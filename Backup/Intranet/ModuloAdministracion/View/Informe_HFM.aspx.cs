using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloAdministracion.Model;
using System.Text;
using System.Globalization;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Informe_HFM : System.Web.UI.Page
    {
        public static List<HFM_Fin700> lista = new List<HFM_Fin700>();
        Controller_HFMFin700 control700 = new Controller_HFMFin700();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesyAño();
                Cargar();
            }
        }

        public void CargarMesyAño()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
            }
            catch { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL"); }
            #region Mes
            ddlMes.Items.Add("Seleccione Mes");

            List<string> nombreMes = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToList();
            var listaMesesSeleccionados = nombreMes.Select(m => new
            {
                Id = nombreMes.IndexOf(m) + 1,
                Name = m
            });

            foreach (var mes in listaMesesSeleccionados)
            {
                this.ddlMes.Items.Add(new ListItem(mes.Name, mes.Id.ToString()));
            }
            #endregion
            #region Año
            ddlAño.Items.Add("Seleccione Año");
            for (int i = 2013; i <= Convert.ToInt32(DateTime.Now.ToString("yyyy")); i++)
            {
                ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            #endregion
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            if ((ddlMes.SelectedValue == "Seleccione Mes") && (ddlAño.SelectedItem.ToString() == "Seleccione Año"))
            {
                RadGrid1.DataSource = "";
                btnExportar.Visible = false;
            }
            else
            {
                lista = control700.Listar(Convert.ToInt32(ddlAño.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));
                RadGrid1.DataSource = lista;
                btnExportar.Visible = true;
            }

            RadGrid1.DataBind();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            btnExportCSV_Click(lista);
        }

        protected void btnExportCSV_Click(List<HFM_Fin700> lista)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=HFM.txt");
            Response.Charset = "";

            StringBuilder sb = new StringBuilder();
            string nCuenta = "000000000";
            foreach (HFM_Fin700 fin700 in lista)
            {
                sb.Append("QGCHILEADJ;");
                sb.Append(fin700.Año+';');
                switch (fin700.NMes)
                {
                    case 1: fin700.Mes = "JAN"; break;
                    case 2: fin700.Mes = "Feb"; break;
                    case 3: fin700.Mes = "MAR"; break;
                    case 4: fin700.Mes = "APR"; break;
                    case 5: fin700.Mes = "MAY"; break;
                    case 6: fin700.Mes = "JUN"; break;
                    case 7: fin700.Mes = "JUL"; break;
                    case 8: fin700.Mes = "AUG"; break;
                    case 9: fin700.Mes = "SEP"; break;
                    case 10: fin700.Mes = "OCT"; break;
                    case 11: fin700.Mes = "NOV"; break;
                    case 12: fin700.Mes = "DEC"; break;
                }
                sb.Append(fin700.Mes+ ';');
                sb.Append(nCuenta.Substring(0,nCuenta.Length-fin700.NCuenta.Length)+ fin700.NCuenta + ';');
                sb.Append(fin700.Nombre_Cuen.ToUpper().Trim() + ';');
                sb.Append(fin700.Saldo);
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();

        }
    }
}