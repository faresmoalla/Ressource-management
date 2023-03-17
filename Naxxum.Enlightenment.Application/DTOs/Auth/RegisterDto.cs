using System.ComponentModel.DataAnnotations;
using MediatR;
using Naxxum.Enlightenment.Application.DTOs.Users;
using Naxxum.Enlightenment.Domain.Shared;

namespace Naxxum.Enlightenment.Application.DTOs.Auth;

public record RegisterDto([Required, StringLength(50)] string Username, [Required, StringLength(50)] string Password) : IRequest<OperationResult<UserDto>>;