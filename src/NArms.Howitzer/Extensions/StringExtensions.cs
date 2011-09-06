namespace NArms.Howitzer.Extensions
{
    public static class StringExtensions
    {
        public static string Escape(this string str)
        {
            return str
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("'", "&apos;")
                .Replace("\"", "&quot;");
        }
    }
}