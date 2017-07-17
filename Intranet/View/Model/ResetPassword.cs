using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.View.Model
{
    public class ResetPassword
    {
        public int idLogin { get; set; }
        public String user { get; set; }
        public String paswoord { get; set; }
        public int pin { get; set; }
    }
}