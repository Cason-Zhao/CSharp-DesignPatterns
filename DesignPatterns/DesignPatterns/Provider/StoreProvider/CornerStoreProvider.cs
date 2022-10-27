using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class CornerStoreProvider : StoreProvider
    {
        private Dictionary<Product, int> Inventory;
        private Dictionary<Product, double> Markup;

        public CornerStoreProvider()
        {

        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override void AddProductToStock(Product operatedItem)
        {
            throw new NotImplementedException();
        }

        public override double GetMarkup()
        {
            throw new NotImplementedException();
        }

        public override double GetProductPrice()
        {
            throw new NotImplementedException();
        }

        public override int GetProductStockCount()
        {
            throw new NotImplementedException();
        }

        public override void RemoveProductFromStock(Product operatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
