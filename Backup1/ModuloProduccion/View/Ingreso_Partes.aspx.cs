using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System.Web.Script.Serialization;

namespace Intranet.ModuloProduccion.View
{
    public partial class Ingreso_Partes : System.Web.UI.Page
    {
        int count = 0;
        Controller_IngresoPartes ip = new Controller_IngresoPartes();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtHora.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtCodigo.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtOT.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtMinuto.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtBuenos.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtMalos.Attributes.Add("onkeypress", "return solonumeros(event);");
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                try
                {
                    lblUsuario.Text = Session["Usuario"].ToString();
                }
                catch
                {
                    lblUsuario.Text = "Sistema";
                }
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            //if (ddlMaquina.SelectedValue.ToString() != "Seleccione..." && txtFechaParte.Text != "" && txtCodigo.Text != "" && txtOT.Text != ""
            //    && txtHora.Text != "" && txtMinuto.Text != "" && txtBuenos.Text != "" && txtMalos.Text != "" && txtPliego.Text != "")
            //{


            //    PartesIngreso p = new PartesIngreso();
            //    string[] str = txtFechaParte.Text.Split('/');
            //    p.FechaInicio = str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
            //    if (RadGrid1.Items.Count > 0)
            //    {
            //        ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(p.FechaInicio));
            //        //  p.FechaTermino = Convert.ToDateTime(ip.FechaAnterior(Session["Usuario"].ToString(), 2)).ToString("MM/dd/yyyy HH:mm:ss");
            //    }

            //    p.FechaTermino = "1900-01-01";



            //    #region Variables inserT
            //    p.Count = count.ToString();
            //    p.Maquina = ddlMaquina.SelectedValue.ToString();
            //    if (rdTurno.Checked == true)
            //    {
            //        p.Turno = rdTurno.Text;
            //    }
            //    else if (rdTurno2.Checked == true)
            //    {
            //        p.Turno = rdTurno2.Text;
            //    }
            //    else
            //    {
            //        p.Turno = rdTurno3.Text;
            //    }
            //    p.Codigo = txtCodigo.Text;
            //    p.OT = txtOT.Text;
            //    p.NombreOT = "";

            //    p.FechaParte = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

            //    p.Buenos = txtBuenos.Text;
            //    p.Malos = txtMalos.Text;
                //p.Usuario = Session["Usuario"].ToString();
                //p.Pliego = txtPliego.Text;
                //p.Factor = txtFactor.Text;
                //#endregion
                //if (ddlMaquina.SelectedValue.ToString() == "C150")
                //{
                //    if (txtFactor.Text != "")
                //    {
                //        if (ip.IngresarDetalleParte(p, 0) == 0)
                //        {
                //            btnFiltro.Text = "ERROR";
                //        }
                //        else
                //        {
            //                RadGrid1.DataSource = ip.Lista_Detalle(p, 1);
            //                RadGrid1.DataBind();
            //            }

            //            Limpiar();
            //            txtCodigo.Focus();
            //        }
            //        else
            //        {
            //            string popupScript = "<script language='JavaScript'> alert(' Debe ingresar el Factor ');</script>";
            //            Page.RegisterStartupScript("PopupScript", popupScript);
            //        }
            //    }
            //    else
            //    {
            //        if (ip.IngresarDetalleParte(p, 0) == 0)
            //        {
            //            btnFiltro.Text = "ERROR";

            //        }
            //        else
            //        {
            //            RadGrid1.DataSource = ip.Lista_Detalle(p, 1);
            //            RadGrid1.DataBind();
            //        }
            //        Limpiar();
            //        txtCodigo.Focus();
            //        //string popupScript = "<script language='JavaScript'> alert(' Debe ingresar el Factor ');</script>";
            //        //Page.RegisterStartupScript("PopupScript", popupScript);
            //    }
            //}
            //else
            //{
            //    string popupScript = "<script language='JavaScript'> alert(' Debe ingresar todos los campos ');</script>";
            //    Page.RegisterStartupScript("PopupScript", popupScript);
            //}
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            string fec = "";
            string fecha = "";
            if (RadGrid1.Items.Count > 0)
            {
                string[] str23 = txtFechaParte.Text.Split('/');
                // str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
                if (Convert.ToDateTime(str23[1] + "/" + str23[0] + "/" + str23[2]).DayOfWeek.ToString() == "Monday")
                {
                    if (rdTurno.Checked)
                    {
                        fec = "14:00:00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        fec = "19:00:00";
                    }
                    else
                    {
                        fec = "23:59:59";
                    }
                    string[] str = txtFechaParte.Text.Split('/');
                    fecha = str[1] + "/" + str[0] + "/" + str[2] + " " + fec;

                    ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(fecha));
                    bool a = ip.CambiaEstado(Session["Usuario"].ToString());
                    if (a == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Parte Ingresado Correctamente ');location.href='IngresoPartes.aspx?id=1' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {

                    if (rdTurno.Checked)
                    {
                        fec = "08:00:00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        fec = "16:00:00";
                    }
                    else
                    {
                        fec = "23:59:59";
                    }
                    string[] str = txtFechaParte.Text.Split('/');
                    fecha = str[1] + "/" + str[0] + "/" + str[2] + " " + fec;

                    ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(fecha));
                    bool a = ip.CambiaEstado(Session["Usuario"].ToString());
                    if (a == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Parte Ingresado Correctamente ');location.href='IngresoPartes.aspx?id=1' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
            }
        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
    //        if (ddlMaquina.SelectedValue.ToString() != "Seleccione..." && txtFechaParte.Text != "" && txtCodigo.Text != "" && lblCodigo.Text != "" && txtOT.Text != ""
    //&& lblNombreOT.Text != "" && txtHora.Text != "" && txtMinuto.Text != "" && txtBuenos.Text != "" && txtMalos.Text != "" && txtPliego.Text != "")
    //        {
    //            PartesIngreso p = new PartesIngreso();
    //            string[] str = txtFechaParte.Text.Split('/');
    //            p.FechaInicio = str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
    //            p.idParte = Request.QueryString["idP"];
    //            p.Maquina = ddlMaquina.SelectedValue.ToString();
    //            if (rdTurno.Checked == true)
    //            {
    //                p.Turno = rdTurno.Text;
    //            }
    //            else if (rdTurno.Checked == true)
    //            {
    //                p.Turno = rdTurno2.Text;
    //            }
    //            else
    //            {
    //                p.Turno = rdTurno3.Text;
    //            }
    //            p.Codigo = txtCodigo.Text;
    //            p.OT = txtOT.Text;


    //            p.FechaParte = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

    //            p.Buenos = txtBuenos.Text;
    //            p.Malos = txtMalos.Text;
    //            p.Pliego = txtPliego.Text;
    //            p.Factor = txtFactor.Text;

    //            bool a = ip.ModificarRegistros(p);
    //            if (a == true)
    //            {
    //                btnFiltro.Visible = true;
    //                btnModificar.Visible = false;
    //                RadGrid1.DataSource = ip.Lista_DetalleModi(Session["Usuario"].ToString(), 2);
    //                RadGrid1.DataBind();
    //                Limpiar();

    //            }
    //        }
        }



