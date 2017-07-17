using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloSalud.Controller;
using Intranet.ModuloSalud.Model;

namespace Intranet.ModuloSalud.View
{
    public partial class Consulta_Medica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rut = Request.QueryString["rut"].ToString();
                Controller_FichaMedica controlfm = new Controller_FichaMedica();
                FichaMedica fm = controlfm.BuscarPacienteRut(rut, 1);
                lblIdFichaMedica.Text = fm.IDFichaMedica.ToString();
                try
                {
                    string ID = Request.QueryString["nro"].ToString();
                    if (ID != "")
                    {
                        string popupScript4 = "<script language='JavaScript'>BuscarPaciente(" + ID + ");</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript4);
                    }
                }
                catch
                {
                    string popupScript4 = "<script language='JavaScript'>SexualidadPaciente('" + fm.Sexo + "');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
            }
        }

        [WebMethod]
        public static string[] GuardarConsulta(string IDFichaMedica, string Fuma, string Bebe, string Drogas, string ActividadFisica, string Medicamento_Alergia, string Alimento_Alergia,string Lentes
                                    ,string Audifonos,string Protesis,string Plantillas,string Medicamentos,string Intervenciones,string Enfermedad,string Dermatitis,string Varices,string Epilepsia
                                    , string Sueño, string Sangre, string Neumonia, string Bronquitis, string Ulceras, string TBC, string Hepatitis, string Asma, string Diabetes, string Fiebre
                                    , string Hipertension, string Lumbalgias, string Tendinitis, string Observacion, string UsuarioCreador, string FumaCant, string FumaDescript, string BebeCant
                                    , string BebeDescript, string DrogasCant, string DrogasCantDescript, string ActFCant, string ActFCantDescript, string TipoAccidente, string polvo, string impacto
                                    , string permanente, string solvente, string mmc, string sefp, string asmagenos, string calor, string ionizante, string metales, string humo, string electromag
                                    , string riesgos , string ddlEco, string txtEcoFecha)
        {
            string resultado = "";
            Controller_FichaMedica controlMedico = new Controller_FichaMedica();
            FichaMedica fmPaciente = new FichaMedica();
            fmPaciente.IDFichaMedica = Convert.ToInt32(IDFichaMedica);
            fmPaciente.Fuma = Fuma;
            fmPaciente.Bebe = Bebe;
            fmPaciente.Drogas = Drogas;
            fmPaciente.ActividadFisica = ActividadFisica;
            fmPaciente.Medicamento_Alergia = Medicamento_Alergia;
            fmPaciente.Alimento_Alergia = Alimento_Alergia;
            fmPaciente.Lentes= Lentes;
            fmPaciente.Audifonos = Audifonos;
            fmPaciente.Protesis = Protesis;
            fmPaciente.Plantillas = Plantillas;
            fmPaciente.Medicamentos = Medicamentos;
            fmPaciente.Intervenciones = Intervenciones;
            fmPaciente.Enfermedad = Enfermedad;
            fmPaciente.Dermatitis = Dermatitis;
            fmPaciente.Varices = Varices;
            fmPaciente.Epilepsia = Epilepsia;
            fmPaciente.Sueño = Sueño;
            fmPaciente.Sangre = Sangre;
            fmPaciente.Neumonia = Neumonia;
            fmPaciente.Bronquitis = Bronquitis;
            fmPaciente.Ulceras = Ulceras;
            fmPaciente.TBC = TBC;
            fmPaciente.Hepatitis = Hepatitis;
            fmPaciente.Asma = Asma;
            fmPaciente.Diabetes = Diabetes;
            fmPaciente.Fiebre = Fiebre;
            fmPaciente.Hipertension = Hipertension;
            fmPaciente.Lumbalgias = Lumbalgias;
            fmPaciente.Tendinitis = Tendinitis;
            fmPaciente.Accion = Observacion;
            fmPaciente.Nombre = UsuarioCreador;
            fmPaciente.FumaCant = FumaCant;
            fmPaciente.FumaDescript = FumaDescript;
            fmPaciente.BebeCant = BebeCant;
            fmPaciente.BebeDescript = BebeDescript;
            fmPaciente.DrogasCant = DrogasCant;
            fmPaciente.DrogasCantDescript = DrogasCantDescript;
            fmPaciente.ActFCant = ActFCant;
            fmPaciente.ActFCantDescript = ActFCantDescript;
            fmPaciente.TipoAccidente = TipoAccidente;
            fmPaciente.polvo = polvo;
            fmPaciente.impacto = impacto;
            fmPaciente.permanente = permanente;
            fmPaciente.solvente = solvente;
            fmPaciente.mmc = mmc;
            fmPaciente.sefp = sefp;
            fmPaciente.asmagenos = asmagenos;
            fmPaciente.calor = calor;
            fmPaciente.ionizante = ionizante;
            fmPaciente.metales = metales;
            fmPaciente.humo = humo;
            fmPaciente.electromag = electromag;
            fmPaciente.riesgos = riesgos;
            fmPaciente.Eco = ddlEco;
            fmPaciente.EcoFecha = txtEcoFecha;

            int resultadoID = controlMedico.GuardarAntecedentesMedicos(fmPaciente);
            if (resultadoID>0)
            {
                resultado = "OK";
            }
            return new[] {resultado, resultadoID.ToString()};
        }


        [WebMethod]
        public static string GuardarConsultaPaciente(string IDFichaMedica,string Pulso, string Peso, string Mamografia, string FechaMamografia, string PresionArterial,string Talla,string Pap,
                            string FechaPap,string Examen_CabezaCuello,string Examen_Torax,string Examen_Abdomen,string Examen_Urogenital,string Extre_Superior,string Extre_Inferior,
                            string Columna,string Diagnostico_Comun,string Diagnostico_Laboral,string Diagnostico_Tratamiento,string Diagnostico_Recomdacion, string UsuarioCreador,
                            string FechaControl, string HoraControl, string Torax, string Osea, string Cavidades, string TAC, string RNM, string EEG, string ECG, string ECARDG, string EMG, string Laboratorio, string IDAntMedicos)
        {
            string resultado = "";
            Controller_FichaMedica controlMedico = new Controller_FichaMedica();
            Antecedentes_Medicos Paciente = new Antecedentes_Medicos();
            Paciente.IDFichaMedica = Convert.ToInt32(IDFichaMedica);
            Paciente.Pulso = Pulso;
            Paciente.Peso = Peso;
            Paciente.Mamografia = Mamografia;
            if (FechaMamografia != "")
            {
                Paciente.FechaMamografia = Convert.ToDateTime(FechaMamografia);
            }
            else
            {
                Paciente.FechaMamografia = Convert.ToDateTime("1900-01-01");
            }
            Paciente.PresionArterial = PresionArterial;
            Paciente.Talla = Talla;
            Paciente.Pap = Pap;
            if (FechaPap != "")
            {
                Paciente.FechaPap = Convert.ToDateTime(FechaPap);
            }
            else
            {
                Paciente.FechaPap = Convert.ToDateTime("1900-01-01");
            }
            Paciente.Examen_CabezaCuello = Examen_CabezaCuello;
            Paciente.Examen_Torax = Examen_Torax;
            Paciente.Examen_Abdomen = Examen_Abdomen;
            Paciente.Examen_Urogenital = Examen_Urogenital;
            Paciente.Extre_Superior = Extre_Superior;
            Paciente.Extre_Inferior = Extre_Inferior;
            Paciente.Columna = Columna;
            Paciente.Diagnostico_Comun = Diagnostico_Comun;
            Paciente.Diagnostico_Laboral = Diagnostico_Laboral;
            Paciente.Diagnostico_Tratamiento = Diagnostico_Tratamiento;
            Paciente.Diagnostico_Recomdacion = Diagnostico_Recomdacion;
            Paciente.UsuarioCreador = UsuarioCreador;
            Paciente.Torax = Torax;
            Paciente.Osea = Osea;
            Paciente.Cavidades = Cavidades;
            Paciente.TAC = TAC;
            Paciente.RNM = RNM;
            Paciente.EEG = EEG;
            Paciente.ECG = ECG;
            Paciente.ECARDG = ECARDG;
            Paciente.EMG = EMG;
            Paciente.Laboratorio = Laboratorio;
            Paciente.IDAntMedicos = Convert.ToInt32(IDAntMedicos);

            if (controlMedico.GuardarConsulta(Paciente))
            {
                if (FechaControl != "" && HoraControl != "")
                {
                    string[] split = FechaControl.Split('-');
                    string Fecha = split[2]+"-"+split[1]+"-"+split[0] + " " + HoraControl + ":00";
                    if (controlMedico.GuardarControl(Paciente.IDFichaMedica, Fecha))
                    {
                        resultado = "OK";
                    }
                }
                else
                {
                    resultado = "OK";
                }
            }
            return resultado;
        }

        [WebMethod]
        public static string[] BuscarConsulta(string ID)
        {
            Controller_FichaMedica controlficha = new Controller_FichaMedica();
            FichaMedica consulta = controlficha.BuscarConsultaPaciente(ID);
            if (consulta.Accion != "")
            {
                string[] datos = consulta.Anexo.Split('*');
                return new[] { consulta.Fuma,consulta.FumaCant,consulta.FumaDescript, consulta.Bebe, consulta.BebeCant, consulta.BebeDescript, consulta.Drogas, consulta.DrogasCant, consulta.DrogasCantDescript,
                        consulta.ActividadFisica,consulta.ActFCant,consulta.ActFCantDescript,consulta.Medicamento_Alergia, consulta.Alimento_Alergia, consulta.Lentes, consulta.Audifonos, consulta.Protesis, 
                        consulta.Plantillas, consulta.Medicamentos, consulta.TipoAccidente, consulta.polvo, consulta.impacto, consulta.permanente, consulta.solvente, consulta.mmc, consulta.sefp, consulta.asmagenos,
                        consulta.calor, consulta.ionizante, consulta.metales, consulta.humo, consulta.electromag, consulta.riesgos, consulta.Intervenciones, consulta.Enfermedad, consulta.Dermatitis, consulta.Varices,
                        consulta.Epilepsia, consulta.Sueño, consulta.Sangre, consulta.Neumonia, consulta.Bronquitis, consulta.Ulceras, consulta.TBC, consulta.Hepatitis, consulta.Asma, consulta.Diabetes, consulta.Fiebre,
                        consulta.Hipertension, consulta.Lumbalgias, consulta.Tendinitis, consulta.Observacion, consulta.Nombre, consulta.Rut, consulta.FechaNacimiento.ToString("dd-MM-yyyy"), 
                        consulta.FechaIngreso.ToString("dd-MM-yyyy"), consulta.NombreSeg, consulta.ApellidoPaterno, consulta.ApellidoMaterno, consulta.Cargo, consulta.CentroCosto, consulta.Telefono, consulta.Direccion,
                        consulta.Comuna, consulta.Jornada, consulta.EstadoCivil, consulta.Sexo, consulta.Transporte, datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], datos[7], datos[8], datos[9], datos[10], datos[11], consulta.IDFichaMedica.ToString()};
            }
            else
            {
                return new[] { "" };
            }
        }

        

    }
}