using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user =  await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        if (user == null)
            throw new ArgumentException("Usuario não encontrado.");

        return user;
    }
}