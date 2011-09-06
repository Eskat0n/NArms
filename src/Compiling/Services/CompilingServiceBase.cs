using System;
using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.CSharp;
using NArms.Compiling.Exceptions;
using NArms.Compiling.Services.Runs;

namespace NArms.Compiling.Services
{
    public abstract class CompilingServiceBase : ICompilingService, IDisposable
    {
        private const string CouldNotLocateOneOfStubTypesErrorMessage = "Couldn't locate one of stub types in compiled assembly";
        private const string CouldNotLocateAssemblyErrorMessage = "Couldn't locate assembly after compilation.";

        private readonly CSharpCodeProvider _provider;

        protected CompilingServiceBase()
        {
            _provider = new CSharpCodeProvider();
        }

        #region ICompilingService Members

        public abstract DynamicRun Compile(string code);
        public abstract PersistedDynamicRun Compile(string code, PersistedDynamicRun persistedDynamicRun);

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _provider.Dispose();
        }

        #endregion

        protected static Type ExtractType(CompilerResults results)
        {
            ProcessResults(results);

            var executeType = results.CompiledAssembly.GetType(DynamicRun.ClassName);
            if (executeType == null)
                throw new CompilingException(CouldNotLocateOneOfStubTypesErrorMessage);

            return executeType;
        }

        private static void ProcessResults(CompilerResults results)
        {
            if (results.Errors.Count != 0)
                throw new CompilingErrorsException(results.Errors.OfType<CompilerError>().ToArray());
            if (results.CompiledAssembly == null)
                throw new CompilingException(CouldNotLocateAssemblyErrorMessage);
        }

        protected CompilerResults CompileAssembly(string source, params string[] assemblies)
        {
            var parameters = new CompilerParameters(assemblies)
                                 {
                                     GenerateExecutable = false,
                                     GenerateInMemory = true
                                 };

            return _provider.CompileAssemblyFromSource(parameters, source);
        }
    }
}