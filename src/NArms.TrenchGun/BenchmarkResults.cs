namespace NArms.TrenchGun
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BenchmarkResults
    {
        private readonly IDictionary<int, TimeSpan> _passes = new Dictionary<int, TimeSpan>();

        public BenchmarkResults()
        {
            _passes = new Dictionary<int, TimeSpan>();
        }

        public IEnumerable<TimeSpan> Passes
        {
            get { return _passes.Values; }
        }

        public TimeSpan TotalTime
        {
            get
            {
                return _passes.Aggregate(new TimeSpan(),
                                         (total, pair) => total + pair.Value);
            }
        }

        public TimeSpan AverageTime
        {
            get { return new TimeSpan(TotalTime.Ticks / PassesCount); }
        }

        public int PassesCount
        {
            get { return _passes.Count; }
        }

        internal void AddPass(int index, TimeSpan elapsed)
        {
            _passes.Add(index, elapsed);
        }
    }
}