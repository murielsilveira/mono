using System;
using SQLite;

namespace Library.Models
{
    public class ModelBase : IModel
    {
        public ModelBase()
        {
        }

        [Column("id"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
