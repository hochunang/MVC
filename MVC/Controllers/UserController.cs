using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Models;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {
            DatabaseEntities db = new DatabaseEntities();
            User newUser = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password)
                .FirstOrDefault();
            if (newUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View(user);
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                // TODO: Add insert logic here
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                Response.Write("<script LANGUAGE='JavaScript' >alert('Register Successfully')</script>");
                return RedirectToAction("Login");
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid Register')</script>");
                return View();
            }

           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/User/Login");
          
        }
    }
}