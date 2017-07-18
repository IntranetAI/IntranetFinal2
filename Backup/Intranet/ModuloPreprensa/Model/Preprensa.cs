using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloPreprensa.Model
{
    public class Preprensa
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string FechaCreacion { get; set; }
        public string Cliente { get; set; }
        public string CSR { get; set; }
        public string FormatoCerrado { get; set; }
        public string Tiraje { get; set; }
        public string RutCliente { get; set; }
        public string Direccion { get; set; }
        public string IDDireccion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Tipo { get; set; }
        public string NroTipo { get; set; }
        public string Piso { get; set; }
        public string Contacto { get; set; }
        public string CodTelefono { get; set; }
        public string AreaTelefono { get; set; }
        public string Telefono { get; set; }
        public string AreaCelular { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }

        public string FechaVB { get; set; }
        public string HoraVB { get; set; }
        public string MinutoVB { get; set; }
        public string PagColor { get; set; }
        public string PagImproof { get; set; }
        public string PagArmado { get; set; }
        public string TipoArchivo { get; set; }
        public string RevisaCSR { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
    }
}