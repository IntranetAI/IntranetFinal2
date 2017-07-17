using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloProduccion.View
{
    public partial class EstadoOT : System.Web.UI.Page
    {
        OrdenController controlOT = new OrdenController();
        public static List<Orden> lista = new List<Orden>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
                Session["Usuario"] = Session["Usuario"].ToString();
            }

        }
        public void CargarGrilla()
        {
            string fec = "1900-01-01";
           string Usuario = Session["Usuario"].ToString();
            lista = controlOT.ListarEstadoOT_Mejora("", "", "", Convert.ToDateTime(fec), Convert.ToDateTime(fec), 0, Usuario, 0);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
        }
        
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string OT = txtNumeroOT.Text;
            string Nombre = txtNombreOT.Text;
            string Cliente = txtCliente.Text;
            string FInicio = txtFechaInicio.Text;
            DateTime fec = Convert.ToDateTime("1900-01-01");
            string FTermino = txtFechaTermino.Text;
            string Usu = Session["Usuario"].ToString();
            int Estado = Convert.ToInt32(ddlEstado.SelectedValue);
            DivImprimir.Visible = false;
            RadGrid1.Columns[8].HeaderText = "Fecha Entrega";
            // 0 todos, 1 enproceso,2 liquidada, 3 mensajes

                if (Estado == 0)
                {   //Todos los estados con fecha
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        string[] str = FInicio.Split('/');
                        DateTime fIni = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = FTermino.Split('/');
                        DateTime fTer = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fIni, fTer, 0, Usu, 1);
                        RadGrid1.DataBind();
                    }
                    else
                    {//  Todos los estados sin fecha
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fec, fec, 0, Usu, 2);
                        RadGrid1.DataBind();
                    }

                }
                else if (Estado == 1 || Estado == 2)
                {//Estados 
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {//Estados con fecha
                        string[] str = FInicio.Split('/');
                        DateTime fIni = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = FTermino.Split('/');
                        DateTime fTer = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");


                        RadGrid1.Columns[8].HeaderText = "Fecha Liquidación";
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fIni, fTer, Estado, Usu, 7);

                        //estado 7
                        RadGrid1.DataBind();
                    }
                    else
                    {//Estados sin fecha++

                        //estado 8
                        RadGrid1.Columns[8].HeaderText = "Fecha Liquidación";
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fec, fec, Estado, Usu, 8);
                        RadGrid1.DataBind();
                        //tenemos que modificar
                    }
                }
                else if (Estado == 3)
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        string[] str = FInicio.Split('/');
                        DateTime fIni = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = FTermino.Split('/');
                        DateTime fTer = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fIni, fTer, Estado, Usu, 5);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fec, fec, Estado, Usu, 6);
                        RadGrid1.DataBind();
                    }
                }
                else if (Estado == 4)
                {
                    DivImprimir.Visible = true;
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        string[] str = FInicio.Split('/');
                        DateTime fIni = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = FTermino.Split('/');
                        DateTime fTer = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fIni, fTer, Estado, Usu, 11);
                        RadGrid1.DataBind();
                    }
                    else
                    {

                        RadGrid1.DataSource = controlOT.ListarEstadoOT_Mejora(OT, Nombre, Cliente, fec, fec, Estado, Usu, 9);
                        RadGrid1.DataBind();
                    }



                }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Envio();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Envio();
        }
        public void Envio()
        {
            string fechaI= "";
            string fechaT = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                fechaI = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";
                string[] str2 = txtFechaTermino.Text.Split('/');
                fechaT = str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59";
            }
            else
            {
                fechaI = "SinFecha";
                fechaT = "SinFecha";
            }
            string popupScript = "<script language='JavaScript'>openMensajes(\"" + Session["Usuario"].ToString() + "\",\"" + fechaI + "\",\"" + fechaT + "\");</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}