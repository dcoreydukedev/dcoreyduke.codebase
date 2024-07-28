using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.Attributes
{



    public interface IConfirmed
    {
        public bool IsConfirmed { get; }
        public DateTime AsOf { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Confirmed : Attribute, IConfirmed
    {
        public DateTime AsOf { get; set; }
        public bool IsConfirmed { get { return true; } }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Unconfirmed : Attribute, IConfirmed
    {
        public DateTime AsOf { get; set; }
        public bool IsConfirmed { get { return false; } }
    }
}
