using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedWithEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductsContext())
            {
                foreach (var p in context.Products.Where(p=>p.ProductName.StartsWith("a")))
                {
                    Console.WriteLine(p.ProductName + " in category " + p.Category.CategoryName);
                }
            }
            Console.ReadLine();
        }
    }
}
