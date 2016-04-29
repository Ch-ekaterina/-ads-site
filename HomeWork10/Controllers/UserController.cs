using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using HomeWork10.App_Start;
using HomeWork10.Models.User;
using HomeWork10.Entities;
using HomeWork10.Forms.User;
using HomeWork10.Models.Advert;
using HomeWork10.Models.Advert.List;
using HomeWork10.Models.User.List;
using HomeWork10.Repozitories.Advert;
using HomeWork10.Repozitories.User;

namespace HomeWork10.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private AdvertRepository _advertRepository;
        EFContext ef = new EFContext();

        public UserController()
        {
            _userRepository = new UserRepository();
            _advertRepository = new AdvertRepository();
        }


        public ActionResult Index()
        {
            return RedirectToAction("Register", "User");
        }
        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            return View("~/Views/User/Register.cshtml", model);
        }

        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            RegisterModel model = new RegisterModel();
            bool isError = false;
            if (string.IsNullOrWhiteSpace(form.Login))
            {
                isError = true;
                model.LoginError = "Введите логин";
            }
            if (_userRepository.Get(form.Login) != null)
            {
                isError = true;
                model.LoginError = "Такой пользователь уже есть";
            }

            if (string.IsNullOrWhiteSpace(form.Password))
            {
                isError = true;
                model.PasswordError = "Введите пароль";
            }
            else if (form.Password != form.PasswordRepeat)
            {
                isError = true;
                model.PasswordError = "Пароли не совпадают";
            }

            model.LoginValue = form.Login;

            if (!isError)
            {
                _userRepository.AddUser(new UserEntity
                {
                    Login = form.Login,
                    Password = form.Password
                });

                return RedirectToAction("Login", "User");

            }

            return View("~/Views/User/Register.cshtml", model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            UserEntity user = _userRepository.Get(login, password);

            if (user != null)
            {
                Session["UserId"] = user.Id;
            }

            return View();
        }
        public ActionResult View(int id, int page = 1)
        {
            var userModel = _userRepository.Get(id);
            if (userModel == null) 
            {
                return HttpNotFound();
            }


           List<AdvertEntity> advertsList = ef.Adverts.Where(x => x.UserId == id)
               .OrderByDescending(x => x.Id)
               .Skip(3*(page - 1))
               .Take(3).ToList();

            AdvertsByUserModel model = new AdvertsByUserModel
            {
                UserViewModel = userModel,
                AdvertsList = advertsList.Select(x => new AdvertViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Desсription
                }).ToList(),
                Count = ef.Adverts.Where(x => x.UserId == id).Count(),
               
                Page = page,
               
            };

            return View("~/Views/User/View.cshtml", model);
        }
        public ActionResult UsersList(int page = 1)
        {
            var usersList = _userRepository.GetList(page);
            var model = new UsersListModel
            {
                UsersList = usersList,
                Count = _userRepository.CountAll(),
                Page = page
            };
            return View("~/Views/User/UsersList.cshtml", model);
        }

        public ActionResult List(int page = 1)
        {
            var list = _advertRepository.GetList(page);
            var model = new AdvertsByUserModel
            {
                AdvertsList = list,
                Count = _advertRepository.CountAll(),
                Page = page
            };

            return View("~/Views/User/View.cshtml", model);
        }



    }
}