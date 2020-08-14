using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class Metadata : ProductProperty
    {
        public List<Shared.CustomProperty> customer_properties { get; set; }
    }
}
