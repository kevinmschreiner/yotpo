using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Yotpo.Light.Models.Order;

namespace Yotpo.Light.Services
{
    public class Purchase:Base
    {
        public Purchase(string appKey, string secretKey) : base(appKey,secretKey) { }
        public Purchase(string appKey, string secretKey, iLogHandler handler) : base(appKey, secretKey)
        {
            base.Attach(handler);
        }
        public bool Create(Models.Order.Request order)
        {
            var result = base.Post("apps/{{APPKEY}}/purchases/", order);
            return true;
        }
        public bool Create(List<Models.Order.Request> orders)
        {
            if (orders != null && orders.Count > 0)
            {
                var request = new MassRequest();
                request.platform = orders[0].platform;
                request.orders = new List<Order>();
                foreach (var o in orders) request.orders.Add(o);

                var result = base.Post("apps/{{APPKEY}}/purchases/mass_create.json", request);
                return true;
            }
            return false;
        }

        public Models.Order.Response Retrieve(int? count=null, int? page=null)
        {
            string url = "apps/{{APPKEY}}/purchases?utoken={{UTOKEN}}";
            if (count != null) url += "&count=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            return ((JObject)base.Get(url).response).ToObject<Models.Order.Response>();
        }

        public bool Invalidate(string order_id)
        {
            var request = new InvalidateRequest();
            request.Add(order_id);
            var result = base.Delete("apps/{{APPKEY}}/purchases", request);
            if (result.status.code == 200) return true;
            return false;
        }
        public bool Invalidate(string order_id, IEnumerable<string> skus)
        {
            var request = new InvalidateRequest();
            request.Add(order_id,skus);
            var result = base.Delete("apps/{{APPKEY}}/purchases", request);
            if (result.status.code == 200) return true;
            return false;
        }
        public bool Invalidate(IEnumerable<string> order_ids)
        {
            var request = new InvalidateRequest();
            foreach (var order_id in order_ids)
            {
                request.Add(order_id);
            }
            var result = base.Delete("apps/{{APPKEY}}/purchases", request);
            if (result.status.code == 200) return true;
            return false;
        }
        
        public bool Invalidate(InvalidateRequest request)
        {
            var result = base.Delete("apps/{{APPKEY}}/purchases", request);
            if (result.status.code == 200) return true;
            return false;
        }
    }
}
