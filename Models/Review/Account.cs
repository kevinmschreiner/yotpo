using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class Account
    {
        public Int64 id { get; set; }
        public string domain { get; set; }
        public ImageMeta map_image { get; set; }
        public ImageMeta comments_avatar { get; set; }
        public string comments_display_name { get; set; }
    }
}
