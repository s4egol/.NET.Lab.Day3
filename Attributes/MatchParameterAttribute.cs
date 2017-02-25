using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Attributes
{
    // Should be applied to .ctors.
    // Matches a .ctor parameter with property. Needs to get a default value from property field, and use this value for calling .ctor.
    [AttributeUsage(AttributeTargets.Constructor)]
    public class MatchParameterWithPropertyAttribute : Attribute
    {
        public string ParameterName { get; private set; }

        public string PropertyName { get; private set; }

        public MatchParameterWithPropertyAttribute(string parameterName, string propertyName)
        {
            ParameterName = parameterName;
            PropertyName = propertyName;
        }

        public T Match<T>()
            where T : class 
        {
            TypeInfo metaData = typeof (T).GetTypeInfo();

            PropertyInfo prop = metaData.GetDeclaredProperty(PropertyName);
            var defaulValueAttribute =
                prop.GetCustomAttributes(typeof (DefaultValueAttribute))
                    as DefaultValueAttribute;

            ConstructorInfo constructor
                = metaData.GetConstructor(new Type[] {typeof (int)});

            T instance =
                constructor.Invoke(new [] {defaulValueAttribute.Value})
                    as T;

            return instance;
        }
    }
}
