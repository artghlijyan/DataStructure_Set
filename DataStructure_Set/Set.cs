using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure_Set
{
    class Set<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> _items = new List<T>();

        public int Count { get => this._items.Count; }

        public Set()
        {

        }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>(this._items);

            foreach (T item in other._items)
            {
                if (!result.Contain(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();

            foreach (T item in other)
            {
                if (_items.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(this);

            foreach (T item in other)
            {
                if (result.Contain(item))
                {
                    result.Remove(item);
                }
            }

            return result;
        }

        public Set<T> SymetricDifference(Set<T> other)
        {
            Set<T> result = this.Union(this);

            foreach (T item in this)
            {
                if (other.Contain(item) && result.Contain(item))
                {
                    result.Remove(item);
                    other.Remove(item);
                }
            }

            result.AddRange(other);
            return result;
        }

        public bool IsSubSet(Set<T> other)
        {
            int count = 0;

            foreach (var item in other)
            {
                if (this.Contain(item))
                {
                    count++;
                }
            }

            return count == this.Count ? true : false;
        }

        public void Add(T item)
        {
            if (this.Contain(item))
            {
                throw new InvalidOperationException("The value already exists in set");
            }

            this._items.Add(item);
        }

        internal bool Remove(T item)
        {
            return _items.Remove(item);
        }

        internal void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public bool Contain(T item)
        {
            return this._items.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
