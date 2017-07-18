using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloRFrecuencia.Model;
using Intranet.ModuloRFrecuencia.Controller;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_WarRom : System.Web.UI.Page
    {
        Bobina_Controller controlbob = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
                string Ayer = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

                CargarRegistros(Ayer);
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
                Label1.Text="";
            }

        }

        public void CargarRegistros(string Dia)
        {
            try
            {
                RadGrid1.DataSource = controlbob.ListBobina_WarRom(Dia);
                RadGrid1.DataBind();
            }
            catch (Exception e)
            {
                string popupScript = "<script language='JavaScript'>alert('"+e.Message+"');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
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
            double TotalEscarpeExt = 0;
            double PromedioEscarpeInt = 0;
            try
            {
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
                }
                catch { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL"); }
                #region Grillas
                int PesoTotalOrig = 0;
                int BobCProyect = 0;
                int BobSProyect = 0;
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

                    f1 = año + "-" + mes + "-" + dia;//Convert.ToDateTime(fechaInicio);
                    //txtCliente.Text = mes + "/" + dia + "/" + año;

                    PesoTotalOrig = controlbob.PesoOriginalTB(f1);
                }
                else
                {
                    f1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");   
                    PesoTotalOrig = controlbob.PesoOriginalTB(f1);
                }
                List<Bobina_Excel> lista = controlbob.ListBobina_WarRom(f1);

                List<Bobina_Excel> listaDimen = lista.Where(o => o.Maquina.ToUpper() == "DIMENSIONADORA").ToList();
                List<Bobina_Excel> listaM600 = lista.Where(o => o.Maquina.ToUpper() == "M600").ToList();
                List<Bobina_Excel> listaLitho = lista.Where(o => o.Maquina.ToUpper() == "LITHOMAN").ToList();
                List<Bobina_Excel> listaWeb1 = lista.Where(o => o.Maquina.ToUpper() == "WEB 1").ToList();
                List<Bobina_Excel> listaWeb2 = lista.Where(o => o.Maquina.ToUpper() == "WEB 2").ToList();

                Bobina_Excel bob1 = new Bobina_Excel();
                Bobina_Excel bob2 = new Bobina_Excel();
                Bobina_Excel bob3 = new Bobina_Excel();
                Bobina_Excel bob4 = new Bobina_Excel();
                Bobina_Excel bob5 = new Bobina_Excel();
                Bobina_Excel bob6 = new Bobina_Excel();

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

                GridView GridWeb2 = new GridView();
                GridWeb2.DataSource = listaWeb2;
                GridWeb2.DataBind();
                GridWeb2.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridWeb2.HeaderStyle.ForeColor = System.Drawing.Color.White;
                //Inicio del Excel 

                if (wControl.Rows.Count > 0)
                {
                    wControl.HeaderRow.Cells[0].Text = "Código Bobina";
                    wControl.HeaderRow.Cells[1].Visible = false;
                    wControl.HeaderRow.Cells[2].Text = "Nombre Papel";
                    wControl.HeaderRow.Cells[3].Text = "Gramaje";
                    wControl.HeaderRow.Cells[4].Text = "Ancho";
                    wControl.HeaderRow.Cells[5].Text = "Peso Bobina";
                    wControl.HeaderRow.Cells[6].Text = "Consumo";
                    wControl.HeaderRow.Cells[7].Text = "Estado Bobina";
                    wControl.HeaderRow.Cells[8].Text = "Origen Daño";
                    wControl.HeaderRow.Cells[9].Text = "Causa Daño";
                    wControl.HeaderRow.Cells[10].Visible = false;
                    wControl.HeaderRow.Cells[11].Visible = false;
                    wControl.HeaderRow.Cells[12].Visible = false;
                    wControl.HeaderRow.Cells[13].Visible = false;
                    wControl.HeaderRow.Cells[14].Visible = false;
                    wControl.HeaderRow.Cells[15].Visible = false;
                    wControl.HeaderRow.Cells[16].Visible = false;
                    wControl.HeaderRow.Cells[17].Visible = false;
                    wControl.HeaderRow.Cells[18].Visible = false;
                    wControl.HeaderRow.Cells[19].Text = "Kilos Escarpe";
                    wControl.HeaderRow.Cells[20].Text = "% Perdida";
                }

                if (GridM600.Rows.Count > 0)
                {
                    GridM600.HeaderRow.Cells[0].Text = "Código Bobina";
                    GridM600.HeaderRow.Cells[1].Visible = false;
                    GridM600.HeaderRow.Cells[2].Text = "Nombre Papel";
                    GridM600.HeaderRow.Cells[3].Text = "Gramaje";
                    GridM600.HeaderRow.Cells[4].Text = "Ancho";
                    GridM600.HeaderRow.Cells[5].Text = "Peso Bobina";
                    GridM600.HeaderRow.Cells[6].Text = "Consumo";
                    GridM600.HeaderRow.Cells[7].Text = "Estado Bobina";
                    GridM600.HeaderRow.Cells[8].Text = "Origen Daño";
                    GridM600.HeaderRow.Cells[9].Text = "Causa Daño";
                    GridM600.HeaderRow.Cells[10].Visible = false;
                    GridM600.HeaderRow.Cells[11].Visible = false;
                    GridM600.HeaderRow.Cells[12].Visible = false;
                    GridM600.HeaderRow.Cells[13].Visible = false;
                    GridM600.HeaderRow.Cells[14].Visible = false;
                    GridM600.HeaderRow.Cells[15].Visible = false;
                    GridM600.HeaderRow.Cells[16].Visible = false;
                    GridM600.HeaderRow.Cells[17].Visible = false;
                    GridM600.HeaderRow.Cells[18].Visible = false;
                    GridM600.HeaderRow.Cells[19].Text = "Kilos Escarpe";
                    GridM600.HeaderRow.Cells[20].Text = "% Perdida";
                }

                if (GridDimen.Rows.Count > 0)
                {
                    GridDimen.HeaderRow.Cells[0].Text = "Código Bobina";
                    GridDimen.HeaderRow.Cells[1].Visible = false;
                    GridDimen.HeaderRow.Cells[2].Text = "Nombre Papel";
                    GridDimen.HeaderRow.Cells[3].Text = "Gramaje";
                    GridDimen.HeaderRow.Cells[4].Text = "Ancho";
                    GridDimen.HeaderRow.Cells[5].Text = "Peso Bobina";
                    GridDimen.HeaderRow.Cells[6].Text = "Consumo";
                    GridDimen.HeaderRow.Cells[7].Text = "Estado Bobina";
                    GridDimen.HeaderRow.Cells[8].Text = "Origen Daño";
                    GridDimen.HeaderRow.Cells[9].Text = "Causa Daño";
                    GridDimen.HeaderRow.Cells[10].Visible = false;
                    GridDimen.HeaderRow.Cells[11].Visible = false;
                    GridDimen.HeaderRow.Cells[12].Visible = false;
                    GridDimen.HeaderRow.Cells[13].Visible = false;
                    GridDimen.HeaderRow.Cells[14].Visible = false;
                    GridDimen.HeaderRow.Cells[15].Visible = false;
                    GridDimen.HeaderRow.Cells[16].Visible = false;
                    GridDimen.HeaderRow.Cells[17].Visible = false;
                    GridDimen.HeaderRow.Cells[18].Visible = false;
                    GridDimen.HeaderRow.Cells[19].Text = "Kilos Escarpe";
                    GridDimen.HeaderRow.Cells[20].Text = "% Perdida";
                }

                if (GridWeb1.Rows.Count > 0)
                {
                    GridWeb1.HeaderRow.Cells[0].Text = "Código Bobina";
                    GridWeb1.HeaderRow.Cells[1].Visible = false;
                    GridWeb1.HeaderRow.Cells[2].Text = "Nombre Papel";
                    GridWeb1.HeaderRow.Cells[3].Text = "Gramaje";
                    GridWeb1.HeaderRow.Cells[4].Text = "Ancho";
                    GridWeb1.HeaderRow.Cells[5].Text = "Peso Bobina";
                    GridWeb1.HeaderRow.Cells[6].Text = "Consumo";
                    GridWeb1.HeaderRow.Cells[7].Text = "Estado Bobina";
                    GridWeb1.HeaderRow.Cells[8].Text = "Origen Daño";
                    GridWeb1.HeaderRow.Cells[9].Text = "Causa Daño";
                    GridWeb1.HeaderRow.Cells[10].Visible = false;
                    GridWeb1.HeaderRow.Cells[11].Visible = false;
                    GridWeb1.HeaderRow.Cells[12].Visible = false;
                    GridWeb1.HeaderRow.Cells[13].Visible = false;
                    GridWeb1.HeaderRow.Cells[14].Visible = false;
                    GridWeb1.HeaderRow.Cells[15].Visible = false;
                    GridWeb1.HeaderRow.Cells[16].Visible = false;
                    GridWeb1.HeaderRow.Cells[17].Visible = false;
                    GridWeb1.HeaderRow.Cells[18].Visible = false;
                    GridWeb1.HeaderRow.Cells[19].Text = "Kilos Escarpe";
                    GridWeb1.HeaderRow.Cells[20].Text = "% Perdida";
                }

                if (GridWeb2.Rows.Count > 0)
                {
                    GridWeb2.HeaderRow.Cells[0].Text = "Código Bobina";
                    GridWeb2.HeaderRow.Cells[1].Visible = false;
                    GridWeb2.HeaderRow.Cells[2].Text = "Nombre Papel";
                    GridWeb2.HeaderRow.Cells[3].Text = "Gramaje";
                    GridWeb2.HeaderRow.Cells[4].Text = "Ancho";
                    GridWeb2.HeaderRow.Cells[5].Text = "Peso Bobina";
                    GridWeb2.HeaderRow.Cells[6].Text = "Consumo";
                    GridWeb2.HeaderRow.Cells[7].Text = "Estado Bobina";
                    GridWeb2.HeaderRow.Cells[8].Text = "Origen Daño";
                    GridWeb2.HeaderRow.Cells[9].Text = "Causa Daño";
                    GridWeb2.HeaderRow.Cells[10].Visible = false;
                    GridWeb2.HeaderRow.Cells[11].Visible = false;
                    GridWeb2.HeaderRow.Cells[12].Visible = false;
                    GridWeb2.HeaderRow.Cells[13].Visible = false;
                    GridWeb2.HeaderRow.Cells[14].Visible = false;
                    GridWeb2.HeaderRow.Cells[15].Visible = false;
                    GridWeb2.HeaderRow.Cells[16].Visible = false;
                    GridWeb2.HeaderRow.Cells[17].Visible = false;
                    GridWeb2.HeaderRow.Cells[18].Visible = false;
                    GridWeb2.HeaderRow.Cells[19].Text = "Kilos Escarpe";
                    GridWeb2.HeaderRow.Cells[20].Text = "% Perdida";
                }
                #endregion
                #region ForeachGrillas
                int count = 0;
                for (int contador = 0; contador < wControl.Rows.Count; contador++)
                {
                    GridViewRow row = wControl.Rows[contador];
                    string BobinaPeso = row.Cells[4].Text;
                    string EstadoBobina = row.Cells[5].Text;
                    string Origen = row.Cells[6].Text;
                    string Causa = row.Cells[7].Text;
                    string KiloEscarpe = row.Cells[8].Text;
                    string Perdida = row.Cells[9].Text;
                    row.Cells[4].Text = row.Cells[20].Text;
                    row.Cells[5].Text = BobinaPeso;
                    row.Cells[6].Text = row.Cells[19].Text;
                    row.Cells[7].Text = EstadoBobina;
                    row.Cells[8].Text = Origen;
                    row.Cells[9].Text = Causa;
                    row.Cells[19].Text = KiloEscarpe;
                    row.Cells[20].Text = Perdida;
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
                    bob1.BMalas = (Convert.ToInt32(row.Cells[11].Text) - Convert.ToInt32(row.Cells[10].Text)).ToString();
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
                    bob1.Pesos_Conos = PromedioEscarpe.ToString("N1");

                    double escarpe = ((Convert.ToDouble(bob1.NombreOT) * 100) / Convert.ToDouble(bob1.Maquina));
                    bob1.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    double PesoOriginal = Convert.ToDouble(row.Cells[5].Text);
                    if (row.Cells[5].Text.Length > 3)
                    {
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    else
                    {
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }

                    if (count == 0)
                    {
                        if (bob6.BBuenas != null)
                        {
                            bob6.BBuenas = (Convert.ToDouble(bob1.BBuenas.ToString()) + Convert.ToDouble(bob6.BBuenas.ToString())).ToString();
                            bob6.BMalas = (Convert.ToDouble(bob1.BMalas.ToString()) + Convert.ToDouble(bob6.BMalas.ToString())).ToString();
                            bob6.BMalas_QG = (Convert.ToDouble(bob1.BMalas_QG.ToString()) + Convert.ToDouble(bob6.BMalas_QG.ToString())).ToString();
                            bob6.Maquina = (Convert.ToDouble(bob1.Maquina.ToString()) + Convert.ToDouble(bob6.Maquina.ToString())).ToString();
                            bob6.NombreOT = (Convert.ToDouble(bob1.NombreOT.ToString()) + Convert.ToDouble(bob6.NombreOT.ToString())).ToString();

                            count = count + 1;
                        }
                        else
                        {
                            bob6.BBuenas = Convert.ToDouble(bob1.BBuenas.ToString()).ToString();
                            bob6.BMalas = Convert.ToDouble(bob1.BMalas.ToString()).ToString();
                            bob6.BMalas_QG = Convert.ToDouble(bob1.BMalas_QG.ToString()).ToString();
                            bob6.Maquina = Convert.ToDouble(bob1.Maquina.ToString()).ToString();
                            bob6.NombreOT = Convert.ToDouble(bob1.NombreOT.ToString()).ToString();
                            BobCProyect = Convert.ToInt32(bob1.CProyecto);
                            BobSProyect = Convert.ToInt32(bob1.SProyecto);

                            bob6.ProCProyec = bob1.ProCProyec;
                            bob6.ProSProyec = bob1.ProSProyec;
                            count = count + 1;
                        }
                    }

                }

                count = 0;
                for (int contador = 0; contador < GridM600.Rows.Count; contador++)
                {
                    GridViewRow row = GridM600.Rows[contador];
                    string BobinaPeso = row.Cells[4].Text;
                    string EstadoBobina = row.Cells[5].Text;
                    string Origen = row.Cells[6].Text;
                    string Causa = row.Cells[7].Text;
                    string KiloEscarpe = row.Cells[8].Text;
                    string Perdida = row.Cells[9].Text;
                    row.Cells[4].Text = row.Cells[20].Text;
                    row.Cells[5].Text = BobinaPeso;
                    row.Cells[6].Text = row.Cells[19].Text;
                    row.Cells[7].Text = EstadoBobina;
                    row.Cells[8].Text = Origen;
                    row.Cells[9].Text = Causa;
                    row.Cells[19].Text = KiloEscarpe;
                    row.Cells[20].Text = Perdida;
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
                    bob2.BMalas = (Convert.ToInt32(row.Cells[11].Text) - Convert.ToInt32(row.Cells[10].Text)).ToString();
                    bob2.BMalas_QG = row.Cells[10].Text;
                    bob2.Maquina = row.Cells[13].Text;
                    bob2.NombreOT = row.Cells[14].Text;
                    bob1.CProyecto = row.Cells[15].Text;
                    bob1.SProyecto = row.Cells[16].Text;
                    bob1.ProCProyec = row.Cells[17].Text;
                    bob1.ProSProyec = row.Cells[18].Text;

                    double PromedioBuenas = ((Convert.ToDouble(bob2.BMalas) * 100) / Convert.ToDouble(bob2.BBuenas));
                    PromedioBuenas = Math.Round(PromedioBuenas);
                    bob2.OT = PromedioBuenas.ToString("N0") + "%";

                    double PromedioMalas = ((Convert.ToDouble(bob2.BMalas_QG) * 100) / Convert.ToDouble(bob2.BBuenas));
                    PromedioMalas = Math.Round(PromedioMalas);
                    bob2.Peso_Original = PromedioMalas.ToString("N0") + "%";

                    double PromedioEscarpe = ((Convert.ToDouble(bob2.NombreOT)) / Convert.ToDouble(bob2.BBuenas));
                    bob2.Pesos_Conos = PromedioEscarpe.ToString("N1");

                    double escarpe = ((Convert.ToDouble(bob2.NombreOT) * 100) / Convert.ToDouble(bob2.Maquina));
                    bob2.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    double PesoOriginal = Convert.ToDouble(row.Cells[5].Text);
                    if (row.Cells[5].Text.Length > 3)
                    {
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    else
                    {
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    if (count == 0)
                    {
                        if (bob6.BBuenas != null)
                        {
                            bob6.BBuenas = (Convert.ToDouble(bob2.BBuenas.ToString()) + Convert.ToDouble(bob6.BBuenas.ToString())).ToString();
                            bob6.BMalas = (Convert.ToDouble(bob2.BMalas.ToString()) + Convert.ToDouble(bob6.BMalas.ToString())).ToString();
                            bob6.BMalas_QG = (Convert.ToDouble(bob2.BMalas_QG.ToString()) + Convert.ToDouble(bob6.BMalas_QG.ToString())).ToString();
                            bob6.Maquina = (Convert.ToDouble(bob2.Maquina.ToString()) + Convert.ToDouble(bob6.Maquina.ToString())).ToString();
                            bob6.NombreOT = (Convert.ToDouble(bob2.NombreOT.ToString()) + Convert.ToDouble(bob6.NombreOT.ToString())).ToString();

                            count = count + 1;
                        }
                        else
                        {
                            bob6.BBuenas = Convert.ToDouble(bob2.BBuenas.ToString()).ToString();
                            bob6.BMalas = Convert.ToDouble(bob2.BMalas.ToString()).ToString();
                            bob6.BMalas_QG = Convert.ToDouble(bob2.BMalas_QG.ToString()).ToString();
                            bob6.Maquina = Convert.ToDouble(bob2.Maquina.ToString()).ToString();
                            bob6.NombreOT = Convert.ToDouble(bob2.NombreOT.ToString()).ToString();
                            BobCProyect = Convert.ToInt32(bob1.CProyecto);
                            BobSProyect = Convert.ToInt32(bob1.SProyecto);

                            bob6.ProCProyec = bob1.ProCProyec;
                            bob6.ProSProyec = bob1.ProSProyec;
                            count = count + 1;
                        }
                    }


                }
                count = 0;
                for (int contador = 0; contador < GridDimen.Rows.Count; contador++)
                {
                    GridViewRow row = GridDimen.Rows[contador];
                    string BobinaPeso = row.Cells[4].Text;
                    string EstadoBobina = row.Cells[5].Text;
                    string Origen = row.Cells[6].Text;
                    string Causa = row.Cells[7].Text;
                    string KiloEscarpe = row.Cells[8].Text;
                    string Perdida = row.Cells[9].Text;
                    row.Cells[4].Text = row.Cells[20].Text;
                    row.Cells[5].Text = BobinaPeso;
                    row.Cells[6].Text = row.Cells[19].Text;
                    row.Cells[7].Text = EstadoBobina;
                    row.Cells[8].Text = Origen;
                    row.Cells[9].Text = Causa;
                    row.Cells[19].Text = KiloEscarpe;
                    row.Cells[20].Text = Perdida;
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
                    bob3.BMalas = (Convert.ToInt32(row.Cells[11].Text) - Convert.ToInt32(row.Cells[10].Text)).ToString();
                    bob3.BMalas_QG = row.Cells[10].Text;
                    bob3.Maquina = row.Cells[13].Text;
                    bob3.NombreOT = row.Cells[14].Text;
                    bob1.CProyecto = row.Cells[15].Text;
                    bob1.SProyecto = row.Cells[16].Text;
                    bob1.ProCProyec = row.Cells[17].Text;
                    bob1.ProSProyec = row.Cells[18].Text;

                    double PromedioBuenas = ((Convert.ToDouble(bob3.BMalas) * 100) / Convert.ToDouble(bob3.BBuenas));
                    PromedioBuenas = Math.Round(PromedioBuenas);
                    bob3.OT = PromedioBuenas.ToString("N0") + "%";

                    double PromedioMalas = ((Convert.ToDouble(bob3.BMalas_QG) * 100) / Convert.ToDouble(bob3.BBuenas));
                    PromedioMalas = Math.Round(PromedioMalas);
                    bob3.Peso_Original = PromedioMalas.ToString("N0") + "%";

                    double PromedioEscarpe = ((Convert.ToDouble(bob3.NombreOT)) / Convert.ToDouble(bob3.BBuenas));
                    bob3.Pesos_Conos = PromedioEscarpe.ToString("N1");

                    double escarpe = ((Convert.ToDouble(bob3.NombreOT) * 100) / Convert.ToDouble(bob3.Maquina));
                    bob3.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    double PesoOriginal = Convert.ToDouble(row.Cells[5].Text);
                    if (row.Cells[5].Text.Length > 3)
                    {
                        string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    else
                    {
                        string po2 = PesoOriginal.ToString("N0");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    if (count == 0)
                    {
                        if (bob6.BBuenas != null)
                        {
                            bob6.BBuenas = (Convert.ToDouble(bob3.BBuenas.ToString()) + Convert.ToDouble(bob6.BBuenas.ToString())).ToString();
                            bob6.BMalas = (Convert.ToDouble(bob3.BMalas.ToString()) + Convert.ToDouble(bob6.BMalas.ToString())).ToString();
                            bob6.BMalas_QG = (Convert.ToDouble(bob3.BMalas_QG.ToString()) + Convert.ToDouble(bob6.BMalas_QG.ToString())).ToString();
                            bob6.Maquina = (Convert.ToDouble(bob3.Maquina.ToString()) + Convert.ToDouble(bob6.Maquina.ToString())).ToString();
                            bob6.NombreOT = (Convert.ToDouble(bob3.NombreOT.ToString()) + Convert.ToDouble(bob6.NombreOT.ToString())).ToString();

                            count = count + 1;
                        }
                        else
                        {
                            bob6.BBuenas = Convert.ToDouble(bob3.BBuenas.ToString()).ToString();
                            bob6.BMalas = Convert.ToDouble(bob3.BMalas.ToString()).ToString();
                            bob6.BMalas_QG = Convert.ToDouble(bob3.BMalas_QG.ToString()).ToString();
                            bob6.Maquina = Convert.ToDouble(bob3.Maquina.ToString()).ToString();
                            bob6.NombreOT = Convert.ToDouble(bob3.NombreOT.ToString()).ToString();
                            BobCProyect = Convert.ToInt32(bob1.CProyecto);
                            BobSProyect = Convert.ToInt32(bob1.SProyecto);

                            bob6.ProCProyec = bob1.ProCProyec;
                            bob6.ProSProyec = bob1.ProSProyec;
                            count = count + 1;
                        }
                    }


                }
                count = 0;
                for (int contador = 0; contador < GridWeb1.Rows.Count; contador++)
                {
                    GridViewRow row = GridWeb1.Rows[contador];
                    string BobinaPeso = row.Cells[4].Text;
                    string EstadoBobina = row.Cells[5].Text;
                    string Origen = row.Cells[6].Text;
                    string Causa = row.Cells[7].Text;
                    string KiloEscarpe = row.Cells[8].Text;
                    string Perdida = row.Cells[9].Text;
                    row.Cells[4].Text = row.Cells[20].Text;
                    row.Cells[5].Text = BobinaPeso;
                    row.Cells[6].Text = row.Cells[19].Text;
                    row.Cells[7].Text = EstadoBobina;
                    row.Cells[8].Text = Origen;
                    row.Cells[9].Text = Causa;
                    row.Cells[19].Text = KiloEscarpe;
                    row.Cells[20].Text = Perdida;
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
                    bob4.BMalas = (Convert.ToInt32(row.Cells[11].Text) - Convert.ToInt32(row.Cells[10].Text)).ToString();
                    bob4.BMalas_QG = row.Cells[10].Text;
                    bob4.Maquina = row.Cells[13].Text;
                    bob4.NombreOT = row.Cells[14].Text;
                    bob1.CProyecto = row.Cells[15].Text;
                    bob1.SProyecto = row.Cells[16].Text;
                    bob1.ProCProyec = row.Cells[17].Text;
                    bob1.ProSProyec = row.Cells[18].Text;

                    double PromedioBuenas = ((Convert.ToDouble(bob4.BMalas) * 100) / Convert.ToDouble(bob4.BBuenas));
                    PromedioBuenas = Math.Round(PromedioBuenas);
                    bob4.OT = PromedioBuenas.ToString("N0") + "%";

                    double PromedioMalas = ((Convert.ToDouble(bob4.BMalas_QG) * 100) / Convert.ToDouble(bob4.BBuenas));
                    PromedioMalas = Math.Round(PromedioMalas);
                    bob4.Peso_Original = PromedioMalas.ToString("N0") + "%";

                    double PromedioEscarpe = ((Convert.ToDouble(bob4.NombreOT)) / Convert.ToDouble(bob4.BBuenas));
                    bob4.Pesos_Conos = PromedioEscarpe.ToString("N1");

                    double escarpe = ((Convert.ToDouble(bob4.NombreOT) * 100) / Convert.ToDouble(bob4.Maquina));
                    bob4.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    double PesoOriginal = Convert.ToDouble(row.Cells[5].Text);
                    if (row.Cells[5].Text.Length > 3)
                    {
                        string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    else
                    {
                        string po2 = PesoOriginal.ToString("N0");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    if (count == 0)
                    {
                        if (bob6.BBuenas != null)
                        {
                            bob6.BBuenas = (Convert.ToDouble(bob4.BBuenas.ToString()) + Convert.ToDouble(bob6.BBuenas.ToString())).ToString();
                            bob6.BMalas = (Convert.ToDouble(bob4.BMalas.ToString()) + Convert.ToDouble(bob6.BMalas.ToString())).ToString();
                            bob6.BMalas_QG = (Convert.ToDouble(bob4.BMalas_QG.ToString()) + Convert.ToDouble(bob6.BMalas_QG.ToString())).ToString();
                            bob6.Maquina = (Convert.ToDouble(bob4.Maquina.ToString()) + Convert.ToDouble(bob6.Maquina.ToString())).ToString();
                            bob6.NombreOT = (Convert.ToDouble(bob4.NombreOT.ToString()) + Convert.ToDouble(bob6.NombreOT.ToString())).ToString();

                            count = count + 1;
                        }
                        else
                        {
                            bob6.BBuenas = Convert.ToDouble(bob4.BBuenas.ToString()).ToString();
                            bob6.BMalas = Convert.ToDouble(bob4.BMalas.ToString()).ToString();
                            bob6.BMalas_QG = Convert.ToDouble(bob4.BMalas_QG.ToString()).ToString();
                            bob6.Maquina = Convert.ToDouble(bob4.Maquina.ToString()).ToString();
                            bob6.NombreOT = Convert.ToDouble(bob4.NombreOT.ToString()).ToString();
                            BobCProyect = Convert.ToInt32(bob1.CProyecto);
                            BobSProyect = Convert.ToInt32(bob1.SProyecto);

                            bob6.ProCProyec = bob1.ProCProyec;
                            bob6.ProSProyec = bob1.ProSProyec;
                            count = count + 1;
                        }
                    }


                }

                count = 0;
                for (int contador = 0; contador < GridWeb2.Rows.Count; contador++)
                {
                    GridViewRow row = GridWeb2.Rows[contador];
                    string BobinaPeso = row.Cells[4].Text;
                    string EstadoBobina = row.Cells[5].Text;
                    string Origen = row.Cells[6].Text;
                    string Causa = row.Cells[7].Text;
                    string KiloEscarpe = row.Cells[8].Text;
                    string Perdida = row.Cells[9].Text;
                    row.Cells[4].Text = row.Cells[20].Text;
                    row.Cells[5].Text = BobinaPeso;
                    row.Cells[6].Text = row.Cells[19].Text;
                    row.Cells[7].Text = EstadoBobina;
                    row.Cells[8].Text = Origen;
                    row.Cells[9].Text = Causa;
                    row.Cells[19].Text = KiloEscarpe;
                    row.Cells[20].Text = Perdida;
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
                    bob5.BBuenas = row.Cells[11].Text;
                    bob5.BMalas = (Convert.ToInt32(row.Cells[11].Text) - Convert.ToInt32(row.Cells[10].Text)).ToString();
                    bob5.BMalas_QG = row.Cells[10].Text;
                    bob5.Maquina = row.Cells[13].Text;
                    bob5.NombreOT = row.Cells[14].Text;
                    bob1.CProyecto = row.Cells[15].Text;
                    bob1.SProyecto = row.Cells[16].Text;
                    bob1.ProCProyec = row.Cells[17].Text;
                    bob1.ProSProyec = row.Cells[18].Text;

                    double PromedioBuenas = ((Convert.ToDouble(bob5.BMalas) * 100) / Convert.ToDouble(bob5.BBuenas));
                    PromedioBuenas = Math.Round(PromedioBuenas);
                    bob5.OT = PromedioBuenas.ToString("N0") + "%";

                    double PromedioMalas = ((Convert.ToDouble(bob5.BMalas_QG) * 100) / Convert.ToDouble(bob5.BBuenas));
                    PromedioMalas = Math.Round(PromedioMalas);
                    bob5.Peso_Original = PromedioMalas.ToString("N0") + "%";

                    double PromedioEscarpe = ((Convert.ToDouble(bob5.NombreOT)) / Convert.ToDouble(bob5.BBuenas));
                    bob5.Pesos_Conos = PromedioEscarpe.ToString("N1");

                    double escarpe = ((Convert.ToDouble(bob5.NombreOT) * 100) / Convert.ToDouble(bob5.Maquina));
                    bob5.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    double PesoOriginal = Convert.ToDouble(row.Cells[5].Text);
                    if (row.Cells[5].Text.Length > 3)
                    {
                        string po2 = PesoOriginal.ToString("N0").Replace(",", ".");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    else
                    {
                        string po2 = PesoOriginal.ToString("N0");
                        row.Cells[5].Text = row.Cells[5].Text.Replace(",", "").Replace(".", "");
                    }
                    if (count == 0)
                    {
                        if (bob6.BBuenas != null)
                        {
                            bob6.BBuenas = (Convert.ToDouble(bob5.BBuenas.ToString()) + Convert.ToDouble(bob6.BBuenas.ToString())).ToString();
                            bob6.BMalas = (Convert.ToDouble(bob5.BMalas.ToString()) + Convert.ToDouble(bob6.BMalas.ToString())).ToString();
                            bob6.BMalas_QG = (Convert.ToDouble(bob5.BMalas_QG.ToString()) + Convert.ToDouble(bob6.BMalas_QG.ToString())).ToString();
                            bob6.Maquina = (Convert.ToDouble(bob5.Maquina.ToString()) + Convert.ToDouble(bob6.Maquina.ToString())).ToString();
                            bob6.NombreOT = (Convert.ToDouble(bob5.NombreOT.ToString()) + Convert.ToDouble(bob6.NombreOT.ToString())).ToString();

                            count = count + 1;
                        }
                        else
                        {
                            bob6.BBuenas = Convert.ToDouble(bob5.BBuenas.ToString()).ToString();
                            bob6.BMalas = Convert.ToDouble(bob5.BMalas.ToString()).ToString();
                            bob6.BMalas_QG = Convert.ToDouble(bob5.BMalas_QG.ToString()).ToString();
                            bob6.Maquina = Convert.ToDouble(bob5.Maquina.ToString()).ToString();
                            bob6.NombreOT = Convert.ToDouble(bob5.NombreOT.ToString()).ToString();
                            BobCProyect = Convert.ToInt32(bob1.CProyecto);
                            BobSProyect = Convert.ToInt32(bob1.SProyecto);

                            bob6.ProCProyec = bob1.ProCProyec;
                            bob6.ProSProyec = bob1.ProSProyec;
                            count = count + 1;
                        }
                    }


                }
                #endregion
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

                if (GridWeb2.Rows.Count > 0)
                {
                    Label Maquina5 = new Label();
                    Maquina5.Text = "<br/><div align='left'>Web 2 </div><br/>";
                    form.Controls.Add(Maquina5);
                    form.Controls.Add(GridWeb2);
                    Label TaTotWeb2 = new Label();
                    TaTotWeb2.Text = "<br/><div align='right'><table><tr>" +
                                        "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.BBuenas.ToString() + "</div></td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.BMalas.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.BMalas_QG.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.Maquina.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Ponderado</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.NombreOT.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.OT.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.Peso_Original.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.Pesos_Conos.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                        "<td style='border:1px solid black;'>" + bob5.Pesos_Envoltura.ToString() + "</td></tr></table></div>";
                    form.Controls.Add(TaTotWeb2);
                }
                if (bob6.BBuenas.ToString() != null)
                {
                    double PromedioBuenas = ((Convert.ToDouble(bob6.BMalas) * 100) / Convert.ToDouble(bob6.BBuenas));
                    PromedioBuenas = Math.Round(PromedioBuenas);
                    bob6.OT = PromedioBuenas.ToString("N0") + "%";

                    double PromedioMalas = ((Convert.ToDouble(bob6.BMalas_QG) * 100) / Convert.ToDouble(bob6.BBuenas));
                    PromedioMalas = Math.Round(PromedioMalas);
                    bob6.Peso_Original = PromedioMalas.ToString("N0") + "%";

                    double PromedioEscarpe = ((Convert.ToDouble(bob6.NombreOT)) / Convert.ToDouble(bob6.BBuenas));
                    bob6.Pesos_Conos = PromedioEscarpe.ToString("N2");

                    double PesoTotal = Convert.ToDouble(bob5.Maquina) + Convert.ToDouble(bob4.Maquina) + Convert.ToDouble(bob3.Maquina) + Convert.ToDouble(bob2.Maquina) + Convert.ToDouble(bob1.Maquina);
                    double escarpe = ((Convert.ToDouble(bob6.NombreOT) * 100) / Convert.ToDouble(PesoTotal));//bob6.Maquina));
                    bob6.Pesos_Envoltura = escarpe.ToString("N2") + "%";

                    Label TaTotGeneral = new Label();
                    TaTotGeneral.Text = "<br/><div align='right'><table><tr>" +
                                        "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='3'>General</td>" +
                                        "</tr><tr>" +
                                        "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.BBuenas.ToString() + "</div></td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.BMalas.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.BMalas_QG.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Bobina</td>" +
                                        "<td style='border:1px solid black;'>" + PesoTotal.ToString("N0").Replace(",", "").Replace(".", "") + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.NombreOT.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.OT.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.Peso_Original.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.Pesos_Conos.ToString() + "</td></tr><tr>" +

                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobina Proyecto</td>" +
                                        "<td style='border:1px solid black;'>" + BobCProyect.ToString("N0") + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Bobina Sin Proyecto</td>" +
                                        "<td style='border:1px solid black;'>" + BobSProyect.ToString("N0") + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total % Con Proyecto</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.ProCProyec.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total % Sin Proyecto</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.ProSProyec.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                        "<td style='border:1px solid black;'>" + bob6.Pesos_Envoltura.ToString() + "</td></tr><tr>"+
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Ext</td>" +
                                        "<td style='border:1px solid black;'>" + TotalEscarpeExt.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe Int</td>" +
                                        "<td style='border:1px solid black;'>" + PromedioEscarpeInt.ToString() + "</td></tr></table></div>";
                    
                    form.Controls.Add(TaTotGeneral);
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
                Label1.Text = "";

            }
            catch (Exception except)
            {
                string d = except.Message;
                string e1 = except.Source;
                string f = except.StackTrace;
                Label1.Text = d + "," + e1 + "," + f;
            }
                //fin del excel +except.Message+
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}