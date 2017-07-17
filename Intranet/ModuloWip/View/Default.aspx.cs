using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.View
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDummyRow();
            }
        }

        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("OT");
            dummy.Columns.Add("NombreOT");
            dummy.Columns.Add("Ubicacion");
            dummy.Columns.Add("Posicion");
            dummy.Columns.Add("ID_Control");
            dummy.Columns.Add("Pliego");
            dummy.Columns.Add("Pliegos_Impresos");
            dummy.Columns.Add("Peso_pallet");
            dummy.Columns.Add("Maquina_Proceso");
            dummy.Columns.Add("Estado_Pallet2");
            dummy.Columns.Add("Fecha_Modificacion");
            dummy.Columns.Add("Usuario");
            dummy.Columns.Add("VerMas");
            
            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();
        }

        [WebMethod]
        public static string GetCustomers()
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();

            DataTable dt = new DataTable();
            dt.TableName = "Table";
            dt.Columns.Add("OT", typeof(string));
            dt.Columns.Add("NombreOT", typeof(string));
            dt.Columns.Add("Ubicacion", typeof(string));
            dt.Columns.Add("Posicion", typeof(string));
            dt.Columns.Add("ID_Control", typeof(string));
            dt.Columns.Add("Pliego", typeof(string));
            dt.Columns.Add("Pliegos_Impresos", typeof(string));
            dt.Columns.Add("Peso_pallet", typeof(string));
            dt.Columns.Add("Maquina_Proceso", typeof(string));
            dt.Columns.Add("Estado_Pallet2", typeof(string));
            dt.Columns.Add("Fecha_Modificacion", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("VerMas", typeof(string));
            Model_Wip_Control wipFiltro = new Model_Wip_Control();
            wipFiltro.OT = "99444";
            wipFiltro.Pliego = "1";
            lista = wipControl.ListOTUbi_Buscar(wipFiltro);
            foreach (Model_Wip_Control wip in lista)
            {
                DataRow row = dt.NewRow();

                //foreach of your properties
                row["OT"] = wip.OT;
                row["NombreOT"] = wip.NombreOT;
                row["Ubicacion"] = wip.Ubicacion;
                row["Posicion"] = wip.Posicion;
                row["ID_Control"] = wip.ID_Control;
                row["Pliego"] = wip.Pliego;
                row["Pliegos_Impresos"] = wip.Pliegos_Impresos;
                row["Peso_pallet"] = wip.Peso_pallet;
                row["Maquina_Proceso"] = wip.Maquina_Proceso;
                row["Estado_Pallet2"] = wip.Estado_Pallet2;
                row["Fecha_Modificacion"] = wip.Fecha_Modificacion;
                row["Usuario"] = wip.Usuario;
                row["VerMas"] = wip.VerMas;

                dt.Rows.Add(row);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds.GetXml();
        }
    }
}