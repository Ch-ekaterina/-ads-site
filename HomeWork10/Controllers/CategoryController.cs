using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using HomeWork10.App_Start;
using HomeWork10.Entities;
using HomeWork10.Forms.Category;
using HomeWork10.Models.Advert;
using HomeWork10.Models.Сategory;
using HomeWork10.Repozitories.Advert;
using HomeWork10.Repozitories.Category;

namespace HomeWork10.Controllers
{
    public class CategoryController : Controller
    {
        private AdvertRepository _advertRepository;
        private CategoryRepository _categoryRepository;
        EFContext ef =new EFContext();

        public CategoryController()
        {
            _advertRepository = new AdvertRepository();
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateModel model = new CreateModel();
            return View("~/Views/Category/Create.cshtml", model);
        }
        [HttpPost]
        public JsonResult Create(CreateForm form)
        {
            CreateModel model = new CreateModel();
            bool isError = false;
            if (string.IsNullOrWhiteSpace(form.Category))
            {
                isError = true;
                model.CategoryError = "Введите название категории";
            }

            if (_categoryRepository.Get(form.Category) != null)
            {
                isError = true;
                model.CategoryError = "Такая категория уже есть";
            }

            model.CategoryValue = form.Category;

            if (!isError)
            {
                _categoryRepository.AddCategory(new СategoryEntity
                {
                    Category = form.Category

                });
                
            }
            return Json(new
            {
                IsSuccess = true
            });
        }

        public ActionResult List()
        {
            var list = _categoryRepository.GetList();
            var model = new CategoryListModel
            {
                List = list
            };

            return View("~/Views/Category/Index.cshtml", model);
        }

        public ActionResult AdvertsCategory(int id)
        {
            var categoryModel = _categoryRepository.Get(id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }

            List<AdvertEntity> advertsList = ef.Adverts
                .Where(x => x.CategoryId == id)
                .OrderByDescending(x => x.CategoryId).ToList();

            CategoryListModel model = new CategoryListModel
            {
               // ItemCategory = categoryModel,
                AdvertsList = advertsList.Select(x => new AdvertViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Desсription
                }).ToList()
            };

            return View("~/Views/Category/View.cshtml", model);
        }
        
    }
}
