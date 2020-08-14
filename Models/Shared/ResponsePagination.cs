using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Shared
{
    public class ResponsePagination
    {
        public Int64 page { get; set; }
        public Int64 count { get; set; } 
        public Int64 total { get; set; }
    }
}
