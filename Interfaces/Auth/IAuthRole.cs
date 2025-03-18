/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Interfaces.Auth
{
    /// <summary>
    /// Represents a Role iņ an Application or Domain
    /// </summary>
    public interface IAuthRole
    {
        string Name { get; }
        ICollection<AuthPermission> Permissions { get; }
    }
}
