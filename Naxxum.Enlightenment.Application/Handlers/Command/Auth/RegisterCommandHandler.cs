using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Application.DTOs.Auth;
using Naxxum.Enlightenment.Application.DTOs.Users;
using Naxxum.Enlightenment.Application.Services;
using Naxxum.Enlightenment.Domain.Entities;
using Naxxum.Enlightenment.Domain.Enums;
using Naxxum.Enlightenment.Domain.Shared;

namespace Naxxum.Enlightenment.Application.Handlers.Command.Auth;

internal class RegisterCommandHandler : IRequestHandler<RegisterDto, OperationResult<UserDto>>
{
    private readonly IUsersRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(IUsersRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper,
        ILogger<RegisterCommandHandler> logger)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<OperationResult<UserDto>> Handle(RegisterDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking for username duplication");
        if (await _userRepository.AnyAsync(u => u.Username == request.Username, cancellationToken))
        {
            _logger.LogInformation("Username '{Username}' you have provided is already exists.", request.Username);
            return DomainErrors.UsernameIsAlreadyExists;
        }

        _logger.LogInformation("Username is not exists, creating new user with username and encrypted password.");
        var (passwordHash, passwordSalt) = Sha512PasswordService.Generate(request.Password);
        var user = User.Create(request.Username, passwordHash, passwordSalt);
        _userRepository.Add(user);

        _logger.LogInformation("Saving new user to database.");
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("New user has been created successfully!");
        return _mapper.Map<UserDto>(user);
    }
}