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
    public partial class Informe_Semanal : System.Web.UI.Page
    {
        Bobina_Controller controlbob = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
                string Ayer = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

                CargarRegistros(Ayer,"");
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text!= "")
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

                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año = año.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                CargarRegistros(f1, fechaTermino);
            }

        }

        public void CargarRegistros(string FechaInicio, string FechaTermino)
        {
            RadGrid1.DataSource = controlbob.ListBobina_WarRom(FechaInicio, FechaTermino);
            RadGrid1.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            int PesoTotalOrig = 0;
            int BobCProyect = 0;
            int BobSProyect = 0;
            //DateTime f1 = new DateTime();
            string f1 = "";
            string f2 = "";
            if (txtFechaInicio.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                //string fechaInicio = mes + "/" + dia + "/" + año;

                f1 = año + "-" + mes + "-" + dia;//Convert.ToDateTime(fechaInicio);
                //txtCliente.Text = mes + "/" + dia + "/" + año;
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año = año.Substring(0, 4);

                f2 = mes2 + "/" + dia2 + "/" + año2;
                PesoTotalOrig = controlbob.PesoOriginalTB(f1, f2);
            }
            else
            {
                f1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                f2 = DateTime.Now.ToString("yyyy-MM-dd");

            }
            List<Bobina_Excel> lista = controlbob.ListBobina_WarRom(f1,f2);

            List<Bobina_Excel> listaDimen = lista.Where(o => o.Maquina == "Dimensionadora").ToList();
            List<Bobina_Excel> listaM600 = lista.Where(o => o.Maquina == "M600").ToList();
            List<Bobina_Excel> listaLitho = lista.Where(o => o.Maquina == "Lithoman").ToList();
            List<Bobina_Excel> listaWeb1 = lista.Where(o => o.Maquina == "WEB 1").ToList();

            Bobina_Excel bob1 = new Bobina_Excel();
            Bobina_Excel bob2 = new Bobina_Excel();
            Bobina_Excel bob3 = new Bobina_Excel();
            Bobina_Excel bob4 = new Bobina_Excel();
            Bobina_Excel bob5 = new Bobina_Excel();

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
                wControl.HeaderRow.Cells[15].Visible = false;
                wControl.HeaderRow.Cells[16].Visible = false;
                wControl.HeaderRow.Cells[17].Visible = false;
                wControl.HeaderRow.Cells[18].Visible = false;
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
                GridM600.HeaderRow.Cells[15].Visible = false;
                GridM600.HeaderRow.Cells[16].Visible = false;
                GridM600.HeaderRow.Cells[17].Visible = false;
                GridM600.HeaderRow.Cells[18].Visible = false;
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
                GridDimen.HeaderRow.Cells[15].Visible = false;
                GridDimen.HeaderRow.Cells[16].Visible = false;
                GridDimen.HeaderRow.Cells[17].Visible = false;
                GridDimen.HeaderRow.Cells[18].Visible = false;
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
                GridWeb1.HeaderRow.Cells[15].Visible = false;
                GridWeb1.HeaderRow.Cells[16].Visible = false;
                GridWeb1.HeaderRow.Cells[17].Visible = false;
                GridWeb1.HeaderRow.Cells[18].Visible = false;
            }

            int count = 0;
            for (int contador = 0; contador < wControl.Rows.Count; contador++)
            {
                GridViewRow row = wControl.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                row.Cells[15].Visible = false;
                row.Cells[16].Visible = false;
                row.Cells[17].Visible = false;
                row.Cells[18].Visible = false;
                bob1.BBuenas = row.Cells[11].Text;
                bob1.BMalas = row.Cells[12].Text;
                bob1.BMalas_QG = row.Cells[10].Text;
                bob1.Maquina = row.Cells[13].Text;//total de Peso
                bob1.NombreOT = row.Cells[14].Text;//Total de escarpe
                bob1.CProyecto = row.Cells[15].Text;
                bob1.SProyecto = row.Cells[16].Text;
                bob1.ProCProyec = row.Cells[17].Text;
                bob1.ProSProyec = row.Cells[18].Text;

                double PromedioBuenas = ((Convert.ToDouble(bob1.BMalas) * 100) / Convert.ToDouble(bob1.BBuenas));
                PromedioBuenas = Math.Round(PromedioBuenas);
                bob1.OT = PromedioBuenas.ToString("N0") + "%";

                double PromedioMalas = ((Convert.ToDouble(bob1.BMalas_QG) * 100) / Convert.ToDouble(bob1.BBuenas));
                PromedioMalas = Math.Round(PromedioMalas);
                bob1.Peso_Original = PromedioMalas.ToString("N0") + "%";

                double PromedioEscarpe = ((Convert.ToDouble(bob1.NombreOT)) / Convert.ToDouble(bob1.BBuenas));
                bob1.Pesos_Conos = PromedioEscarpe.ToString("N0");

                double escarpe = ((Convert.ToDouble(bob1.NombreOT) * 100) / Convert.ToDouble(bob1.Maquina));
                bob1.Pesos_Envoltura = escarpe.ToString("N1") + "%";

                

                if (count == 0)
                {
                    if (bob5.BBuenas != null)
                    {
                        bob5.BBuenas = (Convert.ToDouble(bob1.BBuenas.ToString()) + Convert.ToDouble(bob5.BBuenas.ToString())).ToString();
                        bob5.BMalas = (Convert.ToDouble(bob1.BMalas.ToString()) + Convert.ToDouble(bob5.BMalas.ToString())).ToString();
                        bob5.BMalas_QG = (Convert.ToDouble(bob1.BMalas_QG.ToString()) + Convert.ToDouble(bob5.BMalas_QG.ToString())).ToString();
                        bob5.Maquina = (Convert.ToDouble(bob1.Maquina.ToString()) + Convert.ToDouble(bob5.Maquina.ToString())).ToString();
                        bob5.NombreOT = (Convert.ToDouble(bob1.NombreOT.ToString()) + Convert.ToDouble(bob5.NombreOT.ToString())).ToString();

                        count = count + 1;
                    }
                    else
                    {
                        bob5.BBuenas = Convert.ToDouble(bob1.BBuenas.ToString()).ToString();
                        bob5.BMalas = Convert.ToDouble(bob1.BMalas.ToString()).ToString();
                        bob5.BMalas_QG = Convert.ToDouble(bob1.BMalas_QG.ToString()).ToString();
                        bob5.Maquina = Convert.ToDouble(bob1.Maquina.ToString()).ToString();
                        bob5.NombreOT = Convert.ToDouble(bob1.NombreOT.ToString()).ToString();
                        BobCProyect = Convert.ToInt32(bob1.CProyecto);
                        BobSProyect = Convert.ToInt32(bob1.SProyecto);
                        
                        bob5.ProCProyec = bob1.ProCProyec;
                        bob5.ProSProyec = bob1.ProSProyec;
                        count = count + 1;
                    }
                }
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
            count = 0;
            for (int contador = 0; contador < GridM600.Rows.Count; contador++)
            {
                GridViewRow row = GridM600.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                row.Cells[15].Visible = false;
                row.Cells[16].Visible = false;
                row.Cells[17].Visible = false;
                row.Cells[18].Visible = false;
                bob2.BBuenas = row.Cells[11].Text;
                bob2.BMalas = row.Cells[12].Text;
                bob2.BMalas_QG = row.Cells[10].Text;
                bob2.Maquina = row.Cells[13].Text;
                bob2.NombreOT = row.Cells[14].Text;

                double PromedioBuenas = ((Convert.ToDouble(bob2.BMalas) * 100) / Convert.ToDouble(bob2.BBuenas));
                PromedioBuenas = Math.Round(PromedioBuenas);
                bob2.OT = PromedioBuenas.ToString("N0") + "%";

                double PromedioMalas = ((Convert.ToDouble(bob2.BMalas_QG) * 100) / Convert.ToDouble(bob2.BBuenas));
                PromedioMalas = Math.Round(PromedioMalas);
                bob2.Peso_Original = PromedioMalas.ToString("N0") + "%";

                double PromedioEscarpe = ((Convert.ToDouble(bob2.NombreOT)) / Convert.ToDouble(bob2.BBuenas));
                bob2.Pesos_Conos = PromedioEscarpe.ToString("N0");

                double escarpe = ((Convert.ToDouble(bob2.NombreOT) * 100) / Convert.ToDouble(bob2.Maquina));
                bob2.Pesos_Envoltura = escarpe.ToString("N1") + "%";

                if (count == 0)
                {
                    if (bob5.BBuenas != null)
                    {
                        bob5.BBuenas = (Convert.ToDouble(bob2.BBuenas.ToString()) + Convert.ToDouble(bob5.BBuenas.ToString())).ToString();
                        bob5.BMalas = (Convert.ToDouble(bob2.BMalas.ToString()) + Convert.ToDouble(bob5.BMalas.ToString())).ToString();
                        bob5.BMalas_QG = (Convert.ToDouble(bob2.BMalas_QG.ToString()) + Convert.ToDouble(bob5.BMalas_QG.ToString())).ToString();
                        bob5.Maquina = (Convert.ToDouble(bob2.Maquina.ToString()) + Convert.ToDouble(bob5.Maquina.ToString())).ToString();
                        bob5.NombreOT = (Convert.ToDouble(bob2.NombreOT.ToString()) + Convert.ToDouble(bob5.NombreOT.ToString())).ToString();

                        count = count + 1;
                    }
                    else
                    {
                        bob5.BBuenas = Convert.ToDouble(bob2.BBuenas.ToString()).ToString();
                        bob5.BMalas = Convert.ToDouble(bob2.BMalas.ToString()).ToString();
                        bob5.BMalas_QG = Convert.ToDouble(bob2.BMalas_QG.ToString()).ToString();
                        bob5.Maquina = Convert.ToDouble(bob2.Maquina.ToString()).ToString();
                        bob5.NombreOT = Convert.ToDouble(bob2.NombreOT.ToString()).ToString();

                        count = count + 1;
                    }
                }

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
            count = 0;
            for (int contador = 0; contador < GridDimen.Rows.Count; contador++)
            {
                GridViewRow row = GridDimen.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                row.Cells[15].Visible = false;
                row.Cells[16].Visible = false;
                row.Cells[17].Visible = false;
                row.Cells[18].Visible = false;
                bob3.BBuenas = row.Cells[11].Text;
                bob3.BMalas = row.Cells[12].Text;
                bob3.BMalas_QG = row.Cells[10].Text;
                bob3.Maquina = row.Cells[13].Text;
                bob3.NombreOT = row.Cells[14].Text;

                double PromedioBuenas = ((Convert.ToDouble(bob3.BMalas) * 100) / Convert.ToDouble(bob3.BBuenas));
                PromedioBuenas = Math.Round(PromedioBuenas);
                bob3.OT = PromedioBuenas.ToString("N0") + "%";

                double PromedioMalas = ((Convert.ToDouble(bob3.BMalas_QG) * 100) / Convert.ToDouble(bob3.BBuenas));
                PromedioMalas = Math.Round(PromedioMalas);
                bob3.Peso_Original = PromedioMalas.ToString("N0") + "%";

                double PromedioEscarpe = ((Convert.ToDouble(bob3.NombreOT)) / Convert.ToDouble(bob3.BBuenas));
                bob3.Pesos_Conos = PromedioEscarpe.ToString("N0");

                double escarpe = ((Convert.ToDouble(bob3.NombreOT) * 100) / Convert.ToDouble(bob3.Maquina));
                bob3.Pesos_Envoltura = escarpe.ToString("N1") + "%";

                if (count == 0)
                {
                    if (bob5.BBuenas != null)
                    {
                        bob5.BBuenas = (Convert.ToDouble(bob3.BBuenas.ToString()) + Convert.ToDouble(bob5.BBuenas.ToString())).ToString();
                        bob5.BMalas = (Convert.ToDouble(bob3.BMalas.ToString()) + Convert.ToDouble(bob5.BMalas.ToString())).ToString();
                        bob5.BMalas_QG = (Convert.ToDouble(bob3.BMalas_QG.ToString()) + Convert.ToDouble(bob5.BMalas_QG.ToString())).ToString();
                        bob5.Maquina = (Convert.ToDouble(bob3.Maquina.ToString()) + Convert.ToDouble(bob5.Maquina.ToString())).ToString();
                        bob5.NombreOT = (Convert.ToDouble(bob3.NombreOT.ToString()) + Convert.ToDouble(bob5.NombreOT.ToString())).ToString();

                        count = count + 1;
                    }
                    else
                    {
                        bob5.BBuenas = Convert.ToDouble(bob3.BBuenas.ToString()).ToString();
                        bob5.BMalas = Convert.ToDouble(bob3.BMalas.ToString()).ToString();
                        bob5.BMalas_QG = Convert.ToDouble(bob3.BMalas_QG.ToString()).ToString();
                        bob5.Maquina = Convert.ToDouble(bob3.Maquina.ToString()).ToString();
                        bob5.NombreOT = Convert.ToDouble(bob3.NombreOT.ToString()).ToString();

                        count = count + 1;
                    }
                }

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
            count = 0;
            for (int contador = 0; contador < GridWeb1.Rows.Count; contador++)
            {
                GridViewRow row = GridWeb1.Rows[contador];
                row.Cells[1].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                row.Cells[15].Visible = false;
                row.Cells[16].Visible = false;
                row.Cells[17].Visible = false;
                row.Cells[18].Visible = false;
                bob4.BBuenas = row.Cells[11].Text;
                bob4.BMalas = row.Cells[12].Text;
                bob4.BMalas_QG = row.Cells[10].Text;
                bob4.Maquina = row.Cells[13].Text;
                bob4.NombreOT = row.Cells[14].Text;

                double PromedioBuenas = ((Convert.ToDouble(bob4.BMalas) * 100) / Convert.ToDouble(bob4.BBuenas));
                PromedioBuenas = Math.Round(PromedioBuenas);
                bob4.OT = PromedioBuenas.ToString("N0") + "%";

                double PromedioMalas = ((Convert.ToDouble(bob4.BMalas_QG) * 100) / Convert.ToDouble(bob4.BBuenas));
                PromedioMalas = Math.Round(PromedioMalas);
                bob4.Peso_Original = PromedioMalas.ToString("N0") + "%";

                double PromedioEscarpe = ((Convert.ToDouble(bob4.NombreOT)) / Convert.ToDouble(bob4.BBuenas));
                bob4.Pesos_Conos = PromedioEscarpe.ToString("N0");

                double escarpe = ((Convert.ToDouble(bob4.NombreOT) * 100) / Convert.ToDouble(bob4.Maquina));
                bob4.Pesos_Envoltura = escarpe.ToString("N1") + "%";

                if (count == 0)
                {
                    if (bob5.BBuenas != null)
                    {
                        bob5.BBuenas = (Convert.ToDouble(bob4.BBuenas.ToString()) + Convert.ToDouble(bob5.BBuenas.ToString())).ToString();
                        bob5.BMalas = (Convert.ToDouble(bob4.BMalas.ToString()) + Convert.ToDouble(bob5.BMalas.ToString())).ToString();
                        bob5.BMalas_QG = (Convert.ToDouble(bob4.BMalas_QG.ToString()) + Convert.ToDouble(bob5.BMalas_QG.ToString())).ToString();
                        bob5.Maquina = (Convert.ToDouble(bob4.Maquina.ToString()) + Convert.ToDouble(bob5.Maquina.ToString())).ToString();
                        bob5.NombreOT = (Convert.ToDouble(bob4.NombreOT.ToString()) + Convert.ToDouble(bob5.NombreOT.ToString())).ToString();

                        count = count + 1;
                    }
                    else
                    {
                        bob5.BBuenas = Convert.ToDouble(bob4.BBuenas.ToString()).ToString();
                        bob5.BMalas = Convert.ToDouble(bob4.BMalas.ToString()).ToString();
                        bob5.BMalas_QG = Convert.ToDouble(bob4.BMalas_QG.ToString()).ToString();
                        bob5.Maquina = Convert.ToDouble(bob4.Maquina.ToString()).ToString();
                        bob5.NombreOT = Convert.ToDouble(bob4.NombreOT.ToString()).ToString();
                        count = count + 1;
                    }
                }

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
            count = 0;
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
                                    "<td style='border:1px solid black;'>" + bob1.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.BMalas_QG.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.Maquina.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.OT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + bob1.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
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
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.BMalas_QG.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.Maquina.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.OT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + bob2.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
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
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.BMalas_QG.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.Maquina.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.OT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + bob3.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
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
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.BMalas_QG.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.Maquina.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.OT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + bob4.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
                form.Controls.Add(TaTotWeb1);
            }
            if (bob5.BBuenas.ToString() != null)
            {
                double PromedioBuenas = ((Convert.ToDouble(bob5.BMalas) * 100) / Convert.ToDouble(bob5.BBuenas));
                PromedioBuenas = Math.Round(PromedioBuenas);
                bob5.OT = PromedioBuenas.ToString("N0") + "%";

                double PromedioMalas = ((Convert.ToDouble(bob5.BMalas_QG) * 100) / Convert.ToDouble(bob5.BBuenas));
                PromedioMalas = Math.Round(PromedioMalas);
                bob5.Peso_Original = PromedioMalas.ToString("N0") + "%";

                double PromedioEscarpe = ((Convert.ToDouble(bob5.NombreOT)) / Convert.ToDouble(bob5.BBuenas));
                bob5.Pesos_Conos = PromedioEscarpe.ToString("N0");

                double escarpe = ((Convert.ToDouble(bob5.NombreOT) * 100) / Convert.ToDouble(PesoTotalOrig));//bob5.Maquina));
                bob5.Pesos_Envoltura = escarpe.ToString("N1") + "%";


                Label TaTotGeneral = new Label();
                TaTotGeneral.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='3'>General</td>" +
                                    "</tr><tr>" +
                                    "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.BBuenas.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.BMalas.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.BMalas_QG.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + PesoTotalOrig.ToString("N0").Replace(",", ".") + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.NombreOT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.OT.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.Peso_Original.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.Pesos_Envoltura.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobina Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + BobCProyect.ToString("N0").Replace(",", ".") + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobina Sin Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + BobSProyect.ToString("N0").Replace(",", ".") + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total % Con Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.ProCProyec.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total % Sin Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + bob5.ProSProyec.ToString() + "</td></tr></table></div>";
                                    //"<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Peso Total Bobi</td>" +
                                    //"<td style='border:1px solid black;'>" + PesoTotalOrig.ToString("N0").Replace(",", ".") + "</td></tr></table></div>";
                form.Controls.Add(TaTotGeneral);
            }

            //Label TotalEscalpe = new Label();
            //TotalEscalpe.Text = "<br/><div align='center'>"+PesoTotalOrig.ToString("N0").Replace(",",".")+"</div><br/>";
            //form.Controls.Add(TotalEscalpe);
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