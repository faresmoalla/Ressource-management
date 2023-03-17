using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Application.DTOs.Auth;
using Naxxum.Enlightenment.Application.DTOs.Users;
using Naxxum.Enlightenment.Application.Handlers.Command.Auth;
using Naxxum.Enlightenment.Application.Services;
using Naxxum.Enlightenment.Domain.Entities;
using Naxxum.Enlightenment.Domain.Enums;
using Naxxum.Enlightenment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Application.Handlers.Command
{
    public record ClientDto( string Nom, 
       string Prenom, string Email, string Telephone, string Adresse
        , DateTime? EnvoyéLe, DateTime? DateObtentionBac) : IRequest<OperationResult<UserDto>>;


    internal class CreateClientCommand : IRequestHandler<ClientDto, OperationResult<ClientDto>>
    {
        private readonly IClientRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClientCommand> _logger;

        public CreateClientCommand(IClientRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<CreateClientCommand> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<UserDto>> Handle(RegisterDto request, CancellationToken cancellationToken)
        {
 
            var user = Client.Create(request.Nom, request.Prenom, request.Username, request.Username,
                request.Username, request.Username, request.Username,);
            _userRepository.Add(user);

            _logger.LogInformation("Saving new user to database.");
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("New user has been created successfully!");
            return _mapper.Map<ClientDto>(user);
        }
    }