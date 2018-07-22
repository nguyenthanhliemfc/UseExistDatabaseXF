using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LocalDatabaseDS.Models
{
    public class StaffTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
