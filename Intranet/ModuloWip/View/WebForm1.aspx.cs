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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = GeneCodMas("01","01",0, "Wip Test de Posiciones"); 
        }
        public string GeneCodMas(string Codigo, string Barcode, int contador, string Bodega)
        {
            string Etiqueta = "";
            string eti = generadorCodigo(Barcode, contador);
            //if ((contador % 2) == 0)
            //{
                Etiqueta =
                        "<div style='font-size:80;font-weight:bold;'>&nbsp;&nbsp;" + Codigo.ToUpper() + "</div>" +
                        "<div><img src='" + eti + "' alt='' Width='600px' Height='240px'/></div>" +
                        "<div style='font-size:20;font-weight:bold;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Bodega.ToUpper() + "</div><br />";
            //}

            //else
            //{
            //    Etiqueta = "<div style='page-break-after:always;'><div style='font-size:80;font-weight:bold;'>&nbsp;&nbsp;" + Codigo.ToUpper() + "</div>" +
            //            "<div><img src='" + eti + "' alt='' Width='600px' Height='240px'/></div>" +
            //             "<div style='font-size:20;font-weight:bold;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Bodega.ToUpper() + "</div></div><br />";
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