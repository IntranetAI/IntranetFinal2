using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdmin.Controller;
using Telerik.Web.UI;
using Intranet.ModuloJefatura.Model;
using Intranet.View.Controller;
using System.Text;

namespace Intranet.ModuloJefatura.View
{
    public partial class asignarModulos : System.Web.UI.Page
    {
        Controller_Usuarios cUsu = new Controller_Usuarios();
        Controller_Login cLogin = new Controller_Login();
        int id = 0;
        string correo = "";
        string nombre = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarUsuarios();
                    try
                    {
                        cargarModulos(Convert.ToInt32(lblidUs.Text));
                        cargarModulosAsignados(Convert.ToInt32(lblidUs.Text));

                    }
                    catch
                    {
                    }
                    TabPanel2.Enabled = false;
                    TabPanel3.Enabled = false;

                    try
                    {
                        int? idus = Convert.ToInt32(Request.QueryString["i"]);
                        string nombre = Request.QueryString["n"];
                        string elm = Request.QueryString["e"];
                        if (idus != 0)
                        {
                            if (elm == "1")
                            {
                                cUsu.EliminarSolicitud(idus);
                                string popupScript = "<script language='JavaScript'> alert(' Se ha eliminado correctamente la solicitud de activacion de cuenta, del  usuario: " + nombre + " .');</script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                            else
                            {
                                cUsu.CambiarInactivoCorreo(idus);
                                cargarUsuarios();
                                string popupScript = "<script language='JavaScript'> alert(' La cuenta del usuario: " + nombre + " ha sido Activada Correctamente.\\n * Para Asignarle Modulos, presione el nombre del usuario en la lista.');</script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                        }
                    }
                    catch
                    {
                    }



                }
            }
            catch
            {
                Response.Redirect("http://Intranet.qgchile.cl");
            }

            //Label3.Text = Session["CentroCosto"].ToString();

        }
        public void cargarUsuarios()
        {       
            RadGrid1.DataSource = cUsu.ListarUsuarios(6, Session["Nombre"].ToString());
            RadGrid1.DataBind();
        
        }
        public void cargarModulos(int idUsuario)
        {
            RadGrid2.DataSource = cUsu.ListarModulosUsuario(1, idUsuario,Session["CentroCosto"].ToString());
            RadGrid2.DataBind();
        }
        public void cargarModulosAsignados(int idusuario)
        {
            RadGrid3.DataSource = cUsu.ListarModulosUsuario(2, idusuario, Session["CentroCosto"].ToString());
            RadGrid3.DataBind();
        }
        protected void contactsGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            TabPanel2.Enabled = true;
            TabPanel3.Enabled = true;
            TabContainer1.ActiveTabIndex = 1;
            GridDataItem item = (GridDataItem)e.Item;
            nombre = item["Nombre"].Text;
            id = Convert.ToInt32(item["idUsuario"].Text);
            correo = item["Correo"].Text;
            Label2.Text = "Usuario: "+nombre+"<br />"+correo;
            lblidUs.Text = id.ToString();

            cargarModulos(id);
            cargarModulosAsignados(id);

            ibDesasignar.Visible = true;
            ibMultiCheck.Visible = true;
        }
        protected void contactsGrid_ItemCommand2(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }
        protected void contactsGrid_ItemCommand3(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }

        protected void ibMultiCheck_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            if (TabContainer1.ActiveTabIndex == 1)
            {
                List<Modulos> list = new List<Modulos>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    GridDataItem row = RadGrid2.Items[i];

                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;
                        Modulos asi = new Modulos();
                        asi.IDModulo = Convert.ToInt32(row["IDModulo"].Text);
                        list.Add(asi);
                    }
                }
                //contador
                string contadorIns = contadorInsert.ToString();
                //llamada procedimiento
                cUsu.AsignarModulos(list, Convert.ToInt32(lblidUs.Text));
                ////carga de gridviews
                cargarModulos(Convert.ToInt32(lblidUs.Text));
                cargarModulosAsignados(Convert.ToInt32(lblidUs.Text));
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Asignado " + contadorIns.ToString() + " Modulos!  ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡No se puede asignar Modulos !');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ibEliminarSuscrita_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            if (TabContainer1.ActiveTabIndex == 2)
            {
                List<Modulos> list = new List<Modulos>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid3.Items.Count; i++)
                {
                    GridDataItem row = RadGrid3.Items[i];

                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;
                        Modulos asi = new Modulos();
                        asi.IDModulo = Convert.ToInt32(row["IDModulo"].Text);
                        list.Add(asi);
                    }
                }
                //contador
                string contadorIns = contadorInsert.ToString();
                //llamada procedimiento
                cUsu.DesasignarModulos(list, Convert.ToInt32(lblidUs.Text));
                ////carga de gridviews
                cargarModulos(Convert.ToInt32(lblidUs.Text));
                cargarModulosAsignados(Convert.ToInt32(lblidUs.Text));
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Desasignado " + contadorIns.ToString() + " Modulos!  ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡No se puede Desasignar Modulos !');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}