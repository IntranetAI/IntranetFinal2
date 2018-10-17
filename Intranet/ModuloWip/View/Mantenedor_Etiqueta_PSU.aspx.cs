using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloWip.View
{
    public partial class Mantenedor_Etiqueta_PSU : System.Web.UI.Page
    {
        Controller_MetricsWIP w = new Controller_MetricsWIP();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            lblImprimir.Text = CrearEtiqueta("", "");
            Page.RegisterStartupScript("PopupScript", "<script language='JavaScript'>imprSelec('muestra');</script>");

        }
        public string CrearEtiqueta(string Bodega, string NombreBodega)
        {
            string Respuesta = "";
            List<Folios> lista = w.FoliosPsuENC(0);
            int contador = 0;
            foreach (Folios wc in lista)
            {
                
                if (contador == 0)
                {
                    Respuesta = Respuesta + GeneCodMas(wc.Pallet, wc.Caja, wc.Desde, wc.Hasta, wc.Asignatura, wc.Forma, contador);
                    contador++;
                }else
                {
                    Respuesta = Respuesta + GeneCodMas(wc.Pallet, wc.Caja, wc.Desde, wc.Hasta, wc.Asignatura, wc.Forma, contador);
                    contador = 0;
                }
                
            }
            return Respuesta;
        }

        public string GeneCodMas(string Pallet,int Caja,int Desde,int Hasta,string Asignatura,string Forma,int contador)
        {
            string Etiqueta = "";
            string NumDesde = "";
            switch (Desde.ToString().Count())
            {
                case 1:
                    NumDesde = "00000" + Desde.ToString();
                    break;
                case 2:
                    NumDesde = "0000" + Desde.ToString();
                    break;
                case 3:
                    NumDesde = "000" + Desde.ToString();
                    break;
                case 4:
                    NumDesde = "00" + Desde.ToString();
                    break;
                case 5:
                    NumDesde = "0" + Desde.ToString();
                    break;
                case 6:
                    NumDesde = Desde.ToString();
                    break;
                default:
                    NumDesde = Desde.ToString();
                    break;
            }
            string NumHasta = "";
            switch (Hasta.ToString().Count())
            {
                case 1:
                    NumHasta = "00000" + Hasta.ToString();
                    break;
                case 2:
                    NumHasta = "0000" + Hasta.ToString();
                    break;
                case 3:
                    NumHasta = "000" + Hasta.ToString();
                    break;
                case 4:
                    NumHasta = "00" + Hasta.ToString();
                    break;
                case 5:
                    NumHasta = "0" + Hasta.ToString();
                    break;
                case 6:
                    NumHasta = Hasta.ToString();
                    break;
                default:
                    NumHasta = Hasta.ToString();
                    break;
            }


            if ((contador) == 0)
            {
                Etiqueta =
                    "<div style='border-style: solid;text-align:center;width:550px;font-family: Arial Black'>" +
                        "<div style='font-size:40;font-weight:bold;'>" + Forma + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + Asignatura + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + Pallet + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>CAJA " + Caja + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + NumDesde + " - " + NumHasta + "</div></div><br />";
            }

            else
            {
                Etiqueta = " <div style = 'page-break-after:always;border-style: solid;text-align:center;width:550px;font-family: Arial Black' > " +
                        "<div style='font-size:40;font-weight:bold;'>" + Forma + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + Asignatura + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + Pallet + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>CAJA " + Caja + "</div>" +
                        "<div style='font-size:50;font-weight:bold;'>" + NumDesde + " - " + NumHasta + "</div></div>";
            }

            //if ((contador) == 0)
            //{
            //    Etiqueta =
            //        "<div style='border-style: solid;text-align:center;width:550px;font-family: Arial Black'>" +
            //            "<div style='font-size:40;font-weight:bold;'>" + Forma + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + Asignatura + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + Pallet + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>CAJA " + Caja + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + NumDesde + " - " + NumHasta + "</div></div><br />";
            //}

            //else
            //{
            //    Etiqueta = " <div style = 'page-break-after:always;border-style: solid;text-align:center;width:550px;font-family: Arial Black' > " +
            //            "<div style='font-size:40;font-weight:bold;'>" + Forma + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + Asignatura + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + Pallet + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>CAJA " + Caja + "</div>" +
            //            "<div style='font-size:50;font-weight:bold;'>" + NumDesde + " - " + NumHasta + "</div></div>";
            //}

            return Etiqueta;
        }
        public string GenerarImagen(int contador)
        {
            string imagen = "";
            string fileName = "bc.png";
            string sourcePath = Server.MapPath("./barcodes/"); // @"C:\Users\Public\TestFolder";
            string targetPath = Server.MapPath("./barcodes1/");

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            imagen = "bc" + contador.ToString() + ".png";
            string destFile = System.IO.Path.Combine(targetPath, imagen);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            System.IO.File.Copy(sourceFile, destFile, true);
            return imagen;
        }

        public string generadorCodigo(string Codigo, int contador)
        {
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);
            string Nimagen = GenerarImagen(contador);
            code.DrawCode128(g, Codigo, 0, 0).Save(Server.MapPath("./barcodes1/" + Nimagen.ToString()), ImageFormat.Png);
            return "./barcodes1/" + Nimagen.ToString();//imgCodigo.ImageUrl = "./barcodes/bc.png";
        }
    }
} 