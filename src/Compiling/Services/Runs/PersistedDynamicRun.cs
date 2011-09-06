using System;

namespace NArms.Compiling.Services.Runs
{
    public class PersistedDynamicRun : DynamicRun
    {
        private readonly dynamic _bag;

        internal dynamic Bag { get { return _bag; } }

        internal PersistedDynamicRun(Type runType, dynamic bag)
            : base(runType)
        {
            _bag = bag;
        }

        internal PersistedDynamicRun(Type runType)
            : base(runType)
        {
            throw new NotImplementedException();
        }
    }
}
