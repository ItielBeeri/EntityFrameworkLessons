using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassingDataBetweenTiers.Entities;
using PassingDataBetweenTiers.BL;
using System.Linq;
using System.Diagnostics;

namespace PassingDataBetweenTiers.BL.Test
{
    [TestClass]
    public class ProductsManager_TestFixture
    {
        [TestMethod]
        public void GetAllProducts_Test()
        {
            var manager = new ProductsManager();
            var products = manager.GetAllProducts();
            Assert.IsTrue(products.Any());
            foreach (var product in products)
            {
                Trace.WriteLine(product.ProductName);
            }
        }
    }
}
