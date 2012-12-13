namespace NArms.Grenade
{
    using System;

    public interface IContainer
    {
        void Reset();
        void Register(IRegistration registration);
        T Resolve<T>();
        object Resolve(Type type);
    }
}