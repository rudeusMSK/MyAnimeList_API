using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public class Information
    {
        public List<Type> type { get; set; }
        public string episodes { get; set; }
        public string status { get; set; }
        public string aired { get; set; }
        public List<Premiered> premiered { get; set; }
        public string broadcast { get; set; }
        public List<Producer> producers { get; set; }
        public List<Licensor> licensors { get; set; }
        public List<Studio> studios { get; set; }
        public List<Source> source { get; set; }
        public string genre { get; set; }
        public string theme { get; set; }
        public string duration { get; set; }
        public string rating { get; set; }
        public List<Genre> genres { get; set; }
        public List<Demographic> demographic { get; set; }
    }
}