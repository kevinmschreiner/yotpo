using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class CreateGroupRequest : Shared.iAuthorizedRequest
    {
        public string utoken { get; set; }
        public string group_name { get; set; }
    }
}
