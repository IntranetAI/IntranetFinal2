using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Intranet.ModuloWip.Controller;


namespace Intranet.ModuloWip.View
{
    public partial class EtiquetaMasiva : System.Web.UI.Page
    {
        Controller_WipControl controlWip = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Codigos = Request.QueryString["cbw"].ToString();
            if (Codigos != "")
            {
                EtiqMasiva.Text = controlWip.CrearEtiqueta(Codigos);
                //EtiqMasiva.Text = EtiqMasiva.Text.Substring(0, EtiqMasiva.Text.Length-);
            }
        }

        public string GenerarImagen(int contador)
        {
            string imagen = "";
            string fileName = "bc.png";
            string sourcePath = Server.MapPath("./barcodes/"); // @"C:\Users\Public\TestFolder";
            string targetPath = Server.MapPath("./barcodes1/");

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            imagen = "bc"+contador.ToString()+".png";
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
            code.DrawCode128(g, Codigo, 0, 0).Save(Server.MapPath("./barcodes1/"+Nimagen.ToString()), ImageFormat.Png);
            return "./barcodes1/" + Nimagen.ToString();//imgCodigo.ImageUrl = "./barcodes/bc.png";
        }

    }
}