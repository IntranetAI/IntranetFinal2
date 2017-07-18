using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Intranet.ModuloAdministracion.Model;
using System.Text;

namespace Intranet.ModuloAdministracion.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridRF.DataSource = Listar();
                RadGridRF.DataBind();
            }
        }

        public List<Consumo> Listar()
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionWebForm1();
            if (cmd != null)
            {
                cmd.CommandText = "select [letra],[codigo],[fecha],[nombre],[cantidad],[unidad_cantidad_solucio],[Bodega  ],[precio_solucion],[lote ],[ubicación] from [Generar_juanito]";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Consumo txt = new Consumo();
                    txt.Lote = reader["letra"].ToString();
                    txt.CodItem = reader["codigo"].ToString();
                    DateTime fecha = Convert.ToDateTime(reader["fecha"].ToString());
                    txt.NombrePapel = fecha.ToString("dd/MM/yyyy");
                    txt.Gramage = reader["nombre"].ToString();
                    txt.Largo = reader["unidad_cantidad_solucio"].ToString()+"  ";
                    txt.Cons_Bobina = reader["Bodega  "].ToString();
                    if (reader["precio_solucion"].ToString() != "0000000000,00000")
                    {
                        string ceros = "000000000000";
                        double Valor = Convert.ToDouble(reader["precio_solucion"].ToString());//Convert.ToDouble(reader["cantidad"].ToString()) * Convert.ToDouble(reader["precio"].ToString());
                        //string cant = reader["cantidad"].ToString(); string precio = Convert.ToDouble(reader["precio"].ToString()).ToString();
                        string[] ar = Valor.ToString("N3").Split('.');
                        if (ar.Length == 2)
                        {
                            string solucion = Valor.ToString("N3").Replace(",", string.Empty);
                            txt.CostUni = ceros.Substring(0, ceros.Length - solucion.Length) + solucion.ToString().Replace(".",",");
                        }
                        else if(ar.Length==1)
                        {
                            string solucion = Valor.ToString().Replace(".", string.Empty) + ",000";
                            txt.CostUni = ceros.Substring(0, ceros.Length - solucion.Length) + solucion.ToString().Replace(".", ",");
                        }

                        double valor2 = Convert.ToDouble(reader["cantidad"].ToString());
                        string[] ar2 = valor2.ToString("N3").Split('.');
                        if (ar2.Length == 2)
                        {
                            string solucion = valor2.ToString("N3").Replace(",", string.Empty);
                            txt.Cons_Pliego = ceros.Substring(0, ceros.Length - solucion.Length) + solucion.ToString().Replace(".", ",");
                        }
                        else if (ar2.Length == 1)
                        {
                            string solucion = valor2.ToString().Replace(".", string.Empty) + ",000";
                            txt.Cons_Pliego = ceros.Substring(0, ceros.Length - solucion.Length) + solucion.ToString().Replace(".", ",");
                        }
                    }
                    else
                    {
                        txt.CostUni = "00000000,000";
                    }
                    string lote = "00000";
                    string lotesql = reader["lote "].ToString();
                    txt.Costtot = lote.Substring(0,lote.Length-lotesql.Length)+lotesql+reader["ubicación"].ToString();
                    lista.Add(txt);
                }
                con.CerrarConexion();

            }
            return lista;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            btnExportCSV_Click(Listar());
        }

        protected void btnExportCSV_Click(List<Consumo> lista)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=Pajaro.txt");
            Response.Charset = "";

            StringBuilder sb = new StringBuilder();
            //string nCuenta = "000000000";
            int contador = 0;
            foreach (Consumo con in lista)
            {
                if (contador == 0)
                {
                    sb.Append("C000004001"); 
                    sb.Append("\r\n");
                    contador++;
                }
                string cuatro = "    ";
                string once = "           ";
                string veinte = "                    ";
                string cuarenta = "                                           ";

                sb.Append(con.Lote+once.Substring(0, once.Length - con.Lote.Length));
                sb.Append(con.CodItem);
                sb.Append(con.NombrePapel);


                sb.Append(veinte.Substring(0,veinte.Length-con.Gramage.Length)+ con.Gramage);
                
                sb.Append(con.Cons_Pliego);
                sb.Append(con.Largo);
                //sb.Append(con.Cons_Pliego+cuatro.Substring(0, cuatro.Length - con.Cons_Pliego.Length));
                sb.Append(con.Cons_Bobina+ veinte.Substring(0,veinte.Length-con.Cons_Bobina.Length));
                sb.Append(con.CostUni+cuarenta);
                sb.Append(con.Costtot);
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();

        }
    }
}