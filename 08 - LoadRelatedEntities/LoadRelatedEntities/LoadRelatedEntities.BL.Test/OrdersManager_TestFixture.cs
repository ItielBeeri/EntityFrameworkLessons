using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoadRelatedEntities.Entities;
using LoadRelatedEntities.BL;
using System.Linq;
using System.Diagnostics;

namespace LoadRelatedEntities.BL.Test
{
    [TestClass]
    public class OrdersManager_TestFixture
    {
        [TestMethod]
        public void GetOrders_Test()
        {
            var manager = new OrdersManager();
            var orders = manager.GetOrders();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            var order = orders.First();
            Assert.IsFalse(string.IsNullOrEmpty(order.CustomerID));
            Assert.IsNotNull(order.Customer);
            Trace.WriteLine("Order's customer company name: " + order.Customer.CompanyName);
        }
    }
}
