using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using NArms.Howitzer.NamingConventions;

namespace NArms.Howitzer
{
    public sealed class XmlMarkup : DynamicObject
    {
        private const string IndentIsNegativeErrorMessage = "Indent parameter does not allow negative values";

        private bool _nested;
        private readonly string _atomicIndent;
        private readonly Stack<string> _tagStack = new Stack<string>();

        public StringBuilder Target { get; private set; }
        public int Indent { get; private set; }
        public INamingConvention TagNamingConvention { get; private set; }
        public INamingConvention AttributeNamingConvention { get; private set; }

        public XmlMarkup(ref StringBuilder target, int indent = 2,
            INamingConvention tagNamingConvention = null,
            INamingConvention attributeNamingConvention = null)
        {
            Target = target;
            TagNamingConvention = tagNamingConvention ?? new PascalCaseNamingConvention();
            AttributeNamingConvention = attributeNamingConvention ?? new MixedCaseNamingConvention();

            if (indent < 0)
                throw new ArgumentException(IndentIsNegativeErrorMessage);
            Indent = indent;

            for (var i = 0; i < Indent; i++)
                _atomicIndent += ' ';
        }

        // ReSharper disable InconsistentNaming  
        // ReSharper disable UnusedMember.Global
        public void Declaration_(string version = "1.0", string encoding = "UTF-8", bool? standalone = null)
        // ReSharper restore UnusedMember.Global
        // ReSharper restore InconsistentNaming
        {
            var standaloneAttrubte = string.Empty;
            if (standalone.HasValue)
                standaloneAttrubte = string.Format(" standalone=\"{0}\"",
                                                   standalone == true
                                                       ? "yes"
                                                       : "no");

            Target.AppendFormat("<?xml version=\"{0}\" encoding=\"{1}\"{2}?>",
                    version, encoding, standaloneAttrubte);
        }

        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Global
        public void Cdata_(string value)
        // ReSharper restore UnusedMember.Global
        // ReSharper restore InconsistentNaming
        {
            Target.AppendFormat("<![CDATA[{0}]]>", value);
        }

        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Global
        public void Comment_(string value)
        // ReSharper restore UnusedMember.Global
        // ReSharper restore InconsistentNaming
        {
            Target.AppendFormat("{0}<!--{1}-->", GetIndent(), value);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            CloseLastTag();

            var tagName = TagNamingConvention.Apply(binder.Name);
            var value = args.Length > 0
                            ? args[0].ToString()
                            : string.Empty;

            var attributes = new StringBuilder();

            if (args.Length > 1)
            {
                var anonymousType = args[1].GetType();
                var properties = anonymousType.GetProperties();
                foreach (var propertyInfo in properties)
                    attributes.AppendFormat(" {0}=\"{1}\"", 
                        AttributeNamingConvention.Apply(propertyInfo.Name), 
                        propertyInfo.GetValue(args[1], null));
            }

            Target.AppendLine(string.Empty);
            Target.AppendFormat("{0}<{1}{2}>{3}", GetIndent(), tagName, attributes, value);

            _tagStack.Push(tagName);

            result = this;
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(IDisposable))
            {                
                result = new XmlMarkupNode(CloseLastTag);
                return _nested = true;
            }
            result = null;
            return false;
        }

        public override string ToString()
        {
            return Target.ToString();
        }

        private string GetIndent()
        {
            var sb = new StringBuilder();

            foreach (var tag in _tagStack)
                sb.Append(_atomicIndent);

            return sb.ToString();
        }

        private void CloseLastTag()
        {
            if (_nested)
                Target.AppendLine(string.Empty);
            Target.AppendFormat("{0}</{1}>", GetIndent(), _tagStack.Pop());
        }
    }
}