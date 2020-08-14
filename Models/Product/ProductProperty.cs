using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Product
{
    public class ProductProperty
    {
        /// <summary>
        /// The color of the product
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// The size of the product
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// The product vendor
        /// </summary>
        public string vendor { get; set; }

        /// <summary>
        /// The material the product is made of
        /// </summary>
        public string material { get; set; }
        /// <summary>
        /// The model of the product
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// Specifies whether a coupon was applied to this product purchase
        /// </summary>
        public bool coupon_used { get; set; }

    }
}
