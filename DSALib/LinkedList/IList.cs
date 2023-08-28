using System;
using System.Collections.Generic;
using System.Text;

namespace DSALib.LinkedList
{
    interface IList<T>
    {
        void Add(int index, T data);
        void AddLast(T data);
        T RemoveAt(int index);
        bool RemoveItem(T item);
        bool IsEmpty();
        int Size();
        void Clear();
        T Get(int index);
        int IndexOf(T item);
        bool Contains(T item);
    }
}
