namespace NArms.Grenade
{
    public interface ILinkConfiguration<in TFacade>
    {
        IRegistration And<TBacking>()
            where TBacking : class, TFacade;
    }
}