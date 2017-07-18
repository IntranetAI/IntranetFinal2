using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class LiquidarOT : System.Web.UI.Page
    {
        Controller_EstadoOT eo = new Controller_EstadoOT();
        int Estado = 0;
        bool respuesta = true;
        bool resp = true;
        bool re = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tblRegistro.Visible = false;
            }

            try
            {
                string var = Request.QueryString["va"];
                if (var != null)
                {
                    txtOT.Text = Request.QueryString["va"];
                    CargaRegistros();

                }
            }
            catch
            {
            }
        }

        public void CargaRegistros()
        {

                tblRegistro.Visible = true;

                Estado_OT et = eo.BuscarOTLiquidar(txtOT.Text, 1);
                btnFiltro.Enabled = false;
                txtOT.Enabled = false;
                //txtOT.Text = et.OT.ToUpper();
                lblNombreOT.Text = et.NombreOT;
                lblCliente.Text = et.Cliente;
                int ti = Convert.ToInt32(et.TirajeTotal);
                lblTiraje.Text = ti.ToString("N0").Replace(",", ".");

                if (et.Estado == "1")
                {
                    lblEstadoActual.ForeColor = Color.Blue;
                    lblEstadoActual.Text = "En Proceso.";
                }
                else if(et.Estado=="A")
                {
                    lblEstadoActual.ForeColor = Color.Blue;
                    lblEstadoActual.Text = "En Proceso.";
                }
                else if (et.Estado == "E")
                {
                    lblEstadoActual.ForeColor = Color.Red;
                    lblEstadoActual.Text = "Liquidada.";
                }
                else
                {
                    lblEstadoActual.ForeColor = Color.Red;
                    lblEstadoActual.Text = "Liquidada.";                
                }





                if (et.FechaMaxima != "")
                {
                    DateTime fc = Convert.ToDateTime(et.FechaMaxima);
                    lblFechaLiquidacion.Text = fc.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    lblFechaLiquidacion.Text = "Sin Fecha de Liquidacion";
                }

                //datos adicionales
                int devolucion = Convert.ToInt32(et.Devolucion);
                DateTime fmin = Convert.ToDateTime(et.OT);
                DateTime fmax = Convert.ToDateTime(et.Saldo);
                int totalDesp = Convert.ToInt32(et.TotalDespachado);

                lblDespachado.Text = totalDesp.ToString("N0").Replace(",", ".");
                lblPrimerDesp.Text = fmin.ToString("dd/MM/yyyy HH:mm:ss");
                lblUltDesp.Text = fmax.ToString("dd/MM/yyyy HH:mm:ss");
                lblDevolucion.Text = devolucion.ToString("N0").Replace(",", ".");

                int saldo = (ti - (totalDesp - devolucion));
                if (saldo <= 0)
                {
                    lblFaltante.Text = "0";
                }
                else
                {
                    lblFaltante.Text = saldo.ToString("N0").Replace(",", ".");

                }

        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                CargaRegistros();

            }
            else
            {
                //mensaje error
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (ddlEstado.SelectedValue.ToString() != "Seleccione...")
            {
                if (ddlEstado.SelectedValue.ToString() == "Liquidar")
                {
                    Estado = 2;
                }
                else
                {
                    Estado = 1;
                }

                if (lblEstadoActual.Text != "Liquidada." || ddlEstado.SelectedValue.ToString()!="Liquidar")
                {
                    //respuesta = eo.CambiarEstadoOT(txtOT.Text, Estado);
                    if (ddlEstado.SelectedValue.ToString() == "En Proceso")
                    {
                        if (txtObservacion.Text != "")
                        {
                            respuesta = eo.CambiarEstadoOT(txtOT.Text, Estado);
                            resp = eo.CambiarEstadoOT_Local(txtOT.Text, Estado);
                            re = eo.Historial_Liquidadas(txtOT.Text.ToUpper(), lblNombreOT.Text, lblCliente.Text, Convert.ToInt32(lblTiraje.Text.Replace(".", "")), Estado, txtObservacion.Text, Session["Usuario"].ToString());
                            //bool r=
                            if (respuesta == true)
                            {
                                DivMensaje.Visible = true;
                                imgMensaje.ImageUrl = "../../Images/tick.png";
                                lblMensaje.Text = "Se ha Cambiado el Estado Correctamente.";
                                lblMensaje.ForeColor = Color.White;
                                DivMensaje.Attributes.Add("style", "background-color:Green");

                                btnGuardar.Enabled = false;
                            }
                            else
                            {
                                DivMensaje.Visible = true;
                                imgMensaje.ImageUrl = "../../Images/cross.png";
                                lblMensaje.Text = "Ha Ocurrido un Error Vuelva a Intentarlo.";
                                lblMensaje.ForeColor = Color.White;
                                DivMensaje.Attributes.Add("style", "background-color:Red");
                            }
                        }
                        else
                        {
                            DivMensaje.Visible = true;
                            imgMensaje.ImageUrl = "../../Images/cross.png";
                            lblMensaje.Text = "Para cambiar una OT en Proceso, el campo Observacion es Obligatorio.";
                            lblMensaje.ForeColor = Color.White;
                            DivMensaje.Attributes.Add("style", "background-color:Red");
                        }
                    }
                    else
                    {
                        respuesta = eo.CambiarEstadoOT(txtOT.Text, Estado);
                        resp = eo.CambiarEstadoOT_Local(txtOT.Text, Estado);
                        re = eo.Historial_Liquidadas(txtOT.Text, lblNombreOT.Text, lblCliente.Text, Convert.ToInt32(lblTiraje.Text.Replace(".", "")), Estado, txtObservacion.Text, Session["Usuario"].ToString());
                        if (respuesta == true)
                        {
                            DivMensaje.Visible = true;
                            imgMensaje.ImageUrl = "../../Images/tick.png";
                            lblMensaje.Text = "Se ha Cambiado el Estado Correctamente.";
                            lblMensaje.ForeColor = Color.White;
                            DivMensaje.Attributes.Add("style", "background-color:Green");

                            btnGuardar.Enabled = false;
                        }
                        else
                        {
                            DivMensaje.Visible = true;
                            imgMensaje.ImageUrl = "../../Images/cross.png";
                            lblMensaje.Text = "Ha Ocurrido un Error Vuelva a Intentarlo.";
                            lblMensaje.ForeColor = Color.White;
                            DivMensaje.Attributes.Add("style", "background-color:Red");
                        }



                    }




                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "La OT ya esta Liquidada.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }

                
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiquidarOT.aspx?id=8&Cat=6");
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}