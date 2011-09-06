using System;

namespace NArms.Howitzer.NamingConventions.Utils
{
    public static class StringExtensions
    {
        public static bool IsUpper(this string str)
        {
            return str.ToUpperInvariant().Equals(str, StringComparison.InvariantCulture);
        }

        public static bool IsLower(this string str)
        {
            return str.ToLowerInvariant().Equals(str, StringComparison.InvariantCulture);
        }

        public static string Capitalize(this string str)
        {
            if (str.Length == 1)
                return str.ToUpperInvariant();
            return str[0].ToString().ToUpperInvariant() + str.Remove(0, 1).ToLowerInvariant();
        }
    }
}