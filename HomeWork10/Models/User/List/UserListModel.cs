using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork10.Models.User.List
{
    public class UsersListModel
    {
        public List<UsersListItemModel> UsersList { get; set; }
        
        public int Count { get; set; }

        public int Page { get; set; }
    }
}