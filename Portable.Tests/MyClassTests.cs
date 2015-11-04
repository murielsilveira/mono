using NUnit.Framework;
using System;

namespace Portable.Tests
{
	[TestFixture ()]
	public class MyClassTests
	{
		[Test ()]
		public void TestCase()
		{
			var myClass = new MyClass();
			
            var result = myClass.Sum(2, 2);

            Assert.AreEqual(4, result);
		}
	}
}
