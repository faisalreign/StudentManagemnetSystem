using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        lindaSEntities db = new lindaSEntities();

        public int a { get; private set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {

            if (ModelState.IsValid)
            {
                using (lindaSEntities db = new lindaSEntities())
                {
                    //var obj = db.users.Where(a >= a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();


                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {

                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }

                }

            }
            return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}