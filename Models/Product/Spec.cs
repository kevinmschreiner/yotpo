using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Product
{
    public class Spec
    {
        /// <summary>
        /// The product UPC code
        /// </summary>
        public string upc { get; set; }
        /// <summary>
        /// Manufacturer Part Number (MPN)
        /// </summary>
        public string mpn { get; set; }
        /// <summary>
        /// The brand of the product
        /// </summary>
        public string brand { get; set; }
        /// <summary>
        /// The products ISBN code
        /// </summary>
        public string isbn { get; set; }
        /// <summary>
        /// European Article Number
        /// </summary>
        public string ean { get; set; }
        /// <summary>
        /// Stock-Keeping Unit. Cannot contain spaces.
        /// </summary>
        public string external_sku { get; set; }
    }
}
