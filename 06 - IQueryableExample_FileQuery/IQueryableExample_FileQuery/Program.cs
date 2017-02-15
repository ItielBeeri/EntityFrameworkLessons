using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableExample_FileQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempFolderQuery = new FileQuery(@"C:\Temp");
            foreach (FileData file in tempFolderQuery.Where(f => f.Name == "Untitled1.ps1"))
            {
                Console.WriteLine("The first line in file '{0}' is '{1}'.", file.Name, file.FirstLine);
            }
            Console.ReadLine();
        }
    }
}
