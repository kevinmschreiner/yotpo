using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Account
{
    public class PlatformType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool billable { get; set; }
    }
}
