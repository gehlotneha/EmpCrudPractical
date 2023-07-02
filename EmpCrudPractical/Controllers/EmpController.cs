using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpCrudPractical.Models;
using System.Net.Http;

namespace EmpCrudPractical.Controllers
{
    public class EmpController : Controller
    {
        PracticalDBEntities emp = new PracticalDBEntities();
        // GET: Emp
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Employee> empobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44363/api/Employee");

                var consumeapi = hc.GetAsync("Employee");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<List<Employee>>();
                    empobj = displaydata.Result;
                }
                return View(empobj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the employee.";
                return RedirectToAction("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var insertresult = emp.EmpCRUDSP(0, employee.Name, employee.Birthdate, employee.Gender, employee.EmpEducation[0].ToString(), employee.Email, employee.Mobile, employee.Languages, employee.Remarks, "Insert").ToList();
                TempData["SuccessMessage"] = "Record added successfully.";
                return View("Create");
            }
            catch (Exception ex)
            {
                ViewBag.SuccessMessage = "Please fill the details !";
                return View("Create");
            }
           
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Employee empobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44363/api/");

                var consumeapi = hc.GetAsync("Employee?id=" + id.ToString());
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayempdetail = readdata.Content.ReadAsAsync<Employee>();
                    displayempdetail.Wait();
                    empobj = displayempdetail.Result;
                    ViewData["Birthdate"] = empobj.Birthdate;
                }
                return View(empobj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the employee.";
                return RedirectToAction("Error");
            }

        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                var updaterecord = emp.EmpCRUDSP(employee.Id, employee.Name, employee.Birthdate, employee.Gender, employee.Education.ToString(), employee.Email, employee.Mobile, employee.Languages, employee.Remarks, "Update").ToList();
                TempData["SuccessMessage"] = "Record Update successfully.";
                return View("Edit");
            }
            catch (Exception ex)
            {
                ViewBag.SuccessMessage = "Please fill the details !";
                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44363/api/Employee");

                var delete = hc.DeleteAsync("Employee/" + id.ToString());
                delete.Wait();

                var readdata = delete.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the employee.";
                return RedirectToAction("Error");
            }
        }
    }
}