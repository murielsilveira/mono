using System;
using SQLite;

namespace Library
{
    public class Database
    {
        public Database()
        {
            
        }

        public void Conectar()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "muriel.db3";
            SQLiteConnection conexao = new SQLiteConnection(path);
        }
    }
}

