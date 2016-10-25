using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BL.Test
{
    [TestClass]
    public class ProductsManager_TestFixture
    {
        [TestMethod]
        public void GetAllProducts_Test()
        {
            var manager = new ProductsManager();
            var products = manager.GetAllProducts();
            Assert.AreEqual(78, products.Count());
        }
    }
}
