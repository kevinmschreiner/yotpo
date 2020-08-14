using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ImageMeta
    {
        public Int64 id { get; set; }
        public string image_url { get; set; }
        public string big_image_url { get; set; }
        public string image_content_type { get; set; }
        public int image_width { get; set; }
        public int image_height { get; set; }
        public string imageable_type { get; set; }
        public Int64 imageable_id { get; set; }
    }
}
