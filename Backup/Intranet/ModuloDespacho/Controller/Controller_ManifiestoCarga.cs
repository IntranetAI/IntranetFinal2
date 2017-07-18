using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_ManifiestoCarga
    {
        public List<OrdenCarga> Listarsucursales(string OT, string region)
        {
            List<OrdenCarga> lista = new List<OrdenCarga>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "select p1.Ot, p1.NombreOT, p1.Cliente,CALLESUCURSAL,NOMBRECOMUNA,NOMBRECIUDAD,"+
"(select top 1 p2.FechaProduccion from Produccion.dbo.Produccion p2 where p2.OT = p1.OT and "+
 "p2.FechaProduccion>=GETDATE() order by p2.FechaProduccion desc) as fechaentrega  "+
 "from Produccion.dbo.Produccion p1  "+
 "inner join QGGuiaDespacho.dbo.PROVEEDOR on (p1.Cliente = PROVEEDOR.RAZONSOCIALPROVEEDOR) "+
 "inner join QGGuiaDespacho.dbo.SUCURSAL on (SUCURSAL.RUTPERSONA = PROVEEDOR.RUTPROVEEDOR) "+
 "inner join QGGuiaDespacho.dbo.COMUNA on (SUCURSAL.IDCOMUNA= COMUNA.IDCOMUNA) "+
 "inner join QGGuiaDespacho.dbo.CIUDAD on (CIUDAD.IDCIUDAD = COMUNA.IDCIUDAD) "+
 "where p1.FechaModificacion>'2016-01-01' "+
"and p1.OT =  "+OT+ " and NOMBRECIUDAD like '%"+region+"%' "+
"group by ot, NombreOT,Cliente, CALLESUCURSAL, NOMBRECOMUNA, NOMBRECIUDAD"; 
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrdenCarga orden = new OrdenCarga();
                        orden.OT = OT;
                        orden.NombreOT = reader["NombreOT"].ToString();
                        orden.Cliente = reader["Cliente"].ToString();
                        orden.Sucursal = reader["CALLESUCURSAL"].ToString();
                        orden.FechaEntrega = reader["fechaentrega"].ToString();
                        orden.Comuna = reader["NOMBRECOMUNA"].ToString();
                        orden.Region = reader["NOMBRECIUDAD"].ToString();
                        lista.Add(orden);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}