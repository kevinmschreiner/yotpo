using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class BottomLineResponse
    {
        public UserBottomLine bottomline { get; set; }
    }
    public class BottomLinesResponse
    {
        public List<ProductBottomLine> bottomlines { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
    }
}
