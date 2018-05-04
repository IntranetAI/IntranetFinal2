using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloComercial.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloComercial.Controller
{
    public class Presupuesto_Controller
    {
        public List<PresupuestadorM> Lista_Producto(int Procedimiento)
        {
            List<PresupuestadorM> lista = new List<PresupuestadorM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Presupuesto_CargaFormulario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PresupuestadorM p = new PresupuestadorM();
                    p.Producto = reader["Producto"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
        public List<PresupuestadorM> Lista_FormatoAbierto(int Procedimiento)
        {
            List<PresupuestadorM> lista = new List<PresupuestadorM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Presupuesto_CargaFormulario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PresupuestadorM p = new PresupuestadorM();
                    p.FormatoAbierto = reader["Medida"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public PresupuestadorM Carga_Paginas_Pliegos(string Formato, int procedimiento)
        {
            Conexion con = new Conexion();
            PresupuestadorM des = new PresupuestadorM();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Presupuesto_CargaFormatos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Formato", Formato);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.FormatoPagina = reader["FormatoPagina"].ToString();
                    des.PaginasxPliego = reader["PaginasxPleigo"].ToString();
                }

            }
            con.CerrarConexion();
            return des;
        }

        public List<PresupuestadorM> Lista_PaginasInterior(int Procedimiento)
        {
            List<PresupuestadorM> lista = new List<PresupuestadorM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Presupuesto_CargaFormulario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PresupuestadorM p = new PresupuestadorM();
                    p.CantidadPaginas = reader["CantidadPaginas"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public List<Valor_TrimestreQ> Listar_valorTrimestre()
        {
            List<Valor_TrimestreQ> lista = new List<Valor_TrimestreQ>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionPresupuestoFalabella();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mantenedor_ListarValorTrimestre";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Valor_TrimestreQ q = new Valor_TrimestreQ();
                        q.ID_Trimestre = Convert.ToInt32(reader["id_Trimestre"].ToString());
                        q.ValorTrimestre = Convert.ToDouble(reader["ValorTrimestre"].ToString());
                        q.NombreTrimestre = reader["NombreTrimestre"].ToString();
                        q.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        q.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        q.Estado = reader["Estado"].ToString();
                        q.UsuarioCreador = reader["UsuarioCreador"].ToString();
                        lista.Add(q);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Papeles> Listar_Papeles()
        {
            List<Papeles> lista = new List<Papeles>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionPresupuestoFalabella();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mantenedor_ListarPapeles";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Papeles papel = new Papeles();
                        papel.ID_Papel = Convert.ToInt32(reader["id_CostoPapel"].ToString());
                        papel.ID_Trimestre = Convert.ToInt32(reader["id_Trimestre"].ToString());
                        papel.ValorTrimestre = Convert.ToDouble(reader["ValorTrimestre"].ToString());
                        papel.TipoPapel = reader["TipoPapel"].ToString();
                        papel.Marca = reader["Marca"].ToString();
                        papel.NombrePapel = reader["NombrePapel"].ToString();
                        papel.Origen = reader["Origen"].ToString();
                        papel.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString());
                        papel.Presentacion = reader["Presentacion"].ToString();
                        papel.CostoPapelTonelada = Convert.ToDouble(reader["CostoPapel_ToneladaUS"].ToString());
                        papel.GastoBodega = Convert.ToDouble(reader["GastoBodegaUS"].ToString());
                        papel.GastoImportacion = Convert.ToDouble(reader["GastoImportacionUS"].ToString());
                        papel.CostoCIFUS = Convert.ToDouble(reader["CostoCIFUS"].ToString());
                        papel.BodegaSeguro = Convert.ToDouble(reader["BodegaSegurosOtrosUS"].ToString());
                        papel.Obsolencia = Convert.ToDouble(reader["ObsolenciaYMargenUS"].ToString());
                        papel.CortePliego = Convert.ToDouble(reader["CortePliegoUS"].ToString());
                        papel.ValorBase = Convert.ToDouble(reader["ValorBaseUS"].ToString());
                        papel.FacturaCL = Convert.ToDouble(reader["FacturaCL"].ToString());
                        papel.InferiorCL = Math.Round((papel.FacturaCL * 0.95), 2);
                        papel.SuperiorCL = Math.Round((papel.FacturaCL * 1.05), 2);
                        papel.Empresas = reader["Empresas"].ToString();
                        papel.Componente = reader["Componente"].ToString();
                        lista.Add(papel);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;

        }

        public bool InsertCambioValorTrimestral(string Usuario, string valorQ, string FechaTermino, string MesComienzo, string MesPromedio)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionPresupuestoFalabella();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mantenedor_ValorTrimestreAgregar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@ValorTrimestre", valorQ);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                        if (respuesta)
                        {
                            string[] split = FechaTermino.Split('-');
                            CorreoCambioValorTrimestre(valorQ, MesComienzo, MesPromedio, split[0]);
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return respuesta;
        }

        public bool CorreoCambioValorTrimestre(string ValorQ, string MesAjuste, string MesPromedio, string Año)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            //mmsg.To.Add("alejandro.garces@aimpresores.cl");
            //mmsg.To.Add("cecilia.aguirre@aimpresores.cl");
            //mmsg.To.Add("juan.beheran@aimpresores.cl");
            //mmsg.To.Add("natalia.gonzalez@aimpresores.cl");
            mmsg.To.Add("alan.herrera@aimpresores.cl");
            //mmsg.To.Add("juan.venegas@aimpresores.cl");

            mmsg.Body = "<div style='font-family: georgia,serif; font-size: 10pt; color: rgb(0, 0, 0);'>Estimados <br/><br/>" +
                        "El contrato con Falabella, establece que el papel deberá ser reajustado trimestralmente de acuerdo a la siguiente condición: <br/><br/>" +
                        "Mecanismo de Ajuste de Precios del Papel <br/><br/>" +
                        "El valor del papel expresado en pesos chilenos se ajustará trimestralmente, en los meses de Enero, Abril, Julio y Octubre de cada año. <br/>" +
                        "El valor del papel en pesos chilenos será determinado como el producto entre la cotización del dólar observado promedio informado por el Banco central de Chile correspondiente al mes anterior al " +
                        "trimestre en que se realiza el ajuste y valor del papel expresado en dólares. Las variaciones en precio del papel , positivas o negativas, comenzarán a regir a partir del primer día hábil del mes en " +
                        "que se produce el ajuste. <br/>" +
                        "El valor del papel expresado en pesos chilenos se mantendrá fijo durante todo el trimestre, pudiendo ser modificado cada vez que durante dicho período, se produzca una variación positiva o negativa " +
                        "superior al 5%, ocasión en la que las partes podrán solicitar que se ajuste el valor vigente. <br/>" +
                        "Para acreditar el valor de compra del papel de importación directa, bastará la sola exhibición de la factura del proveedor. <br/><br/>" +
                        "Según lo anterior, a partir del 1° de " + MesAjuste + " corresponde hacer el ajuste en el valor del papel usado en la impresión de los catálogos de las empresas del grupo Falabella (Falabella, Homecenter, Tottus). " +
                        "Para ello, para los catálogos que sean cotizados a partir de esta fecha, el tipo de cambio que debes comenzar a usar es $ " + ValorQ + " correspondiente al promedio del mes de " + MesPromedio + " " + Año + ". <br/><br/>" +
                        "Adicionalmente se ajustará el Costo de Papel según Factura (Ton) de algunos papeles, lo anterior consultado al Sr. Rafael Maroto." +
                        "<br/>" +
                        "<br/>" +
                        "<br />" +
                        "Atentamente," +
                            "<br />" +
                        "Departamento de Presupuestos" +
                        "<div align='center'>Powered by the Development Team A Impresores S.A</div></div>";
            mmsg.Subject = "Nuevo tipo de cambio para presupuestos Falabella, Tottus y Homecenter";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

            cliente.Host = "mail.aimpresores.cl";
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

        public bool InsertCambioCostoPapeles(Papeles papel)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionPresupuestoFalabella();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mantenedor_CostoPapelAgregar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Papel", papel.ID_Papel);
                    cmd.Parameters.AddWithValue("@ValorTrimestre", papel.ValorTrimestre);
                    cmd.Parameters.AddWithValue("@TipoPapel", papel.TipoPapel);
                    cmd.Parameters.AddWithValue("@Marca", papel.Marca);
                    cmd.Parameters.AddWithValue("@NombrePapel", papel.NombrePapel);
                    cmd.Parameters.AddWithValue("@Origen", papel.Origen);
                    cmd.Parameters.AddWithValue("@Gramaje", papel.Gramaje);
                    cmd.Parameters.AddWithValue("@Presentacion", papel.Presentacion);
                    cmd.Parameters.AddWithValue("@CostoPapel_ToneladaUS", papel.CostoPapelTonelada);
                    cmd.Parameters.AddWithValue("@GastoBodegaUS", papel.GastoBodega);
                    cmd.Parameters.AddWithValue("@GastoImportacionUS", papel.GastoImportacion);
                    cmd.Parameters.AddWithValue("@CostoCIFUS", papel.CostoCIFUS);
                    cmd.Parameters.AddWithValue("@BodegaSegurosOtrosUS", papel.BodegaSeguro);
                    cmd.Parameters.AddWithValue("@ObsolenciaYMargenUS", papel.Obsolencia);
                    cmd.Parameters.AddWithValue("@CortePliegoUS", papel.CortePliego);
                    cmd.Parameters.AddWithValue("@ValorBaseUS", papel.ValorBase);
                    cmd.Parameters.AddWithValue("@InferiorCL", papel.InferiorCL);
                    cmd.Parameters.AddWithValue("@FacturaCL", papel.FacturaCL);
                    cmd.Parameters.AddWithValue("@SuperiorCL", papel.SuperiorCL);
                    cmd.Parameters.AddWithValue("@Empresas", papel.Empresas);
                    cmd.Parameters.AddWithValue("@Componente", papel.Componente);
                    cmd.Parameters.AddWithValue("@UsuarioCreador", papel.Usuario);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        respuesta = Convert.ToBoolean(reader["Respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            return respuesta;
        }

        public List<Papeles_Export> lista_ExportarExcel()
        {
            List<Papeles_Export> lista = new List<Papeles_Export>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionPresupuestoFalabella();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mantenedor_ListarPapeles";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (lista.Count == 0)
                        {
                            Papeles_Export papel0 = new Papeles_Export();
                            papel0.Gramaje = "(gr/m2)";
                            papel0.CostoPapelTonelada = "(Tonelada)";
                            papel0.GastoImportacion = "1.0%";
                            papel0.BodegaSeguro = "5.0%";
                            papel0.Obsolencia = "12.0%";
                            papel0.CortePliego = "7.0%";
                            papel0.InferiorCL = "Inferior";
                            papel0.FacturaCL = "Factura";
                            papel0.SuperiorCL = "Superior";
                            lista.Add(papel0);
                        }
                        Papeles_Export papel = new Papeles_Export();
                        papel.ValorTrimestre = reader["ValorTrimestre"].ToString();
                        papel.TipoPapel = reader["TipoPapel"].ToString();
                        papel.Marca = reader["Marca"].ToString();
                        papel.NombrePapel = reader["NombrePapel"].ToString();
                        papel.Origen = reader["Origen"].ToString();
                        papel.Gramaje = reader["Gramaje"].ToString();
                        papel.Presentacion = reader["Presentacion"].ToString();
                        papel.CostoPapelTonelada = reader["CostoPapel_ToneladaUS"].ToString();
                        papel.GastoBodega = reader["GastoBodegaUS"].ToString();
                        papel.GastoImportacion = reader["GastoImportacionUS"].ToString();
                        papel.CostoCIFUS = reader["CostoCIFUS"].ToString();
                        papel.BodegaSeguro = reader["BodegaSegurosOtrosUS"].ToString();
                        papel.Obsolencia = reader["ObsolenciaYMargenUS"].ToString();
                        papel.CortePliego = reader["CortePliegoUS"].ToString();
                        papel.ValorBase = reader["ValorBaseUS"].ToString();
                        papel.FacturaCL = reader["FacturaCL"].ToString();
                        papel.InferiorCL = Math.Round((Convert.ToDouble(papel.FacturaCL) * 0.95), 2).ToString();
                        papel.SuperiorCL = Math.Round((Convert.ToDouble(papel.FacturaCL) * 1.05), 2).ToString();
                        papel.Empresas = reader["Empresas"].ToString();
                        papel.Componente = reader["Componente"].ToString();
                        lista.Add(papel);
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