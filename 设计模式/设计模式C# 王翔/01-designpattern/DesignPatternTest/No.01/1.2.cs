using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern.No._01;

namespace DesignPatternTest.No._01
{
    [TestClass]
    public class AsyncInvokerTest
    {
        [TestMethod]
        public void Test()
        {
            AsyncInvoker asyncInvoker = new AsyncInvoker();
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual<string>("method", asyncInvoker.Output[0]);
            Assert.AreEqual<string>("fast", asyncInvoker.Output[1]);
            Assert.AreEqual<string>("slow", asyncInvoker.Output[2]);
        }
    }
    [TestClass]
    public class RawGenericFactoryTest
    {
        interface IProduct { }
         class ConcreteProduct : IProduct { }
        [TestMethod]
        public void Test()
        {
            string typeName = typeof(ConcreteProduct).AssemblyQualifiedName;
            IProduct product = RawGenericFactory.Create<IProduct>(typeName);
            Assert.IsNotNull(product);
            Assert.AreEqual<string>(typeName, product.GetType().AssemblyQualifiedName);
        }

    }
}
