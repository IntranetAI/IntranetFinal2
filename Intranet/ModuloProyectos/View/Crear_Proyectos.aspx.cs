using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProyectos.Controller;
using System.Drawing;
using System.Text;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace Intranet.ModuloProyectos.View
{
    public partial class Crear_Proyectos : System.Web.UI.Page
    {
        public static string usuario = "";
        Controller_Proyectos cp = new Controller_Proyectos();
        bool respuesta = true;
        bool res = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = Session["Usuario"].ToString();
            lblMisProyectos.Text = "<a title='Ver Mis Proyectos' ><img width='30' height='30' src='../../Images/MisProyectos.png' /> Mis Proyectos</a>";
            lblMisProyectos.Attributes.Add("onclick", "window.open('MisProyectos.aspx?u="+Session["Usuario"].ToString()+"','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=700,height=700,left=300,top=150')");
        }

        public void filtro()
        {
            int Estado = 0;
            string Usuario = Session["Usuario"].ToString();
            //if (ddlEstado.SelectedValue.ToString() == "Seleccione..." && txtOT.Text == "" && txtNombreOT.Text == "" && txtCliente.Text == "")
            //{

                if (ddlEstado.SelectedValue.ToString() != "Seleccione...")
                {
                    if (ddlEstado.SelectedValue.ToString() == "En Proceso")
                    {
                        Estado = 1;
                    }
                    else
                    {
                        Estado = 2;
                    }
                    //cargar con estado

                  
                    RadGrid1.DataSource = cp.CargarGrillaProyecto(Usuario, txtNombreProyecto.Text, txtOT.Text, txtNombreOT.Text, txtCliente.Text, Estado, 2);
                    RadGrid1.DataBind();
                }
                else
                {
                    //cargar sin estado

                    RadGrid1.DataSource = cp.CargarGrillaProyecto(Usuario, txtNombreProyecto.Text, txtOT.Text, txtNombreOT.Text, txtCliente.Text, Estado, 1);
                    RadGrid1.DataBind();
                }
            //}
            //else
            //{
            //    RadGrid1.DataSource = cp.CargarGrillaProyecto(Usuario, txtNombreProyecto.Text, "", "", "", 0, 0);
            //    RadGrid1.DataBind();
            //}
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string Usuario=Session["Usuario"].ToString();
           
            
            respuesta = cp.BuscarDisponibilidadyCrear(Usuario , txtNombreProyecto.Text, "", 1);
            if (respuesta == true)
            {
                btnFiltro.Enabled = false;
                txtNombreProyecto.Enabled = false;
                res = cp.BuscarDisponibilidadyCrear(Usuario, txtNombreProyecto.Text, "", 0);
                if (respuesta == true)
                {
                    DivOculto.Visible = true;
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Green");
                    lblMensaje.Text = "Proyecto Creado Correctamente, Ahora asigne OTs al Proyecto.";

                    RadGrid1.DataSource = cp.CargarGrillaProyecto(Usuario, txtNombreProyecto.Text, "", "", "", 0, 0);
                    RadGrid1.DataBind();

                    RadGrid2.DataSource = "";
                    RadGrid2.DataBind();
                }
                else
                {
                    txtNombreProyecto.Enabled = true;
                    divMensaje.Visible = true;
                    lblMensaje.Text = "Ha ocurrido un error.";
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
            else
            {
                btnFiltro.Enabled = true;
                divMensaje.Visible = true;
                lblMensaje.Text = "El Nombre del Proyecto Ya Existe.";
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                divMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtro();
        }

        protected void btnAsignar_Click(object sender, ImageClickEventArgs e)
        {
            bool r = true;
            if (TabContainer1.ActiveTabIndex == 0)
            {
              
                StringBuilder str = new StringBuilder();
                int contadorAsig = 0;
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                       
                        r = cp.BuscarDisponibilidadyCrear(Session["Usuario"].ToString(), txtNombreProyecto.Text, row["OT"].Text, 2);
                        if (r == true)
                        { 
                            contadorAsig++;
                        }

                    }
                }
                if (contadorAsig > 0)
                {
                    //se han modificado blblabla
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Green");
                    lblMensaje.Text = "Ha asignado "+contadorAsig.ToString()+" OT(s) al Proyecto "+txtNombreProyecto.Text+" .";
                }
                else
                {
                }
                
                //carga de gridviews

            }
            else
            {

            }
            filtro();//cargamos grilla 1

            RadGrid2.DataSource = cp.CargarGrillaProyecto(Session["Usuario"].ToString(), txtNombreProyecto.Text, "", "", "", 0, 3);
            RadGrid2.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string usu = Session["Usuario"].ToString();
            if (txtNombreProyecto.Text != "")
            {
                res = cp.BuscarDisponibilidadyCrear(usu, txtNombreProyecto.Text, "", 1);
                if (res == false)
                {


                    RadGrid1.DataSource = cp.CargarGrillaProyecto(usu, txtNombreProyecto.Text, "", "", "", 0, 0);
                    RadGrid1.DataBind();

                    RadGrid2.DataSource = cp.CargarGrillaProyecto(usu, txtNombreProyecto.Text, "", "", "", 0, 3);
                    RadGrid2.DataBind();





                    DivOculto.Visible = true;
                    btnFiltro.Enabled = false;
                }
                else
                {

                    DivOculto.Visible = false;
                    divMensaje.Visible = true;
                    btnFiltro.Enabled = true;
                    lblMensaje.Text = "El proyecto que ha buscado NO existe.";
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Red");
                }

            }
        }

        protected void ibQuitarOTs_Click(object sender, ImageClickEventArgs e)
        {
            bool r = true;
            if (TabContainer1.ActiveTabIndex == 1)
            {

                StringBuilder str = new StringBuilder();
                int contadorAsig = 0;
                int algo = RadGrid2.Items.Count;
                int asd = RadGrid1.Items.Count;
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    GridDataItem row = RadGrid2.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {

                        r = cp.BuscarDisponibilidadyCrear(Session["Usuario"].ToString(), txtNombreProyecto.Text, row["OT"].Text, 3);
                        if (r == true)
                        {
                            contadorAsig++;
                        }

                    }
                }
                if (contadorAsig > 0)
                {
                    //se han modificado blblabla
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Green");
                    lblMensaje.Text = "se Han Eliminado " + contadorAsig.ToString() + " OT(s) al Proyecto " + txtNombreProyecto.Text + " .";
                }
                else
                {
                }

                //carga de gridviews

            }
            else
            {

            }
            filtro();//cargamos grilla 1

            RadGrid2.DataSource = cp.CargarGrillaProyecto(Session["Usuario"].ToString(), txtNombreProyecto.Text, "", "", "", 0, 3);
            RadGrid2.DataBind();
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText)
        {
            //  
            // return (from m in nombres where m.StartsWith(prefixText,StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            cmd.CommandText = "Select TOP 15 NombreProyecto from intranet2.dbo.Proyectos Where NombreProyecto like @prefixText and Usuario=@Usuario ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
            da.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["NombreProyecto"].ToString(), i);
                i++;
            }
            return items;
        }
    }
}