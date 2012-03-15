namespace NArms.Numbers
{
    using System;
    using System.Collections.Generic;

    public static class TimesExtensions
    {
        public static int Times(this int times, Action action)
        {
            var i = 0;
            try
            {
                for (i = 0; i < times; i++)
                    action();
            }
            catch (BreakException)
            {
                return i;
            }

            return i;            
        }

        public static int Times(this int times, Action<int> action)
        {
            var i = 0;
            try
            {
                for (i = 0; i < times; i++)
                    action(i);
            }
            catch (BreakException)
            {
                return i;
            }

            return i;
        }

        public static IEnumerable<TOut> Times<TOut>(this int times, Func<TOut> func)
        {
            var result = new List<TOut>();
            try
            {
                for (var i = 0; i < times; i++)
                    result.Add(func());
            }
            catch (BreakException)
            {
                return result;
            }

            return result;
        }

        public static IEnumerable<TOut> Times<TOut>(this int times, Func<int, TOut> func)
        {
            var result = new List<TOut>();
            try
            {
                for (var i = 0; i < times; i++)
                    result.Add(func(i));
            }
            catch (BreakException)
            {
                return result;
            }

            return result;
        }

        public static IEnumerable<TOut> Times<TOut>(this int times, Func<TOut> func, out int resultingTimes)
        {
            var result = new List<TOut>();
            var i = 0;
            try
            {
                for (i = 0; i < times; i++)
                    result.Add(func());
            }
            catch (BreakException)
            {
                resultingTimes = i;
                return result;
            }

            resultingTimes = i;
            return result;
        }
        
        public static IEnumerable<TOut> Times<TOut>(this int times, Func<int, TOut> func, out int resultingTimes)
        {
            var result = new List<TOut>();
            var i = 0;
            try
            {
                for (i = 0; i < times; i++)
                    result.Add(func(i));
            }
            catch (BreakException)
            {
                resultingTimes = i;
                return result;
            }

            resultingTimes = i;
            return result;
        }
    }
}