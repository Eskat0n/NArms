using System;

namespace NArms.Collections
{
    public static class CompositeKey
    {
        public static CompositeKey<TItem1, TItem2> Create<TItem1, TItem2>(TItem1 key1, TItem2 key2)
        {
            return new CompositeKey<TItem1, TItem2>(key1, key2);
        }

        public static CompositeKey<TItem1, TItem2, TItem3> Create<TItem1, TItem2, TItem3>(TItem1 key1, TItem2 key2, TItem3 key3)
        {
            return new CompositeKey<TItem1, TItem2, TItem3>(key1, key2, key3);
        }
    }

    public class CompositeKey<TItem1, TItem2> : Tuple<TItem1, TItem2>
    {
        public CompositeKey(TItem1 key1, TItem2 key2)
            : base(key1, key2)
        {
        }

        public bool Equals(CompositeKey<TItem1, TItem2> other)
        {
            return Item1.Equals(other.Item1) && 
                Item2.Equals(other.Item2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CompositeKey<TItem1, TItem2>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class CompositeKey<TItem1, TItem2, TItem3> : Tuple<TItem1, TItem2, TItem3>
    {
        public CompositeKey(TItem1 key1, TItem2 key2, TItem3 key3)
            : base(key1, key2, key3)
        {
        }

        public bool Equals(CompositeKey<TItem1, TItem2, TItem3> other)
        {
            return Item1.Equals(other.Item1) && 
                Item2.Equals(other.Item2) &&
                Item3.Equals(other.Item3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CompositeKey<TItem1, TItem2, TItem3>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}