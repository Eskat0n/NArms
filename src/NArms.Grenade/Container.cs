﻿namespace NArms.Grenade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Container : IContainer
    {
        private readonly ICollection<IRegistration> _registrations
            = new List<IRegistration>();

        public void Reset()
        {
            _registrations.Clear();
        }

        public void Register(IRegistration registration)
        {
            _registrations.Add(registration);
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        public object Resolve(Type type)
        {
            var registration = _registrations
                .SingleOrDefault(x => x.FacadeType == type);

            if (registration == null)
                throw new ArgumentException(string.Format("Could not find backing type for {0}", type.FullName), "type");

            return FactoryCreate(registration.BackingType);
        }

        private object FactoryCreate(Type backingType)
        {
            var parameters = ResolveConstructorParameters(backingType);
            var backingTypeInstance = Activator.CreateInstance(backingType, parameters);

            ResolvePublicProperties(backingType, backingTypeInstance);

            return backingTypeInstance;
        }

        private void ResolvePublicProperties(Type backingType, object backingTypeInstance)
        {
            var publicSettableProperties = backingType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetSetMethod() != null)
                .Where(x => IsResolvingPossible(x.PropertyType));

            foreach (var property in publicSettableProperties)
                property.SetValue(backingTypeInstance, Resolve(property.PropertyType), null);
        }

        private object[] ResolveConstructorParameters(Type backingType)
        {
            var parameterTypes = backingType.GetConstructors()
                .Select(x => x.GetParameters().Select(z => z.ParameterType).ToArray())
                .FirstOrDefault(x => x.All(IsResolvingPossible));

            if (parameterTypes == null)
                throw new NotImplementedException();

            var parameters = parameterTypes
                .Select(Resolve)
                .ToArray();
            return parameters;
        }

        private bool IsResolvingPossible(Type type)
        {
            return _registrations.Any(z => z.FacadeType == type);
        }
    }
}
