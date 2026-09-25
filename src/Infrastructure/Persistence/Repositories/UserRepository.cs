using System;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(BlogDbContext blogDbContext) : GenericRepository<User>(blogDbContext), IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await blogDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<string>> GetUserRolesByEmailAsync(string email)
    {
        return await blogDbContext.Users
            .Where(u => u.Email == email)
            .SelectMany(u => u.UserRoles)
            .Select(u => u.Role.Name)
            .ToListAsync();
        throw new NotImplementedException();
    }

}
