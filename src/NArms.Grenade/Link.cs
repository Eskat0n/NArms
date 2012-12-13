namespace NArms.Grenade
{
    using System;

    public static class Link
    {
        public static ILinkConfiguration<TFacade> Between<TFacade>()
        {
            var registration = new Registration {FacadeType = typeof (TFacade)};

            return new LinkConfiguration<TFacade>(registration);
        }

        public static ILinkConfiguration Between(Type facadeType)
        {
            if (facadeType == null)
                throw new ArgumentNullException("facadeType");

            var registration = new Registration {FacadeType = facadeType};

            return new LinkConfiguration(registration);
        }
    }
}