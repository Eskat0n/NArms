namespace NArms.Howitzer.Rss.Extensions
{
    public static class StringExtensions
    {
        public static string Cdata(this string value)
        {
            return string.Format("<![CDATA[{0}]]>", value);
        }
    }
}