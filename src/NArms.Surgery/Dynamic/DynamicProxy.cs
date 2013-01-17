namespace NArms.Surgery.Dynamic
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;

    public class DynamicProxy<TObject> : DynamicObject
    {
        private const BindingFlags InstanceBindingFlags =
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

        private readonly FieldInfo[] _instanceFields;
        private readonly PropertyInfo[] _instanceProperties;
        private readonly TObject _proxyTarget;
        private readonly Type _proxyType;

        internal DynamicProxy(TObject proxyTarget)
        {
            _proxyTarget = proxyTarget;
            _proxyType = proxyTarget.GetType();
            _instanceFields = _proxyType.GetFields(InstanceBindingFlags);
            _instanceProperties = _proxyType.GetProperties(InstanceBindingFlags);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var fieldInfo = _instanceFields.SingleOrDefault(x => x.Name == binder.Name);
            var propertyInfo = _instanceProperties.SingleOrDefault(x => x.Name == binder.Name);
            if (fieldInfo == null && propertyInfo == null)
            {
                result = null;
                return false;
            }

            result = fieldInfo != null
                         ? fieldInfo.GetValue(_proxyTarget)
                         : propertyInfo.GetValue(_proxyTarget, null);

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var fieldInfo = _instanceFields
                .SingleOrDefault(x => x.Name == binder.Name);
            var propertyInfo = _instanceProperties
                .SingleOrDefault(x => x.Name == binder.Name);

            if (fieldInfo == null && propertyInfo == null)
                return false;
            if (fieldInfo != null)
                fieldInfo.SetValue(_proxyTarget, value);
            else
                propertyInfo.SetValue(_proxyTarget, value, null);

            return true;
        }
    }
}