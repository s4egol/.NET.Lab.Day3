using System;

namespace Attributes
{
    // Should be applied to properties and fields.
    public class StringValidatorAttribute : Attribute
    {
        public int Length { get; private set; }

        public StringValidatorAttribute(int length)
        {
            Length = length;
        }
    }
}
