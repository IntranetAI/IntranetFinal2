using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloSalud.Model
{
    public class Antecedentes_Medicos
    {
        public int IDFichaMedica { get; set; }
        public string Pulso { get; set; }
        public string Peso { get; set; }
        public string Mamografia { get; set; }
        public DateTime FechaMamografia { get; set; }
        public string PresionArterial { get; set; }
        public string Talla { get; set; }
        public string Pap { get; set; }
        public DateTime FechaPap { get; set; }
        public string Examen_CabezaCuello { get; set; }
        public string Examen_Torax { get; set; }
        public string Examen_Abdomen{ get; set; }
        public string Examen_Urogenital { get; set; }
        public string Extre_Superior { get; set; }
        public string Extre_Inferior { get; set; }
        public string Columna { get; set; }
        public string Diagnostico_Comun { get; set; }
        public string Diagnostico_Laboral { get; set; }
        public string Diagnostico_Tratamiento { get; set; }
        public string Diagnostico_Recomdacion { get; set; }
        public string UsuarioCreador { get; set; }
        public string FechaConsulta { get; set; }
        public string Torax { get; set; }
        public string Osea { get; set; }
        public string Cavidades { get; set; }
        public string TAC { get; set; }
        public string RNM { get; set; }
        public string EEG { get; set; }
        public string ECG { get; set; }
        public string ECARDG { get; set; }
        public string EMG { get; set; }
        public string Laboratorio { get; set; }
        public int IDAntMedicos { get; set; }
        
    }
}