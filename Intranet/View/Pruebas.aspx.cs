using Intranet.ModuloDespacho.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.View
{
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid1.DataSource = "";
            RadGrid1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<SimpliRoute> lista = ListarGuias(TextBox1.Text);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();

            ViewState["lista"] = lista;

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(lista);

            Label1.Text = json;

        }
        public List<SimpliRoute> ListarGuias(string NroGuia)
        {                List<SimpliRoute> lista = new List<SimpliRoute>();
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {

                if (cmd != null)
                {
                    cmd.CommandText = "select cliente,direccion,carga,notas,nroguia,ot,personadecontacto,nombreot,total" +
                        ",correo from metricsprod.dbo.cjr_GuiasDespacho_SimpliRoute where nroguia ='" + NroGuia + "'";
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SimpliRoute sr = new SimpliRoute();
                        sr.Cliente = reader["cliente"].ToString();
                        sr.Direccion = reader["direccion"].ToString();
                        sr.Carga = reader["carga"].ToString();
                        sr.Notas = reader["notas"].ToString();
                        sr.Folio = reader["nroguia"].ToString();
                        sr.OT = reader["ot"].ToString();
                        sr.PersonaContacto = reader["personadecontacto"].ToString();
                        sr.NombreOT = reader["nombreot"].ToString();
                        sr.Total = reader["total"].ToString();
                        sr.Correo = reader["correo"].ToString();
                        lista.Add(sr);
                    }
                }
            }catch(Exception ex)
            {

            }
            con.CerrarConexion();
            return lista;
        }
        const string cJobSeekerNameConst = "JobSeeker_cnst";
        public List<SimpliRoute> JobSeekersList
        {
            get
            {
                // If not on the viewstate then add it
                if (ViewState[cJobSeekerNameConst] == null)
                    ViewState[cJobSeekerNameConst] = new List<SimpliRoute>();

                // this code is not exist on release, but I check to be sure that I did not 
                //  overwrite this viewstate with a different object.
                Debug.Assert(ViewState[cJobSeekerNameConst] is List<SimpliRoute>);

                return (List<SimpliRoute>)ViewState[cJobSeekerNameConst];
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            RadGrid1.DataSource = "";
            RadGrid1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            RadGrid1.DataSource = JsonConvert.DeserializeObject<List<SimpliRoute>>(Label1.Text);
            RadGrid1.DataBind();


        }
    }
}