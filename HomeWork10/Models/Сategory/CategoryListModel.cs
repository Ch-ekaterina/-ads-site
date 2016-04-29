using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWork10.Models.Advert;
using HomeWork10.Models.Advert.List;

namespace HomeWork10.Models.Сategory
{
    public class CategoryListModel
    {
        public string ItemCategory { get; set; }

        public AdvertViewModel ItemAdvert { get; set; }

        public List<СategoryViewModel> List { get; set; }

        public List<AdvertViewModel> AdvertsList { get; set; }
    }
}