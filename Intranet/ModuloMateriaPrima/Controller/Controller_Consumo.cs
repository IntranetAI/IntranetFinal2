using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.ModuloMateriaPrima.Controller
{
    public class Controller_Consumo
    {
        public string CargaConsumo(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";
            #region Encabezado
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;'>" +
  "<tbody>" +
  "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:43px;' " +
          "class='style16'>OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:285px;' " +
          "class='style16'>Nombre OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:61px;' " +
        "class='style16'>Codigo </td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:326px;' " +
          "class='style16'>Papel</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:51px;' " +
          "class='style16'>Gramaje</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:42px;' " +
          "class='style16'>Ancho</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:38px;' " +
          "class='style16'>Largo</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Consumo KGs.</td>" +
  "</tr>";
            #endregion
            int TotalConsumoBodega = 0;
            int TotalConsumoDesperdicio = 0;
            int TotalConsumoTeorico = 0;
            string Diferencias = "";


            string ot = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaMP_ConsumoBobinas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OTs);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (ot == "")
                    {
                        TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                        TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                        TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                        if (TotalConsumoBodega < TotalConsumoDesperdicio)
                        {
                            Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                        }
                        else
                        {
                            Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                        }
                        ot = reader["numordem"].ToString();
                        Contenido = Contenido + encabezado +
                        "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        reader["numordem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["NombreOT"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                        reader["coditem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["Material"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                        "</tr>";

                    }
                    else
                    {
                        if (ot == reader["numordem"].ToString())
                        {
                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            if (TotalConsumoBodega < TotalConsumoDesperdicio)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                            }
                            Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                    "</tr>";
                        }
                        else
                        {

                            Contenido = Contenido + "</tbody></table>";

                            Contenido = Contenido +
                            "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                            "<tbody>" +
                            "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Papel Solicitado</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                            "Consumo en Maquina</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Consumo en Metrics</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Diferencias</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "&nbsp;</td>" +
                            "</tr>" +
                            "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Diferencias + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            "ver mas</td>" +
                            "</tr>" +
                            "</tbody></table>";


                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            if (TotalConsumoBodega < TotalConsumoDesperdicio)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                            }
                            ot = reader["numordem"].ToString();
                            Contenido = Contenido + encabezado +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                            "</tr>";
                        }
                    }
                }
                if (reader.Read() == false)
                {
                    if (Contenido != "")
                    {
                        Contenido = Contenido + "</tbody></table>";
                        Contenido = Contenido +
                        "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                        "<tbody>" +
                        "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Papel Solicitado</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                        "Consumo en Maquina</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Consumo en Metrics</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "Diferencias</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "&nbsp;</td>" +
                        "</tr>" +
                        "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Diferencias + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        "ver mas</td>" +
                        "</tr>" +
                        "</tbody></table>";
                    }
                }
            }
            con.CerrarConexion();
            return Contenido;

        }

        public string CargaConsumoMetrics(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";

            #region Encabezado
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:100%;'>" +
  "<tbody>" +
  "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:43px;' " +
          "class='style16'>OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:285px;' " +
          "class='style16'>Nombre OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:61px;' " +
        "class='style16'>Codigo </td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:326px;' " +
          "class='style16'>Papel</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:51px;' " +
          "class='style16'>Gramaje</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:42px;' " +
          "class='style16'>Ancho</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:38px;' " +
          "class='style16'>Largo</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Consumo KGs.</td>" +
  "</tr>";
            #endregion
            int TotalConsumoBodega = 0;
            int TotalConsumoDesperdicio = 0;
            int TotalConsumoTeorico = 0;
            string Diferencias = "";


            string ot = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {

                    cmd.CommandText = "[BodegaMP_ConsumoBobinasMetrics]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OTs);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (ot == "")
                        {
                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            if (TotalConsumoBodega < TotalConsumoDesperdicio)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                            }
                            ot = reader["numordem"].ToString();
                            Contenido = Contenido + encabezado +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                            "</tr>";

                        }
                        else
                        {
                            if (ot == reader["numordem"].ToString())
                            {
                                TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                                TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                                TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                                if (TotalConsumoBodega < TotalConsumoDesperdicio)
                                {
                                    Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                                }
                                else
                                {
                                    Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                                }
                                Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                reader["numordem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["NombreOT"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                                reader["coditem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["Material"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                        "</tr>";
                            }
                            else
                            {

                                Contenido = Contenido + "</tbody></table>";

                                Contenido = Contenido +
                                "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-right:0px !important;margin-bottom: 15px; width:600px;'>" +
                                "<tbody>" +
                                "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                                "Papel Solicitado</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                                "Consumo en Maquina</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                                "Consumo en Metrics</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                                "Diferencias</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                                "&nbsp;</td>" +
                                "</tr>" +
                                "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Diferencias + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                "ver mas</td>" +
                                "</tr>" +
                                "</tbody></table>";


                                TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                                TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                                TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                                if (TotalConsumoBodega < TotalConsumoDesperdicio)
                                {
                                    Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "</div";
                                }
                                else
                                {
                                    Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoDesperdicio).ToString("N0").Replace(",", ".");
                                }
                                ot = reader["numordem"].ToString();
                                Contenido = Contenido + encabezado +
                                "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                reader["numordem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["NombreOT"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                                reader["coditem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["Material"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                "</tr>";
                            }
                        }
                    }
                    if (reader.Read() == false)
                    {
                        if (Contenido != "")
                        {
                            Contenido = Contenido + "</tbody></table>";
                            Contenido = Contenido +
                            "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-right:0px !important;margin-bottom: 15px; width:600px;'>" +
                            "<tbody>" +
                            "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Papel Solicitado</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                            "Consumo en Maquina</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Consumo en Metrics</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Diferencias</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "&nbsp;</td>" +
                            "</tr>" +
                            "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Diferencias + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            "ver mas</td>" +
                            "</tr>" +
                            "</tbody></table>";
                        }
                    }
                }
                catch
                {

                }
            }

            con.CerrarConexion();
            return Contenido;

        }

        //05-06-2018 CAMBIO QUITAR CARGA DESDE DESPERDICIOPAPEL INTRANET Y CAMBIO EN FORMATO PARA CONSUMO METRICS
        public string CargaConsumoMetricsV2(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";

            #region Encabezado
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:100%;'>" +
  "<tbody>" +
  "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:43px;' " +
          "class='style16'>OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:285px;' " +
          "class='style16'>Nombre OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:61px;' " +
        "class='style16'>SKU </td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:326px;' " +
          "class='style16'>Papel</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:51px;' " +
          "class='style16'>Gramaje</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:42px;' " +
          "class='style16'>Ancho</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Solicitado KGs.</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Consumo KGs.</td>" +
  "</tr>";
            #endregion
            int TotalConsumoBodega = 0;int TotalConsumoDesperdicio = 0;int TotalConsumoTeorico = 0; string Diferencias = "";string ot = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[BodegaMP_ConsumoBobinasMetrics_V2]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OTs);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (ot == "")
                        {
                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico += Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            if (TotalConsumoBodega < TotalConsumoDesperdicio)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".");
                            }
                            ot = reader["numordem"].ToString();
                            Contenido = Contenido + encabezado +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramaje"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["ConsumoTeorico"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                            "</tr>";

                        }
                        else
                        {
                            if (ot == reader["numordem"].ToString())
                            {
                                TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                                TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                                TotalConsumoTeorico += Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                                if (TotalConsumoBodega < TotalConsumoDesperdicio)
                                {
                                    Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "</div";
                                }
                                else
                                {
                                    Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".");
                                }
                                Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                reader["numordem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["NombreOT"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                                reader["coditem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["Material"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Gramaje"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["ConsumoTeorico"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                        "</tr>";
                            }
                            else
                            {

                                Contenido = Contenido + "</tbody></table>";

                                Contenido = Contenido +
                                "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-right:0px !important;margin-bottom: 15px; width:600px;'>" +
                                "<tbody>" +
                                "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                                "Papel Solicitado</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                                "Consumo en Metrics</td>" +
                                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                                "Diferencias</td>" +
                                "</tr>" +
                                "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                Diferencias + "</td>" +
                                "</tr>" +
                                "</tbody></table>";
                                TotalConsumoTeorico = 0;

                                TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                                TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                                TotalConsumoTeorico += Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                                
                                if (TotalConsumoBodega < TotalConsumoDesperdicio)
                                {
                                    Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "</div";
                                }
                                else
                                {
                                    Diferencias = Convert.ToInt32(TotalConsumoBodega - TotalConsumoTeorico).ToString("N0").Replace(",", ".");
                                }
                                ot = reader["numordem"].ToString();
                                Contenido = Contenido + encabezado +
                                "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                reader["numordem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["NombreOT"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                                reader["coditem"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                                reader["Material"].ToString().ToLower() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Gramaje"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                reader["ConsumoTeorico"].ToString() + "&nbsp;&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                "</tr>";
                            }
                        }
                    }
                    if (reader.Read() == false)
                    {
                        if (Contenido != "")
                        {
                            Contenido = Contenido + "</tbody></table>";
                            Contenido = Contenido +
                            "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-right:0px !important;margin-bottom: 15px; width:600px;'>" +
                            "<tbody>" +
                            "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Papel Solicitado</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Consumo en Metrics</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Diferencias</td>" +
                            "</tr>" +
                            "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Diferencias + "</td>" +
                            "</tr>" +
                            "</tbody></table>";
                        }
                    }
                }
                catch
                {

                }
            }

            con.CerrarConexion();
            return Contenido;

        }

        public string CargaOTSV2(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaMP_ConsumoBobinasMetrics_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OTs);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contenido = Contenido + "" + reader["numordem"].ToString() + ",";

                }
                Contenido = Contenido.Substring(0, Contenido.Length - 1);
            }
            con.CerrarConexion();
            return Contenido;

        }

        public string CargaOTS(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaMP_ConsumoBobinas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OTs);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contenido = Contenido + "" + reader["numordem"].ToString() + ",";

                }
                Contenido = Contenido.Substring(0, Contenido.Length - 1);
            }
            con.CerrarConexion();
            return Contenido;

        }


        public string CargaConsumoTeoricoVsMetrics(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";
            #region Encabezado
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;'>" +
  "<tbody>" +
  "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:43px;' " +
          "class='style16'>OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:285px;' " +
          "class='style16'>Nombre OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:61px;' " +
        "class='style16'>Codigo </td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:326px;' " +
          "class='style16'>Papel</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:51px;' " +
          "class='style16'>Gramaje</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:42px;' " +
          "class='style16'>Ancho</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:38px;' " +
          "class='style16'>Largo</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Consumo KGs.</td>" +
  "</tr>";
            #endregion
            int TotalConsumoBodega = 0;
            int TotalConsumoDesperdicio = 0;
            int TotalConsumoTeorico = 0;
            string Diferencias = "";
            DateTime Fecha = Convert.ToDateTime("1900-01-01");
            int TeoricoVsMetrics = 0;

            string ot = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaMP_ConsumoBobinas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OTs);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (ot == "")
                    {
                        TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                        TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                        TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                        Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                        if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                        {
                            Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                        }
                        else
                        {
                            Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                        }




                        ot = reader["numordem"].ToString();
                        Contenido = Contenido + encabezado +
                        "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        reader["numordem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["NombreOT"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                        reader["coditem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["Material"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                        "</tr>";

                    }
                    else
                    {
                        if (ot == reader["numordem"].ToString())
                        {
                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                            if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                            }
                            Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                    "</tr>";
                        }
                        else
                        {

                            Contenido = Contenido + "</tbody></table>";

                            Contenido = Contenido +
                            "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                            "<tbody>" +
                            "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Papel Solicitado</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                            "Consumo en Maquina</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Consumo en Metrics</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Diferencias</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Fecha Max.</td>" +
                            "</tr>" +
                            "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Diferencias + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Fecha.ToString("dd/MM/yyyy") + "</td>" +
                            "</tr>" +
                            "</tbody></table>";


                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                            if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                            }
                            ot = reader["numordem"].ToString();
                            Contenido = Contenido + encabezado +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                            "</tr>";
                        }
                    }
                }
                if (reader.Read() == false)
                {
                    if (Contenido != "")
                    {
                        Contenido = Contenido + "</tbody></table>";
                        Contenido = Contenido +
                        "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                        "<tbody>" +
                        "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Papel Solicitado</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                        "Consumo en Maquina</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Consumo en Metrics</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "Diferencias</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "Fecha Max.</td>" +
                        "</tr>" +
                        "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Diferencias + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Fecha.ToString("dd/MM/yyyy") + "</td>" +
                        "</tr>" +
                        "</tbody></table>";
                    }
                }
            }
            con.CerrarConexion();
            return Contenido;

        }


        public string CargaConsumoTeoricoVsMetrics2(string OTs, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = "";
            #region Encabezado
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;'>" +
  "<tbody>" +
  "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:43px;' " +
          "class='style16'>OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:285px;' " +
          "class='style16'>Nombre OT</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:61px;' " +
        "class='style16'>Codigo </td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:326px;' " +
          "class='style16'>Papel</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:51px;' " +
          "class='style16'>Gramaje</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:42px;' " +
          "class='style16'>Ancho</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:38px;' " +
          "class='style16'>Largo</td>" +
        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:92px;' " +
          "class='style16'>Consumo KGs.</td>" +
  "</tr>";
            #endregion
            int TotalConsumoBodega = 0;
            int TotalConsumoDesperdicio = 0;
            int TotalConsumoTeorico = 0;
            string Diferencias = "";
            DateTime Fecha = Convert.ToDateTime("1900-01-01");
            int TeoricoVsMetrics = 0;

            string ot = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaMP_ConsumoBobinasMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OTs);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (ot == "")
                    {
                        TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                        TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                        TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                        Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                        if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                        {
                            Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                        }
                        else
                        {
                            Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                        }




                        ot = reader["numordem"].ToString();
                        Contenido = Contenido + encabezado +
                        "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        reader["numordem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["NombreOT"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                        reader["coditem"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        reader["Material"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                        Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                        "</tr>";

                    }
                    else
                    {
                        if (ot == reader["numordem"].ToString())
                        {
                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                            if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                            }
                            Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                                    "</tr>";
                        }
                        else
                        {

                            Contenido = Contenido + "</tbody></table>";

                            Contenido = Contenido +
                            "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                            "<tbody>" +
                            "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Papel Solicitado</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                            "Consumo en Maquina</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                            "Consumo en Metrics</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Diferencias</td>" +
                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                            "Fecha Max.</td>" +
                            "</tr>" +
                            "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Diferencias + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Fecha.ToString("dd/MM/yyyy") + "</td>" +
                            "</tr>" +
                            "</tbody></table>";


                            TotalConsumoBodega = Convert.ToInt32(reader["ConsumoBodega"].ToString());
                            TotalConsumoDesperdicio = Convert.ToInt32(reader["ConsumoDesperdicio"].ToString());
                            TotalConsumoTeorico = Convert.ToInt32(reader["ConsumoTeorico"].ToString());
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                            if (Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()) < 0)
                            {
                                Diferencias = "<div style='Color:red;'>" + Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".") + "</div";
                            }
                            else
                            {
                                Diferencias = Convert.ToInt32(reader["TeoricoVsMetrics"].ToString()).ToString("N0").Replace(",", ".");
                            }
                            ot = reader["numordem"].ToString();
                            Contenido = Contenido + encabezado +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["numordem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style20'>" +
                            reader["coditem"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["Material"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Gramage"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Ancho"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            reader["Largo"].ToString() + "&nbsp;&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                            "</tr>";
                        }
                    }
                }
                if (reader.Read() == false)
                {
                    if (Contenido != "")
                    {
                        Contenido = Contenido + "</tbody></table>";
                        Contenido = Contenido +
                        "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: -15px;margin-left:492px;margin-bottom: 15px; width:450px;'>" +
                        "<tbody>" +
                        "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Papel Solicitado</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;' class='style16'> " +
                        "Consumo en Maquina</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;' class='style16'>" +
                        "Consumo en Metrics</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "Diferencias</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;' class='style16'>" +
                        "Fecha Max.</td>" +
                        "</tr>" +
                        "<tr style='background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoTeorico).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoDesperdicio).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Convert.ToInt32(TotalConsumoBodega).ToString("N0").Replace(",", ".") + "&nbsp;KGs.</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Diferencias + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        Fecha.ToString("dd/MM/yyyy") + "</td>" +
                        "</tr>" +
                        "</tbody></table>";
                    }
                }
            }
            con.CerrarConexion();
            return Contenido;

        }
    }
}