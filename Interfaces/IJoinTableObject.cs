using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.Interfaces
{
    /// <summary>
    /// Defines a contract for join table objects in a database context. It serves as a marker interface for entities
    /// involved in join operations. Example: UserHasRole, RoleHasPermission, etc.
    /// </summary>
    public interface IJoinTableObject
    {
    }

    public interface IJoinTableObject<TEntity1, TEntity2> : IJoinTableObject
    {
    }
}
