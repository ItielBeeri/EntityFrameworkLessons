using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace BL
{
    public class ProductsManager : IProductsManager
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new ProductsContext())
            {
                return context.Products.ToArray();
            }
        }
    }
}
