using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    internal class SquaresCollection : ICollection<SquareCoordinate>
    {
        private List<SquareCoordinate> __squares = new List<SquareCoordinate>();

        public int Count
        {
            get
            {
                return this.__squares.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(SquareCoordinate item)
        {
            if (item.IsValid())
            {
                this.__squares.Add(item);
            }
        }

        public void Clear()
        {
            this.__squares.Clear();
        }

        public bool Contains(SquareCoordinate item)
        {
            return this.__squares.Contains(item);
        }

        public void CopyTo(SquareCoordinate[] array, int arrayIndex)
        {
            this.__squares.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SquareCoordinate> GetEnumerator()
        {
            return this.__squares.GetEnumerator();
        }

        public bool Remove(SquareCoordinate item)
        {
            return this.__squares.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.__squares.GetEnumerator();
        }
    }
}