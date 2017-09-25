namespace ConsoleIterator
{
    class ConcreteIterator<T> : Iterator<T>
    {
        private readonly ConcreteAggregate<T> _aggregate;
        private int _current;

        public ConcreteIterator(ConcreteAggregate<T> aggregate) => _aggregate = aggregate;

        public override T First() => _aggregate[0];

        public override T Next()
        {
            T ret = default(T);
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public override T CurrentItem() => _aggregate[_current];

        public override bool IsDone() => _current >= _aggregate.Count;
    }
}
