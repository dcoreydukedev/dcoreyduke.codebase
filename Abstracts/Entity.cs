/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;

namespace DCoreyDuke.CodeBase.Abstracts
{
    public abstract class Entity : IEntity
    {
       
        protected Entity()
        {
           
        }

        public abstract int Id { get; set; }
        public abstract DateTime? CreatedOn { get; set; }
        public abstract DateTime? UpdatedOn { get; set; }
    }
}
