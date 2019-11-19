using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.View.Controller
{
    public class ControllerSubMenu
    {
        public string CargarSubMenu(string usuario, int IDArea)
        {
            string subMenu = "<ul id='css3menu1' style='width:133px;'>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListSeccion2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@IDArea", IDArea);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subMenu = subMenu + "<li ><a>" + reader["Nombre_Seccion"].ToString() + "</a><ul>";

                    if (Convert.ToInt32(reader["Informe"].ToString()) != 0)
                    {
                        subMenu = subMenu + "<li><a href='#'><span><img src='../../Menu/images/news.png' alt=''/>Informes</span></a>";
                        subMenu = subMenu + CargarModulo(usuario, Convert.ToInt32(reader["IDSeccion"].ToString()), IDArea);
                        subMenu = subMenu + "</li>";
                    }

                    if (Convert.ToInt32(reader["Aplicacion"].ToString()) != 0)
                    {
                        subMenu = subMenu + "<li><a><span><img src='../../Menu/images/samples.png' alt=''/>Aplicaciones</span></a>";
                        subMenu = subMenu + CargarSeccionMenu(usuario, Convert.ToInt32(reader["IDSeccion"].ToString()));
                        subMenu = subMenu + "</li>";
                    }

                    subMenu = subMenu + "</ul></li>";
                }
                subMenu = subMenu + "</ul>";
            }
            con.CerrarConexion();
            return subMenu;
        }

        public string CargarModulo(string usuario, int IDSeccion, int IDArea)
        {
            string subMenu = "<ul>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListModulo2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@IDSeccion", IDSeccion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    if (reader["Nombre_Modulo"].ToString() == "Dashboard")
                    {
                        subMenu = subMenu + "<li><a target='_blank' href=" + reader["Url_Modulo"].ToString() + "?id=" + IDArea + ">" + reader["Nombre_Modulo"].ToString() + "</a></li>";
                    }
                    else
                    {
                        subMenu = subMenu + "<li><a href=" + reader["Url_Modulo"].ToString() + "?id=" + IDArea + ">" + reader["Nombre_Modulo"].ToString() + "</a></li>";
                    }

                }
                subMenu = subMenu + "</ul>";
            }
            con.CerrarConexion();
            return subMenu;
        }

        public string CargarSeccionMenu(string usuario, int IDSeccion)
        {//aquiiiiii
            string subMenu = "<ul>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListCategoria";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@IDSeccion", IDSeccion);
              
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subMenu = subMenu + "<li><a href='" + reader["Url_Modulo"].ToString() + "?id=" + reader["IDSeccion"].ToString() + "&cat=" + reader["IDCategoria"].ToString() + "'>" + reader["Nombre_cat"].ToString() + "</a></li>";

                }
                subMenu = subMenu + "</ul>";
            }
            con.CerrarConexion();
            return subMenu;
        }

        public string CargarAplicaciones_Menu(string usuario, string seccion,int idCategoria)
        {
            string menuLat = "<ul id='css3menu1' ><li><a href='../../ModuloProduccion/View/Suscripcion.aspx?id=1'>Inicio</a></li>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_SeccionMenu_Usuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idSeccion", seccion);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menuLat = menuLat + "<li ><a>" + reader["Area"].ToString() + "</a>";//<ul>
                    menuLat = menuLat + CargarModuloSub(usuario, Convert.ToInt32(seccion), reader["Area"].ToString(), Convert.ToInt32(reader["IDCategoria"].ToString()));
                    menuLat = menuLat + "</li>";//</ul>
                }

                menuLat = menuLat + "</ul>";
            }
            con.CerrarConexion();
            return menuLat;
        }

        public string CargarModuloSub(string usuario, int seccion, string Area,int idCategoria)
        {
            string subMenu = "<ul>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_ModuloMenu_Usuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@categoria", Area);
                cmd.Parameters.AddWithValue("@IDCategoria",idCategoria);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subMenu = subMenu + "<li><a href=" + reader["Url_Modulo"].ToString() + "?id=" + reader["IDSeccion"].ToString() + "&Cat="+reader["IDCategoria"].ToString()+">" + reader["Nombre_Mod"].ToString() + "</a></li>";

                }
                subMenu = subMenu + "</ul>";
            }
            con.CerrarConexion();
            return subMenu;
        }

        public string CargarMenuRastro(string Url)
        {
            string MenuRastro = "<div style='color:#555;float:left;font-family:Geneva,Arial,Helvetica,sans-serif;font-size:11px;text-align:left;vertical-align:top;text-decoration:none;margin-left:5px;'>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListMenuRastro";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Url", Url);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MenuRastro = MenuRastro + "<a href='../../View/Pagina_Inicio.aspx'>Inicio</a> >> " + reader["Nombre_Seccion"].ToString() + " >> " + reader["Tipo"].ToString() + " >> " + reader["Nombre_Cat"].ToString() + " >> <a href='" + reader["Url_Modulo"].ToString() + "?id=" + reader["IDArea"].ToString() + "&cat=" + reader["IDCategoria"].ToString() + "'>" + reader["Nombre_Mod"].ToString() + "</a>";
                }
            }
            MenuRastro = MenuRastro + "</div>";
            con.CerrarConexion();
            return MenuRastro;
        }

        //********************************* PROYECTOS *************************************
        public string CargarMenuProyectos(string usuario)
        {
            string subMenu = "<ul id='css3menu1' style='width:133px;margin-top:-1px;'>";
            string Cont = "<ul>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Proyectos_CargaMenu]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Cont = Cont + "<li><a href='../../ModuloProyectos/View/Carga_Proyecto.aspx?p=" + reader["NombreProyecto"].ToString() + "'>" + reader["NombreProyecto"].ToString() + "</a></li>";
                }
                Cont = Cont + "</ul>";

                subMenu = subMenu + "<li ><a>Proyectos</a><ul>";
                subMenu = subMenu + "<li><a href='#'><span><img src='../../Menu/images/news.png' alt=''/>Mis Proyectos</span></a>";
                subMenu = subMenu + Cont;
                subMenu = subMenu + "<li><a><span><img src='../../Menu/images/samples.png' alt=''/>Aplicaciones</span></a>";
                subMenu = subMenu + "<ul><li><a href='../../ModuloProyectos/View/Crear_Proyectos.aspx?id=1'>Administrar Proyectos</a></li></ul>";
                subMenu = subMenu + "</li>";

                subMenu = subMenu + "</ul></li></ul>";
            }
            con.CerrarConexion();
            return subMenu;
        }

        public string CargarAplicaciones_Proyecto(string usuario)
        {
            string menuLat = "<ul id='css3menu1' ><li><a href='../../ModuloProduccion/View/Suscripcion.aspx?id=1'>Inicio</a></li>";
            string Cont = "<ul>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Proyectos_CargaMenu";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cont = Cont + "<li><a href='../../ModuloProyectos/View/Carga_Proyecto.aspx?p=" + reader["NombreProyecto"].ToString() + "'>" + reader["NombreProyecto"].ToString() + "</a></li>";
                 //   menuLat = menuLat + "<li ><a>" + reader["Area"].ToString() + "</a>";//<ul>
                  //  menuLat = menuLat + CargarModuloSub(usuario, Convert.ToInt32(seccion), reader["Area"].ToString());
                   // menuLat = menuLat + "</li>";//</ul>
                }
                Cont = Cont + "</ul>";
                menuLat = menuLat + "<li><a>Mis Proyectos</a>";

                menuLat = menuLat + Cont;
                //menuLat = menuLat + "<li><a href='#'><span><img src='../../Menu/images/news.png' alt=''/>Informes</span></a>";
                //menuLat = menuLat + Cont;
                menuLat = menuLat + "<li><a>Administración</a>";
                menuLat = menuLat + "<ul><li><a href='../../ModuloProyectos/View/Crear_Proyectos.aspx?id=1'>Administrar Proyectos</a></li></ul>";
                menuLat = menuLat + "</li>";

                menuLat = menuLat + "</ul>";
            }
            con.CerrarConexion();
            return menuLat;
        }
    }
}