using System;
using System.Text;
using NArms.Compiling.Services.Runs;

namespace NArms.Compiling.Services
{
    internal class DefaultCompilingService : CompilingServiceBase
    {
        public override DynamicRun Compile(string code)
        {
            var results = CompileAssembly(CreateSource(code), "system.dll");

            return new DynamicRun(ExtractType(results));
        }

        public override PersistedDynamicRun Compile(string code, PersistedDynamicRun persistedDynamicRun)
        {
            var results = CompileAssembly(CreateSourceWithPersistence(code), "system.dll");

            var type = ExtractType(results);
            return persistedDynamicRun != null
                       ? new PersistedDynamicRun(type, persistedDynamicRun.Bag)
                       : new PersistedDynamicRun(type);
        }

        private static string CreateSource(string code)
        {
            var source = new StringBuilder("using System;");

            source.AppendFormat("static class {0} {{ public static void {1}() {{",
                                DynamicRun.ClassName, DynamicRun.ExecuteMethodName);
            source.AppendFormat("{0}; }} }}", code);

            source.Append(Environment.NewLine);

            source.AppendFormat("static class {0} {{ public static object {1}() {{",
                                DynamicRun.EvaluateClassName, DynamicRun.EvaluateMethodName);
            source.AppendFormat("{0}; }} }}", code);

            return source.ToString();
        }

        private static string CreateSourceWithPersistence(string code)
        {
            var source = new StringBuilder("using System;");

            source.AppendFormat("class {0} {{", DynamicRun.ClassName);
            source.Append("private readonly dynamic bag;");
            source.AppendFormat("public {0}(dynamic bag) {{ this.bag = bag; }}", DynamicRun.ClassName);
            source.AppendFormat("public void {0}() {{", DynamicRun.ExecuteMethodName);
            source.AppendFormat("{0}; }} }}", code);

            source.Append(Environment.NewLine);

            source.AppendFormat("class {0} {{", DynamicRun.EvaluateClassName);
            source.Append("private readonly dynamic bag;");
            source.AppendFormat("public {0}(dynamic bag) {{ this.bag = bag; }}", DynamicRun.EvaluateClassName);
            source.AppendFormat("public object {0}() {{", DynamicRun.EvaluateMethodName);
            source.AppendFormat("{0}; }} }}", code);

            return source.ToString();
        }
    }
}