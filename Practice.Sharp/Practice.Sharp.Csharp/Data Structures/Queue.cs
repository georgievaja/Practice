using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Practice.Sharp.Csharp.Data_Structures
{
    public sealed class Queue<T> where T: class
    {
        private const int DefaultQueueCapacity = 10;
        private T[] Array { get; set; }
        private int Size { get; set; }

        /// <summary>
        /// First element in the queue
        /// </summary>
        public int Head { get; private set; }

        /// <summary>
        /// Last element in the queue
        /// </summary>
        public int Tail { get; private set; }

        public Queue(int capacity)
        {
            Array = new T[capacity];
            Size = 0;
            Head = 0;
            Tail = 0;
        }

        public Queue(
            [CanBeNull] ICollection<T> items) 
            : this(items?.Count ?? DefaultQueueCapacity)
        {
            if (items == null) return;
            using var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Enqueue(enumerator.Current);
            }
        }

        public void Enqueue(T item)
        {
            if(Array.Length == Size)
            {
                var newArray = new T[2 * Array.Length];
                System.Array.Copy(Array, 0, newArray, 0, Size);
                Array = newArray;
            }

            Array[Tail] = item;
            Tail = Tail == Array.Length - 1 ?  0 : Tail++;
            Size++;
        }

        public void Dequeue()
        {
            Array[Head] = null;
            Head = Head == Array.Length - 1 ? 0 : Head++;
            Size--;
        }
    }
}
