using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloSalud.Model
{
    public class FichaMedica
    {
        public int IDFichaMedica { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string NombreSeg { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaAntiguedad { get; set; }
        public string Cargo { get; set; }
        public string CentroCosto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Jornada { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string Transporte { get; set; }
        public string Correo { get; set; }
        public string Anexo { get; set; }
        public string Accion { get; set; }

        #region AntecedentesMedicos
        public string Fuma { get; set; }
        public string Bebe{ get; set; }
        public string Drogas { get; set; }
        public string ActividadFisica { get; set; }
        public string Medicamento_Alergia { get; set; }
        public string Alimento_Alergia { get; set; }
        public string Lentes { get; set; }
        public string Audifonos { get; set; }
        public string Protesis { get; set; }
        public string Plantillas { get; set; }
        public string Medicamentos { get; set; }
        public string Intervenciones { get; set; }
        public string Enfermedad { get; set; }
        public string Dermatitis { get; set; }
        public string Varices { get; set; }
        public string Epilepsia { get; set; }
        public string Sueño { get; set; }
        public string Sangre { get; set; }
        public string Neumonia { get; set; }
        public string Bronquitis { get; set; }
        public string Ulceras { get; set; }
        public string TBC { get; set; }
        public string Hepatitis { get; set; }
        public string Asma { get; set; }
        public string Diabetes { get; set; }
        public string Fiebre { get; set; }
        public string Hipertension { get; set; }
        public string Lumbalgias { get; set; }
        public string Tendinitis { get; set; }
        public string Observacion { get; set; }

        public string FumaCant { get; set; }
        public string FumaDescript { get; set; }
        public string BebeCant { get; set; }
        public string BebeDescript { get; set; }
        public string DrogasCant { get; set; }
        public string DrogasCantDescript { get; set; }
        public string ActFCant { get; set; }
        public string ActFCantDescript { get; set; }
        public string TipoAccidente { get; set; }
        public string polvo { get; set; }
        public string impacto { get; set; }
        public string permanente { get; set; }
        public string solvente { get; set; }
        public string mmc { get; set; }
        public string sefp { get; set; }
        public string asmagenos { get; set; }

        public string calor { get; set; }
        public string ionizante { get; set; }
        public string metales { get; set; }
        public string humo { get; set; }
        public string electromag { get; set; }
        public string riesgos { get; set; }
        public string Eco { get; set; }
        public string EcoFecha { get; set; }
        #endregion



    }
}