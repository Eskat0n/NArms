using NArms.Compiling.Services.Runs;

namespace NArms.Compiling.Services
{
    public interface ICompilingService
    {
        DynamicRun Compile(string code);
        PersistedDynamicRun Compile(string code, PersistedDynamicRun persistedDynamicRun);
    }
}