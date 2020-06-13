/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.KeyGenerators
{
    /// <summary>
    /// Classes implementing this interface will generate various unique key entities
    /// </summary>
    /// <typeparam name="T">Type of Key Generated</typeparam>
    public interface IKeyGenerator<T>
    {
        T Generate();
    }
}