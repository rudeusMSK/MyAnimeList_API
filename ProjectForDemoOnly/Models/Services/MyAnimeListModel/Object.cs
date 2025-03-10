using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Object
    {
        public string title { get; set; }
        public string myanimelist_url { get; set; }
        public int myanimelist_id { get; set; }
        public string all_reviews_url { get; set; }
        public string picture_url { get; set; }
    }
}