using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(Guid id, User updatedUser);
        Task<bool> DeleteUserAsync(Guid id);
        Task<bool> PromoteToAdminAsync(Guid userId);
    }
}