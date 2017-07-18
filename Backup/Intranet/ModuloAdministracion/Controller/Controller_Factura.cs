using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_Factura
    {
        public List<Factura> Listar_Facturas(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicioEmision, string FechaTerminoEmison, string FechaInicioVen, string FechaTerminoVen, int Estado)
        {
            List<Factura> lista = new List<Factura>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Recepcion_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicioEmision", FechaInicioEmision.Replace("/","-"));
                cmd.Parameters.AddWithValue("@FechaTerminoEmision", FechaTerminoEmison.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaInicioVen", FechaInicioVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTerminoVen", FechaTerminoVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.RutEmisor = reader["Rut"].ToString();
                    f.NombreEmisor = reader["NombreEmisor"].ToString();
                    f.Folio = reader["Folio"].ToString().Replace(".0", "");

                    try
                    {
                        string[] str = reader["FechaEmision"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["FechaEmision"].ToString();
                    }


                    try 
                    {

                        string[] str2 = reader["FechaVencimiento"].ToString().Split('-');
                        f.FechaVencimiento = str2[2] + "/" + str2[1] + "/" + str2[0];
                    }
                    catch
                    {
                        f.FechaVencimiento = reader["FechaVencimiento"].ToString();
                    }



                   

                    if (reader["Estado"].ToString() == "ER3")
                    {
                        f.Estado = "DTE no Recibido-Error en Rut de Receptor";
                    }
                    else if (reader["Estado"].ToString() == "ER4") 
                    {
                        f.Estado = "DTE no Recibido-DTE Repetido";
                    }
                    else if (reader["Estado"].ToString() == "ERR")
                    {
                        f.Estado="DTE con errores internos";
                    }
                    else if (reader["Estado"].ToString() == "INI")
                    {
                        f.Estado="DTE inicializado";
                    }
                    f.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + f.Folio + "\",\"" + f.NombreEmisor + "\",\"" + f.RutEmisor + "\")'>Ver Más</a>";//f.RutEmisor
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<Factura> Listar_DetalleFacturas(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicioEmision, string FechaTerminoEmison, string FechaInicioVen, string FechaTerminoVen, int Estado)
        {
            List<Factura> lista = new List<Factura>();
            Conexion conexion = new Conexion();
            string Neto = "";
            string IVA = "";
            string Total = "";
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Recepcion_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicioEmision", FechaInicioEmision.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTerminoEmision", FechaTerminoEmison.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaInicioVen", FechaInicioVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTerminoVen", FechaTerminoVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.RutEmisor = reader["rutt_emis"].ToString();
                    f.NombreEmisor = reader["nomb_emis"].ToString();
                    f.Folio = reader["foli_docu"].ToString().Replace(".0", "");
                    f.NombreItem = reader["Nomb_item"].ToString();
                    f.PrecioItem = reader["Prec_item"].ToString();
                    f.CantItem = reader["cant_item"].ToString();
                    //f.MontoNeto = reader["mont_neto"].ToString();
                    //f.Impuesto = reader["impu_vaag"].ToString();
                    //f.MontoTotal = reader["mont_tota"].ToString();

                    Neto = Convert.ToInt32(reader["mont_neto"].ToString().Replace(".0","")).ToString("N0").Replace(",",".");
                    IVA = Convert.ToInt32(reader["impu_vaag"].ToString().Replace(".0", "")).ToString("N0").Replace(",", ".");
                    Total = Convert.ToInt32(reader["mont_tota"].ToString().Replace(".0", "")).ToString("N0").Replace(",", ".");

                    try
                    {
                        string[] str = reader["fech_emis"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["fech_emis"].ToString();
                    }


                    try
                    {

                        string[] str2 = reader["fech_venc"].ToString().Split('-');
                        f.FechaVencimiento = str2[2] + "/" + str2[1] + "/" + str2[0];
                    }
                    catch
                    {
                        f.FechaVencimiento = reader["fech_venc"].ToString();
                    }





                    if (reader["esta_docu"].ToString() == "ER3")
                    {
                        f.Estado = "DTE no Recibido-Error en Rut de Receptor";
                    }
                    else if (reader["esta_docu"].ToString() == "ER4")
                    {
                        f.Estado = "DTE no Recibido-DTE Repetido";
                    }
                    else if (reader["esta_docu"].ToString() == "ERR")
                    {
                        f.Estado = "DTE con errores internos";
                    }
                    else if (reader["esta_docu"].ToString() == "INI")
                    {
                        f.Estado = "DTE inicializado";
                    }
                
                    lista.Add(f);
                } 
                if (reader.Read() == false)
                {
                    Factura fe = new Factura();
                    fe.RutEmisor = "";
                    fe.NombreEmisor = "";
                    fe.Folio = "";
                    fe.NombreItem = "";
                    fe.PrecioItem = "";
                    fe.MontoNeto = "";
                    fe.Impuesto = "";
                    fe.MontoTotal = "";
                    fe.FechaEmision = "";
                    fe.FechaVencimiento = "Neto:";
                    fe.Estado = "$ " + Neto;
                    lista.Add(fe);

                    Factura fe1 = new Factura();
                    fe1.RutEmisor = "";
                    fe1.NombreEmisor = "";
                    fe1.Folio = "";
                    fe1.NombreItem = "";
                    fe1.PrecioItem = "";
                    fe1.MontoNeto = "";
                    fe1.Impuesto = "";
                    fe1.MontoTotal = "";
                    fe1.FechaEmision = "";
                    fe1.FechaVencimiento = "IVA:";
                    fe1.Estado = "$ " + IVA;
                    lista.Add(fe1);

                    Factura fe2 = new Factura();
                    fe2.RutEmisor = "";
                    fe2.NombreEmisor = "";
                    fe2.Folio = "";
                    fe2.NombreItem = "";
                    fe2.PrecioItem = "";
                    fe2.MontoNeto = "";
                    fe2.Impuesto = "";
                    fe2.MontoTotal = "";
                    fe2.FechaEmision = "";
                    fe2.FechaVencimiento = "Total:";
                    fe2.Estado = "$ " + Total;
                    lista.Add(fe2);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<Factura> Listar_FacturasEnviadas(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicio, string FechaTermino, int Estado)
        {
            List<Factura> lista = new List<Factura>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Envio_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.RutEmisor = reader["Rut"].ToString();
                    f.NombreEmisor = reader["Cliente"].ToString();
                    f.Folio = reader["Folio"].ToString().Replace(".0", "");

                    try
                    {
                        string[] str = reader["FechaEmision"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["FechaEmision"].ToString();
                    }

                    f.FechaVencimiento = reader["dias"].ToString();

                    if (reader["Estado"].ToString() == "DOK")
                    {
                        f.Estado = "DTE OK en el SII";
                    }
                    else if (reader["Estado"].ToString() == "RLV")
                    {
                        f.Estado = "DTE Aceptado con Reparos Leves";
                    }
                    else if (reader["Estado"].ToString() == "ERR")
                    {
                        f.Estado = "DTE con errores internos";
                    }
                    else if (reader["Estado"].ToString() == "RPR")
                    {
                        f.Estado = "Aprobado Con reparos por el SII";
                    }


                    f.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + f.Folio + "\",\"" + f.NombreEmisor + "\",\"" + f.RutEmisor + "\")'>Ver Más</a>";
                    lista.Add(f);  
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<Factura> Listar_DetalleFacturasEnvio(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicio, string FechaTermino, int Estado)
        {
            List<Factura> lista = new List<Factura>();
            Conexion conexion = new Conexion();
            string Neto = "";
            string IVA = "";
            string Total = "";
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Envio_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.RutEmisor = reader["rutt_rece"].ToString();
                    f.Folio = reader["foli_docu"].ToString().Replace(".0", "");
                    f.NombreItem = reader["Nomb_item"].ToString();
                    f.PrecioItem = Convert.ToInt32(Convert.ToDouble(reader["Prec_item"].ToString())).ToString("N0").Replace(",", ".");


                    Neto = Convert.ToInt32(Convert.ToDouble(reader["mont_neto"].ToString())).ToString("N0").Replace(",", ".");
                    IVA = Convert.ToInt32(Convert.ToDouble(reader["impu_vaag"].ToString())).ToString("N0").Replace(",", ".");
                    Total = Convert.ToInt32(Convert.ToDouble(reader["mont_tota"].ToString())).ToString("N0").Replace(",", ".");

                    f.CantItem = Convert.ToInt32(Convert.ToDouble(reader["cant_item"].ToString())).ToString("N0").Replace(",", ".");


                    f.Mensaje = reader["mens_esta"].ToString();
                    
                    f.CreadaPor = reader["val3"].ToString();
                    try
                    {
                        string[] str = reader["fech_emis"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["fech_emis"].ToString();
                    }

                    f.FechaVencimiento = reader["val4"].ToString();






                    lista.Add(f);
                }
                if (reader.Read() == false)
                {
                    Factura fe = new Factura();
                    fe.Folio = "";
                    fe.NombreItem = "";
                    fe.CantItem = "";
                    fe.PrecioItem = "";
                    fe.MontoNeto = "";
                    fe.Impuesto = "";
                    fe.MontoTotal = "";
                    fe.FechaEmision = "";
                    fe.FechaVencimiento = "";
                    fe.Mensaje= "Neto:";
                    fe.CreadaPor = "$ " + Neto;
                    lista.Add(fe);

                    Factura fe1 = new Factura();
                    fe1.Folio = "";
                    fe1.NombreItem = "";
                    fe1.CantItem = "";
                    fe1.PrecioItem = "";
                    fe1.MontoNeto = "";
                    fe1.Impuesto = "";
                    fe1.MontoTotal = "";
                    fe1.FechaEmision = "";
                    fe1.FechaVencimiento = "";
                    fe1.Mensaje = "IVA:";
                    fe1.CreadaPor = "$ " + IVA;
                    lista.Add(fe1);

                    Factura fe2 = new Factura();
                    fe2.Folio = "";
                    fe2.NombreItem = "";
                    fe2.CantItem = "";
                    fe2.PrecioItem = "";
                    fe2.MontoNeto = "";
                    fe2.Impuesto = "";
                    fe2.MontoTotal = "";
                    fe2.FechaEmision = "";
                    fe2.FechaVencimiento = "";
                    fe2.Mensaje = "Total:";
                    fe2.CreadaPor ="$ "+ Total;
                    lista.Add(fe2);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<Factura_Excel> Listar_FacturasEnviadasExcel(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicio, string FechaTermino, int Estado)
        {
            List<Factura_Excel> lista = new List<Factura_Excel>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Envio_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura_Excel f = new Factura_Excel();
                    f.Folio = reader["Folio"].ToString().Replace(".0", "");
                    f.Rut = reader["Rut"].ToString();
                    f.Nombre = reader["Cliente"].ToString();
                    

                    try
                    {
                        string[] str = reader["FechaEmision"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["FechaEmision"].ToString();
                    }

                    f.FechaVencimiento = reader["dias"].ToString();
                    if (reader["mont_neto"].ToString() != "")
                    {
                        f.ValorNeto = Convert.ToInt32(Convert.ToDouble(reader["mont_neto"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.ValorNeto = "0";
                    }
                    if (reader["impu_vaag"].ToString() != "")
                    {
                        f.IVA = Convert.ToInt32(Convert.ToDouble(reader["impu_vaag"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.IVA = "0";
                    }
                    if (reader["mont_tota"].ToString() != "")
                    {
                        f.Total = Convert.ToInt32(Convert.ToDouble(reader["mont_tota"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.Total = "0";
                    }



                    if (reader["Estado"].ToString() == "DOK")
                    {
                        f.Estado = "DTE OK en el SII";
                    }
                    else if (reader["Estado"].ToString() == "RLV")
                    {
                        f.Estado = "DTE Aceptado con Reparos Leves";
                    }
                    else if (reader["Estado"].ToString() == "ERR")
                    {
                        f.Estado = "DTE con errores internos";
                    }
                    else if (reader["Estado"].ToString() == "RPR")
                    {
                        f.Estado = "Aprobado Con reparos por el SII";
                    }
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<Factura_Excel> Listar_FacturasExcel(string Rut, string NombreEmisor, string Folio, string NombreItem, string FechaInicioEmision, string FechaTerminoEmison, string FechaInicioVen, string FechaTerminoVen, int Estado)
        {
            List<Factura_Excel> lista = new List<Factura_Excel>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionSV2000_Factura();

            if (cmd != null)
            {
                cmd.CommandText = "[Recepcion_Factura]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@NombreEmisor", NombreEmisor);
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@NombreItem", NombreItem);
                cmd.Parameters.AddWithValue("@FechaInicioEmision", FechaInicioEmision.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTerminoEmision", FechaTerminoEmison.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaInicioVen", FechaInicioVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@FechaTerminoVen", FechaTerminoVen.Replace("/", "-"));
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura_Excel f = new Factura_Excel();
                    f.Rut = reader["Rut"].ToString();
                    f.Nombre = reader["NombreEmisor"].ToString();
                    f.Folio = reader["Folio"].ToString().Replace(".0", "");

                    try
                    {
                        string[] str = reader["FechaEmision"].ToString().Split('-');
                        f.FechaEmision = str[2] + "/" + str[1] + "/" + str[0];
                    }
                    catch
                    {
                        f.FechaEmision = reader["FechaEmision"].ToString();
                    }


                    try
                    {

                        string[] str2 = reader["FechaVencimiento"].ToString().Split('-');
                        f.FechaVencimiento = str2[2] + "/" + str2[1] + "/" + str2[0];
                    }
                    catch
                    {
                        f.FechaVencimiento = reader["FechaVencimiento"].ToString();
                    }

                    if (reader["mont_neto"].ToString() != "")
                    {
                        f.ValorNeto = Convert.ToInt32(Convert.ToDouble(reader["mont_neto"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.ValorNeto = "0";
                    }
                    if (reader["impu_vaag"].ToString() != "")
                    {
                        f.IVA = Convert.ToInt32(Convert.ToDouble(reader["impu_vaag"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.IVA = "0";
                    }
                    if (reader["mont_tota"].ToString() != "")
                    {
                        f.Total = Convert.ToInt32(Convert.ToDouble(reader["mont_tota"].ToString())).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        f.Total = "0";
                    }



                    if (reader["Estado"].ToString() == "ER3")
                    {
                        f.Estado = "DTE no Recibido-Error en Rut de Receptor";
                    }
                    else if (reader["Estado"].ToString() == "ER4")
                    {
                        f.Estado = "DTE no Recibido-DTE Repetido";
                    }
                    else if (reader["Estado"].ToString() == "ERR")
                    {
                        f.Estado = "DTE con errores internos";
                    }
                    else if (reader["Estado"].ToString() == "INI")
                    {
                        f.Estado = "DTE inicializado";
                    }
                   
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        

    }
}