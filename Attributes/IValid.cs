using System;

namespace DCoreyDuke.CodeBase.Attributes
{
    public interface IValid
    {
        public bool IsValid { get; }
        public DateTime AsOf { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Valid : Attribute, IValid
    {
        public bool IsValid { get { return true; } }
        public DateTime AsOf { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Invalid : Attribute, IValid
    {
        public bool IsValid { get { return false; } }
        public DateTime AsOf { get; set; }
    }

}
