using EmpCrudPractical.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpCrudPractical.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginClass loginClass)
        {
            try
            {
                string con = @"Data Source=DESKTOP-IE1N485\CHINU;Initial Catalog=PracticalDB;integrated security=True;";
                //string con = ConfigurationManager.ConnectionStrings["PracticalDBEntities"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                string qry = "select Email,Password from [dbo].[Login] where Email = @Email and Password = @Password";
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(qry, sqlcon);
                sqlcom.Parameters.AddWithValue("@Email", loginClass.Email);
                sqlcom.Parameters.AddWithValue("@Password", loginClass.Password);
                SqlDataReader sdr = sqlcom.ExecuteReader();
                if (sdr.Read())
                {
                    Session["Email"] = loginClass.Email.ToString();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Emp");
                }
                else
                {
                    ViewData["Message"] = "User Login Details Failed !";
                }
                sqlcon.Close();
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the employee.";
                return RedirectToAction("Error");
            }

        }
    }
}