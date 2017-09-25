using System;

namespace ConsoleCollections
{
    class MyQueue<T>
    {
        private T[] _arr;
        private readonly int _defSize = 16;
        private int _used = 0;

        public MyQueue() => _arr = new T[_defSize];

        public int Count => _used;

        public void Enqueue(T item)
        {
            EnlargeIfFull();
            _arr[_used++] = item;
        }

        public T Dequeue()
        {
            if (_used == 0)
            {
                throw new InvalidOperationException();
            }
            var res = _arr[0];
            Array.Copy(_arr, 1, _arr, 0, _used - 1);
            _used--;
            return res;
        }

        public T Peek()
        {
            if (_used == 0)
            {
                throw new InvalidOperationException();
            }
            return _arr[0];
        }

        private void EnlargeIfFull()
        {
            if (_used == _arr.Length)
            {
                var bigger = _used + _defSize;

                var biggerArray = new T[bigger];
                _arr.CopyTo(biggerArray, 0);

                _arr = biggerArray;
            }
        }
    }
}
