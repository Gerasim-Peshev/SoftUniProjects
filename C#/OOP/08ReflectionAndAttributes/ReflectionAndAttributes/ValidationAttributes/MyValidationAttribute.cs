using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
