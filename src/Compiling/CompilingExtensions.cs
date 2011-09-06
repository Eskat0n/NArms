using NArms.Compiling.Services;

namespace NArms.Compiling
{
    public static class CompilingExtensions
    {
        public static void Exec(this string code)
        {
            new DefaultCompilingService().Compile(code).Execute();
        }

        public static object Eval(this string code)
        {
            return new DefaultCompilingService().Compile(code).Evaluate();
        }
    }    
}