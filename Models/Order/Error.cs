using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Order
{
    public class Error
    {
        /// <summary>
        /// The ID of the purchase
        /// </summary>
        public string order_id { get; set; }
        /// <summary>
        /// The field where the error occurred
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// Description of the error in the field
        /// </summary>
        public string error { get; set; }
    }
}
