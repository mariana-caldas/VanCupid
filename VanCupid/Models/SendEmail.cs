using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanCupid.Models
{
    public class SendEmail
    {
        public int UserID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}