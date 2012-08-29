namespace NArms.Collections
{
    using System.Collections.Generic;

    public class CompositeKeyDictionary<TKey1, TKey2, TValue> : Dictionary<CompositeKey<TKey1, TKey2>, TValue>
    {
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return this[new CompositeKey<TKey1, TKey2>(key1, key2)]; }
            set { this[new CompositeKey<TKey1, TKey2>(key1, key2)] = value; }
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            Add(new CompositeKey<TKey1, TKey2>(key1, key2), value);
        }
    }
}