using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using EmployeeDataAccess;
using Microsoft.Ajax.Utilities;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        public IEnumerable<Employee> Get()
        {

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                 var entity= entities.Employees.Where(a => a.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else 
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not Found " + id.ToString());
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {

              return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

           
        }
    }
}
