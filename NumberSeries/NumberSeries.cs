using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSeries
{
    /// <summary>
    /// Class that describes series of numbers
    /// </summary>
    static public class NumberSeries
    {
        static public void PrintNumberByIndex(long index)
        {
            Console.WriteLine("Your index: {0}", index);
            var number = CalculateNumber(index);
            if (number == 0)
            {
                Console.WriteLine("Something went wrong. Try another index");
            }
            else
            {
                Console.WriteLine("Your number: {0}", number);
            }
        }

        static private long CalculateNumber(long index)
        {
            if (index < 0)
            {
                return 0;
            }

            if (index == 0 || index == 1 || index == 2)
            {
                return index == 2 ? 2 : 1;
            }

            try
            {
                // filling deque with three first values
                var deque = new Deque<long>();
                deque.AddLast(1);
                deque.AddLast(1);
                deque.AddLast(2);

                for (long i = 2; i < index; ++i)
                {
                    long value = checked(deque.ElementAt(2) + deque.ElementAt(1) + deque.ElementAt(0));
                    deque.RemoveFirst();
                    deque.AddLast(value);
                }

                return deque.Last();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }
    }
}