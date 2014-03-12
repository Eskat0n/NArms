namespace NArms.Config.Extensions
{
    using System.Collections.Specialized;
    using System.Linq;

    public static class NameValueCollectionExtensions
    {
        public static bool ContainsKey(this NameValueCollection nameValueCollection, string key)
        {
            return nameValueCollection.AllKeys.Any(x => x == key);
        }
    }
}