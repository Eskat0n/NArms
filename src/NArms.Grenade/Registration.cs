namespace NArms.Grenade
{
    using System;

    internal class Registration : IRegistration
    {
        public Type FacadeType { get; internal set; }
        public Type BackingType { get; internal set; }
    }
}