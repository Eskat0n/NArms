namespace NArms.Grenade
{
    using System;

    public interface ILinkConfiguration
    {
        IRegistration And(Type backingType);
    }
}