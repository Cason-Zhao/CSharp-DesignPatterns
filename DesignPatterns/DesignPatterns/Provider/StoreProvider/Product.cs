using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class Product
    {
        public string Name { get; set; }
        private List<Product> _Products;
        public double WholeSaleCost { get; set; }

        public Product GetProduct()
        {
            return null;
        }

        public static List<Product> GetProducts()
        {
            var result = new List<Product>();
            return result;
        }

        public static void Initialize()
        {

        }

        public Product()
        {

        }

    }
}
