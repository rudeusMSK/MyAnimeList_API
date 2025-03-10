using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Review
    {
        public User user { get; set; }
        public string tag { get; set; }
        public List<string> tags { get; set; }
        public Text text { get; set; }
        public Date date { get; set; }
        public Object @object { get; set; }
    }
}