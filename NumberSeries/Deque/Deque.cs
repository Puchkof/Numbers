using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSeries
{
    public class Deque<T> : IEnumerable<T>
    {
        // Size of deque
        int size;

        // Head and tail of deque
        Node<T> head;
        Node<T> tail;

        /// <summary>
        /// Adding element to the tail
        /// </summary>
        /// <param name="value">Value of element</param>
        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            size++;
        }

        /// <summary>
        /// Adding element to the head
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> temp = head;
            node.Next = temp;
            head = node;

            if (size == 0)
                tail = head;
            else
                temp.Previous = node;

            size++;
        }

        /// <summary>
        /// Remove element from the head
        /// </summary>
        /// <returns>Removed element</returns>
        public T RemoveFirst()
        {
            if (size == 0)
                throw new InvalidOperationException();
            T output = head.Value;

            if (size == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            size--;
            return output;
        }

        /// <summary>
        /// Remove element from the tail
        /// </summary>
        /// <returns>Removed element</returns>
        public T RemoveLast()
        {
            if (size == 0)
                throw new InvalidOperationException();
            T output = tail.Value;

            if (size == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            size--;
            return output;
        }

        /// <summary>
        /// First element
        /// </summary>
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Value;
            }
        }

        /// <summary>
        /// Last element
        /// </summary>
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Value;
            }
        }

        public int Count { get { return size; } }
        public bool IsEmpty { get { return size == 0; } }

        /// <summary>
        /// Clears the deque
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        /// <summary>
        /// Check if deque contains such an element
        /// </summary>
        /// <param name="value">Value of element</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return element with such an index
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns></returns>
        public T ElementAt(int index)
        {
            if (size == 0)
                throw new InvalidOperationException();

            if (index > size - 1)
            {
                throw new IndexOutOfRangeException();
            }
            var current = head;

            if (index == 0)
            {
                return current.Value;
            }
            int i = 0;

            while (current != null && i < index)
            {
                current = current.Next;
                i++;
            }

            if (current != null)
            {
                return current.Value;
            }
            else
            {
                return default(T);
            }
        }
    }
}
