using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_Papeles
    {
        public string Carga_PapelesOT(string OT, DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {

            string Titulo = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:170px;'>Nombre Componente</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Papel</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Ancho (Bobina)</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Largo</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Grs</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Formato Immpresión</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Consumo KGs</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Consumo PLs</td>" +
                "</tr>";
            string RackLibre = "";
            string OTa = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {

                cmd.CommandText = "[Administracion_PapelesOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                string v1 = "";
                string v2 ="";
                while (reader.Read())
                {
                    string a = reader["OT"].ToString();
                    if (OTa != reader["OT"].ToString())
                    {
                        if (RackLibre != "")
                        {
                            RackLibre = RackLibre + "</tbody></table>";
                        }

                        try
                        {
                            string[] str = reader["FormatoPapel"].ToString().Split('x');
                            v1 = str[0];
                            v2 = str[1];
                        }
                        catch
                        {
                            v1 = reader["FormatoPapel"].ToString();
                            v2 = "";
                        }
                        string Estado = "";
                        if (reader["EstadoOT"].ToString() == "E")
                        {
                            Estado = "<label style='color:Green'>Liquidada</label>";
                        }
                        else
                        {
                            Estado = "<label style='color:Blue'>En Proceso</label>";
                        }

                        
                        string vv = reader["ConsumoKG"].ToString();
                        string v = reader["ConsumoPL"].ToString();
                        RackLibre = RackLibre + "<div style='width:900px;margin-left:15px;'>OT:&nbsp" + reader["OT"].ToString() + "&nbsp;&nbsp;-&nbsp;&nbsp;" + reader["NombreOT"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado: " + Estado + "</div>" + Titulo +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:170px;'>" +
                               reader["Description"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                               reader["NombrePapel"].ToString() + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            v1 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            v2 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            reader["Gramaje"].ToString() + "</td>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            reader["Ancho"].ToString() + "x" + reader["Alto"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                          "</tr>";
                    }
                    else
                    {
                        try
                        {
                            string[] str = reader["FormatoPapel"].ToString().Split('x');
                            v1 = str[0];
                            v2 = str[1];
                        }
                        catch
                        {
                            v1 = reader["FormatoPapel"].ToString();
                            v2 = "";
                        }
                        RackLibre =  RackLibre +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:170px;'>" +
                               reader["Description"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                               reader["NombrePapel"].ToString() + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                           v1 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            v2 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            reader["Gramaje"].ToString() + "</td>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            reader["Ancho"].ToString() + "x" + reader["Alto"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                          "</tr>";
                    }
                    OTa = reader["OT"].ToString();


                }
                RackLibre = RackLibre + "</tbody></table>";
            }
            con.CerrarConexion();
            return RackLibre;
        }





        public List<Papeles> Lista_ExcelPapelesOT(string OT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Papeles> lista = new List<Papeles>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Administracion_PapelesOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Papeles pro = new Papeles();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.NombreComponente = reader["Description"].ToString();
                    pro.NombrePapel=reader["NombrePapel"].ToString();
                    pro.Ancho = reader["Ancho"].ToString();
                    pro.Largo = reader["Alto"].ToString();
                    pro.Gramaje = reader["Gramaje"].ToString();
                    pro.FormatoImpresion = reader["FormatoPapel"].ToString();
                    pro.ConsumoKG = Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",",".");
                    pro.ConsumoPL = Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".");
                    if (reader["EstadoOT"].ToString() == "E")
                    {
                        pro.EstadoOT = "Liquidada";
                    }
                    else
                    {
                        pro.EstadoOT = "En Proceso";
                    }

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}