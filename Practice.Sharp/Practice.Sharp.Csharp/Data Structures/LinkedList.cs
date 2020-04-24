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
            Tail = null;
        }

        public DoubleLinkedNode<T> Head { get; private set; }
        public DoubleLinkedNode<T> Tail { get; private set; }

        public DoubleLinkedNode<T> Search(int key)
        {
            var x = Head;
            while (x != null && x.Key != key)
            {
                x = Head.Next;
            }

            return x;
        }

        public void Insert(int key, T data)
        {
            var x = new DoubleLinkedNode<T>(key, data, Head);
            Head = x;
        }

        public void Delete(int key)
        {
            var el = Search(key);
            if (el == null) return;

            var next = el.Next;
            var prev = el.Prev;

            if (next != null)
            {
                next.Prev = prev;
            }

            if (prev != null)
            {
                prev.Next = next;
            }
        }

    }

    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode(int key, T data, DoubleLinkedNode<T> next)
        {
            Key = key;
            Data = data;
            Prev = null;
            Next = next;
        }

        public int Key { get; set; }
        public DoubleLinkedNode<T> Prev { get; set; }
        public DoubleLinkedNode<T> Next { get; set; }

        public T Data { get; set; }
    }
}
