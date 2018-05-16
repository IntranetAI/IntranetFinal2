using Intranet.ModuloEtiquetasMetricsWIP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEtiquetasMetricsWIP.Controller
{
    public class EtiquetasController
    {
        public List<Etiquetas> Produccion_EstadisticaEnc(string OT,string Pliego,string Maquina,int Procedimiento)
        {
            List<Etiquetas> lista = new List<Etiquetas>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Listar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Procedimiento", 0);
                cmd.CommandTimeout = 9000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Etiquetas p = new Etiquetas();
                    p.OT = reader["numordem"].ToString();
                    p.NombreOT = reader["descricao"].ToString().ToLower();
                    p.Tiraje = Convert.ToInt32( reader["qtdplanejado"].ToString());
                    p.Buenos = Convert.ToInt32(reader["bons"].ToString());
                    p.ObjId = reader["objId"].ToString();
                    p.Maquina = reader["maquina"].ToString();
                    p.CantidadPallets= Convert.ToInt32(reader["palletqty"].ToString());
                    p.FechaInicio = Convert.ToDateTime(reader["DtHoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    p.Pliego = reader["processo"].ToString().ToLower();
                    p.Accion = "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:Mostrar(\"" + p.ObjId + "\",\"" + p.OT + "\",\"" + p.NombreOT.ToUpper() +  "\",\"" + p.Pliego.ToUpper() + "\")' >Seleccionar</a>";
                   
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();

            return lista;
        }
        public int CrearEtiqueta(string Objid,int Cantidad)
        {
            int result = 0; 
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Crear]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEntradaMaquina", Objid);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.CommandTimeout = 9000000;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
                catch (Exception ex)
                {
                }
            }
            conexion.CerrarConexion();

            return result;
        }
        public Etiquetas Carga_Etiqueta(string IdPallet, int Procedimiento)
        {
            Etiquetas p = null; Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Listar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", IdPallet);
                cmd.Parameters.AddWithValue("@Pliego", "");
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Procedimiento", 1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    p = new Etiquetas();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT= reader["NombreOT"].ToString();
                    p.FechaCreacion= Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    p.Tiraje2 = Convert.ToInt32(reader["Planificado"].ToString()).ToString("N0").Replace(",", ".");
                    p.Cliente= reader["Cliente"].ToString();
                    p.Elemento= reader["ElementoCompleto"].ToString();
                    p.Pliego = reader["Pliego"].ToString() + "<br/>" + reader["Elemento"].ToString();//cortado + comp
                    p.Actividad= reader["Processo"].ToString();//replace
                    p.ProximaActividad = reader["ProxActividad"].ToString(); //reader[""].ToString();
                    p.Observacion= reader["Obs"].ToString();
                    p.Maquina= reader["Maquina"].ToString();
                    p.Operador= reader["InsUser"].ToString();
                    p.Peso= reader["QuantityKG"].ToString();
                    p.Cantidad = Convert.ToInt32(reader["Quantity"].ToString()).ToString("N0").Replace(",", ".");
                    p.IdPallet= reader["IdPalletLabel"].ToString();
                }

            }
            conexion.CerrarConexion();

            return p;
        }

        public string ResultadoFiltro(string OT, string Pliego, string Maquina,int Procedimiento)
        {
            string result = "";string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1070px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:220px;'>Nombre OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:280px;'>Pliego</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Tiraje</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Buenos</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Maquina</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Fecha Inicio</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Etiquetas Creadas</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Cantidad Etiquetas</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Accion</td>" +
          "</tr>";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Listado]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 9000000;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = result + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                           reader["numordem"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:230px;'>" +
                           reader["descricao"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:300px;'>" +
                           reader["processo"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:70px;'>" +
                           reader["qtdplanejado"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:70px;'>" +
                           reader["bons"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                           reader["maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                           Convert.ToDateTime(reader["DtHoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:70px;'>" +
                           reader["PalletCreados"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           reader["CantidadCreada"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                           "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:Mostrar(\"" + reader["objid"].ToString() + "\",\"" + reader["numordem"].ToString() + "\",\"" + reader["descricao"].ToString() + "\",\"" + reader["processo"].ToString() + "\",\"" + reader["CantidadCreada"].ToString() + "\",\"" + reader["qtdplanejado"].ToString() + "\")' >Seleccionar</a>" + "</td>" +



                           "</tr>";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            conexion.CerrarConexion();
            return Encabezado + result + "</tbody></table>";
        }

        public List<Etiquetas> ListaPliegosOT(string OT, string Pliego, string Maquina, int procedimiento)
        {
            List<Etiquetas> lista = new List<Etiquetas>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Listado]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Etiquetas d = new Etiquetas();
                    d.Pliego = reader["Pliego"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public string HistorialEtiquetas(string OT, string Pliego)
        {
            string result = ""; string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:850px;margin-left:3px;'>" +
           "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Nro Pallet</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Cantidad</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Peso</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Pallet</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:170px;'>Fecha Creacion</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Estado</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Usuario</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:220px;'>Local</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Ubicacion</td>" +
             "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Accion</td>" +
           "</tr>";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_Listado]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Procedimiento", 1);
                cmd.CommandTimeout = 9000000;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = result + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                           reader["idPalletLabel"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                           reader["Quantity"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                           reader["QuantityKG"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                           reader["Pallet"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:170px;'>" +
                           Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           reader["Estado"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                           reader["InsUser"].ToString() + " </td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:220px;'>" +
                           reader["Local"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:50px;'>" +
                           reader["Ubicacion"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                           "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:HistorialEtiquetas(\"" + reader["idPalletLabel"].ToString() + "\")' >Reimprimir</a>" + "</td>" +



                           "</tr>";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            conexion.CerrarConexion();
            return Encabezado + result + "</tbody></table>";
        }

        public int CrearEtiquetaxIntranet(int idpallet,string Objid, int Cantidad)
        {
            int result = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Metrics_Etiquetas_CrearenIntranet]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpallet", idpallet);
                cmd.Parameters.AddWithValue("@objid", Objid);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Procedimiento", 0);
                cmd.CommandTimeout = 9000000;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
                catch (Exception ex)
                {
                }
            }
            conexion.CerrarConexion();

            return result;
        }
    }
}