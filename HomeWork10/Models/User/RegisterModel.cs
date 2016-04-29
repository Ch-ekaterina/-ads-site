using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace HomeWork10.Models.User
{
    public class RegisterModel
    {
        public string LoginError { get; set; }
        public string PasswordError { get; set; }
        public string LoginValue { get; set; }
    }
}