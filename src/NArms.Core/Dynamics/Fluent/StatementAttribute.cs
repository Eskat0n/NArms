using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NArms.Dynamics.Fluent
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class StatementAttribute : Attribute
    {
        private readonly string _pattern;

        public StatementAttribute(string pattern)
        {
            _pattern = pattern;
        }

        public bool IsMatch(string statement)
        {
            return Regex.IsMatch(statement, _pattern);
        }

        public string[] ExtractParameters(string statement)
        {
            if (IsMatch(statement) == false)
                return new string[] {};

            var match = Regex.Match(statement, _pattern);

            return match.Groups.OfType<Group>()
                .Skip(1)
                .Select(x => x.Value)
                .ToArray();
        }
    }
}