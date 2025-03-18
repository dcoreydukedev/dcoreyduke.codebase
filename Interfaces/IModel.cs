/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.Interfaces
{
    /// <summary>
    /// Defines a model with a name, validity status, and a list of validation errors. 
    /// Provides properties to access these attributes.
    /// </summary>
    public interface IModel
    {
        string Name { get; }
        bool IsValid { get; }
        List<string> ValidationErrors { get; }
    }

    /// <summary>
    /// Represents a domain model interface that extends the IModel interface. 
    /// It serves as a marker for domain models.
    /// </summary>
    public interface IDomainModel : IModel
    {
        
    }

    /// <summary>
    /// IViewModel is an interface that extends the IModel interface, serving as a marker for view model implementations.
    /// </summary>
    public interface IViewModel : IModel
    {
       
    }

}
