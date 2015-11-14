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
            string path = "URI=file:" + AppDomain.CurrentDomain.BaseDirectory + "muriel.db3";
            using (var conn = new SqliteConnection(path))
            {
                conn.Open();
                conn.Clone();
            }
        }
    }
}

