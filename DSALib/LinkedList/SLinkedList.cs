using System;
using System.Collections.Generic;
using System.Text;

namespace DSALib.LinkedList
{
    public class SLinkedList<T> : IList<T>
    {
        protected Node Head { get; set; }
        protected Node Tail { get; set; }
        protected int Count { get; set; }

        public SLinkedList()
        {
            Head = new Node();
            Tail = new Node();
            Head.Next = Tail;
            Tail.Next = Head;
            Count = 0;
        }

        public SLinkedList(IEnumerable<T> data) : this() 
        {
            foreach (var d in data)
            {
                AddLast(d);
            }            
        }

        public class Node
        {
            public Node(Node next = null)
            {
                Next = next;
            }
            public Node(T data, Node next = null)
            {
                Data = data;
                Next = next;
            }

            public T Data { get; set; }

            public Node Next { get; set; }

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(Head)--->");

            foreach(T data in GetDataList())
            {
                sb.Append($"({data})--->");
            }

            sb.Append("(Tail)");

            return sb.ToString();
        }

        public void Add(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            var newNode = new Node(data);
            var prevNode = Head;

            int cursor = -1;

            while (cursor < index - 1)
            {
                prevNode = prevNode.Next;
                cursor++;
            }

            var curNode = prevNode.Next;
            prevNode.Next = newNode;
            newNode.Next = curNode;

            if (index == Count)
            {
                Tail.Next = newNode;
            }
            
            Count++;
        }

        public void AddLast(T data)
        {
            var node = new Node(data, Tail);
            Tail.Next.Next = node;
            Tail.Next = node;
            Count++;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            var prevNode = Head;

            int cursor = -1;

            while (cursor < index - 1)
            {
                prevNode = prevNode.Next;
                cursor++;
            }

            var curNode = prevNode.Next;
            prevNode.Next = curNode.Next;
            curNode.Next = null;

            if (index == Count - 1)
            {
                Tail.Next = prevNode;
            }

            Count--;
            return curNode.Data;
        }

        public bool RemoveItem(T item)
        {
            var curNode = Head.Next;
            var prevNode = Head;

            while (curNode != Tail)
            {
                if (curNode.Data.Equals(item))
                {
                    prevNode.Next = curNode.Next;
                    if (curNode.Next == Tail) Tail.Next = prevNode;
                    curNode.Next = null;
                    Count--;
                    return true;
                }

                curNode = curNode.Next;
                prevNode = prevNode.Next;
            }

            return false;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int Size()
        {
            return Count;
        }

        public void Clear()
        {
            Head.Next = Tail;
            Tail.Next = Head;
            Count = 0;
        }

        public T Get(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            var prevNode = Head;
            int cursor = -1;

            while (cursor < index - 1)
            {
                prevNode = prevNode.Next;
                cursor++;
            }

            return prevNode.Next.Data;
        }

        public int IndexOf(T item)
        {
            bool found = false;
            var curNode = Head.Next;
            int foundAt = 0;

            while (curNode != Tail)
            {
                found = curNode.Data.Equals(item);
                if (found) break;
                curNode = curNode.Next;
                foundAt++;
            }

            if (found) return foundAt;
            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
    }

}
