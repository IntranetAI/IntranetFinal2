using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Intranet.ModuloProduccion.View
{
    public partial class PDF : System.Web.UI.Page
    {
        public static string info = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string NumeroOT = Request.QueryString["NumeroOT"];

            VariasPaginas(NumeroOT, "Lib.Celeb.del Bicentenario");
        }

        public List<Despacho> ListDespacho(string OT)
        {
            DespachoController dc = new DespachoController();
            List<Despacho> lista = dc.ListarPDF(OT);
            return lista;
        }

        //Se genera el PDF
        public void VariasPaginas(string OT, string NombreOT)
        {
            List<Despacho> lista = ListDespacho(OT);
            MemoryStream MStream = new MemoryStream();
            Document document = new Document(PageSize.A4.Rotate(), 30, 30, 60, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, MStream);

            writer.CloseStream = false;

            itsEvents ev = new itsEvents();
            writer.PageEvent = ev;
            BaseFont bftime = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font time = new Font(bftime, 16, Font.BOLD, Color.BLACK);
            info = "OT : " + OT + "  Nombre : " + NombreOT;
            Paragraph para = new Paragraph("      Informe Despachos por OT \n", time);
            HeaderFooter header = new HeaderFooter(para, false);

            header.Alignment = Element.ALIGN_CENTER;
            header.Border = 0;

            document.Header = header;
            document.Open();


            int columnCount = 7;
            int rowCount = lista.Count;
            int tableRows = rowCount + 3;
            iTextSharp.text.Table grdTable = new iTextSharp.text.Table(columnCount, tableRows);
            //
            grdTable.Width = 100;
            int[] w = new int[] { 8, 18, 36, 68, 15, 10, 8 };
            grdTable.SetWidths(w);
            grdTable.BorderColor = new iTextSharp.text.Color(0);
            grdTable.BorderWidth = 1;
            grdTable.Cellpadding = 15;
            grdTable.Cellspacing = -15;

            int[] widths = new int[lista.Count];
            int contador = 0;
            foreach (Despacho des in lista)
            {
                if ((contador % 2) == 0)
                {
                    grdTable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
                    grdTable.Cellpadding = 1;
                    grdTable.Cellspacing = 0;
                    //grdTable.DefaultCell.BorderColor = new iTextSharp.text.Color(255, 255, 255);

                }
                else
                {
                    grdTable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(210, 210, 210);
                    grdTable.Cellpadding = 1;
                    grdTable.Cellspacing = 0;
                    //grdTable.DefaultCell.BorderColor = new iTextSharp.text.Color(255, 255, 255);

                }
                bftime = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                time = new Font(bftime, 9, Font.NORMAL, Color.BLACK);
                grdTable.AddCell(new Paragraph(des.NumeroFolio, time));
                grdTable.AddCell(new Paragraph(des.FechaImpresion.ToString(), time));
                grdTable.AddCell(new Paragraph(des.Destinatario, time));
                grdTable.AddCell(new Paragraph(des.Sucursal, time));
                grdTable.AddCell(new Paragraph(des.Comuna, time));
                grdTable.AddCell(new Paragraph(des.StatusDes, time));
                grdTable.AddCell(new Paragraph(des.Despachado, time));
                contador++;

            }


            document.Add(grdTable);
            document.Close();

            //var context = HttpContext.Current;
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Despacho.pdf");
            Response.BinaryWrite(MStream.GetBuffer());
            Response.End();
        }
        private string GetApplicationPhysicalPath()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
        }
        public class itsEvents : PdfPageEventHelper
        {

            PdfTemplate template;
            // This is the contentbyte object of the writer
            PdfContentByte cb;
            PdfContentByte pdfContent;
            // we will put the final number of pages in a template
            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;

            // This keeps track of the creation time
            DateTime PrintTime = DateTime.Now;




            Document pdfDoc = new Document();
            PdfDocument objDoc = null;
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                base.OnOpenDocument(writer, document);

                try
                {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    template = cb.CreateTemplate(100, 50);

                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }
            }
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                /***** INICIO PIE DE PAGINA ******/
                int page_count = 0;
                PdfTemplate total;
                BaseFont helv;
                bool settingFont = false;
                DateTime fecha = DateTime.Now;
                DateTime hora = DateTime.Now;
                total = writer.DirectContent.CreateTemplate(100, 100);

                total.BoundingBox = new Rectangle(-20, -20, 100, 100);

                helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContent;
                cb.SaveState();

                string text = "Pág. " + writer.PageNumber + " de";
                string text2 = "                                                                                                                                         Generado el " + fecha.ToString("dd/MM/yyyy") + ", a las: " + hora.ToString("hh:mm:ss");
                float textBase = document.Bottom - 20;
                float textSize = 22; //helv.GetWidthPoint(text, 12);
                cb.BeginText();
                cb.SetFontAndSize(helv, 8);

                cb.SetTextMatrix(document.Left, textBase);

                cb.ShowText(text);
                cb.ShowText(text2);
                cb.EndText();
                cb.AddTemplate(template, document.Left + textSize, textBase);
                cb.RestoreState();

                /************* FIN DE PIE DE PAGINAA **************/

                /************* INICIO CABECERA **************/
                BaseFont bftime = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font time = new Font(bftime, 10, Font.BOLD, Color.BLACK);
                ////Phrase p1Header = new Phrase(String.Format("BlueLemonCode generated page{0}", "\n", FontFactory.GetFont("arial", 18)));
                Phrase p1Header = new Phrase(String.Format(" Guía "), time);//FontFactory.GetFont("arial", 10));
                Phrase p2Header = new Phrase(String.Format("Fecha Guía"), time);//FontFactory.GetFont("arial", 10));
                Phrase p3Header = new Phrase(String.Format("Nombre Cliente"), time);//FontFactory.GetFont("arial", 10));
                Phrase p4Header = new Phrase(String.Format("Dirección de Despacho"), time);//FontFactory.GetFont("arial", 10));
                Phrase p5Header = new Phrase(String.Format("Comuna"), time);//FontFactory.GetFont("arial", 10));
                Phrase p6Header = new Phrase(String.Format("Estado"), time);//FontFactory.GetFont("arial", 10));
                Phrase p7Header = new Phrase(String.Format("Cant."), time);//FontFactory.GetFont("arial", 10));
                Phrase p8Header = new Phrase(String.Format(""), FontFactory.GetFont("arial", 10));
                iTextSharp.text.Image logoHeader = iTextSharp.text.Image.GetInstance(GetApplicationPhysicalPath() + @"\Content\images\qgLogoPDF.JPG");
                //espacio
                time = new Font(bftime, 12, Font.BOLD, Color.BLACK);
                Phrase subtitle = new Phrase(info, time);

                //Create PdfTable object
                PdfPTable pdfTab = new PdfPTable(1);
                PdfPTable pdfTa = new PdfPTable(8);
                PdfPTable pdfT = new PdfPTable(1);
                //Color 

                pdfT.WidthPercentage = 100;
                int[] a = new int[] { 30 };
                pdfT.SetWidths(a);
                PdfPCell pdfCe1 = new PdfPCell(subtitle);
                pdfCe1.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCe1.Border = 0;
                pdfT.AddCell(pdfCe1);
                pdfTa.WidthPercentage = 100;
                int[] w = new int[] { 8, 17, 35, 67, 14, 10, 8, 2 };
                pdfTa.SetWidths(w);
                PdfPCell pdfCell1 = new PdfPCell(logoHeader);
                PdfPCell pdfCell = new PdfPCell(p1Header);
                PdfPCell pdfCell2 = new PdfPCell(p2Header);
                PdfPCell pdfCell3 = new PdfPCell(p3Header);
                PdfPCell pdfCell4 = new PdfPCell(p4Header);
                PdfPCell pdfCell5 = new PdfPCell(p5Header);
                PdfPCell pdfCell6 = new PdfPCell(p6Header);
                PdfPCell pdfCell7 = new PdfPCell(p7Header);
                PdfPCell pdfCell8 = new PdfPCell(p8Header);
                pdfCell.BackgroundColor = new Color(165, 165, 165);
                pdfCell2.BackgroundColor = new Color(165, 165, 165);
                pdfCell3.BackgroundColor = new Color(165, 165, 165);
                pdfCell4.BackgroundColor = new Color(165, 165, 165);
                pdfCell5.BackgroundColor = new Color(165, 165, 165);
                pdfCell6.BackgroundColor = new Color(165, 165, 165);
                pdfCell7.BackgroundColor = new Color(165, 165, 165);
                //set the alignment of all three cells and set border to 0
                pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell1.Border = 0;
                pdfCell8.Border = 0;
                //add all three cells into PdfTable
                pdfTab.AddCell(pdfCell1);
                pdfTa.AddCell(pdfCell);
                pdfTa.AddCell(pdfCell2);
                pdfTa.AddCell(pdfCell3);
                pdfTa.AddCell(pdfCell4);
                pdfTa.AddCell(pdfCell5);
                pdfTa.AddCell(pdfCell6);
                pdfTa.AddCell(pdfCell7);
                pdfTa.AddCell(pdfCell8);
                pdfTab.TotalWidth = document.PageSize.Width - 50;
                pdfTa.TotalWidth = document.PageSize.Width - 50;
                pdfT.TotalWidth = document.PageSize.Width - 50;
                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                pdfTab.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 15, writer.DirectContent);
                pdfTa.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 88, writer.DirectContent);
                pdfT.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 68, writer.DirectContent);
                //set pdfContent value
                pdfContent = writer.DirectContent;
                //Move the pointer and draw line to separate header section from rest of page
                pdfContent.MoveTo(10, document.PageSize.Height - 135);
                //pdfContent.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 35);
                pdfContent.Stroke();
                /************* FIN CABECERA **************/
            }
            private string GetApplicationPhysicalPath()
            {
                return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            }
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);



                /******/
                template.BeginText();
                template.SetTextMatrix(25, 0);
                template.SetFontAndSize(bf, 8);
                template.ShowText(" " + (writer.PageNumber - 1));
                template.EndText();
            }
        }
    }
}