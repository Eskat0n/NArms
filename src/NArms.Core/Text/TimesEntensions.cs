namespace NArms.Text
{
    using System.Text;

    public static class TimesEntensions
    {
        public static string Times(this int times, string value)
        {
            if (times == 0)
                return string.Empty;
            if (times == 1)
                return value;

            var sb = new StringBuilder();

            for (var i = 0; i < times; i++)
                sb.Append(value);

            return sb.ToString();
        }
    }
}