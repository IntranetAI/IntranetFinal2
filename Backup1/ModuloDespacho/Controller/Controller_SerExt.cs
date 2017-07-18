using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_SerExt
    {
        public List<WipSerExt> Listar(string Ot, string NombreOt, string FechaInicio, string FechaTermino)
        {
            List<WipSerExt> lista = new List<WipSerExt>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_ListSerExt";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", Ot);
                cmd.Parameters.AddWithValue("@NombreOt", NombreOt);
                if ((FechaInicio != "") && (FechaTermino != ""))
                {
                    string[] str = FechaInicio.Split('-');
                    cmd.Parameters.AddWithValue("@FechaInicio", str[1] + "-"+ str[0] + "-"+ str[2]);
                    string[] str2 = FechaTermino.Split('-');
                    cmd.Parameters.AddWithValue("@FechaTermino", str2[1] + "-" + str2[0] + "-" + str2[2]);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WipSerExt ws = new WipSerExt();
                    ws.OT = reader["OT"].ToString();
                    ws.NombreOT = reader["NombreOT"].ToString();
                    ws.ProcExtern = reader["PROCESOEXTERNOGUIADET"].ToString();
                    
                    ws.PliegoImp = Convert.ToInt32(reader["Pliegos_Impresos"].ToString()).ToString("N0").Replace(",",".");
                    ws.Cant_Envio = Convert.ToInt32(reader["CANTIDADTIPOELEMENTO"].ToString()).ToString("N0").Replace(",", ".");
                    ws.Cant_Recep = reader["Cantidad"].ToString();
                    DateTime feE = Convert.ToDateTime(reader["Fecha_Entrega"].ToString());
                    ws.fechDev = feE.ToString("dd-MM-yyyy HH:mm:ss");
                    DateTime fe = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    ws.FechImp = fe.ToString("dd-MM-yyyy HH:mm:ss");
                    lista.Add(ws);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}