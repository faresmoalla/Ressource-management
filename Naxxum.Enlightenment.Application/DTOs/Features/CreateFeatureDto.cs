using System.ComponentModel.DataAnnotations;

namespace Naxxum.Enlightenment.Application.DTOs.Features;

public record CreateFeatureDto([Required, StringLength(50)] string Name, [StringLength(1000)] string? Description);