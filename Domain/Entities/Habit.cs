using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Domain.Entities
{
    public class Habit
    {
        public Guid MyProperty { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public char Frequency { get; set; }
        public DateTime CreatedAt { get; set; }
        public char IsActive { get; set; }
    }
}
