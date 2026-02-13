using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Data
{
    public class UnitOfWork
    {
        private readonly MySqlConnection _connection;
        private MySqlTransaction _transaction;

        public UnitOfWork()
        {
            _connection = DbSettings.Build();
        }
        public async Task BeginTransactionAsync()
        {
            await _connection.OpenAsync();
            _transaction = await _connection.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
            await _connection.CloseAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _connection.CloseAsync();
        }

        public MySqlConnection Connection => _connection;
        public MySqlTransaction Transaction => _transaction;

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

    }
}
