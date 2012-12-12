namespace NArms.TrenchGun
{
    using System;

    public class Benchmark
    {
        private Benchmark(int passesCount, Action<PassInfo> action)
        {
            PassesCount = passesCount;
            Action = action;
        }

        public static Benchmark Create(int passesCount, Action action)
        {
            Action<PassInfo> step = info => action();
            return Create(passesCount, step);
        }

        public static Benchmark Create(int passesCount, Action<int> action)
        {
            Action<PassInfo> step = info => action(info.Index);
            return Create(passesCount, step);
        }

        public static Benchmark Create(int passesCount, Action<PassInfo> action)
        {
            return new Benchmark(passesCount, action);
        }

        public static Benchmark Create<TSuite>(TSuite suite)
            where TSuite : class, IBenchmarkSuite
        {
            throw new NotImplementedException();
        }

        public int PassesCount { get; private set; }

        public Action<PassInfo> Action { get; private set; }

        public BenchmarkResults LastResults { get; private set; }

        public BenchmarkResults Run()
        {
            var results = new BenchmarkResults();

            for (var i = 1; i <= PassesCount; i++)
            {
                var passInfo = new PassInfo(i);

                var startTime = DateTime.Now;
                Action(passInfo);
                var elapsed = startTime - DateTime.Now;

                results.AddPass(i, elapsed);
            }

            return LastResults = results;
        }
    }
}
