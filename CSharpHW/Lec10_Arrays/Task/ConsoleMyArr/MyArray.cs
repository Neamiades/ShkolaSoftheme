using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMyArr
{
    class MyArray<T> : IEnumerable<T>
    {
        private int _used;
        private int _defaultSize = 16;
        private T[] _array;

        public MyArray() => _array = new T[_defaultSize];

        public MyArray<T> Add(T item)
        {
            EnlargeIfFull();
            _array[_used++] = item;

            return this;
        }

        public bool Contains(T item) => _array.Contains(item);

        public T GetByIndex(int idx) => _array[idx];

        public T this[int idx]
        {
            get => _array[idx];
            set => _array[idx] = value;
        }

        public int Lenght => _used;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _used; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnlargeIfFull()
        {
            if (_used == _array.Length)
            {
                var bigger = _used + _defaultSize;

                var biggerArray = new T[bigger];
                _array.CopyTo(biggerArray, 0);

                _array = biggerArray;
            }
        }

    }
}
