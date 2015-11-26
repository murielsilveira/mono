using NUnit.Framework;
using System;
using Library.Models;

namespace Library.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestSQLiteDatabase()
        {
            var database = new Database();
            database.DropTables();
            database.CreateTables();

            var id = database.SaveItem(new Client(){
                Name = "John Doe"
            });
            var entry = database.GetItem<Client>(id);

            Assert.AreEqual(id, entry.ID);
            Assert.AreEqual("John Doe", entry.Name);
        }
    }
}
