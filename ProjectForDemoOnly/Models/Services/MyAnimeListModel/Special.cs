using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Special
    {
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public List<Genre> genres { get; set; }
        public object image_url { get; set; }
        public double? score { get; set; }
        public double members { get; set; }
        public string synopsis { get; set; }
        public Date date { get; set; }
        public int episodes { get; set; }
        public int duration { get; set; }
        public Properties properties { get; set; }
    }
}