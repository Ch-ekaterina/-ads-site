using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork10.Models.Advert.List
{
    public class AdvertListModel
    {
        public List<AdvertViewModel> List { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }
    }
}