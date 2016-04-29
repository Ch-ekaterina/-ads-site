using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork10.Entities;
using HomeWork10.Models.Сategory;

namespace HomeWork10.Models.Advert
{
    public class AdvertViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int? CategoryId { get; set; }

        public string Category { get; set; }

        public List<СategoryViewModel> CategoryList { get; set; }
    }
}