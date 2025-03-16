/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.Interfaces
{
    /// <summary>
    /// Defines an entity with an identifier and timestamps for creation and last update. 
    /// Entity classes that implement this interface are considered to be entities in the database context.
    /// Entity = Object that has an identity (ID) and a lifecycle. (A database table is an example of an entity.)
    /// </summary>
    public interface  IEntity
    {
        int Id{get;set;}
        DateTime? CreatedOn { get;set; }
        DateTime? UpdatedOn { get;set; }
    }

}
