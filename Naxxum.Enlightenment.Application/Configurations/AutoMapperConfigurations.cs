using System.Reflection;
using AutoMapper;
using Naxxum.Enlightenment.Application.Profiles;

namespace Naxxum.Enlightenment.Application.Configurations;

public static class AutoMapperConfigurations
{
    public static Assembly Assemblies => typeof(UserMappingProfile).Assembly;

    public static MapperConfiguration MapperConfiguration => new(c => c.AddMaps(Assemblies));
}