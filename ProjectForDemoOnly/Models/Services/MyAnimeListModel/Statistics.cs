using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Statistics
    {
        public double score { get; set; }
        public int ranked { get; set; }
        public int popularity { get; set; }
        public int members { get; set; }
        public int favorites { get; set; }
    }
}