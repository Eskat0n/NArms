namespace NArms.Surgery.Static
{
    public static class DissectionExtensions
    {
        public static TProxy Dissect<TProxy>(this object value)
            where TProxy : class
        {
            var proxyFactory = new StaticProxyFactory();
            return proxyFactory.CreateProxy<TProxy>(value);
        }
    }

    public class StaticProxyFactory
    {
        public TProxy CreateProxy<TProxy>(object value)
        {
            return (TProxy) new object();
        }
    }
}