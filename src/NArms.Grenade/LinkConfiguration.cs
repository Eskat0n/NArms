namespace NArms.Grenade
{
    using System;

    public class LinkConfiguration : ILinkConfiguration
    {
        private readonly Registration _registration;

        internal LinkConfiguration(Registration registration)
        {
            _registration = registration;
        }

        public IRegistration And(Type backingType)
        {
            var facadeType = _registration.FacadeType;

            if (backingType == null)
                throw new ArgumentNullException("backingType");

            if (backingType.IsInterface == false || facadeType.IsAssignableFrom(backingType) == false)
                throw new ArgumentException(
                    string.Format("Type {0} is not an implementation of {1}", backingType.FullName, facadeType),
                    "backingType");

            _registration.BackingType = backingType;
            return _registration;
        }
    }
}