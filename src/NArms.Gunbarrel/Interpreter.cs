namespace NArms.Gunbarrel
{
    public static class Interpreter
    {
        public static Interpreter<T> CreateFor<T>(T languageMetadata)
            where T : LanguageMetadata
        {
            return new Interpreter<T>(languageMetadata);
        }
    }
}