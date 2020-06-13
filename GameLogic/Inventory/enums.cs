/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.GameLogic.Inventory
{
    #region Inventory Item Enums

    [Serializable]
    public enum InventoryItemOptions
    {
        Delete,
        View,
        Sell,
        Trade,
        Other
    }

    [Serializable]
    public enum InventoryItemQuality
    {
        Other,
        Default
    }

    [Serializable]
    public enum InventoryItemType
    {
        Other,
        Default
    }

    #endregion Inventory Item Enums

    #region Inventory Enums

    [Serializable]
    public enum InventorySortBy
    {
        SortByName,
        SortByCategory,
        SortByType,
        SortByNone,
        SortByDefault
    }

    [Serializable]
    public enum InventorySortOrder
    {
        Descending,
        Ascending,
        Custom,
        Other,
        None
    }

    #endregion Inventory Enums
}