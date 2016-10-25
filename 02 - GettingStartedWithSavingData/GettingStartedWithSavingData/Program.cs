using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedWithSavingData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductsContext())
            {
                //InsertProduct(context);
                //UpdateProduct(context);
                //DeleteProduct(context);
                ComplexChange(context);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void InsertProduct(ProductsContext context)
        {
            var prod1 = new Product
            {
                ProductName = "Bamba"
            };
            context.Products.Add(prod1);
            context.SaveChanges();
        }

        private static void UpdateProduct(ProductsContext context)
        {
            var bamba = context.Products.SingleOrDefault(p => p.ProductName == "Bamba");
            if (bamba != null)
            {
                bamba.UnitPrice = 3;
                context.SaveChanges();
            }
        }

        private static void DeleteProduct(ProductsContext context)
        {
            var bamba = context.Products.SingleOrDefault(p => p.ProductName == "Bamba");
            if (bamba != null)
            {
                context.Products.Remove(bamba);
                context.SaveChanges();
            }
        }

        private static void ComplexChange(ProductsContext context)
        {
            var beverages = context.Categories.Find(1);
            if (beverages != null)
            {
                beverages.Description = "Fake description";
                var newProd = new Product
                {
                    ProductName = "Bisli",
                    Category = beverages
                };
                context.Products.Add(newProd);
                context.SaveChanges();
            }
        }
    }
}
