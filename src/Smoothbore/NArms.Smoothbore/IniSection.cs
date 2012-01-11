namespace NArms.Smoothbore
{
    using System.Collections.Generic;

    public class IniSection : IniElement
    {
        private readonly IList<IniParameter> _parameters = new List<IniParameter>();

        public IniSection(string name)
        {
            Name = name;
        }

        public IEnumerable<IniParameter> Parameters
        {
            get { return _parameters; }
        }

        public void AddParameter(IniParameter iniParameter)
        {
            _parameters.Add(iniParameter);
        }
    }
}