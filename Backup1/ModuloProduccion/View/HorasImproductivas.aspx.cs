using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Telerik.Web.UI;

namespace Intranet.ModuloProduccion.View
{
    public partial class HorasImproductivas : System.Web.UI.Page
    {
        Partes par = new Partes();
        public static List<PartesDeProduccion> ll = new List<PartesDeProduccion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime f = Convert.ToDateTime("1900-01-01");
                ddlSeccion.DataSource = par.Listar_Maquinas_TODAS("", "", "", f, f, 5);
                ddlSeccion.DataTextField = "NOMBRE_SECCION";
                ddlSeccion.DataValueField = "ID_SECCION";
                ddlSeccion.DataBind();


                ddlSeccion.Items.Insert(0, new ListItem("Seleccione..."));
                
                ddlMaquina.DataSource = par.Listar_Maquinas_Planas("", "","", f, f, 0);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "ID_Maquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));


                ddlOperacion.DataSource = par.Listar_Operaciones("", "","", f, f, 1);
                ddlOperacion.DataTextField = "Maquina";
                ddlOperacion.DataValueField = "ID_Maquina";
                ddlOperacion.DataBind();
                ddlOperacion.Items.Insert(0, new ListItem("Seleccione..."));




                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string op = "";
            string ma = "";
            if (ddlOperacion.SelectedValue.ToString() == "Seleccione...")
            {
                op = "";
            }
            else
            {
                op = ddlOperacion.SelectedValue.ToString();
            }
            if (ddlMaquina.SelectedValue.ToString() == "Seleccione...")
            {
                ma = "";
            }
            else
            {
                ma = ddlMaquina.SelectedItem.ToString();
            }

            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");


                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");


                ll = par.Listar_Horas_Improductivas(op, ma, ddlSeccion.SelectedValue.ToString(), f1, f2, 4);
                RadGrid1.DataSource = ll;
                RadGrid1.DataBind();
            }
            else
            {
                DateTime f=Convert.ToDateTime("1900-01-01");

                ll = par.Listar_Horas_Improductivas(op, ma,ddlSeccion.SelectedValue.ToString(), f, f, 3);
                RadGrid1.DataSource = ll;
                RadGrid1.DataBind();
                
                
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeccion.SelectedValue.ToString() != "Seleccione...")
            {

                DateTime f = Convert.ToDateTime("1900-01-01");
                ddlMaquina.DataSource = par.Listar_Maquinas_Planas("", "", ddlSeccion.SelectedValue.ToString(), f, f, 0);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "ID_Maquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
        }

        protected void RadGrid1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if ("Maquina".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = ll;
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = ll.OrderBy(o => o.Maquina);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = ll.OrderByDescending(o => o.Maquina);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("OT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = ll;
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = ll.OrderBy(o => o.OT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = ll.OrderByDescending(o => o.OT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = ll;
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = ll.OrderBy(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = ll.OrderByDescending(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }

        }
    }
}