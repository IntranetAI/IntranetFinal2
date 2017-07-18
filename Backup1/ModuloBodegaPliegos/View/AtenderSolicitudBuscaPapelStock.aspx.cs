using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AtenderSolicitudBuscaPapelStock : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                BodegaPliegos d = bp.BuscaOTComponente(Request.QueryString["ot"], Request.QueryString["comp"], "", "", DateTime.Now, DateTime.Now, 0, 4);
                lblCodigoProducto.Text = d.CodigoProducto;
                lblPapel.Text = d.Papel.ToUpper().Replace("  ", " ");
                string gramaje = "";
                string Papel = "";
                string Ancho = "";
                string Largo = "";
                int contador = 0;
                int b=0;
                try
                {
                    string[] algo = d.Papel.Split(' ');
                    for (int i = 0; i < algo.Length; i++)
                    {
                        if (algo[i].ToString().Trim()!="")
                        {
                            if (int.TryParse(algo[i].ToString().Substring(0, 1), out b))
                            {
                                if (contador == 0)
                                {
                                    gramaje = algo[i].ToString().ToLower().Replace("g", "").Replace("gr", "");
                                }
                                else
                                {
                                    string[] axl = algo[i].ToString().Split('x');
                                    Ancho = axl[0].ToString().Replace("m", "").Replace("mm", "");
                                    Largo = axl[1].ToString().Replace("m", "").Replace("mm", "");
                                }
                                contador++;
                            }
                            else
                            {
                                Papel += algo[i].ToString() + " ";
                            }
                        }
                    }                    
                    txtPapel.Text = Papel;
                    txtGramaje.Text = gramaje;
                    txtAncho.Text = Ancho;
                    txtLargo.Text = Largo;
                    btnFiltro_Click1(sender, e);
                }
                catch
                {
                }

                lblGramaje.Text = d.Gramaje;
                lblAncho.Text = d.Ancho;
                lblLargo.Text = d.Largo;

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

                lblSolicitado.Text = "Cantidad Solicitada: " + Convert.ToInt32(Request.QueryString["solFL"]).ToString("N0").Replace(",", ".") + " Pliegos.";




                ddlCertificacion.DataSource = bp.BuscaCertificaciones("", "", "", "", "", "", 0, 0, 0, 0, 0, "", "", 1);
                ddlCertificacion.DataTextField = "Certificacion";
                ddlCertificacion.DataValueField = "Certificacion";
                ddlCertificacion.DataBind();
                ddlCertificacion.Items.Insert(0, new ListItem("Seleccione..."));
            }
           // (lblOT.Text, lblComponente.Text, lblLargo.Text, Papel, Convert.ToInt32(lblGramaje.Text), Convert.ToInt32(lblAncho.Text), Convert.ToInt32(Request.QueryString["solFL"]), Convert.ToInt32(Request.QueryString["solKG"]), lblPreID.Text, Request.QueryString["usuario"], 2);
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtPapel.Text != "" || txtGramaje.Text != "" && txtAncho.Text != "")
            {
                string ot = Request.QueryString["ot"];
                string componente = Request.QueryString["comp"];
                string papel = txtPapel.Text;
                string certi = ddlCertificacion.SelectedValue.ToString();
                if (certi == "Seleccione...")
                {
                    certi = "";
                }
                
                int gramaje = 0;
                if (txtGramaje.Text != "")
                {
                    gramaje = Convert.ToInt32(txtGramaje.Text);
                }
                int ancho = 0;
                if (txtAncho.Text != "")
                {
                    ancho = Convert.ToInt32(txtAncho.Text);
                }
                int Largo = 0;
                if (txtLargo.Text != "")
                {
                    Largo = Convert.ToInt32(txtLargo.Text);
                }
                string preid = Request.QueryString["preid"];
                
                RadGrid1.DataSource = bp.BuscaStockBodegaPliegos(ot,componente,certi,txtMarca.Text,"",papel,gramaje, ancho, Largo,Convert.ToInt32(Request.QueryString["solFL"]), Convert.ToInt32(Request.QueryString["solKG"]), preid, Request.QueryString["usuario"], 0);
                RadGrid1.DataBind();
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {//AtenderSolicitudPapel2.aspx?ot=101334&comp=TAPAS&solFL=315&solKG=22&preid=6&usuario=cjerias
            string ot = Request.QueryString["ot"];
            string comp = Request.QueryString["comp"];
            string solFL = Request.QueryString["solFL"];
            string solKG = Request.QueryString["solKG"];
            string usuario = Request.QueryString["usuario"];
            string preid = Request.QueryString["preid"];
            Response.Redirect("AtenderSolicitudPapel2.aspx?ot=" + ot + "&comp=" + comp + "&solFL=" + solFL + "&solKG=" + solKG + "&preid=" + preid + "&usuario=" + usuario);
        }
    }
}