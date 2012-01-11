namespace NArms.Smoothbore
{
    using System.Collections.Generic;

    public class IniSection : IniElement
    {
        private readonly IList<IniParameter> _parameters = new List<IniParameter>();

        public IEnumerable<IniParameter> Parameters
        {
            get { return _parameters; }
        }
    }
}