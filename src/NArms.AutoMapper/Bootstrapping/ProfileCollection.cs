namespace NArms.AutoMapper.Bootstrapping
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using global::AutoMapper;

    public class ProfileCollection : IEnumerable<Type>
    {
        private readonly IEnumerable<Type> _profileTypes;

        internal ProfileCollection(IEnumerable<Type> profileTypes)
        {
            _profileTypes = profileTypes;
        }

        public void Load(Func<Type, bool> predicate)
        {
            LoadUsing(x => Activator.CreateInstance(x), predicate);
        }

        public void LoadMarked<TAttribute>()
            where TAttribute : Attribute
        {
            var attributeType = typeof (TAttribute);
            Load(x => x.GetCustomAttributes(attributeType, true).Length != 0);
        }

        public void LoadAll()
        {
            Load(x => true);
        }
        
        public void LoadUsing(Func<Type, object> factory)
        {
            LoadUsing(factory, x => true);
        }
        
        public void LoadUsing(Func<Type, object> factory, Func<Type, bool> predicate)
        {
            LoadUsing(x => factory(x) as Profile, predicate);
        }
        
        public void LoadUsing(Func<Type, Profile> factory)
        {
            LoadUsing(factory, x => true);
        }

        public void LoadUsing(Func<Type, Profile> factory, Func<Type, bool> predicate)
        {
            var profiles = _profileTypes
                .Where(predicate)
                .Select(factory)
                .Where(x => x != null);

            foreach (var profile in profiles)
                Mapper.AddProfile(profile);
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return _profileTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}