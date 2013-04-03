namespace NArms.Windsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Annotations;
    using Castle.Windsor.Installer;

    internal class OrderedInstallerFactory : InstallerFactory
    {
        private const int DefaultPriority = 0;

        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            return base.Select(installerTypes)
                .OrderBy(GetPriority);
        }

        private static int GetPriority(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(InstallerOrderAttribute), false)
                .Cast<InstallerOrderAttribute>()
                .SingleOrDefault();

            return attribute != null
                       ? attribute.Order
                       : DefaultPriority;
        }
    }
}