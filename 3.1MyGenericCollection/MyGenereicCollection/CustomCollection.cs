using System;
using System.Collections;
using System.Collections.Generic;


namespace MyGenereicCollection
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private T[] _items;
        public T this[int index] => (T)_items[index]; // to get item by index from _items

        public CustomCollection(T[] collection)
        {
            _items = collection;
        }

        public CustomCollection()
        {
            _items = new T[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {

            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = item;
        }

        public int Count()
        {
            return _items.Length;
        }

        public void Sort()
        {
            IEnumerable<T> sortAscendingQuery =
            from item in _items
            orderby item //"ascending" is default
            select item;
            var sortedArray = sortAscendingQuery.ToArray();

            for (int i = 0; i < sortedArray.Length; i++) 
            {
                _items[i] = sortedArray[i];
            }    
        }

        public void SetDefaultAt(int index)
        {
            _items[index] = default(T);
        }

        private class MyEnumerator : IEnumerator<T>
        {
            private CustomCollection<T> collection;
            private int _index = -1;

            public MyEnumerator(CustomCollection<T> collection)
            {
                this.collection = collection;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < collection._items.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return collection._items[_index];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }
        }
    }
}
