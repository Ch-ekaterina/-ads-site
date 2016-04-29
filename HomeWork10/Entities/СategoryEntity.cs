using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeWork10.Entities
{
    public class СategoryEntity
    {
        public int Id { get; set; }
        
        public string Category { get; set; }
        
        public List<AdvertEntity> Adverts { get; set; }
        
    }
}