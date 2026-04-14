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

        public async Task Update(User user)
        {
            const string query = @"Update users set email = @email, passwordHash = @passwordHash where id = @id;";
            await _unitOfWork.Connection.ExecuteAsync(
                query,
                user,
                _unitOfWork.Transaction
            );
        }

        public async Task Delete(Guid id)
        {
            const string query = @"Delete from users where id = @id;";
            await _unitOfWork.Connection.ExecuteAsync(
                query,
                new { id },
                _unitOfWork.Transaction
            );
        }

        public async Task<User> GetById(Guid id)
        {
            const string query = @"Select * from users where id = @id;";
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<User>(
                query,
                new { id },
                _unitOfWork.Transaction
            );
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            const string query = @"Select * from users;";
            return await _unitOfWork.Connection.QueryAsync<User>(
                query,
                transaction: _unitOfWork.Transaction
            );
        }
    }
}
