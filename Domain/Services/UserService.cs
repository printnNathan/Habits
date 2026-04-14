using Habits.Domain.Entities;
using Habits.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Domain.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task CreateUser(User user)
        {
            var userToCreate = new User
            {
                Id = Guid.NewGuid(),    
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreatedAt = DateTime.UtcNow
            };
            await userRepository.Insert(userToCreate);
        }

        public async Task UpdateUser(User user)
        {
            var userToUpdate = new User
            {
               // Id = Guid.NewGuid(),
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };
            await userRepository.Update(userToUpdate);
        }

    }
}
