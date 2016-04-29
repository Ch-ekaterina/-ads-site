using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using HomeWork10.App_Start;
using HomeWork10.Entities;
using HomeWork10.Forms.Category;
using HomeWork10.Models.Advert;
using HomeWork10.Models.Сategory;

namespace HomeWork10.Repozitories.Category
{
    public class CategoryRepository
    {
        EFContext ef = new EFContext();

        public void AddCategory(СategoryEntity categoryEntity)
        {
            ef.Сategories.Add(categoryEntity);
            ef.SaveChanges();
        }

        public СategoryEntity Get(string category)
        {
            return ef.Сategories
                .FirstOrDefault(x => x.Category == category);
        }

        public СategoryViewModel Get(int id)
        {
            var category = ef.Сategories.Select(x => new
            {
                Id = x.Id,
                Category = x.Category
            }).FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return null;
            }
            СategoryViewModel model = new СategoryViewModel
            {
                Id = category.Id,
                Category = category.Category
            };
            return model;

        }
        
        public List<СategoryViewModel> GetList()
        {
            return ef.Сategories.OrderByDescending(x => x.Id)
                .Select(x => new СategoryViewModel
            {
                Id = x.Id,
                Category = x.Category
            }).ToList();
        }


        


        
    }
}