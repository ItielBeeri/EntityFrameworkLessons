using LoadRelatedEntities.DAL;
using LoadRelatedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

namespace LoadRelatedEntities.BL
{
    public class OrdersManager
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var context = new OrdersContext())
            {
                //var context = new OrdersContext();
                context.Database.Log = sql => Trace.WriteLine("EF log: " + sql);
                return context.Orders
                    .Where(o=>o.OrderID == 10248)
                    .Include(o=>o.Customer.Orders)
                    .Include(o=>o.Order_Details.Select(od=>od.Product))
                    .ToArray();
            }
        }
    }
}
