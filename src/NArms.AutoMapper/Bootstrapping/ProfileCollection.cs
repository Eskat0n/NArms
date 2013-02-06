namespace NArms.AutoMapper.Bootstrapping
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ProfileCollection : IEnumerable<Type>
    {
        private readonly IEnumerable<Type> _types;

        internal ProfileCollection(IEnumerable<Type> types)
        {
            _types = types;
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return _types.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}