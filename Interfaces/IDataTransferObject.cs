/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

namespace DCoreyDuke.CodeBase.Interfaces
{
    public interface IDataTransferObject : IJsonSerializable
    {
        
    }

    public interface IDataTransferObject<TEntity> : IDataTransferObject
    {
       
    }

}

