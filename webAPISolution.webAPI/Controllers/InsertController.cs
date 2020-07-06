using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webAPISolution.webAPI.Controllers
{
    public class InsertController : ApiController
    {
        DBchucnangEntities db = new DBchucnangEntities();
        [HttpPost]
        public IHttpActionResult InsertTemp(Empreg eg)
        {
            
                if (ModelState.IsValid)
                {
                    db.Empreg.Add(eg);
                    db.SaveChanges();
                }
                return Ok("Thêm thành công");
            
        }
        public IHttpActionResult GetAllForDropdownList()
        {
                 var data = db.Empreg.ToList();
                return Ok(data);
        }
    }
}
