/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Interfaces.Auth
{
    /// <summary>
    /// Defines a user with properties for Username, Email, and Password. Also includes a collection of associated
    /// Roles.
    /// </summary>
    public interface IAuthUser
    {
        string Username { get; }
        string Email { get; }
        string Password { get; }
        ICollection<AuthRole> Roles { get; }
    }
}
