using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloEncuadernacion.Model;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_ProductosTerminados
    {
        public int CapturaCodigo2(string Usuario,int procedimiento)
        {
            int Tarea = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[PT_CapturaCodigo2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tarea = Convert.ToInt32(reader["cod_Pallet"].ToString());
                }
            }
            con.CerrarConexion();
            return Tarea;
        }
        public int CapturaCodigo()
        {
            int Tarea = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[PT_CapturaCodigo]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tarea = Convert.ToInt32(reader["cod_Pallet"].ToString());
                }
            }
            con.CerrarConexion();
            return Tarea;
        }

        public List<Prod_Terminados> BuscaPallet(string cod_pallet)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            int total = 0;
            if (cmd != null)
            {
                cmd.CommandText = "PT_ListaPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                   // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();
                    p.Total = reader["Total"].ToString();

                    total = total + Convert.ToInt32(p.Total);

                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString();
                    // p.NombreOperario = reader["NombreOperario"].ToString();
                    //p.Maquina = reader["Maquina"].ToString();
                   // p.Proceso = reader["Proceso"].ToString();
                    lista.Add(p);
                } if (reader.Read() == false)
                {
                    Prod_Terminados pe = new Prod_Terminados();
                    pe.id_ProductosTerminados = "";
                    pe.OT = "";
                    pe.NombreOT = "";
                    pe.Terminacion = "";
                    pe.TipoEmbalaje = "";
                    pe.Cantidad = "";
                    pe.Ejemplares = "";
                    pe.Total = "";
                    pe.Modelo = "Total:";
                    pe.Observacion = total.ToString("N0").Replace(",", ".");
                    lista.Add(pe);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public bool IngresarProTerminados(int idOperario, string codigo, string op, string nombreop, string terminacion, string tipoembalaje, int cantidad, int ejemplares, int total, string Modelo,string Observacion)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_ingresarProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Operario", idOperario);
                cmd.Parameters.AddWithValue("@cod_Pallet", codigo);
                cmd.Parameters.AddWithValue("@OT", op);
                cmd.Parameters.AddWithValue("@NombreOT", nombreop);
                cmd.Parameters.AddWithValue("@Terminacion", terminacion);
                cmd.Parameters.AddWithValue("@TipoEmbalaje", tipoembalaje);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Ejemplares", ejemplares);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@Modelo", Modelo);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);


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

        public bool CerrarPallet(string cod_Pallet)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_CerrarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_Pallet);



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



        public bool EliminarPT(int id_ProductosTerminados)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_EliminarPT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);



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

    
        public List<Prod_Terminados> BuscaPalletCerrado(string cod_pallet)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListaPalletEstado1]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                    // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();
                    p.Total = reader["Total"].ToString();

                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString();
                   // p.NombreOperario = reader["NombreOperario"].ToString();
                   // p.Maquina = reader["Maquina"].ToString();
                   // p.Proceso = reader["Proceso"].ToString();
                    if (reader["Estado"].ToString() == "1")
                    {
                        p.Estado = "<div style='Color:Blue;'>Pendiente</div>";
                    }
                    else if (reader["Estado"].ToString() == "2")
                    {
                        p.Estado = "<div style='Color:Green;'>Aprobado</div>";
                    }
                    else if (reader["Estado"].ToString() == "3")
                    {
                        p.Estado = "<div style='Color:Red;'>Rechazado</div>";
                    }
                    //p.Estado = reader["Estado"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public bool CambiarEstado(int id_ProductosTerminados,string Estado)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_CambioEstadoPT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);
                cmd.Parameters.AddWithValue("@Estado", Estado);



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






        public bool CerrarPaso2(int id_ProductosTerminados, string ValidadoPor,int Estado)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_validacionparaPaso3";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);
                cmd.Parameters.AddWithValue("@ValidadoPor", ValidadoPor);
                cmd.Parameters.AddWithValue("@Estado", Estado);



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



        public List<Prod_Terminados> BuscaPalletDespachoImpresion(string cod_pallet)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListaPalletPaso3]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                    // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();
                    p.Total = reader["Total"].ToString();

                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString();
                    //p.NombreOperario = reader["NombreOperario"].ToString();
                    //p.Maquina = reader["Maquina"].ToString();
                    //p.Proceso = reader["Proceso"].ToString();
                    if (reader["Estado"].ToString() == "1")
                    {
                        p.Estado = "<div style='Color:Blue;'>Pendiente</div>";
                    }
                    else if (reader["Estado"].ToString() == "2")
                    {
                        p.Estado = "<div style='Color:Green;'>Aprobado</div>";
                    }
                    else if (reader["Estado"].ToString() == "3")
                    {
                        p.Estado = "<div style='Color:Red;'>Rechazado</div>";
                    }
                    //p.Estado = reader["Estado"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



        public List<Prod_Terminados> BuscaPalletRecepcion(string cod_pallet)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListaPalletEstado4]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                    // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();
                    p.Total = reader["Total"].ToString();

                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString();
                  //  p.NombreOperario = reader["NombreOperario"].ToString();
                   // p.Maquina = reader["Maquina"].ToString();
                   // p.Proceso = reader["Proceso"].ToString();
                    if (reader["Estado"].ToString() == "4")
                    {
                        p.Estado = "<div style='Color:Blue;'>Pendiente</div>";
                    }
                    else if (reader["Estado"].ToString() == "7")
                    {
                        p.Estado = "<div style='Color:Green;'>Aprobado</div>";
                    }
                    else if (reader["Estado"].ToString() == "6")
                    {
                        p.Estado = "<div style='Color:Red;'>Rechazado</div>";
                    }
                    //p.Estado = reader["Estado"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public bool CerrarPaso3(int id_ProductosTerminados, string ValidadoPor, int Estado)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "[PT_RecepcionPaso3]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);
                cmd.Parameters.AddWithValue("@ValidadoPor", ValidadoPor);
                cmd.Parameters.AddWithValue("@Estado", Estado);



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
        public string ValidadoPor(string cod_Pallet)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[PT_ValidadoPor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_Pallet);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["ValidadoPor"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        //public bool CambiarEstado(int id_ProductosTerminados, string Estado)
        //{
        //    bool respuesta = true;
        //    SqlDataReader dr;
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionProduccion();
        //    try
        //    {
        //        cmd.CommandText = "PT_CambioEstadoPT";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);
        //        cmd.Parameters.AddWithValue("@Estado", Estado);



        //        dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //        con.CerrarConexion();
        //    }
        //    return respuesta;
        //}

        public List<PRODUCCIONENC> CARGA_INFORMEPRODUCCIONENC(string ot,string nombreOT,DateTime Fechainicio,DateTime fechatermino,int procedimiento)
        {
            List<PRODUCCIONENC> lista = new List<PRODUCCIONENC>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionINFORMEENC();

            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_INFORMEPRODUCCIONENCUADERNACION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NOMBREOT",nombreOT);
                cmd.Parameters.AddWithValue("@FECHAINICIO", Fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PRODUCCIONENC E = new PRODUCCIONENC();
                    E.OT = reader["OT"].ToString();
                    E.NOMBREOT = NombreOT_InformeProduccionEnc(E.OT).ToLower();
                    E.PLIEGO = reader["PLIEGOS"].ToString();
                    E.FORMA = reader["FORMA"].ToString();
                    E.OPERACION = reader["NOMBRE_OPERACION"].ToString();
                    E.MAQUINA = reader["NOMBRE_MAQUINA"].ToString();
                    E.BUENOS = Convert.ToInt32(reader["BUENOS"].ToString()).ToString("N0").Replace(",", ".");
                    E.FECHAINICIO = Convert.ToDateTime(reader["INICIO_PROCESO"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    E.FECHATERMINO = Convert.ToDateTime(reader["FIN_PROCESO"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    E.OPERACION = reader["NOMBRE_PERSONA"].ToString().ToLower() + " " + reader["APELLIDO_PATERNO"].ToString().ToLower();
                    lista.Add(E);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public string NombreOT_InformeProduccionEnc(string OT)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Enc_BuscarNombreOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["NOMBREOT"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }
        public bool CorreoPrimerDespacho(string OT, string Usuario, int Procedimiento)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Desp_Correos_PrimerDespacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

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

        public string CargarPalletsCorreo(string OT, string Usuario, int Procedimiento)
        {

            string resultado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:800px;margin-left:3px;'>" +
  "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Codigo Pallet</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>OT</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>NombreOT</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Terminacion</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Embalaje (Bulto)</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Cantidad Bultos</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Ejemplares por Bulto</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Total Ejemplares</td>" +
    "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Modelo</td>" +
  "</tr>";

            string contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Correos_PrimerDespacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contenido = "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        reader["cod_Pallet"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["OT"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["NombreOT"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["Terminacion"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["TipoEmbalaje"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Ejemplares"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Total"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["Modelo"].ToString() + "</td>" +
                        "</tr>";
                    // reader["ValidadoPor"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado + contenido + "</tbody></table>";
        }


        public DetalleDespachos_Excel CorreosCSRVendedor(string OT,string usuario,int procedimiento)
        {
            DetalleDespachos_Excel ls = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Desp_Correos_PrimerDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        ls = new DetalleDespachos_Excel();

                        ls.NombreOT = reader["CSR"].ToString();
                        ls.OT = reader["Vendedor"].ToString();


                    }
                }
                catch
                {
                    conexion.CerrarConexion();
                }

            }
            conexion.CerrarConexion();

            return ls;
        }
        public List<InfEstadoGuias> InformeEstadoGuias(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InfEstadoGuias> lista = new List<InfEstadoGuias>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Desp_EstadoGuias]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InfEstadoGuias p = new InfEstadoGuias();
                    p.NroPallet = reader["cod_pallet"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString().ToLower();
                    p.Terminacion=reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".");
                    p.Ejemplares = Convert.ToInt32(reader["Ejemplares"].ToString()).ToString("N0").Replace(",", ".");
                    p.Total = Convert.ToInt32(reader["Total"].ToString()).ToString("N0").Replace(",", ".");
                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString().ToLower();
                    p.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    if (reader["Estado"].ToString() == "Creado")
                    {
                        p.Estado = "<div style='Color:Blue;'>Creado</div>";
                    }
                    else if (reader["Estado"].ToString() == "Rechazado")
                    {
                        p.Estado = "<div style='Color:red;'>Rechazado</div>";
                    }
                    else
                    {
                        p.Estado = "<div style='Color:Green;'>Recepcionado</div>";
                    }
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



    }

}