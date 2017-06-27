using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanCupid.Models
{
    public class Login
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}