using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.View
{
    /// <summary>
    /// Descripción breve de MantenedordeSesion
    /// </summary>
    public class MantenedordeSesion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "application/x-javascript";
            context.Response.Write("//");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}