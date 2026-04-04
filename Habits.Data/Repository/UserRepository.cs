using Dapper;
using Habits.Domain.Entities;
using Habits.Domain.Interfaces;
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
            const string query = @"Insert into users (id, email, passwordHash, createdAt) values
                                 (@id, @email, @passwordHash, @createdAt);";

            await _unitOfWork.Connection.ExecuteAsync(
                query,
                user,
                _unitOfWork.Transaction
            );
        }
    }
}
