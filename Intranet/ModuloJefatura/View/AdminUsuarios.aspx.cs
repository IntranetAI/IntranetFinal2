using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdmin.Controller;
using Intranet.ModuloJefatura.Model;
using System.Text;
using Telerik.Web.UI;

namespace Intranet.ModuloJefatura.View
{
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        Controller_Usuarios cUsu = new Controller_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarInactivos();
                cargarDeshabilitados();
                cargarTodos();
            }
          

        }
        public void cargarInactivos()
        {
            RadGrid1.DataSource = cUsu.ListarUsuarios(4, Session["Nombre"].ToString());
            RadGrid1.DataBind();
        }
        public void cargarDeshabilitados()
        {
            RadGrid2.DataSource = cUsu.ListarUsuarios(5, Session["Nombre"].ToString());
            RadGrid2.DataBind();
        }
        public void cargarTodos()
        {
            RadGrid3.DataSource = cUsu.ListarUsuarios(6,  Session["Nombre"].ToString());
            RadGrid3.DataBind();
        }
        protected void contactsGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "" && txtNombre.Text == "" && txtUsername.Text == "")
            {
                //mensaje error
            }
            else
            {
                RadGrid1.DataSource = cUsu.ListarUsuariosFiltro(1, Session["Nombre"].ToString(), txtUsername.Text, txtNombre.Text, txtCorreo.Text);
                RadGrid1.DataBind();
                //grd2
                RadGrid2.DataSource = cUsu.ListarUsuariosFiltro(2, Session["Nombre"].ToString(),txtUsername.Text, txtNombre.Text, txtCorreo.Text);
                RadGrid2.DataBind();
                //grd3
                RadGrid3.DataSource = cUsu.ListarUsuariosFiltro(3, Session["Nombre"].ToString(), txtUsername.Text, txtNombre.Text, txtCorreo.Text);
                RadGrid3.DataBind();

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            cargarDeshabilitados();
            cargarInactivos();
            cargarTodos();
            string popupScript = "<script language='JavaScript'> alert(' ¡ Registros Actualizados Correctamente !  ');</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = true;
        }

        protected void ibMultiCheck_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            if (TabContainer1.ActiveTabIndex == 0)
            {
                List<Activar> list = new List<Activar>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];

                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;
                        Activar asi = new Activar();
                        asi.Usuario = row["Usuario"].Text;
                        asi.Estado = 1;
                        list.Add(asi);
                    }
                }
                //contador
                string contadorIns = contadorInsert.ToString();
                //llamada procedimiento
                cUsu.usuarioInactivos(list);
                ////carga de gridviews
                cargarInactivos();
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Activado " + contadorIns.ToString() + " Cuenta(s) de Usuario !  ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                List<Activar> list2 = new List<Activar>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    GridDataItem row = RadGrid2.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;
                        Activar asi = new Activar();
                        asi.Usuario = row["Usuario"].Text;
                        asi.Estado = 1;
                        list2.Add(asi);
                    }
                }
                //contador
                string contadorIns = contadorInsert.ToString();
                //llamada procedimiento
                cUsu.usuarioDeshabilitados(list2);
                //////carga de gridviews
                cargarInactivos();
                cargarDeshabilitados();
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Habilitado " + contadorIns.ToString() + " Cuenta(s) de Usuario !  ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ibEliminarSuscrita_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            if (TabContainer1.ActiveTabIndex == 2)
            {
                List<Activar> list3 = new List<Activar>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid3.Items.Count; i++)
                {
                    GridDataItem row = RadGrid3.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;
                        Activar asi = new Activar();
                        asi.Usuario = row["Usuario"].Text;
                        asi.Estado = 1;
                        list3.Add(asi);
                    }
                }
                //contador
                string contadorIns = contadorInsert.ToString();
                //llamada procedimiento
                cUsu.DeshabilitarUsuarios(list3);
                //////carga de gridviews
                cargarInactivos();
                cargarDeshabilitados();
                cargarTodos();
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han deshabilitado " + contadorIns.ToString() + " Cuenta(s) de Usuario !  ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}