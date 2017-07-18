using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class Productos
    {
        public string OP { get; set; }
        public string NombreOP { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Total { get; set; }
        public string FechaCreacion { get; set; }
        public string Operador { get; set; }
        public string Maquina { get; set; }
        public string Proceso { get; set; }


        public string id_DespProducto { get; set; }
        public string id_Maquina { get; set; }
        
        

        public string Cantidad { get; set; }
        public string Ejemplares { get; set; }
      
        public string Codigo { get; set; }
       

        public string Cliente { get; set; }
       
        public string Tiraje { get; set; }
        public string idOperador { get; set; }

        public string validado { get; set; }
        public string fechavalidacion { get; set; }
        //agregados el 05/11/2013

        public string FechaRecepcion { get; set; }
        public string RecepcionadoPor { get; set; }
        public string Ubicacion { get; set; }
        public string FechaSalida { get; set; }
        public string Modificado { get; set; }
        public string Turno { get; set; }
    }
}