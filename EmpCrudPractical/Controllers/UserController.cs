using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpCrudPractical.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            Login login = new Login();
            return View(login);
        }

        [HttpPost]
        public ActionResult AddorEdit(Login login)
        {
            try
            {
                if (login.Email != null && login.Password != null && login.Username != null)
                {
                    using (PracticalDBEntities db = new PracticalDBEntities())
                    {
                        db.Logins.Add(login);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    TempData["SuccessMessage"] = "Registration Successfull !";
                }
                return View("AddorEdit", new Login());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the employee.";
                return RedirectToAction("Error");
            }
            
        }
    }
}