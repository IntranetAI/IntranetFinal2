using MySql.Data.MySqlClient;
using ServicioWeb.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Controller
{
    public class XMLController
    {
        public List<XMLMetrics> OTSEmitidas()
        {
            List<XMLMetrics> lista = new List<XMLMetrics>();
            List<Homologacion> Lhom = ListadoHomologacion();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 14);//CAMBIAR AL 10 AL SALIR A PRODUCCION... CAMBIOS PARA PRUEBAS
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics dtDist = new XMLMetrics();
                        dtDist.OT = reader["NumOrdem"].ToString();
                        string nOT= reader["Descricao"].ToString();
                        dtDist.NombreOT = Regex.Replace(nOT, @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "y").Replace("/", "").Replace("_", " "); 
                        string aaa = reader["NomeCliente"].ToString();
                        dtDist.Cliente = reader["NomeCliente"].ToString().Replace("&", "y");
                        dtDist.EnvioCorreo = Convert.ToInt32(reader["EnvioCorreo"].ToString());
                        dtDist.CSR = reader["CSR"].ToString();
                        dtDist.CorreoCSR = reader["CorreoCSR"].ToString();

                        /*      CONSULTA CLIENTES A HOMOLOGAR COPESA Y CENCOSUD     */
                        if (Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString()).Count() > 0)
                        {
                            var ooo = Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString()).ToList();
                            
                            dtDist.Cliente = Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString() && dtDist.NombreOT.ToLower().Contains(x.Keyword.ToLower())).Select(p=>p.ClientePrinergy).FirstOrDefault();
                            dtDist.EstadoCliente = "No";
                        }
                        else
                        {
                            dtDist.EstadoCliente = "Si";
                        }
                        

                        // VERSION ANTIGUA PROCEDMIMIENTO MODIFICADA EL 20200408_1101
                        //if (Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString()).Count() > 0)
                        //{
                        //    string ClientePri = BuscaClientePrinergy(dtDist.NombreOT);
                        //    if (ClientePri != "")
                        //    {
                        //        dtDist.EstadoCliente = "No";
                        //    }else
                        //    {
                        //        dtDist.EstadoCliente = "Si";
                        //    }
                        //}
                        //else
                        //{
                        //    string clienteParte = consultaMysql(reader["NomeCliente"].ToString());
                        //    if (clienteParte != "Error")
                        //    {
                        //        dtDist.EstadoCliente = "No";
                        //    }
                        //    else
                        //    {
                        //        if (reader["NomeCliente"].ToString() == "A Impresores")
                        //        {
                        //            dtDist.EstadoCliente = "No";
                        //        }
                        //        else
                        //        {
                        //            dtDist.EstadoCliente = "Si";
                        //        }
                        //    }

                        //}

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<XMLMetrics> OTSEmitidas_Colores()
        {
            List<XMLMetrics> lista = new List<XMLMetrics>();
            List<Homologacion> Lhom = ListadoHomologacion();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 21);//CAMBIAR AL 10 AL SALIR A PRODUCCION... CAMBIOS PARA PRUEBAS
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics dtDist = new XMLMetrics();
                        dtDist.OT = reader["NumOrdem"].ToString();
                        string nOT = reader["Descricao"].ToString();
                        dtDist.NombreOT = Regex.Replace(nOT, @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "y").Replace("/", "").Replace("_", " ");
                        string aaa = reader["NomeCliente"].ToString();
                        dtDist.Cliente = reader["NomeCliente"].ToString().Replace("&", "y");
                        dtDist.EnvioCorreo = Convert.ToInt32(reader["EnvioCorreo"].ToString());
                        dtDist.CSR = reader["CSR"].ToString();
                        dtDist.CorreoCSR = reader["CorreoCSR"].ToString();

                        /*      CONSULTA CLIENTES A HOMOLOGAR COPESA Y CENCOSUD     */
                        if (Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString()).Count() > 0)
                        {
                            var ooo = Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString()).ToList();

                            dtDist.Cliente = Lhom.Where(x => x.ClienteMetrics == reader["NomeCliente"].ToString() && dtDist.NombreOT.ToLower().Contains(x.Keyword.ToLower())).Select(p => p.ClientePrinergy).FirstOrDefault();
                            dtDist.EstadoCliente = "No";
                        }
                        else
                        {
                            dtDist.EstadoCliente = "Si";
                        } 

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        /* CAMBIOS PROGRMAACION MODO SINCRONIZACION AUTOMATICA*/
        public List<XMLMetrics_Detalle> EstructurasEmitidas()
        {
            List<XMLMetrics_Detalle> lista = new List<XMLMetrics_Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); int ContadorPaginas = 0;string PapelMayor = "";int SumaPaginas = 0;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento",13);//reemplazar por 11 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics_Detalle dtDist = new XMLMetrics_Detalle();

                        dtDist.OT = reader["OT"].ToString().Trim();
                        dtDist.Proceso = reader["Proceso"].ToString().Trim();
                        dtDist.Papel = reader["Papel"].ToString();
                        dtDist.Paginas = Convert.ToInt32(reader["Paginas"].ToString());
                        dtDist.ModeloTracado = reader["PCodModeloTracado"].ToString();
                        dtDist.X = Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Y = Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Xnota = Convert.ToInt32(reader["X"].ToString());
                        dtDist.Ynota = Convert.ToInt32(reader["Y"].ToString());
                        dtDist.MultiplePapel = (Convert.ToInt32(reader["Componentes"].ToString()) > 1 ? true : false);

                        if (dtDist.Papel.ToLower().Contains("couche"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("bond"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra 29 _v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("lwc") || dtDist.Papel.ToLower().Contains("cartulina"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";//perfil de couche
                        }
                        else
                        {
                            dtDist.ColorFlow = "Ink Opt Papel diario";
                        }

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<XMLMetrics_Detalle> EstructurasEmitidas_Colores()
        {
            List<XMLMetrics_Detalle> lista = new List<XMLMetrics_Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); int ContadorPaginas = 0; string PapelMayor = ""; int SumaPaginas = 0;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 20);//reemplazar por 11-13 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics_Detalle dtDist = new XMLMetrics_Detalle();

                        dtDist.OT = reader["OT"].ToString().Trim();
                        dtDist.Proceso = reader["Proceso"].ToString().Trim();
                        dtDist.Papel = reader["Papel"].ToString();
                        dtDist.Paginas = Convert.ToInt32(reader["Paginas"].ToString());
                        dtDist.ModeloTracado = reader["PCodModeloTracado"].ToString();
                        dtDist.X = Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Y = Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Xnota = Convert.ToInt32(reader["X"].ToString());
                        dtDist.Ynota = Convert.ToInt32(reader["Y"].ToString());
                        dtDist.MultiplePapel = (Convert.ToInt32(reader["Componentes"].ToString()) > 1 ? true : false);
                        int Negro = Convert.ToInt32(reader["ColorNegro"].ToString());
                        dtDist.Colores =(( Convert.ToInt32(reader["ColorF"]) >= Convert.ToInt32(reader["ColorV"])) ? Convert.ToInt32(reader["ColorF"]) : Convert.ToInt32(reader["ColorV"]));
                        dtDist.ColoresEspeciales = Convert.ToInt32(reader["ColoresEspeciales"].ToString());
                        dtDist.ColorTiro = Convert.ToInt32(reader["ColorF"]);
                        dtDist.ColorRetiro = Convert.ToInt32(reader["ColorV"]);


                        if (dtDist.Papel.ToLower().Contains("couche"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("bond"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra 29 _v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("lwc") || dtDist.Papel.ToLower().Contains("cartulina"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";//perfil de couche
                        }
                        else
                        {
                            dtDist.ColorFlow = "Ink Opt Papel diario";
                        }

                        string Refinado = "4 CMYK";
                        if(dtDist.Colores==4 && dtDist.ColoresEspeciales == 0)
                        {
                            switch (dtDist.Papel.ToLower())
                            {
                                case "bond":
                                    Refinado = "1 CMYK CF BOND"; break;
                                case "couche":
                                    Refinado = "2 CMYK CF COUCHE"; break;
                                case "diario":
                                    Refinado = "3 CMYK CF DIARIO"; break;
                                default:
                                    Refinado = "4 CMYK";break;
                            }
                        }
                        else if (dtDist.Colores >= 4 && dtDist.ColoresEspeciales >= 1)
                        {
                            switch (dtDist.Papel.ToLower())
                            {
                                case "bond":
                                    Refinado = "5 CMYK CF BOND PLANOS"; break;
                                case "couche":
                                    Refinado = "6 CMYK CF COUCHE PLANOS"; break;
                                case "diario":
                                    Refinado = "7 CMYK CF DIARIO PLANOS"; break;
                                default:
                                    Refinado = "4 CMYK"; break;
                            }
                        }
                        else if (dtDist.Colores <= 3 && dtDist.ColoresEspeciales == 0)
                        {
                            Refinado = "4 CMYK";
                        }
                        else if (dtDist.Colores == 1 && dtDist.ColoresEspeciales == 0 && Negro>=1)
                        {
                            Refinado = "8 ESCALA GRISES";
                        }
                        else
                        {
                            Refinado = "4 CMYK"; 
                        }
                        dtDist.RefinarCon = Refinado;
                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<XMLMetrics_Detalle> EstructurasEmitidasPreviamente()
        {
            List<XMLMetrics_Detalle> lista = new List<XMLMetrics_Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 12);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics_Detalle dtDist = new XMLMetrics_Detalle();

                        dtDist.OT = reader["OT"].ToString().Trim();
                        dtDist.Proceso = reader["Proceso"].ToString().Trim();
                        dtDist.Papel = reader["Papel"].ToString();
                        dtDist.Paginas = Convert.ToInt32(reader["Paginas"].ToString());
                        dtDist.ModeloTracado = reader["PCodModeloTracado"].ToString();
                        dtDist.X = Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Y = Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Xnota = Convert.ToInt32(reader["X"].ToString());
                        dtDist.Ynota = Convert.ToInt32(reader["Y"].ToString());

                        if (dtDist.Papel.ToLower().Contains("couche"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("bond"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra 29 _v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("lwc") || dtDist.Papel.ToLower().Contains("cartulina"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";//perfil de couche
                        }
                        else
                        {
                            dtDist.ColorFlow = "Ink Opt Papel diario";
                        }

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<NotasAntiguas> Clientes_NotasAntiguas()
        {
            List<NotasAntiguas> lista = new List<NotasAntiguas>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 22);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NotasAntiguas dt = new NotasAntiguas();

                        dt.Id = Convert.ToInt32(reader["Id"].ToString().Trim());
                        dt.Cliente = reader["Cliente"].ToString().Trim(); 
                        lista.Add(dt);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public int InsertEstructura(string OT, string NombreGrupo, int Paginas, int Inicio, int FormatoX, int FormatoY, string Papel, string version, int Procedimiento, int ColorTiro, int ColorRetiro, int ColorEspecial)
        {
            int Resp = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "[Prinergy_XML_ParteManual]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", version);
                    cmd.Parameters.AddWithValue("@Cliente", "");
                    cmd.Parameters.AddWithValue("@NombreGrupo", NombreGrupo);
                    cmd.Parameters.AddWithValue("@Paginas", Paginas);
                    cmd.Parameters.AddWithValue("@Inicio", Inicio);
                    cmd.Parameters.AddWithValue("@FormatoX", FormatoX);
                    cmd.Parameters.AddWithValue("@FormatoY", FormatoY);
                    cmd.Parameters.AddWithValue("@Formato", "");
                    cmd.Parameters.AddWithValue("@Papel", Papel);
                    cmd.Parameters.AddWithValue("@Usuario", "");
                    cmd.Parameters.AddWithValue("@ColorTiro", ColorTiro);
                    cmd.Parameters.AddWithValue("@ColorRetiro", ColorRetiro);
                    cmd.Parameters.AddWithValue("@ColorEspecial", ColorEspecial);
                    cmd.Parameters.AddWithValue("@RefinarCon", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 1);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Resp = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return Resp;
            }
            conexion.CerrarConexion();
            return Resp;
        }

        public int InsertUltimaVersion(string OT, string NombreGrupo, int Paginas, int Inicio, int FormatoX, int FormatoY, string Papel, int Procedimiento, int ColorTiro,int ColorRetiro, int ColorEspecial)
        {
            int Resp = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "[Prinergy_XML_ParteManual]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", "");
                    cmd.Parameters.AddWithValue("@Cliente", "");
                    cmd.Parameters.AddWithValue("@NombreGrupo", NombreGrupo);
                    cmd.Parameters.AddWithValue("@Paginas", Paginas);
                    cmd.Parameters.AddWithValue("@Inicio", Inicio);
                    cmd.Parameters.AddWithValue("@FormatoX", FormatoX);
                    cmd.Parameters.AddWithValue("@FormatoY", FormatoY);
                    cmd.Parameters.AddWithValue("@Formato", "");
                    cmd.Parameters.AddWithValue("@Papel", Papel);
                    cmd.Parameters.AddWithValue("@Usuario", "");
                    cmd.Parameters.AddWithValue("@ColorTiro", ColorTiro);
                    cmd.Parameters.AddWithValue("@ColorRetiro", ColorRetiro);
                    cmd.Parameters.AddWithValue("@ColorEspecial", ColorEspecial);
                    cmd.Parameters.AddWithValue("@RefinarCon", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 2);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Resp = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return Resp;
            }
            conexion.CerrarConexion();
            return Resp;
        }

        /*FIN*/

        public List<XMLMetrics_Detalle> ComponentesOT(string OT)
        {
            List<XMLMetrics_Detalle> lista = new List<XMLMetrics_Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Procedimiento", 1);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XMLMetrics_Detalle dtDist = new XMLMetrics_Detalle();

                        dtDist.OT = reader["OT"].ToString();
                        dtDist.Proceso = reader["Proceso"].ToString();
                        dtDist.Papel = reader["Papel"].ToString();
                        dtDist.Paginas = Convert.ToInt32(reader["Paginas"].ToString());
                        dtDist.ModeloTracado = reader["PCodModeloTracado"].ToString();
                        dtDist.X = Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["X"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Y = Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(reader["Y"].ToString()) * 2.8346) + 2).ToString();
                        dtDist.Xnota = Convert.ToInt32(reader["X"].ToString());
                        dtDist.Ynota = Convert.ToInt32(reader["Y"].ToString());

                        if (dtDist.Papel.ToLower().Contains("couche"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";
                        }else if (dtDist.Papel.ToLower().Contains("bond"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra 29 _v2";
                        }
                        else if (dtDist.Papel.ToLower().Contains("lwc") || dtDist.Papel.ToLower().Contains("cartulina"))
                        {
                            dtDist.ColorFlow = "Ink Opt Fogra_39_v2";//perfil de couche
                        }
                        else
                        {
                            dtDist.ColorFlow = "Ink Opt Papel diario";
                        }

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Homologacion> ListadoHomologacion()
        {
            List<Homologacion> lista = new List<Homologacion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 2);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Homologacion h = new Homologacion();
                        h.ClienteMetrics = reader["ClienteMetrics"].ToString();
                        h.ClientePrinergy = reader["ClientePrinergy"].ToString();
                        h.Keyword = reader["Keyword"].ToString();
                        lista.Add(h);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string BuscaClientePrinergy(string NombreOT)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); string resultado = "";
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", NombreOT);
                    cmd.Parameters.AddWithValue("@Procedimiento", 3);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       resultado = reader["ClientePrinergy"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    resultado= "";
                }
            }
            
            con.CerrarConexion();
            return resultado;
        }
        public string consultaMysql(string cliente)
        {
            string result = "Error";
            try
            {
                string cCon = "Server=192.168.1.74;UserID=root;Database=Worldcolor_chile;Password=pacc3059;";
                MySqlConnection cnn = new MySqlConnection();
                cnn.ConnectionString = cCon;
                cnn.Open();
                string consulta = "select* from insite_cliente where nombre = '" + cliente + "'";
                MySqlCommand ncc = new MySqlCommand();
                ncc.Connection = cnn;
                ncc.CommandText = consulta;
                MySqlDataReader myr = ncc.ExecuteReader();
                if (myr.Read())
                {
                    result = myr["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                result = "Error";
            }


            return result;
        }

        public string InsertSincronizacion(string OT,string NombreOT,string Cliente,string Estado,int Activo,string Obs, int Procedimiento)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); string resultado = "";
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_Sincronizacion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Activo", Activo);
                    cmd.Parameters.AddWithValue("@Obs", Obs);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        resultado = reader["resultado"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    resultado = "";
                }
            }

            con.CerrarConexion();
            return resultado;
        }
        public List<ACR> consultaMysql_ACR(DateTime FechaIni, DateTime FechaTer)
        {
            List<ValorACR> valores = ListadoValoresACR("", "", 0, 0, DateTime.Now, 2);
            List<ACR> lista = new List<ACR>();
            try
            {
                string ini = FechaIni.ToString("yyyy-MM-dd");
                string ter =  FechaTer.ToString("yyyy-MM-dd 23:59:59");
                string cCon = "Server=192.168.1.74;UserID=root;Database=Worldcolor_chile;Password=pacc3059;";
                MySqlConnection cnn = new MySqlConnection();
                cnn.ConnectionString = cCon;
                cnn.Open();
                string consulta = "select op.ot2,pro.centro,sum(op.cantidad) as Cantidad, op.registrado from operaciones op" +
                " inner join procesos pro on op.proceso = pro.proceso inner join centros_costos co on pro.centro = co.centro" +
                //" where op.registrado between '"+ini+"' and '"+ter +"' and op.ot2 != 'BBBBBBB' and pro.centro in ('Imposición','Improof','Prueba de Color')" +
                " where op.registrado between '"+ini.ToString()+"' and '"+ter.ToString()+"' and op.ot2 != 'BBBBBBB' and pro.centro in ('Imposición','Improof','Prueba de Color') and op.ot2!='122473'" +
                
                " group by op.ot2,pro.centro,op.registrado order by op.ot2,op.registrado";
                MySqlCommand ncc = new MySqlCommand();
                ncc.Connection = cnn;
                ncc.CommandText = consulta;
                MySqlDataReader myr = ncc.ExecuteReader();
                while (myr.Read())
                {
                    ACR ac = new ACR();
                    ac.OT = myr["OT2"].ToString();
                    ac.Centro= myr["centro"].ToString();
                    ac.Cantidad = Convert.ToInt32(myr["Cantidad"].ToString());
                    ac.Total = Convert.ToInt32(myr["Cantidad"].ToString()) * valores.Where(x => x.Proceso == ac.Centro).Select(p => p.Valor).FirstOrDefault();
                    ac.Fecha = Convert.ToDateTime(myr["Registrado"].ToString());
                    lista.Add(ac);
                }
            }
            catch (Exception ex)
            {
                
            }


            return lista;
        }

        public int InsertACRMentrics(string OT, string Proceso, int Cantidad,int Valor, DateTime Fecha,int Procedimiento)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); int resultado = 0;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_ACR_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Proceso", Proceso);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@Valor",Valor);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        resultado = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    resultado = 0;
                }
            }

            con.CerrarConexion();
            return resultado;
        }

        public List<ValorACR> ListadoValoresACR(string OT, string Proceso, int Cantidad, int Valor, DateTime Fecha, int Procedimiento)
        {
            List<ValorACR> valores = new List<ValorACR>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); 
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_ACR_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Proceso", Proceso);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@Valor", Valor);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@Procedimiento", 2);

                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       ValorACR val = new ValorACR();
                        val.Proceso = reader["Proceso"].ToString();
                        val.Valor = Convert.ToInt32(reader["Valor"].ToString());
                        valores.Add(val);
                    }
                }
                catch (Exception ex)
                {
                     
                }
            }

            con.CerrarConexion();
            return valores;
        }


        //PRUEBAS HISTORIAL PRINERGY

        public List<JsonHistorial_Entrada> PinergyHistorial()
        {
            List<JsonHistorial_Entrada> lista = new List<JsonHistorial_Entrada>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_CargaHistorial_Prueba";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        JsonHistorial_Entrada dtDist = new JsonHistorial_Entrada();
                        dtDist.Usuario = reader["usuario"].ToString();
                        dtDist.Fecha = reader["fecha"].ToString();
                        dtDist.Json = "[" + reader["json"].ToString() + "]";
                        dtDist.Id = Convert.ToInt32(reader["id"].ToString());
                        dtDist.OT = reader["ot"].ToString();



                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }



        //pruebas clientes desde prinergy
        public List<ACR> Cliente_Prinergy(DateTime FechaIni, DateTime FechaTer)
        {
            List<ValorACR> valores = ListadoValoresACR("", "", 0, 0, DateTime.Now, 2);
            List<ACR> lista = new List<ACR>();
            try
            {
                string ini = FechaIni.ToString("yyyy-MM-dd");
                string ter = FechaTer.ToString("yyyy-MM-dd 23:59:59");
                string cCon = "Server=192.168.1.74;UserID=root;Database=Worldcolor_chile;Password=pacc3059;";
                MySqlConnection cnn = new MySqlConnection();
                cnn.ConnectionString = cCon;
                cnn.Open();
                string consulta = "select op.ot2,pro.centro,sum(op.cantidad) as Cantidad, op.registrado from operaciones op" +
                " inner join procesos pro on op.proceso = pro.proceso inner join centros_costos co on pro.centro = co.centro" +
                //" where op.registrado between '"+ini+"' and '"+ter +"' and op.ot2 != 'BBBBBBB' and pro.centro in ('Imposición','Improof','Prueba de Color')" +
                " where op.registrado between '" + ini.ToString() + "' and '" + ter.ToString() + "' and op.ot2 != 'BBBBBBB' and pro.centro in ('Imposición','Improof','Prueba de Color')" +

                " group by op.ot2,pro.centro,op.registrado order by op.ot2,op.registrado";
                MySqlCommand ncc = new MySqlCommand();
                


                ncc.Connection = cnn;
                ncc.CommandText = consulta;
                MySqlDataReader myr = ncc.ExecuteReader();
                while (myr.Read())
                {
                    ACR ac = new ACR();
                    ac.OT = myr["OT2"].ToString();

                    lista.Add(ac);
                }
            }
            catch (Exception ex)
            {

            }


            return lista;
        }
        /* PAGINAS DE INICIO*/
        public List<PaginasInicio> CleintesPaginaInicio3()
        {
            List<PaginasInicio> lista = new List<PaginasInicio>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet(); 
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 15);//reemplazar por 11 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PaginasInicio dtDist = new PaginasInicio();

                        dtDist.Cliente = reader["Cliente"].ToString();
                        dtDist.Keyword = reader["Keyword"].ToString();
                        dtDist.Pagina = Convert.ToInt32(reader["Inicio"].ToString());
                        
                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<APA_Clientes> ClientesAPA()
        {
            List<APA_Clientes> lista = new List<APA_Clientes>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 16);//reemplazar por 11 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        APA_Clientes dtDist = new APA_Clientes();

                        dtDist.Cliente = reader["Cliente"].ToString();
                        dtDist.Keyword = reader["Keyword"].ToString();
                        dtDist.APA = reader["APA"].ToString();

                        lista.Add(dtDist);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

    }
}