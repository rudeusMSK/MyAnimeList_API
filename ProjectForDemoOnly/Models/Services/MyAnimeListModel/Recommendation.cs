using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Recommendation
    {
        public Liked liked { get; set; }
        public Recommendation recommendation { get; set; }
        public Recommendation2 recommendation2 { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public string recommendation_age { get; set; }
    }
}