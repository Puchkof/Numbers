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
    public class NumberSeries
    {
        // I have used Int32 size to prevent program working too long. For other types logic will be the same
        private int seriesSize;
        private int[] numbers;

        /// <summary>
        /// Initializes instance of NumberSeries class
        /// </summary>
        /// <param name="">Series size</param>
        public NumberSeries(int size)
        {
            seriesSize = size;
            numbers = new int[seriesSize];
            InitializeSeries();
        }

        /// <summary>
        /// Initializes numbers in series
        /// </summary>
        private void InitializeSeries()
        {
            if (numbers == null)
            {
                numbers = new int[seriesSize];
            }

            for (int i = 0; i < seriesSize; ++i)
            {
                // filling series with 3 first values
                if (i == 0 || i == 1 || i == 2)
                {
                    numbers[i] = i == 2 ? 2 : 1;
                    continue;
                }


                // preventing OverflowException
                try
                {
                    // calculating value for series
                    int value = checked(numbers[i - 1] + numbers[i - 2] + numbers[i - 3]);
                    numbers[i] = value;
                }
                catch
                {
                    int j = i;

                    while (j < seriesSize)
                    {
                        numbers[j++] = 0;
                    }

                    break;
                }
            }
        }

        public void PrintSeries()
        {
            // printing header
            Console.WriteLine("Number series    Index");

            var lineFormat = "{0, 13}{1, 9}";
            for (int i = 0; i < seriesSize; ++i)
            {
                if (numbers[i] == 0)
                {
                    Console.WriteLine("Next number/numbers are more than Int32.MaxValue");
                    break;
                }
                Console.WriteLine(string.Format(lineFormat, numbers[i], i));
            }
        }
    }
}