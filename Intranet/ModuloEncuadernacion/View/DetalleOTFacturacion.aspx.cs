using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Intranet.ModuloEncuadernacion.Model;
using System.Drawing;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class DetalleOTFacturacion : System.Web.UI.Page
    {
        List<FacturacionEnc> lista = new List<FacturacionEnc>();
        Controller_FacturacionEnc cf = new Controller_FacturacionEnc();
        DateTime fe = Convert.ToDateTime("1900-01-01");
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            int pli = cf.PliegosProcesos2(ot, "", fe, fe, 16);
            if (pli == 0)
            {
                btnActualizar.Enabled = false;
                btnPrefactura.Enabled = false;
            }
            lista = cf.ValorizacionProcesos(ot, pli);
            FacturacionEnc fac = cf.BuscaOT(ot);
            lblOT.Text = "OT: " + fac.OT + "  -  " + fac.NombreOT;
            lblTirajeyDespachado.Text = "Tiraje: " + Convert.ToInt32(fac.Tiraje).ToString("N0").Replace(",", ".") + "  - Cant. Despachada: " + Convert.ToInt32(fac.DespachadoEnc).ToString("N0").Replace(",", ".");
            lblPliegos.Text = "Nro de Pliegos: " + pli;



            
           
            if (!IsPostBack)
            {
               //si existe una prefactura parcial!!
                if (cf.verificarPreFactura(ot, "", fe, fe, 9))
                {
                    gv1.DataSource = cf.FacturacionParcial(ot, "", fe, fe, 10);
                    gv1.DataBind();

                    //deshabilitar las cantidades completadas
                    for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                    {
                        if (gv1.Rows[i].Cells[7].Text == "0")
                        {
                            TextBox txtName = ((TextBox)gv1.Rows[i].FindControl("txtEjemplar"));
                            txtName.Enabled = false;

                            TextBox txtName2 = ((TextBox)gv1.Rows[i].FindControl("txtCantidad"));
                            txtName2.Enabled = false;
                        }
                    }
                }
                else
                {
                    gv1.DataSource = cf.ValorizacionProcesos(ot, pli).OrderBy(o => o.Fecha).Where(p => p.ValorUnitario != "0").Where(p => p.Cantidad != "0");
                    gv1.DataBind();
                }



                DateTime f = Convert.ToDateTime("1900-01-01");
                RadGrid4.DataSource = cf.DespachoEncuadernacion(ot, "", f, f, 1);
                RadGrid4.DataBind();




                int total = 0;
                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {

                    total = total + Convert.ToInt32(gv1.Rows[i].Cells[7].Text.Replace(".", "").Replace("$", "").Trim());
                  
                }
                lblTotal.Text = "$   " + total.ToString("N0").Replace(",", ".");



                RadGrid3.DataSource = cf.ListaPrefacturas(ot);
                RadGrid3.DataBind();
            }
 
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cf.verificarPreFactura(Request.QueryString["ot"], "", fe, fe, 9))
            {
                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {
                    String Lab = ((Label)gv1.Rows[i].FindControl("lblCantidad")).Text;
                    String torval = ((TextBox)gv1.Rows[i].FindControl("txtCantidad")).Text;

                    String LabEjem = ((Label)gv1.Rows[i].FindControl("lblEjemplar")).Text;
                    String torvalEjem = ((TextBox)gv1.Rows[i].FindControl("txtEjemplar")).Text;

                    if (Lab != torval)
                    {
                        double ejem = (Convert.ToDouble(torval) / Convert.ToDouble(Lab));
                        int PU = Convert.ToInt32(gv1.Rows[i].Cells[6].Text.Replace("$", "").Trim());
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).CantidadDesp = Convert.ToInt32(torval.Replace(".", "").Trim()).ToString("N0").Replace(",", ".");
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ " + ((PU * Convert.ToInt32(torval.Replace(".", ""))) ).ToString("N0").Replace(",", ".");
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Ejemplar = ejem.ToString("N2");
                    }
                    else if (LabEjem != torvalEjem)
                    {
                        double ejem = Convert.ToDouble(torvalEjem.Replace(".", ","));
                        int ee = Convert.ToInt32(Convert.ToDouble(ejem) * Convert.ToDouble(Lab.Replace(".", "")));
                        int PU = Convert.ToInt32(gv1.Rows[i].Cells[6].Text.Replace("$", "").Trim());
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).CantidadDesp = ee.ToString("N0").Replace(",", ".");
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ " + ((PU * Convert.ToInt32(ee.ToString().Replace(".", ""))) ).ToString("N0").Replace(",", ".");//sumar costo f
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Ejemplar = ejem.ToString("N2");
                    }

               }

            }
            else
            {
                for (int i = 0; i <= gv1.Rows.Count - 1; i++)
                {
                    String Lab = ((Label)gv1.Rows[i].FindControl("lblCantidad")).Text;
                    String torval = ((TextBox)gv1.Rows[i].FindControl("txtCantidad")).Text;

                    String LabEjem = ((Label)gv1.Rows[i].FindControl("lblEjemplar")).Text;
                    String torvalEjem = ((TextBox)gv1.Rows[i].FindControl("txtEjemplar")).Text;

                    if (Lab != torval)
                    {
                        double ejem = (Convert.ToDouble(torval) / Convert.ToDouble(Lab));
                        int PU = Convert.ToInt32(gv1.Rows[i].Cells[6].Text.Replace("$", "").Trim());
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).CantidadDesp = Convert.ToInt32(torval.Replace(".", "").Trim()).ToString("N0").Replace(",", ".");
                        if (torval == "0")
                        {
                            lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ 0";
                        }
                        else
                        {
                            lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ " + ((PU * Convert.ToInt32(torval.Replace(".", ""))) + Convert.ToInt32(cf.PrecioUnitario(gv1.Rows[i].Cells[1].Text, "", fe, fe, 8))).ToString("N0").Replace(",", ".");
                        }
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Ejemplar = ejem.ToString("N2");
                    }
                    else if (LabEjem != torvalEjem)
                    {
                        double ejem = Convert.ToDouble(torvalEjem.Replace(".", ","));
                        int ee = Convert.ToInt32(Convert.ToDouble(ejem) * Convert.ToDouble(Lab.Replace(".", "")));
                        int PU = Convert.ToInt32(gv1.Rows[i].Cells[6].Text.Replace("$", "").Trim());
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).CantidadDesp = ee.ToString("N0").Replace(",", ".");
                        if (torval == "0")
                        {
                            lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ 0";
                        }
                        else
                        {
                            lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Total = "$ " + ((PU * Convert.ToInt32(ee.ToString().Replace(".", ""))) + +Convert.ToInt32(cf.PrecioUnitario(gv1.Rows[i].Cells[1].Text, "", fe, fe, 8))).ToString("N0").Replace(",", ".");//sumar costo f
                        }
                        lista.FirstOrDefault(p => p.Proceso.Equals(gv1.Rows[i].Cells[1].Text)).Ejemplar = ejem.ToString("N2");
                    }
                }
               
            }

                 gv1.DataSource = lista.OrderBy(o => o.Fecha).Where(p => p.ValorUnitario != "0").Where(p => p.Cantidad != "0");
                gv1.DataBind();


            int total = 0;
            for (int i = 0; i <= gv1.Rows.Count - 1; i++)
            {
                total = total + Convert.ToInt32(gv1.Rows[i].Cells[7].Text.Replace(".", "").Replace("$", "").Trim());

                if (gv1.Rows[i].Cells[7].Text.Trim() == "0" || gv1.Rows[i].Cells[7].Text.Trim() == "$ 0")
                {
                    TextBox txtName = ((TextBox)gv1.Rows[i].FindControl("txtEjemplar"));
                    txtName.Enabled = false;

                    TextBox txtName2 = ((TextBox)gv1.Rows[i].FindControl("txtCantidad"));
                    txtName2.Enabled = false;
                }
            }
            lblTotal.Text = "$   " + total.ToString("N0").Replace(",", ".");


            
        }

        protected void btnPrefactura_Click(object sender, EventArgs e)
        {
            FacturacionEnc f = new FacturacionEnc();
            f.NroPreFactura = "0";
            f.OT = "";
            f.Proceso = "";
            f.Maquina = "";
            f.Cantidad = "0";
            f.DespachadoEnc = "0";
            f.CantidadDespOriginal = "0";
            f.Ejemplar = "0";
            f.ValorUnitario = "0";
            f.Total = "0";
            f.Usuario = "cjerias";

            int r = 0;
            int rr = 0;
            int m = 0;
            rr = cf.IngresoPreFactura(f, 1);
            rr = rr + 1;
            for (int i = 0; i <= gv1.Rows.Count - 1; i++)
            {
                f.NroPreFactura = rr.ToString();
                f.OT = gv1.Rows[i].Cells[0].Text;
                f.Proceso = gv1.Rows[i].Cells[1].Text;
                f.Maquina = gv1.Rows[i].Cells[2].Text;
                if (f.Maquina == "&nbsp;")
                {
                    f.Maquina = "";
                }
                f.Cantidad = gv1.Rows[i].Cells[3].Text.Replace(".", "");
                f.DespachadoEnc = ((TextBox)gv1.Rows[i].FindControl("txtCantidad")).Text.Replace(".", "");
                f.CantidadDespOriginal = ((Label)gv1.Rows[i].FindControl("lblCantidad")).Text.Replace(".", "");
                f.Ejemplar = ((TextBox)gv1.Rows[i].FindControl("txtEjemplar")).Text.Replace(",", ".");
                f.ValorUnitario = gv1.Rows[i].Cells[6].Text.Replace("$", "").Replace(".", "").Trim();
                f.Total = gv1.Rows[i].Cells[7].Text.Replace("$", "").Replace(".", "").Trim();
                f.Usuario = "cjerias";

                    r = cf.IngresoPreFactura(f, 0);
                    if (r != 0)
                    {
                        m = m + 1;
                    }
                

            }
            if (m != 0)
            {
                btnPrefactura.Enabled = false;
                string popupScript = "<script language='JavaScript'> alert('La PreFactura N° " + rr.ToString() + " se ha generado Correctamente.');location.href='DetalleOTFacturacion.aspx?ot=" + Request.QueryString["ot"] + "' </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }



    }
}