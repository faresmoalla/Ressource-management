using AutoMapper;
using Naxxum.Enlightenment.Application.DTOs.Features;
using Naxxum.Enlightenment.Domain.Entities;

namespace Naxxum.Enlightenment.Application.Profiles;

public class FeatureMappingProfile : Profile
{
    public FeatureMappingProfile()
    {
        CreateMap<Feature, FeatureDto>();
    }
}