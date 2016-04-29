using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HomeWork10.App_Start;
using HomeWork10.Attribute;
using HomeWork10.Entities;
using HomeWork10.Forms.Advert;
using HomeWork10.Models.Advert;
using HomeWork10.Models.Advert.List;
using HomeWork10.Models.User;
using HomeWork10.Models.Сategory;
using HomeWork10.Repozitories.Advert;
using HomeWork10.Repozitories.Category;

namespace HomeWork10.Controllers
{
    public class AdvertController : Controller
    {
        private AdvertRepository _advertRepository;
        private CategoryRepository _categoryRepository;
        EFContext ef = new EFContext();


        public AdvertController()
        {
            _advertRepository = new AdvertRepository();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Add");
        }

        [HttpGet]
        [ProjectAuthorize]

        public ActionResult Add()
        {
            AdvertViewModel model = new AdvertViewModel();
            return View(model);
        }

        [HttpPost]
        [ProjectAuthorize]
        public JsonResult Add(AddForm form)
        {
            AdvertEntity advert = new AdvertEntity()
            {
                Title = form.Title,
                Desсription = form.Desсription,
                UserId = (int) Session["UserId"],
                CategoryList = _categoryRepository.GetList()

            };

            _advertRepository.Add(advert);

            int advertId = advert.Id;

            return Json(new
            {
                IsSuccess = true,
                AdvertId = advertId
            });
        }

        public ActionResult View(int id)
        {
            var advertModel = _advertRepository.Get(id);
            if (advertModel == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/Advert/View.cshtml", advertModel);
        }

        public ActionResult List(int page = 1)
        {
            var list = _advertRepository.GetList(page);
            var model = new AdvertListModel
            {
                List = list,
                Count = _advertRepository.CountAll(),
                Page = page
            };
        
            return View("~/Views/Advert/List.cshtml", model);
        }
        
    }
}
