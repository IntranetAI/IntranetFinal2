using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloJefatura.Model
{
    public class Usuarios
    {
        public int? idPrivilegio { get; set; }
        public String NombrePrivi { get; set; }

        //modulos

        public int? CAT_ID { get; set; }
        public String CAT_NAME { get; set; }
        //usuarios
        public int? idUsuario { get; set; }
        public String nombre { get; set; }
        public String Usuario { get; set; }
        public String correo { get; set; }
        public String passw { get; set; }
        public int? filt { get; set; }

        //listar

        public int? id_Servicio { get; set; }
        public String ser_titulo { get; set; }
        public String ser_descripcion { get; set; }
        public String cat_name { get; set; }

        //
        public DateTime FechaCaducidad { get; set; }
        public DateTime fechaantes { get; set; }
    }
}