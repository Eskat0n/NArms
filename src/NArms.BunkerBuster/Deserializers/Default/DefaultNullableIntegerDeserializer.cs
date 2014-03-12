namespace NArms.Config.Deserializers.Default
{
    using System;
    using System.ComponentModel;

    internal class DefaultNullableIntegerDeserializer : IDeserializer
    {
        private readonly TypeConverter _typeConverter = new Int64Converter();
        private readonly Type _resultType;

        public DefaultNullableIntegerDeserializer(Type resultType)
        {
            _resultType = resultType;
        }

        public object Deserialize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            long result;
            long.TryParse(value, out result);
          
            return _typeConverter.ConvertTo(result, _resultType);
        }
    }
}