using System;

namespace Attributes
{
    // Should be applied to properties and fields.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntValidatorAttribute : Attribute
    {
        public int MinValue { get; private set; }

        public int MaxValue { get; private set; }

        public IntValidatorAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
