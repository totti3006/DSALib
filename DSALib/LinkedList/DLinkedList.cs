using System;
using System.Collections.Generic;
using System.Text;

namespace DSALib.LinkedList
{
    public class DLinkedList<T> : IList<T>
    {
        protected Node Head { get; set; }
        protected Node Tail { get; set; }
        protected int Count { get; set; }

        public DLinkedList() 
        {
            Head = new Node();
            Tail = new Node();
            Head.Next = Tail;
            Tail.Next = null;
            Tail.Prev = Head;
            Head.Prev = null;
            Count = 0;
        }

        public DLinkedList(IEnumerable<T> data) : this() 
        {
            foreach (var d in data)
            {
                AddLast(d);
            }
        }

        public class Node
        {
            public Node(Node next = null, Node prev = null)
            {
                Next = next;
                Prev = prev;
            }
            public Node(T data, Node next = null, Node prev = null)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }

            public T Data { get; set; }

            public Node Next { get; set; }
            public Node Prev { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }
        public IEnumerable<T> GetDataList()
        {
            Node current = Head.Next;
            while (current != Tail)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> GetDataReversed()
        {
            var current = Tail.Prev;
            while (current != Head)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(Head)<-->");

            foreach (T data in GetDataList())
            {
                sb.Append($"({data})<-->");
            }

            sb.Append("(Tail)");

            return sb.ToString();
        }

        public void Add(int index, T data)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T data)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(T item)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
