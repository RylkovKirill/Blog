using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PlacemarkViewModel
    {
        public double x { get; set; }
        public double y { get; set; }
        public bool balloonCloseButton { get; set; }
        public string balloonContent { get; set; }
        public bool hideIconOnBalloonOpen { get; set; }
        public string iconContent { get; set; }
        public string preset { get; set; }
    }
}
