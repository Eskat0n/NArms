using System;
using System.Reflection;

namespace NArms.Compiling.Services.Runs
{
    public class DynamicRun
    {
        internal const string ClassName = "DynamicExecute";
        internal const string ExecuteMethodName = "Execute";

        internal const string EvaluateClassName = "DynamicEvaluate";
        internal const string EvaluateMethodName = "Evaluate";

        private readonly Type _executeType;
        private readonly Type _evaluateType;

        internal DynamicRun(Type executeType)
        {
            _executeType = executeType;
            _evaluateType = executeType;
        }

        public virtual void Execute()
        {
            var method = _executeType.GetMethod(ExecuteMethodName, BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                throw new MissingMethodException(ClassName, ExecuteMethodName);

            method.Invoke(null, null);
        }

        public virtual object Evaluate()
        {
            var method = _evaluateType.GetMethod(EvaluateMethodName, BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                throw new MissingMethodException(EvaluateClassName, EvaluateMethodName);

            return method.Invoke(null, null);
        }
    }
}