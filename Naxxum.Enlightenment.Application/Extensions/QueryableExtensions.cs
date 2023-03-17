using AutoMapper.QueryableExtensions;
using Naxxum.Enlightenment.Application.Configurations;

namespace Naxxum.Enlightenment.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TResult> MapTo<TResult>(this IQueryable queryable)

    {
        return queryable.ProjectTo<TResult>(AutoMapperConfigurations.MapperConfiguration);
    }
}