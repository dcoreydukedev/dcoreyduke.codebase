/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.ObjectModel;
using DCoreyDuke.CodeBase.DataStructures.LinkedListBased;
using DCoreyDuke.CodeBase.Algorithms.Sorting;

namespace DCoreyDuke.CodeBase.GameLogic.Inventory
{
    public class Inventory : Bag<InventoryItem>, IDisposable
    {
        public Inventory() : base()
        {
        }

        // The Key to sort by
        public InventorySortBy SortBy { get; set; }

        // The Direction to sort in
        public InventorySortOrder SortOrder { get; set; }

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
        // ~Inventory() { // Do not change this code. Put cleanup code in Dispose(bool disposing)
        // above. Dispose(false); }

        #endregion IDisposable Support
    }
}