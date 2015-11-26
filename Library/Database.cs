using System;
using SQLite;
using System.Linq;
using System.Reflection;

namespace Library
{
    public class Database
    {
        SQLiteConnection database;
        static object locker = new Object();


        public Database()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "muriel.db3";
            string ErroBD = string.Empty;

            var r = SQLite3.Shutdown();
            if (r != SQLite3.Result.OK)
                ErroBD = string.Format("Erro ao configurar SQLite!!! Shutdown {0}", r);
            r = SQLite3.Config(SQLite3.ConfigOption.Serialized);
            if (r != SQLite3.Result.OK)
                ErroBD = string.Format("Erro ao configurar SQLite!!! Config {0}", r);
            r = SQLite3.Initialize();
            if (r != SQLite3.Result.OK)
                ErroBD = string.Format("Erro ao configurar SQLite!!! Initialize {0}", r);

            if (string.IsNullOrWhiteSpace(ErroBD))
                Console.WriteLine("Não deu ErroBD");
            else
                Console.WriteLine(ErroBD);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            database = new SQLiteConnection(path);
        }

        public void DropTables()
        {
            var models = from t in Assembly.GetExecutingAssembly ().GetTypes ()
                         where t.IsClass && t.IsPublic && t.Namespace == "Library.Models"
                            && t.IsSubclassOf(typeof(Library.Models.ModelBase))
                         select t;

            foreach (var model in models)
            {
                var dropMethod = typeof(SQLiteConnection).GetMethod("DropTable", new Type[] { } ).MakeGenericMethod(model);
                dropMethod.Invoke(database, new object[] { });
            }
        }

        public void CreateTables()
        {
            var models = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.IsClass && t.IsPublic && t.Namespace == "Library.Models"
                            && t.IsSubclassOf(typeof(Library.Models.ModelBase))
                        select t;
            
            foreach (var model in models)
            {
                var createMethod = typeof(SQLiteConnection).GetMethod("CreateTable", new Type[] { typeof(CreateFlags) }).MakeGenericMethod(model);
                createMethod.Invoke(database, new object[] { CreateFlags.None });
            }
        }

        public int SaveItem<T>(T item) where T : Models.IModel, new()
        {
            lock (locker)
            {
                if (item.ID == 0)
                {
                    var id = database.Insert(item);
                    return id;
                }
                else
                {
                    var objeto = GetItem<T>(item.ID);
                    if (objeto != null)
                        database.Update(item);
                    else
                        database.Insert(item);
                    return item.ID;
                }
            }
        }

        public T GetItem<T>(int id) where T : Models.IModel, new()
        {
            lock (locker)
            {
                var item = database.Table<T>().Where(x => x.ID == id).ToList().FirstOrDefault();
                return item;
            }
        }
    }
}
