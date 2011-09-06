using System;
using NArms.Appflow.ArgumentDriven.Configurations;

namespace NArms.Appflow.ArgumentDriven.Annotations
{
    public abstract class ArgumentAnnotationAttribute : Attribute
    {
        public abstract ArgumentConfiguration CreateConfiguration();
    }
}