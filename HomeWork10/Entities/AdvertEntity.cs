using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HomeWork10.Models.Сategory;

namespace HomeWork10.Entities
{
    public class AdvertEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desсription { get; set; }

    [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        
         [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public СategoryEntity Category { get; set; }
        public List<СategoryViewModel> CategoryList { get; set; }
    }
}