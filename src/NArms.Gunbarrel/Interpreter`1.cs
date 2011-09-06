namespace NArms.Gunbarrel
{
    public class Interpreter<T> where T : LanguageMetadata
    {
        private readonly T _languageMetadata;

        public Interpreter(T languageMetadata)
        {
            _languageMetadata = languageMetadata;
        }

        public void Interpret(string script)
        {
            
        }

        public T LanguageMetadata
        {
            get { return _languageMetadata; }
        }
    }
}