using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Product;

namespace Yotpo.Light.Models.Review
{
    public class ProductList
    {
        public List<Int64> Location_idx { get; set; }
        public Product Product { get; set; }
    }
}
