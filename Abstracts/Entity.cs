/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Abstracts
{
    public abstract class Entity : IEntity
    {
        private int _id;

        private List<string> _validationErrors = new List<string>();

        private Entity()
        {
            
        }

        protected Entity(int id) : this()
        {
            _id = id;
        }

        public virtual int Id => _id;

        public virtual bool IsValid => Validate();

        public virtual List<string> ValidationErrors => _validationErrors;

        public virtual bool Validate()
        {
            if (_id <= 0)
            {
                _validationErrors.Add("Id must be greater than 0");
            }
            return _validationErrors.Count > 0;
        }
    }
  
}
