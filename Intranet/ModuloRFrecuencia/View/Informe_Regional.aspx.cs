using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using Intranet.ModuloRFrecuencia.Model;
using Intranet.ModuloRFrecuencia.Controller;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_Regional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            string f1 = "";
            string f2 = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;

                f1 = fechaInicio;

                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año = año.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                f2 = fechaTermino;
            }
            else
            {
                f1 = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
                f2 = DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy");
            }
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            Bobina_Controller controlb = new Bobina_Controller();
            List<Inf_Regional> lista = controlb.List_Inf_Regional(f1, f2);
            PesoTotalOrig = controlb.PesoOriginalTB(f1, f2);
            List<Inf_Regional> lista1 = lista.Where(o => o.Maquina.Substring(0,3).ToUpper() != "WEB" && o.Turno == "Mañana" && o.Maquina != "General").ToList();
            Inf_Regional TTurnoR = new Inf_Regional();
            int CantidadBob = 0;
            foreach (Inf_Regional x in lista1)
            {
                CantidadBob = CantidadBob + (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(x.BobRotCant));
                TTurnoR.Maquina = "T. Turno";
                TTurnoR.BobBueCant = (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(TTurnoR.BobBueCant)).ToString(); TTurnoR.BobBueEsc = (Convert.ToDouble(x.BobBueEsc) + Convert.ToDouble(TTurnoR.BobBueEsc)).ToString();
                TTurnoR.BobDetCant = (Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(TTurnoR.BobDetCant)).ToString(); TTurnoR.BobDetEsc = (Convert.ToDouble(x.BobDetEsc) + Convert.ToDouble(TTurnoR.BobDetEsc)).ToString();
                TTurnoR.BobOtrCant = (Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(TTurnoR.BobOtrCant)).ToString(); TTurnoR.BobOtrEsc = (Convert.ToDouble(x.BobOtrEsc) + Convert.ToDouble(TTurnoR.BobOtrEsc)).ToString();
                TTurnoR.BobRotCant = (Convert.ToInt32(x.BobRotCant) + Convert.ToInt32(TTurnoR.BobRotCant)).ToString(); TTurnoR.BobRotEsc = (Convert.ToDouble(x.BobRotEsc) + Convert.ToDouble(TTurnoR.BobRotEsc)).ToString();
            }
            if (TTurnoR.BobBueCant != "0")
            {
                TTurnoR.BobBueProm = (Convert.ToDouble(TTurnoR.BobBueEsc) / Convert.ToInt32(TTurnoR.BobBueCant)).ToString("N1");
                TTurnoR.BobBueProG = ((Convert.ToDouble(TTurnoR.BobBueCant) / CantidadBob) * 100).ToString("N2");
            }
            else { TTurnoR.BobBueProm = "0"; TTurnoR.BobBueProG = "0.00"; }
            if (TTurnoR.BobDetCant != "0")
            {
                TTurnoR.BobDetProm = (Convert.ToDouble(TTurnoR.BobDetEsc) / Convert.ToInt32(TTurnoR.BobDetCant)).ToString("N1");
                TTurnoR.BobDetProG = ((Convert.ToDouble(TTurnoR.BobDetCant) / CantidadBob) * 100).ToString("N2");
            }
            else { TTurnoR.BobDetProm = "0"; TTurnoR.BobDetProG = "0.00"; }
            if (TTurnoR.BobOtrCant != "0")
            {
                TTurnoR.BobOtrProm = (Convert.ToDouble(TTurnoR.BobOtrEsc) / Convert.ToInt32(TTurnoR.BobOtrCant)).ToString("N1");
                TTurnoR.BobOtrProG = ((Convert.ToDouble(TTurnoR.BobOtrCant) / CantidadBob) * 100).ToString("N2");
            }
            else { TTurnoR.BobOtrProm = "0"; TTurnoR.BobOtrProG = "0.00"; }
            if (TTurnoR.BobRotCant != "0")
            {
                TTurnoR.BobRotProm = (Convert.ToDouble(TTurnoR.BobRotEsc) / Convert.ToInt32(TTurnoR.BobRotCant)).ToString("N1");
                TTurnoR.BobRotProG = ((Convert.ToDouble(TTurnoR.BobRotCant) / CantidadBob) * 100).ToString("N2");
            }
            else { TTurnoR.BobRotProm = "0"; TTurnoR.BobRotProG = "0.00"; }

            lista1.Add(TTurnoR);
            List<Inf_Regional> lista2 = lista.Where(o => o.Maquina.ToUpper() != "WEB 1" && o.Turno == "Tarde" && o.Maquina != "General" && o.Maquina.ToUpper() != "WEB 2").ToList();
            Inf_Regional TTurnoR2 = new Inf_Regional();
            int CantidadBob2 = 0;
            foreach (Inf_Regional x in lista2)
            {
                CantidadBob2 = CantidadBob2 + (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(x.BobRotCant));
                TTurnoR2.Maquina = "T. Turno";
                TTurnoR2.BobBueCant = (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(TTurnoR2.BobBueCant)).ToString(); TTurnoR2.BobBueEsc = (Convert.ToDouble(x.BobBueEsc) + Convert.ToDouble(TTurnoR2.BobBueEsc)).ToString();
                TTurnoR2.BobDetCant = (Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(TTurnoR2.BobDetCant)).ToString(); TTurnoR2.BobDetEsc = (Convert.ToDouble(x.BobDetEsc) + Convert.ToDouble(TTurnoR2.BobDetEsc)).ToString();
                TTurnoR2.BobOtrCant = (Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(TTurnoR2.BobOtrCant)).ToString(); TTurnoR2.BobOtrEsc = (Convert.ToDouble(x.BobOtrEsc) + Convert.ToDouble(TTurnoR2.BobOtrEsc)).ToString();
                TTurnoR2.BobRotCant = (Convert.ToInt32(x.BobRotCant) + Convert.ToInt32(TTurnoR2.BobRotCant)).ToString(); TTurnoR2.BobRotEsc = (Convert.ToDouble(x.BobRotEsc) + Convert.ToDouble(TTurnoR2.BobRotEsc)).ToString();
            }
            if (TTurnoR2.BobBueCant != "0")
            {
                TTurnoR2.BobBueProm = (Convert.ToDouble(TTurnoR2.BobBueEsc) / Convert.ToInt32(TTurnoR2.BobBueCant)).ToString("N1");
                TTurnoR2.BobBueProG = ((Convert.ToDouble(TTurnoR2.BobBueCant) / CantidadBob2) * 100).ToString("N2");
            }
            else { TTurnoR2.BobBueProm = "0"; TTurnoR2.BobBueProG = "0.00"; }
            if (TTurnoR2.BobDetCant != "0")
            {
                TTurnoR2.BobDetProm = (Convert.ToDouble(TTurnoR2.BobDetEsc) / Convert.ToInt32(TTurnoR2.BobDetCant)).ToString("N1");
                TTurnoR2.BobDetProG = ((Convert.ToDouble(TTurnoR2.BobDetCant) / CantidadBob2) * 100).ToString("N2");
            }
            else { TTurnoR2.BobDetProm = "0"; TTurnoR2.BobDetProG = "0.00"; }
            if (TTurnoR2.BobOtrCant != "0")
            {
                TTurnoR2.BobOtrProm = (Convert.ToDouble(TTurnoR2.BobOtrEsc) / Convert.ToInt32(TTurnoR2.BobOtrCant)).ToString("N1");
                TTurnoR2.BobOtrProG = ((Convert.ToDouble(TTurnoR2.BobOtrCant) / CantidadBob2) * 100).ToString("N2");
            }
            else { TTurnoR2.BobOtrProm = "0"; TTurnoR2.BobOtrProG = "0.00"; }
            if (TTurnoR2.BobRotCant != "0")
            {
                TTurnoR2.BobRotProm = (Convert.ToDouble(TTurnoR2.BobRotEsc) / Convert.ToInt32(TTurnoR2.BobRotCant)).ToString("N1");
                TTurnoR2.BobRotProG = ((Convert.ToDouble(TTurnoR2.BobRotCant) / CantidadBob2) * 100).ToString("N2");
            }
            else { TTurnoR2.BobRotProm = "0"; TTurnoR2.BobRotProG = "0.00"; }
            lista2.Add(TTurnoR2);
            
            List<Inf_Regional> lista3 = lista.Where(o => o.Turno == "Mañana" && o.Maquina.Substring(0,3).ToUpper() == "WEB").ToList();
            int CantidadBob3 = 0;
            Inf_Regional TTurno = new Inf_Regional();
            foreach (Inf_Regional x in lista3)
            {
                CantidadBob3 = CantidadBob3 + (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(x.BobRotCant));
                TTurno.Maquina = "T. Turno";
                TTurno.BobBueCant = (Convert.ToInt32(x.BobBueCant)+ Convert.ToInt32(TTurno.BobBueCant)).ToString(); TTurno.BobBueEsc = (Convert.ToDouble(x.BobBueEsc)+Convert.ToDouble(TTurno.BobBueEsc)).ToString();
                TTurno.BobDetCant = (Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(TTurno.BobDetCant)).ToString(); TTurno.BobDetEsc = (Convert.ToDouble(x.BobDetEsc) + Convert.ToDouble(TTurno.BobDetEsc)).ToString(); 
                TTurno.BobOtrCant = (Convert.ToInt32(x.BobOtrCant)+ Convert.ToInt32(TTurno.BobOtrCant)).ToString(); TTurno.BobOtrEsc = (Convert.ToDouble(x.BobOtrEsc)+Convert.ToDouble(TTurno.BobOtrEsc)).ToString(); 
                TTurno.BobRotCant = (Convert.ToInt32(x.BobRotCant)+ Convert.ToInt32(TTurno.BobRotCant)).ToString(); TTurno.BobRotEsc = (Convert.ToDouble(x.BobRotEsc)+ Convert.ToDouble(TTurno.BobRotEsc)).ToString();
            }
            if (TTurno.BobBueCant != "0")
            {
                TTurno.BobBueProm = (Convert.ToDouble(TTurno.BobBueEsc) / Convert.ToInt32(TTurno.BobBueCant)).ToString("N1");
                TTurno.BobBueProG = ((Convert.ToDouble(TTurno.BobBueCant) / CantidadBob3) * 100).ToString("N2");
            }
            else { TTurno.BobBueProm = "0"; TTurno.BobBueProG = "0.00"; }
            if (TTurno.BobDetCant != "0")
            {
                TTurno.BobDetProm = (Convert.ToDouble(TTurno.BobDetEsc) / Convert.ToInt32(TTurno.BobDetCant)).ToString("N1");
                TTurno.BobDetProG = ((Convert.ToDouble(TTurno.BobDetCant) / CantidadBob3) * 100).ToString("N2");
            }
            else { TTurno.BobDetProm = "0"; TTurno.BobDetProG = "0.00"; }
            if (TTurno.BobOtrCant != "0")
            {
                TTurno.BobOtrProm = (Convert.ToDouble(TTurno.BobOtrEsc) / Convert.ToInt32(TTurno.BobOtrCant)).ToString("N1");
                TTurno.BobOtrProG = ((Convert.ToDouble(TTurno.BobOtrCant) / CantidadBob3) * 100).ToString("N2");
            }
            else { TTurno.BobOtrProm = "0"; TTurno.BobOtrProG = "0.00"; }
            if (TTurno.BobRotCant != "0")
            {
                TTurno.BobRotProm = (Convert.ToDouble(TTurno.BobRotEsc) / Convert.ToInt32(TTurno.BobRotCant)).ToString("N1");
                TTurno.BobRotProG = ((Convert.ToDouble(TTurno.BobRotCant) / CantidadBob3) * 100).ToString("N2");
            }
            else { TTurno.BobRotProm = "0"; TTurno.BobRotProG = "0.00"; }
            lista3.Add(TTurno);
            List<Inf_Regional> lista4 = lista.Where(o =>  o.Maquina.Substring(0,3).ToUpper() == "WEB" && o.Turno == "Tarde").ToList();
            int CantidadBob4 = 0;
            Inf_Regional TTurno1 = new Inf_Regional();
            foreach (Inf_Regional x in lista4)
            {
                CantidadBob4 = CantidadBob4 + (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(x.BobRotCant));
                TTurno1.Maquina = "T. Turno";
                TTurno1.BobBueCant = (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(TTurno1.BobBueCant)).ToString(); TTurno1.BobBueEsc = (Convert.ToDouble(x.BobBueEsc) + Convert.ToDouble(TTurno1.BobBueEsc)).ToString();
                TTurno1.BobDetCant = (Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(TTurno1.BobDetCant)).ToString(); TTurno1.BobDetEsc = (Convert.ToDouble(x.BobDetEsc) + Convert.ToDouble(TTurno1.BobDetEsc)).ToString();
                TTurno1.BobOtrCant = (Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(TTurno1.BobOtrCant)).ToString(); TTurno1.BobOtrEsc = (Convert.ToDouble(x.BobOtrEsc) + Convert.ToDouble(TTurno1.BobOtrEsc)).ToString();
                TTurno1.BobRotCant = (Convert.ToInt32(x.BobRotCant) + Convert.ToInt32(TTurno1.BobRotCant)).ToString(); TTurno1.BobRotEsc = (Convert.ToDouble(x.BobRotEsc) + Convert.ToDouble(TTurno1.BobRotEsc)).ToString();
            }
            if (TTurno1.BobBueCant != "0")
            {
                TTurno1.BobBueProm = (Convert.ToDouble(TTurno1.BobBueEsc) / Convert.ToInt32(TTurno1.BobBueCant)).ToString("N1");
                TTurno1.BobBueProG = ((Convert.ToDouble(TTurno1.BobBueCant) / CantidadBob4) * 100).ToString("N2");
            }
            else { TTurno1.BobBueProm = "0"; TTurno1.BobBueProG = "0.00"; }
            if (TTurno1.BobDetCant != "0")
            {
                TTurno1.BobDetProm = (Convert.ToDouble(TTurno1.BobDetEsc) / Convert.ToInt32(TTurno1.BobDetCant)).ToString("N1");
                TTurno1.BobDetProG = ((Convert.ToDouble(TTurno1.BobDetCant) / CantidadBob4) * 100).ToString("N2");
            }
            else { TTurno1.BobDetProm = "0"; TTurno1.BobDetProG = "0.00"; }
            if (TTurno1.BobOtrCant != "0")
            {
                TTurno1.BobOtrProm = (Convert.ToDouble(TTurno1.BobOtrEsc) / Convert.ToInt32(TTurno1.BobOtrCant)).ToString("N1");
                TTurno1.BobOtrProG = ((Convert.ToDouble(TTurno1.BobOtrCant) / CantidadBob4) * 100).ToString("N2");
            }
            else { TTurno1.BobOtrProm = "0"; TTurno1.BobOtrProG = "0.00"; }
            if (TTurno1.BobRotCant != "0")
            {
                TTurno1.BobRotProm = (Convert.ToDouble(TTurno1.BobRotEsc) / Convert.ToInt32(TTurno1.BobRotCant)).ToString("N1");
                TTurno1.BobRotProG = ((Convert.ToDouble(TTurno1.BobRotCant) / CantidadBob4) * 100).ToString("N2");
            }
            else { TTurno1.BobRotProm = "0"; TTurno1.BobRotProG = "0.00"; }
            lista4.Add(TTurno1);
            List<Inf_Regional> lista5 = lista.Where(o =>  o.Maquina.Substring(0,3).ToUpper() == "WEB" && o.Turno == "Noche").ToList();
            int CantidadBob5 = 0;
            Inf_Regional TTurno2 = new Inf_Regional();
            foreach (Inf_Regional x in lista5)
            {
                CantidadBob5 = CantidadBob5 + (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(x.BobRotCant));
                TTurno2.Maquina = "T. Turno";
                TTurno2.BobBueCant = (Convert.ToInt32(x.BobBueCant) + Convert.ToInt32(TTurno2.BobBueCant)).ToString(); TTurno2.BobBueEsc = (Convert.ToDouble(x.BobBueEsc) + Convert.ToDouble(TTurno2.BobBueEsc)).ToString();
                TTurno2.BobDetCant = (Convert.ToInt32(x.BobDetCant) + Convert.ToInt32(TTurno2.BobDetCant)).ToString(); TTurno2.BobDetEsc = (Convert.ToDouble(x.BobDetEsc) + Convert.ToDouble(TTurno2.BobDetEsc)).ToString();
                TTurno2.BobOtrCant = (Convert.ToInt32(x.BobOtrCant) + Convert.ToInt32(TTurno2.BobOtrCant)).ToString(); TTurno2.BobOtrEsc = (Convert.ToDouble(x.BobOtrEsc) + Convert.ToDouble(TTurno2.BobOtrEsc)).ToString();
                TTurno2.BobRotCant = (Convert.ToInt32(x.BobRotCant) + Convert.ToInt32(TTurno2.BobRotCant)).ToString(); TTurno2.BobRotEsc = (Convert.ToDouble(x.BobRotEsc) + Convert.ToDouble(TTurno2.BobRotEsc)).ToString();
            }
            if (TTurno2.BobBueCant != "0")
            {
                TTurno2.BobBueProm = (Convert.ToDouble(TTurno2.BobBueEsc) / Convert.ToInt32(TTurno2.BobBueCant)).ToString("N1");
                TTurno2.BobBueProG = ((Convert.ToDouble(TTurno2.BobBueCant) / CantidadBob5) * 100).ToString("N2");
            }
            else { TTurno2.BobBueProm = "0"; TTurno2.BobBueProG = "0.00"; }
            if (TTurno2.BobDetCant != "0")
            {
                TTurno2.BobDetProm = (Convert.ToDouble(TTurno2.BobDetEsc) / Convert.ToInt32(TTurno2.BobDetCant)).ToString("N1");
                TTurno2.BobDetProG = ((Convert.ToDouble(TTurno2.BobDetCant) / CantidadBob5) * 100).ToString("N2");
            }
            else { TTurno2.BobDetProm = "0"; TTurno2.BobDetProG = "0.00"; }
            if (TTurno2.BobOtrCant != "0")
            {
                TTurno2.BobOtrProm = (Convert.ToDouble(TTurno2.BobOtrEsc) / Convert.ToInt32(TTurno2.BobOtrCant)).ToString("N1");
                TTurno2.BobOtrProG = ((Convert.ToDouble(TTurno2.BobOtrCant) / CantidadBob5) * 100).ToString("N2");
            }
            else { TTurno2.BobOtrProm = "0"; TTurno2.BobOtrProG = "0.00"; }
            if (TTurno2.BobRotCant != "0")
            {
                TTurno2.BobRotProm = (Convert.ToDouble(TTurno2.BobRotEsc) / Convert.ToInt32(TTurno2.BobRotCant)).ToString("N1");
                TTurno2.BobRotProG = ((Convert.ToDouble(TTurno2.BobRotCant) / CantidadBob5) * 100).ToString("N2");
            }
            else { TTurno2.BobRotProm = "0"; TTurno2.BobRotProG = "0.00"; }
            lista5.Add(TTurno2);
            List<Inf_Regional> lista6 = lista.Where(o => o.Maquina == "General").ToList();

            GridView MaquinasMR = new GridView();
            MaquinasMR.DataSource = lista1;
            MaquinasMR.DataBind();
            MaquinasMR.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            MaquinasMR.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView MaquinasTR = new GridView();
            MaquinasTR.DataSource = lista2;
            MaquinasTR.DataBind();
            MaquinasTR.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            MaquinasTR.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView MaquinasMW = new GridView();
            MaquinasMW.DataSource = lista3;
            MaquinasMW.DataBind();
            MaquinasMW.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            MaquinasMW.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView MaquinaTW = new GridView();
            MaquinaTW.DataSource = lista4;
            MaquinaTW.DataBind();
            MaquinaTW.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            MaquinaTW.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView MaquinaNW = new GridView();
            MaquinaNW.DataSource = lista5;
            MaquinaNW.DataBind();
            MaquinaNW.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            MaquinaNW.HeaderStyle.ForeColor = System.Drawing.Color.White;

            MaquinasMR.HeaderRow.Cells[1].Text = "Bob.";
            MaquinasMR.HeaderRow.Cells[2].Text = "Peso";
            MaquinasMR.HeaderRow.Cells[3].Text = "P. Prom";
            MaquinasMR.HeaderRow.Cells[4].Text = "%";
            MaquinasMR.HeaderRow.Cells[5].Text = "Bob.";
            MaquinasMR.HeaderRow.Cells[6].Text = "Peso";
            MaquinasMR.HeaderRow.Cells[7].Text = "P. Prom";
            MaquinasMR.HeaderRow.Cells[8].Text = "%";
            MaquinasMR.HeaderRow.Cells[9].Text = "Bob.";
            MaquinasMR.HeaderRow.Cells[10].Text = "Peso";
            MaquinasMR.HeaderRow.Cells[11].Text = "P. Prom";
            MaquinasMR.HeaderRow.Cells[12].Text = "%";
            MaquinasMR.HeaderRow.Cells[13].Text = "Bob.";
            MaquinasMR.HeaderRow.Cells[14].Text = "Peso";
            MaquinasMR.HeaderRow.Cells[15].Text = "P. Prom";
            MaquinasMR.HeaderRow.Cells[16].Text = "%";
            MaquinasMR.HeaderRow.Cells[17].Visible = false;

            MaquinasTR.HeaderRow.Cells[1].Text = "Bob.";
            MaquinasTR.HeaderRow.Cells[2].Text = "Peso";
            MaquinasTR.HeaderRow.Cells[3].Text = "P. Prom";
            MaquinasTR.HeaderRow.Cells[4].Text = "%";
            MaquinasTR.HeaderRow.Cells[5].Text = "Bob.";
            MaquinasTR.HeaderRow.Cells[6].Text = "Peso";
            MaquinasTR.HeaderRow.Cells[7].Text = "P. Prom";
            MaquinasTR.HeaderRow.Cells[8].Text = "%";
            MaquinasTR.HeaderRow.Cells[9].Text = "Bob.";
            MaquinasTR.HeaderRow.Cells[10].Text = "Peso";
            MaquinasTR.HeaderRow.Cells[11].Text = "P. Prom";
            MaquinasTR.HeaderRow.Cells[12].Text = "%";
            MaquinasTR.HeaderRow.Cells[13].Text = "Bob.";
            MaquinasTR.HeaderRow.Cells[14].Text = "Peso";
            MaquinasTR.HeaderRow.Cells[15].Text = "P. Prom";
            MaquinasTR.HeaderRow.Cells[16].Text = "%";
            MaquinasTR.HeaderRow.Cells[17].Visible = false;

            MaquinasMW.HeaderRow.Cells[1].Text = "Bob.";
            MaquinasMW.HeaderRow.Cells[2].Text = "Peso";
            MaquinasMW.HeaderRow.Cells[3].Text = "P. Prom";
            MaquinasMW.HeaderRow.Cells[4].Text = "%";
            MaquinasMW.HeaderRow.Cells[5].Text = "Bob.";
            MaquinasMW.HeaderRow.Cells[6].Text = "Peso";
            MaquinasMW.HeaderRow.Cells[7].Text = "P. Prom";
            MaquinasMW.HeaderRow.Cells[8].Text = "%";
            MaquinasMW.HeaderRow.Cells[9].Text = "Bob.";
            MaquinasMW.HeaderRow.Cells[10].Text = "Peso";
            MaquinasMW.HeaderRow.Cells[11].Text = "P. Prom";
            MaquinasMW.HeaderRow.Cells[12].Text = "%";
            MaquinasMW.HeaderRow.Cells[13].Text = "Bob.";
            MaquinasMW.HeaderRow.Cells[14].Text = "Peso";
            MaquinasMW.HeaderRow.Cells[15].Text = "P. Prom";
            MaquinasMW.HeaderRow.Cells[16].Text = "%";
            MaquinasMW.HeaderRow.Cells[17].Visible = false;

            MaquinaTW.HeaderRow.Cells[1].Text = "Bob.";
            MaquinaTW.HeaderRow.Cells[2].Text = "Peso";
            MaquinaTW.HeaderRow.Cells[3].Text = "P. Prom";
            MaquinaTW.HeaderRow.Cells[4].Text = "%";
            MaquinaTW.HeaderRow.Cells[5].Text = "Bob.";
            MaquinaTW.HeaderRow.Cells[6].Text = "Peso";
            MaquinaTW.HeaderRow.Cells[7].Text = "P. Prom";
            MaquinaTW.HeaderRow.Cells[8].Text = "%";
            MaquinaTW.HeaderRow.Cells[9].Text = "Bob.";
            MaquinaTW.HeaderRow.Cells[10].Text = "Peso";
            MaquinaTW.HeaderRow.Cells[11].Text = "P. Prom";
            MaquinaTW.HeaderRow.Cells[12].Text = "%";
            MaquinaTW.HeaderRow.Cells[13].Text = "Bob.";
            MaquinaTW.HeaderRow.Cells[14].Text = "Peso";
            MaquinaTW.HeaderRow.Cells[15].Text = "P. Prom";
            MaquinaTW.HeaderRow.Cells[16].Text = "%";
            MaquinaTW.HeaderRow.Cells[17].Visible = false;

            MaquinaNW.HeaderRow.Cells[1].Text = "Bob.";
            MaquinaNW.HeaderRow.Cells[2].Text = "Peso";
            MaquinaNW.HeaderRow.Cells[3].Text = "P. Prom";
            MaquinaNW.HeaderRow.Cells[4].Text = "%";
            MaquinaNW.HeaderRow.Cells[5].Text = "Bob.";
            MaquinaNW.HeaderRow.Cells[6].Text = "Peso";
            MaquinaNW.HeaderRow.Cells[7].Text = "P. Prom";
            MaquinaNW.HeaderRow.Cells[8].Text = "%";
            MaquinaNW.HeaderRow.Cells[9].Text = "Bob.";
            MaquinaNW.HeaderRow.Cells[10].Text = "Peso";
            MaquinaNW.HeaderRow.Cells[11].Text = "P. Prom";
            MaquinaNW.HeaderRow.Cells[12].Text = "%";
            MaquinaNW.HeaderRow.Cells[13].Text = "Bob.";
            MaquinaNW.HeaderRow.Cells[14].Text = "Peso";
            MaquinaNW.HeaderRow.Cells[15].Text = "P. Prom";
            MaquinaNW.HeaderRow.Cells[16].Text = "%";
            MaquinaNW.HeaderRow.Cells[17].Visible = false;

            for (int contador = 0; contador < MaquinasMR.Rows.Count; contador++)
            {
                GridViewRow row = MaquinasMR.Rows[contador];
                row.Cells[1].Style.Add("text-align", "right");
                row.Cells[2].Style.Add("text-align", "right");
                row.Cells[3].Style.Add("text-align", "right");
                row.Cells[4].Style.Add("text-align", "right");
                row.Cells[5].Style.Add("text-align", "right");
                row.Cells[6].Style.Add("text-align", "right");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");
                row.Cells[11].Style.Add("text-align", "right");
                row.Cells[12].Style.Add("text-align", "right");
                row.Cells[13].Style.Add("text-align", "right");
                row.Cells[14].Style.Add("text-align", "right");
                row.Cells[15].Style.Add("text-align", "right");
                row.Cells[16].Style.Add("text-align", "right");
                row.Cells[17].Visible = false;
            }
            for (int contador = 0; contador < MaquinasTR.Rows.Count; contador++)
            {
                GridViewRow row = MaquinasTR.Rows[contador];
                row.Cells[1].Style.Add("text-align", "right");
                row.Cells[2].Style.Add("text-align", "right");
                row.Cells[3].Style.Add("text-align", "right");
                row.Cells[4].Style.Add("text-align", "right");
                row.Cells[5].Style.Add("text-align", "right");
                row.Cells[6].Style.Add("text-align", "right");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");
                row.Cells[11].Style.Add("text-align", "right");
                row.Cells[12].Style.Add("text-align", "right");
                row.Cells[13].Style.Add("text-align", "right");
                row.Cells[14].Style.Add("text-align", "right");
                row.Cells[15].Style.Add("text-align", "right");
                row.Cells[16].Style.Add("text-align", "right");
                row.Cells[17].Visible = false;
            }
            for (int contador = 0; contador < MaquinasMW.Rows.Count; contador++)
            {
                GridViewRow row = MaquinasMW.Rows[contador];
                row.Cells[1].Style.Add("text-align", "right");
                row.Cells[2].Style.Add("text-align", "right");
                row.Cells[3].Style.Add("text-align", "right");
                row.Cells[4].Style.Add("text-align", "right");
                row.Cells[5].Style.Add("text-align", "right");
                row.Cells[6].Style.Add("text-align", "right");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");
                row.Cells[11].Style.Add("text-align", "right");
                row.Cells[12].Style.Add("text-align", "right");
                row.Cells[13].Style.Add("text-align", "right");
                row.Cells[14].Style.Add("text-align", "right");
                row.Cells[15].Style.Add("text-align", "right");
                row.Cells[16].Style.Add("text-align", "right");
                row.Cells[17].Visible = false;
            }
            for (int contador = 0; contador < MaquinaTW.Rows.Count; contador++)
            {
                GridViewRow row = MaquinaTW.Rows[contador];
                row.Cells[1].Style.Add("text-align", "right");
                row.Cells[2].Style.Add("text-align", "right");
                row.Cells[3].Style.Add("text-align", "right");
                row.Cells[4].Style.Add("text-align", "right");
                row.Cells[5].Style.Add("text-align", "right");
                row.Cells[6].Style.Add("text-align", "right");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");
                row.Cells[11].Style.Add("text-align", "right");
                row.Cells[12].Style.Add("text-align", "right");
                row.Cells[13].Style.Add("text-align", "right");
                row.Cells[14].Style.Add("text-align", "right");
                row.Cells[15].Style.Add("text-align", "right");
                row.Cells[16].Style.Add("text-align", "right");
                row.Cells[17].Visible = false;
            }
            for (int contador = 0; contador < MaquinaNW.Rows.Count; contador++)
            {
                GridViewRow row = MaquinaNW.Rows[contador];
                row.Cells[1].Style.Add("text-align", "right");
                row.Cells[2].Style.Add("text-align", "right");
                row.Cells[3].Style.Add("text-align", "right");
                row.Cells[4].Style.Add("text-align", "right");
                row.Cells[5].Style.Add("text-align", "right");
                row.Cells[6].Style.Add("text-align", "right");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");
                row.Cells[11].Style.Add("text-align", "right");
                row.Cells[12].Style.Add("text-align", "right");
                row.Cells[13].Style.Add("text-align", "right");
                row.Cells[14].Style.Add("text-align", "right");
                row.Cells[15].Style.Add("text-align", "right");
                row.Cells[16].Style.Add("text-align", "right");
                row.Cells[17].Visible = false;
            }

            string Titulo = "<div align='center'>Reporte de Desponche por Turno <br/>Rango de Fechas: Desde: " + txtFechaInicio.Text + " Hasta " + txtFechaTermino.Text + " </div><br />";
            la.Text = Titulo;
            form.Controls.Add(la);

            Label MaquinasM = new Label();
            MaquinasM.Text = "<table><tr><td>2 Turnos</td><td>12 Horas</td></tr></table><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>Turno Mañana</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Bobina Buena</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Problema Rotativa</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Deposito</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Otros Daños</td></tr></table>";
            form.Controls.Add(MaquinasM);
            form.Controls.Add(MaquinasMR);

            Label MaquinaT = new Label();
            MaquinaT.Text = "<br/><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>Turno Tarde</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Bobina Buena</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Problema Rotativa</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Deposito</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Otros Daños</td></tr></table>";
            form.Controls.Add(MaquinaT);
            form.Controls.Add(MaquinasTR);

            Label TaTotLitho = new Label();
            TaTotLitho.Text = "<br/><table><tr><td>3 Turnos</td><td>8 Horas</td></tr></table><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>Turno Mañana</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Bobina Buena</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Problema Rotativa</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Deposito</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Otros Daños</td></tr></table>";
            form.Controls.Add(TaTotLitho);
            form.Controls.Add(MaquinasMW);

            Label TaTotM600 = new Label();
            TaTotM600.Text = "<br/><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>Turno Tarde</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Bobina Buena</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Problema Rotativa</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Deposito</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Otros Daños</td></tr></table>";
            form.Controls.Add(TaTotM600);
            form.Controls.Add(MaquinaTW);

            Label TaTotDimen = new Label();
            TaTotDimen.Text = "<br/><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>Turno Noche</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Bobina Buena</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Problema Rotativa</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Deposito</td>" +
                    "<td style='border:1px solid black;' colspan='4' align='center'>Otros Daños</td></tr></table>";
            form.Controls.Add(TaTotDimen);
            form.Controls.Add(MaquinaNW);

            Label TaTotWeb1 = new Label();
            Inf_Regional regional = new Inf_Regional();
            foreach (Inf_Regional a in lista6)
            {
                regional = a;

            }
            TaTotWeb1.Text = "<br/><table style='width: 100%;'>" +
                    "<tr><td style='border:1px solid black;'>T. General</td>" +
                    "<td style='border:1px solid black;text-align:right;'>" + regional.BobBueCant + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobBueEsc + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobBueProm + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobBueProG + "</td>" +
                    "<td style='border:1px solid black;text-align:right;'>" + regional.BobRotCant + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobRotEsc + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobRotProm + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobRotProG + "</td>" +
                    "<td style='border:1px solid black;text-align:right;'>" + regional.BobDetCant + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobDetEsc + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobDetProm + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobDetProG + "</td>" +
                    "<td style='border:1px solid black;text-align:right;'>" + regional.BobOtrCant + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobOtrEsc + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobOtrProm + "</td><td style='border:1px solid black;text-align:right;'>" + regional.BobOtrProG + "</td></tr></table>";
            form.Controls.Add(TaTotWeb1);
             
            Label TotalEscalpe = new Label();
            double Total = (Convert.ToDouble(regional.BobBueEsc) + Convert.ToDouble(regional.BobRotEsc) + Convert.ToDouble(regional.BobDetEsc) + Convert.ToDouble(regional.BobOtrEsc)) * 100;
            double Total2 = Total / PesoTotalOrig;
            string detalle = "";
            List<Bobina> listadet = controlb.ListarPromEsc(f1,f2);
            foreach(Bobina b in listadet)
            {
                detalle = detalle + "<tr><td colspan ='2'></td><td colspan ='2' style='border:1px solid black;'>Resumen</td><td colspan ='2' style='border:1px solid black;'>Con Proyectos</td><td colspan ='2' style='border:1px solid black;text-align:right;'>" + b.Lote.Replace(".", ",") + "</td><td style='border:1px solid black;text-align:right;'>" + b.Porc_Buenas + "%</td><td colspan ='2' style='border:1px solid black;'>Sin Proyectos</td><td style='border:1px solid black;text-align:right;'>" + b.Marca.Replace(".", ",") + "</td><td style='border:1px solid black;text-align:right;'>" + b.Porc_Malas + "%</td></tr>";
            }
            TotalEscalpe.Text = "<br/><table style='width: 100%;'><tr><td colspan ='2'></td><td colspan ='2' style='border:1px solid black;'>Total KG. Mes</td><td colspan ='2' style='border:1px solid black;text-align:right;'>" + PesoTotalOrig.ToString("N0").Replace(",", ".") + "</td>" +
                                "<td colspan ='2' style='border:1px solid black;'>Escarpe KG. Mes</td><td style='border:1px solid black;'>" + Convert.ToInt32(Total / 100).ToString("N0").Replace(",", ".") + "</td><td colspan ='2' style='border:1px solid black;'>% Escarpe/P.Bruto</td><td colspan ='2' style='border:1px solid black;text-align:right;'>" + Total2.ToString("N2") + "%</td></tr>" +
                                detalle + "<tr><td colspan ='2'></td><td colspan ='2' style='border:1px solid black;'>Prom. Escarpe Int</td><td colspan ='2' style='border:1px solid black;text-align:right;'>" + (((Convert.ToDouble(regional.BobBueEsc) + Convert.ToDouble(regional.BobRotEsc) + Convert.ToDouble(regional.BobDetEsc)) / PesoTotalOrig) * 100).ToString("N2") + "%</td><td colspan ='2' style='border:1px solid black;'>Total Escarpe Otr. Daños</td><td style='border:1px solid black;'>" + regional.BobOtrEsc + "</td></tr></table><br/>";
            form.Controls.Add(TotalEscalpe);

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
            response.AddHeader("Content-Disposition", "attachment;filename=Reporte de Desponche " + fecha + ".xls");
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

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }
    }
}