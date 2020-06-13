/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DCoreyDuke.CodeBase.Objects.General;

namespace DCoreyDuke.CodeBase.GameLogic.Inventory
{
    public interface IInventoryItem
    {
        // Use Timestamp so that comparisons for sorting can be made based on parts of timestamp
        Timestamp AddedOn { get; set; }

        string ItemDescription { get; set; }

        File ItemImage { get; set; }

        string ItemName { get; set; }

        List<InventoryItemOptions> ItemOptions { get; set; }

        InventoryItemQuality ItemQuality { get; set; }

        InventoryItemType ItemType { get; set; }
    }

    public class InventoryItem : IInventoryItem, IEquatable<InventoryItem>, IDisposable
    {
        public Timestamp AddedOn { get; set; }

        public string ItemDescription { get; set; }

        public File ItemImage { get; set; }

        public string ItemName { get; set; }

        public List<InventoryItemOptions> ItemOptions { get; set; }

        public InventoryItemQuality ItemQuality { get; set; }

        public InventoryItemType ItemType { get; set; }

        public bool Equals(InventoryItem other)
        {
            if (other == null) return false;
            return other.ItemDescription == this.ItemDescription &&
               other.ItemName == this.ItemName &&
               other.ItemType == this.ItemType;
        }

        #region IDisposable Support

        private bool _DisposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above. GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _DisposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InventoryItem() { // Do not change this code. Put cleanup code in Dispose(bool
        // disposing) above. Dispose(false); }

        #endregion IDisposable Support
    }
}