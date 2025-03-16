/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;

namespace DCoreyDuke.CodeBase.Abstracts
{
    public abstract class Entity : IEntity
    {
        private readonly int _id;
        private readonly DateTime _created;
        private readonly DateTime _modified;
        protected Entity()
        {
           
        }
        public virtual int Id => _id;
        public virtual DateTime Created => _created;
        public virtual DateTime Modified => _modified;
      
    }
}
