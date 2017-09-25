using System;
using System.Collections.Generic;

namespace ConsoleCollections
{
    class MyDictionary<TKey, TValue>
    {
        private readonly List<KeyValuePair<TKey, TValue>> _list;

        public MyDictionary() => _list = new List<KeyValuePair<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (ContainsKey(key))
            {
                throw new ArgumentException();
            }
            _list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            int i;
            for (i = 0; i < _list.Count && !_list[i].Key.Equals(key); i++) { }
            if (i == _list.Count)
            {
                return false;
            }
            _list.RemoveAt(i);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int i;
            for (i = 0; i < _list.Count && !_list[i].Key.Equals(key); i++) { }
            if (i == _list.Count)
            {
                value = default(TValue);
                return false;
            }

            value = _list[i].Value;
            return true;
        }

        public bool ContainsKey<T>(T key)
        {
            foreach (var pair in _list)
            {
                if (Equals(pair.Key, key))
                {
                    return true;
                }
            }

            return false;
        }

}
}

