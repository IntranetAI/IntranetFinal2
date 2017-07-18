using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Telerik.Web.UI;

namespace Intranet.ModuloPresupuesto.View
{
    public partial class Solicitud_Presupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<string> empresa = new List<string>();
            empresa.Add("Falabella");
            empresa.Add("Sodimac");
            empresa.Add("Tottus");
            empresa.Add("Santillana");

            foreach (string x in empresa)
            {
                TabPanel tbPanel = new TabPanel();
                tbPanel.HeaderText = x;
                RadGrid radGrid4 = new RadGrid();
                
                GridBoundColumn columna0 = new GridBoundColumn();
                columna0.HeaderText = "Nº Ppto";
                columna0.DataField = "NumeroOT";
                columna0.ReadOnly = true;
                columna0.SortExpression = "NumeroOT";
                columna0.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna0);

                GridBoundColumn columna1 = new GridBoundColumn();
                columna1.HeaderText = "Nombre";
                columna1.DataField = "NumeroOT";
                columna1.ReadOnly = true;
                columna1.SortExpression = "NumeroOT";
                columna1.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna1);

                GridBoundColumn columna2 = new GridBoundColumn();
                columna2.HeaderText = "Formato";
                columna2.DataField = "NumeroOT";
                columna2.ReadOnly = true;
                columna2.SortExpression = "NumeroOT";
                columna2.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna2);

                GridBoundColumn columna3 = new GridBoundColumn();
                columna3.HeaderText = "Papel Interior";
                columna3.DataField = "NumeroOT";
                columna3.ReadOnly = true;
                columna3.SortExpression = "NumeroOT";
                columna3.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna3);

                GridBoundColumn columna4 = new GridBoundColumn();
                columna4.HeaderText = "Encuadernación";
                columna4.DataField = "NumeroOT";
                columna4.ReadOnly = true;
                columna4.SortExpression = "NumeroOT";
                columna4.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna4);

                GridBoundColumn columna5 = new GridBoundColumn();
                columna5.HeaderText = "Terminación";
                columna5.DataField = "NumeroOT";
                columna5.ReadOnly = true;
                columna5.SortExpression = "NumeroOT";
                columna5.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna5);

                GridBoundColumn columna6 = new GridBoundColumn();
                columna6.HeaderText = "Costo Total";
                columna6.DataField = "NumeroOT";
                columna6.ReadOnly = true;
                columna6.SortExpression = "NumeroOT";
                columna6.ItemStyle.Width = 30;
                radGrid4.Columns.Add(columna6);

                radGrid4.MasterTableView.NoMasterRecordsText = "<div style='text-align:center;'><br />¡ No se han encontrado OTs Nuevas !<br /></div>";

                radGrid4.DataSource = "";
                radGrid4.DataBind();
                radGrid4.Skin = "Outlook";
                radGrid4.AllowSorting = true;
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Style.Add(HtmlTextWriterStyle.Overflow, "auto");
                createDiv.Style.Add(HtmlTextWriterStyle.Height, "548px");
                createDiv.Style.Add(HtmlTextWriterStyle.Width, "930px");
                createDiv.Controls.Add(radGrid4);
                tbPanel.Controls.Add(createDiv);
                TabContainer1.Controls.Add(tbPanel);
            }
            
            
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

        }






    }
}