namespace NArms.Surgery.Dynamic
{
    public static class DissectionExtensions
    {
        public static dynamic Dissect<TValue>(this TValue value)
            where TValue : class
        {
            return new DynamicProxy<TValue>(value);
        }
    }
}