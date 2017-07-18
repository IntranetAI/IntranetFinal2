using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class OPSCreadas : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        DateTime fc = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = bp.OPSCreadas("", "", "", "", fc, fc, 0, Session["Usuario"].ToString(), 0);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                RadGrid1.DataSource = bp.OPSCreadas("", "", "", "", fi, ft, 0,Session["Usuario"].ToString(), 2);
                RadGrid1.DataBind();
            }
            else
            {
                if (txtOT.Text != "" || txtNombreOT.Text != "" || txtPapel.Text != "" || txtCodigoPapel.Text != "")
                {
                    RadGrid1.DataSource = bp.OPSCreadas(txtOT.Text, txtNombreOT.Text, txtPapel.Text, txtCodigoPapel.Text, fc, fc, 0, Session["Usuario"].ToString(), 3);
                    RadGrid1.DataBind();
                } 
                else
                {
                    RadGrid1.DataSource = bp.OPSCreadas("", "", "", "", fc, fc, 0, Session["Usuario"].ToString(), 0);
                    RadGrid1.DataBind();
                }
            }
        }
        protected void gridSearchResults_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                TableCell myCell = dataItem["Estado"];
                if ((myCell.Text.Contains("Parcialmente Atendida")))
                {
                    dataItem.BackColor = System.Drawing.Color.Yellow;// .ForeColor = System.Drawing.Color.Red;

                }
                else if ((myCell.Text.Contains("Atendida")))
                {
                    dataItem.BackColor = System.Drawing.Color.Green;
                }
            }
        }

    }
}