using Habits.Domain.Users;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UnitOfWork _unitOfWork;
    
            public UserRepository(UnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }


        public async Task Insert(User user)
        {
            const string query = @"Insert into user(id, email, passwordHash, createdAt) values
                                 (@id, @emai, @passwordHash, @createdAt);";

            using var command = new MySqlCommand(query, _unitOfWork.Connection, _unitOfWork.Transaction);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@createdAt", user.CreatedAt);

            await command.ExecuteScalarAsync();
        }
    }
}
