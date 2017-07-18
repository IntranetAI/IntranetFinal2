using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloUsuario.Model
{
    public class Mail
    {
        public int IDMail { get; set; }
        public string OT { get; set; }
        public string Asunto { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Creado { get; set; }
        public string NM { get; set; }//nombreOT

        //enviar correo segun importancia
        public string numeroOT { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
    }
}