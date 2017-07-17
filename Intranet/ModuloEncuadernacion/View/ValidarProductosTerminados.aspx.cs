using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using System.Drawing;
using Telerik.Web.UI;
using Intranet.ModuloEncuadernacion.Model;
using System.Text;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class ValidarProductosTerminados : System.Web.UI.Page
    {
        Controller_ProductosTerminados cPT = new Controller_ProductosTerminados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
            txtCodigo.Focus();
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            List<Prod_Terminados> lisPT = new List<Prod_Terminados>();
            lisPT = cPT.BuscaPalletCerrado(txtCodigo.Text);

            RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
            RadGrid1.DataBind();

            if (lisPT.Count != 0)
            {

                DivMensaje.Visible = false;

            }
            else
            {

                //poner error qe no existe o fue cerrada
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "El Pallet no ha sido encontrado.";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void ibAprobar_Click1(object sender, ImageClickEventArgs e)
        {

            int contadorInsert = 0;
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    contadorInsert++;
                    Prod_Terminados asi = new Prod_Terminados();
                    asi.id_ProductosTerminados = row["id_ProductosTerminados"].Text;
                    asi.Estado = "2";
                    bool resp = cPT.CambiarEstado(Convert.ToInt32(asi.id_ProductosTerminados), asi.Estado);
                    list.Add(asi);
                }
            }
            //contador
            string contadorIns = contadorInsert.ToString();
            //llamada procedimiento

            //carga de gridviews

            RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
            RadGrid1.DataBind();
            //mensaje 
            //string popupScript = "<script language='JavaScript'> alert(' ¡Se ha Suscrito a " + contadorIns.ToString() + " OTs ! \\n\\n* Las OTs que no ha seleccionado, las puede encontrar en OTs sin Suscribir ');</script>";
            //Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void ibRechazar_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    contadorInsert++;
                    Prod_Terminados asi = new Prod_Terminados();
                    asi.id_ProductosTerminados = row["id_ProductosTerminados"].Text;
                    asi.Estado = "3";
                    bool resp = cPT.CambiarEstado(Convert.ToInt32(asi.id_ProductosTerminados), asi.Estado);
                    list.Add(asi);
                }
            }
            //contador
            string contadorIns = contadorInsert.ToString();
            //llamada procedimiento

            //carga de gridviews

            RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
            RadGrid1.DataBind();
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;

                //Session["nOT"] = item["NumeroOT"].Text;
                //string emp = item["NombreOT"].Text;

                string popupScript = "<script language='JavaScript'> onload(window.open('ModificarProductosTerminados.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            int validar = 0;
            if (txtCodigo.Text != "")
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    //if (isChecked)
                    //{

                    bool resp;
                    string id = row["id_ProductosTerminados"].Text;

                    string estado = row["Estado"].Text;

                    if (estado == "<div style='Color:Green;'>Aprobado</div>")
                    {

                        //cambiar a estado 4
                        //resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 4);
                    }
                    else if (estado == "<div style='Color:Blue;'>Pendiente</div>")
                    {
                        validar = validar + 1;

                        //cambia a estado 5
                        //resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 5);
                    }
                    else if (estado == "<div style='Color:Red;'>Rechazado</div>")
                    {
                        //cambia a estado 5
                        resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 5);
                    }


                    //}

                }

                if (validar == 0)
                {
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        GridDataItem row = RadGrid1.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        //if (isChecked)
                        //{

                        bool resp;
                        string id = row["id_ProductosTerminados"].Text;

                        string estado = row["Estado"].Text;

                        if (estado == "<div style='Color:Green;'>Aprobado</div>")
                        {

                            //cambiar a estado 4
                            resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 4);
                        }
                        else if (estado == "<div style='Color:Blue;'>Pendiente</div>")
                        {
                            validar = validar + 1;

                            //cambia a estado 5
                            resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 5);
                        }
                        else if (estado == "<div style='Color:Red;'>Rechazado</div>")
                        {
                            //cambia a estado 5
                            resp = cPT.CerrarPaso2(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 5);
                        }


                        //}

                    }

                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Registros Guardados Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green");
                    //cg
                    RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
                    RadGrid1.DataBind();

                    btnImprimir.Visible = true;

                    Session["Usuario"] = Session["Usuario"].ToString();
                    string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaAprobadaPT.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Debe Asignar Estado a las Guias!";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }




                //DivMensaje.Visible = true;
                //imgMensaje.ImageUrl = "../../Images/tick.png";
                //lblMensaje.Text = "Registros Guardados Correctamente.";
                //lblMensaje.ForeColor = Color.White;
                //DivMensaje.Attributes.Add("style", "background-color:Green");
                ////cg
                //RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
                //RadGrid1.DataBind();

                //btnImprimir.Visible = true;

                //Session["Usuario"] = Session["Usuario"].ToString();
                //string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaAprobadaPT.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
                //Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                //mal
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = Session["Usuario"].ToString();
            string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaAprobadaPT.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }
    }
}