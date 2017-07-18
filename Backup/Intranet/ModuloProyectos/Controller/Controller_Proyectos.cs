using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProyectos.Model;

namespace Intranet.ModuloProyectos.Controller
{
    public class Controller_Proyectos
    {
        public bool BuscarDisponibilidadyCrear(string usuario, string NombreProyecto, string OT, int procedimiento)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Proyectos_NuevoProyecto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@NombreProyecto", NombreProyecto);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            con.CerrarConexion();
            return respuesta;
        }

        //
        public List<ProyectosModelo> CargarGrillaProyecto(string Usuario,string Proyecto,string OT, string NombreOT,string Cliente, int Estado, int Procedimiento)
        {
            List<ProyectosModelo> lista = new List<ProyectosModelo>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Proyectos_OTSinAsignar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Proyecto", Proyecto);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProyectosModelo pro = new ProyectosModelo();
                    pro.OT = reader["QG_RMS_JOB_NBR"].ToString();
                    pro.NombreOT = reader["NM"].ToString();

                    pro.Cliente = reader["CUST_NM"].ToString();

                    string asf = reader["PRN_ORD_QTY"].ToString();
                    int ti = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    pro.Tiraje = ti.ToString("N0").Replace(",", ".");

                    string es = reader["JOB_STS"].ToString();

                    if (es == "1")
                    {
                        pro.Estado = "<div style='Color:Blue;'>En Proceso</div>";
                    }
                    else
                    {
                        pro.Estado = "<div style='Color:Green;'>Liquidada</div>";
                    }


                  
                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();
            return lista;
        }


        public string Carga_MisProyectos(string Usuario, string NombreProyecto, string OT,int Procedimiento)
        {
            
            string RackLibre = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:650px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Nombre Proyecto</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Fecha Creación</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Estado</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'></td>" +
                //"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Activar/Desactivar Proyecto</td>" +
                "</tr>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {

                cmd.CommandText = "[Proyectos_NuevoProyecto]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NombreProyecto", NombreProyecto);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    string nombre = reader["NombreProyecto"].ToString();

                    DateTime fechacreacion=Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    string FechaC = fechacreacion.ToString("dd/MM/yyyy HH:ss:mm");
                    string Estado="";
                    string Actividad = "";
                    if (reader["Estado"].ToString() == "1")
                    {
                        Estado = "<div style='Color:Green;'>ACTIVO</div>";
                        //Actividad = "<div style='Color:Blue;'><a href='#' style='text-Decorate:none'>Activar</a></div>";
                    }
                    else
                    {
                        Estado = "<div style='Color:Red;'>INACTIVO</div>";
                       // Actividad = "<div style='Color:Black;'><a href='#' style='text-Decorate:none'>Desctivar</a></div>";
                    }

                    RackLibre = RackLibre +
                        "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
        "<asp:Label ID='lblDespachado' runat='server'>" + nombre.ToUpper() + "</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>" +
    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
      "  <asp:Label ID='lblPrimerDesp' runat='server'>" + FechaC + "</asp:Label></td>" +
    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
        "<asp:Label ID='lblUltDesp' runat='server'>" + Estado + "</asp:Label></td>" +
    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
        "<asp:Label ID='lblDevolucion' runat='server'><a href='MisProyectos.aspx?u=" + Usuario + "&n=" + nombre + "'>Ver Más</a></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp; </td>" +

