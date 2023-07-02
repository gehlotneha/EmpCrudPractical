using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpCrudPractical.Models;

namespace EmpCrudPractical.Controllers
{
    public class EmployeeController : ApiController
    {
        PracticalDBEntities emp = new PracticalDBEntities();

        public IHttpActionResult GetEmp()
        {
            try
            {
                var results = emp.EmpCRUDSP(0, "", DateTime.Now, "", "", "", "", "", "", "Get").ToList();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //public IHttpActionResult InsertEmp(Employee employee)
        //{
        //    var insertresult = emp.EmpCRUDSP(0,employee.Name,employee.Birthdate,employee.Gender,employee.EmpEducation.ToString(),employee.Email,employee.Mobile,employee.Languages,employee.Remarks,"Insert").ToList();
        //    return Ok(insertresult);
        //}

        public IHttpActionResult GetEmpID(int id)
        {
            try
            {
                var empdetails = emp.EmpCRUDSP(id, "", DateTime.Now, "", "", "", "", "", "", "GetEmpId").Select(x => new Employee()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Birthdate = x.Birthdate,
                    Gender = x.Gender,
                    Education = x.Education,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    Languages = x.Languages,
                    Remarks = x.Remarks
                }).FirstOrDefault<Employee>();
                return Ok(empdetails);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //public IHttpActionResult EmPUpdate(Employee employee)
        //{
        //    var updaterecord = emp.EmpCRUDSP(employee.Id, employee.Name, employee.Birthdate, employee.Gender, employee.EmpEducation.ToString(), employee.Email, employee.Mobile, employee.Languages, employee.Remarks, "Update").ToList();
        //    return Ok(updaterecord);
        //}

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var deleteemp = emp.EmpCRUDSP(id, "", DateTime.Now, "", "", "", "", "", "", "Delete").Select(x => new Employee()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Birthdate = x.Birthdate,
                    Gender = x.Gender,
                    Education = x.Education,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    Languages = x.Languages,
                    Remarks = x.Remarks
                }).FirstOrDefault<Employee>();
                emp.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
