﻿using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labar12._1
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;
        public int Count { get; set; } = 0;

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            Count++;
            if (beg != null)
            {
                beg.Prev = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            Count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Prev = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("список пуст");
            for (int i = 0; i < size; i++)
            {
                T newItem = new T();
                newItem.RandomInit();
                AddToEnd(newItem);
            }
        }

        public MyList(T[] collection)
        {
            if (collection == null || collection.Length == 0) throw new Exception("пустая коллекция");
            foreach (var item in collection)
            {
                AddToEnd(item);
            }
        }

        public MyList(MyList<T> list)
        {
            if (list == null || list.Count == 0) throw new Exception("пустая коллекция");
            Point<T> current = list.beg;
            while (current != null)
            {
                AddToEnd(current.Data);
                current = current.Next;
            }
        }

        public void PrintList()
        {
            Console.WriteLine();
            if (Count == 0)
                Console.WriteLine("Список пуст");
            Point<T>? current = beg;
            for (int i = 1; current != null; i++)
            {
                Console.WriteLine($"{i}. {current}");
                current = current.Next;
            }
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data.Equals(item)) return current;
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("список пустой");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            Count--;
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            if (pos.Prev == null)
            {
                beg = beg?.Next;
                if (beg != null) beg.Prev = null;
                return true;
            }
            if (pos.Next == null)
            {
                end = end?.Prev;
                if (end != null) end.Next = null;
                return true;
            }
            Point<T>? next = pos.Next;
            Point<T>? prev = pos.Prev;
            pos.Next.Prev = prev;
            pos.Prev.Next = next;
            return true;
        }

        public void AddPointByIndex(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Индекс за границами");
            }

            if (index == 0)
            {
                AddToBegin(item);
            }
            else if (index == Count)
            {
                AddToEnd(item);
            }
            else
            {
                Point<T> current = beg;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                T newItemData = (T)item.Clone();
                Point<T> newItem = new Point<T>(newItemData);

                newItem.Next = current.Next;
                newItem.Prev = current;
                current.Next.Prev = newItem;
                current.Next = newItem;
                Count++;
            }
        }

        public void RemoveOddIndexes()
        {
            if (Count == 0)
            {
                return;
            }

            Point<T>? current = beg;

            int index = 1;
            while (current != null)
            {
                Point<T>? next = current.Next;
                if (index % 2 != 0)
                {
                    RemoveItem(current.Data);
                }
                current = next;
                index++;
            }
        }

        public void DeleteList()
        {
            Point<T>? current = beg;
            while (current != null)
            {
                Point<T>? next = current.Next;
                current.Prev = null;
                current.Next = null;
                current = next;
            }
            beg = end = null;
            Count = 0;
        }
    }
}