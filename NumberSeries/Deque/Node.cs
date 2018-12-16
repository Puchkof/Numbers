using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSeries
{
    /// <summary>
    /// Node of deque
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        // Value of node
        public T Value { get; set; }

        //Next and previous nodes
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