        [WebMethod]
        public static string[] BuscaCodigo(string Codigo)
        {
            try
            { 
                Controller_IngresoPartes ip = new Controller_IngresoPartes();
                PartesIngreso pi  = ip.Carga_CodigoParte_V2(Codigo);

                if (pi == null)
                {
                    return new[] { "Codigo Incorrecto","" };
                }
                else
                {
                    return new[] { pi.Codigo, pi.Malos };
                }
            }
            catch
            {
                return new[] { "Codigo Incorrecto", "" };
            }
        }
        [WebMethod]
        public static string[] BuscaOT(string OT)
        {
            try
            {
                string Resultado = "";
                Controller_IngresoPartes ip = new Controller_IngresoPartes();
                Resultado = ip.Carga_NombreOT(OT);
                if (Resultado == "")
                {
                    return new[] { "OT Incorrecta" };
                }
                else
                {
                    return new[] { Resultado };
                }
            }
            catch
            {
                return new[] { "OT Incorrecta" };
            }
        }
        [WebMethod]
        public static string CargaPliego(string OT)
        {
            Controller_IngresoPartes c = new Controller_IngresoPartes();
            List<PartesIngreso> lista = c.CargaPliegos(OT, 0);
            List<PartesIngreso> lista2 = new List<PartesIngreso>();

            int contador = 1;
            PartesIngreso insert1 = new PartesIngreso();
            insert1.Pliego = "Seleccione...";
            lista2.Insert(0, insert1);
            foreach (PartesIngreso ps in lista)
            {
                PartesIngreso objst = new PartesIngreso();
                //objst.Componente = ps.Componente;
                objst.Pliego = ps.Pliego;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] IngresarParte(string Maquina,string FechaParte,string Turno,string Codigo,string OT,string NombreOT,string Pliego,
            string Hora,string Minutos,string Buenos,string Malos,string IngresaCantidad,string Factor,string Usuario)
        {
            try
            {
                if (Maquina == "" || FechaParte == "" || Codigo == "" || OT == "" || Pliego == "Seleccione..." || Hora == "" || Minutos == "" || Buenos == "" || Malos == "" || IngresaCantidad == "" || Usuario == "")
                {
                    return new[] { "Debe ingresar Todos los campos" };
                }
                else
                {
                    Controller_IngresoPartes c = new Controller_IngresoPartes();
                    PartesIngreso p = new PartesIngreso();
                    p.Maquina = Maquina;
                    string[] str2 = FechaParte.Split('/');
                    p.FechaParte = str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00";
                    p.Turno = Turno;
                    p.Codigo = Codigo;
                    p.OT = OT;
                    p.NombreOT = NombreOT;
                    p.Pliego = Pliego;
                    string[] str = FechaParte.Split('/');
                    p.FechaInicio = str[1] + "/" + str[0] + "/" + str[2] + " " + Hora + ":" + Minutos + ":00";
                    p.Buenos = Buenos;
                    p.Malos = Malos;
                    p.Usuario = Usuario;
                    p.Factor = Factor;
                    if (c.IngresarDetalleParte_V2(p, 0) > 0)
                    {
                        return new[] { "Registro Ingresado Correctamente" };
                    }
                    else
                    {
                        return new[] { "Ha ocurrido un Error al ingresar" };
                    }
                }
            }
            catch
            {
                return new[] { "OT Incorrecta" };
            }
        }

    }
}