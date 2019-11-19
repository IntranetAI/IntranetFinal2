using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Dashboard.Model
{
    public class DashboardProd
    {
        public string Maquina { get; set; }
        public string FechaProduccion { get; set; }
        public double TotalHoras { get; set; }
        public double HorasTiraje { get; set; }
        public double HorasPreparacion { get; set; }
        public double HorasImprod_Prep { get; set; }
        public double HorasDelay { get; set; }
        public double HorasSinPersonal { get; set; }
        public double HorasColacion { get; set; }
        public double HorasAseo { get; set; }
        public double HorasSinTrabajo { get; set; }
        public double HorasMantencion { get; set; }
        public int Buenos { get; set; }
        public int MalosPreparacion { get; set; }
        public int MalosTiraje { get; set; }
        public int Preparaciones { get; set; }
        public int Arranques { get; set; }
        public int Preparaciones2 { get; set; }
        public int Arranques2 { get; set; }
        public double LogisticaMaterial { get; set; }
        public double Encuadernacion { get; set; }
        public double Impresion { get; set; }
        public double Logistica { get; set; }
        public double Mantencion { get; set; }
        public double Mecanico { get; set; }
        public double Electrico { get; set; }
        public double Gestion { get; set; }
        public double Material { get; set; }
        public double Atascos { get; set; }
        public double EsperaCambioTurno { get; set; }
        public double ParadaPorJefatura { get; set; }
        public double SinInformacion { get; set; }
        public double Operacional { get; set; }
        public double Planchas { get; set; }
        public double Planificacion { get; set; }
        public double ServicioCliente { get; set; }
        public double RegulacionyLavados { get; set; }
    }
    public class DashBoardVisual
    {
        public string Maquina { get; set; }
        public string Año { get; set; }
        public string Semana1 { get; set; }
        public string Semana2 { get; set; }
        public string Semana3 { get; set; }
        public string Dia1 { get; set; }
        public string Dia2 { get; set; }
        public string Dia3 { get; set; }
        public string Dia4 { get; set; }
        public string Dia5 { get; set; }
        public string Dia6 { get; set; }
        public string Dia7 { get; set; }
    }
    public class Recursos
    {
        public string Maquina { get; set; }
        public string CodMaquina { get; set; }
        public int Valor { get; set; }

    }
}