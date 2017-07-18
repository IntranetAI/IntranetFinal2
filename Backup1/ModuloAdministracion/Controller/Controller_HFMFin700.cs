using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_HFMFin700
    {
        public List<HFM_Fin700> Listar(int Año, int Mes)
        {
            List<HFM_Fin700> lista = new List<HFM_Fin700>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionSV2008Fin();
            if (cmd != null)
            {
                cmd.CommandText = "select emp.empid as empresa ,ent.entrut as rut_empresa ,ent.entrazonsocial as razon_social ,cta.ctacodigo as cuenta "+
                                    ",cta.ctanombre as nombre_cuenta ,mes.ejeano as año ,mes.permes as mes ,mes.perglosa as glosa_mes "+
                                    ",convert(numeric(18,2),sum(movccemontolocaldebe) - sum(movccemontolocalhaber)) as saldo "+
                                    " from cont_cabeceracom cab ,cont_detallecom det ,glbt_periodos ape ,glbt_periodos mes ,glbt_empresas emp "+
                                    ",glbt_entidad ent ,cont_cuentas cta where mes.ejeano = "+Año+" and mes.permes = "+Mes+"and ape.pempid = mes.pempid "+
                                    " and ape.ejeano = mes.ejeano and ape.permes = 0 and ape.pempid = emp.empid and emp.pentid = ent.entid "+
                                    " and cab.pempid = mes.pempid and cab.perid <= mes.perid and cab.perid >= ape.perid "+
                                    "and cab.cabcompid = det.pcabcompid and det.pctaid = cta.ctaid and cta.ctanombre not like '%Fecu%' and cta.ctanombre not like '%IFRS%' "+
                                    "and cta.ctacodigo!=260107 and cta.ctacodigo!=330101 group by emp.empid ,ent.entrut ,ent.entrazonsocial " +
                                    ",cta.ctacodigo ,cta.ctanombre ,mes.ejeano ,mes.permes ,mes.perglosa order by emp.empid ,ent.entrut "+
                                    ",ent.entrazonsocial ,cta.ctacodigo ,cta.ctanombre ,mes.ejeano ,mes.permes ,mes.perglosa";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HFM_Fin700 Fin700 = new HFM_Fin700();
                    Fin700.Entidad = reader["razon_social"].ToString();
                    Fin700.Año = reader["año"].ToString();
                    Fin700.NMes = Convert.ToInt32(reader["mes"].ToString());
                    switch (Fin700.NMes)
                    {
                        case 1: Fin700.Mes = "Enero"; break;
                        case 2: Fin700.Mes = "Febrero"; break;
                        case 3: Fin700.Mes = "Marzo"; break;
                        case 4: Fin700.Mes = "Abril"; break;
                        case 5: Fin700.Mes = "Mayo"; break;
                        case 6: Fin700.Mes = "Junio"; break;
                        case 7: Fin700.Mes = "Julio"; break;
                        case 8: Fin700.Mes = "Agosto"; break;
                        case 9: Fin700.Mes = "Septiembre"; break;
                        case 10: Fin700.Mes = "Octubre"; break;
                        case 11: Fin700.Mes = "Noviembre"; break;
                        case 12: Fin700.Mes = "Diciembre"; break;
                    }

                    Fin700.NCuenta = reader["cuenta"].ToString();
                    Fin700.Nombre_Cuen = reader["nombre_cuenta"].ToString();
                    Fin700.Saldo = reader["saldo"].ToString();
                    lista.Add(Fin700);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}