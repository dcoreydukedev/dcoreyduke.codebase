/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

namespace DCoreyDuke.CodeBase.Interfaces
{
    /// <summary>
    /// Defines a contract for join table objects in a database context. It serves as a marker interface for entities
    /// involved in join operations. Example: UserHasRole, RoleHasPermission, etc.
    /// </summary>
    public interface IJoinTableObject
    {
    }

    /// <summary>
    /// Defines a join table object interface for two types, facilitating operations between them.
    /// </summary>
    /// <typeparam name="TTableObject1">Represents the first type involved in the join operation.</typeparam>
    /// <typeparam name="TTableObject2">Represents the second type involved in the join operation.</typeparam>
    public interface IJoinTableObject<TTableObject1, TTableObject2> : IJoinTableObject
    {
    }
}
