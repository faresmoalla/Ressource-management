using System.ComponentModel.DataAnnotations;
using MediatR;
using Naxxum.Enlightenment.Domain.Shared;

namespace Naxxum.Enlightenment.Application.DTOs.Auth;

public record LoginDto([Required] string Username, [Required] string Password) : IRequest<OperationResult<UserWithTokenDto>>;