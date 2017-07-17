using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using System.Web.Services;
using System.Web.Script.Serialization;
using Intranet.ModuloProduccion.Model;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Intranet.ModuloProduccion
{
    public partial class InformeProgramacionProduccion : System.Web.UI.Page
    {
        SeguimientoController sc = new SeguimientoController();
        DateTime f = Convert.ToDateTime("1900-01-01");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (ddlTipoInforme.SelectedValue.ToString() == "General")
            {
                InformeGeneral();
            }
            else if (ddlTipoInforme.SelectedValue.ToString() == "Resumido")
            {
                InformeResumido();
            }
            else if (ddlTipoInforme.SelectedValue.ToString() == "Detallado")
            {
                InformeDetallado();
            }
        }
        public void InformeGeneral()
        {
            if (txtOT.Text != "")
            {
                lblInforme.Text = sc.Carga_ProgramacionInfGeneral(txtOT.Text, "", Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("1900-01-01"), 7);
            }
            else
            {

                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                        {
                            lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 2);
                        }
                        else
                        {
                            lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", f1, f2, 1);
                        }
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            string Maquina = "";
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 10p")
                                {
                                    Maquina = "10p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 8p")
                                {
                                    Maquina = "8p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 4p")
                                {
                                    Maquina = "4p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master CD")
                                {
                                    Maquina = "CD";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master XL")
                                {
                                    Maquina = "XL";
                                }

                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", Maquina, f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", f1, f2, 5);
                            }
                        }
                    }
                }
                else
                {
                    string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    DateTime f2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        //01/10/2014
                        lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", Convert.ToDateTime(f1), Convert.ToDateTime(f2), 1);
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", f1, f2, 5);
                            }
                        }
                    }

                }
            }
               // lblInforme.Text = sc.Carga_ProgramacionInfGeneral("", "", Convert.ToDateTime("11/01/2014 00:00:00"), Convert.ToDateTime("11/30/2014 23:59:59"), 1);
            
            
        }
        public void InformeResumido()
        {
            if (txtOT.Text != "")
            {


                lblInforme.Text = sc.Carga_Programacion(txtOT.Text.Trim(), "", f, f, 7);
            }
            else
            {

                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                        {
                            lblInforme.Text = sc.Carga_Programacion("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 2);
                        }
                        else
                        {
                            lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 1);
                        }
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 5);
                            }
                        }
                    }
                }
                else
                {
                    string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    DateTime f2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 1);
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 5);
                            }
                        }
                    }

                }
            }
        }
        public void InformeDetallado()
        {

            if (txtOT.Text != "")
            {


                lblInforme.Text = sc.Carga_Programacion2(txtOT.Text.Trim(), "", f, f, 7);
            }
            else
            {

                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('-');
                    DateTime f2 = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                        {
                            lblInforme.Text = sc.Carga_Programacion2("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 2);
                        }
                        else
                        {
                            lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 1);
                        }
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            string Maquina = "";
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 10p")
                                {
                                    Maquina = "10p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 8p")
                                {
                                    Maquina = "8p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master 4p")
                                {
                                    Maquina = "4p";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master CD")
                                {
                                    Maquina = "CD";
                                }
                                else if (ddlMaquinas.SelectedValue.ToString() == "Speed Master XL")
                                {
                                    Maquina = "XL";
                                }

                                lblInforme.Text = sc.Carga_Programacion2("", Maquina, f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 5);
                            }
                        }
                    }
                }
                else
                {
                    string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    DateTime f2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        //01/10/2014
                        lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 1);
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion2("", "", f1, f2, 5);
                            }
                        }
                    }

                }
            }
        }


        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlMaquinas.DataSource = sc.ListMaquinas(ddlSeccion.SelectedValue.ToString());
            ddlMaquinas.DataTextField = "Name";
            ddlMaquinas.DataValueField = "Name";
            ddlMaquinas.DataBind();
            ddlMaquinas.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lblInforme.Text != "")
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                        {
                            lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 2);
                        }
                        else
                        {
                            lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 1);
                        }
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 5);
                            }
                        }
                    }
                }
                else
                {
                    string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    DateTime f2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 1);
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 5);
                            }
                        }
                    }

                }





                Document document = new Document();
                document.SetPageSize(PageSize.A4.Rotate());
                PdfWriter.GetInstance(document, new FileStream(Request.PhysicalApplicationPath + "\\MySamplePDF.pdf", FileMode.Create));
                document.Open();
                iTextSharp.text.html.simpleparser.HTMLWorker hw =
                             new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                hw.Parse(new StringReader("<div align='center'><h1>Programacion de Producción</h1></div>&nbsp;" + lblInforme.Text));


                HeaderFooter header = new HeaderFooter(new Paragraph("Header\n <div style='color:red;'>apekedikdjaj</div>"), false);
                document.Header = header;


                document.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=MySamplePDF");
                Response.WriteFile(Request.PhysicalApplicationPath + "\\MySamplePDF.pdf");
                Response.End();
            }

        }

        protected void LinkPDF_Click(object sender, EventArgs e)
        {
            if (lblInforme.Text != "")
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                        {
                            lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 2);
                        }
                        else
                        {
                            lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 1);
                        }
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 5);
                            }
                        }
                    }
                }
                else
                {
                    string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                    DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    DateTime f2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    if (ddlSeccion.SelectedValue.ToString() == "Todas")
                    {
                        lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 1);
                    }
                    else
                    {
                        if (ddlSeccion.SelectedValue.ToString() == "Rotativa")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 4);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 3);
                            }
                        }
                        else if (ddlSeccion.SelectedValue.ToString() == "Planas")
                        {
                            if (ddlMaquinas.SelectedValue.ToString() != "Seleccione...")
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", ddlMaquinas.SelectedValue.ToString(), f1, f2, 6);
                            }
                            else
                            {
                                lblInforme.Text = sc.Carga_Programacion_PDF("", "", f1, f2, 5);
                            }
                        }
                    }

                }





                Document document = new Document();
                document.SetPageSize(PageSize.A4.Rotate());
                PdfWriter.GetInstance(document, new FileStream(Request.PhysicalApplicationPath + "\\ProgramacionProduccion.pdf", FileMode.Create));
                document.Open();
                iTextSharp.text.html.simpleparser.HTMLWorker hw =
                             new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                hw.Parse(new StringReader("<div align='center'><h1>Programacion de Producción</h1></div>&nbsp;" + lblInforme.Text));


                HeaderFooter header = new HeaderFooter(new Paragraph("Header\n <div style='color:red;'>apekedikdjaj</div>"), false);
                document.Header = header;


                document.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=ProgramacionProduccion");
                Response.WriteFile(Request.PhysicalApplicationPath + "\\ProgramacionProduccion.pdf");
                Response.End();
            }
        }




    }
}