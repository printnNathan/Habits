using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Domain.Entities
{
    public class HabitLog
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
