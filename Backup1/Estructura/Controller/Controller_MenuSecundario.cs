using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.Estructura.Controller
{
    public class Controller_MenuSecundario
    {
        //********************************* APLICACIONES *************************************
        public string CargarMenu_AplicacionesSeccion(string usuario, string seccion, int idCategoria)
        {
            string menuLat = "<div id='cssmenu'><ul><li><a href='../../ModuloProduccion/View/EstadoOT.aspx?id=1'><i class='fa fa-fw fa-home'></i>Inicio</a></li>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "List_SeccionMenu_Usuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@idSeccion", seccion);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        menuLat += "<li class='has-sub'><a><i class='fa fa-fw fa-bars'></i>"+ reader["Area"].ToString() + "</a><ul>"; //+ menuLat + "<li ><a>" + reader["Area"].ToString() + "</a>";//<ul>
                        menuLat += CargarMenu_AplicacionesModulo(usuario, Convert.ToInt32(seccion), reader["Area"].ToString(), Convert.ToInt32(reader["IDCategoria"].ToString()));
                        menuLat +=  "</ul></li>";//</ul>
                    }

                    menuLat = menuLat + "</ul></div>";
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return menuLat;
        }

        public string CargarMenu_AplicacionesModulo(string usuario, int seccion, string Area,int idCategoria)
        {
            string subMenu = "";
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
                    subMenu = subMenu + "<li style='margin-left:20px;'><a style='text-align: left;' href=" + reader["Url_Modulo"].ToString() + "?id=" + reader["IDSeccion"].ToString() + "&Cat=" + reader["IDCategoria"].ToString() + ">" + reader["Nombre_Mod"].ToString() + "</a></li>";

                }
            }
            con.CerrarConexion();
            return subMenu;
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