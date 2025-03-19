using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.Interfaces
{
    /// <summary>
    /// Defines a contract for mapping between different object types. 
    /// Implementations will provide specific mapping logic.
    /// </summary>
    public interface IMapper
    {
    }

    /// <summary>
    /// Defines a mapping interface for converting between two types.
    /// </summary>
    /// <typeparam name="TSource">Represents the source type from which data will be mapped.</typeparam>
    /// <typeparam name="TDestination">Represents the destination type to which data will be mapped.</typeparam>
    public interface IMapper<TSource, TDestination> : IMapper
    {
        public static TDestination? Map()
        {
            return default;
        }

        public static TSource Unmapped { get; }
        public static TDestination Mapped { get; }
    }   
}
