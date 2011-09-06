using System;

namespace NArms.Appflow.StepByStep
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class StepAttribute : Attribute
    {
        public StepAttribute()
        {
        }
    }
}