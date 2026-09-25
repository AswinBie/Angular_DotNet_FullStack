using System;
using Domain.Entities;

namespace Domain.Interface;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);

    Task<List<string>> GetUserRolesByEmailAsync(string email);
}
