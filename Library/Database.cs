using System;
using SQLite;

namespace Library
{
    public class Database
    {
        string ErroBD;

        public Database()
        {
            
        }

        public void Conectar()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "muriel.db3";

            this.ErroBD = string.Empty;
            var r = SQLite3.Shutdown();
            if (r != SQLite3.Result.OK)
                this.ErroBD = string.Format("Erro ao configurar SQLite!!! Shutdown {0}", r);
            r = SQLite3.Config(SQLite3.ConfigOption.Serialized);
            if (r != SQLite3.Result.OK)
                this.ErroBD = string.Format("Erro ao configurar SQLite!!! Config {0}", r);
            r = SQLite3.Initialize();
            if (r != SQLite3.Result.OK)
                this.ErroBD = string.Format("Erro ao configurar SQLite!!! Initialize {0}", r);

            if (string.IsNullOrWhiteSpace(this.ErroBD))
                Console.WriteLine("Não deu ErroBD");
            else
                Console.WriteLine(this.ErroBD);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            SQLiteConnection conexao = new SQLiteConnection(path);
        }
    }
}
