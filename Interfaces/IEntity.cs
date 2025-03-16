﻿/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.Interfaces
{
    public interface  IEntity
    {
        int Id{get;}
        DateTime Created { get; }
        DateTime Modified { get; }
    }

}
