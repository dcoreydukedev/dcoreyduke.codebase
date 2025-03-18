/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System.Collections;

namespace DCoreyDuke.CodeBase.Interfaces.Auth
{
    /// <summary>
    /// Represents a Permission iņ an Application or Domain
    /// </summary>
    public interface IAuthPermission
    {
        string Name { get; }
    }

   
}
