using System.Collections.Generic;
using System.Dynamic;

namespace NArms.Dynamics
{
    public class Pouch : DynamicObject
    {
        private readonly IDictionary<string, object> _properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name) == false)
            {
                result = null;
                return true;
            }

            result = _properties[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties[binder.Name] = value;

            return true;
        }

        public IDictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>(_properties);
        }
    }
}