using System.Collections.Generic;
using HomeWork10.Models.Advert;


namespace HomeWork10.Models.User
{
    public class AdvertsByUserModel
    {
        public int Count { get; set; }
        public int Page { get; set; }

        public UserViewModel UserViewModel { get; set; }

        public List<AdvertViewModel> AdvertsList { get; set; }
    }
}