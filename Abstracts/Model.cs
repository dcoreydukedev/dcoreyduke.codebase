/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Abstracts
{
    public abstract class Model : IModel
    {
        private readonly string _name;

        private readonly List<string> _validationErrors = [];

        private Model()
        {
            
        }

        protected Model(string name) : this()
        {
           _name = name;
        }

        public virtual string Name => _name;

        public virtual bool IsValid => Validate();

        public virtual List<string> ValidationErrors => _validationErrors;

        public virtual bool Validate()
        {
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Name must be provided");
            }
            return _validationErrors.Count > 0;
        }
    }

  

}
