using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Customer
{
    public class Customer : Properties
    {
        /// <summary>
        /// Two letter uppercase country code indicating the customer country. Default value:US
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// The customer's phone number
        /// </summary>
        public string phone_number { get; set; }
        public List<Shared.CustomProperty> custom_properties { get; set; }
    }
}
