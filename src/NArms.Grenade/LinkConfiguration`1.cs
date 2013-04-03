namespace NArms.Grenade
{
    internal class LinkConfiguration<TFacade> : ILinkConfiguration<TFacade>
    {
        private readonly Registration _registration;

        internal LinkConfiguration(Registration registration)
        {
            _registration = registration;
        }

        public IRegistration And<TBacking>()
            where TBacking : class, TFacade
        {
            _registration.BackingType = typeof (TBacking);
            return _registration;
        }
    }
}