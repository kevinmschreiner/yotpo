using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Order
{
    public class Metadata
    {
        public string coupon_used { get; set; }
        public string delivery_type { get; set; }
        public List<Shared.CustomProperty> customer_properties { get; set; }
    }
}
