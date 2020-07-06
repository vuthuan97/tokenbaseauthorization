using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace solution.API2.Controllers
{
    public class EmployeeController : ApiController
    {
        DBchucnangEntities db = new DBchucnangEntities();
        public IEnumerable<Employees> Get()
        {
            return db.Employees.ToList();
        }
        public Employees Get(int id)
        {
            return db.Employees.SingleOrDefault(c => c.ID == id);
        }
        public HttpResponseMessage Post([FromBody] Employees emp)
        {

            try
            {

                db.Employees.Add(emp);
                db.SaveChanges();
                var mess = Request.CreateResponse(HttpStatusCode.Created, emp);
                mess.Headers.Location = new Uri(Request.RequestUri + emp.ID.ToString());
                return mess;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = db.Employees.FirstOrDefault(c => c.ID == id);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "không tồn tại nhân viên nào vs ai id =" + id.ToString());
                }
                else
                {
                    db.Employees.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
           


        }
        public HttpResponseMessage Put(int id,[FromBody] Employees emp)
        {
            try
            {
                var entity = db.Employees.FirstOrDefault(c => c.ID == id);
                if (entity != null)
                {
                    entity.FirstName = emp.FirstName;
                    entity.LastName = emp.LastName;
                    entity.Gender = emp.Gender;
                    entity.Salary = emp.Salary;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "không tồn tại nhân viên nafaof với mã id là " + id.ToString());
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            
        }

    }
}
