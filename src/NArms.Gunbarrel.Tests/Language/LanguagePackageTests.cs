using NArms.Gunbarrel.Language;

namespace NArms.Gunbarrel.Tests.Language
{
    public class LanguagePackageTests
    {
        private class CustomLanguagePackage : LanguagePackage
        {
            public CustomLanguagePackage()
            {
                Function("SUMMARIZE")
                    .Arguments(2);
            }
        }
    }
}