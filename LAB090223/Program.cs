using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB090223
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard MyCard = new CreditCard("1234567890123456", "Smith J. A.", "113", DateTime.Parse("2025-12-31"));
            Console.WriteLine(MyCard);

            Console.ReadKey();
        }
    }
}
