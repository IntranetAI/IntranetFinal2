using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Intranet.ModuloEncuadernacion.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class DistribucionNatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargardatos();
            }
        }

        public void cargardatos()
        {
            Controller_Distribucion controldis = new Controller_Distribucion();
            string Marca = "";
            string Estado = "";
            string Ciclo = "";
            if (ddlMarca.SelectedItem.Text != "Todos")
            {
                Marca = ddlMarca.SelectedItem.Text;
            }
            if (ddlEstado.SelectedItem.Text != "Todos")
            {
                Estado = ddlEstado.SelectedItem.Text;
            }
            if (txtCicloNatura.Text != "")
            {
                Ciclo = txtCicloNatura.Text.ToString();
            }
            RadGridCodigos.DataSource = controldis.ListarDistribucionNatura(txtGerencia.Text, Marca,Ciclo, Estado);
            RadGridCodigos.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            cargardatos();
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<Distribucion> lista = new List<Distribucion>();
                string Cajarevista = "";
                string CajaEnsobrados = "";
                for (int i = 0; i < RadGridCodigos.Items.Count; i++)
                {
                    Distribucion dis = new Distribucion();
                    dis.Gerencia = RadGridCodigos.Items[i]["Gerencia"].Text;
                    dis.Sector = RadGridCodigos.Items[i]["Sector"].Text;
                    dis.Destinatario = RadGridCodigos.Items[i]["Destinatario"].Text;
                    dis.Domicilio = RadGridCodigos.Items[i]["Domicilio"].Text;
                    dis.Localidad = RadGridCodigos.Items[i]["Localidad"].Text;
                    dis.Fecha_Retiro = RadGridCodigos.Items[i]["Retiro"].Text;
                    dis.Marca = RadGridCodigos.Items[i]["Marca"].Text;
                    dis.Caja_Revista = RadGridCodigos.Items[i]["Caja_Revista"].Text;
                    dis.caja_ensobrado = RadGridCodigos.Items[i]["caja_ensobrado"].Text;
                    dis.CodigoBarra = RadGridCodigos.Items[i]["CodigoBarra"].Text;
                    dis.Estado = RadGridCodigos.Items[i]["Estado"].Text;
                    dis.Nombre_Cajas = RadGridCodigos.Items[i]["Nombre_Cajas"].Text;
                    if (dis.Marca.IndexOf("REV.") >= 0)
                    {
                        Cajarevista = "Cajas Revista <br/> (" + dis.Nombre_Cajas + ")";
                    }
                    else
                    {
                        CajaEnsobrados = "Cajas de Ensobrados <br/> (" + dis.Nombre_Cajas + ")";
                    }
                    lista.Add(dis);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                GridView1.HeaderRow.Cells[5].Visible = false;
                GridView1.HeaderRow.Cells[7].Text = Cajarevista;
                GridView1.HeaderRow.Cells[8].Text = CajaEnsobrados;
                GridView1.HeaderRow.Cells[10].Visible = false;
                GridView1.HeaderRow.Cells[9].Text = "Cant. Faltante";
                GridView1.HeaderRow.Cells[12].Text = "Material";
                for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    if(row.Cells[12].Text.IndexOf("REV.")>=0)
                    {
                        row.Cells[7].Text = row.Cells[8].Text;
                        row.Cells[8].Text = "";
                    }
                    else
                    {
                        row.Cells[7].Text = "";
                    }
                    row.Cells[9].Text = row.Cells[10].Text;
                    row.Cells[10].Visible = false;
                    row.Cells[5].Visible = false;
                }

                string Filtro = "";
                if (txtGerencia.Text != "")
                {
                    Filtro += " Gerencia : " + txtGerencia + "<br />";
                }
                if (txtCicloNatura.Text != "")
                {
                    Filtro += "Ciclo : " + txtCicloNatura.Text + "<br />";
                }
                if (ddlEstado.SelectedItem.Text != "Todos")
                {
                    Filtro += "Estado : " + ddlEstado.SelectedItem.Text + "<br/>";
                }
                if (ddlMarca.SelectedItem.Text != "Todos")
                {
                    Filtro += "Material : " + ddlMarca.SelectedItem.Text;
                }
                string Titulo = Filtro + "</div><br />";
                ExportToExcel("Informe Distribucion Natura Ciclo " + txtCicloNatura.Text, Titulo, GridView1);
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error al exportar a Excel'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

        private void ExportToExcel(string nameReport, string Titulo, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>Informe Distribucion Natura </div><div align='center'>" + Titulo;

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