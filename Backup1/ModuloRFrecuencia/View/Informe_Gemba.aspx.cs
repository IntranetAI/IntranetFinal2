using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using Intranet.ModuloRFrecuencia.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_Gemba : System.Web.UI.Page
    {
        Bobina_Controller controlbob = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
                string Ayer = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                CargarRegistros(Ayer);
                //divbotones.Style.Add("margin-top", "20px");
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;

                //DateTime f1 = Convert.ToDateTime(fechaInicio);
                string f1 = año + "-" + mes + "-" + dia;
                //txtCliente.Text = mes + "/" + dia + "/" + año;
                CargarRegistros(f1);
            }

        }

        public void CargarRegistros(string Dia)
        {
            RadGrid1.DataSource = controlbob.ListBobina_WarRom(Dia);
            RadGrid1.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            //divbotones.Style.Add("margin-top", "-10px");
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            //DateTime f1 = new DateTime();
            string f1 = "";
            if (txtFechaInicio.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                //string fechaInicio = mes + "/" + dia + "/" + año;

                f1 = año + "-" + mes + "-" + dia;//Convert.ToDateTime(fechaInicio).ToString();
                //txtCliente.Text = mes + "/" + dia + "/" + año;
            }
            else
            {
                f1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            }
            List<Bobina_Excel> lista = controlbob.ListBobina_WarRom(f1);

            List<Bobina_Excel> listaDimen = lista.Where(o => o.Maquina == "Dimensionadora").ToList();
            List<Bobina_Excel> listaM600 = lista.Where(o => o.Maquina == "M600").ToList();
            List<Bobina_Excel> listaLitho = lista.Where(o => o.Maquina == "Lithoman").ToList();
            List<Bobina_Excel> listaWeb1 = lista.Where(o => o.Maquina == "WEB 1").ToList();

            Bobina_Excel bob = new Bobina_Excel();

            GridView wControl = new GridView();
            wControl.DataSource = listaLitho;
            wControl.DataBind();
            wControl.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            wControl.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView GridM600 = new GridView();
            GridM600.DataSource = listaM600;
            GridM600.DataBind();
            GridM600.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridM600.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView GridDimen = new GridView();
            GridDimen.DataSource = listaDimen;
            GridDimen.DataBind();
            GridDimen.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridDimen.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView GridWeb1 = new GridView();
            GridWeb1.DataSource = listaWeb1;
            GridWeb1.DataBind();
            GridWeb1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridWeb1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            //Inicio del Excel 

            if (wControl.Rows.Count > 0)
            {
                wControl.HeaderRow.Cells[0].Text = "Código Bobina";
                wControl.HeaderRow.Cells[1].Visible = false;
                wControl.HeaderRow.Cells[2].Text = "Nombre Papel";
                wControl.HeaderRow.Cells[3].Text = "Gramaje";
                wControl.HeaderRow.Cells[4].Text = "Peso Bobina";
                wControl.HeaderRow.Cells[5].Text = "Estado Bobina";
                wControl.HeaderRow.Cells[6].Text = "Origen Daño";
                wControl.HeaderRow.Cells[7].Text = "Causa Daño";
                wControl.HeaderRow.Cells[8].Text = "Kilos Escarpe";
                wControl.HeaderRow.Cells[9].Text = "% Perdida";
                wControl.HeaderRow.Cells[10].Visible = false;
                wControl.HeaderRow.Cells[11].Visible = false;
                wControl.HeaderRow.Cells[12].Visible = false;
                wControl.HeaderRow.Cells[13].Visible = false;
                wControl.HeaderRow.Cells[14].Visible = false;
            }

            if (GridM600.Rows.Count > 0)
            {
                GridM600.HeaderRow.Cells[0].Text = "Código Bobina";
                GridM600.HeaderRow.Cells[1].Visible = false;
                GridM600.HeaderRow.Cells[2].Text = "Nombre Papel";
                GridM600.HeaderRow.Cells[3].Text = "Gramaje";
                GridM600.HeaderRow.Cells[4].Text = "Peso Bobina";
                GridM600.HeaderRow.Cells[5].Text = "Estado Bobina";
                GridM600.HeaderRow.Cells[6].Text = "Origen Daño";
                GridM600.HeaderRow.Cells[7].Text = "Causa Daño";
                GridM600.HeaderRow.Cells[8].Text = "Kilos Escarpe";
                GridM600.HeaderRow.Cells[9].Text = "% Perdida";
                GridM600.HeaderRow.Cells[10].Visible = false;
                GridM600.HeaderRow.Cells[11].Visible = false;
                GridM600.HeaderRow.Cells[12].Visible = false;
                GridM600.HeaderRow.Cells[13].Visible = false;
                GridM600.HeaderRow.Cells[14].Visible = false;
            }

            if (GridDimen.Rows.Count > 0)
            {
                GridDimen.HeaderRow.Cells[0].Text = "Código Bobina";
                GridDimen.HeaderRow.Cells[1].Visible = false;
                GridDimen.HeaderRow.Cells[2].Text = "Nombre Papel";
                GridDimen.HeaderRow.Cells[3].Text = "Gramaje";
                GridDimen.HeaderRow.Cells[4].Text = "Peso Bobina";
                GridDimen.HeaderRow.Cells[5].Text = "Estado Bobina";
                GridDimen.HeaderRow.Cells[6].Text = "Origen Daño";
                GridDimen.HeaderRow.Cells[7].Text = "Causa Daño";
                GridDimen.HeaderRow.Cells[8].Text = "Kilos Escarpe";
                GridDimen.HeaderRow.Cells[9].Text = "% Perdida";
                GridDimen.HeaderRow.Cells[10].Visible = false;
                GridDimen.HeaderRow.Cells[11].Visible = false;
                GridDimen.HeaderRow.Cells[12].Visible = false;
                GridDimen.HeaderRow.Cells[13].Visible = false;
                GridDimen.HeaderRow.Cells[14].Visible = false;
            }

            if (GridWeb1.Rows.Count > 0)
            {
                GridWeb1.HeaderRow.Cells[0].Text = "Código Bobina";
                GridWeb1.HeaderRow.Cells[1].Visible = false;
                GridWeb1.HeaderRow.Cells[2].Text = "Nombre Papel";
                GridWeb1.HeaderRow.Cells[3].Text = "Gramaje";
                GridWeb1.HeaderRow.Cells[4].Text = "Peso Bobina";
                GridWeb1.HeaderRow.Cells[5].Text = "Estado Bobina";
                GridWeb1.HeaderRow.Cells[6].Text = "Origen Daño";
                GridWeb1.HeaderRow.Cells[7].Text = "Causa Daño";
                GridWeb1.HeaderRow.Cells[8].Text = "Kilos Escarpe";
                GridWeb1.HeaderRow.Cells[9].Text = "% Perdida";
                GridWeb1.HeaderRow.Cells[10].Visible = false;
                GridWeb1.HeaderRow.Cells[11].Visible = false;
                GridWeb1.HeaderRow.Cells[12].Visible = false;
                GridWeb1.HeaderRow.Cells[13].Visible = false;
                GridWeb1.HeaderRow.Cells[14].Visible = false;
            }


            for (int contador = 0; contador < wControl.Rows.Count; contador++)
            {
                GridViewRow row = wControl.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                bob.BBuenas = row.Cells[11].Text;
                bob.BMalas = row.Cells[12].Text;
                bob.BMalas_QG = row.Cells[10].Text;

                double PesoOriginal = Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[4].Text.Length > 3)
                {
                    string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                    row.Cells[4].Text = po2;
                }
                else
                {
                    string po2 = PesoOriginal.ToString("N0");
                    row.Cells[4].Text = po2;
                }
            }

            for (int contador = 0; contador < GridM600.Rows.Count; contador++)
            {
                GridViewRow row = GridM600.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                bob.Maquina = row.Cells[11].Text;
                bob.NombreOT = row.Cells[12].Text;
                bob.OT = row.Cells[10].Text;

                double PesoOriginal = Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[4].Text.Length > 3)
                {
                    string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                    row.Cells[4].Text = po2;
                }
                else
                {
                    string po2 = PesoOriginal.ToString("N0");
                    row.Cells[4].Text = po2;
                }
            }

            for (int contador = 0; contador < GridDimen.Rows.Count; contador++)
            {
                GridViewRow row = GridDimen.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                bob.Peso_Original = row.Cells[11].Text;
                bob.Pesos_Conos = row.Cells[12].Text;
                bob.Pesos_Envoltura = row.Cells[10].Text;

                double PesoOriginal = Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[4].Text.Length > 3)
                {
                    string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                    row.Cells[4].Text = po2;
                }
                else
                {
                    string po2 = PesoOriginal.ToString("N0");
                    row.Cells[4].Text = po2;
                }
            }

            for (int contador = 0; contador < GridWeb1.Rows.Count; contador++)
            {
                GridViewRow row = GridWeb1.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                bob.Pesos_Escarpe = row.Cells[11].Text;
                bob.Pesos_Tapas = row.Cells[12].Text;
                bob.Porc_Buenas = row.Cells[10].Text;

                double PesoOriginal = Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[4].Text.Length > 3)
                {
                    string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                    row.Cells[4].Text = po2;
                }
                else
                {
                    string po2 = PesoOriginal.ToString("N0");
                    row.Cells[4].Text = po2;
                }
            }
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            string FechaTitulo;
            if (txtFechaInicio.Text == "")
            {
                FechaTitulo = DateTime.Now.AddDays(-1).ToShortDateString();
            }
            else
            {
                FechaTitulo = txtFechaInicio.Text;
            }
            string Titulo = "<div align='center'>Reporte Desperdicio Papel <br/>Dia: " + txtFechaInicio.Text + " Desde:00:00 Hasta 23:59:59 </div><br />";
            la.Text = Titulo;
            form.Controls.Add(la);
            if (wControl.Rows.Count > 0)
            {
                Label Maquina1 = new Label();
                Maquina1.Text = "<div>Lithoman </div><br/>";
                form.Controls.Add(Maquina1);
                form.Controls.Add(wControl);
                Label TaTotLitho = new Label();
                TaTotLitho.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.BMalas_QG.ToString() + "</td></tr></table></div>";
                form.Controls.Add(TaTotLitho);
            }

            if (GridM600.Rows.Count > 0)
            {
                Label Maquina2 = new Label();
                Maquina2.Text = "<br/><div align='left'>M600 </div><br/>";
                form.Controls.Add(Maquina2);
                form.Controls.Add(GridM600);
                Label TaTotM600 = new Label();
                TaTotM600.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Maquina.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.OT.ToString() + "</td></tr></table></div>";
                form.Controls.Add(TaTotM600);
            }

            if (GridDimen.Rows.Count > 0)
            {
                Label Maquina3 = new Label();
                Maquina3.Text = "<br/><div align='left'>Dimensionadora </div><br/>";
                form.Controls.Add(Maquina3);
                form.Controls.Add(GridDimen);
                Label TaTotDimen = new Label();
                TaTotDimen.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
                form.Controls.Add(TaTotDimen);
            }

            if (GridWeb1.Rows.Count > 0)
            {
                Label Maquina4 = new Label();
                Maquina4.Text = "<br/><div align='left'>Web 1 </div><br/>";
                form.Controls.Add(Maquina4);
                form.Controls.Add(GridWeb1);
                Label TaTotWeb1 = new Label();
                TaTotWeb1.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Pesos_Escarpe.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Pesos_Tapas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob.Porc_Buenas.ToString() + "</td></tr></table></div>";
                form.Controls.Add(TaTotWeb1);
            }

            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            string fecha;
            if (txtFechaInicio.Text == "")
            {
                fecha = DateTime.Now.AddDays(-1).ToShortDateString();
            }
            else
            {
                fecha = txtFechaInicio.Text;
            }
            response.AddHeader("Content-Disposition", "attachment;filename=Reporte Desperdicio Papel" + fecha + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();


            //fin del excel

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}