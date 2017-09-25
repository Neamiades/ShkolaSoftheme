using System.Collections.Generic;

namespace ConsoleIterator
{
    class ConcreteAggregate<T> : Aggregate<T>
    {
        private readonly List<T> _items = new List<T>();

        public override Iterator<T> CreateIterator() => new ConcreteIterator<T>(this);

        public int Count => _items.Count;

        public T this[int index]
        {
            get => _items[index];
            set => _items.Insert(index, value);
        }
    }
}
