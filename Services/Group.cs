using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Product;

namespace Yotpo.Light.Services
{
    public class Group : Base
    {
        public Group(string appKey, string secretKey) : base(appKey, secretKey) { }

        public bool Create(string name)
        {
            var request = new Models.Product.CreateGroupRequest
            {
                group_name = name
            };
            var result = base.Post("v1/apps/{{APPKEY}}/products_groups", request);
            if (result != null && result.status.code==200)
            {
                return true;
            }
            return false;
        }

        public List<ProductGroup> Retrieve()
        {
            string url = "v1/apps/{{APPKEY}}/products_groups?utoken={{UTOKEN}}";
            //if (count != null) url += "&count=" + count.Value.ToString();
            //if (page != null) url += "&page=" + page.Value.ToString();

            var result = Models.Product.GroupResponse.from(base.Get(url));
            if (result != null) return result.products_groups;
            return null;
        }

        public ProductGroupDetail Retrieve(string key)
        {
            string url = "v1/apps/{{APPKEY}}/products_groups/"+key+"?utoken={{UTOKEN}}";
            var result = Models.Product.GroupDetailResponse.from(base.Get(url));
            if (result!=null && result.products_group != null)
            {
                return result.products_group;
            }
            return null;
        }

        public bool Products_AddRemove(string key, List<string> add, List<string> remove)
        {
            var request = new Models.Product.AddRemoveRequest
            {
                product_ids_to_add = add,product_ids_to_remove = remove
            };
            var result = (Models.Shared.ResponseEnvelope)base.Put("v1/apps/{{APPKEY}}/products_groups/" + key, request);
            if (result != null && result.status.code == 200)
            {
                return true;
            }
            return false;
        }

        public bool Products_Add(string key, List<string> add)
        {
            var request = new Models.Product.AddRemoveRequest
            {
                product_ids_to_add = add
            };
            var result = (Models.Shared.ResponseEnvelope)base.Put("v1/apps/{{APPKEY}}/products_groups/" + key, request);
            if (result != null && result.status.code == 200)
            {
                return true;
            }
            return false;
        }

        public bool Products_Remove(string key, List<string> remove)
        {
            var request = new Models.Product.AddRemoveRequest
            {
                product_ids_to_remove = remove
            };
            var result = (Models.Shared.ResponseEnvelope)base.Put("v1/apps/{{APPKEY}}/products_groups/" + key, request);
            if (result != null && result.status.code == 200)
            {
                return true;
            }
            return false;
        }

        public bool Products_Add(string key, string add)
        {
            var request = new Models.Product.AddRemoveRequest();
            request.Add(add);
            var result = (Models.Shared.ResponseEnvelope)base.Put("v1/apps/{{APPKEY}}/products_groups/" + key, request);
            if (result != null && result.status.code == 200)
            {
                return true;
            }
            return false;
        }

        public bool Products_Remove(string key, string remove)
        {
            var request = new Models.Product.AddRemoveRequest();
            request.Remove(remove);
            var result = (Models.Shared.ResponseEnvelope)base.Put("v1/apps/{{APPKEY}}/products_groups/" + key, request);
            if (result != null && result.status.code == 200)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string key)
        {
            var result = base.Delete("v1/apps/{{APPKEY}}/products_groups/" + key + "?utoken={{UTOKEN}}");
            if (result.status.code == 200) return true;
            return false;
        }
    }
}
