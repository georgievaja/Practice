using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Practice.Sharp.Csharp.Data_Structures
{
    public class LinkedList<T>
    {
        public LinkedList()
        {
            Head = null;
        }

        public DoubleLinkedNode<T> Head { get; private set; }

        public DoubleLinkedNode<T> Search(int key)
        {
            var x = Head;
            while (x != null && x.Key != key)
            {
                x = x.Next;
            }

            return x;
        }

        public void Insert(int key, T data)
        {
            if (Head == null)
            {
                Head  = new DoubleLinkedNode<T>(key, data);
            }
            else
            {
                var x = new DoubleLinkedNode<T>(key, data) {Next = Head};
                Head.Prev = x;
                Head = x;
            }
        }

        public void Delete(int key)
        {
            var el = Search(key);
            if (el == null) return;

            var next = el.Next;
            var prev = el.Prev;

            if (prev != null)
            {
                prev.Next = next;
            }
            else
            {
                Head = next;
            }

            if (next != null)
            {
                next.Prev = prev;
            }
        }

    }

    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode(int key, T data)
        {
            Key = key;
            Data = data;
            Prev = null;
            Next = null;
        }

        public int Key { get; set; }
        public DoubleLinkedNode<T> Prev { get; set; }
        public DoubleLinkedNode<T> Next { get; set; }

        public T Data { get; set; }
    }
}
