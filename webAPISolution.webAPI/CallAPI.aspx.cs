using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace webAPISolution.webAPI
{
    public partial class CallAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Empreg> listdata = null;
            HttpClient htcl = new HttpClient();
            htcl.BaseAddress = new Uri("http://localhost:52584/api/");
            var sourceAPI = htcl.GetAsync("Insert");
            sourceAPI.Wait();
            var readdata = sourceAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var datadisplay = readdata.Content.ReadAsAsync<IList<Empreg>>();
                datadisplay.Wait();
                listdata = datadisplay.Result;
                dropdown.DataSource = listdata;
                dropdown.DataTextField = "EmpName";
                dropdown.DataValueField = "Empid";
                dropdown.DataBind();
            }

        }
    }
}