namespace NArms.Windsor.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InstallerOrderAttribute : Attribute
    {
        public int Order { get; private set; }

        public InstallerOrderAttribute(int order)
        {
            Order = order;
        }
    }
}