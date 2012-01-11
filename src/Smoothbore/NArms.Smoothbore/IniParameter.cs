namespace NArms.Smoothbore
{
    public class IniParameter : IniElement
    {
        public IniParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Value { get; set; }
    }
}