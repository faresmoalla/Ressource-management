using System.Text.Json.Serialization;

namespace Naxxum.Enlightenment.Application.DTOs;

public record ErrorResultDto(int StatusCode, string Message,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? StackTrace = null);