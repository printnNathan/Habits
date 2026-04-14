using Habits.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Insert(User user);
        Task Update(User user);
        Task Delete(Guid id);
        Task<User> GetById(Guid id);
        Task<IEnumerable<User>> GetAll();
    }
}
