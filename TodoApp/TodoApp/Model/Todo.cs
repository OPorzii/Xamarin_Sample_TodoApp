using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TodoApp.Model
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsDone { get; set; }

    }
}
