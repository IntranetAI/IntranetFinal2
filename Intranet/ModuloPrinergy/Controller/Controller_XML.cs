using Intranet.ModuloPrinergy.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Intranet.ModuloPrinergy.Controller
{
    public class Controller_XML
    {
        public XMLFormato BuscaOT(string OT, int Procedimiento)
        {
            XMLFormato xf = new XMLFormato();
            Conexion conexion = new Conexion();
            List<Homologacion> Lhom = ListadoHomologacion();
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
                    cmd.Parameters.AddWithValue("@NombreGrupo", "");
                    cmd.Parameters.AddWithValue("@Paginas", "");
                    cmd.Parameters.AddWithValue("@Inicio", "");
                    cmd.Parameters.AddWithValue("@FormatoX", "");
                    cmd.Parameters.AddWithValue("@FormatoY", "");
                    cmd.Parameters.AddWithValue("@Formato", "");
                    cmd.Parameters.AddWithValue("@Papel", "");
                    cmd.Parameters.AddWithValue("@Usuario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 0);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        xf.OT = reader["OT"].ToString();
                        xf.NombreOT = Regex.Replace(reader["NombreOT"].ToString(), @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "y").Replace("/", "").Replace("_", " ");
                        xf.Cliente = reader["Cliente"].ToString().Replace("&", "y");
                        xf.CSR = reader["CSR"].ToString();
                        if (Lhom.Where(x => x.ClienteMetrics == reader["Cliente"].ToString()).Count() > 0)
                        {
                            var ooo = Lhom.Where(x => x.ClienteMetrics == reader["Cliente"].ToString()).ToList();

                            xf.Cliente = Lhom.Where(x => x.ClienteMetrics == reader["Cliente"].ToString() && xf.NombreOT.ToLower().Contains(x.Keyword.ToLower())).Select(p => p.ClientePrinergy).FirstOrDefault();
                            //dtDist.EstadoCliente = "No";
                        } 
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return xf;
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
        public string InsertSincronizacion(string OT, string NombreOT, string Cliente, string Estado, int Activo,string Obs, int Procedimiento)
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
                    cmd.Parameters.AddWithValue("@Obs",Obs);
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
        public bool ConsultaOTIngresada(string OT, int Procedimiento)
        {
            bool Resp = false;
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
                    cmd.Parameters.AddWithValue("@NombreGrupo", "");
                    cmd.Parameters.AddWithValue("@Paginas", "");
                    cmd.Parameters.AddWithValue("@Inicio", "");
                    cmd.Parameters.AddWithValue("@FormatoX", "");
                    cmd.Parameters.AddWithValue("@FormatoY", "");
                    cmd.Parameters.AddWithValue("@Formato", "");
                    cmd.Parameters.AddWithValue("@Papel", "");
                    cmd.Parameters.AddWithValue("@Usuario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 12);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Resp = Convert.ToBoolean(reader["respuesta"].ToString());
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
        public List<XMLFormato> ListaGruposPaginas(string OT, int Procedimiento)
        {
            List<XMLFormato> lista = new List<XMLFormato>();
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
                    cmd.Parameters.AddWithValue("@NombreGrupo", "");
                    cmd.Parameters.AddWithValue("@Paginas", "");
                    cmd.Parameters.AddWithValue("@Inicio", "");
                    cmd.Parameters.AddWithValue("@FormatoX", "");
                    cmd.Parameters.AddWithValue("@FormatoY", "");
                    cmd.Parameters.AddWithValue("@Formato", "");
                    cmd.Parameters.AddWithValue("@Papel", "");
                    cmd.Parameters.AddWithValue("@Usuario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 13);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        XMLFormato p = new XMLFormato();
                        p.Id = Convert.ToInt32(reader["Id"].ToString());
                        p.NombreGrupo = reader["Proceso"].ToString();
                        p.Paginas = Convert.ToInt32(reader["Paginas"].ToString());
                        p.Inicio = Convert.ToInt32(reader["Inicio"].ToString());
                        p.Formato = reader["X"].ToString() + "x"+ reader["Y"].ToString();
                        p.FormatoX = Convert.ToInt32(reader["X"].ToString());
                        p.FormatoY = Convert.ToInt32(reader["Y"].ToString());
                        p.Papel= reader["Papel"].ToString();

                        lista.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
           
            }
            conexion.CerrarConexion();
            return lista;
        }
        public int InsertEstructura(string OT,string NombreGrupo,int Paginas,int Inicio, int FormatoX,int FormatoY,string Papel,string version, int Procedimiento)
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
        public int InsertUltimaVersion(string OT, string NombreGrupo, int Paginas, int Inicio, int FormatoX, int FormatoY, string Papel, int Procedimiento)
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

        public List<APA_Clientes> ClientesMetrics()
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
                    cmd.Parameters.AddWithValue("@Procedimiento", 17);//reemplazar por 11 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        APA_Clientes dtDist = new APA_Clientes();

                        dtDist.Cliente = reader["Cliente"].ToString();

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

        public XMLFormato ConsultaOTManual(string OT)
        {
            XMLFormato xm = new XMLFormato();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prinergy_XMLMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Procedimiento", 18);//reemplazar por 11 al momento de entrar a produccion
                    cmd.CommandTimeout = 999999999;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        xm.NombreOT = reader["NombreOT"].ToString();
                        xm.Cliente = reader["cliente"].ToString();
                        xm.OT = reader["ot"].ToString();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return xm;
        }
    }
}