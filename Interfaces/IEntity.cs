/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.Interfaces
{
    public interface  IEntity
    {
        int Id{get;set;}
        DateTime? CreatedOn { get;set; }
        DateTime? UpdatedOn { get;set; }
    }

}
