using System.Linq.Expressions;
using Naxxum.Enlightenment.Domain.Entities;

namespace Naxxum.Enlightenment.Application.Abstractions;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);
}