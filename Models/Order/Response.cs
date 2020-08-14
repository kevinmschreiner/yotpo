using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Order
{
    public class Response
    {
        public List<Purchase> purchases { get; set; }
        public Int64 total_purchases { get; set; }
        public int total_orders { get; set; }
    }
}
