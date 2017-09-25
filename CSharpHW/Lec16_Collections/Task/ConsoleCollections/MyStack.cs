using System;

namespace ConsoleCollections
{
    class MyStack<T>
    {
        private T[] _arr;
        private readonly int _defSize = 16;
        private int _used = 0;

        public int Count => _used;

        public MyStack() => _arr = new T[_defSize];

        public void Push(T item)
        {
            EnlargeIfFull();
            _arr[_used++] = item;
        }

        public T Pop()
        {
            if (_used == 0)
            {
                throw new InvalidOperationException();
            }
            return _arr[--_used];
        }

        public T Peek()
        {
            if(_used == 0)
            {
                throw new InvalidOperationException();
            }
            return _arr[_used - 1];
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
