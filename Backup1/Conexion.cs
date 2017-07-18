using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Intranet
{
    public class Conexion
    {

        SqlConnection sqlconection = null;

        public SqlCommand AbrirConexion()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONPro"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionProduccion()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONProduccion"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionbd_gcqw()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONbd_gcqw"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionData_P2B()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONData_P2B"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionIntranet()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONIntranet"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        //Conexion A DataP2b Servidor 2000
        public SqlCommand AbrirConexionDataP2B2000()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionDespacho()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONDespacho"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionSV2008()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2008"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }
        public SqlCommand AbrirConexionDataP2B2000_DataP2B()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000_DataP2B"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionDataP2B2000_PARTES()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000_PARTES"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionSV2008Fin()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2008Fin700"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }


        //CONNECTIONSV2000_WebForm1 para borrar
        public SqlCommand AbrirConexionWebForm1()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000_WebForm1"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionINFORMEENC()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTION_DEPACHOENC"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }
        public SqlCommand AbrirConexionSV2000_Factura()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000_Factura"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionPresupuestoFalabella()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONPresupuestoFalabella"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public SqlCommand AbrirConexionSV2000_Addax()
        {
            try
            {
                string conectionstring =
                    ConfigurationManager.ConnectionStrings["CONNECTIONSV2000ADAX"].ToString();
                sqlconection = new SqlConnection(conectionstring);
                sqlconection.Open();

                SqlCommand cmd = sqlconection.CreateCommand();
                return cmd;

            }
            catch
            {
                return null;
            }
        }

        public void CerrarConexion()
        {
            sqlconection.Close();
        }


    }
}