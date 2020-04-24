using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Practice.Sharp.Csharp.Data_Structures
{
    public sealed class Queue
    {
        private const int DefaultQueueCapacity = 10;
        private object[] Array { get; }
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
            Array = new object[capacity];
            Size = 0;
            Head = 0;
            Tail = 0;
        }

        public Queue(
            [CanBeNull] ICollection<object> items) 
            : this(items?.Count ?? DefaultQueueCapacity)
        {
            if (items == null) return;
            using var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Enqueue(enumerator.Current);
            }
        }

        public void Enqueue(object item)
        {
            if (Size == Array.Length) throw new InvalidOperationException("Stack overflow");

            Array[Tail] = item;
            Tail = Tail == Array.Length - 1 ?  0 : Tail + 1;
            Size++;
        }

        public void Dequeue()
        {
            if(Size == 0) throw new InvalidOperationException("Stack underflow");

            Array[Head] = null;
            Head = Head == Array.Length -1 ? 0 : Head + 1;
            Size--;
        }
    }
}
