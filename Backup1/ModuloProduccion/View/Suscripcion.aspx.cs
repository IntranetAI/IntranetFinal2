using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System.Text;
using Telerik.Web.UI;
using Intranet.View.Controller;
using System.Web.UI.HtmlControls;
using System.Web.Services;

namespace Intranet.ModuloProduccion.View
{
    public partial class Suscripcion : System.Web.UI.Page
    {
        bool respuesta;
        OrdenController controlot = new OrdenController();
        public static List<Orden> lista = new List<Orden>();
        public static List<Orden> lista2 = new List<Orden>();
        public static List<Orden> lista3 = new List<Orden>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSuscripcion();
                cargarLeidos();
                CargarAsignadas();
                SincroController control_sincro = new SincroController();
                //if (control_sincro.GenerarCorreoInformeFacturacion("", "", "0"))
                //{
                //}

            }
            
                HtmlAnchor MyLnk = (HtmlAnchor)this.Master.FindControl("menuProduccion");
                MyLnk.Attributes.Add("class", "b-hover");

        }

        public void CargarSuscripcion()
        {
            lista = controlot.ListarOrdenes("", "", "", null, null, Session["Usuario"].ToString(), 1);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
        }

        public void cargarLeidos()
        {
            lista3 = controlot.ListarOrdenes("", "", "", null, null, Session["Usuario"].ToString(), 5);
            RadGrid3.DataSource = lista3;
            RadGrid3.DataBind();
        }

        public void CargarAsignadas()
        {
            lista2 = controlot.ListarOrdenes("", "", "", null, null, Session["Usuario"].ToString(), 3);
            RadGrid2.DataSource = lista2;
            RadGrid2.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                //seteo fecha Inicio
                string FecI = txtFechaInicio.Text;
                string[] str = FecI.Split('-');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                string FI = año + "-" + mes + "-" + dia;
                //fin fecha Inicio

                //seteo Fecha Termino
                string FecT = txtFechaTermino.Text;
                string[] str2 = FecT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);
                string FT = año2 + "-" + mes2 + "-" + dia2;
                //fin fecha Termino
                lista = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, FI, FT, Session["Usuario"].ToString(), 2);
                RadGrid1.DataSource = lista;
                RadGrid1.DataBind();

                lista2 = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, FI, FT, Session["Usuario"].ToString(), 4);
                RadGrid2.DataSource = lista2;
                RadGrid2.DataBind();

                lista3 = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, FI, FT, Session["Usuario"].ToString(), 6);
                RadGrid3.DataSource = lista3;
                RadGrid3.DataBind();
            }
            else
            {

                lista = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, "", "", Session["Usuario"].ToString(), 1);
                RadGrid1.DataSource = lista;
                RadGrid1.DataBind();

                lista2 = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, "", "", Session["Usuario"].ToString(), 3);
                RadGrid2.DataSource = lista2;
                RadGrid2.DataBind();

                lista3 = controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, "", "", Session["Usuario"].ToString(), 5);
                RadGrid3.DataSource = lista3;
                RadGrid3.DataBind();
            }

            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        { 
            //boton recargar grillas
            CargarSuscripcion();
            TabContainer1.ActiveTabIndex = 0;

            string popupScript = "<script language='JavaScript'> alert(' Actualizacion de OT Realizada Correctamente (Inactivo)');</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);


            //string query = controlot.CargarDatos2000();
            //if (controlot.IngresarExporta(query))
            //{
            //    string popupScript = "<script language='JavaScript'> alert(' Actualizacion de OT Realizada Correctamente');</script>";
            //    Page.RegisterStartupScript("PopupScript", popupScript);
            //}
            
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            //divbotones.Style.Add("margin-Top", "-25px");
            Panel2.Visible = true;
        }

        protected void ibEliminarSuscrita_Click(object sender, ImageClickEventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 1)
            {
                List<Asignar> listA = new List<Asignar>();
                StringBuilder str = new StringBuilder();
                int contadorElimina = 0;
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    GridDataItem row = RadGrid2.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorElimina++;
                        Asignar asi = new Asignar();
                        asi.NumeroOT = row["NumeroOT"].Text;
                        asi.Estado = 2;
                        listA.Add(asi);

                    }
                }
                //contador
                string muestacontador = contadorElimina.ToString();
                //lamada procedimiento
                Controller_Login log = new Controller_Login();
                int idu = log.BuscarIDUsuario(Session["Usuario"].ToString());
                controlot.AsignarNoLeidas(listA, idu);
                //carga de gridviews
                CargarAsignadas();
                cargarLeidos();
                CargarSuscripcion();
                //mensaje
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Removido " + muestacontador.ToString() + " OTs Suscritas! \\n\\n*Ahora podrá encontrarlas en OTs Sin Suscribir ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

            }
            else
            {

                string popupScript = "<script language='JavaScript'> alert(' ¡Solo se puede Remover las OTs Suscritas! ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);


                //location.href='Suscripcion.aspx'
            }

        }

        protected void ibMultiCheck_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int contadorInsert = 0;
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    List<Asignar> list = new List<Asignar>();
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        GridDataItem row = RadGrid1.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        if (isChecked)
                        {
                            contadorInsert++;
                            Asignar asi = new Asignar();
                            asi.NumeroOT = row["NumeroOT"].Text;
                            asi.Estado = 1;
                            list.Add(asi);
                        }
                        else
                        {
                            Asignar asi = new Asignar();
                            asi.NumeroOT = row["NumeroOT"].Text;
                            asi.Estado = 2;
                            list.Add(asi);
                        }
                    }
                    //contador
                    string contadorIns = contadorInsert.ToString();
                    //llamada procedimiento
                    Controller_Login login = new Controller_Login();
                    int IDUsuario = login.BuscarIDUsuario(Session["Usuario"].ToString());
                    controlot.AsignarOT(list, IDUsuario);
                    //carga de gridviews
                    CargarAsignadas();
                    cargarLeidos();
                    CargarSuscripcion();
                    //mensaje 
                    string popupScript = "<script language='JavaScript'> alert(' ¡Se ha Suscrito a " + contadorIns.ToString() + " OTs ! \\n\\n* Las OTs que no ha seleccionado, las puede encontrar en OTs sin Suscribir ');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    int contadorSinSus = 0;
                    List<Asignar> listA = new List<Asignar>();
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < RadGrid3.Items.Count; i++)
                    {
                        GridDataItem row = RadGrid3.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        if (isChecked)
                        {
                            contadorSinSus++;
                            Asignar asi = new Asignar();
                            asi.NumeroOT = row["NumeroOT"].Text;
                            asi.Estado = 1;
                            listA.Add(asi);

                        }
                    }
                    //contador
                    string contadorNoSus = contadorSinSus.ToString();
                    //procedimiento
                    Controller_Login log = new Controller_Login();
                    int idu = log.BuscarIDUsuario(Session["Usuario"].ToString());
                    controlot.AsignarLeidas(listA, idu);
                    //cargar gridviews
                    CargarAsignadas();
                    cargarLeidos();
                    CargarSuscripcion();
                    //mensaje
                    string popupScript = "<script language='JavaScript'> alert(' ¡Se ha Suscrito a " + contadorNoSus.ToString() + " OTs ! ');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);

                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert(' ¡Solo se puede Suscribir OTs Nuevas y OTs sin Suscripcion! ');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception a)
            {
                txtNumeroOT.Text = a.Message;
            }
        }

        protected void contactsGrid_ItemCommand2(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void RadGrid1_SortCommand(object sender, GridSortCommandEventArgs e)
        {            
            if ("NumeroOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista.OrderBy(o=>o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o=>o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista.OrderByDescending(o=>o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista.OrderBy(o=>o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista.OrderByDescending(o=>o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("ejem".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista.OrderBy(o=>o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista.OrderByDescending(o=>o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("FechaOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista.OrderBy(o=>o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista.OrderByDescending(o=>o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreCliente".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista.OrderBy(o=>o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista.OrderByDescending(o=>o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
        }

        protected void RadGrid2_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if ("NumeroOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista2;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderBy(o => o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o=>o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderByDescending(o => o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista2;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderBy(o => o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderByDescending(o => o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("ejem".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista2;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderBy(o => o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderByDescending(o => o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("FechaOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista2;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderBy(o => o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderByDescending(o => o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreCliente".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista2;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderBy(o => o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista2.OrderByDescending(o => o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
        }

        protected void RadGrid3_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if ("NumeroOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista3;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderBy(o => o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o=>o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderByDescending(o => o.NumeroOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NumeroOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista3;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderBy(o => o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderByDescending(o => o.NombreOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("ejem".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista3;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderBy(o => o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderByDescending(o => o.ejem);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.ejem);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("FechaOT".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista3;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderBy(o => o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderByDescending(o => o.FechaOT);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.FechaOT);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
            if ("NombreCliente".Equals(e.CommandArgument))
            {
                switch (e.NewSortOrder)
                {
                    case GridSortOrder.None:
                        e.Item.OwnerTableView.DataSource = lista3;//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Ascending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderBy(o => o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderBy(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                    case GridSortOrder.Descending:
                        e.Item.OwnerTableView.DataSource = lista3.OrderByDescending(o => o.NombreCliente);//controlot.ListarOrdenes(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(FI), Convert.ToDateTime(FT), Session["Usuario"].ToString(), 1).OrderByDescending(o => o.NombreCliente);
                        e.Item.OwnerTableView.Rebind();
                        break;
                }
            }
        }

        protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
        }
        [WebMethod]
        public static string SincroAutoOTS(string Usuario, string Horas, string Minutos)
        {               
            SincroController controlSin = new SincroController();
            string fec = DateTime.Now.ToString("yyyy/MM/dd");
            int ins = controlSin.SincronizarOTAutomatica(Usuario, Convert.ToDateTime(fec + " " + Horas + ":00:" + "00"), 1);
            if (ins != 0)
            {
                try
                {
                    List<SincronizarOT> lista = controlSin.listaOTSincroOT();
                    List<SincronizarOT> listaSincro = controlSin.listaOTSincroMetrics();
                    string query = "";
                    int contador = 0;
                    foreach (SincronizarOT sinOT in listaSincro)
                    {
                        int count = lista.Where(o => o.QG_RMS_JOB_NBR.Trim() == sinOT.QG_RMS_JOB_NBR.Trim()).Count();
                        if (count == 0)
                        {
                            DateTime fecha = Convert.ToDateTime(sinOT.CTD_TMSTMP);
                            query = query + "INSERT INTO Data_P2B.dbo.QGPressJob (QG_RMS_JOB_NBR ,NM ,CTD_TMSTMP ,DUE_DT ,JOB_STS ,CUST_RUT ,CUST_NM, QG_RMS_TITLE_CD ," +
                                                " PRN_ORD_QTY,IMPZ_PROD_HGT,IMPZ_PROD_WDT,OPN_WDTH,OPN_HGT,AccountAddress1,AccountAddress2,AccountNeighborhood," +
                                                " AccountRegion,AccountCountry,AccountCity ,FullIssueName,FECHA_LIQUIDACION) VALUES" +
                                                "('" + sinOT.QG_RMS_JOB_NBR.Trim() + "','" + sinOT.NM + "','" + fecha.ToString("yyyy-dd-MM HH:mm:ss") + "',NULL," + sinOT.JOB_STS + ",'" + sinOT.CUST_RUT + "','" +
                                                sinOT.CUST_NM + "','" + sinOT.QG_RMS_TITLE_CD + "'," + sinOT.PRN_ORD_QTY + ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);";
                        }
                        else
                        {
                            query = query + "UPDATE Data_P2B.dbo.QGPressJob SET NM = '" + sinOT.NM + "',CUST_RUT = '" + sinOT.CUST_RUT + "'" +
                                            ",CUST_NM = '" + sinOT.CUST_NM + "',PRN_ORD_QTY = " + sinOT.PRN_ORD_QTY + ", JOB_STS= " + sinOT.JOB_STS + " WHERE QG_RMS_JOB_NBR = '" + sinOT.QG_RMS_JOB_NBR.Trim() + "';";
                        }
                        contador++;
                    }
                }
                catch (Exception e)
                {
                    bool r = controlSin.generarCorreoErrorSuscripcion(e.ToString());
                }
            }
            return "";
        }

        
        [WebMethod]
        public static string Sincro2000()
        {
            string[] Fecha = DateTime.Now.ToString("yyyy-MM-dd").Split('-');

            SincroController control_sincro = new SincroController();
            if (control_sincro.SincronizadorACR(Fecha[0],Fecha[1],Fecha[2])=="OK")
            {
            }
               
            return "";
        }

        [WebMethod]
        public static string CorreoProduccion_SobreImpresion(string Usuario)
        {
            InformeProduccion_Controller inf = new InformeProduccion_Controller();
            //if (!inf.ValidadordeCorreoSobreConsumo(Usuario, DateTime.Now, 0))
            //{
            //    inf.GenerarCorreoComparativo("", DateTime.Now.AddDays(-1), DateTime.Now, 0);
            //    inf.ValidadordeCorreoSobreConsumo(Usuario, DateTime.Now, 1);
            //}
            //if (!inf.ValidadordeCorreoSobreConsumoPesos(Usuario, DateTime.Now, 0))
            //{
            //    inf.GenerarCorreoComparativo("", DateTime.Now.AddDays(-1), DateTime.Now, 1);
            //    inf.ValidadordeCorreoSobreConsumoPesos(Usuario, DateTime.Now, 1);
            //}

            return "";
        }
    }
}