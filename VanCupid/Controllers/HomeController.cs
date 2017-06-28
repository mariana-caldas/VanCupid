using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VanCupid.Models;
using VanCupid.Library;
using System.Net.Mail;
using System.IO;
using System.Threading.Tasks;
using WebGrease.Activities;

namespace VanCupid.Controllers
{
    public class HomeController : Controller
    {
        private vancupidEntities db = new vancupidEntities();
        public ActionResult Index()
        {

            if (Session["LoggedUser"] != null)
            {
                if (Session["Location"] != null)
                {
                    var search = new SearchLocation
                    {
                        Location = Session["Location"].ToString()
                    };
                    return View(search);
                }
            }
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserList(SearchLocation search)
        {
            if (Session["LoggedUser"] != null)
            {
                var exists = db.Users.Where(us => search.Location.Contains(us.Location)).ToList();


                return View(exists);
            }

            Session["Location"] = search.Location;
            return RedirectToAction("UserLogin");
        }
        public ActionResult UserLogin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult UserLogin([Bind(Include = "UserID,Email,Password")] Login login)
        {
            var exists = db.Users.Where(us =>
                us.Email == login.Email
                && us.Password == login.Password)
                .FirstOrDefault();

            if (exists != null)
            {
                Session["LoggedUser"] = exists.Nickname;
                Session["LoggedUserType"] = "Users";
                Session["LoggedUserID"] = exists.UserID;
                return RedirectToAction("Index");
            }

            ViewBag.MessageErrorLogin = "Email or Password invalids";

            return View();
        }



        public ActionResult UserRegister()
        {
            ViewBag.Message = "Your register page.";

            return View();
        }


        public ActionResult Logout()
        {
            Session["LoggedUser"] = null;
            Session["LoggedUserType"] = null;
            Session["LoggedUserID"] = null;
            return RedirectToAction("Index");
        }


        public ActionResult SendEmail(int UserID)
        {
            ViewBag.UserID = UserID;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(SendEmail form)
        {
            var userToNotify = db.Users.Where(u => u.UserID == form.UserID).FirstOrDefault();

            //Email
            var email = new Email(userToNotify.Email);
            email.SetMessage(form.Message);
            email.SetSubject(form.Subject);
            await email.Send();

            ViewBag.Message = "Message sent!";
            return View();
        }


    }

}