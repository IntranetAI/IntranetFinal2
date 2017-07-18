using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using Telerik.Web.UI;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class DevolucionInterna : System.Web.UI.Page
    {
        bool respuesta;
        public static string folio = "";
        Controller_Devoluciones des = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                RadGrid2.DataSource = "";
                RadGrid2.DataBind();

                string va = des.idTipoDev();
                int n = Convert.ToInt32(va) + 1;
                idDev.Text = n.ToString();
            }
        }
        public void cargarGrid(string ot)
        {
            RadGrid1.DataSource = des.DevolucionInterna(ot);
            RadGrid1.DataBind();
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            Devoluciones list = des.Cliente_Producto(txtOT.Text);
            txtCliente.Text = list.sucursal;
            txtProducto.Text = list.guia;
            lblTirajeOT.Text = list.TirajeOT;


            cargarGrid(txtOT.Text);

            btnAgregar.Enabled = true;

            //cargar recepciones realizadas
            string valor = des.MaxRecepciones(txtOT.Text, 0);
            lblRestantes.Text = valor;

        }

        protected void ddlCausa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCausa.SelectedValue.ToString() == "Otros")
            {
                lblObservacion.Visible = true;
                txtComentario.Visible = true;
            }
            else
            {
                lblObservacion.Visible = true;
                txtComentario.Visible = true;
            }
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ddlTipoEmbalaje.SelectedValue.ToString() != "Seleccione..." && txtCantidad.Text != "")
            {
                if ((Convert.ToInt32(lblRestantes.Text) - Convert.ToInt32(txtCantidad.Text)) >= 0)
                {



                    respuesta = des.insertTipoDev(Convert.ToInt32(idDev.Text), txtOT.Text, ddlTipoEmbalaje.SelectedValue.ToString(), Convert.ToInt32(txtCantidad.Text),1);
                    if (respuesta == true)
                    {
                        //actualizar grilla

                        RadGrid2.DataSource = des.ListaTipos(Convert.ToInt32(idDev.Text));
                        RadGrid2.DataBind();
                        //totalDevuelto = totalDevuelto + Convert.ToInt32(txtCantidad.Text);
                        divMensaje.Visible = false;

                        string valor = des.MaxRecepciones(txtOT.Text, 0);
                        lblRestantes.Text = valor;

                        btnAgregar.Enabled = false;
                    }
                    else
                    {
                        //error o algo
                    }
                }
                else
                {
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "La cantidad a Devolver no puede ser mayor a 'Maximo a Devolver'.";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
        }

        protected void btnGuardarDev_Click(object sender, EventArgs e)
        {
            int coun = 0;
            if (txtOT.Text != "")
            {
                if (RadGrid1.Visible == true)
                {

                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        GridDataItem row = RadGrid1.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        if (isChecked)
                        {
                           
                            int id = Convert.ToInt32(idDev.Text);
                            string nguias = row["guia"].Text;
                            string sucur = "Devolucion Interna";
                            string a = row["Despachado"].Text.Replace(".", "");
                            int cant = Convert.ToInt32(a);
                            DateTime fd = DateTime.Now;

                            //ingreso solo una Guia de despacho (limite necesario)
                            if (coun == 0)
                            {
                                bool re = des.insertGuias(id, nguias, sucur, cant, fd);
                                if (re == true)
                                {
                                    coun = coun + 1;
                                }
                            }

                        }

                    }
                }
                if (coun != 0)
                {
                    int id2 = Convert.ToInt32(idDev.Text);

                    string f = des.GenerarFolio();

                    int n = Convert.ToInt32(f.Replace("DE-", "")) + 1;
                    string v = "";
                    if (n.ToString().Length == 1)
                    {
                        v = "DE-00000" + n.ToString();
                    }
                    else if (n.ToString().Length == 2)
                    {
                        v = "DE-0000" + n.ToString();
                    }
                    else if (n.ToString().Length == 3)
                    {
                        v = "DE-000" + n.ToString();
                    }
                    else if (n.ToString().Length == 4)
                    {
                        v = "DE-00" + n.ToString();
                    }
                    else if (n.ToString().Length == 5)
                    {
                        v = "DE-0" + n.ToString();
                    }




                    folio = v;


                    if (RadGrid2.Items.Count > 0)
                    {

                        if (txtComentario.Text != "")
                        {
                            int totalDevuelto = 0;
                            for (int i = 0; i < RadGrid2.Items.Count; i++)
                            {
                                totalDevuelto = totalDevuelto + Convert.ToInt32(RadGrid2.Items[i]["Cantidad"].Text);

                            }



                            bool res2 = des.insertCliente(id2, id2, folio, txtOT.Text, Convert.ToInt32(lblTirajeOT.Text), txtCliente.Text, txtProducto.Text, ddlCausa.SelectedValue.ToString(), txtComentario.Text, totalDevuelto, Session["Usuario"].ToString());

                            if (res2 == true)
                            {
                                btnGuardarDev.Enabled = false;
                                btnImprimir.Visible = true;
                                btnNuevo.Visible = true;
                                // btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + folio + ",'Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
                                btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucionInterna.aspx?Cod=" + folio + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");


                                divMensaje.Visible = true;
                                imgMensaje.ImageUrl = "../../Images/tick.png";
                                lblMensaje.Text = "Devolución Generada Correctamente con el Folio " + folio + ".";
                                lblMensaje.ForeColor = Color.White;
                                divMensaje.Attributes.Add("style", "background-color:Green");

                            }
                            else
                            {
                                //eliminar los datos ingresados
                            }
                        }
                        else
                        {
                            divMensaje.Visible = true;
                            imgMensaje.ImageUrl = "../../Images/cross.png";
                            lblMensaje.Text = "El Campo Observacion es Obligatorio.";
                            lblMensaje.ForeColor = Color.White;
                            divMensaje.Attributes.Add("style", "background-color:Red");
                        }
                    }
                    else
                    {
                        divMensaje.Visible = true;
                        imgMensaje.ImageUrl = "../../Images/cross.png";
                        lblMensaje.Text = "Debe Ingresar la cantidad y tipo de embalaje de la Devolucion.";
                        lblMensaje.ForeColor = Color.White;
                        divMensaje.Attributes.Add("style", "background-color:Red");

                    }
                    //}
                    //

                    

                }
                else
                {
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Debe Seleccionar guia(s) para generar la devolución.";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
            else
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "Debe Ingresar la OT para la Devolucion.";
                lblMensaje.ForeColor = Color.White;
                divMensaje.Attributes.Add("style", "background-color:Red");
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("DevolucionInterna.aspx?id=8&Cat=6");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }


    }
}