using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_Devoluciones
    {


        public List<Devoluciones> ListarGuias(string ot)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Listar_Guias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();

                    des.guia = reader["NOFOLIOGUIACAB"].ToString();
                    des.sucursal = reader["sucursal"].ToString();
                    int despc = Convert.ToInt32(reader["CANTIDADTIPOELEMENTO"].ToString());
                    des.despachado = despc.ToString("N0").Replace(",", ".");
                    DateTime fdesp = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.FechaDespacho = fdesp.ToString("dd/MM/yyyy HH:mm");

                    lista.Add(des);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }


        public Devoluciones Cliente_Producto(string ot)
        {
            Conexion con = new Conexion(); 
            Devoluciones des = new Devoluciones();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Cliente_Producto";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                 

                    des.guia = reader["NM"].ToString();
                    des.sucursal = reader["CUST_NM"].ToString();
                    des.TirajeOT = reader["PRN_ORD_QTY"].ToString();

               }
               
            }
            con.CerrarConexion();
            return des;
        }


        public string idTipoDev()
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Desp_Dev_idTipoDev]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["id_TipoDev"].ToString();
                }
              
            }
            con.CerrarConexion();
            return resultado;
        }

        public bool insertTipoDev(int id_TipoDev,string OT,string TipoEmbalaje,int Cantidad, int TipoDevolucion)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_Insert_Tipo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@id_TipoDev", id_TipoDev);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@TipoEmbalaje", TipoEmbalaje);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@TipoDevolucion", TipoDevolucion);

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
            conexion.CerrarConexion();
            return respuesta;
        }


        public List<Devoluciones> ListaTipos(int id_TipoDev)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_ListaTipo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_TipoDev", id_TipoDev);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();
                    des.OT = reader["OT"].ToString();
                    des.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    des.Cantidad = reader["Cantidad"].ToString();

                    lista.Add(des);
                }
              
            }
            con.CerrarConexion();
            return lista;
        }


        public bool insertGuias(int id_Guias,string Nro_Guias,string Sucursal,int Cantidad,DateTime FechaDespacho)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_Insert_Guias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@id_Guias", id_Guias);
                cmd.Parameters.AddWithValue("@Nro_Guias", Nro_Guias);
                cmd.Parameters.AddWithValue("@Sucursal", Sucursal);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@FechaDespacho", FechaDespacho);

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
            conexion.CerrarConexion();
            return respuesta;
        }


        public bool insertCliente(int id_Guias, int id_TipoDev,string Folio,string OT,int TirajeOT,string Cliente,string Producto,string CausaDevolucion,string Observacion,int Total_Dev,string CreadaPor)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_Insert_Cliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@id_Guias", id_Guias);
                cmd.Parameters.AddWithValue("@id_TipoDev", id_TipoDev);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Producto", Producto);
                cmd.Parameters.AddWithValue("@CausaDevolucion", CausaDevolucion);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Total_Dev", Total_Dev);
                cmd.Parameters.AddWithValue("@CreadoPor", CreadaPor);

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
            conexion.CerrarConexion();
            return respuesta;
        }
        public bool insertCliente_DevolucionGeneral(int id_Guias, int id_TipoDev, string Folio, string OT, int TirajeOT, string Cliente, string Producto, string CausaDevolucion, string Observacion, int Total_Dev, string CreadaPor)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "[Desp_Dev_Insert_Cliente_DevGeneral]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@id_Guias", id_Guias);
                cmd.Parameters.AddWithValue("@id_TipoDev", id_TipoDev);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Producto", Producto);
                cmd.Parameters.AddWithValue("@CausaDevolucion", CausaDevolucion);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Total_Dev", Total_Dev);
                cmd.Parameters.AddWithValue("@CreadoPor", CreadaPor);

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
            conexion.CerrarConexion();
            return respuesta;
        }


        public Devoluciones ListaDevoluciones(string Folio)
        {
            Conexion con = new Conexion();
            Devoluciones des = new Devoluciones();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_Lista_Devoluciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.id_Devolucion = reader["id_Devolucion"].ToString();
                    des.id_Guias = reader["id_Guias"].ToString();
                    des.id_TipoDev = reader["id_TipoDev"].ToString();
                    des.Folio = reader["Folio"].ToString();
                    des.OT = reader["OT"].ToString();
                    des.TirajeOT = reader["TirajeOT"].ToString();
                    des.Cliente = reader["Cliente"].ToString();
                    des.Producto = reader["Producto"].ToString();
                    des.CausaDevolucion = reader["CausaDevolucion"].ToString();
                    des.Total_Dev = reader["Total_Dev"].ToString();

                    des.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    des.CreadaPor = reader["CreadaPor"].ToString();





                }
               
            }
            con.CerrarConexion();
            return des;
        }




        public List<Devoluciones> ListaGuias(int id_Guias)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            int suma = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_ListaGuias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Guias", id_Guias);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();
                    des.guia = reader["Nro_Guias"].ToString();
                    des.sucursal = reader["Sucursal"].ToString();

                    int cant = Convert.ToInt32(reader["Cantidad"].ToString());
                    des.Cantidad = cant.ToString("N0").Replace(",", ".");
                  //  des.Cantidad = reader["Cantidad"].ToString();

                    if (reader["FechaDespacho"].ToString() == "")
                    {
                        des.FechaDespacho = "";
                    }
                    else
                    {

                        DateTime fd = Convert.ToDateTime(reader["FechaDespacho"].ToString());
                        des.FechaDespacho = fd.ToString("dd/MM/yyyy HH:mm");
                        //des.FechaDespacho = reader["FechaDespacho"].ToString();
                    }
                    suma = suma + Convert.ToInt32(reader["Cantidad"].ToString());


                    lista.Add(des);
                }
                if (reader.Read() == false)
                {
                    Devoluciones d = new Devoluciones();
                    d.guia = "";
                    d.sucursal = "";
                    d.Cantidad = "Cantidad Total:";
                    d.FechaDespacho = suma.ToString("N0").Replace(",", ".");
                    lista.Add(d);
                }
               
            }
            con.CerrarConexion();
            return lista;
        }
        public List<Devoluciones> ListasTipos(int id_TipoDev)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            int suma = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_ListaTipos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_TipoDev", id_TipoDev);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();
                    des.OT = reader["OT"].ToString().ToUpper();
                    des.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int cant = Convert.ToInt32(reader["Cantidad"].ToString());
                  //  des.Cantidad = reader["Cantidad"].ToString();
                    des.Cantidad = cant.ToString("N0").Replace(",", ".");



                    suma = suma + Convert.ToInt32(reader["Cantidad"].ToString());

                    lista.Add(des);
                }
                if (reader.Read() == false)
                {
                    Devoluciones d = new Devoluciones();
                    d.OT = "";
                    d.TipoEmbalaje = "Cantidad Total";
                    d.Cantidad = suma.ToString("N0").Replace(",", ".");
                    lista.Add(d);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public string GenerarFolio()
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Desp_Dev_Folio]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["folio"].ToString();
                }
                
            }
            con.CerrarConexion();
            return resultado;
        }


        public List<Devoluciones> BusquedaPorFolioyOT(string Folio, string OT, int procedimiento)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            int suma = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_EnvioEnc";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();
                    des.Folio = reader["Folio"].ToString();
                    des.OT = reader["OT"].ToString().ToUpper();
                    int tiraje=Convert.ToInt32(reader["TirajeOT"].ToString());
                    des.TirajeOT = tiraje.ToString("N0").Replace(",", ".");

                    des.Cliente = reader["Cliente"].ToString();
                    des.Producto = reader["Producto"].ToString();
                    des.CausaDevolucion = reader["CausaDevolucion"].ToString();
                    des.Observacion = reader["Observacion"].ToString();
                    int total = Convert.ToInt32(reader["Total_Dev"].ToString());
                    des.Total_Dev = total.ToString("N0").Replace(",", ".");


                    des.CreadaPor = reader["CreadaPor"].ToString();

                    DateTime fc = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    des.FechaCreacion = fc.ToString("dd/MM/yyyy HH:mm");


                    lista.Add(des);
                }

                
            }
            con.CerrarConexion();
            return lista;
        }


        public bool GenerarEnvio(string Folio,string GeneradaPor)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_GenerarEnvio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@GeneradaPor", GeneradaPor);
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
            conexion.CerrarConexion();
            return respuesta;
        }

        public bool RecepcionEnc(string Folio, string RecepcionadaPor,string Observacion,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_RecepcionarEnc";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
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
            conexion.CerrarConexion();
            return respuesta;
        }

        public bool GuiasCliente(int id,string nroGuia, int Cantidad, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_GuiaCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@id_Guias", id);
                cmd.Parameters.AddWithValue("@NroGuia", nroGuia);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
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
            conexion.CerrarConexion();
            return respuesta;
        }

        public List<Devoluciones> ListarGuiasCliente(int id, string nroGuia, int Cantidad, int procedimiento)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_GuiaCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Guias", id);
                cmd.Parameters.AddWithValue("@NroGuia", nroGuia);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();

                    des.guia = reader["Nro_Guias"].ToString();
                    des.sucursal = reader["Sucursal"].ToString();
                    int despc = Convert.ToInt32(reader["Cantidad"].ToString());
                    des.despachado = despc.ToString("N0").Replace(",", ".");
                    //DateTime fdesp = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.FechaDespacho = "";// fdesp.ToString("dd/MM/yyyy HH:mm");

                    lista.Add(des);
                }
               
            }
            con.CerrarConexion();
            return lista;
        }
        //devolucion interna
        public List<Devoluciones> DevolucionInterna(string ot)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_CargaInterna";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();

                    des.guia = reader["cod_pallet"].ToString();
                    des.sucursal = reader["Terminacion"].ToString();

                    des.TipoEmbalaje = reader["tipoEmbalaje"].ToString();

                    int despc = Convert.ToInt32(reader["TotalGuia"].ToString());
                    des.despachado = despc.ToString("N0").Replace(",", ".");


                    DateTime fdesp = Convert.ToDateTime(reader["FechaRecepcion"].ToString());
                    des.FechaDespacho = fdesp.ToString("dd/MM/yyyy HH:mm:ss");

                    lista.Add(des);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }


        public string MaxRecepciones(string OT, int procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Desp_Dev_MaxRecepcion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["MaxRecepcion"].ToString();
                }

            }
            con.CerrarConexion();
            return resultado;
        }

        // Eliminar Devolucion
        public Devoluciones Buscar_Devolucion(string Folio,int id_Devolucion,string Motivo,string anuladapor, int Procedimiento )
        {
            Conexion con = new Conexion();
            Devoluciones des = new Devoluciones();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_AnularDevolucion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@id_devolucion", id_Devolucion);
                cmd.Parameters.AddWithValue("@Motivo", Motivo);
                cmd.Parameters.AddWithValue("@AnuladaPor", anuladapor);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.id_Devolucion = reader["id_Devolucion"].ToString();
                    des.id_Guias = reader["id_Guias"].ToString();
                    des.Folio = reader["Folio"].ToString();
                    des.OT = reader["OT"].ToString().ToUpper();
                    des.TirajeOT = reader["TirajeOT"].ToString();
                    des.Cliente = reader["Cliente"].ToString().ToUpper();
                    des.Producto = reader["Producto"].ToString().ToUpper();
                    des.CausaDevolucion = reader["CausaDevolucion"].ToString();
                    des.Observacion = reader["Observacion"].ToString();
                    des.Total_Dev = reader["Total_Dev"].ToString();
                    des.CreadaPor = reader["CreadaPor"].ToString();
                    des.FechaCreacion = reader["FechaCreacion"].ToString();
                    des.sucursal = reader["Sucursal"].ToString();
                    des.guia = reader["Estado"].ToString();
                }

            }
            con.CerrarConexion();
            return des;
        }



        public bool Anular_Devolucion(string folio,int id_dev,string motivo,string anuladapor,int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Dev_AnularDevolucion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", folio);
                cmd.Parameters.AddWithValue("@id_devolucion", id_dev);
                cmd.Parameters.AddWithValue("@Motivo", motivo);
                cmd.Parameters.AddWithValue("@AnuladaPor", anuladapor);
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
            conexion.CerrarConexion();
            return respuesta;
        }


        public List<Devoluciones> CargaInformeDevoluciones(string ot,string NombreOT,DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Dev_InformeDevolucion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Devoluciones des = new Devoluciones();

                    des.Folio = reader["Folio"].ToString();
                    des.OT = reader["OT"].ToString().ToUpper();
                    des.Producto = reader["Producto"].ToString();
                    des.Cliente = reader["Cliente"].ToString().ToLower();
                    des.TirajeOT = Convert.ToInt32(reader["TirajeOT"].ToString()).ToString("N0").Replace(",", ".");
                    des.CausaDevolucion = reader["CausaDevolucion"].ToString();
                    des.Total_Dev = Convert.ToInt32(reader["Total_Dev"].ToString()).ToString("N0").Replace(",", ".");
                    des.CreadaPor = reader["CreadaPor"].ToString();
                    des.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");

                    if (reader["Estado"].ToString() == "1")
                    {
                        des.guia = "<div style='Color:Red'>Creada</div>";
                    }
                    else if (reader["Estado"].ToString() == "2")
                    {
                        des.guia = "<div style='Color:Orange'>Generada</div>";
                    }
                    else if (reader["Estado"].ToString() == "4")
                    {
                        des.guia = "<div style='Color:Green'>Recepcionada</div>";
                    }
                    else
                    {
                        des.guia = "<div>Anulada</div>";
                    }

                  

                    if (reader["TipoDevolucion"].ToString() == "Devolucion Interna")
                    {
                        des.id_TipoDev = "Devolucion Interna";
                        des.Observacion = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + des.Folio + "\",\"" + des.OT + "\")'>ver Más</a>";
                    }
                    else
                    {
                        des.id_TipoDev = "Devolucion Cliente";
                        des.Observacion = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGames(\"" + des.Folio + "\",\"" + des.OT + "\")'>ver Más</a>";
                    }

                   
                    lista.Add(des);
                }

            }
            con.CerrarConexion();
            return lista;
        }
    }
}
