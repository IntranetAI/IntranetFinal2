using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using System.Drawing;
using Telerik.Web.UI;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class Devolucion_General : System.Web.UI.Page
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
            RadGrid1.DataSource = des.ListarGuias(ot);
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

            lblRestante.Text = des.MaxRecepciones(txtOT.Text, 1);
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

        protected void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            RadGrid1.Visible = true;
            lblGuias.Visible = true;

            RadGrid3.Visible = false;
            lblCantGuia.Visible = false;
            lblIngreseGuias.Visible = false;
            txtCantidadGuia.Visible = false;
            txtNroGuia.Visible = false;
            btnAgregarGuia.Visible = false;
            lblNroGuia.Visible = false;
        }

        protected void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            //divGrillaGuias.Visible = false;
            lblGuias.Visible = false;

            lblGuias.Visible = false;
            lblIngreseGuias.Visible = true;

            RadGrid3.Visible = true;
            RadGrid1.Visible = false;
            lblCantGuia.Visible = true;
            lblIngreseGuias.Visible = true;
            txtCantidadGuia.Visible = true;
            txtNroGuia.Visible = true;
            btnAgregarGuia.Visible = true;
            lblNroGuia.Visible = true;

            RadGrid3.DataSource = "";
            RadGrid3.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ddlTipoEmbalaje.SelectedValue.ToString() != "Seleccione..." && txtCantidad.Text != "")
            {
                if ((Convert.ToInt32(lblRestante.Text) - Convert.ToInt32(txtCantidad.Text)) >= 0)
                {
                    respuesta = des.insertTipoDev(Convert.ToInt32(idDev.Text), txtOT.Text, ddlTipoEmbalaje.SelectedValue.ToString(), Convert.ToInt32(txtCantidad.Text), 3);
                    if (respuesta == true)
                    {
                        //actualizar grilla

                        RadGrid2.DataSource = des.ListaTipos(Convert.ToInt32(idDev.Text));
                        RadGrid2.DataBind();
                        //totalDevuelto = totalDevuelto + Convert.ToInt32(txtCantidad.Text);
                        lblMensaje.Text = "";

                        lblRestante.Text = des.MaxRecepciones(txtOT.Text, 1);

                        btnAgregar.Enabled = false;

                    }
                    else
                    {
                        //error o algo
                    }
                }
                else
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "La cantidad recepcionada no puede ser mayor a 'Maximo a recepcionar'.";
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
                            string sucur = row["Sucursal"].Text;
                            string a = row["Despachado"].Text.Replace(".", "");
                            int cant = Convert.ToInt32(a);
                            DateTime fd = DateTime.Now;

                            if (coun == 0)
                            {

                                bool re = des.insertGuias(id, nguias, sucur, cant, fd);
                                //asi.NumeroOT = row["NumeroOT"].Text;
                                if (re == true)
                                {
                                    coun = coun + 1;
                                }
                            }
                        }

                    }
                    if (coun > 0)
                    {
                        #region generaCodigo
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

                        #endregion


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
                                    btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + folio + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");

                                    lblMensaje.ForeColor = Color.Green;
                                    lblMensaje.Text = "Devolucion desde Cliente, Creada correctamente." + folio;
                                }
                                else
                                {

                                    //eliminar los datos ingresados
                                }
                            }
                            else
                            {
                                lblMensaje.ForeColor = Color.Red;
                                lblMensaje.Text = "El Campo Observacion es Obligatorio";
                            }

                        }
                        else
                        {
                            lblMensaje.ForeColor = Color.Red;
                            lblMensaje.Text = "Debe ingresar las cantidad y tipo de embalaje a recepcionar.";
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "Debe seleccionar una guia de despacho";
                    }
                }
                else if (RadGrid2.Visible == true)
                {
                    if (RadGrid3.Items.Count > 0)
                    {
                        #region generaCodigo
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

                        #endregion


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
                                    int ccc = 0;
                                    for (int i = 0; i < RadGrid3.Items.Count; i++)
                                    {
                                        if (ccc == 0)
                                        {
                                            //  totalDevuelto = totalDevuelto + Convert.ToInt32(RadGrid2.Items[i]["Cantidad"].Text);
                                            bool rr = des.GuiasCliente(Convert.ToInt32(idDev.Text), RadGrid3.Items[i]["guia"].Text, Convert.ToInt32(RadGrid3.Items[i]["Despachado"].Text.Replace(".", "").Replace(",", "")), 0);
                                            ccc = ccc + 1;
                                        }
                                    }

                                    btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + folio + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");

                                    lblMensaje.ForeColor = Color.Green;
                                    lblMensaje.Text = "Devolucion desde Cliente, Creada correctamente. " + folio;
                                }
                                else
                                {

                                    //eliminar los datos ingresados
                                }
                            }
                            else
                            {
                                lblMensaje.ForeColor = Color.Red;
                                lblMensaje.Text = "El Campo Observacion es Obligatorio";
                            }

                        }
                        else
                        {
                            lblMensaje.ForeColor = Color.Red;
                            lblMensaje.Text = "Debe ingresar las cantidad y tipo de embalaje a recepcionar.";
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "Debe crear una guia de despacho";
                    }
                }
                else
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "ha ocurrido un erro. Vuelva a intentarlo.";
                }
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar una OT, vuelva a intentarlo.";
            }
            //int coun = 0;
            //if (txtOT.Text != "")
            //{
            //    if (RadGrid1.Visible == true)
            //    {

            //        for (int i = 0; i < RadGrid1.Items.Count; i++)
            //        {
            //            GridDataItem row = RadGrid1.Items[i];
            //            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            //            if (isChecked)
            //            {
            //                int id = Convert.ToInt32(idDev.Text);
            //                string nguias = row["guia"].Text;
            //                string sucur = row["Sucursal"].Text;
            //                string a = row["Despachado"].Text.Replace(".", "");
            //                int cant = Convert.ToInt32(a);
            //                DateTime fd = DateTime.Now;

            //                if (coun == 0)
            //                {

            //                    bool re = des.insertGuias(id, nguias, sucur, cant, fd);
            //                    //asi.NumeroOT = row["NumeroOT"].Text;
            //                    if (re == true)
            //                    {
            //                        coun = coun + 1;
            //                    }
            //                }
            //            }

            //        }
            //    }
            //    int id2 = Convert.ToInt32(idDev.Text);

            //    string f = des.GenerarFolio();

            //    int n = Convert.ToInt32(f.Replace("DE-", "")) + 1;
            //    string v = "";
            //    if (n.ToString().Length == 1)
            //    {
            //        v = "DE-00000" + n.ToString();
            //    }
            //    else if (n.ToString().Length == 2)
            //    {
            //        v = "DE-0000" + n.ToString();
            //    }
            //    else if (n.ToString().Length == 3)
            //    {
            //        v = "DE-000" + n.ToString();
            //    }
            //    else if (n.ToString().Length == 4)
            //    {
            //        v = "DE-00" + n.ToString();
            //    }
            //    else if (n.ToString().Length == 5)
            //    {
            //        v = "DE-0" + n.ToString();
            //    }




            //    folio = v;


            //    if (RadGrid2.Items.Count > 0)
            //    {
            //        if (txtComentario.Text != "")
            //        {
            //            int totalDevuelto = 0;
            //            for (int i = 0; i < RadGrid2.Items.Count; i++)
            //            {
            //                totalDevuelto = totalDevuelto + Convert.ToInt32(RadGrid2.Items[i]["Cantidad"].Text);
            //            }


            //            bool res2 = des.insertCliente(id2, id2, folio, txtOT.Text, Convert.ToInt32(lblTirajeOT.Text), txtCliente.Text, txtProducto.Text, ddlCausa.SelectedValue.ToString(), txtComentario.Text, totalDevuelto, Session["Usuario"].ToString());

            //            if (res2 == true)
            //            {
            //                btnGuardarDev.Enabled = false;
            //                btnImprimir.Visible = true;
            //                btnNuevo.Visible = true;
            //                // btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + folio + ",'Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
            //                btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + folio + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");

            //                lblMensaje.ForeColor = Color.Green;
            //                lblMensaje.Text = "Devolucion desde Cliente, recepcionada correctamente.";
            //            }
            //            else
            //            {

            //                //eliminar los datos ingresados
            //            }
            //        }
            //        else
            //        {
            //            lblMensaje.ForeColor = Color.Red;
            //            lblMensaje.Text = "El Campo Observacion es Obligatorio";
            //        }

            //    }
            //    else
            //    {
            //        lblMensaje.ForeColor = Color.Red;
            //        lblMensaje.Text = "Debe ingresar las cantidad y tipo de embalaje a recepcionar.";
            //    }
            //}
            //else
            //{
            //    lblMensaje.ForeColor = Color.Red;
            //    lblMensaje.Text = "No se ha encontrado la OT, vuelva a intentarlo.";
            //}
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Devolucion_General.aspx?id=8&Cat=6");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarGuia_Click(object sender, EventArgs e)
        {
            int coun = 0;
            if (txtNroGuia.Text != "" && txtCantidadGuia.Text != "")
            {
                if (coun == 0)
                {
                    List<Devoluciones> l = new List<Devoluciones>();
                    Devoluciones des = new Devoluciones();
                    des.guia = txtNroGuia.Text;
                    des.sucursal = "Guia Del Cliente";
                    des.despachado = txtCantidadGuia.Text;
                    des.FechaDespacho = "";

                    l.Add(des);


                    RadGrid3.Visible = true;
                    RadGrid3.DataSource = l;
                    RadGrid3.DataBind();

                    coun = coun + 1;
                    //bool rr = des.GuiasCliente(Convert.ToInt32(idDev.Text), txtNroGuia.Text, Convert.ToInt32(txtCantidadGuia.Text), 0);
                    //if (rr == true)
                    //{
                    //    RadGrid3.Visible = true;
                    //    RadGrid3.DataSource = des.ListarGuiasCliente(Convert.ToInt32(idDev.Text), "", 0, 1);
                    //    RadGrid3.DataBind();

                    //    coun = coun + 1;
                    //}
                    btnAgregarGuia.Enabled = false;
                }
            }
        }

    }
}