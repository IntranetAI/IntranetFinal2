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

              //  double algo=
                //var url = "http://192.168.4.100/lithoman_ea.php";//"http://webservices.aimpresores.cl/ServiceMail.asmx/Lithoman_OTPliego";

                //var syncClient = new WebClient();
                //string content = syncClient.DownloadString(url);
                 
                //string[]  contenido = content.ToString().Split(',');
                //string var1 = contenido[0].Replace("\r\n\"energia_activa:", "").Trim();
                //double consumo = Convert.ToDouble(var1);
                //string var2 = contenido[1];
                //Label1.Text = content.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double algo = Convert.ToDouble(TextBox1.Text);

            double nose = algo % 1000;
            double nose2 = algo % 100;
        }
    }
}