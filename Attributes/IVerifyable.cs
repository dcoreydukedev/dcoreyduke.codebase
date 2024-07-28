using System;

namespace DCoreyDuke.CodeBase.Attributes
{
    public interface IVerifyable
    {
        public bool IsVerified { get; }
        public DateTime AsOf { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Verified : Attribute, IVerifyable
    {
        public bool IsVerified { get { return true; } }
        public DateTime AsOf { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Unverified : Attribute, IVerifyable
    {
        public bool IsVerified { get { return false; } }
        public DateTime AsOf { get; set; }
    }
}
