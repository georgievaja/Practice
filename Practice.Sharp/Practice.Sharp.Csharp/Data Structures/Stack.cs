using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp.Data_Structures
{
    /// <summary>
    /// Stack data structure
    /// </summary>
    public sealed class Stack<T>
    {
        private const int DefaultSize = 10;
        private T[] Array { get; set; }
        private int Size { get; set; }

        public Stack(int capacity)
        {
            Array = new T[capacity];
            Size = 0;
        }

        public Stack(
            [CanBeNull] ICollection<T> items) 
            : this(items?.Count ?? DefaultSize)
        {
            if (items == null) return;

            using var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
                Push(enumerator.Current);
        }

        /// <summary>
        /// Deletes last inserted item
        /// </summary>
        public T Pop()
        {
            if (Size == 0) throw new InvalidOperationException("Stack underflow");

            return Array[--Size];
        }

        /// <summary>
        /// Adds an item
        /// </summary>
        public void Push(T item)
        {
            if (Size == Array.Length) throw new InvalidOperationException("Stack overflow");
            Array[Size++] = item;
        }

        /// <summary>
        /// Copies the Stack to an array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            var objArray = new T[Size];
            var i = 0;
            while (i < Size)
            {
                objArray[i] = Array[i];
                i++;
            }
            return objArray;
        }
    }
}
