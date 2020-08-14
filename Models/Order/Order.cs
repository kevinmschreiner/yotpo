using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Order
{
    public class Order
    {
        /// <summary>
        /// The email address of the customer who made the order
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// The name of the customer who made the order
        /// </summary>
        public string customer_name { get; set; }

        /// <summary>
        /// The unique order ID. Orders using the same order_id will not be created.
        /// </summary>
        public string order_id { get; set; }


        /// <summary>
        /// Only used as an external reference for the Points and Rewards feature
        /// </summary>
        public string user_reference { get; set; }

        /// <summary>
        /// The date of the order in the format YYYY-MM-DD. If this is not provided, the time of the request will be used as the order date. It is not possible to send a MAP emails for orders older than six months.
        /// </summary>
        public string order_date { get; set; }

        /// <summary>
        /// The ISO code of the currency in which the order was made. Must be three characters long. 
        /// </summary>
        public string currency_iso { get; set; }

        public Dictionary<string, Models.Product.Product> products { get; set; }

        public Customer.Customer customer { get; set; }
        public Customer.Properties customer_properties { get; set; }

        /// <summary>
        /// The type of shipping/delivery chosen for this order e.g. same_day, express, standard
        /// </summary>
        public string delivery_type { get; set; }

        public List<Shared.CustomProperty> custom_properties { get; set; }

    }
}
