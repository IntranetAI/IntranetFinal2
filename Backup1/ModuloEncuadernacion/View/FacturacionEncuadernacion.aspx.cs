using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class FacturacionEncuadernacion : System.Web.UI.Page
    {
        Controller_FacturacionEnc f = new Controller_FacturacionEnc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                string fecIni = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";
                string fecTer = str[1] + "/" + str[0] + "/" + str[2] + " 23:59:59";

                RadGrid1.DataSource = "";//f.ListaFacturacionEnc(txtOP.Text, "", Convert.ToDateTime("09/23/2014 00:00:00"), Convert.ToDateTime("09/30/2014 00:00:00"), 0);
                RadGrid1.DataBind();

            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            DateTime fe = Convert.ToDateTime("1900-01-01");
            if (txtOP.Text != "")
            {
                RadGrid1.DataSource = f.ListaFacturacionEnc(txtOP.Text, "", fe, fe, 12);
                RadGrid1.DataBind();
            }
            else if(txtFechaInicio.Text!="" && txtFechaTermino.Text!="")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                string fechaInicio = mes + "/" + dia + "/" + año + " 00:00:00";


                string fechat = txtFechaInicio.Text;
                string[] strt = fechaI.Split('/');
                string diat = strt[0];
                string mest = strt[1];
                string añot = strt[2];
                añot = añot.Substring(0, 4);
                string fechaTermino = mest + "/" + diat + "/" + añot + " 23:59:59";

                RadGrid1.DataSource = f.ListaFacturacionEnc("", "", Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 0);
                RadGrid1.DataBind();

            }
            else if (txtNombreOP.Text != "")
            {
                RadGrid1.DataSource = f.ListaFacturacionEnc("", txtNombreOP.Text, fe, fe, 13);
                RadGrid1.DataBind();
            }
            txtOP.Text = "Funciona";
        }
        [System.Web.Services.WebMethod]
        public static string GetContactName(string OT)
        {
            string resultado = "";
            try
            {
                System.Diagnostics.Process.Start(@"file:///z:/Produccion/Ots/" + OT + ".pdf");
                resultado = "SI";
            }
            catch (Exception e)
            {
                string a = e.ToString();
                resultado = a;
            }
            return resultado;
        }

        protected void Save_Click(object sender, EventArgs e)
        {

        }

        protected void SaveClose_Click(object sender, EventArgs e)
        {

        }
    }
}