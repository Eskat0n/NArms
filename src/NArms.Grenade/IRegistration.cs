namespace NArms.Grenade
{
    using System;

    public interface IRegistration
    {
        Type FacadeType { get; }
        Type BackingType { get; }
    }
}