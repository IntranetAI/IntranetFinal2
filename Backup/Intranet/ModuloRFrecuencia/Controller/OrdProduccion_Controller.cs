using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloRFrecuencia.Model;

namespace Intranet.ModuloRFrecuencia.Controller
{
    public class OrdProduccion_Controller
    {
        public OrdenProduccion ListOrPro(string OP)
        {
            OrdenProduccion op = new OrdenProduccion();
            Conexion con = new Conexion();
            SqlCommand cmd;

            if (OP.Substring(0, 1).ToUpper() == "B")
            {
                cmd = con.AbrirConexionDataP2B2000();
                if (cmd != null)
                {
                    cmd.CommandText = "select QG_RMS_JOB_NBR as NumeroOT, NM as NombreOT, CUST_NM as NombreCliente from Data_P2B.dbo.QGPressJob where QG_RMS_JOB_NBR ='" + OP + "'";

                }
            }
            else
            {
                cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = "ListOp";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OP", OP);
                }
            }

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                op.OrdenP = reader["NumeroOT"].ToString();
                op.Nombre_OT = reader["NombreOT"].ToString();
                op.Cliente = reader["NombreCliente"].ToString();
            }
            con.CerrarConexion();

            return op;
        }

        public List<OrdenProduccion> listaOrPliegos(string Op, string Maquina)
        {
            List<OrdenProduccion> lista = new List<OrdenProduccion>();
            Conexion con = new Conexion();
            SqlCommand cmd;
            if (Op.Substring(0, 1).ToUpper() == "B")
            {
                cmd = con.AbrirConexionDataP2B2000();
                if (cmd != null)
                {
                    if (Maquina != "Dimensionadora")
                    {
                        cmd.CommandText = "select task.FRM_NM as Status, job.QG_RMS_JOB_NBR as Pliego, task.PRN_ORD_QTY as Tiraje_Pliego,  task.SIG_NM as Papel_Solicitud,  task.PRSS_TSK_ID   as NumOrdem" +
                                            ", 0 as estado " +
                                            " from Data_P2B.dbo.QGPressJob job " +
                                            " inner join Data_P2B.dbo.QGPressTask task on job.QG_RMS_JOB_NBR = task.QG_RMS_JOB_NBR" +
                                            " where job.QG_RMS_JOB_NBR = '" + Op + "'";
                    }
                    else
                    {
                        cmd.CommandText = "select '' as Status ,job.QG_RMS_JOB_NBR as Pliego, sum(task.PRN_ORD_QTY) as Tiraje_Pliego,'Forma'  as NumOrdem, '' as Papel_Solicitud, 0 as estado " +
                                            " from Data_P2B.dbo.QGPressJob job " +
                                            " inner join Data_P2B.dbo.QGPressTask task on job.QG_RMS_JOB_NBR = task.QG_RMS_JOB_NBR " +
                                            " where job.QG_RMS_JOB_NBR = '" + Op + "'" +
                                            " group by job.QG_RMS_JOB_NBR";
                    }

                }
            }
            else
            {
                cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = "ListOPPliegos";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OP", Op);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                }

            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                OrdenProduccion orde = new OrdenProduccion();
                //pendiente                
                orde.Cliente = reader["NumOrdem"].ToString();//tarea
                orde.OrdenP = reader["Pliego"].ToString();//NUmero Ot
                orde.TirajePliego = Convert.ToInt32(reader["Tiraje_Pliego"].ToString());
                orde.Papel_Solicitud = reader["Papel_Solicitud"].ToString();
                orde.Status = reader["Status"].ToString();
                lista.Add(orde);
            }
            con.CerrarConexion();

            return lista;
        }
    }
}