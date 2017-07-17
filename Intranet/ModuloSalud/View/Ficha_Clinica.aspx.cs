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
    public partial class Ficha_Clinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string RutPaciente = Request.QueryString["rut"].ToString();
                string pro = "";
                try
                {
                    pro = Request.QueryString["pro"].ToString();
                    string popupScript4 = "<script language='JavaScript'>BuscarPaciente2(" + RutPaciente + ");</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                catch
                {
                    string popupScript4 = "<script language='JavaScript'>BuscarPaciente(" + RutPaciente + ");</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                
            }
        }

        [WebMethod]
        public static string[] BuscarPaciente(string Rut)
        {
            Controller_FichaMedica controlMedico = new Controller_FichaMedica();
            FichaMedica fm = controlMedico.BuscarPacienteRut(Rut.Substring(0,Rut.Length-1),0);
            TimeSpan ts = DateTime.Now - fm.FechaIngreso;
            double AñosAntiguedad = Math.Floor(ts.TotalDays / 356);
            return new[] { fm.Nombre + " " + fm.ApellidoPaterno, fm.FechaNacimiento.ToString("dd-MM-yyyy"), fm.Cargo, fm.CentroCosto, AñosAntiguedad.ToString("N0")+ " Años",
                           fm.Telefono, fm.EstadoCivil, fm.Direccion, fm.Comuna,fm.Jornada, fm.Sexo, fm.Correo };
        }

        [WebMethod]
        public static string[] BuscarPaciente2(string Rut)
        {
            Controller_FichaMedica controlMedico = new Controller_FichaMedica();
            FichaMedica fm = controlMedico.BuscarPacienteRut(Rut, 1);
            TimeSpan ts = DateTime.Now - fm.FechaIngreso;
            double AñosAntiguedad = Math.Floor(ts.TotalDays / 356);
            return new[] { fm.Nombre + " " + fm.ApellidoPaterno, fm.FechaNacimiento.ToString("dd-MM-yyyy"),fm.Telefono, fm.EstadoCivil, fm.Anexo, 
                           fm.Correo, fm.Direccion, fm.Comuna, fm.Transporte, fm.Accion, fm.Cargo, fm.Fiebre, fm.Sexo, AñosAntiguedad.ToString("N0")+ " Años", fm.Edad.ToString() };
        }

        [WebMethod]
        public static string[] GuardarFicha(string Rut, string Telefono, string FechaAnti, string EstadoCivil, string Transporte, string Empresa, string Usuario, string Correo, string Anexo)
        {
            string resultado = "";
            Controller_FichaMedica controlMedico = new Controller_FichaMedica();
            DateTime FechaCargo= new DateTime();
            if(FechaAnti!="")
            {
                FechaCargo = DateTime.Now.AddYears(-Convert.ToInt32(FechaAnti));
            }
            int resultadoID = controlMedico.GuardarFicha(Rut, Telefono, FechaCargo, EstadoCivil, Transporte, Empresa, Usuario, Correo, Anexo);
            if (resultadoID > 0)
            {
                resultado = "OK";
            }
            return new[] { resultado, resultadoID.ToString()};
        }


    }
}