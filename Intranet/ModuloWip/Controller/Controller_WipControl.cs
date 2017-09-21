using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloWip.Model;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using Intranet.ModuloWip.View;
using System.Text.RegularExpressions;

namespace Intranet.ModuloWip.Controller
{
    public class Controller_WipControl
    {
        #region sincambios
        public List<Model_Wip_Control> ListMaquinas(string Maquina)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_ListMaquina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Maquina);
                cmd.Parameters.AddWithValue("@proceso",0);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control cont = new Model_Wip_Control();
                    cont.OT = reader["Maquina"].ToString();
                    
                    lista.Add(cont);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_Wip_Control> ListPliegosOT(string OT)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_ListPliegoOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control cont = new Model_Wip_Control();
                    cont.Pliego = reader["Pliegos"].ToString().Trim();
                    cont.Forma = reader["Forma"].ToString();
                    cont.Tarea = reader["Tarea"].ToString();

                    lista.Add(cont);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_Wip_Control> ListPliegosOT2(string OT)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_PliegoList";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();
                string Pliegos = "";
                while (reader.Read())
                {
                    Model_Wip_Control cont = new Model_Wip_Control();
                    cont.Forma = reader["tiraje"].ToString();
                    cont.Prox_Proceso = reader["Pliegos"].ToString();
                    Pliegos = reader["Pliegos"].ToString();
                    lista.Add(cont);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public int MaxRegistroWip()
        {
            int registro = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Wip_List_MaxRegistro";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string numero = reader["ID_Control"].ToString();
                        numero = numero.Substring(3, numero.Length - 3);
                        registro = Convert.ToInt32(numero.Substring(1, numero.Length - 1));
                    }
                    else
                    {
                        registro = 0;
                    }
                }
                catch
                {

                }
            }
            con.CerrarConexion();
            return registro;
        }

        public List<Model_Wip_Control> List_PliegosMultiples(string Codigo)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_List_Pallet_PliegMult";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.OT = reader["OT"].ToString().Trim();
                    wip.NombreOT = reader["NombreOT"].ToString().Trim();
                    wip.Pliego = reader["Pliego"].ToString().Trim();
                    wip.Tarea = reader["Tarea"].ToString().Trim();
                    wip.Forma = reader["Forma"].ToString().Trim();
                    wip.Maquina = reader["Maquina_Origen"].ToString().Trim();
                    wip.TotalTiraje = Convert.ToInt32(reader["Total_Tiraje"].ToString());
                    wip.Pliegos_Impresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString().Trim());
                    wip.TipoPallet = reader["TipoPallet"].ToString();
                    wip.Peso_pallet = Convert.ToDouble(reader["Peso_Pallet"].ToString());

                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool Wip_ModificarPallet(Model_Wip_Control wip)
        {
            Boolean Respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_InsertMov_pallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ControlWip", wip.ID_Control);
                cmd.Parameters.AddWithValue("",wip.Maquina);
                cmd.Parameters.AddWithValue("",wip.NombreOT);
                cmd.Parameters.AddWithValue("",wip.OT);
                cmd.Parameters.AddWithValue("",wip.Peso_pallet);
                cmd.Parameters.AddWithValue("",wip.Pliegos_Impresos);
                cmd.Parameters.AddWithValue("",wip.Posicion);
                cmd.Parameters.AddWithValue("",wip.Ubicacion);
                cmd.Parameters.AddWithValue("",wip.Usuario);
                cmd.Parameters.AddWithValue("",wip.Estado_Pallet);
                cmd.Parameters.AddWithValue("",wip.Fecha_Creacion);
                cmd.Parameters.AddWithValue("",wip.Fecha_Modificacion);
                cmd.Parameters.AddWithValue("",wip.Forma);
                Respuesta = true;
            }
            con.CerrarConexion();
            return Respuesta;
        }

        public bool Agregar_Pallet_Wip(Model_Wip_Control wip, string PliegoMetrics)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_insert_pallet_Control";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Control", wip.ID_Control);
                cmd.Parameters.AddWithValue("@OT", wip.OT);
                cmd.Parameters.AddWithValue("@NombreOT", wip.NombreOT);
                cmd.Parameters.AddWithValue("@Pliego", wip.Pliego);
                cmd.Parameters.AddWithValue("@Maquina", wip.Maquina);
                cmd.Parameters.AddWithValue("@Total", wip.TotalTiraje);
                cmd.Parameters.AddWithValue("@PliegosImp", wip.Pliegos_Impresos);
                cmd.Parameters.AddWithValue("@Peso", wip.Peso_pallet);
                cmd.Parameters.AddWithValue("@Usuario", wip.Usuario);
                cmd.Parameters.AddWithValue("@IDTipoPallet", wip.IDTipoPallet);
                cmd.Parameters.AddWithValue("@TipoPallet", wip.TipoPallet);
                cmd.Parameters.AddWithValue("@Tarea", wip.Tarea);
                cmd.Parameters.AddWithValue("@Forma", wip.Forma);
                cmd.Parameters.AddWithValue("@Ubicacion", wip.Ubicacion);
                cmd.Parameters.AddWithValue("@PliegoMetrics", PliegoMetrics);
                cmd.Parameters.AddWithValue("@Procedimiento", 1);
                
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public Model_Wip_Control BuscarWip_ControlPorCodigo(string Codigo)
        {
            Model_Wip_Control wip = new Model_Wip_Control();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!= null)
            {
                cmd.CommandText = "Wip_Buscar_ControlPorCodigo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.Maquina = reader["Maquina_Origen"].ToString();
                    wip.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    wip.Estado_Pallet = Convert.ToInt32(reader["Estado_Pallet"].ToString());
                    wip.Forma = reader["Forma"].ToString();
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.OT = reader["OT"].ToString();
                    if (reader["Peso_pallet"].ToString() != "")
                    {
                        wip.Peso_pallet = Convert.ToDouble(reader["Peso_pallet"].ToString());
                    }
                    if (reader["Pliegos_Impresos"].ToString() != "")
                    {
                        wip.Pliegos_Impresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString());
                    }
                    wip.Pliego = reader["Pliego"].ToString();
                    wip.Tarea = reader["Tarea"].ToString();
                    wip.TotalTiraje = Convert.ToInt32(reader["Total_Tiraje"].ToString());
                    wip.Usuario = reader["Usuario_Creador"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    string TipPallet = reader["TipoPallet"].ToString();
                    if (TipPallet != "Pliego Normal")
                    {
                        wip.TipoPallet = "ESP";
                    }
                    else
                    {
                        wip.TipoPallet = "";
                    }
                }
            }
            con.CerrarConexion();
            return wip;
        }

        public List<Model_Wip_Control> BuscarWip_ControlPorCodigo2(string Codigo)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Buscar_ControlPorCodigo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.Maquina = reader["Maquina_Origen"].ToString();
                    wip.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    wip.Estado_Pallet = Convert.ToInt32(reader["Estado_Pallet"].ToString());
                    wip.Forma = reader["Forma"].ToString();
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.OT = reader["OT"].ToString();
                    if (reader["Peso_pallet"].ToString() != "")
                    {
                        wip.Peso_pallet = Convert.ToDouble(reader["Peso_pallet"].ToString());
                    }
                    if (reader["Pliegos_Impresos"].ToString() != "")
                    {
                        wip.Pliegos_Impresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString());
                    }
                    wip.Pliego = reader["Pliego"].ToString();
                    wip.Tarea = reader["Tarea"].ToString();
                    wip.TotalTiraje = Convert.ToInt32(reader["Total_Tiraje"].ToString());
                    wip.Usuario = reader["Usuario_Creador"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    string TipPallet = reader["TipoPallet"].ToString();
                    if (TipPallet != "Pliego Normal")
                    {
                        wip.TipoPallet = "ESP";
                    }
                    else
                    {
                        wip.TipoPallet = "";
                    }
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Model_Wip_Control BuscarWip_BuscarPallet(string Codigo)
        {
            Model_Wip_Control wip = new Model_Wip_Control();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_BuscarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wip.ID_Control = reader["@ID_Control"].ToString();
                    wip.Estado_Pallet = Convert.ToInt32(reader["@Estado_Pallet"].ToString());
                    wip.Fecha_Creacion = Convert.ToDateTime(reader["@Fecha_Creacion"].ToString());
                    wip.Forma = reader["@Forma"].ToString();
                    wip.Maquina = reader["@Maquina"].ToString();
                    wip.NombreOT = reader["@NombreOT"].ToString();
                    wip.OT = reader["@OT"].ToString();
                    wip.Peso_pallet = Convert.ToDouble(reader["@Peso_pallet"].ToString());
                    wip.Pliego = reader["@Pliego"].ToString();
                    wip.Pliegos_Impresos = Convert.ToInt32(reader["@Pliegos_Impresos"].ToString());
                    wip.Posicion = reader["Posicion"].ToString();
                    wip.Tarea = reader["Tarea"].ToString();
                    wip.TotalTiraje = Convert.ToInt32(reader["TotalTiraje"].ToString());
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Usuario = reader["Usuario"].ToString();

                }
            }
            con.CerrarConexion();
            return wip;
        }

        public List<Model_Wip_Control> listBodegaWip()
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_List_Bodegas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_Wip_Control> listEstadoPalletWip()
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_ListarEstadoPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.Ubicacion = reader["Nombre_Estado"].ToString();
                    wip.Estado_Pallet = Convert.ToInt32(reader["Status_Wip"].ToString());
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_Wip_Control> listNumRack_Bodega(string Bodega)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_List_NumeroRack";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega", Bodega);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.Ubicacion = reader["NRack"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string UbicacionRack_Libre(string Bodega, int Rack, string Codigo,int Piso)
        {
            double algo=0;
            int Ocupadas = 0;
            int libres = 0;
            int contadorg = 0;
            int total = 0;
            string color = "";
            string RackLibre = "<div style='border:1px solid black;padding:20px;'><table style='width: 100%;' border='1'>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "wip_Ubicaciones_RackLibre";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.Parameters.AddWithValue("@NumRack", Rack);
                cmd.Parameters.AddWithValue("@Piso", Piso);
                SqlDataReader reader = cmd.ExecuteReader();

                int nivelNew = 0;
                int nivelOld = 0;
                int count = 1;
                while(reader.Read())
                {
                    total = Convert.ToInt32(reader["Niveles"].ToString());
                 //   int total2 = total + 1;
                    nivelNew = Convert.ToInt32(reader["Nivel"].ToString());
                    
                    if (count == 1)
                    {

                        RackLibre = RackLibre + "<tr>";
                        //nivelOld = nivelNew;



                        string RadioVisible = "";
                        string Pallet = "src='../../Images/Pallet.png'";
                        string Ubicacion = "title='Ubicacion Libre'";
                        if (Convert.ToInt32(reader["Estado"].ToString()) != 0)
                        {
                            //RadioVisible = "disabled='disabled'";
                            Pallet = "src='../../Images/Pallet_Ocupado.png'";
                            Ubicacion = "title='Ubicacion Ocupada'";
                            color = "bgcolor='#FF1A00'";
                            Ocupadas = Ocupadas + 1;
                        }
                        else
                        {
                            color = "bgcolor='#00FF00'";
                            libres = libres + 1;
                        }
                        string td4 = "";
                        if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                        {
                            td4 = "<td colspan='4'></td>";
                        }
                        RackLibre = RackLibre + td4 + "<td style='width: 60px;'" + color + "><input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " /><label style='font-size:11px;'>" + reader["Nombre_Rack"].ToString() + "</label></td>";
                        count++;
                        contadorg = contadorg + 1;
                    }
                    else
                    {
                        if (count == total)
                        {
                            //if (count != 0)
                            //{
                            string RadioVisible = "";
                            string Pallet = "src='../../Images/Pallet.png'";
                            string Ubicacion = "title='Ubicacion Libre'";
                            if (Convert.ToInt32(reader["Estado"].ToString()) != 0)
                            {
                                //RadioVisible = "disabled='disabled'";
                                Pallet = "src='../../Images/Pallet_Ocupado.png'";
                                Ubicacion = "title='Ubicacion Ocupada'";

                                color = "bgcolor='#FF1A00'";
                                Ocupadas = Ocupadas + 1;
                            }
                            else
                            {
                                color = "bgcolor='#00FF00'";
                                libres = libres + 1;
                            }
                            string td4 = "";
                            if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                            {
                                td4 = "<td colspan='4'></td>";
                            }
                            RackLibre = RackLibre + td4 + "<td style='width: 60px;'" + color + "><input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " /><label style='font-size:11px;'>" + reader["Nombre_Rack"].ToString() + "</label></td>";
                            
                                RackLibre = RackLibre + "</tr>";
                            //}
                            //RackLibre = RackLibre + "<tr>";
                            ////  nivelOld = nivelNew;
                                count = 1;
                                contadorg = contadorg + 1;
                        }
                        else
                        {
                            //RackLibre = RackLibre + "<tr>";
                            //  nivelOld = nivelNew;


                            string RadioVisible = "";
                            string Pallet = "src='../../Images/Pallet.png'";
                            string Ubicacion = "title='Ubicacion Libre'";
                            if (Convert.ToInt32(reader["Estado"].ToString()) != 0)
                            {
                                //RadioVisible = "disabled='disabled'";
                                Pallet = "src='../../Images/Pallet_Ocupado.png'";
                                Ubicacion = "title='Ubicacion Ocupada'";

                                color = "bgcolor='#FF1A00'";
                                Ocupadas = Ocupadas + 1;
                            }
                            else
                            {
                                color = "bgcolor='#00FF00'";
                                libres = libres + 1;
                            }
                            string td4 = "";
                            if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                            {
                                td4 = "<td colspan='4'></td>";
                            }
                            RackLibre = RackLibre + td4+"<td style='width: 60px;'" + color + "><input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " /><label style='font-size:11px;'>" + reader["Nombre_Rack"].ToString() + "</label></td>";
                            count++;
                            contadorg = contadorg + 1;
                        }
                    }
                }
            }
            if (libres == 0 || contadorg == 0)
            {
                algo = 0;
            }
            else
            {
                algo = ((libres * 100 / contadorg * 100));
            }
            
            if (algo == 0)
            {
                RackLibre = RackLibre + "</tr></table> <div align='center' >Piso " + Piso + " ( Disponibilidad:  0%, Posiciones Libres: " + libres.ToString() + ". )</div> </div>  <input id='Text1' name='Text1'  type='text' value='" + Codigo + "' style='visibility: hidden;'  />";
            }
            else
            {
                string algo2 = algo.ToString().Substring(0, algo.ToString().Length - 2);
                RackLibre = RackLibre + "</tr></table> <div align='center' >Piso " + Piso + " ( Disponibilidad: " + algo2.ToString() + "%, Posiciones Libres: " + libres.ToString() + ". )</div> </div>  <input id='Text1' name='Text1'  type='text' value='" + Codigo + "' style='visibility: hidden;'  />";
            }
            con.CerrarConexion();
            return RackLibre;
        }

        public bool AsignarUbicacionPallet(string Codigo, string Ubicacion, string Usuario)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Update_AsignarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Posicion", Ubicacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);

                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Model_Wip_Control> listPliegosWip(string OT)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_List_PliegosOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT",OT);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.Ubicacion = reader["Pliego"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public List<Model_Wip_Control> ListOTUbi_Buscar(Model_Wip_Control wipFiltro)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Informe_BuscarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", wipFiltro.OT);
                cmd.Parameters.AddWithValue("@Pliego", wipFiltro.Pliego);
                cmd.Parameters.AddWithValue("@Ubicacion", wipFiltro.Ubicacion);
                cmd.Parameters.AddWithValue("@FechaInicio", wipFiltro.Forma);//Fecha Inicio
                cmd.Parameters.AddWithValue("@FechaTermino", wipFiltro.Tarea);//Fecha Termino
                cmd.Parameters.AddWithValue("@EstadoPallet", wipFiltro.Estado_Pallet);
                cmd.Parameters.AddWithValue("@Procedimiento", wipFiltro.IDTipoPallet);
                cmd.CommandTimeout = 100000;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.OT = reader["OT"].ToString();
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.Pliego = reader["Pliegos"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Pliegos_Impresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString());
                    wip.Peso_pallet = Convert.ToDouble(reader["Peso_Pallet"].ToString());
                    wip.Fecha_Modificacion = Convert.ToDateTime(reader["Fecha"].ToString());
                    wip.Estado_Pallet2 = reader["Estado_Pallet"].ToString();
                    wip.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + wip.OT + "\",\"" + wip.ID_Control + "\")'>Ver Más</a>";
                    
                    lista.Add(wip);
                }
                int contador = 0;
                string OrdenOTNEW = "";
                string OrdenOTOld = "";
                foreach (Model_Wip_Control wp in lista)
                {
                    contador++;
                    OrdenOTNEW = wp.OT;
                    int contadorG = lista.Where(o => o.OT == OrdenOTNEW).Count();
                    if (OrdenOTNEW != OrdenOTOld)
                    {
                        contador = 1;
                    }

                    wp.Maquina_Proceso = contador + "/" + contadorG;
                    OrdenOTOld = OrdenOTNEW;
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string BuscaPliegos(string OT, string Pliego, int Procedimiento)
        {
           string RackLibre = "0";
           Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    int salida = Convert.ToInt32(Pliego);
                    cmd.CommandText = "[WIP_TirajePlieg]";
                }
                catch
                {
                    cmd.CommandText = "[WIP_TirajePliego]";
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    try
                    {
                        RackLibre = Convert.ToInt32(Convert.ToDouble(reader["PRN_ORD_QTY"].ToString())).ToString();
                    }
                    catch
                    {
                        RackLibre = "0";
                    }
                }
            }
            con.CerrarConexion();
            return RackLibre;
        }

        public string Historial_Pallet(string Codigo)
        {
            string Historial = "<table cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px;width:100%;'>"+
                                  "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>"+
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Código Pallet</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Fecha</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Movimiento</td>" +
                                    
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Posicion</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Usuario</td>" +
                                  "</tr>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_BuscarHistorial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo",Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Historial = Historial + "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;'>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["ID_Control"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + Convert.ToDateTime(reader["Fecha_Modificacion"].ToString()).ToString("dd-MM-yyyy HH:mm:ss") + "</td>";
                   
                    string Maquina = "";
                    if (Convert.ToInt32(reader["Estado_Pallet"].ToString()) == 8)
                    {
                        Maquina = BuscarMaquina(Codigo);
                    }
                    string Movimiento = "";
                    if ((Convert.ToInt32(reader["Estado_Pallet"].ToString()) == 8) || (Convert.ToInt32(reader["Estado_Pallet"].ToString()) == 2))
                    {
                        Movimiento = reader["Estado"].ToString()+ " - " +reader["Ubicacion"].ToString(); 
                    }
                    else
                    {
                        Movimiento = reader["Estado"].ToString();
                    }

                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + Movimiento + "</td>";
                    string posicion = "";
                    if (reader["Posicion"].ToString() == "")
                    {
                        posicion = "Sin Asignar";
                    }
                    else
                    {
                        posicion = reader["Posicion"].ToString();
                    }
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + posicion + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["Usuario"].ToString() + "</td>";
                    Historial = Historial + "</tr>";
                }

                Historial = Historial + "</table>";
            }
            con.CerrarConexion();
            return Historial;
        }

        public string Historial_PalletDetalle(string Codigo)
        {
            string Historial = "<table cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px;width:100%;'>" +
                                  "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Código Pallet</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>N° OT</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Nombre OT</td>" +

                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Pliego</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Cant. Pliegos</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Peso Pallet</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Tipo Pallet</td>" +
                                  "</tr>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_BuscarHistorialDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Historial = Historial + "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;'>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["ID_Control"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["OT"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["NombreOT"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + reader["Pliego"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + reader["Pliegos_Impresos"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + reader["Peso_Pallet"].ToString() + "</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + reader["TipoPallet"].ToString() + "</td>";
                    Historial = Historial + "</tr>";
                }

                Historial = Historial + "</table>";
            }
            con.CerrarConexion();
            return Historial;
        }

        public List<Model_Wip_Control> BusquedaPorFolioyOT(string cod_Pallet, string OT)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Wip_Reimpresion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_Pallet);
                cmd.Parameters.AddWithValue("@OT", OT);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Model_Wip_Control wp = new Model_Wip_Control();
                    wp.ID_Control = reader["ID_Control"].ToString();
                    wp.OT = reader["OT"].ToString();
                    wp.NombreOT = reader["NombreOT"].ToString();
                    wp.Pliego = reader["Pliego"].ToString();
                    wp.Pliegos_Impresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString());
                    wp.Peso_pallet = Convert.ToDouble(reader["Peso_pallet"].ToString());
                    wp.Maquina = reader["Maquina_Origen"].ToString();
                    wp.Usuario = reader["Usuario_Creador"].ToString();
                    wp.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    wp.Posicion = reader["Posicion"].ToString();
                    wp.Ubicacion = reader["Ubicacion"].ToString();
                    int estado = Convert.ToInt32(reader["Estado_Pallet"].ToString());
                    switch (estado)
                    {
                        case 1: wp.Estado_Pallet2 = "Creado"; break;
                        case 2: wp.Estado_Pallet2 = "Almacenado WIP"; break;
                        case 3: wp.Estado_Pallet2 = "Almacenado WIP"; break;
                        case 4: wp.Estado_Pallet2 = "Entregado Encuadernación"; break;
                        case 5: wp.Estado_Pallet2 = "Enviado a Ser. Externos"; break;
                        case 6: wp.Estado_Pallet2 = "En transito"; break;
                    }
                    wp.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + wp.OT + "\",\"" + wp.ID_Control + "\")'>Ver Más</a>";
                    lista.Add(wp);
                    //respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
                int contador = 0;
                string OrdenOTNEW = "";
                string OrdenOTOld = "";
                foreach (Model_Wip_Control wp in lista)
                {
                    contador++;
                    OrdenOTNEW = wp.OT;
                    int contadorG = lista.Where(o => o.OT == OrdenOTNEW).Count();
                    if (OrdenOTNEW != OrdenOTOld)
                    {
                        contador = 1;
                    }

                    wp.Maquina_Proceso = contador + "/" + contadorG;
                    OrdenOTOld = OrdenOTNEW;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return lista;
        }

        public int TipodePallet(string Codigo_Pallet)
        {
            int Respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "WIP_PalletTipo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDControl", Codigo_Pallet);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Respuesta = Convert.ToInt32(reader["TipPallet"].ToString());
                }
            }
            con.CerrarConexion();
            return Respuesta;
        }

        public int CantidadNivelRack(string Ubicacion)
        {
            int Respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_NNivelRack";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Respuesta = Convert.ToInt32(reader["Nivel"].ToString());
                }
            }
            con.CerrarConexion();
            return Respuesta;
        }

        public bool EliminarPallet(string Codigo, string Usuario, string Observacion)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_AnulEtiqueta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigos",Codigo);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return respuesta;
            
        }

        public string BuscarMaquina(string CodigoMaquina)
        {
            string Maquina = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_BusMaquina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", CodigoMaquina);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Maquina = reader["Maquina"].ToString();
                }
            }
            con.CerrarConexion();
            return Maquina;
        
        }

        public string CrearEtiqueta(string Codigos)
        {
            string Respuesta = "";
            string[] str = Codigos.Split(',');
            int contador = 0;
            for (int i = 0; i < str.Length; i++ )
            {
                Respuesta = Respuesta+ GeneCodMas(str[i], contador);
                contador++;
            }
            int a = Respuesta.Length;
            return Respuesta;
        }

        public string GeneCodMas(string Codigo, int contador)
        {
            string Etiqueta = "";
            Model_Wip_Control wip = BuscarWip_ControlPorCodigo(Codigo);
            
            if (wip.ID_Control != "")
            {
                EtiquetaMasiva pagina = new EtiquetaMasiva();
                string eti = pagina.generadorCodigo(wip.ID_Control, contador);
                Etiqueta = "<div align='center' style='font-size:xx-large;font-weight:bold'>Control Wip<br /><br /></div>" +
                           "</div>" +
                           "<table style='width:100%;' border='1px'>" +
                           "<tr>" +
                               "<td class='style2' align='center' rowspan='2' style='padding:20px;'>" +
                                    "<img alt='' src='../../Images/quadlogo.PNG'  />" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>OT" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Nombre OT" +
                                "</td>" +
                            "</tr><tr>" +
                                "<td align='center' style='font-size:xx-large;font-weight:bold'>" + wip.OT.ToUpper() +
                                "</td>" +
                                "<td align='center' style='font-size:xx-large;font-weight:bold'>" + wip.NombreOT +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2' align='center' style='font-size:x-large;font-weight:bold'>Fecha Creación" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Tiraje" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Pliego" +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2' align='center' style='font-size:x-large;font-weight:bold'>" + wip.Fecha_Creacion.ToString("dd/MM/yyyy HH:mm:ss") +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.TotalTiraje.ToString("N0").Replace(",", ".") +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.Pliego +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2'>" +
                                    "&nbsp;</td>" +
                                "<td align='center'  style='font-size:x-large;font-weight:bold'>Tarea" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Forma" +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2'>" +
                                    "&nbsp;</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.Tarea +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.Forma +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2' align='center'>" +
                                    "&nbsp;</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Pliegos Impresos" +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Peso Pallet" +
                                "</td>" +
                            "</tr><tr>" +
                                "<td class='style2' align='center'>" +
                                    "&nbsp;</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.Pliegos_Impresos.ToString("N0").Replace(",", ".") +
                                "</td>" +
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" + wip.Peso_pallet.ToString() +
                                "</td>"+
                            "</tr><tr>"+
                                "<td class='style2'  align='center' style='font-size:x-large;font-weight:bold'>Operario" +
                                "</td>"+
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Maquina" +
                                "</td>"+
                                "<td align='center' style='font-size:x-large;font-weight:bold'>Destino" +
                                "</td>"+
                            "</tr><tr>"+
                                "<td align='center' style='font-size:x-large;font-weight:bold'>" +wip.Usuario+
                                "</td><td align='center' style='font-size:x-large;font-weight:bold'>" +wip.Maquina+
                                "</td><td align='center' style='font-size:x-large;font-weight:bold'>" +wip.Ubicacion+
                                "</td></tr><tr>"+
                                "<td class='style2' align='center'>&nbsp;</td>" +
                                "<td align='center' >&nbsp;</td>" +
                                "<td align='center' >&nbsp;</td>" +
                            "</tr><tr><td align='center' colspan='3'><br />" +
                                    "<img src='" + eti + "' alt=''/><br />" + wip.ID_Control + "<br /><br />" +
                               "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td class='style2' align='center' >&nbsp;</td>" +
                                "<td align='center' >&nbsp;</td>" +
                                "<td align='center' >&nbsp;</td>" +
                            "</tr>" +
                        "</table><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />";
            }
            int leng = Etiqueta.Length;
            return Etiqueta;
        }

        public bool Devolucion(string query)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;

        }

        public List<Model_Wip_Control> ListUbicaciones(string Bodega)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Ubicaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega",Bodega);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wc = new Model_Wip_Control();
                    wc.Maquina = reader["Nombre_Rack"].ToString();
                    lista.Add(wc);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string UbicacionRack_Libre2(string Bodega, int Rack, string Codigo, int Piso)
        {
            List<Model_Wip_Control> lista = listaCodigoxUbicacion(Bodega);
            double algo = 0;
            int Ocupadas = 0;
            int libres = 0;
            int contadorg = 0;
            int total = 0;
            string color = "";
            string RackLibre = "<div style='border:1px solid black;padding:10px;'><table border='1'>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "wip_Ubicaciones_RackLibre";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.Parameters.AddWithValue("@NumRack", Rack);
                cmd.Parameters.AddWithValue("@Piso", Piso);
                SqlDataReader reader = cmd.ExecuteReader();

                int nivelNew = 0;
                int nivelOld = 0;
                int count = 1;
                
                while (reader.Read())
                {
                    total = Convert.ToInt32(reader["Niveles"].ToString());
                    //   int total2 = total + 1;
                    nivelNew = Convert.ToInt32(reader["Nivel"].ToString());

                    if (count == 1)
                    {

                        RackLibre = RackLibre + "<tr>";
                        
                        string RadioVisible = "";
                        string Pallet = "src='../../Images/Pallet.png'";
                        string Ubicacion = "title='Ubicacion Libre'";
                        string td4 = "";
                        if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                        {
                            td4 = "<td colspan='4'></td>";
                        }
                        string CodigoUbicacion1 = "";
                        int contador1 = 0;
                        foreach (Model_Wip_Control wp in lista.Where(o => o.Posicion == reader["Nombre_Rack"].ToString()))
                        {
                            if (contador1 % 2 == 0)
                            {
                                CodigoUbicacion1 = CodigoUbicacion1 + "OT: " + wp.OT + " Pliego: " + wp.Pliego + " Codigo: " + wp.ID_Control + "   ";
                            }
                            else
                            {
                                CodigoUbicacion1 = CodigoUbicacion1 + "OT: " + wp.OT + " Pliego: " + wp.Pliego + " Codigo: " + wp.ID_Control + " \n";
                            }
                            contador1++;
                        }
                        if (CodigoUbicacion1 != "")
                        {
                            //RadioVisible = "disabled='disabled'";
                            Pallet = "src='../../Images/Pallet_Ocupado.png'";
                            Ubicacion = "title='Ubicacion Ocupada'";
                            color = "bgcolor='#FF1A00'";
                            Ocupadas = Ocupadas + contador1;
                        }
                        else
                        {
                            color = "bgcolor='#00FF00'";
                            libres = libres + 1;
                        }
                        RackLibre = RackLibre + td4 + "<td style='width: 100px;vertical-align:top;'" + color + "><div align='center' style='font-size:13px;'>" + reader["Nombre_Rack"].ToString() + "</div><a style='font-size:11px;' title='" + CodigoUbicacion1 + "'>" + contador1.ToString("N0").Replace(",", ".") + " Pallet</a></td>";
                        //<input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " />
                        count++;
                        contadorg = contadorg + 1;
                    }
                    else
                    {
                        if (count == total)
                        {
                            //if (count != 0)
                            //{
                            string RadioVisible = "";
                            string Pallet = "src='../../Images/Pallet.png'";
                            string Ubicacion = "title='Ubicacion Libre'";
                            string td4 = "";
                            if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                            {
                                td4 = "<td colspan='4'></td>";
                            }
                            string CodigoUbicacion2 = "";

                            int contador2 = 0;
                            foreach (Model_Wip_Control wp in lista.Where(o => o.Posicion == reader["Nombre_Rack"].ToString()))
                            {
                                CodigoUbicacion2 = CodigoUbicacion2 +"OT: " + wp.OT + " Pliego: " + wp.Pliego + " Codigo: " + wp.ID_Control + " \n";
                                contador2++;
                            }
                            if (CodigoUbicacion2 != "")
                            {
                                //RadioVisible = "disabled='disabled'";
                                Pallet = "src='../../Images/Pallet_Ocupado.png'";
                                Ubicacion = "title='Ubicacion Ocupada'";

                                color = "bgcolor='#FF1A00'";
                                Ocupadas = Ocupadas + contador2;
                            }
                            else
                            {
                                color = "bgcolor='#00FF00'";
                                libres = libres + 1;
                            }
                            RackLibre = RackLibre + td4 + "<td style='width: 100px;vertical-align:top;'" + color + "><div align='center' style='font-size:13px;'>" + reader["Nombre_Rack"].ToString() + "</div><a style='font-size:11px;' title='" + CodigoUbicacion2 + "'>" + contador2.ToString("N0").Replace(",", ".") + " Pallet</a></td>";
                            //<input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " />
                            RackLibre = RackLibre + "</tr>";
                            //}
                            //RackLibre = RackLibre + "<tr>";
                            ////  nivelOld = nivelNew;
                            count = 1;
                            contadorg = contadorg + 1;
                        }
                        else
                        {
                            string RadioVisible = "";
                            string Pallet = "src='../../Images/Pallet.png'";
                            string Ubicacion = "title='Ubicacion Libre'";
                            
                            string td4 = "";
                            if ((reader["Nombre_Rack"].ToString() == "N04C5" || reader["Nombre_Rack"].ToString() == "N04A5" || reader["Nombre_Rack"].ToString() == "N04B5") && Bodega == "EXTERIOR NORBINDER")
                            {
                                td4 = "<td colspan='4'></td>";
                            }
                            string CodigoUbicacion3 = "";

                            int contador3 = 0;
                            foreach (Model_Wip_Control wp in lista.Where(o => o.Posicion == reader["Nombre_Rack"].ToString()))
                            {
                                if (contador3 % 2 == 0)
                                {
                                    CodigoUbicacion3 = CodigoUbicacion3 + "OT: " + wp.OT + " Pliego: " + wp.Pliego + " Codigo: " + wp.ID_Control + "   ";
                                }
                                else
                                {
                                    CodigoUbicacion3 = CodigoUbicacion3 + "OT: " + wp.OT + " Pliego: " + wp.Pliego + " Codigo: " + wp.ID_Control + " \n";
                                }
                                contador3++;
                            }
                            if (CodigoUbicacion3 != "")
                            {
                                //RadioVisible = "disabled='disabled'";
                                Pallet = "src='../../Images/Pallet_Ocupado.png'";
                                Ubicacion = "title='Ubicacion Ocupada'";

                                color = "bgcolor='#FF1A00'";
                                Ocupadas = Ocupadas + contador3;
                            }
                            else
                            {
                                color = "bgcolor='#00FF00'";
                                libres = libres + 1;
                            }
                            RackLibre = RackLibre + td4 + "<td style='width: 100px;vertical-align:top;'" + color + "><div align='center' style='font-size:13px;'>" + reader["Nombre_Rack"].ToString() + "</div><a style='font-size:11px;' title='" + CodigoUbicacion3 + "'>" + contador3.ToString("N0").Replace(",", ".") + " Pallet</a></td>";
                            //<input type='radio' name='checkintento' value='" + reader["Nombre_Rack"].ToString() + "' " + RadioVisible + " />
                            count++;
                            contadorg = contadorg + 1;
                        }
                    }
                }
            }
            if (libres == 0 || contadorg == 0)
            {
                algo = 0;
            }
            else
            {
                algo = ((libres * 100 / contadorg * 100));
            }

            if (algo == 0)
            {
                RackLibre = RackLibre + "</tr></table> <div align='center' >Piso " + Piso + " ( Disponibilidad:  0%, Posiciones Libres: " + libres.ToString() + ". )</div><div align='center'>Cantidad Total : " + Ocupadas + " Pallet</div></div><input id='Text1' name='Text1'  type='text' value='" + Codigo + "' style='visibility: hidden;'  />";
            }
            else
            {
                string algo2 = algo.ToString().Substring(0, algo.ToString().Length - 2);
                RackLibre = RackLibre + "</tr></table> <div align='center' >Piso " + Piso + " ( Disponibilidad: " + algo2.ToString() + "%, Posiciones Libres: " + libres.ToString() + ". )</div><div align='center'>Cantidad Total : " + Ocupadas + " Pallet </div> </div><input id='Text1' name='Text1'  type='text' value='" + Codigo + "' style='visibility: hidden;'  />";
            }
            con.CerrarConexion();
            return RackLibre;
        }

        public List<Model_Wip_Control> listaCodigoxUbicacion(string Ubicacion)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_CodigoXUbicacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.OT = reader["OT"].ToString();
                    wip.Pliego = reader["Pliego"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    lista.Add(wip);
                }
                con.CerrarConexion();
            }
            return lista;

        }

        public List<Model_Wip_Control> ListarInformeEntregaPallet(string OT)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Wip_InformeEntregaPallet";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Model_Wip_Control wip = new Model_Wip_Control();
                        wip.OT = OT;
                        wip.NombreOT = reader["NombreOT"].ToString();
                        wip.TotalTiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                        wip.Pliegos_Impresos = Convert.ToInt32(reader["Entregado"].ToString());
                        wip.Maquina = reader["Serv_Ext"].ToString();
                        wip.Maquina_Proceso = reader["Almacenado"].ToString();
                        wip.Estado_Pallet2 = reader["EstadoOt"].ToString();
                        wip.VerMas = "Ver Más";
                        lista.Add(wip);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        #endregion
        #region nuevosCambios

        public List<Model_Wip_Control> ListInventarioWip(string FechaTermino)
        {
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_InformeInventario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.CommandTimeout = 60000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.OT = reader["OT"].ToString();
                    wip.Pliego = reader["Pliegos"].ToString();
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.Maquina = reader["Maquina_Origen"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Pliegos_Impresos = Convert.ToInt32(reader["CantidadPliegos"].ToString());
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        #endregion
    }
}