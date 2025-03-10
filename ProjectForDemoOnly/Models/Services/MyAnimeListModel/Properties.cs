using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Properties
    {
        public Studio studio { get; set; }
        public string source { get; set; }
        public Themes themes { get; set; }
        public Demographic demographic { get; set; }
        public Theme theme { get; set; }
        public Studios studios { get; set; }
        public Demographics demographics { get; set; }
    }
}