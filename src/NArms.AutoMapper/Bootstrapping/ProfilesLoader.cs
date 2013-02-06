namespace NArms.AutoMapper.Bootstrapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using global::AutoMapper;

    public static class ProfileLoader
    {
        public static ProfileCollection FromAssembly(Assembly assembly)
        {
            var profileTypes = assembly.GetTypes()
                .Where(x => typeof (Profile).IsAssignableFrom(x))
                .ToArray();

            return new ProfileCollection(profileTypes);
        }

        public static ProfileCollection FromAssemblyContaining(Type type)
        {
            return FromAssembly(type.Assembly);
        }

        public static ProfileCollection FromAssemblyContaining<T>()
        {
            return FromAssemblyContaining(typeof (T));
        }
    }
}