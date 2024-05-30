using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;

namespace labar12._1
{
    public class Point<T> where T : ICloneable
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Prev { get; set; }
        public Point()
        {
            this.Data = default(T);
            this.Next = null;
            this.Prev = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
        public Point<T> Clone()
        {
            T newData = (T)Data.Clone();
            Point<T> newPoint = new Point<T>(newData);
            return newPoint;
        }
    }
}