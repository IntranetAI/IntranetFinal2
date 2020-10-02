using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var url = "http://webservices.aimpresores.cl/ServiceMail.asmx/Lithoman_OTPliego";

                var syncClient = new WebClient();
                var content = syncClient.DownloadString(url);
                Label1.Text = content.ToString();
            }
        }
    }
}