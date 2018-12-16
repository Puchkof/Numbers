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
                Console.WriteLine("Enter size of your series: ");

                // Preventing wrong input and System.OutOfMemoryException for too long inputs
                try
                {
                    var size = Convert.ToInt32(Console.ReadLine());
                    var numberSeries = new NumberSeries(size);
                    numberSeries.PrintSeries();
                    Console.WriteLine("Press any key to finish program execution");
                    Console.ReadKey();
                    break;
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Please try again");
                }
            }
        }
    }
}