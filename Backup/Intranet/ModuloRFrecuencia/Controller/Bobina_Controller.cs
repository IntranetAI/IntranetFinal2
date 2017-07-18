using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloRFrecuencia.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloRFrecuencia.Controller
{
    public class Bobina_Controller
    {
        #region anterior
        //procedimiento modificado
        public Bobina BuscarBobinaCodigo(string codigo)
        {
            Bobina bobina = new Bobina();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_buscarPorCode";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string respuesta = reader["respuesta"].ToString();
                    if (respuesta == "Nueva" || respuesta == "Saldo")
                    {
                        bobina.Codigo = reader["Codigo"].ToString();
                        bobina.Ubicacion = respuesta;
                        bobina.Proveedor = reader["Proveedor"].ToString();
                        string a = reader["Gramage"].ToString();
                        bobina.Gramage = Convert.ToInt32(reader["Gramage"].ToString());
                        bobina.Ancho = Convert.ToInt32(reader["Ancho"].ToString());
                        bobina.Peso_Original = Convert.ToInt32(reader["Peso"].ToString());
                        bobina.Marca = reader["Marca"].ToString();
                        bobina.Tipo = reader["Tipo"].ToString();
                        bobina.Cono = reader["SKU"].ToString();
                    }
                    else if (respuesta == "Consumida")
                    {
                        bobina.Ubicacion = "Bobina Consumida.";
                    }
                    else
                    {
                        bobina.Ubicacion = respuesta;
                    }
                }
            }
            con.CerrarConexion();
            return bobina;
        }

        public List<Bobina> BuscarEstado_bobi(int Tipo)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BuscarTipoBobi";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Tipo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina b = new Bobina();
                    b.Codigo = reader["Codigo"].ToString();
                    b.Tipo = reader["Nombre_estado"].ToString();
                    lista.Add(b);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Boolean AgregarBobina(Bobina b, string Usuario, string Maquina, string Fecha)
        {
            Boolean Completa = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bob_Insert_Bobina";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOP", b.NumeroOp);
                    cmd.Parameters.AddWithValue("@Codigo_Bobina", b.Codigo);
                    cmd.Parameters.AddWithValue("@Proveedor", b.Proveedor);
                    cmd.Parameters.AddWithValue("@Gramage", b.Gramage);
                    cmd.Parameters.AddWithValue("@Ancho", b.Ancho);
                    cmd.Parameters.AddWithValue("@Marca", b.Marca);
                    cmd.Parameters.AddWithValue("@Tipo_Papel", b.Tipo);
                    cmd.Parameters.AddWithValue("@PesoOrginal", b.Peso_Original);
                    cmd.Parameters.AddWithValue("@Peso_Tapas", b.Peso_Tapa);
                    cmd.Parameters.AddWithValue("@Peso_Envoltorio", b.Peso_emboltorio);
                    cmd.Parameters.AddWithValue("@Peso_Escarpe", b.PesoEscarpe);
                    cmd.Parameters.AddWithValue("@Estado_Bobina", b.Estado_Bobina);//Causa
                    cmd.Parameters.AddWithValue("@Responsable", b.Responsable);
                    cmd.Parameters.AddWithValue("@Pliego", b.pliego);
                    cmd.Parameters.AddWithValue("@Cierre", false);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    if (Fecha != "")
                    {
                        string[] str = Fecha.Split('/');
                        cmd.Parameters.AddWithValue("@Fecha", str[1] + "-" + str[0] + "-" + str[2].Substring(0, 4) + " " + str[2].Substring(4, str[2].Length - 4));
                    }

                    cmd.ExecuteNonQuery();
                    Completa = true;
                }
                catch
                {
                    Completa = false;
                }
            }
            con.CerrarConexion();
            return Completa;
        }

        public List<Bobina> listarBobinaPend(string OP, string pliego, int Procedimiento)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ListarBobinaOP";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OP", OP);
                    cmd.Parameters.AddWithValue("@pliego", pliego);
                    cmd.Parameters.AddWithValue("@Proceso", Procedimiento);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina b = new Bobina();
                        b.NumeroOp = OP;
                        b.ID_Bobina = Convert.ToInt32(reader["ID_Bobina"].ToString());
                        b.Codigo = reader["Codigo_Bobina"].ToString();
                        b.Gramage = Convert.ToInt32(reader["Gramage"].ToString());
                        b.Ancho = Convert.ToInt32(reader["Ancho"].ToString());
                        b.Peso_Original = Convert.ToInt32(reader["PesoOrginal"].ToString());
                        b.Peso_Tapa = Convert.ToDouble(reader["Peso_Tapas"].ToString());
                        b.Peso_emboltorio = Convert.ToDouble(reader["Peso_Envoltorio"].ToString());
                        b.PesoEscarpe = Convert.ToDouble(reader["Peso_Escarpe"].ToString());
                        b.Saldo = Convert.ToInt32(reader["Saldo"].ToString());
                        if (reader["Peso_Cono"].ToString() != "")
                        {
                            b.Peso_Cono = Convert.ToDouble(reader["Peso_Cono"].ToString());
                        }
                        else
                        {
                            b.Peso_Cono = 0;
                        }
                        b.Marca = reader["Marca"].ToString();
                        b.Proveedor = reader["Tipo_Papel"].ToString();
                        b.Fecha_Consumo = Convert.ToDateTime(reader["fecha_Consumo"].ToString());
                        if (Convert.ToInt32(reader["Cierre"].ToString()) == 3 || Convert.ToInt32(reader["Cierre"].ToString()) == 2)
                        {
                            b.Tipo = "Consumida";
                        }
                        else
                        {
                            b.Tipo = "Pendiente";
                        }
                        if (Procedimiento == 1)
                        {
                            b.Lote = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + b.NumeroOp + "\",\"" + b.ID_Bobina + "\");'>Modificar</a>";
                            b.Cono = "<a style='Color:Blue;text-decoration:none;' href='javascript:Falla(\"" + b.ID_Bobina + "\");'>Ingresar</a>";
                        }
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string infMaquinaBobina(string Usuario)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[SP_infMaquinaBobina]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["Fecha"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public bool IngresarOperador(string Nombre, string Turno, string Maquina, string Proceso)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SP_Insert_Operario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Turno", Turno);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Proceso", Proceso);
                    cmd.ExecuteNonQuery();


                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else { return false; };

            conexion.CerrarConexion();

        }

        public Bobina BuscarBobinaCerrar(int IDBobina)
        {
            Bobina b = new Bobina();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BuscarbobinaCierre";
                cmd.Parameters.AddWithValue("@IDBobina", IDBobina);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    b.ID_Bobina = Convert.ToInt32(reader["ID_Bobina"].ToString());
                    b.NumeroOp = reader["NumeroOP"].ToString();
                    b.Codigo = reader["Codigo_Bobina"].ToString();
                    b.pliego = reader["NOmbre_pliego"].ToString();
                    b.Fecha_Consumo = Convert.ToDateTime(reader["Fecha_Consumo"].ToString());
                    b.Proveedor = reader["Proveedor"].ToString();
                    b.Gramage = Convert.ToInt32(reader["Gramage"].ToString());
                    b.Marca = reader["Marca"].ToString();
                    b.Tipo = reader["Tipo_Papel"].ToString();
                    b.Peso_Original = Convert.ToInt32(reader["PesoOrginal"].ToString());
                    b.Ancho = Convert.ToInt32(reader["Ancho"].ToString());
                    b.Peso_Tapa = Convert.ToDouble(reader["Peso_Tapas"].ToString());
                    b.Peso_emboltorio = Convert.ToDouble(reader["Peso_Envoltorio"].ToString());
                    b.PesoEscarpe = Convert.ToDouble(reader["Peso_Escarpe"].ToString());
                    b.Peso_Cono = Convert.ToDouble(reader["Peso_Cono"].ToString());
                    b.Saldo = Convert.ToInt32(reader["Saldo"].ToString());
                    b.Ubicacion = reader["Maquina"].ToString();
                    b.Responsable = Convert.ToInt32(reader["Responsable"].ToString());
                    b.Estado_Bobina = Convert.ToInt32(reader["Estado_Bobina"].ToString());
                    b.Cono = reader["Usuario"].ToString();
                }
            }
            con.CerrarConexion();

            return b;
        }

        public bool UpdateBobinaClose(Bobina b, int estado)
        {
            Boolean verificacion = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "UpdateCierreBobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDBobina", b.ID_Bobina);
                cmd.Parameters.AddWithValue("@PesoCono", b.Peso_Cono);
                cmd.Parameters.AddWithValue("@Saldo", b.Saldo);
                cmd.Parameters.AddWithValue("@Estado", estado);

                cmd.ExecuteNonQuery();
                verificacion = true;
            }
            con.CerrarConexion();
            return verificacion;
        }

        public string BuscarMaquinaUser(string IP)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Desperdicio_BuscarMaquina_IP";
                cmd.Parameters.AddWithValue("@IP", IP);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = reader["Maquina"].ToString();
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public bool PliegosRealizados(string OT, string Pliego)
        {
            Boolean Respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Insert_pliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Respuesta = Convert.ToBoolean(reader["Respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return Respuesta;
        }

        public List<Bobina> ListarBobinaInf(Bobina b, DateTime FechaInicio, DateTime FechaTermino)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_Informe_Bobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", b.NumeroOp);
                cmd.Parameters.AddWithValue("@NombreOT", b.Ubicacion);
                cmd.Parameters.AddWithValue("@Cliente", b.Marca);
                cmd.Parameters.AddWithValue("@Maquina", b.Proveedor);
                cmd.Parameters.AddWithValue("@Usuario", b.pliego);
                cmd.Parameters.AddWithValue("@Papel", b.Tipo);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina bobina = new Bobina();
                    if (b.Proveedor != "")
                    {
                        bobina.pliego = reader["Maquina"].ToString();
                    }
                    bobina.NumeroOp = reader["NumeroOP"].ToString();
                    bobina.Proveedor = reader["NM"].ToString();
                    bobina.ID_Bobina = Convert.ToInt32(reader["Total_Bobina"].ToString());
                    bobina.Ancho = Convert.ToInt32(reader["Buenas"].ToString());
                    bobina.Gramage = Convert.ToInt32(reader["MalasQG"].ToString());
                    bobina.Inicial = Convert.ToInt32(reader["Malas"].ToString());
                    bobina.Peso_Original = Convert.ToInt32(reader["PesoOriginal"].ToString());
                    bobina.Peso_Tapa = Convert.ToDouble(reader["PesoTapas"].ToString());
                    bobina.Peso_Cono = Convert.ToDouble(reader["PesoCono"].ToString());
                    bobina.Peso_emboltorio = Convert.ToDouble(reader["PesoEnvoltura"].ToString());
                    bobina.PesoEscarpe = Convert.ToDouble(reader["PesoEscarpe"].ToString());
                    double Porc_Perdida = Convert.ToDouble(reader["Porce_Perdida"].ToString());
                    bobina.Porc_Perdida = Porc_Perdida.ToString("N2") + " %";
                    int numero = Convert.ToInt32(reader["Porce_Buenas"].ToString());
                    bobina.Porc_Buenas = numero.ToString() + " %";

                    numero = Convert.ToInt32(reader["Porce_Malas"].ToString());
                    bobina.Porc_Malas = numero.ToString() + " %";
                    lista.Add(bobina);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina_Excel> ListarBobExcelInf(Bobina b, DateTime FechaInicio, DateTime FechaTermino)
        {
            List<Bobina_Excel> lista = new List<Bobina_Excel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_Informe_Bobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", b.NumeroOp);
                cmd.Parameters.AddWithValue("@NombreOT", b.Ubicacion);
                cmd.Parameters.AddWithValue("@Cliente", b.Marca);
                cmd.Parameters.AddWithValue("@Maquina", b.Proveedor);
                cmd.Parameters.AddWithValue("@Usuario", b.pliego);
                cmd.Parameters.AddWithValue("@Papel", b.Tipo);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina_Excel bobina = new Bobina_Excel();
                    if (b.Proveedor != "")
                    {
                        bobina.Maquina = reader["Maquina"].ToString();
                    }
                    bobina.OT = reader["NumeroOP"].ToString();
                    bobina.NombreOT = reader["NM"].ToString();
                    int numero = Convert.ToInt32(reader["Total_Bobina"].ToString());
                    bobina.Total_B = numero.ToString("N0").Replace(",", ".");
                    numero = Convert.ToInt32(reader["Buenas"].ToString());
                    bobina.BBuenas = numero.ToString("N0").Replace(",", ".");
                    numero = Convert.ToInt32(reader["MalasQG"].ToString());
                    bobina.BMalas_QG = numero.ToString("N0").Replace(",", ".");
                    numero = Convert.ToInt32(reader["Malas"].ToString());
                    bobina.BMalas = numero.ToString("N0").Replace(",", ".");
                    numero = Convert.ToInt32(reader["PesoOriginal"].ToString());
                    bobina.Peso_Original = numero.ToString("N0").Replace(",", ".");
                    double numero1 = Convert.ToDouble(reader["PesoTapas"].ToString());
                    bobina.Pesos_Tapas = numero1.ToString("N0").Replace(",", ".");
                    numero1 = Convert.ToDouble(reader["PesoCono"].ToString());
                    bobina.Pesos_Conos = numero1.ToString("N0").Replace(",", ".");
                    numero1 = Convert.ToDouble(reader["PesoEnvoltura"].ToString());
                    bobina.Pesos_Envoltura = numero1.ToString("N0").Replace(",", ".");
                    numero1 = Convert.ToDouble(reader["PesoEscarpe"].ToString());
                    bobina.Pesos_Escarpe = numero1.ToString("N0").Replace(",", ".");

                    double Porc_Perdida = Convert.ToDouble(reader["Porce_Perdida"].ToString());
                    bobina.Porc_Perdida = Porc_Perdida.ToString("N2") + " %";
                    int numero2 = Convert.ToInt32(reader["Porce_Buenas"].ToString());
                    bobina.Porc_Buenas = numero2.ToString() + " %";

                    numero = Convert.ToInt32(reader["Porce_Malas"].ToString());
                    bobina.Porc_Malas = numero.ToString() + " %";
                    lista.Add(bobina);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina> ListarUsuarioBobina()
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Listar_User_InfBobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina bobina = new Bobina();
                    bobina.Marca = reader["Usuario"].ToString();
                    string[] strUser = reader["Nombre"].ToString().Split(' ');
                    bobina.pliego = strUser[0] + " " + strUser[2];
                    lista.Add(bobina);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina_Excel> ListBobina_WarRom(string Fecha, string Fecha2 = "")
        {
            List<Bobina_Excel> lista = new List<Bobina_Excel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_Informe_WarRom2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                if (Fecha2 != "")
                {
                    cmd.Parameters.AddWithValue("@Fecha2", Fecha2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Fecha2", "");
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina_Excel b = new Bobina_Excel();
                    //b.Porc_Perdida = reader["ID_Bobina"].ToString();
                    b.Maquina = reader["Maquina"].ToString();//Maquina
                    b.OT = reader["Codigo_Bobina"].ToString(); //Codigo de Bobina 
                    b.NombreOT = reader["Tipo_Papel"].ToString();//Tipó de papel
                    b.Total_B = reader["Gramage"].ToString();//gramaje
                    b.BBuenas = Convert.ToDouble(reader["PesoOriginal"]).ToString("N0").Replace(",", ".");// peso Original
                    b.Pesos_Tapas = reader["Peso_Escarpe"].ToString();//peso escarpe
                    b.Pesos_Envoltura = reader["Total_Bobina"].ToString();//Total de Bobina
                    b.Porc_Buenas = reader["Buenas"].ToString();//Total de Bobinas Buenas
                    b.Pesos_Escarpe = reader["Malas"].ToString();// Totla de Bobinas Malas
                    b.Porc_Malas = reader["TotalPeso"].ToString();//Total Peso Original
                    b.Porc_Perdida = reader["TotalEscarpe"].ToString();//TotalEscarpe
                    b.CProyecto = reader["CProyecto"].ToString();
                    b.SProyecto = reader["SProyecto"].ToString();
                    b.ProCProyec = reader["PorcCProye"].ToString() + "%";
                    b.ProSProyec = reader["PorcSProye"].ToString() + "%";
                    b.ConsumoMaquina = reader["ConsumoMaquina"].ToString();
                    b.Ancho = reader["ancho"].ToString();
                    if (Convert.ToInt32(reader["Estado_Bobina"].ToString()) == 100)
                    {
                        b.BMalas_QG = "Bobina Buena";
                        b.BMalas = "";//Responsable Daño
                        b.Peso_Original = "";//Causa del Daño de la Bobina
                    }
                    else
                    {
                        b.Peso_Original = reader["Causa"].ToString();//Causa del Daño de la Bobina
                        b.BMalas_QG = "Bobina Mala";
                        if (Convert.ToInt32(reader["Responsable"].ToString()) == 2)
                        {
                            b.BMalas = "Rollero";//Responsable Daño
                        }
                        if (Convert.ToInt32(reader["Responsable"].ToString()) == 3)
                        {
                            b.BMalas = "Almacén";//Responsable Daño
                        }
                        if (Convert.ToInt32(reader["Responsable"].ToString()) == 4)
                        {
                            b.BMalas = "Otros Daños";//Responsable Daño
                        }
                    }

                    double Peso_Total = Convert.ToDouble(reader["ConsumoMaquina"].ToString());
                    //if (b.PesoEscarpe != 0)
                    //{
                    double result = ((Convert.ToDouble(b.Pesos_Tapas) * 100) / Peso_Total);
                    b.Pesos_Conos = result.ToString("N2") + " %";
                    //}
                    //else
                    //{
                    //    b.Porc_Perdida = "0 %";
                    //}
                    lista.Add(b);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public bool IngresoCodigo(Bobina bob)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "AgregarCodigo_Bobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", bob.Codigo);
                cmd.Parameters.AddWithValue("@PesoOriginal", bob.Peso_Original);
                cmd.Parameters.AddWithValue("@Ancho", bob.Ancho);
                cmd.Parameters.AddWithValue("@Largo", bob.Gramage);

                int globa0 = cmd.ExecuteNonQuery();
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Inf_Regional> List_Inf_Regional(string FechaInicio, string FechaTermino)
        {
            List<Inf_Regional> lista = new List<Inf_Regional>();
            List<Bobina> listainicial = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_Inf_Regional";
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                Inf_Regional irMM = new Inf_Regional();//M600 Mañana
                Inf_Regional irMT = new Inf_Regional();// M600 tarde
                Inf_Regional irLM = new Inf_Regional();//Litho Mañana
                Inf_Regional irLT = new Inf_Regional();//Litho tarde
                Inf_Regional irDM = new Inf_Regional();//Dimen Mañana
                Inf_Regional irDT = new Inf_Regional();//Dimen Tarde
                Inf_Regional irWM1 = new Inf_Regional();//Web 1 Mañana
                Inf_Regional irWT1 = new Inf_Regional();//Web 1 Tarde
                Inf_Regional irWN1 = new Inf_Regional();//Web 1 Noche
                Inf_Regional irWM2 = new Inf_Regional();//Web 2 Mañana
                Inf_Regional irWT2 = new Inf_Regional();//Web 2 Tarde
                Inf_Regional irWN2 = new Inf_Regional();//Web 2 Noche
                Inf_Regional irIG = new Inf_Regional();//General

                while (reader.Read())
                {
                    Bobina bob = new Bobina();
                    bob.Cono = reader["Maquina"].ToString();//maquina
                    bob.Ancho = Convert.ToInt32(reader["Hora"].ToString());//Hora
                    bob.Codigo = reader["Bobina"].ToString();//Bobina
                    bob.Peso_Cono = Convert.ToDouble(reader["Peso_Escarpe"].ToString());//Peso Escarpe
                    bob.Peso_emboltorio = Convert.ToDouble(reader["PesoOrginal"].ToString());//Peso Original
                    bob.Responsable = Convert.ToInt32(reader["Responsable"].ToString());//responsable
                    listainicial.Add(bob);
                }
                string CodigoBobina = "0";
                foreach (Bobina b in listainicial)
                {
                    if (b.Cono == "Dimensionadora")
                    {
                        if (b.Ancho < 12)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irDM.BobBueCant == "")
                                {
                                    irDM.BobBueCant = "0";
                                    irDM.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDM.BobBueCant = (Convert.ToInt32(irDM.BobBueCant) + 1).ToString();
                                }
                                irDM.BobBueEsc = (Convert.ToDouble(irDM.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irDM.BobRotCant == "")
                                {
                                    irDM.BobRotCant = "0";
                                    irDM.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDM.BobRotCant = (Convert.ToInt32(irDM.BobRotCant) + 1).ToString();
                                }
                                irDM.BobRotEsc = (Convert.ToDouble(irDM.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irDM.BobDetCant == "")
                                {
                                    irDM.BobDetCant = "0";
                                    irDM.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDM.BobDetCant = (Convert.ToInt32(irDM.BobDetCant) + 1).ToString();
                                }
                                irDM.BobDetEsc = (Convert.ToDouble(irDM.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irDM.BobOtrCant == "")
                                {
                                    irDM.BobOtrCant = "0";
                                    irDM.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDM.BobOtrCant = (Convert.ToInt32(irDM.BobOtrCant) + 1).ToString();
                                }
                                irDM.BobOtrEsc = (Convert.ToDouble(irDM.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else
                        {
                            if (b.Responsable == 1)
                            {
                                if (irDT.BobBueCant == "")
                                {
                                    irDT.BobBueCant = "0";
                                    irDT.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDT.BobBueCant = (Convert.ToInt32(irDT.BobBueCant) + 1).ToString();
                                }
                                irDT.BobBueEsc = (Convert.ToDouble(irDT.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irDT.BobRotCant == "")
                                {
                                    irDT.BobRotCant = "0";
                                    irDT.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDT.BobRotCant = (Convert.ToInt32(irDT.BobRotCant) + 1).ToString();
                                }
                                irDT.BobRotEsc = (Convert.ToDouble(irDT.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irDT.BobDetCant == "")
                                {
                                    irDT.BobDetCant = "0";
                                    irDT.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDT.BobDetCant = (Convert.ToInt32(irDT.BobDetCant) + 1).ToString();
                                }
                                irDT.BobDetEsc = (Convert.ToDouble(irDT.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irDT.BobOtrCant == "")
                                {
                                    irDT.BobOtrCant = "0";
                                    irDT.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irDT.BobOtrCant = (Convert.ToInt32(irDT.BobOtrCant) + 1).ToString();
                                }
                                irDT.BobOtrEsc = (Convert.ToDouble(irDT.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                    }
                    if (b.Cono == "Lithoman")
                    {
                        if (b.Ancho < 12)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irLM.BobBueCant == "")
                                {
                                    irLM.BobBueCant = "0";
                                    irLM.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLM.BobBueCant = (Convert.ToInt32(irLM.BobBueCant) + 1).ToString();
                                }
                                irLM.BobBueEsc = (Convert.ToDouble(irLM.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irLM.BobRotCant == "")
                                {
                                    irLM.BobRotCant = "0";
                                    irLM.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLM.BobRotCant = (Convert.ToInt32(irLM.BobRotCant) + 1).ToString();
                                }
                                irLM.BobRotEsc = (Convert.ToDouble(irLM.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irLM.BobDetCant == "")
                                {
                                    irLM.BobDetCant = "0";
                                    irLM.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLM.BobDetCant = (Convert.ToInt32(irLM.BobDetCant) + 1).ToString();
                                }
                                irLM.BobDetEsc = (Convert.ToDouble(irLM.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irLM.BobOtrCant == "")
                                {
                                    irLM.BobOtrCant = "0";
                                    irLM.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLM.BobOtrCant = (Convert.ToInt32(irLM.BobOtrCant) + 1).ToString();
                                }
                                irLM.BobOtrEsc = (Convert.ToDouble(irLM.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else
                        {
                            if (b.Responsable == 1)
                            {
                                if (irLT.BobBueCant == "")
                                {
                                    irLT.BobBueCant = "0";
                                    irLT.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLT.BobBueCant = (Convert.ToInt32(irLT.BobBueCant) + 1).ToString();
                                }
                                irLT.BobBueEsc = (Convert.ToDouble(irLT.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irLT.BobRotCant == "")
                                {
                                    irLT.BobRotCant = "0";
                                    irLT.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLT.BobRotCant = (Convert.ToInt32(irLT.BobRotCant) + 1).ToString();
                                }
                                irLT.BobRotEsc = (Convert.ToDouble(irLT.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irLT.BobDetCant == "")
                                {
                                    irLT.BobDetCant = "0";
                                    irLT.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLT.BobDetCant = (Convert.ToInt32(irLT.BobDetCant) + 1).ToString();
                                }
                                irLT.BobDetEsc = (Convert.ToDouble(irLT.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irLT.BobOtrCant == "")
                                {
                                    irLT.BobOtrCant = "0";
                                    irLT.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irLT.BobOtrCant = (Convert.ToInt32(irLT.BobOtrCant) + 1).ToString();
                                }
                                irLT.BobOtrEsc = (Convert.ToDouble(irLT.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                    }
                    else if (b.Cono == "M600")
                    {
                        if (b.Ancho < 12)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irMM.BobBueCant == "")
                                {
                                    irMM.BobBueCant = "0";
                                    irMM.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMM.BobBueCant = (Convert.ToInt32(irMM.BobBueCant) + 1).ToString();
                                }
                                irMM.BobBueEsc = (Convert.ToDouble(irMM.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irMM.BobRotCant == "")
                                {
                                    irMM.BobRotCant = "0";
                                    irMM.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMM.BobRotCant = (Convert.ToInt32(irMM.BobRotCant) + 1).ToString();
                                }
                                irMM.BobRotEsc = (Convert.ToDouble(irMM.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irMM.BobDetCant == "")
                                {
                                    irMM.BobDetCant = "0";
                                    irMM.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMM.BobDetCant = (Convert.ToInt32(irMM.BobDetCant) + 1).ToString();
                                }
                                irMM.BobDetEsc = (Convert.ToDouble(irMM.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irMM.BobOtrCant == "")
                                {
                                    irMM.BobOtrCant = "0";
                                    irMM.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMM.BobOtrCant = (Convert.ToInt32(irMM.BobOtrCant) + 1).ToString();
                                }
                                irMM.BobOtrEsc = (Convert.ToDouble(irMM.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else
                        {
                            if (b.Responsable == 1)
                            {
                                if (irMT.BobBueCant == "")
                                {
                                    irMT.BobBueCant = "0";
                                    irMT.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMT.BobBueCant = (Convert.ToInt32(irMT.BobBueCant) + 1).ToString();
                                }
                                irMT.BobBueEsc = (Convert.ToDouble(irMT.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irMT.BobRotCant == "")
                                {
                                    irMT.BobRotCant = "0";
                                    irMT.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMT.BobRotCant = (Convert.ToInt32(irMT.BobRotCant) + 1).ToString();
                                }
                                irMT.BobRotEsc = (Convert.ToDouble(irMT.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irMT.BobDetCant == "")
                                {
                                    irMT.BobDetCant = "0";
                                    irMT.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMT.BobDetCant = (Convert.ToInt32(irMT.BobDetCant) + 1).ToString();
                                }
                                irMT.BobDetEsc = (Convert.ToDouble(irMT.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irMT.BobOtrCant == "")
                                {
                                    irMT.BobOtrCant = "0";
                                    irMT.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irMT.BobOtrCant = (Convert.ToInt32(irMT.BobOtrCant) + 1).ToString();
                                }
                                irMT.BobOtrEsc = (Convert.ToDouble(irMT.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                    }
                    else if (b.Cono.ToUpper() == "WEB 1")
                    {
                        if (b.Ancho < 8)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWM1.BobBueCant == "")
                                {
                                    irWM1.BobBueCant = "0";
                                    irWM1.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM1.BobBueCant = (Convert.ToInt32(irWM1.BobBueCant) + 1).ToString();
                                }
                                irWM1.BobBueEsc = (Convert.ToDouble(irWM1.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWM1.BobRotCant == "")
                                {
                                    irWM1.BobRotCant = "0";
                                    irWM1.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM1.BobRotCant = (Convert.ToInt32(irWM1.BobRotCant) + 1).ToString();
                                }
                                irWM1.BobRotEsc = (Convert.ToDouble(irWM1.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWM1.BobDetCant == "")
                                {
                                    irWM1.BobDetCant = "0";
                                    irWM1.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM1.BobDetCant = (Convert.ToInt32(irWM1.BobDetCant) + 1).ToString();
                                }
                                irWM1.BobDetEsc = (Convert.ToDouble(irWM1.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWM1.BobOtrCant == "")
                                {
                                    irWM1.BobOtrCant = "0";
                                    irWM1.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM1.BobOtrCant = (Convert.ToInt32(irWM1.BobOtrCant) + 1).ToString();
                                }
                                irWM1.BobOtrEsc = (Convert.ToDouble(irWM1.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else if (b.Ancho > 8 && b.Ancho < 16)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWT1.BobBueCant == "")
                                {
                                    irWT1.BobBueCant = "0";
                                    irWT1.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT1.BobBueCant = (Convert.ToInt32(irWT1.BobBueCant) + 1).ToString();
                                }
                                irWT1.BobBueEsc = (Convert.ToDouble(irWT1.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWT1.BobRotCant == "")
                                {
                                    irWT1.BobRotCant = "0";
                                    irWT1.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT1.BobRotCant = (Convert.ToInt32(irWT1.BobRotCant) + 1).ToString();
                                }
                                irWT1.BobRotEsc = (Convert.ToDouble(irWT1.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWT1.BobDetCant == "")
                                {
                                    irWT1.BobDetCant = "0";
                                    irWT1.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT1.BobDetCant = (Convert.ToInt32(irWT1.BobDetCant) + 1).ToString();
                                }
                                irWT1.BobDetEsc = (Convert.ToDouble(irWT1.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWT1.BobOtrCant == "")
                                {
                                    irWT1.BobOtrCant = "0";
                                    irWT1.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT1.BobOtrCant = (Convert.ToInt32(irWT1.BobOtrCant) + 1).ToString();
                                }
                                irWT1.BobOtrEsc = (Convert.ToDouble(irWT1.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else if (b.Ancho > 16)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWN1.BobBueCant == "")
                                {
                                    irWN1.BobBueCant = "0";
                                    irWN1.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN1.BobBueCant = (Convert.ToInt32(irWN1.BobBueCant) + 1).ToString();
                                }
                                irWN1.BobBueEsc = (Convert.ToDouble(irWN1.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWN1.BobRotCant == "")
                                {
                                    irWN1.BobRotCant = "0";
                                    irWN1.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN1.BobRotCant = (Convert.ToInt32(irWN1.BobRotCant) + 1).ToString();
                                }
                                irWN1.BobRotEsc = (Convert.ToDouble(irWN1.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWN1.BobDetCant == "")
                                {
                                    irWN1.BobDetCant = "0";
                                    irWN1.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN1.BobDetCant = (Convert.ToInt32(irWN1.BobDetCant) + 1).ToString();
                                }
                                irWN1.BobDetEsc = (Convert.ToDouble(irWN1.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWN1.BobOtrCant == "")
                                {
                                    irWN1.BobOtrCant = "0";
                                    irWN1.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN1.BobOtrCant = (Convert.ToInt32(irWN1.BobOtrCant) + 1).ToString();
                                }
                                irWN1.BobOtrEsc = (Convert.ToDouble(irWN1.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                    }
                    else if (b.Cono.ToUpper() == "WEB 2")
                    {
                        if (b.Ancho < 8)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWM2.BobBueCant == "")
                                {
                                    irWM2.BobBueCant = "0";
                                    irWM2.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM2.BobBueCant = (Convert.ToInt32(irWM2.BobBueCant) + 1).ToString();
                                }
                                irWM2.BobBueEsc = (Convert.ToDouble(irWM2.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWM2.BobRotCant == "")
                                {
                                    irWM2.BobRotCant = "0";
                                    irWM2.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM2.BobRotCant = (Convert.ToInt32(irWM2.BobRotCant) + 1).ToString();
                                }
                                irWM2.BobRotEsc = (Convert.ToDouble(irWM2.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWM2.BobDetCant == "")
                                {
                                    irWM2.BobDetCant = "0";
                                    irWM2.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM2.BobDetCant = (Convert.ToInt32(irWM2.BobDetCant) + 1).ToString();
                                }
                                irWM2.BobDetEsc = (Convert.ToDouble(irWM2.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWM2.BobOtrCant == "")
                                {
                                    irWM2.BobOtrCant = "0";
                                    irWM2.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWM2.BobOtrCant = (Convert.ToInt32(irWM2.BobOtrCant) + 1).ToString();
                                }
                                irWM2.BobOtrEsc = (Convert.ToDouble(irWM2.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else if (b.Ancho > 8 && b.Ancho < 16)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWT2.BobBueCant == "")
                                {
                                    irWT2.BobBueCant = "0";
                                    irWT2.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT2.BobBueCant = (Convert.ToInt32(irWT2.BobBueCant) + 1).ToString();
                                }
                                irWT2.BobBueEsc = (Convert.ToDouble(irWT2.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWT2.BobRotCant == "")
                                {
                                    irWT2.BobRotCant = "0";
                                    irWT2.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT2.BobRotCant = (Convert.ToInt32(irWT2.BobRotCant) + 1).ToString();
                                }
                                irWT2.BobRotEsc = (Convert.ToDouble(irWT2.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWT2.BobDetCant == "")
                                {
                                    irWT2.BobDetCant = "0";
                                    irWT2.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT2.BobDetCant = (Convert.ToInt32(irWT2.BobDetCant) + 1).ToString();
                                }
                                irWT2.BobDetEsc = (Convert.ToDouble(irWT2.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWT2.BobOtrCant == "")
                                {
                                    irWT2.BobOtrCant = "0";
                                    irWT2.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWT2.BobOtrCant = (Convert.ToInt32(irWT2.BobOtrCant) + 1).ToString();
                                }
                                irWT2.BobOtrEsc = (Convert.ToDouble(irWT2.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                        else if (b.Ancho > 16)
                        {
                            if (b.Responsable == 1)
                            {
                                if (irWN2.BobBueCant == "")
                                {
                                    irWN2.BobBueCant = "0";
                                    irWN2.BobBueEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN2.BobBueCant = (Convert.ToInt32(irWN2.BobBueCant) + 1).ToString();
                                }
                                irWN2.BobBueEsc = (Convert.ToDouble(irWN2.BobBueEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 2)
                            {
                                if (irWN2.BobRotCant == "")
                                {
                                    irWN2.BobRotCant = "0";
                                    irWN2.BobRotEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN2.BobRotCant = (Convert.ToInt32(irWN2.BobRotCant) + 1).ToString();
                                }
                                irWN2.BobRotEsc = (Convert.ToDouble(irWN2.BobRotEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 3)
                            {
                                if (irWN2.BobDetCant == "")
                                {
                                    irWN2.BobDetCant = "0";
                                    irWN2.BobDetEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN2.BobDetCant = (Convert.ToInt32(irWN2.BobDetCant) + 1).ToString();
                                }
                                irWN2.BobDetEsc = (Convert.ToDouble(irWN2.BobDetEsc) + b.Peso_Cono).ToString();
                            }
                            else if (b.Responsable == 4)
                            {
                                if (irWN2.BobOtrCant == "")
                                {
                                    irWN2.BobOtrCant = "0";
                                    irWN2.BobOtrEsc = "0";
                                }
                                if (CodigoBobina != b.Codigo)
                                {
                                    CodigoBobina = b.Codigo;
                                    irWN2.BobOtrCant = (Convert.ToInt32(irWN2.BobOtrCant) + 1).ToString();
                                }
                                irWN2.BobOtrEsc = (Convert.ToDouble(irWN2.BobOtrEsc) + b.Peso_Cono).ToString();
                            }
                        }
                    }
                }

                irMM.Maquina = "M600"; irMM.Turno = "Mañana";
                irMT.Maquina = "M600"; irMT.Turno = "Tarde";
                irLM.Maquina = "Lithoman"; irLM.Turno = "Mañana";
                irLT.Maquina = "Lithoman"; irLT.Turno = "Tarde";
                irDM.Maquina = "Dimensionadora"; irDM.Turno = "Mañana";
                irDT.Maquina = "Dimensionadora"; irDT.Turno = "Tarde";
                irWM1.Maquina = "WEB 1"; irWM1.Turno = "Mañana";
                irWT1.Maquina = "WEB 1"; irWT1.Turno = "Tarde";
                irWN1.Maquina = "WEB 1"; irWN1.Turno = "Noche";
                irWM2.Maquina = "WEB 2"; irWM2.Turno = "Mañana";
                irWT2.Maquina = "WEB 2"; irWT2.Turno = "Tarde";
                irWN2.Maquina = "WEB 2"; irWN2.Turno = "Noche";
                lista.Add(irMM);// M600 Mañana
                lista.Add(irMT);// M600 tarde
                lista.Add(irLM);//Litho Mañana
                lista.Add(irLT);//Litho tarde
                lista.Add(irDM);//Dimen Mañana
                lista.Add(irDT);//Dimen Tarde
                lista.Add(irWM1);//Web 1 Mañana
                lista.Add(irWT1);//Web 1 Tarde
                lista.Add(irWN1);//Web 1 Noche
                lista.Add(irWM2);//Web 1 Mañana
                lista.Add(irWT2);//Web 1 Tarde
                lista.Add(irWN2);//Web 1 Noche

                int Total = 0;
                foreach (Inf_Regional ir in lista)
                {
                    irIG.Maquina = "General";
                    int Porce = 0;

                    if (ir.BobBueCant != null)
                    {
                        Porce = Porce + Convert.ToInt32(ir.BobBueCant);
                        irIG.BobBueCant = (Convert.ToInt32(irIG.BobBueCant) + Convert.ToInt32(ir.BobBueCant)).ToString();
                        irIG.BobBueEsc = (Convert.ToDouble(irIG.BobBueEsc) + Convert.ToDouble(ir.BobBueEsc)).ToString();
                        Total = Total + Convert.ToInt32(ir.BobBueCant);
                    }
                    if (ir.BobDetCant != null)
                    {
                        Porce = Porce + Convert.ToInt32(ir.BobDetCant);
                        irIG.BobDetCant = (Convert.ToInt32(irIG.BobDetCant) + Convert.ToInt32(ir.BobDetCant)).ToString();
                        irIG.BobDetEsc = (Convert.ToDouble(irIG.BobDetEsc) + Convert.ToDouble(ir.BobDetEsc)).ToString();
                        Total = Total + Convert.ToInt32(ir.BobDetCant);
                    }
                    if (ir.BobOtrCant != null)
                    {
                        Porce = Porce + Convert.ToInt32(ir.BobOtrCant);
                        irIG.BobOtrCant = (Convert.ToInt32(irIG.BobOtrCant) + Convert.ToInt32(ir.BobOtrCant)).ToString();
                        irIG.BobOtrEsc = (Convert.ToDouble(irIG.BobOtrEsc) + Convert.ToDouble(ir.BobOtrEsc)).ToString();
                        Total = Total + Convert.ToInt32(ir.BobOtrCant);
                    }
                    if (ir.BobRotCant != null)
                    {
                        Porce = Porce + Convert.ToInt32(ir.BobRotCant);
                        irIG.BobRotCant = (Convert.ToInt32(irIG.BobRotCant) + Convert.ToInt32(ir.BobRotCant)).ToString();
                        irIG.BobRotEsc = (Convert.ToDouble(irIG.BobRotEsc) + Convert.ToDouble(ir.BobRotEsc)).ToString();
                        Total = Total + Convert.ToInt32(ir.BobRotCant);
                    }

                    if (ir.BobBueCant == null)
                    {
                        ir.BobBueCant = "0";
                        ir.BobBueEsc = "0.0";
                        ir.BobBueProm = "0.0";
                        ir.BobBueProG = "0.00";
                    }
                    else
                    {
                        ir.BobBueProm = (Convert.ToDouble(ir.BobBueEsc) / Convert.ToDouble(ir.BobBueCant)).ToString("N1");
                        ir.BobBueProG = ((Convert.ToDouble(ir.BobBueCant) / Porce) * 100).ToString("N2");
                    }
                    if (ir.BobDetCant == null)
                    {
                        ir.BobDetCant = "0";
                        ir.BobDetEsc = "0.0";
                        ir.BobDetProm = "0.0";
                        ir.BobDetProG = "0.00";
                    }
                    else
                    {
                        ir.BobDetProm = (Convert.ToDouble(ir.BobDetEsc) / Convert.ToDouble(ir.BobDetCant)).ToString("N1");
                        ir.BobDetProG = ((Convert.ToDouble(ir.BobDetCant) / Porce) * 100).ToString("N2");
                    }
                    if (ir.BobOtrCant == null)
                    {
                        ir.BobOtrCant = "0";
                        ir.BobOtrEsc = "0.0";
                        ir.BobOtrProm = "0.0";
                        ir.BobOtrProG = "0.00";
                    }
                    else
                    {
                        ir.BobOtrProm = (Convert.ToDouble(ir.BobOtrEsc) / Convert.ToDouble(ir.BobOtrCant)).ToString("N1");
                        ir.BobOtrProG = ((Convert.ToDouble(ir.BobOtrCant) / Porce) * 100).ToString("N2");
                    }
                    if (ir.BobRotCant == null)
                    {
                        ir.BobRotCant = "0";
                        ir.BobRotEsc = "0.0";
                        ir.BobRotProm = "0.0";
                        ir.BobRotProG = "0.00";
                    }
                    else
                    {
                        ir.BobRotProm = (Convert.ToDouble(ir.BobRotEsc) / Convert.ToDouble(ir.BobRotCant)).ToString("N1");
                        ir.BobRotProG = ((Convert.ToDouble(ir.BobRotCant) / Porce) * 100).ToString("N2");
                    }
                }
                if (irIG.BobBueCant == null)
                {
                    irIG.BobBueCant = "0";
                    irIG.BobBueEsc = "0.0";
                    irIG.BobBueProm = "0.0";
                    irIG.BobBueProG = "0.00";
                }
                else
                {
                    irIG.BobBueProm = (Convert.ToDouble(irIG.BobBueEsc) / Convert.ToDouble(irIG.BobBueCant)).ToString("N1");
                    irIG.BobBueProG = ((Convert.ToDouble(irIG.BobBueCant) / Total) * 100).ToString("N2");
                }
                if (irIG.BobDetCant == null)
                {
                    irIG.BobDetCant = "0";
                    irIG.BobDetEsc = "0.0";
                    irIG.BobDetProm = "0.0";
                    irIG.BobDetProG = "0.00";
                }
                else
                {
                    irIG.BobDetProm = (Convert.ToDouble(irIG.BobDetEsc) / Convert.ToDouble(irIG.BobDetCant)).ToString("N1");
                    irIG.BobDetProG = ((Convert.ToDouble(irIG.BobDetCant) / Total) * 100).ToString("N2");
                }
                if (irIG.BobOtrCant == null)
                {
                    irIG.BobOtrCant = "0";
                    irIG.BobOtrEsc = "0.0";
                    irIG.BobOtrProm = "0.0";
                    irIG.BobOtrProG = "0.00";
                }
                else
                {
                    irIG.BobOtrProm = (Convert.ToDouble(irIG.BobOtrEsc) / Convert.ToDouble(irIG.BobOtrCant)).ToString("N1");
                    irIG.BobOtrProG = ((Convert.ToDouble(irIG.BobOtrCant) / Total) * 100).ToString("N2");
                }
                if (irIG.BobRotCant == null)
                {
                    irIG.BobRotCant = "0";
                    irIG.BobRotEsc = "0.0";
                    irIG.BobRotProm = "0.0";
                    irIG.BobRotProG = "0.00";
                }
                else
                {
                    irIG.BobRotProm = (Convert.ToDouble(irIG.BobRotEsc) / Convert.ToDouble(irIG.BobRotCant)).ToString("N1");
                    irIG.BobRotProG = ((Convert.ToDouble(irIG.BobRotCant) / Total) * 100).ToString("N2");
                }
                lista.Add(irIG);//General

            }
            con.CerrarConexion();
            return lista;
        }

        public List<Impreso> List_PliegosImp(string OT)
        {
            List<Impreso> lista = new List<Impreso>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "List_pliegimp";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Impreso imp = new Impreso();
                    imp.OT = reader["NumeroOT"].ToString();
                    imp.Maquina = reader["Maquina"].ToString();
                    imp.Operacion = reader["Descricao"].ToString();
                    int valocMaquina = Convert.ToInt32(reader["velocidademaquina"].ToString());
                    imp.valocMaquina = valocMaquina.ToString("N0").Replace(',', '.');
                    int velocTiraje = Convert.ToInt32(Convert.ToDouble(reader["velocidadtiraje"].ToString()));
                    imp.velocTiraje = velocTiraje.ToString("N0").Replace(',', '.');
                    DateTime Horas = new DateTime();
                    Horas = Horas.AddMinutes(Convert.ToDouble(reader["HorasT"].ToString()));

                    imp.Horas = Horas.ToString("HH:mm:ss");

                    int malas = Convert.ToInt32(reader["Malas"].ToString());
                    imp.Malas = malas.ToString("N0").Replace(',', '.');
                    int Desarrollo = Convert.ToInt32(reader["Producido"].ToString());
                    imp.Desarrollo = Desarrollo.ToString("N0").Replace(',', '.');
                    imp.IdAtiv = Convert.ToInt32(reader["IdAtiv"].ToString());
                    imp.Description = reader["Description"].ToString();
                    lista.Add(imp);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public int PesoOriginalTB(string FechaInicio, string FechaTermino = "")
        {
            int Peso = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bobina_TotalPeso";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@fechaTermino", FechaTermino);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Peso = Convert.ToInt32(Convert.ToDouble(reader["PesoOriginal"]).ToString());
                }

            }
            con.CerrarConexion();
            return Peso;
        }

        public Boolean ModificarCodigo(int Codigo, string OT, double PesoTapas, double PesoEscalpe, double PesoEnvoltura)
        {
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_Update_Bobina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pesotapas", PesoTapas);
                cmd.Parameters.AddWithValue("@PesoEsc", PesoEscalpe);
                cmd.Parameters.AddWithValue("@PesoEnv", PesoEnvoltura);
                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Bobina> List_ConsPapel(string OT, string CodigoBob, string Maquina, string TipoPapel, string FeInicio, string FeTermino, int proced)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_ControlConsumo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", OT);
                //cmd.Parameters.AddWithValue("", NombreOT);
                if (Maquina != "Todas")
                {
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Maquina", "");
                }
                cmd.Parameters.AddWithValue("@Marca", TipoPapel);
                cmd.Parameters.AddWithValue("@Codigo", CodigoBob);
                cmd.Parameters.AddWithValue("@FechaInicio", FeInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FeTermino);
                if (proced != 0)
                {
                    cmd.Parameters.AddWithValue("@Procedimiento", proced);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina bob = new Bobina();
                    bob.ID_Bobina = Convert.ToInt32(reader["ID_Bobina"].ToString());//ID_TablaSG
                    bob.Ubicacion = reader["Maquina"].ToString();//Maquina
                    bob.NumeroOp = reader["NumeroOp"].ToString();//OT
                    bob.Codigo = reader["Codigo_Bobina"].ToString();//Codigo_Bobina
                    bob.pliego = reader["Nombre_pliego"].ToString();//Pliego
                    bob.Marca = reader["Marca"].ToString();//Marca
                    bob.Ancho = Convert.ToInt32(reader["Ancho"].ToString());//Ancho
                    bob.Gramage = Convert.ToInt32(reader["Gramage"].ToString());//Gramage
                    bob.Lote = Convert.ToInt32(reader["PesoOrginal"].ToString()).ToString("N0").Replace(",", ".");//Peso Original
                    bob.Proveedor = Convert.ToInt32(reader["Saldo"].ToString()).ToString("N0").Replace(",", ".");//Saldo
                    double Tapas = Convert.ToDouble(reader["Peso_Tapas"].ToString());
                    string[] str = Tapas.ToString("N2").Split('.');
                    bob.Porc_Malas = Convert.ToDouble(str[0]).ToString("N0").Replace(",", ".") + "," + str[1];//Peso Tapas
                    double Envoltura = Convert.ToDouble(reader["Peso_Envoltorio"].ToString());
                    string[] str2 = Envoltura.ToString("N2").Split('.');
                    bob.Porc_Perdida = Convert.ToDouble(str2[0]).ToString("N0").Replace(",", ".") + "," + str2[1];//Peso emboltura
                    double Escarpe = Convert.ToDouble(reader["Peso_Escarpe"].ToString());
                    string[] str3 = Escarpe.ToString("N2").Split('.');
                    bob.Tipo = Convert.ToDouble(str3[0]).ToString("N0").Replace(",", ".") + "," + str3[1];  //Peso Escarpe 
                    double Cono = Convert.ToDouble(reader["Peso_Cono"].ToString());
                    string[] str4 = Cono.ToString("N2").Split('.');
                    bob.Cono = Convert.ToDouble(str4[0]).ToString("N0").Replace(",", ".") + "," + str4[1];//Peso Cono
                    if (reader["Cierre"].ToString() == "0")
                    {
                        bob.VerMas = "<a style='background:red;color:White;text-decoration:none;' href='javascript:openGame(\"" + bob.NumeroOp + "\",\"" + bob.ID_Bobina + "\",\"" + bob.pliego + "\")'>Editar</a>";
                    }
                    else
                    {
                        bob.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + bob.NumeroOp + "\",\"" + bob.ID_Bobina + "\",\"" + bob.pliego + "\")'>Editar</a>";
                    }

                    lista.Add(bob);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool ActualizarTipPap(Bobina bob, int Proced)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_ControlAct";
                cmd.Parameters.AddWithValue("@Procedimiento", Proced);
                if (Proced == 0)
                {
                    cmd.Parameters.AddWithValue("@Codigo", bob.Codigo);
                    cmd.Parameters.AddWithValue("@Proveedor", bob.Proveedor);
                    cmd.Parameters.AddWithValue("@Marca", bob.Marca);
                    cmd.Parameters.AddWithValue("@Tipo", bob.Tipo);
                    cmd.Parameters.AddWithValue("@Ubicacion", bob.Ubicacion);
                    cmd.Parameters.AddWithValue("@Lote", bob.Lote);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IDBobina", bob.ID_Bobina);
                    cmd.Parameters.AddWithValue("@PesoBruto", bob.Peso_Original);
                    cmd.Parameters.AddWithValue("@PesoTapa", bob.Peso_Tapa);
                    cmd.Parameters.AddWithValue("@PesoEmb", bob.Peso_emboltorio);
                    cmd.Parameters.AddWithValue("@PesoEsc", bob.PesoEscarpe);
                    cmd.Parameters.AddWithValue("@PesoCono", bob.Peso_Cono);
                    cmd.Parameters.AddWithValue("@Saldo", bob.Saldo);
                    cmd.Parameters.AddWithValue("@Maquina", bob.Ubicacion);
                    cmd.Parameters.AddWithValue("@OT", bob.NumeroOp);
                    cmd.Parameters.AddWithValue("@Pliego", bob.pliego);
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                }

            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Bobina> List_BodegaPerd(string OT, string Maquina, string Tipo, string feInicio, string feTermino)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bob_InfoPerdida";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ot", OT);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);
                    cmd.Parameters.AddWithValue("@FeInicio", feInicio);
                    cmd.Parameters.AddWithValue("@FeTermino", feTermino);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina bob = new Bobina();
                        bob.NumeroOp = reader["NumeroOP"].ToString();//OT
                        bob.pliego = reader["NombreOT"].ToString();//Nombre OT
                        bob.Tipo = reader["Tipo_Papel"].ToString();//Tipo
                        bob.Marca = reader["Maquina"].ToString();//Maquina
                        bob.Fecha_Consumo = Convert.ToDateTime(reader["Fecha_Consumo"].ToString());//Fecha
                        bob.Porc_Buenas = Convert.ToInt32(reader["PesoOrginal"].ToString()).ToString("N0").Replace(',', '.');//Peso Bruto
                        Double valorEsc = Convert.ToDouble(reader["Peso_Escarpe"].ToString());
                        Double valorCon = Convert.ToDouble(reader["Peso_Cono"].ToString());
                        Double valorSIm = Convert.ToDouble(reader["SinImpresion"].ToString());
                        string[] str1 = valorEsc.ToString("N2").Split('.');
                        string[] str2 = valorCon.ToString("N2").Split('.');
                        string[] str3 = valorSIm.ToString("N2").Split('.');

                        bob.Porc_Malas = Convert.ToDouble(str1[0]).ToString("N0").Replace(",", ".") + "," + str1[1];//Peso Escarpe
                        bob.Porc_Perdida = Convert.ToDouble(str2[0]).ToString("N0").Replace(",", ".") + "," + str2[1]; ;//Peso Cono
                        bob.Proveedor = Convert.ToDouble(str3[0]).ToString("N0").Replace(",", ".") + "," + str3[1]; ;//Peso SIMpresion
                        lista.Add(bob);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina> ListarPromEsc(string FInicio, string FTermino)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Bob_InfReg_Maquina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaIni", FInicio);
                cmd.Parameters.AddWithValue("@FechaTer", FTermino);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bobina b = new Bobina();
                    b.NumeroOp = reader["Maquina"].ToString();//MAquina
                    b.Lote = reader["Bruto"].ToString();
                    b.Marca = reader["Escarpe"].ToString();
                    b.Porc_Buenas = reader["PorcCProye"].ToString();//% con Proyecto
                    b.Porc_Malas = reader["PorcSProye"].ToString();//% sin Proyecto
                    lista.Add(b);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina> ListarOrigenesCorte()
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bob_ListarFalla_Corte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina b = new Bobina();
                        b.Lote = reader["Cat_Motivo_Corte"].ToString();//NombreOrigen
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina> ListarMotivoCorte(string TipoOrigen)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bob_ListarFalla_MotivoCorte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoOrigen", TipoOrigen);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina b = new Bobina();
                        b.Lote = reader["Nombre_Motivo"].ToString();//NombreOrigen
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public Boolean InsertMotivoCorte(Bobina bobina)
        {
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bob_InsertarFalla_MotivoCorte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBobina", bobina.Codigo);
                    cmd.Parameters.AddWithValue("@Origen", bobina.Proveedor);
                    cmd.Parameters.AddWithValue("@Usuario", bobina.VerMas);
                    cmd.Parameters.AddWithValue("@Motivo", bobina.pliego);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Bobina> Listar_Informe_fallaCorte(Bobina bob, string FechaRangoMin, string FechaRangoMax)
        {
            List<Bobina> lista = new List<Bobina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!=null)
            {
                try
                {
                    cmd.CommandText = "Bob_Informe_fallaCorte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", bob.NumeroOp);
                    cmd.Parameters.AddWithValue("@Codigo_Bobina", bob.Codigo);
                    cmd.Parameters.AddWithValue("@Maquina", bob.Lote);
                    cmd.Parameters.AddWithValue("@cat_Corte", bob.Marca);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaRangoMin);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaRangoMax);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina bobina = new Bobina();
                        bobina.NumeroOp = reader["OT"].ToString();
                        bobina.pliego = reader["Pliego"].ToString();
                        bobina.VerMas = reader["Maquina"].ToString();//Maquina
                        bobina.Lote = reader["Motivo_Corte"].ToString();//Motivo_Corte
                        bobina.Porc_Buenas = reader["Cat_Corte"].ToString();//Cat_Corte
                        bobina.Porc_Malas = reader["Proveedor"].ToString();//Proveedor
                        bobina.Codigo = reader["Codigo_Bobina"].ToString();
                        bobina.Gramage = Convert.ToInt32(reader["Gramage"].ToString());
                        bobina.Ancho = Convert.ToInt32(reader["Ancho"].ToString());
                        bobina.Tipo = reader["Tipo_Papel"].ToString();
                        bobina.Marca = reader["Marca"].ToString();
                        bobina.Ubicacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString()).ToString("dd-MM-yyyy HH:mm");//Fecha_Creacion
                        lista.Add(bobina);
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

        #region newConsumoDimen

        public string Bobina_Dimensionadora_SKU(string Folio)
        {
            string SKU = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliego_Dim_SKUSolicitado";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    SKU = reader["Sku"].ToString();
                }
            }
            con.CerrarConexion();
            return SKU;
        }

        public Boolean AgregarBobinaDimen(Bobina b, string Usuario, string Maquina, string SKU, string Folio)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_Dimensionadora_InsertBobina";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOP", b.NumeroOp);
                    cmd.Parameters.AddWithValue("@Codigo_Bobina", b.Codigo);
                    cmd.Parameters.AddWithValue("@Proveedor", b.Proveedor);
                    cmd.Parameters.AddWithValue("@Gramage", b.Gramage);
                    cmd.Parameters.AddWithValue("@Ancho", b.Ancho);
                    cmd.Parameters.AddWithValue("@Marca", b.Marca);
                    cmd.Parameters.AddWithValue("@Tipo_Papel", b.Tipo);
                    cmd.Parameters.AddWithValue("@PesoOrginal", b.Peso_Original);
                    cmd.Parameters.AddWithValue("@Peso_Tapas", b.Peso_Tapa);
                    cmd.Parameters.AddWithValue("@Peso_Envoltorio", b.Peso_emboltorio);
                    cmd.Parameters.AddWithValue("@Peso_Escarpe", b.PesoEscarpe);
                    cmd.Parameters.AddWithValue("@Estado_Bobina", b.Estado_Bobina);//Causa
                    cmd.Parameters.AddWithValue("@Responsable", b.Responsable);
                    cmd.Parameters.AddWithValue("@Pliego", b.pliego);
                    cmd.Parameters.AddWithValue("@Cierre", false);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@SKU",SKU);
                    cmd.Parameters.AddWithValue("@Folio", Folio);

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
            con.CerrarConexion();
            return respuesta;
        }

        #endregion
    }
}