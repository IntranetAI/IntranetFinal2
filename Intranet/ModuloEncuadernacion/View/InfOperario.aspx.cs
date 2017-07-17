using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Intranet.ModuloEncuadernacion.Controller;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class InfOperario : System.Web.UI.Page
    {
        Controller_Enc enc = new Controller_Enc();
        bool respuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            try
            {
                //string nombre = Session["Nom"].ToString();
                //string[] str = nombre.Split(' ');
                //string nom = str[0] + " " + str[2];
                lblOperador.Text = Session["Usuario"].ToString();
            }
            catch
            {
            }
            //calcular turno
            string FechaHoy = DateTime.Now.ToString("MM/dd/yyyy");
            DateTime HoraActual = DateTime.Now;
            string a = DateTime.Now.ToString("MM/dd/yyyy") + " 08:00:00";
            DateTime DiaI = Convert.ToDateTime(a);
            DateTime DiaT = Convert.ToDateTime(FechaHoy + " 16:00:00");
            DateTime Tarde = Convert.ToDateTime(FechaHoy + " 23:59:00");
            //DateTime Noche = Convert.ToDateTime(FechaHoy + "07:59:59");

            if (HoraActual>DiaI && HoraActual<DiaT)
            {
                lblTurno.Text = "Dia";
            }
            else if (HoraActual > DiaT && HoraActual < Tarde)
            {
                lblTurno.Text = "Tarde";
            }
            else
            {
                lblTurno.Text = "Noche";
            }
           


            //fin turno
            if (!IsPostBack)
            {

                CargarMaquinas();
            }
        }
        public void CargarMaquinas()
        {
            ddlMaquina.DataSource = enc.ListaMaquina();
            ddlMaquina.DataTextField = "Maquina";
            ddlMaquina.DataValueField = "id_Maquina";
            ddlMaquina.DataBind();

            ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            respuesta = enc.IngresarOperador(lblOperador.Text, lblTurno.Text, ddlMaquina.SelectedItem.Text, ddlProceso.SelectedItem.Text);

            if (respuesta == true)
            {
                string popupScript = "<script language='JavaScript'> alert(' Informacion Operario Ingresada Correctamente.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' Ha Ocurrido un Error, Vuelva a intentarlo.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDCausa = Convert.ToInt32(ddlMaquina.SelectedValue);
            ddlProceso.DataSource = enc.ListaProceso(IDCausa);
            ddlProceso.DataTextField = "Proceso";
            ddlProceso.DataValueField = "Proceso";
            ddlProceso.DataBind();

            ddlProceso.Items.Insert(0, new ListItem("Seleccione..."));
        }

    }
}