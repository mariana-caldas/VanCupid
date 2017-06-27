using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VanCupid.Models;
using System.Net.Mail;
using System.IO;
using System.Threading.Tasks;
using WebGrease.Activities;


namespace VanCupid.Controllers
{
    public class UsersController : Controller
    {
        private vancupidEntities db = new vancupidEntities();
        private object us;

        // GET: /Users/
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: /Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,Email,Password,Name,Nickname,Location,Interests")] User user, HttpPostedFileBase Photo1, HttpPostedFileBase Photo2)
        {
            if (ModelState.IsValid)
            {

                var userValidationID = db.Users.Where(us => us.UserID == user.UserID).ToList();
                if (userValidationID.Count() > 0)
                {
                    ViewBag.Message = "The UserID is already taken. Choose another one";
                    return View(user);
                }

                var userValidationEmail = db.Users.Where(us => us.Email == user.Email).ToList();
                if (userValidationEmail.Count() > 0)
                {
                    ViewBag.Message = "This email is already taken. Choose another one";
                    return View(user);
                }

                var userValidationNick = db.Users.Where(us => us.Nickname == user.Nickname).ToList();
                if (userValidationNick.Count() > 0)
                {
                    ViewBag.Message = "This Nickname is already taken. Choose another one";
                    return View(user);
                }

                if (Photo1 != null && Photo1.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Photo1.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Photo1.SaveAs(path);

                    user.Photo1 = fileName;
                }

                if (Photo2 != null && Photo2.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Photo2.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Photo2.SaveAs(path);
                    user.Photo2 = fileName;
                }

                db.Users.Add(user);
                db.SaveChanges();
                
            }
            
            //Email
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(user.Email));  // replace with valid value 
            message.From = new MailAddress("vancupid@hotmail.com");  // replace with valid value
            message.Subject = "Welcome to VanCupid!";
            message.Body = string.Format(body, "Vancupid", "no-reply@vancupid.com", "Registration completed.");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "vancupid@hotmail.com",  // replace with valid value
                    Password = "777777Vc"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Email,Password,Name,Nickname,Location,Interests")] User user, HttpPostedFileBase Photo1, HttpPostedFileBase Photo2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;

                if (Photo1 != null && Photo1.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Photo1.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Photo1.SaveAs(path);

                    user.Photo1 = fileName;
                }
                else
                {
                    db.Entry(user).Property(m => m.Photo1).IsModified = false;
                }

                if (Photo2 != null && Photo2.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Photo2.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Photo2.SaveAs(path);

                    user.Photo2 = fileName;
                }
                else
                {
                    db.Entry(user).Property(m => m.Photo2).IsModified = false;
                }


                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // GET: /Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
