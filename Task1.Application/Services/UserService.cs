using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Application.Interfaces;
using Task1.Domain.Entities;

namespace Task1.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByConditionAsync(u => u.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<bool> UpdateUserAsync(Guid id, User updatedUser)
        {
            var existingUser = await _userRepository.GetByConditionAsync(u => u.Id == id);
            if (existingUser == null)
                return false;

            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            existingUser.Role = updatedUser.Role;

            await _userRepository.UpdateAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByConditionAsync(u => u.Id == id);
            if (user == null)
                return false;

            await _userRepository.DeleteAsync(user.Id);
            return true;
        }

        public async Task<bool> PromoteToAdminAsync(Guid userId)
        {
            var user = await _userRepository.GetByConditionAsync(u => u.Id == userId);
            if (user == null || user.Role == UserRole.Admin)
                return false;

            user.Role = UserRole.Admin;
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }

}