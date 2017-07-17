using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloProduccion.Controller;
using System.IO;

namespace Intranet.ModuloProduccion.View
{
    public partial class GenericMethodsCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string ListArchivos()
        {
            GenericMethodsCall index = new GenericMethodsCall();
            index.cargarArchivos();

            return "hola";
        }
        
        public void cargarArchivos()
        {

            List<ContArchivos> c = new List<ContArchivos>();
            OrdenController oc = new OrdenController();

            c = oc.Seguimiento_ListarArchivos();

            DirectoryInfo picrut = new DirectoryInfo(Server.MapPath("../../ModuloUsuario/View/Uploads/"));
            FileInfo[] rgFiles = picrut.GetFiles("*");

            for (int i = 0; i < rgFiles.Length; i++)
            {
                int contador = c.Where(o => o.Archivo == rgFiles[i].Name).Count();
                if (contador == 0)
                {
                    //eliminar
                    File.Delete(Server.MapPath("../../ModuloUsuario/View/Uploads/" + rgFiles[i].Name));

                }


                //string nombre = rgFiles[i].Name;

            }


        }
    }
}