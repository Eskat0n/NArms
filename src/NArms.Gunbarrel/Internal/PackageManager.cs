using System.Collections.Generic;
using NArms.Gunbarrel.Language;

namespace NArms.Gunbarrel.Internal
{
    public static class PackageManager
    {
        private static readonly ICollection<LanguagePackage> _packages = new List<LanguagePackage>();

        public static void RegisterPackage(LanguagePackage package)
        {
            _packages.Add(package);
        }

        public static IEnumerable<LanguagePackage> Packages
        {
            get { return _packages; }
        }
    }
}