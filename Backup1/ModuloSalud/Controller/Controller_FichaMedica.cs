using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloSalud.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloSalud.Controller
{
    public class Controller_FichaMedica
    {
        public FichaMedica BuscarPacienteRut(string Rut, int Procedimiento)
        {
            FichaMedica fm = new FichaMedica();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_BuscarPaciente";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rut", Rut);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (Procedimiento == 0)
                        {
                            string[] stg = reader["nombre"].ToString().Split(' ');
                            fm.Nombre = stg[0];
                            fm.NombreSeg = stg[1];
                            fm.ApellidoPaterno = reader["ape_paterno_trabaj"].ToString();
                            fm.ApellidoMaterno = reader["ape_materno_trabaj"].ToString();
                            fm.CentroCosto = reader["centro_costo"].ToString();
                            fm.Cargo = reader["Cargo"].ToString();
                            fm.Telefono = reader["telefono"].ToString().Trim();
                            fm.Direccion = reader["direccion"].ToString().Trim();
                            fm.Comuna = reader["Comuna"].ToString().Trim();
                            fm.Jornada = reader["jornada"].ToString().Trim();
                            switch (reader["cod_estado_civil"].ToString())
                            {
                                case "C": fm.EstadoCivil = "Casado(a)"; break;
                                case "S": fm.EstadoCivil = "Soltero(a)"; break;
                                case "V": fm.EstadoCivil = "Viudo(a)"; break;
                                default: fm.EstadoCivil = "Separado(a)"; break;
                            }
                            fm.FechaNacimiento = Convert.ToDateTime(reader["fec_nacimiento"].ToString());
                            fm.FechaIngreso = Convert.ToDateTime(reader["fec_ini_contrato"].ToString());
                            fm.Sexo = reader["sexo"].ToString();
                            fm.Correo = reader["casilla_e_mail"].ToString();
                        }
                        else if (Procedimiento == 1)
                        {
                            fm.IDFichaMedica = Convert.ToInt32(reader["Id_FichaMedica"].ToString());
                            fm.Nombre = reader["Nombre_Primer"].ToString();
                            fm.ApellidoPaterno = reader["Apellido_Paterno"].ToString();
                            fm.ApellidoMaterno = reader["Apellido_Materno"].ToString();
                            fm.Sexo = reader["Sexo"].ToString();
                            fm.FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"].ToString());
                            fm.EstadoCivil = reader["Estado_Civil"].ToString();
                            fm.Telefono = reader["Telefono"].ToString();
                            fm.Anexo = reader["Anexo"].ToString();
                            fm.Correo = reader["CorreoElectronico"].ToString();
                            fm.Direccion = reader["Direccion"].ToString();
                            fm.Comuna = reader["Comuna"].ToString();
                            fm.Transporte = reader["TipoTransporte"].ToString();
                            fm.Accion = reader["Empresa"].ToString();
                            fm.Cargo = reader["Cargo_Actual"].ToString();
                            fm.Fiebre = reader["Turno"].ToString();
                            fm.FechaIngreso = Convert.ToDateTime(reader["Antig_Empresa"].ToString());
                            fm.Edad = DateTime.Now.Year - Convert.ToDateTime(reader["Antig_cargo"].ToString()).Year;
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return fm;
        }

        public int GuardarFicha(string Rut, string Telefono, DateTime FechaAntiguedad, string EstadoCivil, string TipoTransporte, string Empresa, string Usuario, string Correo, string Anexo)
        {
            int respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_FichaMedica_insertar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut.Substring(0,Rut.Length-1));
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@AntiguiedadCargo", FechaAntiguedad);
                    cmd.Parameters.AddWithValue("@Estado_Civil", EstadoCivil);
                    cmd.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
                    cmd.Parameters.AddWithValue("@Empresa", Empresa);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Correo",Correo);
                    cmd.Parameters.AddWithValue("@Anexo", Anexo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        respuesta = Convert.ToInt32(reader["Respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<FichaMedica> ListarFichasMedicas(string Rut, string Apellido)
        {
            List<FichaMedica> lista = new List<FichaMedica>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!=null)
            {
                try
                {
                    cmd.CommandText = "Salud_ListarFichaMedica";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FichaMedica fm = new FichaMedica();
                        fm.IDFichaMedica = Convert.ToInt32(reader["Id_FichaMedica"].ToString());
                        fm.Nombre = reader["Nombre"].ToString();
                        fm.Rut = reader["rut"].ToString();
                        fm.Sexo = reader["Sexo"].ToString();
                        fm.Edad = DateTime.Now.Year - Convert.ToDateTime(reader["Fecha_Nacimiento"].ToString()).Year;
                        fm.Comuna = reader["Comuna"].ToString();
                        fm.Transporte = reader["TipoTransporte"].ToString();
                        fm.Fuma = reader["Fuma"].ToString();
                        fm.Bebe = reader["Bebe"].ToString();
                        fm.Drogas = reader["Drogas"].ToString();
                        fm.Accion = "<a style='Color:Blue;text-decoration:none;' href='javascript:openPopup(\"" + fm.Rut + "\",\"" + 1 + "\")'>Editar</a>";
                        lista.Add(fm);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public int GuardarAntecedentesMedicos(FichaMedica fmPaciente)
        {
            int respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_AntecedentesMedicos_Insertar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Ficha", fmPaciente.IDFichaMedica);
                    cmd.Parameters.AddWithValue("@Fuma", fmPaciente.Fuma);
                    cmd.Parameters.AddWithValue("@Bebe", fmPaciente.Bebe);
                    cmd.Parameters.AddWithValue("@Droga", fmPaciente.Drogas);
                    cmd.Parameters.AddWithValue("@Fisica", fmPaciente.ActividadFisica);
                    cmd.Parameters.AddWithValue("@Medicamento_Alergia", fmPaciente.Medicamento_Alergia);
                    cmd.Parameters.AddWithValue("@Alimento_Alergia", fmPaciente.Alimento_Alergia);
                    cmd.Parameters.AddWithValue("@Lentes", fmPaciente.Lentes);
                    cmd.Parameters.AddWithValue("@Audifonos", fmPaciente.Audifonos);
                    cmd.Parameters.AddWithValue("@Protesis", fmPaciente.Protesis);
                    cmd.Parameters.AddWithValue("@Plantillas", fmPaciente.Plantillas);
                    cmd.Parameters.AddWithValue("@Medicamentos", fmPaciente.Medicamentos);
                    cmd.Parameters.AddWithValue("@Intervenciones", fmPaciente.Intervenciones);
                    cmd.Parameters.AddWithValue("@enfermedad", fmPaciente.Enfermedad);
                    cmd.Parameters.AddWithValue("@Dermatitis", fmPaciente.Dermatitis);
                    cmd.Parameters.AddWithValue("@Varices", fmPaciente.Varices);
                    cmd.Parameters.AddWithValue("@Epilepsia", fmPaciente.Epilepsia);
                    cmd.Parameters.AddWithValue("@Sueño", fmPaciente.Sueño);
                    cmd.Parameters.AddWithValue("@Sangre", fmPaciente.Sangre);
                    cmd.Parameters.AddWithValue("@Neumonia", fmPaciente.Neumonia);
                    cmd.Parameters.AddWithValue("@Bronquitis", fmPaciente.Bronquitis);
                    cmd.Parameters.AddWithValue("@Ulceras", fmPaciente.Ulceras);
                    cmd.Parameters.AddWithValue("@TBC", fmPaciente.TBC);
                    cmd.Parameters.AddWithValue("@Hepatitis", fmPaciente.Hepatitis);
                    cmd.Parameters.AddWithValue("@Asma", fmPaciente.Asma);
                    cmd.Parameters.AddWithValue("@Diabetes", fmPaciente.Diabetes);
                    cmd.Parameters.AddWithValue("@Fiebre", fmPaciente.Fiebre);
                    cmd.Parameters.AddWithValue("@Hipertension", fmPaciente.Hipertension);
                    cmd.Parameters.AddWithValue("@Lumbalgias", fmPaciente.Lumbalgias);
                    cmd.Parameters.AddWithValue("@Tendinitis", fmPaciente.Tendinitis);
                    cmd.Parameters.AddWithValue("@Observacion", fmPaciente.Accion);
                    cmd.Parameters.AddWithValue("@Usuario", fmPaciente.Nombre);
                    cmd.Parameters.AddWithValue("@FumaCant", fmPaciente.FumaCant);
                    cmd.Parameters.AddWithValue("@FumaDescript", fmPaciente.FumaDescript);
                    cmd.Parameters.AddWithValue("@BebeCant", fmPaciente.BebeCant);
                    cmd.Parameters.AddWithValue("@BebeDescript", fmPaciente.BebeDescript);
                    cmd.Parameters.AddWithValue("@DrogasCant", fmPaciente.DrogasCant);
                    cmd.Parameters.AddWithValue("@DrogasCantDescript", fmPaciente.DrogasCantDescript);
                    cmd.Parameters.AddWithValue("@ActFCant", fmPaciente.ActFCant);
                    cmd.Parameters.AddWithValue("@ActFCantDescript", fmPaciente.ActFCantDescript);
                    cmd.Parameters.AddWithValue("@TipoAccidente", fmPaciente.TipoAccidente);
                    cmd.Parameters.AddWithValue("@polvo", fmPaciente.polvo);
                    cmd.Parameters.AddWithValue("@impacto", fmPaciente.impacto);
                    cmd.Parameters.AddWithValue("@permanente", fmPaciente.permanente);
                    cmd.Parameters.AddWithValue("@solvente", fmPaciente.solvente);
                    cmd.Parameters.AddWithValue("@mmc", fmPaciente.mmc);
                    cmd.Parameters.AddWithValue("@sefp", fmPaciente.sefp);
                    cmd.Parameters.AddWithValue("@asmagenos", fmPaciente.asmagenos);
                    cmd.Parameters.AddWithValue("@calor",fmPaciente.calor);
                    cmd.Parameters.AddWithValue("@ionizante",fmPaciente.ionizante);
                    cmd.Parameters.AddWithValue("@metales",fmPaciente.metales);
                    cmd.Parameters.AddWithValue("@humo",fmPaciente.humo);
                    cmd.Parameters.AddWithValue("@electromag",fmPaciente.electromag);
                    cmd.Parameters.AddWithValue("@riesgos",fmPaciente.riesgos);
                    cmd.Parameters.AddWithValue("@Eco", fmPaciente.Eco);
                    cmd.Parameters.AddWithValue("@EcoFecha", fmPaciente.EcoFecha);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        respuesta = Convert.ToInt32(reader["Respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return respuesta;
        }

        public bool GuardarConsulta(Antecedentes_Medicos Paciente)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_AntecedentesMedicos_Agregar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFichaMedica", Paciente.IDFichaMedica);
                    cmd.Parameters.AddWithValue("@Pulso", Paciente.Pulso);
                    cmd.Parameters.AddWithValue("@Peso", Paciente.Peso);
                    cmd.Parameters.AddWithValue("@Mamografia", Paciente.Mamografia);
                    cmd.Parameters.AddWithValue("@Mamografia_fecha", Paciente.FechaMamografia);
                    cmd.Parameters.AddWithValue("@PresionArterial", Paciente.PresionArterial);
                    cmd.Parameters.AddWithValue("@Talla", Paciente.Talla);
                    cmd.Parameters.AddWithValue("@Pap", Paciente.Pap);
                    cmd.Parameters.AddWithValue("@PapaFecha", Paciente.FechaPap);
                    cmd.Parameters.AddWithValue("@Cabeza_Cuello", Paciente.Examen_CabezaCuello);
                    cmd.Parameters.AddWithValue("@Torax", Paciente.Examen_Torax);
                    cmd.Parameters.AddWithValue("@Abdomen", Paciente.Examen_Abdomen);
                    cmd.Parameters.AddWithValue("@Urogenital", Paciente.Examen_Urogenital);
                    cmd.Parameters.AddWithValue("@Extre_Sup", Paciente.Extre_Superior);
                    cmd.Parameters.AddWithValue("@Extre_Inf", Paciente.Extre_Inferior);
                    cmd.Parameters.AddWithValue("@Columna", Paciente.Columna);
                    cmd.Parameters.AddWithValue("@Diag_Comun", Paciente.Diagnostico_Comun);
                    cmd.Parameters.AddWithValue("@Diag_Laboral", Paciente.Diagnostico_Laboral);
                    cmd.Parameters.AddWithValue("@Diag_Tratamiento", Paciente.Diagnostico_Tratamiento);
                    cmd.Parameters.AddWithValue("@Diag_Recomendacion", Paciente.Diagnostico_Recomdacion);
                    cmd.Parameters.AddWithValue("@UsuarioCreador", Paciente.UsuarioCreador);
                    cmd.Parameters.AddWithValue("@RxTorax", Paciente.Torax);
                    cmd.Parameters.AddWithValue("@Osea", Paciente.Osea);
                    cmd.Parameters.AddWithValue("@Cavidades", Paciente.Cavidades);
                    cmd.Parameters.AddWithValue("@TAC", Paciente.TAC);
                    cmd.Parameters.AddWithValue("@RNM", Paciente.RNM);
                    cmd.Parameters.AddWithValue("@EEG", Paciente.EEG);
                    cmd.Parameters.AddWithValue("@ECG", Paciente.ECG);
                    cmd.Parameters.AddWithValue("@ECARDG", Paciente.ECARDG);
                    cmd.Parameters.AddWithValue("@EMG", Paciente.EMG);
                    cmd.Parameters.AddWithValue("@Laboratorio", Paciente.Laboratorio);
                    cmd.Parameters.AddWithValue("@ID_Ant_Generales", Paciente.IDAntMedicos);
                    
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

        public List<Antecedentes_Medicos> ListarConsultasMedicas(string Rut, string Apellido)
        {
            List<Antecedentes_Medicos> lista = new List<Antecedentes_Medicos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_Consulta_Listar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Antecedentes_Medicos fm = new Antecedentes_Medicos();
                        fm.IDFichaMedica = Convert.ToInt32(reader["Id_FichaMedica"].ToString());
                        fm.Talla = reader["Nombre"].ToString();
                        fm.Diagnostico_Comun = reader["DiagComun"].ToString();
                        fm.FechaConsulta = Convert.ToDateTime(reader["Fecha_Consulta"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        fm.Diagnostico_Tratamiento = reader["Diagnostico_Tratamiento"].ToString();
                        fm.Peso = reader["Peso"].ToString();
                        fm.Pulso = reader["Pulso"].ToString();
                        fm.PresionArterial = reader["PresionArterial"].ToString();
                        fm.UsuarioCreador = reader["Usuario_Creador"].ToString();
                        fm.Examen_CabezaCuello = "<a style='Color:Blue;text-decoration:none;' href='javascript:openConsulta(\"" + Rut + "\",\"" + reader["Id_AntecedentesMedicos"].ToString() + "\")'>Ver Más</a>";
                        lista.Add(fm);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool GuardarControl(int IdFicha, string Fecha)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_Controles_Agregar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFicha",IdFicha);
                    cmd.Parameters.AddWithValue("@Fecha",Fecha);
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

        public List<FichaMedica> ListarControles(string Rut, string Apellido)
        {
            List<FichaMedica> lista = new List<FichaMedica>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Salud_ListarControl";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FichaMedica fm = new FichaMedica();
                        fm.IDFichaMedica = Convert.ToInt32(reader["Id_FichaMedica"].ToString());
                        fm.Nombre = reader["Nombre"].ToString();
                        fm.Fuma = Convert.ToDateTime(reader["Fecha_Control"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        fm.Comuna = reader["Diagnostico_Comun"].ToString();
                        fm.Transporte = reader["Diagnostico_Tratamiento"].ToString();
                        lista.Add(fm);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public FichaMedica BuscarConsultaPaciente(string ID)
        {
            FichaMedica Paciente = new FichaMedica();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "salud_BuscarConsultaPaciente";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID",ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Paciente.Accion = reader["Id_AntecedentesMedicos"].ToString();
                        Paciente.Fuma = reader["Habito_Fumar"].ToString();
                        if(Paciente.Fuma!="No")
                        {
                            Paciente.FumaCant = reader["FumaCant"].ToString();
                            Paciente.FumaDescript = reader["FumaDescript"].ToString();
                        }
                        Paciente.Bebe = reader["Habito_Bebe"].ToString();
                        if(Paciente.Bebe!="No")
                        {
                            
                            Paciente.BebeCant = reader["BebeCant"].ToString();
                            Paciente.BebeDescript = reader["BebeDescript"].ToString();
                        }
                        Paciente.Drogas = reader["Habito_Drogas"].ToString();
                        if (Paciente.Drogas != "No")
                        {
                            Paciente.DrogasCant = reader["DrogasCant"].ToString();
                            Paciente.DrogasCantDescript = reader["DrogasCantdescript"].ToString();
                        }
                        Paciente.ActFCant = reader["Habito_Act_Fisica"].ToString();
                        if (Paciente.ActFCant != "No")
                        {
                            Paciente.ActFCant = reader["ActFCant"].ToString();
                            Paciente.ActFCantDescript = reader["ActFcantDescript"].ToString();
                        }
                        Paciente.Medicamento_Alergia = reader["Med_alergia"].ToString();
                        Paciente.Alimento_Alergia = reader["Alimentos_alergia"].ToString();
                        Paciente.Lentes = reader["Lentes"].ToString();
                        Paciente.Audifonos = reader["Audifonos"].ToString();
                        Paciente.Protesis = reader["Protesis"].ToString();
                        Paciente.Plantillas = reader["Plantillas_Ortopedica"].ToString();
                        Paciente.Medicamentos = reader["Medicamentos"].ToString();
                        Paciente.TipoAccidente = reader["TipoAccidente"].ToString();
                        Paciente.polvo = reader["polvo"].ToString();
                        Paciente.impacto = reader["impacto"].ToString();
                        Paciente.permanente = reader["permanente"].ToString();
                        Paciente.solvente = reader["solvente"].ToString();
                        Paciente.mmc = reader["mmc"].ToString();
                        Paciente.sefp = reader["sefp"].ToString();
                        Paciente.asmagenos = reader["asmagenos"].ToString();
                        Paciente.calor = reader["calor"].ToString();
                        Paciente.ionizante = reader["ionizante"].ToString();
                        Paciente.metales = reader["metales"].ToString();
                        Paciente.humo = reader["humo"].ToString();
                        Paciente.electromag = reader["electromag"].ToString();
                        Paciente.riesgos = reader["riesgos"].ToString();
                        Paciente.Intervenciones = reader["Intervenciones_quirurgicas"].ToString();
                        Paciente.Enfermedad = reader["Enfermedad_Importante"].ToString();
                        Paciente.Dermatitis = reader["Dermatitis"].ToString();
                        Paciente.Varices = reader["Varices"].ToString();
                        Paciente.Epilepsia = reader["Epilepsia"].ToString();
                        Paciente.Sueño = reader["Transtorno_Sueño"].ToString();
                        Paciente.Sangre = reader["Alteraciones_Sangre"].ToString();
                        Paciente.Neumonia = reader["Neumonia"].ToString();
                        Paciente.Bronquitis = reader["Bronquitis_Cronica"].ToString();
                        Paciente.Ulceras = reader["Ulceras_Gastricas"].ToString();
                        Paciente.TBC = reader["TBC"].ToString();
                        Paciente.Hepatitis = reader["Hepatitis"].ToString();
                        Paciente.Asma = reader["Asma"].ToString();
                        Paciente.Diabetes = reader["Diabetes_Mellitus"].ToString();
                        Paciente.Fiebre = reader["Fiebre_Tofoidea"].ToString();
                        Paciente.Hipertension = reader["Hipertension_Arterial"].ToString();
                        Paciente.Lumbalgias = reader["Lumbalgias"].ToString();
                        Paciente.Tendinitis = reader["Tendinitis"].ToString();
                        Paciente.Observacion = reader["Observacion"].ToString();

                        Paciente.Nombre = reader["Diagnostico_Tratamiento"].ToString();//Diagnostico_Tratamiento
                        Paciente.Rut = reader["Diagnostico_Recomendacion"].ToString();//Diagnostico_Recomendacion
                        Paciente.FechaNacimiento = Convert.ToDateTime(reader["FechaMamografia"].ToString());//FechaMamografia
                        Paciente.FechaIngreso = Convert.ToDateTime(reader["FechaPap"].ToString());//FechaPap
                        Paciente.NombreSeg = reader["PresionArterial"].ToString();//PresionArterial
                        Paciente.ApellidoPaterno = reader["Laboratorio"].ToString();//Laboratorio
                        Paciente.ApellidoMaterno = reader["Examen_CabezaCuello"].ToString();//Examen_CabezaCuello
                        Paciente.Cargo = reader["Examen_Torax"].ToString();//Examen_Torax
                        Paciente.CentroCosto = reader["Examen_Abdomen"].ToString();//Examen_Abdomen
                        Paciente.Telefono = reader["Examen_Urogenital"].ToString();//Examen_Urogenital
                        Paciente.Direccion = reader["Examen_Extre_Sup"].ToString();//Examen_Extre_Sup
                        Paciente.Comuna = reader["Examen_Extre_Inf"].ToString();//Examen_Extre_Inf
                        Paciente.Jornada = reader["Examen_Columna"].ToString();//Examen_Columna
                        Paciente.EstadoCivil = reader["Diagnostico_Comun"].ToString();//Diagnostico_Comun
                        Paciente.Sexo = reader["Sexo"].ToString();
                        Paciente.Transporte = reader["Diagnostico_Laboral"].ToString();//Diagnostico_Laboral
                        Paciente.Anexo = reader["RxTorax"].ToString() + "*" + reader["RxOsea"].ToString() + "*" + reader["Rxcavidades"].ToString() +"*"+ reader["TAC"].ToString() + "*" + reader["RNM"].ToString() + "*" + reader["EEG"].ToString() +
                                    "*" + reader["ECG"].ToString() + "*" + reader["ECARDG"].ToString() + "*" + reader["EMG"].ToString() + "*" + reader["pulso"].ToString() + "*" + reader["peso"].ToString() + "*" + reader["Talla"].ToString();
                        Paciente.IDFichaMedica = Convert.ToInt32(reader["ID_Ficha"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return Paciente;
        }
    }
}