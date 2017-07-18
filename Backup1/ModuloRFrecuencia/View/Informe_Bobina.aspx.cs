using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using Intranet.ModuloRFrecuencia.Model;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_Bobina : System.Web.UI.Page
    {
        Bobina_Controller controlbo = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                CargarUsuario();
            }
        }

        public void CargarUsuario()
        {
            
            ddlOperador.DataSource = controlbo.ListarUsuarioBobina();
            ddlOperador.DataTextField = "pliego";
            ddlOperador.DataValueField = "Marca";
            ddlOperador.DataBind();
            ddlOperador.Visible = false;
            ddlOperador.Items.Insert(0,new ListItem("Todos", "0"));
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Bobina bobina = new Bobina();
            bobina.NumeroOp = txtNumeroOT.Text;
            bobina.Ubicacion = txtNombreOT.Text;
            bobina.Marca = txtCliente.Text;
            if (ddlMaquina.SelectedItem.ToString() != "Todas")
            {
                bobina.Proveedor = ddlMaquina.SelectedItem.ToString();
            }
            else
            {
                bobina.Proveedor = "";
            }
            if (ddlOperador.SelectedValue != "0")
            {
                bobina.pliego = ddlOperador.SelectedValue.ToString();
            }
            else
            {
                bobina.pliego = "";
            }
            bobina.Tipo = txtTipPapel.Text;
            DateTime f1; DateTime f2;
            if(txtFechaInicio.Text.Trim()!= "" && txtFechaTermino.Text.Trim()!= "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;
                //fechas
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                if (fechaInicio == fechaTermino)
                {
                    fechaInicio = fechaInicio + " 00:00:00";
                    fechaTermino = fechaTermino + " 23:59:59";
                }
                else
                {
                    fechaTermino = fechaTermino + " 23:59:59";
                }
                f1 = Convert.ToDateTime(fechaInicio);
                f2 = Convert.ToDateTime(fechaTermino);
            }
            else
            {
                f1 = Convert.ToDateTime("1900-01-01");
                f2 = Convert.ToDateTime("1900-01-01");
            }
            if (bobina.Proveedor == "")
            {
                RadGrid1.DataSource = controlbo.ListarBobinaInf(bobina, f1, f2);
                RadGrid1.DataBind();
                RadGrid2.Visible = false;
                RadGrid1.Visible = true;
            }
            else
            {
                RadGrid2.DataSource = controlbo.ListarBobinaInf(bobina, f1,f2);
                RadGrid2.DataBind();
                RadGrid2.Visible = true;
                RadGrid1.Visible = false;
            }
            
        }

        protected void ddlResponsable_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlResponsable.SelectedValue) != 0)
            {
                ddlCausa.DataSource = controlbo.BuscarEstado_bobi(Convert.ToInt32(ddlResponsable.SelectedValue));
                ddlCausa.DataTextField = "Tipo";
                ddlCausa.DataValueField = "Codigo";
                ddlCausa.DataBind();
                ddlCausa.Visible = true;
            }
        }

        protected void ddlEstado_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlEstado.SelectedValue) == 2)
            {
                ddlResponsable.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void cbxOption_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOption.Checked == true)
            {
                ddlMaquina.Visible = true;
                txtTipPapel.Visible = true;
                ddlOperador.Visible = true;
                //ddlEstado.Visible = true;
                //ddlResponsable.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                Label6.Visible = true;
                //Label7.Visible = true;
                //Label8.Visible = true;
            }
            else
            {
                ddlMaquina.Visible = false;
                txtTipPapel.Visible = false;
                ddlOperador.Visible = false;
                //ddlEstado.Visible = false;
                //ddlResponsable.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label6.Visible = false;
                //Label7.Visible = false;
                //Label8.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            DateTime f1; DateTime f2;
            GridView GridView1 = new GridView();
            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;
                //fechas
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                if (fechaInicio == fechaTermino)
                {
                    fechaInicio = fechaInicio + " 00:00:00";
                    fechaTermino = fechaTermino + " 23:59:59";
                }
                f1 = Convert.ToDateTime(fechaInicio);
                f2 = Convert.ToDateTime(fechaTermino);
                //txtCliente.Text = mes + "/" + dia + "/" + año;
            }
            else
            {
                f1 = Convert.ToDateTime("1900-01-01");
                f2 = Convert.ToDateTime("1900-01-01");
            }
            Bobina B = new Bobina();
            B.NumeroOp = txtNumeroOT.Text;
            B.Ubicacion = txtNombreOT.Text;
            B.Marca = txtCliente.Text;
            if (ddlMaquina.SelectedItem.ToString() != "Todas")
            {
                B.Proveedor = ddlMaquina.SelectedItem.ToString();
            }
            else
            {
                B.Proveedor = "";
            }
            if (ddlOperador.SelectedValue != "0")
            {
                B.pliego = ddlOperador.SelectedValue.ToString();
            }
            else
            {
                B.pliego = "";
            }
            B.Tipo = txtTipPapel.Text;

            GridView1.DataSource = controlbo.ListarBobExcelInf(B, f1, f2);
            GridView1.DataBind();
            GridView1.Visible = true;
            if (B.Proveedor == "")
            {
                GridView1.HeaderRow.Cells[0].Text = "N° OT";
                GridView1.HeaderRow.Cells[1].Visible = false;
                GridView1.HeaderRow.Cells[2].Visible = false;//.Text = "Nombre OT";
                GridView1.HeaderRow.Cells[3].Text = "Total Bob.";
                GridView1.HeaderRow.Cells[4].Text = "Bob. Buenas";
                GridView1.HeaderRow.Cells[5].Text = "Bob. Malas QGChile";
                GridView1.HeaderRow.Cells[6].Text = "Bob. Malas Proveedor";
                GridView1.HeaderRow.Cells[7].Text = "Pesos Originales";
                GridView1.HeaderRow.Cells[8].Text = "Pesos Tapas";
                GridView1.HeaderRow.Cells[9].Text = "Pesos Conos";
                GridView1.HeaderRow.Cells[10].Text = "Pesos Escarpe";
                GridView1.HeaderRow.Cells[11].Text = "Pesos Envoltura";
                GridView1.HeaderRow.Cells[12].Text = "% Buenas";
                GridView1.HeaderRow.Cells[13].Text = "% Malas";
                GridView1.HeaderRow.Cells[14].Text = "% Perdida";

                for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                 GridViewRow row =GridView1.Rows[contador];
                 row.Cells[1].Visible = false;
                 row.Cells[2].Visible = false;

                 double PesoOriginal = Convert.ToDouble(row.Cells[7].Text);
                 if (row.Cells[7].Text.Length > 3)
                 {
                     string po2 = PesoOriginal.ToString("N3").Replace(",", ".");
                     row.Cells[7].Text = po2;
                 }
                 else
                 {
                     string po2 = PesoOriginal.ToString("N0");
                     row.Cells[7].Text = po2;
                 }
                }
            }
            else
            {
                for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    string OT = row.Cells[0].Text;
                    string Maquina = row.Cells[1].Text;
                    row.Cells[1].Text = OT;
                    row.Cells[0].Text = Maquina;
                    row.Cells[2].Visible = false;
                }
                GridView1.HeaderRow.Cells[0].Text = "Maquina";
                GridView1.HeaderRow.Cells[1].Text = "N° OT";
                GridView1.HeaderRow.Cells[2].Visible = false;//.Text = "Nombre OT";
                GridView1.HeaderRow.Cells[3].Text = "Total Bob.";
                GridView1.HeaderRow.Cells[4].Text = "Bob. Buenas";
                GridView1.HeaderRow.Cells[5].Text = "Bob. Malas QGChile";
                GridView1.HeaderRow.Cells[6].Text = "Bob. Malas Proveedor";
                GridView1.HeaderRow.Cells[7].Text = "Pesos Originales";
                GridView1.HeaderRow.Cells[8].Text = "Pesos Tapas";
                GridView1.HeaderRow.Cells[9].Text = "Pesos Conos";
                GridView1.HeaderRow.Cells[10].Text = "Pesos Escarpe";
                GridView1.HeaderRow.Cells[11].Text = "Pesos Envoltura";

                GridView1.HeaderRow.Cells[12].Text = "% Buenas";
                GridView1.HeaderRow.Cells[13].Text = "% Malas";
                GridView1.HeaderRow.Cells[14].Text = "% Perdida";

            }
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

            string nombre = "Informe de Residuo " + DateTime.Now.ToShortDateString();

            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                ExportToExcel(nombre, GridView1, txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, B.Proveedor.ToString(), B.pliego.ToString(), B.Tipo.ToString(), txtFechaInicio.Text, txtFechaTermino.Text);
            }
            else
            {
                ExportToExcel(nombre, GridView1, txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, B.Proveedor.ToString(), B.pliego.ToString(), B.Tipo.ToString(), txtFechaInicio.Text, txtFechaTermino.Text);
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string OT, string Nombre, string Cliente, string Maquina, string Operador, string TipoPapel, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Sistema de Residuo<br/>";
            //la.Text = "<div align='center'>Informe Despacho Kilos Transportados<br/>";
            if (OT != "") { Titulo = Titulo + "OT : " + OT; }
            if (Nombre != "") { Titulo = Titulo + " Nombre OT : " + Nombre; }
            if (Maquina != "") { Titulo = Titulo + " Maquina : " + Maquina; }
            if (Operador != "") { Titulo = Titulo + " Operador : " + Operador; }
            if (TipoPapel != "") { Titulo = Titulo + " Tipo de Papel : " + TipoPapel; }
            if (Cliente != "") { Titulo = Titulo + " Cliente :" + Cliente; }
            if (fInicio != "") { Titulo = Titulo + " Fecha Inicio : " + fInicio; }
            if (fTermino != "") { Titulo = Titulo + " Fecha Termino : " + fTermino; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);
            form.Controls.Add(wControl);
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