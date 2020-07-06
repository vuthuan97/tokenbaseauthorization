using RunAPIAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;



namespace RunAPIAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult Login(string token)
        {
            List<DanhmucView> lst = new List<DanhmucView>();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44375/api/");
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            hc.DefaultRequestHeaders.Add("Authorization",token);
            var keyAPI = hc.GetAsync("DMAPI");
            keyAPI.Wait();
            var read = keyAPI.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<List<DanhmucView>>();
                lst = data.Result;

                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("đã có lỗi xảy ra "+read.StatusCode,JsonRequestBehavior.AllowGet);
            }

            
        }  

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}