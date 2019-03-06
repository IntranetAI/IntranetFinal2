using Intranet.ModuloCotizadorTransporte.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.ModuloCotizadorTransporte.Controller
{
    public class CotizadorTransporteController
    {
        public List<Ramales> ListRamales()
        {
            List<Ramales> lista = new List<Ramales>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNECTIONIntranet"].ToString());
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[View_CotizadorTransporte_Ramal]", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ramales r = new Ramales();
                    r.IdRamal= reader["id_ramal"].ToString();
                    r.Ramal = reader["Ramal"].ToString();
                    r.Ciudad = reader["Ciudad"].ToString();
                    r.Valor = Convert.ToInt32(reader["Valor"].ToString());
                    r.Opciones = "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:ModificaRamal(\"" + r.IdRamal + "\",\"" + r.Ramal + "\",\"" + r.Ciudad + "\",\"" + r.Valor + "\");' > Modificar </a> |" +
                        "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:EliminaRamal(\"" + r.IdRamal + "\",\"" + r.Ramal + "\",\"" + r.Ciudad + "\",\"" + r.Valor + "\");' > Eliminar </a>";
                     //"<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:alerta(\"" + 3 + "\");' > Modificar </a>"
                     lista.Add(r);
                }

            }catch(Exception ex)
            {

            }
            cmd.Dispose();
            conn.Close();
            return lista;
        }
        public int GuardarRamal(string NombreRamal,string Ciudad,int Valor,string Usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_Ramales";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ramal", 0);
                cmd.Parameters.AddWithValue("@NombreRamal", NombreRamal);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Valor", Valor);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public int UpdateRamal(int IdRamal,string NombreRamal, string Ciudad, int Valor, string Usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_Ramales";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ramal", IdRamal);
                cmd.Parameters.AddWithValue("@NombreRamal", NombreRamal);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Valor", Valor);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public int DeleteRamal(int IdRamal, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_Ramales";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ramal", IdRamal);
                cmd.Parameters.AddWithValue("@NombreRamal", "");
                cmd.Parameters.AddWithValue("@Ciudad", "");
                cmd.Parameters.AddWithValue("@Valor", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }

        /************** TARIFAS ******************/
        public List<Aereos> ListTarifasAeras()
        {
            List<Aereos> lista = new List<Aereos>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNECTIONIntranet"].ToString());
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[View_CotizadorTransporte_Aereo]", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Aereos r = new Aereos();
                    r.IdAereos = reader["id_Aereos"].ToString();
                    r.Ciudad = reader["Ciudad"].ToString();
                    r.de01a03 = Convert.ToInt32(reader["de01a03"].ToString());
                    r.de04a150 = Convert.ToInt32(reader["de04a150"].ToString());
                    r.de151a500 = Convert.ToInt32(reader["de151a500"].ToString());
                    r.de501aInfinito = Convert.ToInt32(reader["de500aInfinito"].ToString());
                    r.Opciones = "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:ModificaTarifa(\"" + r.IdAereos + "\",\"" + r.Ciudad + "\",\"" + r.de01a03 + "\",\"" + r.de04a150 + "\",\"" + r.de151a500 + "\",\"" + r.de501aInfinito + "\");' > Modificar </a> |"+
                        "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:EliminaTarifa(\"" + r.IdAereos + "\",\"" + r.Ciudad + "\",\"" + r.de01a03 + "\",\"" + r.de04a150 + "\",\"" + r.de151a500 + "\",\"" + r.de501aInfinito + "\");' > Eliminar </a>";
                    lista.Add(r);
                }

            }
            catch (Exception ex)
            {

            }
            cmd.Dispose();
            conn.Close();
            return lista;
        }
        public int GuardarTarifa(string Ciudad, int de01a03, int de04a150, int de151a500, int de501aInf, string Usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_TarifasAereos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Aereos", 0);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@De01a03", de01a03);
                cmd.Parameters.AddWithValue("@De04a150", de04a150);
                cmd.Parameters.AddWithValue("@De151a500", de151a500);
                cmd.Parameters.AddWithValue("@De501aInf", de501aInf);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public int UpdateTarifa(int IdAereo, string Ciudad, int de01a03, int de04a150, int de151a500, int de501aInf, string Usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_TarifasAereos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Aereos", IdAereo);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@De01a03", de01a03);
                cmd.Parameters.AddWithValue("@De04a150", de04a150);
                cmd.Parameters.AddWithValue("@De151a500", de151a500);
                cmd.Parameters.AddWithValue("@De501aInf", de501aInf);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public int DeleteTarifa(int IdAereo, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "CotizadorTransporte_TarifasAereos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Aereos", IdAereo);
                cmd.Parameters.AddWithValue("@Ciudad", "");
                cmd.Parameters.AddWithValue("@De01a03", 0);
                cmd.Parameters.AddWithValue("@De04a150", 0);
                cmd.Parameters.AddWithValue("@De151a500", 0);
                cmd.Parameters.AddWithValue("@De501aInf", 0);
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                // throw exc;
                return respuesta = 0;
            }
            conexion.CerrarConexion();
            return respuesta;
        }




        /************** TERRESTRES ******************/
        public List<Terrestres> ListTerrestres()
        {
            List<Terrestres> lista = new List<Terrestres>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNECTIONIntranet"].ToString());
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[View_CotizadorTransporte_Terrestre]", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Terrestres r = new Terrestres();
                    r.IdTerrestre = Convert.ToInt32( reader["id_Terrestre"].ToString());
                    r.Ciudad = reader["Ciudad"].ToString();
                    r.De01a05 = Convert.ToInt32(reader["de01a05"].ToString());
                    r.De06a10 = Convert.ToInt32(reader["de06a10"].ToString());
                    r.De11a20 = Convert.ToInt32(reader["de11a20"].ToString());
                    r.De21a30 = Convert.ToInt32(reader["de21a30"].ToString());
                    r.De31a40 = Convert.ToInt32(reader["de31a40"].ToString());
                    r.De41a50 = Convert.ToInt32(reader["de41a50"].ToString());
                    r.De51a60 = Convert.ToInt32(reader["de51a60"].ToString());
                    r.De61a70 = Convert.ToInt32(reader["de61a70"].ToString());
                    r.De71a80 = Convert.ToInt32(reader["de71a80"].ToString());
                    r.De81a90 = Convert.ToInt32(reader["de81a90"].ToString());
                    r.De91a100 = Convert.ToInt32(reader["de91a100"].ToString());
                    r.De101a1000 = Convert.ToInt32(reader["de101a1000"].ToString());
                    r.De1001a4000 = Convert.ToInt32(reader["de1001a4000"].ToString());
                    r.De4001a7000 = Convert.ToInt32(reader["de4001a7000"].ToString());
                    r.De7001aInfinito = Convert.ToInt32(reader["de7001aInfinito"].ToString());
                    r.MT3 = reader["mt3"].ToString();
                    r.Salidas = reader["Salidas"].ToString();
                    r.Opciones = "mod | Del";
                    //r.Opciones = "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:ModificaTarifa(\"" + r.IdAereos + "\",\"" + r.Ciudad + "\",\"" + r.de01a03 + "\",\"" + r.de04a150 + "\",\"" + r.de151a500 + "\",\"" + r.de501aInfinito + "\");' > Modificar </a> |" +
                      //  "<a style = 'Color:Blue;text-decoration:none;cursor:pointer;' href = 'javascript:EliminaTarifa(\"" + r.IdAereos + "\",\"" + r.Ciudad + "\",\"" + r.de01a03 + "\",\"" + r.de04a150 + "\",\"" + r.de151a500 + "\",\"" + r.de501aInfinito + "\");' > Eliminar </a>";
                    lista.Add(r);
                }

            }
            catch (Exception ex)
            {

            }
            cmd.Dispose();
            conn.Close();
            return lista;
        }





        /************* CALCULOS FLETES ***************/

    }
}