        // "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
        //"<asp:Label ID='lblUltDesp' runat='server'>" + Actividad + "</asp:Label></td>" +
  "</tr>";

                     
                   
                }
                RackLibre = RackLibre + "</tbody></table>";
            }
            con.CerrarConexion();
            return RackLibre;
        }

        public List<ProyectosOT> CargarOTSProyecto(string usuario, string nombreproyecto, int procedimiento)
        {
            List<ProyectosOT> lista = new List<ProyectosOT>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Proyectos_ListaProyectos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@NombreProyecto", nombreproyecto);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProyectosOT pro = new ProyectosOT();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();


                    int envEnc = Convert.ToInt32(reader["totalEnviado"].ToString());
                    pro.EnviadoEnc = envEnc.ToString("N0").Replace(",", ".");


                    pro.Cliente = reader["Cliente"].ToString();

                    int TT = Convert.ToInt32(reader["TirajeTotal"].ToString());
                    int ti = Convert.ToInt32(reader["TirajeTotal"].ToString());
                    pro.TirajeTotal = ti.ToString("N0").Replace(",", ".");

                    int dev = Convert.ToInt32(reader["Devolucion"].ToString());

                    pro.Devolucion = dev.ToString("N0").Replace(",", ".");

                    int TTD = Convert.ToInt32(reader["TotalDespachado"].ToString());
                    pro.TotalDespachado = TTD.ToString("N0").Replace(",", ".");


                   // int TTR = Convert.ToInt32(reader["TotalRecepcionado"].ToString());
                    DateTime fecU = Convert.ToDateTime(reader["UltimaFechaDesp"].ToString());
                    pro.TotalRecepcionado = fecU.ToString("dd/MM/yyyy HH:mm");

                  //  string aaa = "http://www.google.cl?id=" + pro.OT;

                    pro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + pro.OT + "\",\"" + pro.NombreOT + "\")'>Más</a>";
                      

                    int TD = Convert.ToInt32(reader["TotalDespachado"].ToString());

                 
                    int resul = TT - TD;
                    int avanc = 0;
                    if (TT == 0)
                    {
                        avanc = 0;

                    }
                    else
                    {

                        avanc = ((TD * 100 / TT * 100));

                        if (avanc == 0)
                        {
                            avanc = 0;

                        }
                        else
                        {
                            string avanc2 = avanc.ToString().Substring(0, avanc.ToString().Length - 2);
                            avanc = Convert.ToInt32(avanc2.ToString());

                        }
                    }

                    //orden.Ejemplares = result.ToString();
                    if (avanc >= 100)
                    {
                        pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>100%";
                    }
                    else
                    {
                        if (avanc < 10)
                        {
                            pro.Avance = "<a> " + avanc.ToString() + "%</a>";
                        }
                        if (avanc >= 10 && avanc < 20)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 20 && avanc < 30)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 30 && avanc < 40)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 40 && avanc < 50)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 50 && avanc < 60)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 60 && avanc < 70)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 70 && avanc < 80)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 80 && avanc < 90)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' /> " + avanc.ToString() + "%";
                        }
                        if (avanc >= 90 && avanc < 100)
                        {
                            pro.Avance = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' /> " + avanc.ToString() + "%";
                        }
                    }

                    if (resul < 0)
                    {
                        pro.Saldo = "0";
                    }
                    else
                    {
                        pro.Saldo = resul.ToString("N0").Replace(",", ".");
                    }




                    string es = reader["Estado"].ToString();

                    if (es == "1")
                    {
                        pro.Estado = "<div style='Color:Blue;'>En Proceso</div>";
                    }
                    else
                    {
                        pro.Estado = "<div style='Color:Green;'>Liquidada</div>";
                    }



                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }


        public List<ProyectosOT> CargarOT(string usuario, string nombreproyecto, int procedimiento)
        {
            List<ProyectosOT> lista = new List<ProyectosOT>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Proyectos_ListaProyectos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@NombreProyecto", nombreproyecto);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProyectosOT pro = new ProyectosOT();
                    pro.OT = reader["OT"].ToString();



                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }



        public string Carga_HistorialOT(string OT)
        {

            string RackLibre = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;  width:650px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Nombre OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Estado</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Responsable</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Fecha Modificación</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Observación</td>" +
                "</tr>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {

                cmd.CommandText = "[Proyectos_HistorialLiquidadas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                   // string nombre = reader["NombreProyecto"].ToString();

                    //DateTime fechacreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    //string FechaC = fechacreacion.ToString("dd/MM/yyyy HH:ss:mm");
                    string Estado = "";
                    if (reader["Estado"].ToString() == "1")
                    {
                        Estado = "<div style='Color:Blue;'>En Proceso</div>";
                    }
                    else
                    {
                        Estado = "<div style='Color:Red;'>Liquidada</div>";
                    }
                    DateTime Fec = Convert.ToDateTime(reader["FechaModificacion"].ToString());
                            RackLibre = RackLibre +
             "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + reader["OT"].ToString() + "</asp:Label></td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + reader["NombreOT"].ToString() + "</asp:Label></td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + Estado + "</asp:Label></td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + reader["ModificadaPor"].ToString() + "</asp:Label></td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + Fec.ToString("dd/MM/yyyy HH:mm:ss") + "</asp:Label></td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                "<asp:Label ID='lblUltDesp' runat='server'>" + reader["Observacion"].ToString() + "</asp:Label></td>" +
          "</tr>";



                }
                RackLibre = RackLibre + "</tbody></table>";
            }
            con.CerrarConexion();
            return RackLibre;
        }
    }
}