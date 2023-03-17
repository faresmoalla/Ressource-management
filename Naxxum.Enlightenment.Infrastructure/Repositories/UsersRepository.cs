using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Naxxum.Enlightenment.Infrastructure.Data;
using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Domain.Entities;

namespace Naxxum.Enlightenment.Infrastructure.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    private readonly AppDbContext _dbContext;

    public UsersRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default) =>
        GetUserAsync(u => u.Id == id, cancellationToken);

    public Task<User?> GetUserAsync(Expression<Func<User, bool>> expression,
        CancellationToken cancellationToken = default) =>
        _dbContext.Set<User>().FirstOrDefaultAsync(expression, cancellationToken);
}