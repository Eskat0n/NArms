using System;
using NArms.Appflow.ArgumentDriven.Configurations;

namespace NArms.Appflow.ArgumentDriven.Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FlagArgumentAttribute : ArgumentAnnotationAttribute
    {
        private readonly string _name;

        public FlagArgumentAttribute(string name)
        {
            _name = name;
        }

        public override ArgumentConfiguration CreateConfiguration()
        {
            return new FlagArgumentConfiguration(_name);
        }
    }
}