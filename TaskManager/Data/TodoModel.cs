using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TaskManager.Data
{
    public class TodoModel
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Todo { get; set; }
    }
}
