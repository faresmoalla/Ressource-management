﻿using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Application.DTOs.Auth;
using Naxxum.Enlightenment.Application.Options;
using Naxxum.Enlightenment.Application.Services;
using Naxxum.Enlightenment.Domain.Entities;
using Naxxum.Enlightenment.Domain.Enums;
using Naxxum.Enlightenment.Domain.Shared;

namespace Naxxum.Enlightenment.Application.Handlers.Command.Auth;

internal class LoginCommandHandler : IRequestHandler<LoginDto, OperationResult<UserWithTokenDto>>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(IUsersRepository userRepository, IMapper mapper, IOptions<JwtOptions> jwtOptions,
        ILogger<LoginCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<OperationResult<UserWithTokenDto>> Handle(LoginDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking if username '{request.Username}' is exists.", request.Username);
        var user = await _userRepository
            .GetUserAsync(u => u.Username == request.Username, cancellationToken);

        if (user is null)
        {
            _logger.LogInformation("Username '{request.Username}' is not found.", request.Username);
            return DomainErrors.InvalidUsernameOrPassword;
        }

        if (!Sha512PasswordService.ValidatePassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            _logger.LogInformation("Wrong password for user '{request.Username}'", request.Username);
            return DomainErrors.InvalidUsernameOrPassword;
        }

        _logger.LogInformation("Logging in success for user '{request.Username}', generating JWT token...",
            request.Username);
        var userWithToken = _mapper.Map<UserWithTokenDto>(user);
        userWithToken.Token = GenerateToken(user);
        return userWithToken;
    }

    private string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        };

        var expirationDate =
            DateTime.Now.AddHours(_jwtOptions.ExpirationInHours == 0 ? 5 : _jwtOptions.ExpirationInHours);

        return JwtService.GenerateToken(claims, _jwtOptions.Key, expirationDate);
    }
}