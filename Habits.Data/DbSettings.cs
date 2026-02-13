using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits.Data
{
    public class DbSettings
    {
        public static MySqlConnection Build()
        {
            return new MySqlConnection("Server=localhost;Database=Habits;Uid=root;Pwd=root;");
        }
    }
}
