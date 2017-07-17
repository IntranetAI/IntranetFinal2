using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AsignarPliegosPopUp : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        List<BodegaPliegos> lista = new List<BodegaPliegos>();
        List<BodegaPliegos> lista2 = new List<BodegaPliegos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitulo.Text = "Asignar Papel Solicitud PreID ";
                lblPreID.Text = Request.QueryString["preid"];
                
                int id = Convert.ToInt32(Request.QueryString["id"]);
                string ot = Request.QueryString["ot"];
                string comp = Request.QueryString["comp"];
                int solFL = Convert.ToInt32(Request.QueryString["solFL"]);
                int solKG = Convert.ToInt32(Request.QueryString["solKG"]);
                lblSolicitado.Text = "Cantidad Solicitada: " + solFL.ToString("N0").Replace(",", ".")+" Pliegos.";

                lista = bp.ListadoDetalleSKU(id.ToString(), "","",0, "", "", 0, 0, 0, "", 0, "", "", 2,0);

                RadGrid1.DataSource = lista;//.Where(s => s.Asignar == "NO").ToList();
                RadGrid1.DataBind();

                gv1.DataSource = lista2;
                gv1.DataBind();
                BodegaPliegos d = bp.BuscaOTComponente(Request.QueryString["ot"], Request.QueryString["comp"], "", "", DateTime.Now, DateTime.Now, 0, 4);
                lblCodigoProducto.Text = d.CodigoProducto;
                lblPapel.Text = d.Papel.ToUpper();
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

            }
        }
        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<BodegaPliegos> l2 = new List<BodegaPliegos>();
            List<BodegaPliegos> l3 = new List<BodegaPliegos>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                BodegaPliegos b=new BodegaPliegos();
                b.ID = RadGrid1.Items[i]["ID"].Text;
                b.CodigoProducto = RadGrid1.Items[i]["CodigoProducto"].Text;
                b.Papel = RadGrid1.Items[i]["Papel"].Text;
                b.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                b.Sector = RadGrid1.Items[i]["Sector"].Text; 
                b.Ubicacion = RadGrid1.Items[i]["Ubicacion"].Text;
                b.NroPallet = RadGrid1.Items[i]["NroPallet"].Text;
                b.Gramaje = RadGrid1.Items[i]["Gramaje"].Text;
                b.Ancho = RadGrid1.Items[i]["Ancho"].Text;
                b.Largo = RadGrid1.Items[i]["Largo"].Text;
                b.StockFL = RadGrid1.Items[i]["StockFL"].Text;
                b.Antiguedad = RadGrid1.Items[i]["Antiguedad"].Text;
                l2.Add(b);
            }

            for (int i = 0; i <= gv1.Rows.Count - 1; i++)
            {
                BodegaPliegos c = new BodegaPliegos();
                c.ID = gv1.Rows[i].Cells[0].Text;
                c.CodigoProducto = gv1.Rows[i].Cells[1].Text;
                c.Papel = gv1.Rows[i].Cells[2].Text;
                c.Cliente = gv1.Rows[i].Cells[3].Text;
                c.Sector = gv1.Rows[i].Cells[4].Text;
                c.Ubicacion = gv1.Rows[i].Cells[5].Text;
                c.NroPallet = gv1.Rows[i].Cells[6].Text;
                c.Gramaje = gv1.Rows[i].Cells[7].Text;
                c.Ancho = gv1.Rows[i].Cells[8].Text;
                c.Largo = gv1.Rows[i].Cells[9].Text;
                c.StockFL = gv1.Rows[i].Cells[11].Text;
                c.Antiguedad = gv1.Rows[i].Cells[10].Text;
                l3.Add(c);
            }


            string a = gv1.Rows[e.RowIndex].Cells[0].Text;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            BodegaPliegos itemToRemove =bp.ListadoDetalleSKU(id.ToString(), "","",0, "", "", 0, 0, 0, "", 0, "", "", 2,0).SingleOrDefault(r => r.ID == a);
            BodegaPliegos iii = l3.SingleOrDefault(r => r.ID == a);
            l3.Remove(iii);


            l2.Add(itemToRemove);


            RadGrid1.DataSource = l2;
            RadGrid1.DataBind();


            gv1.DataSource = l3;
            gv1.DataBind();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            string compo = Request.QueryString["comp"];
            string popupScript = "<script language='JavaScript'>location.href='AtenderSolicitudPapel2.aspx?ot=" + ot + "&comp=" + compo + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&preid=" + Request.QueryString["preid"] + "&usuario=" + Request.QueryString["usuario"] + "'; </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnAnadirPapel_Click(object sender, EventArgs e)
        {
            int Gramaje = Convert.ToInt32(lblGramaje.Text.Replace(".", ""));
            int Ancho = Convert.ToInt32(lblAncho.Text.Replace(".", ""));
            int largo = Convert.ToInt32(lblLargo.Text.Replace(".", ""));
            if (gv1.Rows.Count > 0)
            {
                List<BodegaPliegos> lnewAsignados = new List<BodegaPliegos>();
                List<BodegaPliegos> lnewSinAsignados = new List<BodegaPliegos>();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {


                            BodegaPliegos b = new BodegaPliegos();
                            b.ID = RadGrid1.Items[i]["ID"].Text;
                            b.CodigoProducto = RadGrid1.Items[i]["CodigoProducto"].Text;
                            b.Papel = RadGrid1.Items[i]["Papel"].Text;
                            b.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                            b.Sector = RadGrid1.Items[i]["Sector"].Text;
                            b.Ubicacion = RadGrid1.Items[i]["Ubicacion"].Text;
                            b.NroPallet = RadGrid1.Items[i]["NroPallet"].Text;
                            b.Gramaje = RadGrid1.Items[i]["Gramaje"].Text;
                            b.Ancho = RadGrid1.Items[i]["Ancho"].Text;
                            b.Largo = RadGrid1.Items[i]["Largo"].Text;
                            b.StockFL = RadGrid1.Items[i]["StockFL"].Text;
                            b.Antiguedad = RadGrid1.Items[i]["Antiguedad"].Text;
                            lnewAsignados.Add(b);

                       // BodegaPliegos itemToRemove = lista.SingleOrDefault(r => r.ID == row["ID"].Text);
                    }
                    else
                    {
                        BodegaPliegos b = new BodegaPliegos();
                        b.ID = RadGrid1.Items[i]["ID"].Text;
                        b.CodigoProducto = RadGrid1.Items[i]["CodigoProducto"].Text;
                        b.Papel = RadGrid1.Items[i]["Papel"].Text;
                        b.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                        b.Sector = RadGrid1.Items[i]["Sector"].Text;
                        b.Ubicacion = RadGrid1.Items[i]["Ubicacion"].Text;
                        b.NroPallet = RadGrid1.Items[i]["NroPallet"].Text;
                        b.Gramaje = RadGrid1.Items[i]["Gramaje"].Text;
                        b.Ancho = RadGrid1.Items[i]["Ancho"].Text;
                        b.Largo = RadGrid1.Items[i]["Largo"].Text;
                        b.StockFL = RadGrid1.Items[i]["StockFL"].Text;
                        b.Antiguedad = RadGrid1.Items[i]["Antiguedad"].Text;
                        lnewSinAsignados.Add(b);
                    }
                }
                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {
                    BodegaPliegos c = new BodegaPliegos();
                    c.ID = gv1.Rows[i].Cells[0].Text;
                    c.CodigoProducto = gv1.Rows[i].Cells[1].Text;
                    c.Papel = gv1.Rows[i].Cells[2].Text;
                    c.Cliente = gv1.Rows[i].Cells[3].Text;
                    c.Sector = gv1.Rows[i].Cells[4].Text;
                    c.Ubicacion = gv1.Rows[i].Cells[5].Text;
                    c.NroPallet = gv1.Rows[i].Cells[6].Text;
                    c.Gramaje = gv1.Rows[i].Cells[7].Text;
                    c.Ancho = gv1.Rows[i].Cells[8].Text;
                    c.Largo = gv1.Rows[i].Cells[9].Text;
                    c.StockFL = gv1.Rows[i].Cells[11].Text;
                    c.Antiguedad = gv1.Rows[i].Cells[10].Text;
                    lnewAsignados.Add(c);
                }
                RadGrid1.DataSource = lnewSinAsignados;
                RadGrid1.DataBind();

                gv1.DataSource = lnewAsignados;
                gv1.DataBind();
            }
            else
            {
                int v = 0; int id = Convert.ToInt32(Request.QueryString["id"]);
                lista = bp.ListadoDetalleSKU(id.ToString(), "", "", 0, "", "", 0, 0, 0, "", 0, "", "", 2,0);



                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {

                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        if (Convert.ToInt32(RadGrid1.Items[i]["Gramaje"].Text) >= Gramaje && Convert.ToInt32(RadGrid1.Items[i]["Ancho"].Text) >= Ancho && Convert.ToInt32(RadGrid1.Items[i]["Largo"].Text) >= largo)
                        {
                            BodegaPliegos itemToRemove = lista.SingleOrDefault(r => r.ID == row["ID"].Text);
                            lista2.Add(itemToRemove);
                            v = v + 1;
                            if (itemToRemove != null)
                            {
                                lista.Remove(itemToRemove);
                                //row["NumeroOT"].Text;
                            }
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'>alert('¡El formato del papel no es el correcto. El gramaje, ancho y largo debe ser igual o mayor al solicitado!');</script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }

                    }
                    else
                    {
                    }
                }


                RadGrid1.DataSource = lista;
                RadGrid1.DataBind();

                gv1.DataSource = lista2;
                gv1.DataBind();
            }

            for (int i = 0; i <= gv1.Rows.Count - 1; i++)
            {
                ((TextBox)gv1.Rows[i].FindControl("txtCantidad")).Attributes.Add("onkeypress", "return solonumeros(event);");

            }
           // lblTitulo.Text = v.ToString();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            string compo = Request.QueryString["comp"];
            bool br = false;
            if (gv1.Rows.Count > 0)
            {
                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {
                    String torval = ((TextBox)gv1.Rows[i].FindControl("txtCantidad")).Text;
                    String drop = ((DropDownList)gv1.Rows[i].FindControl("ddlFactor")).SelectedValue.ToString();
                    int fac = Convert.ToInt32(drop);
                    string inicial = gv1.Rows[i].Cells[11].Text;
                    int ini = Convert.ToInt32(inicial);
                    int asignado = Convert.ToInt32(torval);
                    if (asignado <= ini)
                    {
                        int result = 0;
                        //ot 
                        //compo
                        //Request.QueryString["usuario"]
                        //idpapel    Convert.ToInt32(gv1.Rows[i].Cells[0].Text)
                        //asignado
                        result = bp.InsertAsignarPapelCorte(ot, compo, gv1.Rows[i].Cells[0].Text, asignado, Request.QueryString["usuario"], 0);
                        //result = bp.InsertAsignarPapel(ot, compo, lblPreID.Text, Convert.ToInt32(gv1.Rows[i].Cells[0].Text), gv1.Rows[i].Cells[1].Text, gv1.Rows[i].Cells[2].Text, Convert.ToInt32(gv1.Rows[i].Cells[7].Text), Convert.ToInt32(gv1.Rows[i].Cells[8].Text), Convert.ToInt32(gv1.Rows[i].Cells[9].Text), "", asignado, gv1.Rows[i].Cells[10].Text, Request.QueryString["usuario"], 0, fac);
                        if (result > 0)
                        {
                            br = false;
                        }
                        else
                        {
                            br = true;
                            break;
                        }
                        //transaccion
                    }
                    else
                    {
                        br = true;
                        break;
                    }
                }
            }
            if (br == true)
            {
                string popupScript = "<script language='JavaScript'>alert('La cantidad Asignada no puede ser mayor al stock disponible'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {
                    bool r = bp.ElimanarAsignacion(Convert.ToInt32(gv1.Rows[i].Cells[0].Text), "", 1);
                    // gv1.Rows[i].Cells[11].Text;
                }
              //  bool resp = bp.ElimanarAsignacion(Request.QueryString["usuario"], 0);
            }
            else
            {
                string popupScript = "<script language='JavaScript'>alert('Pliegos Asignados Correctamente');location.href='AtenderSolicitudPapel2.aspx?ot=" + ot + "&comp=" + compo + "&solFL=" + Request.QueryString["solFL"] + "&solKG=" + Request.QueryString["solKG"] + "&preid=" + Request.QueryString["preid"] + "&usuario=" + Request.QueryString["usuario"] + "&p=1'; </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}