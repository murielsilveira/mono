using System;
using SQLite;

namespace Library.Models
{
    [Table("clients")]
    public class Client : ModelBase
    {
        public Client()
        {
        }

        [Column("name"), Collation("NOCASE")]
        public string Name { get; set; }
    }
}
