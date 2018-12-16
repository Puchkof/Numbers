using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your index: ");
                    var index = Convert.ToInt32(Console.ReadLine());
                    NumberSeries.PrintNumberByIndex(index);
                }
                catch
                {
                    Console.WriteLine("Check your input and try again");
                }
            }
        }
    }
}