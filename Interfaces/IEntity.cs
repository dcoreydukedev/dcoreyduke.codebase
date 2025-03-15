/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.Interfaces
{
    public interface IEntity
    {
        int Id { get; }
        bool IsValid { get; }
        List<string> ValidationErrors { get; }
        bool Validate();
    }

   
}
