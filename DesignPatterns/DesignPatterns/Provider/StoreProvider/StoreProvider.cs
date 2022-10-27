using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal abstract class StoreProvider: ProviderBase
    {
        public abstract void AddProductToStock(Product operatedItem);
        public abstract double GetMarkup();
        public abstract double GetProductPrice();
        public abstract int GetProductStockCount();
        public abstract void RemoveProductFromStock(Product operatedItem);
    }
}
