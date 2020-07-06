using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace webAPISolution.webAPI
{
    public partial class CallAPI2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Empreg> listdata = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:52584/api/");
            var keyAPI = hc.GetAsync("Insert");
            keyAPI.Wait();
            var readdata = keyAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var datas = readdata.Content.ReadAsAsync<IList<Empreg>>();
                
                datas.Wait();
                listdata = datas.Result;
                var source = listdata.Select(c => new
                {
                    id = c.Empid,
                    name = c.EmpName,
                    location = c.Locations
                }).ToList();
                gv_display.DataSource = source;
                gv_display.DataBind();
            }
        }
    }
}