using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_Enc
    {

        public  List<Productos> ListaProceso(int idMaquina)
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "SP_Maquina_Proces";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaquina", idMaquina);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos p = new Productos();
                    p.Proceso = reader["NombreProceso"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



        public  List<Productos> ListaMaquina()
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "SP_Listar_Maquina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos p = new Productos();
                    p.id_Maquina = reader["id_Maquina"].ToString();
                    p.Maquina = reader["NombreMaquina"].ToString();
                    lista.Add(p);
                }

                
            }
            conexion.CerrarConexion();
            return lista;
        }


        public bool IngresarOperador(string Nombre,string Turno,string Maquina,string Proceso)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SP_Insert_Operario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Turno", Turno);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Proceso", Proceso);
                    cmd.ExecuteNonQuery();
                    conexion.CerrarConexion();
                    return true;
                }
                catch
                {
                    conexion.CerrarConexion();
                    return false;
                }
            }

            else
            {
                conexion.CerrarConexion();
                return false;
            }
        }




        public bool IngresarProTerminados(int id,string op,string nombreop,string terminacion,string tipoembalaje,int cantidad,int ejemplares,int total,string codigo)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SP_Insert_ProTerminado";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_infOperario", id);
                    cmd.Parameters.AddWithValue("@OP", op);
                    cmd.Parameters.AddWithValue("@NombreOP", nombreop);
                    cmd.Parameters.AddWithValue("@Terminacion", terminacion);
                    cmd.Parameters.AddWithValue("@TipoEmbalaje", tipoembalaje);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Ejemplares", ejemplares);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.ExecuteNonQuery();
                    conexion.CerrarConexion();
                    return true;
                }
                catch
                {
                    conexion.CerrarConexion();
                    return false;
                }
            }
            else
            {
                conexion.CerrarConexion();
                return false; 
            }
        }




        public  int busqIDOperario(string nombre)
        {
            int Tarea = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "SP_BuscaOperador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreOperador", nombre);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tarea = Convert.ToInt32(reader["id_infOperario"].ToString());
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
                cmd.CommandText = "SP_CapturaCodigo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tarea = Convert.ToInt32(reader["Codigo"].ToString());
                }
            }
            con.CerrarConexion();
            return Tarea;
        }
        public int CapturaCodigoDespacho()
        {
            int Tarea = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[SP_CapturaCodigoDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tarea = Convert.ToInt32(reader["Codigo"].ToString());
                }
            }
            con.CerrarConexion();
            return Tarea;
        }

        public Productos ImprimirEtiqueta(string codigo,string OP)
        {
            
            Productos pro = new Productos();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "SP_ImprimirEtiqueta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@OP", OP);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    //pro.Proceso = reader["NombreProceso"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    pro.Cantidad = reader["Cantidad"].ToString();
                    pro.Ejemplares = reader["Ejemplares"].ToString();
                    pro.Total = reader["Total"].ToString();
                    pro.Codigo = reader["Codigo"].ToString();
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    //
                    //
                    pro.Cliente = reader["CUST_NM"].ToString();
                    pro.Tiraje = reader["PRN_ORD_QTY"].ToString();
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.Proceso = reader["Proceso"].ToString();
                   
                }
            }
            conexion.CerrarConexion();
            return pro;
        }


        public Productos ImprimirEtiquetaDespacho(string codigo, string OP)
        {

            Productos pro = new Productos();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_ImprimirEtiquetaDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@OP", OP);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //pro.Proceso = reader["NombreProceso"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    pro.Cantidad = reader["Cantidad"].ToString();
                    pro.Ejemplares = reader["Ejemplares"].ToString();
                    pro.Total = reader["Total"].ToString();
                    pro.Codigo = reader["Codigo"].ToString();
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    //
                    //
                    pro.Cliente = reader["CUST_NM"].ToString();
                    pro.Tiraje = reader["PRN_ORD_QTY"].ToString();
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.Proceso = reader["Proceso"].ToString();

                    pro.validado = reader["ValidadoPor"].ToString();
                    pro.fechavalidacion = reader["FechaValidacion"].ToString();

                }
            }
            conexion.CerrarConexion();
            return pro;
        }

        public Productos CargarEtiqueta(string codigo)
        {

            Productos pro = new Productos();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_CrearEtiqueta]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //pro.Proceso = reader["NombreProceso"].ToString();
                    pro.id_DespProducto = reader["id_prodTerminados"].ToString();
                    pro.idOperador = reader["id_infOperario"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    pro.Cantidad = reader["Cantidad"].ToString();
                    pro.Ejemplares = reader["Ejemplares"].ToString();
                    pro.Total = reader["Total"].ToString();
                    pro.Codigo = reader["Codigo"].ToString();
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    //
                    //
                    pro.Cliente = reader["CUST_NM"].ToString();
                    pro.Tiraje = reader["PRN_ORD_QTY"].ToString();
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.Proceso = reader["Proceso"].ToString();

                }
            }
            conexion.CerrarConexion();
            return pro;
        }


        public bool IngresarDespProTerminados(int idOperario,string op, string nombreop, string terminacion, string tipoembalaje, int cantidad, int ejemplares, int total, string codigo, DateTime FechaCreacion, string validadoPor,int procedimiento, string codigoantiguo)
        {
            bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "SP_Insert_DespachoPT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOperador", idOperario);
                cmd.Parameters.AddWithValue("@OP", op);
                cmd.Parameters.AddWithValue("@NombreOP", nombreop);
                cmd.Parameters.AddWithValue("@Terminacion", terminacion);
                cmd.Parameters.AddWithValue("@TipoEmbalaje", tipoembalaje);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Ejemplares", ejemplares);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                cmd.Parameters.AddWithValue("@ValidadoPor", validadoPor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.Parameters.AddWithValue("@CodigoAntiguo", codigoantiguo);
                


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





        public Productos DetalleConUbicacion(string OP,string NombreOP,DateTime FechaInicio,DateTime FechaTermino,int Procedimiento,int ID,string ubicacion,string codigoUbicacion)
        {

            Productos pro = new Productos();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_List_Existencia]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Ubicacion", ubicacion);
                cmd.Parameters.AddWithValue("@CodigoUbicacion", codigoUbicacion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //pro.Proceso = reader["NombreProceso"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();

                    if (reader["Cantidad"].ToString() != "")
                    {
                        int Cant = Convert.ToInt32(reader["Cantidad"].ToString());
                        pro.Cantidad = Cant.ToString("N0");
                    }
                    else
                    {
                        pro.Cantidad = "";
                    }


                    if (reader["Ejemplares"].ToString() != "")
                    {
                        int Ejem = Convert.ToInt32(reader["Ejemplares"].ToString());
                        pro.Ejemplares = Ejem.ToString("N0");
                    }
                    else
                    {
                        pro.Ejemplares = "";
                    }


                    if (reader["Total"].ToString() != "")
                    {
                        int TT = Convert.ToInt32(reader["Total"].ToString());
                        pro.Total = TT.ToString("N0");
                    }
                    else
                    {
                        pro.Total = "";
                    }

                    if (reader["FechaCreacion"].ToString() != "")
                    {
                        DateTime FC = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                        pro.FechaCreacion = FC.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        pro.FechaCreacion = "";
                    }


                    pro.validado = reader["ValidadoPor"].ToString();

                    if (reader["FechaValidacion"].ToString() != "")
                    {
                        DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                        pro.fechavalidacion = FV.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        pro.fechavalidacion = "";
                    }


                    if (reader["FechaRecepcion"].ToString() != "")
                    {
                        DateTime FR = Convert.ToDateTime(reader["FechaRecepcion"].ToString());
                        pro.FechaRecepcion = FR.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        pro.FechaRecepcion = "";
                    }

                    pro.RecepcionadoPor = reader["RecepcionadoPor"].ToString();
                    pro.Ubicacion = reader["Ubicacion2"].ToString() + " - " + reader["CodigoUbicacion"].ToString();

                    if (reader["FechaUbicacion"].ToString() != "")
                    {
                        DateTime FS = Convert.ToDateTime(reader["FechaUbicacion"].ToString());
                        pro.FechaSalida = FS.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        pro.FechaSalida = "";
                    }
                    pro.Codigo = reader["OperadorUbicacion"].ToString();

                }
            }
            conexion.CerrarConexion();
            return pro;
        }




        ///////procedimientooo j



        public string infMaquinaBobina(string Usuario)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[SP_infMaquinaPROTerminados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado =reader["Fecha"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }


        
        public bool RecepcionProTerminados(int id, string recepcionado)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "SP_RecepcionProTerminado";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@RecepcionadoPor", recepcionado);
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


  
        public List<Productos> CargarProductosTerminados(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_View_ProductosTerminados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos pro = new Productos();
                    pro.id_DespProducto = reader["id_prodTerminados"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.Total = reader["Total"].ToString();
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<Productos> CargarAprobados(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_ListarAprobados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos pro = new Productos();
                    pro.id_DespProducto = reader["id_prodTerminados"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());
                    pro.Total = tt.ToString("N0");

                    
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    pro.validado = reader["ValidadoPor"].ToString();
                    DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    pro.fechavalidacion = FV.ToString("dd/MM/yyyy HH:mm");
                    string var = reader["Modificado"].ToString();
                    if (var == "0")
                    {
                        pro.Modificado = "No";
                    }
                    else
                    {
                        pro.Modificado = "Si";
                    }
                   
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<Productos> CargarAprobadosProTerminados(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_ListarAprobadosProTerminados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos pro = new Productos();
                    pro.id_DespProducto = reader["id_prodTerminados"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());
                    pro.Total = tt.ToString("N0");
                    DateTime FC = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    pro.FechaCreacion = FC.ToString("dd/MM/yyyy HH:mm");
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Turno = reader["Turno"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.Proceso = reader["Proceso"].ToString();

                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<ProductosExcel> CargarAprobados_Excel(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<ProductosExcel> lista = new List<ProductosExcel>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_ListarAprobados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductosExcel pro = new ProductosExcel();
                    pro.id_DespProducto = reader["id_prodTerminados"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());
                    pro.Total = tt.ToString("N0");
                    pro.FechaCreacion = reader["FechaCreacion"].ToString();
                    pro.validado = reader["ValidadoPor"].ToString();
                    DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    pro.fechavalidacion = FV.ToString("dd/MM/yyyy HH:mm");
                    string var = reader["Modificado"].ToString();
                    if (var == "0")
                    {
                        pro.Modificado = "No";
                    }
                    else
                    {
                        pro.Modificado = "Si";
                    }

                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<Productos> ListaExistencia(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento, int ID, string Ubicacion, string CodigoUbicacion)
        {
            List<Productos> lista = new List<Productos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "SP_List_Existencia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                cmd.Parameters.AddWithValue("@CodigoUbicacion", CodigoUbicacion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos pro = new Productos();
                    pro.id_DespProducto = reader["id_DespProducto"].ToString();
                    pro.OP = reader["OP"].ToString();
                    pro.NombreOP = reader["NombreOP"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    //
                    //int c = Convert.ToInt32(reader["Cantidad"].ToString());
                    //pro.Cantidad = c.ToString("N0");
                    ////
                    //int e = Convert.ToInt32(reader["Ejemplares"].ToString());
                    //pro.Ejemplares = e.ToString("N0");
                    //
                    int t = Convert.ToInt32(reader["Total"].ToString());
                    pro.Total = t.ToString("N0");
                    //pro.Codigo = reader["Codigo"].ToString();
                    //
                    DateTime fec = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    pro.FechaCreacion = fec.ToString("dd/MM/yyyy HH:mm");
                    //
                    //
                    string ub=reader["CodigoUbicacion"].ToString();
                    if (ub == "")
                    {
                        pro.Ubicacion = "Sin Ubicación";
                    }
                    else
                    {
                        pro.Ubicacion = ub;
                    }
                    string ES = reader["Estado"].ToString();
                    if (ES == "1")
                    {
                        pro.Codigo = "<div style='Color:Red;'>NO</div>";
                    }
                    else
                    {
                        pro.Codigo = "Si";
                    }
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<Existencia_Excel> ListaExistencia_Excel(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento, int ID, string Ubicacion, string CodigoUbicacion)
        {
            List<Existencia_Excel> lista = new List<Existencia_Excel>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "SP_List_Existencia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                cmd.Parameters.AddWithValue("@CodigoUbicacion", CodigoUbicacion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Existencia_Excel pro = new Existencia_Excel();
                   // Existencia_Excel pro = new Existencia_Excel();
                   //// pro.id_DespProducto = reader["id_DespProducto"].ToString();
                   // pro.O = reader["OP"].ToString();
                   // pro.NombreOP = reader["NombreOP"].ToString();
                   // pro.Terminacion = reader["Terminacion"].ToString();
                   // pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                   // //
                   // //int c = Convert.ToInt32(reader["Cantidad"].ToString());
                   // //pro.Cantidad = c.ToString("N0");
                   // ////
                   // //int e = Convert.ToInt32(reader["Ejemplares"].ToString());
                   // //pro.Ejemplares = e.ToString("N0");
                   // //
                   // int t = Convert.ToInt32(reader["Total"].ToString());
                   // pro.Total = t.ToString("N0");
                   // //pro.Codigo = reader["Codigo"].ToString();
                   // //
                   // DateTime fec = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                   // pro.FechaCreacion = fec.ToString("dd/MM/yyyy HH:mm");
                   // //
                   // //
                   // string ub = reader["Ubicacion2"].ToString();
                   // if (ub == "")
                   // {
                   //     pro.Ubicacion = "Sin Ubicación";
                   // }
                   // else
                   // {
                   //     pro.Ubicacion = ub;
                   // }
                   // string ES = reader["Estado"].ToString();
                   // if (ES == "1")
                   // {
                   //     pro.Codigo = "NO";
                   // }
                   // else
                   // {
                   //     pro.Codigo = "SI";
                   // }
                   // lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    


        ////////////////////////////////////////////////////////////////


        public List<PTerminadosPaso2_Excel> CargarAprobadosPT(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<PTerminadosPaso2_Excel> lista = new List<PTerminadosPaso2_Excel>();
            int totalEjemplares = 0;
            int totalTiraje = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListarAprobados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PTerminadosPaso2_Excel pro = new PTerminadosPaso2_Excel();
                    pro.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    pro.cod_Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());

                    pro.Observacion = reader["Observacion"].ToString().ToLower();
                    totalEjemplares = totalEjemplares + Convert.ToInt32(reader["Total"].ToString());

                    string a = tt.ToString("N0");
                    string b = a.Replace(",", ".");
                    //pro.Total = tt.ToString("N0");
                    pro.Total = b;
                   // pro.FechaValidacion = reader["FechaValidacion"].ToString();
                    pro.Validado = reader["ValidadoPor"].ToString();
                    DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    pro.FechaValidacion = FV.ToString("dd/MM/yyyy HH:mm");
                    string var = reader["Estado"].ToString();
                    if (var == "4")
                    {
                        pro.Modificado = "<div style='Color:Red;'>Despachado</div>";
                    }
                    else if (var == "10")
                    {
                        pro.Modificado = "<div style='Color:Red;'>DEVOLUCION</div>";
                    }
                    else
                    {
                        pro.Modificado = "<div style='Color:Green;'>Recepcionado</div>";
                    }
                    totalTiraje = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    lista.Add(pro);
                }
                if (Procedimiento != 0)
                {

                    if (reader.Read() == false)
                    {
                        PTerminadosPaso2_Excel pro2 = new PTerminadosPaso2_Excel();
                        pro2.id_ProductosTerminados = null;
                        pro2.cod_Pallet = null;
                        pro2.OT = null;
                        pro2.NombreOT = null;
                        pro2.Terminacion = null;
                        pro2.TipoEmbalaje = null;
                        pro2.Total = null;
                        pro2.Validado = null;
                        pro2.FechaValidacion = "<div style='font-weight: bold'>Total Ejemplares:</div>";
                        pro2.Modificado = totalEjemplares.ToString("N0").Replace(",", ".");
                        lista.Add(pro2);

                        PTerminadosPaso2_Excel pro3 = new PTerminadosPaso2_Excel();
                        pro3.id_ProductosTerminados = null;
                        pro3.cod_Pallet = null;
                        pro3.OT = null;
                        pro3.NombreOT = null;
                        pro3.Terminacion = null;
                        pro3.TipoEmbalaje = null;
                        pro3.Total = null;
                        pro3.Validado = null;
                        pro3.FechaValidacion = "<div style='font-weight: bold'>Tiraje OT:</div>";
                        pro3.Modificado = totalTiraje.ToString("N0").Replace(",", ".");
                        lista.Add(pro3);

                    }
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<PTerminadosPaso2_Excel> CargarAprobadosPT_Excel(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<PTerminadosPaso2_Excel> lista = new List<PTerminadosPaso2_Excel>();
            int totalEjemplares = 0;
            int totalTiraje = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListarAprobados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PTerminadosPaso2_Excel pro = new PTerminadosPaso2_Excel();
                    pro.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    pro.cod_Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());


                    totalEjemplares = totalEjemplares + Convert.ToInt32(reader["Total"].ToString());

                    string a = tt.ToString("N0");
                    string b = a.Replace(",", ".");
                    //pro.Total = tt.ToString("N0");
                    pro.Total = b;
                    // pro.FechaValidacion = reader["FechaValidacion"].ToString();
                    pro.Validado = reader["ValidadoPor"].ToString();
                    DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    pro.FechaValidacion = FV.ToString("dd/MM/yyyy HH:mm");
                    string var = reader["Estado"].ToString();
                    if (var == "4")
                    {
                        pro.Modificado = "Despachado";
                    }
                    else
                    {
                        pro.Modificado = "Recepcionado";
                    }
                    totalTiraje = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    lista.Add(pro);
                }
                if (Procedimiento != 0)
                {
                    if (reader.Read() == false)
                    {
                        PTerminadosPaso2_Excel pro2 = new PTerminadosPaso2_Excel();
                        pro2.id_ProductosTerminados = null;
                        pro2.cod_Pallet = null;
                        pro2.OT = null;
                        pro2.NombreOT = null;
                        pro2.Terminacion = null;
                        pro2.TipoEmbalaje = null;
                        pro2.Total = null;
                        pro2.Validado = null;
                        pro2.FechaValidacion = "Total Ejemplares:";
                        pro2.Modificado = totalEjemplares.ToString("N0").Replace(",", ".");
                        lista.Add(pro2);

                        PTerminadosPaso2_Excel pro3 = new PTerminadosPaso2_Excel();
                        pro3.id_ProductosTerminados = null;
                        pro3.cod_Pallet = null;
                        pro3.OT = null;
                        pro3.NombreOT = null;
                        pro3.Terminacion = null;
                        pro3.TipoEmbalaje = null;
                        pro3.Total = null;
                        pro3.Validado = null;
                        pro3.FechaValidacion = "Tiraje OT:";
                        pro3.Modificado = totalTiraje.ToString("N0").Replace(",", ".");
                        lista.Add(pro3);

                    }
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<PTerminadosPaso1_Excel> CargarAprobadosProTerminadosPT(string OP, string NombreOP, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<PTerminadosPaso1_Excel> lista = new List<PTerminadosPaso1_Excel>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ListarAprobadosProTerminados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", OP);
                cmd.Parameters.AddWithValue("@NombreOP", NombreOP);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PTerminadosPaso1_Excel pro = new PTerminadosPaso1_Excel();
                    pro.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    pro.cod_Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());
                    string a = tt.ToString("N0");
                    string b = a.Replace(",", ".");
                    pro.Total = b;
                   
                    DateTime FC = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    pro.FechaCreacion = FC.ToString("dd/MM/yyyy HH:mm");
                    pro.Operador = reader["NombreOperario"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.Proceso = reader["Proceso"].ToString();

                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }




    }

}