using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Yotpo.Light.Models.Review
{
    public class BottomLine
    {
        public int total_review { get; set; }
        public decimal average_score { get; set; }
        public StarDistribution star_distribution { get; set; }
    }
    public class UserBottomLine
    {
        public int total_reviews { get; set; }
        public decimal average_score { get; set; }
        public StarDistribution star_distribution { get; set; }
    }
    public class ProductBottomLine
    {
        public string domain_key { get; set; }
        public decimal product_score { get; set; }
        public int total_reviews { get; set; }
    }
    public class StarDistribution
    {
        [JsonProperty("1")]
        public int one { get; set; }
        [JsonProperty("2")]
        public int two { get; set; }
        [JsonProperty("3")]
        public int three { get; set; }
        [JsonProperty("4")]
        public int four { get; set; }
        [JsonProperty("5")]
        public int five { get; set; }
    }
}
