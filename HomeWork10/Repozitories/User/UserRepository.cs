using System.Collections.Generic;
using System.Linq;
using HomeWork10.App_Start;
using HomeWork10.Entities;
using HomeWork10.Models.User;
using HomeWork10.Models.User.List;


namespace HomeWork10.Repozitories.User
{
    public class UserRepository
    {
        EFContext ef = new EFContext();
        
        public void AddUser(UserEntity userEntity)
        {
            ef.Users.Add(userEntity);
            ef.SaveChanges();
        }
        public UserEntity Get(string login, string password)
        {
            
            return ef.Users.FirstOrDefault(x => x.Login == login
                    && x.Password == password);
        }

        public UserEntity Get(string login)
        {
            return ef.Users.FirstOrDefault(x => x.Login == login); 
        }

        public UserViewModel Get(int id)
        {
            var user = ef.Users.Select(x => new
            {
                UserId = x.Id,
                UserLogin = x.Login
            }).FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return null;
            }

            UserViewModel model = new UserViewModel
            {
                Id = user.UserId,
                Login = user.UserLogin
            };
            return model;
        }

        public List<UsersListItemModel> GetList(int page)
        {
            if (page <= 0)
            {
                return null;
            }
            return ef.Users
                .OrderByDescending(x => x.Id)
                .Skip((page - 1)*3)
                .Take(3)
                .ToUsersListItemModels().ToList();
        }
        public int CountAll()
        {
            return ef.Users.Count();
        }

        
    }

    public static class UserEntityExpresions
    {
        public static IQueryable<UsersListItemModel> ToUsersListItemModels(this IQueryable<UserEntity> query)
        {
            return query.Select(x => new UsersListItemModel
            {
                Id = x.Id,
                Login = x.Login
            });
        }
    }
}