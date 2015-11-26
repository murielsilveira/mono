using NUnit.Framework;
using System;

namespace Library.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void ConectarNoSQLite()
        {
            new Database().Conectar();
        }
    }
}
