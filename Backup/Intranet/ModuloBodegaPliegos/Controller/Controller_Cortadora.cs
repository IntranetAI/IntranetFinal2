using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloBodegaPliegos.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_Cortadora
    {
        public List<BodegaPliegos> CargaSolicitudArreglo(string ot, string nombreot, string papel, string codigoPapel, string Folio, int estado, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_Cortadora]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@CodigoPapel", codigoPapel);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Folio = reader["id_Corte"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.OT = reader["OT"].ToString();
                    //d.NombreOT = reader["NombreOT"].ToString();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                    d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                    d.StockFL = Convert.ToInt32(reader["Pliegos"].ToString()).ToString("N0").Replace(",", ".");
                    d.Estado = "<div style='color:red;'>Sin Procesar</div>";
                    //if (d.OT.Trim().ToLower().Contains("stock"))
                    //{
                        d.Accion = "<a style='Color:Red;text-decoration:none;cursor:pointer;'>Ubicar</a>";
                    //}
                    //else
                    //{
                    //    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Atender(\"" + d.Folio + "\");'>Atender</a>";
                    //}
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<BodegaPliegos> CargaSolicitud(string ot,string nombreot,string papel,string codigoPapel,string Folio,int estado,DateTime fechainicio,DateTime fechatermino,int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_Cortadora]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@CodigoPapel", codigoPapel);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (procedimiento == 0 || procedimiento == 2 || procedimiento == 3 || procedimiento == 4)
                {
                    while (reader.Read())
                    {
                        BodegaPliegos d = new BodegaPliegos();
                        d.Folio = reader["CodigoID"].ToString();
                        d.FechaCreacion = Convert.ToDateTime(reader["FechaAsignacion"].ToString()).ToString("dd/MM/yyyy");
                        d.CodigoProducto = reader["Codigo"].ToString();
                        d.OT = reader["OT"].ToString();
                        //d.NombreOT = reader["NombreOT"].ToString();
                        d.Componente = reader["Componente"].ToString();
                        d.Papel = reader["Papel"].ToString().ToLower();
                        d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                        d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                        d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                        d.StockFL = Convert.ToInt32(reader["Asignado"].ToString()).ToString("N0").Replace(",", ".");
                        d.Estado = "<div style='color:red;'>Sin Atender</div>";
                        if (d.OT.Trim().ToLower().Contains("stock"))
                        {
                            d.Accion = "<a style='Color:Red;text-decoration:none;cursor:pointer;'>Ubicar</a>";
                        }
                        else
                        {
                            d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Atender(\"" + d.Folio + "\");'>Atender</a>";
                        }
                        lista.Add(d);
                    }
                }
                else if (procedimiento == 1)
                {
                    while (reader.Read())
                    {
                        BodegaPliegos d = new BodegaPliegos();
                        d.ID = reader["id_Asignacion"].ToString();
                        d.NroPallet = reader["NroPallet"].ToString();
                        d.Ubicacion = reader["Sector"].ToString() + " - " + reader["Ubicacion"].ToString();
                        d.CodigoProducto = reader["Codigo"].ToString();
                        d.Componente = reader["Componente"].ToString();
                        d.Marca = "-";
                        d.Papel = reader["Papel"].ToString();
                        d.Gramaje = reader["Gramaje"].ToString();
                        d.Ancho = reader["FCAncho"].ToString();
                        d.Largo = reader["FCLargo"].ToString();
                        d.StockFL = reader["CantidadAsignada"].ToString();

                        if (reader["Estado"].ToString() == "1")
                        {
                            d.Estado = "<div style='Color:red;'>Sin Atender</div>";
                        }
                        else if (reader["Estado"].ToString() == "2")
                        {
                            d.Estado = "<div style='Color:Green;'>Atendido</div>";
                        }
                        else
                        {
                            d.Estado = "Error";
                        }
                        lista.Add(d);
                    }
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public bool RecepcionPallets(int id,string usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_RecepcionPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAsignacion", id);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
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


        public BodegaPliegos BuscaTotalCant(string ot,string compo,string codigo)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

                if (cmd != null)
                {
                    cmd.CommandText = "BodegaPliegos_CrearPalletMaquinas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", compo);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        d = new BodegaPliegos();
                        //d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                        d.CodigoProducto = reader["Codigo"].ToString();
                        d.OT = reader["OT"].ToString();
                        d.NombreOT = reader["NombreOT"].ToString().ToLower();
                        d.Componente = reader["Componente"].ToString();
                        d.Papel = reader["Papel"].ToString();
                        //d.FormatoPapel = reader["FormatoPapel"].ToString();
                        d.Gramaje = reader["Gramaje"].ToString();
                        d.Ancho = reader["Ancho"].ToString();
                        d.Largo = reader["Largo"].ToString();
                        d.StockFL = Convert.ToInt32(reader["CantidadAsignada"].ToString()).ToString("N0").Replace(",", ".");
                        d.SKUSalida = reader["SKUSalida"].ToString();
                        d.FAncho = reader["FAncho"].ToString();
                        d.FLargo = reader["FLargo"].ToString();
                    }

                }

            conexion.CerrarConexion();

            return d;
        }


        public List<BodegaPliegos> CargaPendientesPesa()
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[bodegaPliegos_InicioPesa]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["Codigo"].ToString();
                    d.OT = reader["OT"].ToString();
                  //  d.Folio = reader["Folio"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    //d.FormatoPapel = reader["FormatoPapel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.Asignar = Convert.ToInt32(reader["Procesado"].ToString()).ToString("N0").Replace(",", ".");
                    d.StockFL = Convert.ToInt32(reader["CantidadAsignada"].ToString()).ToString("N0").Replace(",", ".");


                    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Atender(\"" + reader["id_corte"].ToString() + "\",\"" + d.OT + "\",\"" + d.Componente + "\",\"" + d.CodigoProducto + "\",\"" + reader["PreID"].ToString() + "\",\"" + reader["Folio"].ToString() + "\",\"" + reader["Procedencia"].ToString() + "\",\"" + reader["CostoMedioPliego"].ToString() + "\");'>Procesar</a>";//reader["Folio"].ToString() 
                    
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaAsignacion"].ToString()).ToString("dd/MM/yyyy");

                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string IngresarPallet(string FolioOrigen,string codigo,string ot,string componente,string nombreot,string papel,string marca,int gramaje,int ancho,int largo,int pliegos,float peso,string usuario,string FolioAnterior,string IDTrabajo,string Procedencia,int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            string respuesta = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_IngresaPallet2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@FolioOrigen", FolioOrigen);
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Largo", largo); 
                cmd.Parameters.AddWithValue("@Pliegos", pliegos);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@FolioAnterior", FolioAnterior);
                cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);
                cmd.Parameters.AddWithValue("@Procedencia", Procedencia);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = dr["respuesta"].ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public string IngresarPalletCorte(string IDCorte,int Pliegos,float Peso,string Usuario,string SKUSalida,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            string respuesta = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_IngresaPalletCorte";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCorte", IDCorte);
                cmd.Parameters.AddWithValue("@Pliegos", Pliegos);
                cmd.Parameters.AddWithValue("@Peso", Peso);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@SKUSalida", SKUSalida);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = dr["respuesta"].ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public int CantidadPallet(string ot, string componente,string Codigo, int procedimiento)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_PalletCreados";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@Codigo", Codigo);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["Cantidad"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }


        public BodegaPliegos CargaEtiquetaBP(string Folio, int Procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_EtiquetaBP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) 
                {
                    d = new BodegaPliegos();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.CodigoProducto = reader["SKU"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.FCAncho = reader["FCAncho"].ToString();
                    d.FCLargo = reader["FCLargo"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.SolicitadoFL = Convert.ToInt32(reader["CantidadAsignada"].ToString()).ToString("N0").Replace(",", ".");
                    d.SolicitadoKG = reader["PesoAsignada"].ToString();
                    d.Seleccionar = reader["CreadoPor"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                }

            }

            conexion.CerrarConexion();

            return d;
        }

        public string CargaPalletCreados(string Folio,string OT,string Componente, int procedimiento)
        {
            string Encabezado = "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1000px;'>" +
            "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
            "Folio</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
            "Ubicacion</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Componente</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Cantidad</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Peso</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Creado Por</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Fecha Creacion</td>" +
            "</tr>";
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_CargaPalletCreados]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
                    reader["Folio"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
                    "Sin Ubicación</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    reader["Componente"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                    Convert.ToInt32(reader["CantidadAsignada"]).ToString("N0").Replace(",", ".") + " Pliegos.&nbsp;&nbsp;</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                    reader["PesoAsignada"].ToString() + " KG.&nbsp;&nbsp;</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    reader["CreadoPor"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                    "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }
        public List<BodegaPliegos> CargaSolicitudCorte(string ot, string nombreot, string papel, string codigoPapel, string Folio, int estado, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_Cortadora]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@CodigoPapel", codigoPapel);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BodegaPliegos d = new BodegaPliegos();
                        d.Folio = reader["CodigoID"].ToString();
                        d.FechaCreacion = Convert.ToDateTime(reader["FechaAsignacion"].ToString()).ToString("dd/MM/yyyy");
                        d.CodigoProducto = reader["Codigo"].ToString();
                        d.OT = reader["OT"].ToString();
                        d.Componente = reader["Componente"].ToString();
                        d.Papel = reader["Papel"].ToString().ToLower();
                        d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                        d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                        d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                        d.StockFL = Convert.ToInt32(reader["Asignado"].ToString()).ToString("N0").Replace(",", ".");
                        d.Estado = "<div style='color:red;'>Sin Atender</div>";
                        if (d.OT.Trim().ToLower().Contains("stock"))
                        {
                            d.Estado = "<a style='Color:Red;text-decoration:none;cursor:pointer;'>Ubicar</a>";
                        }
                        //else
                        //{
                        //    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Atender(\"" + d.Folio + "\");'>Atender</a>";
                        //}
                        lista.Add(d);
                    }
                }
            con.CerrarConexion();
            return lista;
        }
        public bool RecepcionPalletsCortadora(int id,string codigo, string usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "[BodegaPliegos_RecepcionPalletCortadora]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAsignacion", id);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
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

        public BodegaPliegos CargaFaltantesDimensionadora(string IDTrabajo,string FolioOrigen,int procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CargaFaltantes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);
                cmd.Parameters.AddWithValue("@FolioOrigen", FolioOrigen);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    int sol = Convert.ToInt32(reader["CantidadSolicitada"].ToString());
                    int asig = Convert.ToInt32(reader["CantidadAsignada"].ToString());
                    int falt = (sol - asig);
                    d.Solicitada = sol.ToString();
                    d.Asignada = asig.ToString();
                    d.Faltante = falt.ToString();
                }

            }

            conexion.CerrarConexion();

            return d;
        }
    }
}