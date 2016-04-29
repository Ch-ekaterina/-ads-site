using System.Collections.Generic;
using System.Linq;
using HomeWork10.App_Start;
using HomeWork10.Controllers;
using HomeWork10.Entities;
using HomeWork10.Models.Advert;
using HomeWork10.Repozitories.Category;

namespace HomeWork10.Repozitories.Advert
{
    public class AdvertRepository
    {
        
        EFContext ef = new EFContext();
        CategoryRepository _categoryRepository = new CategoryRepository();
        public void Add(AdvertEntity advert)
        {
            ef.Adverts.Add(advert);

            ef.SaveChanges();
        }

        public AdvertViewModel Get(int id)
        {
            var list = _categoryRepository.GetList();
            var advert = ef.Adverts.Select(x => new
            {
                AdvertId = x.Id,
                AdvertTitle = x.Title,
                AdvertDescription = x.Desсription,
                AuthorUserName = x.User.Login,
                CategoryId = x.CategoryId,
                CategoruList = list
                
            }).FirstOrDefault(x => x.AdvertId == id);
            if (advert == null)
            {
                return null;
            }
            AdvertViewModel model = new AdvertViewModel
            {
                Id = advert.AdvertId,
                Title = advert.AdvertTitle,
                Description = advert.AdvertDescription,
                AuthorName = advert.AuthorUserName,
                CategoryId = advert.CategoryId,
                CategoryList = list

            };

            return model;
        }

        
        public List<AdvertViewModel> GetList(int page)
        {
            if (page <= 0)
            {
                return null;
            }

            return ef.Adverts
                    .OrderByDescending(x => x.Id)
                    .Skip((page - 1) * 3)
                    .Take(3)
                    .ToAdvertViewModel()
                    .ToList();
        }

      
        public int CountAll()
        {
            return ef.Adverts.Count();
        }

        
    }

    public static class AdvertEntityExtensions
    {
        private static CategoryRepository _categoryRepository;
        public static IQueryable<AdvertViewModel> ToAdvertViewModel(this IQueryable<AdvertEntity> query)
        {
           var list = _categoryRepository.GetList();
           return query.Select(x => new AdvertViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Desсription,
                AuthorId = x.UserId,
                Category = x.Category.Category,
                AuthorName = x.User.Login,
                CategoryList = list
            });
        }
    }
}