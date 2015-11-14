using System;
using Mono.Data.Sqlite;

namespace Library
{
    public class Database
    {
        public Database()
        {
            
        }

        public void Conectar()
        {
            using (var conn = new SqliteConnection("URI=file:/home/muriel/dev/csharp/Mono/muriel.db3"))
            {
                conn.Open();
                conn.Clone();
            }
        }
    }
}

