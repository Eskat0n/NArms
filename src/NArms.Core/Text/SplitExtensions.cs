namespace NArms.Text
{
    using System;

    public static class SplitExtensions
    {
        public static string[] Split(this string @string, params string[] separator)
        {
            return @string.Split(separator, StringSplitOptions.None);
        }

        public static string[] Split(this string @string, params char[] separator)
        {
            return @string.Split(separator);
        }

        public static string[] Split(this string @string, StringSplitOptions options, params string[] separator)
        {
            return @string.Split(separator, options);
        }

        public static string[] Split(this string @string, StringSplitOptions options, params char[] separator)
        {
            return @string.Split(separator, options);
        }

        public static string[] Split(this string @string, int count, StringSplitOptions options, params string[] separator)
        {
            return @string.Split(separator, count, options);
        }

        public static string[] Split(this string @string, int count, StringSplitOptions options, params char[] separator)
        {
            return @string.Split(separator, count, options);
        }
    }
}