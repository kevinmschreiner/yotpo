using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class AddRemoveRequest : Shared.iAuthorizedRequest
    {
        public List<string> product_ids_to_remove { get; set; }
        public List<string> product_ids_to_add{ get; set; }

        public string utoken { get; set; }

        public void Add(string key)
        {
            if (product_ids_to_add == null) product_ids_to_add = new List<string>();
            product_ids_to_add.Add(key);
        }
        public void Remove(string key)
        {
            if (product_ids_to_remove == null) product_ids_to_remove = new List<string>();
            product_ids_to_remove.Add(key);
        }
    }
}
