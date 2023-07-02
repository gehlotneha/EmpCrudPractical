using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpCrudPractical.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using(PracticalDBEntities pd = new PracticalDBEntities())
                {
                    var v = pd.Logins.Where(a => a.Email.Equals(a.Email) && a.Password.Equals(a.Password)).FirstOrDefault();
                    if(v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedEmail"] = v.Email.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(login);
        }

        public ActionResult AfterLogin()
        {
            if(Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}