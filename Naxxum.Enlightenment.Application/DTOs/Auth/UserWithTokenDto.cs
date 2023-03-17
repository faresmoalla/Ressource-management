﻿namespace Naxxum.Enlightenment.Application.DTOs.Auth;

public record UserWithTokenDto(int Id, string Username)
{
    public string? Token { get; set; }
};