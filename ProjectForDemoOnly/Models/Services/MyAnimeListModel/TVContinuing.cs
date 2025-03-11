using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class TVContinuing
    {
        public string title { get; set; } = null;
        public string type { get; set; } = null;
        public string url { get; set; } = null;
        public List<Genre> genres { get; set; } = null;
        public object image_url { get; set; } = null;
        public double? score { get; set; }
        public double? members { get; set; }
        public string synopsis { get; set; } = null;
        public Date date { get; set; } = null;
        public int? episodes { get; set; }
        public int? duration { get; set; }
        public Properties properties { get; set; } = null;
    }
}