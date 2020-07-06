using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAuth.Controllers
{
    
    [Authorize(Roles = "Admin,QTV")]
    public class DMAPIController : ApiController
    {
       
       
        apiEntities db = new apiEntities();
        
        [HttpGet]
        
        public IHttpActionResult GetAll()
        {
            var list = db.DanhMucBaiViet.ToList();
            return Ok(list);
        }
    }
}
