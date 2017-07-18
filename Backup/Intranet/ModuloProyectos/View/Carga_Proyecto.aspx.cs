using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProyectos.Model;
using Intranet.ModuloProyectos.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloProyectos.View
{
    public partial class Carga_Proyecto : System.Web.UI.Page
    {
        Controller_Proyectos cp = new Controller_Proyectos();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProyecto.Text = "Proyecto " + Request.QueryString["p"];


           // List<ProyectosOT> listaOTS = cp.CargarOT(Session["Usuario"].ToString(), Request.QueryString["p"], 1);


           // List<ProyectosOT> lista = cp.CargarOTSProyecto("", "", 0);
           //// List<ProyectosOT> ListCompleta = new List<ProyectosOT>();

           // List<ProyectosOT> lista2 = new List<ProyectosOT>();
           // foreach (ProyectosOT pt in listaOTS)
           // {
           //     List<ProyectosOT> ListCompleta = lista.Where(o => o.OT == pt.OT).ToList();
           //     foreach (ProyectosOT pp in ListCompleta)
           //     {
           //         lista2.Add(pp);
           //     }

           // }

            RadGrid1.DataSource = cp.CargarOTSProyecto(Session["Usuario"].ToString(), Request.QueryString["p"], 0);

            RadGrid1.DataBind();

                Session["Usuario"] = Session["Usuario"].ToString();
        }

        protected void ibExportExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<ProyectosOT> lista = new List<ProyectosOT>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {

                ProyectosOT pro = new ProyectosOT();

                pro.OT = RadGrid1.Items[i]["OT"].Text;
                pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                pro.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                pro.TirajeTotal = RadGrid1.Items[i]["TirajeTotal"].Text;
                pro.EnviadoEnc = RadGrid1.Items[i]["EnviadoEnc"].Text;
                pro.TotalRecepcionado = RadGrid1.Items[i]["TotalRecepcionado"].Text;
                pro.TotalDespachado = RadGrid1.Items[i]["TotalDespachado"].Text;
                pro.Devolucion = RadGrid1.Items[i]["Devolucion"].Text;
                pro.Saldo = RadGrid1.Items[i]["Saldo"].Text;
                pro.Avance = RadGrid1.Items[i]["Avance"].Text;


                int TD = Convert.ToInt32(RadGrid1.Items[i]["TotalDespachado"].Text.Replace(".", ""));

                int TT = Convert.ToInt32(RadGrid1.Items[i]["TirajeTotal"].Text.Replace(".", ""));

                if (TT == 0)
                {
                    pro.Avance = "0%";
                }
                else
                {
                    int avanc = ((TD * 100 / TT * 100));

                    if (avanc == 0)
                    {
                        pro.Avance = "0%";

                    }
                    else
                    {
                        string avanc2 = avanc.ToString().Substring(0, avanc.ToString().Length - 2);
                        avanc = Convert.ToInt32(avanc2.ToString());
                        pro.Avance = avanc.ToString() + "%";

                    }

                }
                if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Blue;'>En Proceso</div>")
                {
                    pro.Estado = "En Proceso";
                }
                else
                {
                    pro.Estado = "Liquidada";
                }
                   


                lista.Add(pro);
            }
            GridView GridView1 = new GridView();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
            GridView1.HeaderRow.Cells[3].Text = "Tiraje OT";
            GridView1.HeaderRow.Cells[4].Text = "Enviado Enc.";
            GridView1.HeaderRow.Cells[5].Text = "Total Recepcionado";
            GridView1.HeaderRow.Cells[5].Text = "Total Desp.";
            GridView1.HeaderRow.Cells[11].Visible = false;


            int contador = 0;
            for (contador = 0; contador < GridView1.Rows.Count; contador++)
            {
                GridViewRow row = GridView1.Rows[contador];
                row.Cells[11].Visible = false;
            }


            string nombre = lblProyecto.Text +"_" + DateTime.Now.ToString("dd/MM/yyyy");
            string titulo= lblProyecto.Text;

                ExportToExcel(nombre, GridView1, titulo);//GridView1);
           

        }
        private void ExportToExcel(string nameReport, GridView wControl, string Titulo)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            //if (fInicio != "")
            //{
            la.Text = "<div align='center' style='font-weight: bold;font-size:25px;'>" + Titulo.ToUpper() + "<br/> </div><br/>";
            //}
            //else
            //{
            //   // la.Text = "<div align='center'>INFORME PRODUCTOS RECEPCIONADOS<br/> </div><br/>";
            //}
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
            //form.Controls.Add(l);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
    }
}