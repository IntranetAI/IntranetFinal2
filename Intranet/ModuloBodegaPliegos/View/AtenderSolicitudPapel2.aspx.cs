using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;
using Telerik.Web.UI;  
using System.Web.Services;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AtenderSolicitudPapel2 : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        Controller_Reserva cr = new Controller_Reserva();
        protected void Page_Load(object sender, EventArgs e)
        {

            txtAncho.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtLargo.Attributes.Add("onkeypress", "return solonumeros(event);");

            try
            {
                if (Request.QueryString["p"] == "1")
                {
                }
                else
                {
                    bool x = bp.ElimanarAsignacion(0, Request.QueryString["usuario"], 3);
                }
            }
            catch
            {
            }

            if (!IsPostBack)
            {

                lblTitulo.Text = "Atender Solicitud PreID ";
                lblPreID.Text = bp.PREID("", "", "", 0, "", "", 0, 0, 0, "", 0, "", "", 3,0).ToString();
                string Papel = "";
                DateTime f = DateTime.Now;
                BodegaPliegos d = bp.BuscaOTComponente(Request.QueryString["ot"], Request.QueryString["comp"], "", "", f, f, 0, 4);
                lblOT.Text = d.OT;
                lblNombreOT.Text = d.NombreOT.ToUpper();
                lblComponente.Text = d.Componente;
                lblFormatoPapel.Text = d.FormatoPapel;
                lblFechaCreacion.Text = d.FechaCreacion;
                lblCliente.Text = d.Cliente;
                lblCodigoProducto.Text = d.CodigoProducto;
                lblPapel.Text = d.Papel.ToUpper();
                lblGramaje.Text = d.Gramaje;
                lblAncho.Text = d.Ancho;
                lblLargo.Text = d.Largo;

                txtAncho.Text = d.Ancho;
                txtLargo.Text = d.Largo;


                if (d.Papel.Contains("PEFC"))
                {
                    lblCertificacion.Text = "SI";
                    lblTipoCertificacion.Text = "PEFC";
                }
                else
                {
                    lblCertificacion.Text = "NO";
                    lblTipoCertificacion.Text = "-";
                }

                #region papel
                if (d.Papel.Contains("Bond Blanco"))
                {
                    Papel = "bond blanco";
                }
                else if (d.Papel.Contains("Bond Crema"))
                {
                    Papel = "bond crema";
                }
                else if (d.Papel.Contains("Bond Ahuesado"))
                {
                    Papel = "bond ahuesado";
                }
                else if (d.Papel.Contains("Cartulina"))
                {
                    Papel = "cartulina";
                }
                else if (d.Papel.Contains("Couche Brillante"))
                {
                    Papel = "couche brillante";
                }
                else if (d.Papel.Contains("Couche Op"))
                {
                    Papel = "couche op";
                }
                else if (d.Papel.Contains("diario hibrite"))
                {
                    Papel = "diario hibrite";
                }
                else if (d.Papel.Contains("diario periodico"))
                {
                    Papel = "diario periodico";
                }
                else if (d.Papel.Contains("diario salmon"))
                {
                    Papel = "diario salmon";
                }
                else if (d.Papel.Contains("Diario"))
                {
                    Papel = "diario";
                }
                else if (d.Papel.Contains("lwc brillante"))
                {
                    Papel = "lwc brillante";
                }
                else if (d.Papel.Contains("lwc opaco"))
                {
                    Papel = "lwc opaco";
                }
                #endregion

                RadGrid1.DataSource = bp.StockBodegaPliegos(lblOT.Text, lblComponente.Text, lblLargo.Text, Papel, Convert.ToInt32(lblGramaje.Text), Convert.ToInt32(lblAncho.Text), Convert.ToInt32(Request.QueryString["solFL"]), Convert.ToInt32(Request.QueryString["solKG"]), lblPreID.Text, Request.QueryString["usuario"], 2);
                RadGrid1.DataBind();

                RadGrid2.DataSource = bp.ListadoPapelAsignado(lblOT.Text, lblComponente.Text, "", "", 0, 0, 0, "", 0, "", "", lblPreID.Text, 0, 1,0);
                RadGrid2.DataBind();

                int totalAsignado = bp.totalAsignado(lblOT.Text, lblComponente.Text, 0);
                //for (int i = 0; i < RadGrid2.Items.Count; i++)
                //{
                //    totalAsignado = totalAsignado + Convert.ToInt32(RadGrid2.Items[i]["stockFL"].Text);
                //}
                lblAsignadoFL.Text = totalAsignado.ToString("N0").Replace(",", ".");
                lblSolicitadoFL.Text = Convert.ToInt32(Request.QueryString["solFL"]).ToString("N0").Replace(",", ".");
                lblSolicitadoKG.Text = Convert.ToInt32(Request.QueryString["solKG"]).ToString("N0").Replace(",", ".");

                lblSaldoFL.Text = (Convert.ToInt32(Request.QueryString["solFL"]) - totalAsignado).ToString("N0").Replace(",", ".");
    
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            bool x = bp.ElimanarAsignacion(0, Request.QueryString["usuario"], 3);
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
            
        }

        [WebMethod]
        public static bool Delete(int id)
        {
            Controller_BodegaPliegos control = new Controller_BodegaPliegos();
            return control.ElimanarAsignacion(id, "", 2);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (RadGrid2.Items.Count > 0)
            {
                int AsAncho = 0;
                int AsLargo = 0;
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    AsAncho = Convert.ToInt32(RadGrid2.Items[i]["Ancho"].Text.Replace(".", ""));
                    AsLargo = Convert.ToInt32(RadGrid2.Items[i]["Largo"].Text.Replace(".", ""));
                }
                //pregunta si va a cortadora o directo a pesa
                if (txtAncho.Text != AsAncho.ToString() || txtLargo.Text != AsLargo.ToString())
                {//entra a cortadora
                    string codigo = bp.BuscaUltimoCodigoBarra(0, "", 0, 0, 0);
                    int numcode = Convert.ToInt32(codigo.Replace("SC-", ""));
                    string CodigoBarra = "";
                    #region codigo
                    switch (numcode.ToString().Length)
                    {
                        case 1:
                            CodigoBarra = "SC-000000" + (numcode + 1).ToString();
                            break;
                        case 2:
                            CodigoBarra = "SC-00000" + (numcode + 1).ToString();
                            break;
                        case 3:
                            CodigoBarra = "SC-0000" + (numcode + 1).ToString();
                            break;
                        case 4:
                            CodigoBarra = "SC-000" + (numcode + 1).ToString();
                            break;
                        case 5:
                            CodigoBarra = "SC-00" + (numcode + 1).ToString();
                            break;
                        case 6:
                            CodigoBarra = "SC-0" + (numcode + 1).ToString();
                            break;
                        case 7:
                            CodigoBarra = "SC-" + (numcode + 1).ToString();
                            break;
                    }
                    #endregion
                    //buscar codigo para generar etiqueta
                    for (int i = 0; i < RadGrid2.Items.Count; i++)
                    {   //cambiar estado
                        int id = Convert.ToInt32(RadGrid2.Items[i]["ID"].Text);
                        bool r = bp.InsertaFormatoCorte(id, "", 0, 0, 4);
                        //bool r = bp.InsertaFormatoCorte(id, CodigoBarra, Convert.ToInt32(txtAncho.Text), Convert.ToInt32(txtLargo.Text), 1);
                       
                        //string idP = RadGrid2.Items[i]["ID"].Text;
                        //int CantidadAsign = Convert.ToInt32(RadGrid2.Items[i]["stockFL"].Text);
                        //bool res = cr.Reservar(id, CantidadAsign, CodigoBarra, Request.QueryString["usuario"], 0);
                    }

                    Response.Redirect("EtiquetaAtenderSolicitud.aspx?cod=" + CodigoBarra + "&ot=" + lblOT.Text + "&nomOT=" + lblNombreOT.Text.Replace("#", "") + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&formato=" + "" + "&fecha=" + lblFechaCreacion.Text + "&cliente=" + lblCliente.Text + "&comp=" + lblComponente.Text);
                }
                else
                {//solicitud en proceso
                    string codigo = bp.BuscaUltimoCodigoBarra(0, "", 0, 0, 0);
                    int numcode = Convert.ToInt32(codigo.Replace("BP-", ""));
                    string CodigoBarra = "";
                    #region codigo
                    if (numcode.ToString().Count() == 1)
                    {
                        CodigoBarra = "BP-000000" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 2)
                    {
                        CodigoBarra = "BP-00000" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 3)
                    {
                        CodigoBarra = "BP-0000" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 4)
                    {
                        CodigoBarra = "BP-000" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 5)
                    {
                        CodigoBarra = "BP-00" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 6)
                    {
                        CodigoBarra = "BP-0" + (numcode + 1).ToString();
                    }
                    else if (numcode.ToString().Count() == 7)
                    {
                        CodigoBarra = "BP-" + (numcode + 1).ToString();
                    }
                    #endregion

                    //buscar codigo para generar etiqueta
                    for (int i = 0; i < RadGrid2.Items.Count; i++)
                    {
                        //cambiar estado
                        int id = Convert.ToInt32(RadGrid2.Items[i]["ID"].Text);
                        //bool r = bp.InsertaFormatoCorte(id, "", Convert.ToInt32(txtAncho.Text), Convert.ToInt32(txtLargo.Text), 3);
                       // bool r = bp.InsertaFormatoCorte(id, "", 0, 0, 4);
                    }




                    Response.Redirect("EtiquetaProductoEnProceso.aspx?cod=" + CodigoBarra + "&ot=" + lblOT.Text + "&nomOT=" + lblNombreOT.Text.Replace("#", "") + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&formato=" + "" + "&fecha=" + lblFechaCreacion.Text + "&cliente=" + lblCliente.Text + "&comp=" + lblComponente.Text);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'>alert('¡No ha Asignado nada para Esta OT!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AtenderSolicitudBuscaPapelStock.aspx?ot=" + lblOT.Text + "&comp=" + lblComponente.Text + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&usuario=" + Request.QueryString["usuario"] + "&preid=" + lblPreID.Text);
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AtenderSolicitudBuscaPapelStock.aspx?ot=" + lblOT.Text + "&comp=" + lblComponente.Text + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&usuario=" + Request.QueryString["usuario"] + "&preid=" + lblPreID.Text);
        }

    }
}