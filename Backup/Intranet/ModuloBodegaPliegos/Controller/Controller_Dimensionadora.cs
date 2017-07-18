using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_Dimensionadora
    {
        public List<BodegaPliegos> ListaStockDisponible(string sku,string papel,int gramaje,int ancho,string Marca,string Certificacion, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_StockBobinasBodegaMetrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKU", sku);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Certificacion", Certificacion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["SKU"].ToString();
                    d.Papel = reader["nombrepapel"].ToString();
                    d.Gramaje = Convert.ToInt32(Convert.ToDouble(reader["Gramaje"].ToString())).ToString("N0").Replace(",", ".");
                    d.Ancho = Convert.ToInt32(Convert.ToDouble(reader["Ancho"].ToString())).ToString("N0").Replace(",", ".");
                    d.StockFL = Convert.ToInt32(Convert.ToDouble(reader["Cantidad"].ToString())).ToString("N0").Replace(",", ".");
                   // d.StockFL = Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".");
                    d.Seleccionar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Solicitud(\"" + d.CodigoProducto + "\",\"" + d.Papel + "\",\"" + reader["Gramaje"].ToString() + "\",\"" + reader["Ancho"].ToString() + "\");'>Solicitar</a>";
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public List<BodegaPliegos> ListaStockDisponibleDetalle(string sku, string papel, int gramaje, int ancho, string Marca, string Certificacion, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_StockBobinasBodegaMetrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKU", sku);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Certificacion", Certificacion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Componente = reader["CodigoBobina"].ToString();
                    d.CodigoProducto = reader["SKU"].ToString();
                    d.Papel = reader["nombrepapel"].ToString();
                    d.Gramaje = Convert.ToInt32(Convert.ToDouble(reader["Gramaje"].ToString())).ToString("N0").Replace(",", ".");
                    d.Ancho = Convert.ToInt32(Convert.ToDouble(reader["Ancho"].ToString())).ToString("N0").Replace(",", ".");
                    d.StockFL = Convert.ToInt32(Convert.ToDouble(reader["Cantidad"].ToString())).ToString("N0").Replace(",", ".");
                    // d.StockFL = Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".");
                    d.Seleccionar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Solicitud(\"" + d.CodigoProducto + "\");'>Solicitar</a>";
                    int can = Convert.ToInt32(Convert.ToDouble(reader["Cantidad"].ToString()));
                    d.Accion = "<input id='" + can.ToString() + "' alt='" + d.Componente + "' type='checkbox' name='checkintento' onclick='contar();'/>";

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }


        public BodegaPliegos BuscaOT(string ot,string componente,int procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_SolicitudDimensionadora";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (procedimiento == 0)
                    {
                        d = new BodegaPliegos();
                        d.NombreOT = reader["NombreOT"].ToString();
                    }
                    else if (procedimiento == 2)
                    {
                        d= new BodegaPliegos();
                        d.FormatoPapel = reader["FormatoPapel"].ToString();
                        d.Ancho = reader["AnchoImp"].ToString();
                        d.Largo = reader["LargoImp"].ToString();
                        d.Papel = reader["NombrePapel"].ToString();
                        d.Gramaje = reader["Gramaje"].ToString();
                        d.PliegosSol = Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".");
                        d.Kilos = Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".");
                    }
                }
            }
            conexion.CerrarConexion();
            return d;
        }

        public List<BodegaPliegos> ListaComponenteOT(string ot, string componente, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_SolicitudDimensionadora";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Componente = reader["Componente"].ToString();

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public List<BodegaPliegos> ListaSKU(string sku,int Gramaje,int Ancho, int Largo, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CargaSKU";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKU", sku);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Papel = reader["CodigoItem"].ToString() + " " + reader["Papel"].ToString();//reader["CodigoItem"].ToString() + "  " + reader["TipoDeMaterial"].ToString() + " " + reader["Certificacion"].ToString() + " " + reader["Marca"].ToString() + " " + reader["Gramaje"].ToString() + " gr " + reader["Ancho"].ToString() + " mm x " + reader["Largo"].ToString() + " mm";
                    d.CodigoProducto = reader["CodigoItem"].ToString();

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public string InsertEncabezado(string ot, string componente, int procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_SolicitudDimensionadora";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["respuesta"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public int GuardarTrabajo(string Folio, string OT, string NombreOT, string Componente, string SKU,string Papel, int Gramaje, int Ancho, int Largo, int Pliegos, double Peso,string Usuario,int Procedimiento)
        {
            int resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CrearSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT",NombreOT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@PesoPliegos", Peso);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = Convert.ToInt32(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public string CargarTabla(string Folio, string OT, string NombreOT, string Componente,string SKU, string Papel, int Gramaje, int Ancho, int Largo, int Pliegos, double Peso, string Usuario, int Procedimiento)
        {
            string Encabezado = "<table id='Table1' runat='server' cellpadding='0' cellspacing='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1060px;margin-left:3px;'>" +
                    "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        "OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>" +
                        "Nombre OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                        "Componente</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>" +
                        "Papel</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        "Formato Corte</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>" +
                        "Pliegos Asignados</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>" +
                        "Peso Pliegos</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        "&nbsp;</td>" +
                    "</tr>";
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CrearSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU",SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@PesoPliegos", Peso);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = resultado +
                        "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        reader["OT"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        reader["NombreOT"].ToString().ToLower() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                        reader["Componente"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>" +
                        reader["Papel"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        reader["FAncho"].ToString() + "X" + reader["FLargo"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:120px;'>" +
                        Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:120px;'>" +
                        reader["PesoPliegos"].ToString() + "&nbsp;KG&nbsp;</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        "<a style='Color:Blue;text-decoration: underline;' onclick='javascript:EliminarIngreso(" + reader["id_asignacion"].ToString() + ");'>Eliminar</a></td>" +
                    "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + resultado + "</table>"; ;
        }


        public bool EliminaRegistro(string Folio, string OT, string NombreOT, string Componente, string SKU, string Papel, int Gramaje, int Ancho, int Largo, int Pliegos, double Peso, string Usuario, int Procedimiento)
        {
            bool resultado = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CrearSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@PesoPliegos", Peso);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return resultado;
        }



        public BodegaPliegos ParaStock(string Folio, string OT, string NombreOT, string Componente, string SKU, string Papel, int Gramaje, int Ancho, int Largo, int Pliegos, double Peso, string Usuario, int Procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CrearSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje",Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@PesoPliegos", Peso);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();   
                }
            }
            conexion.CerrarConexion();
            return d;
        }



        public BodegaPliegos CantidadRestante(string Usuario,string Folio, int Procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_PorAsignarSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.PliegosSol = reader["Pliegos"].ToString();
                    d.SolicitadoKG = reader["Peso"].ToString();
                }
            }
            conexion.CerrarConexion();
            return d;
        }


        public bool TerminarSolicitud(string Bobinas,string Folio,string SKU,string Usuario, int Procedimiento)
        {
            bool resultado = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_FinalizarSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bobinas", Bobinas);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return resultado;
        }


        public bool EliminaPendientes(string Usuario, int Procedimiento)
        {
            bool resultado = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_EliminaPendientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return resultado;
        }


        public bool generarCorreo(string Folio)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@qgchile.cl");
            mmsg.Subject = "Solicitud de Bobinas";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = "<table style='width:100%;'>" +
            "<tr>" +
                "<td>" +
                    "<img src='http://www.qg.com/images/qg_logocrop.gif' />" +
                    "<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "Estimado(a) :" +
                    "<br />" +
                      "<br />" +
                        "<br />" +
                    "Se ha generado una solicitud para el envio de las siguientes bobinas:" +
                    "<br/>" +
                    "<br/>" +
                    CargarTablaCorreo(Folio, 1)+
                    "<br/>" +
                    "<br />" +
                    "Atentamente," +
                     "<br />" +
                    "<div style='font: 13px Arial, Helvetica, sans-serif; color: #000099;font-weight: bold;'>Bodega de Pliegos Quad/Graphics Chile S.A.</div>" +
                "</td>" +
            "</tr>" +
            "</table>";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@qgchile.cl");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@qgchile.cl", "SI2013.");

            cliente.Host = "mail.qgchile.cl";
            try
            {
                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public string CargarTablaCorreo(string Folio, int Procedimiento)
        {
            string Encabezado = "<table id='Table1' runat='server' cellpadding='0' cellspacing='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:790px;margin-left:3px;'>" +
                    "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            "SKU</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>" +
                            "Codigo Bobina</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:330px;'>" +
                            "Papel</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            "Gramaje</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            "Ancho</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            "KG</td>" +

                    "</tr>";
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_EliminaPendientes]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Folio);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = resultado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        reader["Sku"].ToString()+"</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>" +
                        reader["CodigoBobina"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:330px;'>" +
                        reader["Papel"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        reader["Gramaje"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        reader["Ancho"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                        reader["CantidadSolicitada"].ToString() + "</td>" +
                    "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + resultado + "</table>"; ;
        }


        public List<BodegaPliegos> CargaPendientesDimensionadora(int Procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_InicioDimensionadora]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["SKU"].ToString();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    //d.FormatoPapel = reader["FormatoPapel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["FAncho"].ToString();
                    d.Largo = reader["FLargo"].ToString();
                    d.StockFL = Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".");
                    d.Marca = Convert.ToInt32(reader["Procesado"].ToString()).ToString("N0").Replace(",", ".");
                    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Procesar(\"" + reader["Folio"].ToString() + "\",\"" + reader["id_asignacion"].ToString() + "\");'>Procesar</a>";
                    d.FechaCreacion = reader["Folio"].ToString();

                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }



        public BodegaPliegos CargaSolicitudTrabajo(string OT,string Componente,string SKU,string Folio,string IDTrabajo,int Procedimiento)
        {
            BodegaPliegos d = null;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_CargaTrabajos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.CodigoProducto = reader["SKU"].ToString();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["FAncho"].ToString();
                    d.Largo = reader["FLargo"].ToString();
                    d.SolicitadoFL = Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".");
                    d.Folio = reader["Folio"].ToString();
                    d.FCAncho = reader["AnchoImp"].ToString();
                    d.FCLargo = reader["LargoImp"].ToString();
                }
            }
            con.CerrarConexion();
            return d;
        }
        public int CargaCantidadTrabajos(string OT, string Componente, string SKU, string Folio, string IDTrabajo, int Procedimiento)
        {
            int Cantidad = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_CargaTrabajos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cantidad = Convert.ToInt32(reader["CantidadAsignada"].ToString());                  
                }
            }
            con.CerrarConexion();
            return Cantidad;
        }

        //public string CrearSolicitudCorte(string OT, string Componente,string Papel, string SKU,int Gramaje,int Ancho,int Largo,int FAncho,int FLargo,int Factor,int CantidadAsignada,double Peso,string Usuario, string Folio,string IDT, int Procedimiento)
        //{
        //    string Cantidad = "";
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionIntranet();
        //    if (cmd != null)
        //    {
        //        cmd.CommandText = "[BodegaPliegos_CreaSolicitudCorte]";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@OT", OT);
        //        cmd.Parameters.AddWithValue("@NombreOT", "");
        //        cmd.Parameters.AddWithValue("@Componente", Componente);
        //        cmd.Parameters.AddWithValue("@Papel", Papel);
        //        cmd.Parameters.AddWithValue("@SKU", SKU);
        //        cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
        //        cmd.Parameters.AddWithValue("@Ancho", Ancho);
        //        cmd.Parameters.AddWithValue("@Largo", Largo);
        //        cmd.Parameters.AddWithValue("@FAncho", FAncho);
        //        cmd.Parameters.AddWithValue("@FLargo", FLargo);
        //        cmd.Parameters.AddWithValue("@Factor", Factor);
        //        cmd.Parameters.AddWithValue("@CantidadAsignada", CantidadAsignada);
        //        cmd.Parameters.AddWithValue("@Peso", Peso);
        //        cmd.Parameters.AddWithValue("@Usuario", Usuario);
        //        cmd.Parameters.AddWithValue("@FolioTrabajo", Folio);
        //        cmd.Parameters.AddWithValue("@IDT", IDT);
        //        cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Cantidad = reader["respuesta"].ToString();
        //        }
        //    }
        //    con.CerrarConexion();
        //    return Cantidad;
        //}
        public string CrearSolicitudCorte(string FolioOrigen, string codigo, string ot, string componente, string nombreot, string papel, string marca, int gramaje, int ancho, int largo, int pliegos, float peso, string usuario, string FolioAnterior, string IDTrabajo, string Procedencia, int procedimiento)
        {
            string Cantidad = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
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
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cantidad = reader["respuesta"].ToString();
                }
            }
            con.CerrarConexion();
            return Cantidad;
        }

        public List<BodegaPliegos> CargaPendientesDimensionadoraConsumo(int Procedimiento, string OT, string Folio)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[BodegaPliegos_Dimensionadora_Consumo]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Folio", Folio);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BodegaPliegos d = new BodegaPliegos();
                        d.CodigoProducto = reader["SKU"].ToString();
                        d.OT = reader["OT"].ToString();
                        d.NombreOT = reader["NombreOT"].ToString().ToLower();
                        d.Componente = reader["Componente"].ToString();
                        d.Papel = reader["Papel"].ToString();
                        //d.FormatoPapel = reader["FormatoPapel"].ToString();
                        d.Gramaje = reader["Gramaje"].ToString();
                        d.Ancho = reader["FAncho"].ToString();
                        d.Largo = reader["FLargo"].ToString();
                        d.StockFL = Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".");
                        d.Marca = "";
                        d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Procesar(\"" + reader["Folio"].ToString() + "\",\"" + reader["OT"].ToString() + "\",\"" + reader["Componente"].ToString() + "\");'>Procesar</a>";
                        d.FechaCreacion = reader["Folio"].ToString();

                        lista.Add(d);
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