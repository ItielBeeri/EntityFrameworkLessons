using PassingDataBetweenTiers.DAL;
using PassingDataBetweenTiers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassingDataBetweenTiers.BL
{
    public class ProductsManager
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToArray();
            }
        }
    }
}
