using System.Collections;

namespace ConsoleLinkedListApp
{
    class MyLinkedList<T> : IEnumerable
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == 0)
            {
                _last = _head = new Node<T>();
                _head.Data = item;
            }
            else
            {
                Node<T> node = new Node<T>(item);
                _last.Next = node;
                node.Prev = _last;
                _last = node;
            }
            Count++;
        }

        public void Remove(T item)
        {
            Node<T> node;
            for (node = _head; node != null && !node.Data.Equals(item); node = node.Next) { }
            if (node == null)
            {
                return;
            }
            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            if (node == _last)
            {
                _last = node.Prev;
            }
            if (node == _head)
            {
                _head = node.Next;
            }
            Count--;
        }

        public bool Contains(T item)
        {
            Node<T> node;

            for (node = _head; node != null && !node.Data.Equals(item); node = node.Next) { }

            return node != null;
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            Node<T> node = _head;

            for (int i = 0; i < Count; i++, node = node.Next)
            {
                arr[i] = node.Data;
            }

            return arr;
        }

        public IEnumerator GetEnumerator()
        {
            for (var node = _head; node != null; node = node.Next)
            {
                yield return node.Data;
            }
        }
    }
}
