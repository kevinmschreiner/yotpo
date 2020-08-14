using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Product
{
    public class Product : ProductProperty
    {
        /// <summary>
        /// products.product_id.description
        /// </summary>
        public string product_id { get; set; }
        public List<Shared.CustomProperty> custom_properties {get;set;}

        /// <summary>
        /// The URL of the product on your store website
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The product image URL
        /// </summary>
        public string image { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        public string price { get; set; }

        public Spec specs { get; set; }

        /// <summary>
        /// The tag you apply to a product in Custom Questions. This can only be a single string. Products can accept one tag per product and may not contain commas
        /// </summary>
        public string product_tags { get; set; }
    }
}
