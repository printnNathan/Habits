using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Domain.Users
{
    public interface IUserService
    {
        Task CreateUser(User user);
    }
}
