using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Yotpo.Light.Models.Order
{
    public class InvalidateRequest
    {
        public string utoken { get; set; }
        public List<Invalidation> orders { get; set; }
        public class Invalidation
        {
            public string order_id { get; set; }
            public List<string> skus { get; set; }
        }

        public void Add(string order_id)
        {
            if (this.orders == null) this.orders = new List<Invalidation>();
            var invalidation = new Invalidation();
            invalidation.order_id = order_id;
            this.orders.Add(invalidation);
        }
        public void Add(string order_id, IEnumerable<string> skus)
        {
            if (this.orders == null) this.orders = new List<Invalidation>();
            var invalidation = new Invalidation();
            invalidation.order_id = order_id;
            invalidation.skus = new List<string>();
            invalidation.skus.AddRange(skus);
            this.orders.Add(invalidation);
        }
    }
}
