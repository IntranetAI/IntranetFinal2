using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using AjaxControlToolkit;
using Intranet.ModuloSalud.Controller;

namespace Intranet.ModuloSalud.View
{
    public partial class Historico_Ficha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["Usuario"].ToString().ToLower() == "j.venegas") || (Session["Usuario"].ToString().ToLower() == "d.quinteros"))
                {
                    RadGridFichaMedica.DataSource = "";
                    RadGridFichaMedica.DataBind();
                    RadGridControles.DataSource = "";
                    RadGridControles.DataBind();
                    RadGridConsultas.DataSource = "";
                    RadGridConsultas.DataBind();
                }
                else
                {

                    Response.Redirect("../../ModuloProduccion/view/EstadoOT.aspx?id=1");
                }
                
            }
        }

        public void CargarGrilla(string Rut, string Apellidos)
        {
            Controller_FichaMedica controlFicha = new Controller_FichaMedica();
            RadGridFichaMedica.DataSource = controlFicha.ListarFichasMedicas(txtCI.Text.Trim(),txtApellido.Text.Trim());
            RadGridFichaMedica.DataBind();
            if (RadGridFichaMedica.Items.Count > 0)
            {
                div1.Visible = false;
            }
            else
            {
                div1.Visible = true;
            }
            RadGridControles.DataSource = controlFicha.ListarControles(txtCI.Text.Trim(), txtApellido.Text.Trim());
            RadGridControles.DataBind();
            RadGridConsultas.DataSource = controlFicha.ListarConsultasMedicas(txtCI.Text.Trim(), txtApellido.Text.Trim());
            RadGridConsultas.DataBind();

            #region CreacionTabAutomatico
            //List<string> lista = new List<string>();
            //lista.Add("Ficha Medica");
            //lista.Add("Controles");
            //foreach (string x in lista)
            //{
            //    TabPanel tbPanel = new TabPanel();
            //    tbPanel.HeaderText = x;
            //    RadGrid radGrid4 = new RadGrid();

            //    GridBoundColumn columna0 = new GridBoundColumn();
            //    columna0.HeaderText = "Nº Ficha";
            //    columna0.DataField = "NumeroOT";
            //    columna0.ReadOnly = true;
            //    columna0.SortExpression = "NumeroOT";
            //    columna0.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna0);

            //    GridBoundColumn columna1 = new GridBoundColumn();
            //    columna1.HeaderText = "Nombre";
            //    columna1.DataField = "NumeroOT";
            //    columna1.ReadOnly = true;
            //    columna1.SortExpression = "NumeroOT";
            //    columna1.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna1);

            //    GridBoundColumn columna2 = new GridBoundColumn();
            //    columna2.HeaderText = "Edad";
            //    columna2.DataField = "NumeroOT";
            //    columna2.ReadOnly = true;
            //    columna2.SortExpression = "NumeroOT";
            //    columna2.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna2);

            //    GridBoundColumn columna3 = new GridBoundColumn();
            //    columna3.HeaderText = "Sexo";
            //    columna3.DataField = "NumeroOT";
            //    columna3.ReadOnly = true;
            //    columna3.SortExpression = "NumeroOT";
            //    columna3.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna3);

            //    GridBoundColumn columna4 = new GridBoundColumn();
            //    columna4.HeaderText = "Fuma";
            //    columna4.DataField = "NumeroOT";
            //    columna4.ReadOnly = true;
            //    columna4.SortExpression = "NumeroOT";
            //    columna4.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna4);

            //    GridBoundColumn columna5 = new GridBoundColumn();
            //    columna5.HeaderText = "Bebe";
            //    columna5.DataField = "NumeroOT";
            //    columna5.ReadOnly = true;
            //    columna5.SortExpression = "NumeroOT";
            //    columna5.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna5);

            //    GridBoundColumn columna6 = new GridBoundColumn();
            //    columna6.HeaderText = "Droga";
            //    columna6.DataField = "NumeroOT";
            //    columna6.ReadOnly = true;
            //    columna6.SortExpression = "NumeroOT";
            //    columna6.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna6);

            //    GridBoundColumn columna7 = new GridBoundColumn();
            //    columna7.HeaderText = "Comuna";
            //    columna7.DataField = "NumeroOT";
            //    columna7.ReadOnly = true;
            //    columna7.SortExpression = "NumeroOT";
            //    columna7.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna7);

            //    GridBoundColumn columna8 = new GridBoundColumn();
            //    columna8.HeaderText = "Transporte";
            //    columna8.DataField = "NumeroOT";
            //    columna8.ReadOnly = true;
            //    columna8.SortExpression = "NumeroOT";
            //    columna8.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna8);

            //    GridBoundColumn columna9 = new GridBoundColumn();
            //    columna9.HeaderText = "Ver Más";
            //    columna9.DataField = "NumeroOT";
            //    columna9.ReadOnly = true;
            //    columna9.SortExpression = "NumeroOT";
            //    columna9.ItemStyle.Width = 30;
            //    radGrid4.Columns.Add(columna9);

            //    radGrid4.MasterTableView.NoMasterRecordsText = "<div style='text-align:center;'><br />¡ No se han encontrado OTs Nuevas !<br /></div>";

            //    radGrid4.DataSource = "";
            //    radGrid4.DataBind();
            //    radGrid4.Skin = "Outlook";
            //    radGrid4.AllowSorting = true;
            //    System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //    createDiv.ID = "createDiv";
            //    createDiv.Style.Add(HtmlTextWriterStyle.Overflow, "auto");
            //    createDiv.Style.Add(HtmlTextWriterStyle.Height, "548px");
            //    createDiv.Style.Add(HtmlTextWriterStyle.Width, "930px");
            //    createDiv.Controls.Add(radGrid4);

            //    tbPanel.Controls.Add(createDiv);
            //    TabContainer1.Controls.Add(tbPanel);
            #endregion
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 0;
            CargarGrilla(txtCI.Text.Trim(), txtApellido.Text.Trim());
        }

       
    }
}