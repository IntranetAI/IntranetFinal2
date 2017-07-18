using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloPreprensa.Controller;
using Intranet.ModuloPreprensa.Model;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace Intranet.ModuloPreprensa.View
{
    public partial class Requerimientos : System.Web.UI.Page
    {
        Controller_Preprensa cp = new Controller_Preprensa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Preprensa p = cp.CargaSolicitud(Request.QueryString["OT"], 0);
                lblOP.Text = p.OT;
                lblNombreOP.Text = p.NombreOT;
                lblCliente.Text = p.Cliente;
                lblFechaCreacion.Text = p.FechaCreacion;
                lblTiraje.Text = p.Tiraje;
                lblFormatoCerrado.Text = p.FormatoCerrado;
                lblCSR.Text = p.CSR;
                lblRutCliente.Text = p.RutCliente;
                lblUsuario.Text = Request.QueryString["usu"];
                bool r = cp.EliminaDireccionesPendientes(Request.QueryString["usu"], Request.QueryString["usu"], 1);
            }
        }
        [WebMethod]
        public static string CargarDirecciones(string Rut)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaDirecciones(Rut, 1);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion.ToUpper();
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] CargarDireccionesDetalle(string IDDireccion,string Direccion)
        {
            try
            {
                Controller_Preprensa c = new Controller_Preprensa();
                Preprensa d = c.CargaDetalleDireccion(IDDireccion, Direccion, 0);
                return new[] { d.Pais, d.Region, d.Ciudad, d.Comuna, d.Tipo, d.NroTipo, d.Piso, d.Contacto, d.CodTelefono, d.AreaTelefono, d.Telefono, d.AreaCelular, d.Celular, d.Correo };
            }
            catch
            {
                return new[] { "Error" };
            }
              

        }
        [WebMethod]
        public static string CargarTipo()
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaTipos("", 3);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargarTipoArchivo()
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaTipos("", 5);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] GuardaDirecciones(string IDDireccion,string RutCliente,string Cliente,string Direccion,string Pais,string Region,string Ciudad,string Comuna,string Tipo,string NroTipo,string Piso,string Contacto,string CodTelefono,string AreaTelefono,string Telefono,string AreaCelular,string Celular,string Correo,string Observacion,string Usuario,string TipoDireccion)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            bool r = false;
            if (TipoDireccion == "1")
            {
                r = c.AgregaDireccion(IDDireccion,RutCliente, Cliente, Direccion, Pais, Region, Ciudad, Comuna, Tipo, NroTipo, Piso, Contacto, CodTelefono, AreaTelefono, Telefono, AreaCelular, Celular, Correo, Observacion, Usuario, 1);
            }
            else
            {
                r = c.AgregaDireccion(IDDireccion,RutCliente, Cliente, Direccion, Pais, Region, Ciudad, Comuna, Tipo, NroTipo, Piso, Contacto, CodTelefono, AreaTelefono, Telefono, AreaCelular, Celular, Correo, Observacion, Usuario, 0);
            }
            if (r)
            {
                return new[] { "OK" };
            }
            else
            {
                return new[] { "Error","¡Error al ingresar Direccion!" };
            }
        }
        [WebMethod]
        public static string muestraDirecciones(string Usuario)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            string arrayInserto = c.muestrDirecciones(Usuario, 4);

            return arrayInserto;
        }
        [WebMethod]
        public static string CargaPais(string IDPais)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaDirecciones(IDPais, 6);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargaRegion(string IDPais)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaDirecciones(IDPais, 7);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargaCiudad(string IDRegion)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaDirecciones(IDRegion, 8);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargaComuna(string idCiudad)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            List<Preprensa> lista = c.CargaDirecciones(idCiudad, 9);
            List<Preprensa> lista2 = new List<Preprensa>();

            int contador = 1;
            Preprensa insert1 = new Preprensa();
            insert1.Direccion = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Preprensa ps in lista)
            {
                Preprensa objst = new Preprensa();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion;
                objst.IDDireccion = ps.IDDireccion;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] FinalizarRequerimiento(string OT, string NombreOT, string Cliente, string RutCliente, string FechaVB, int HoraVB, int MinutoVB, int PagColor, int PagImproof, int PagArmado, string TipoArchivo, string RevisaCSR, string Observacion, string CreadoPor)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            int r = c.AgregaRequerimiento(OT, NombreOT, Cliente, RutCliente, DateTime.Now, HoraVB, MinutoVB, PagColor, PagImproof, PagArmado, TipoArchivo, RevisaCSR, Observacion, CreadoPor, 0);
            if (r != 0)
            {
                return new[] { "OK" };
            }
            else
            {
                return new[] { "ERROR" };
            }
        }
        [WebMethod]
        public static string cargaHistoriales(string OT)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            string arrayInserto = c.cargaRequerimientos(OT, 10);

            return arrayInserto;
        }
        [WebMethod]
        public static string[] ModificaRequerimiento(string IDRequerimiento)
        {
            try
            {
                Controller_Preprensa c = new Controller_Preprensa();
                Preprensa d = c.CargaParaModificar(IDRequerimiento, 0);
                string HorVB = "";
                string MinVB = "";
                if (d.HoraVB.Length == 1)
                {
                    HorVB = "0" + d.HoraVB;
                }
                else
                {
                    HorVB = d.HoraVB;
                }
                if (d.MinutoVB.Length == 1)
                {
                    MinVB = "0" + d.MinutoVB;
                }
                else
                {
                    MinVB = d.MinutoVB;
                }
                return new[] { d.FechaVB, HorVB, MinVB, d.PagColor, d.PagImproof, d.PagArmado, d.TipoArchivo, d.RevisaCSR, d.Observacion, d.Estado };
            }
            catch
            {
                return new[] { "Error" };
            }


        }
        [WebMethod]
        public static string cargaDireccionesEdit(string IDRequerimiento)
        {
            Controller_Preprensa c = new Controller_Preprensa();
            string arrayInserto = c.cargaDireccionesaEditar(IDRequerimiento, 1);

            return arrayInserto;
        }
        [WebMethod]
        public static string limpiaRegistro(string IDRequerimiento)
        {
            return "[{_Cliente_:__,_Direccion_:__,_Comuna_:__,_Tipo_:__,_NroTipo_:__,_Piso_:__,_Contacto_:__,_Observacion_:__,_Editar_:__}]";
        }
        //CargaDireccionModi
        [WebMethod]
        public static string[] CargaDireccionModi(string IDDireccion)
        {
            try
            {
                Controller_Preprensa c = new Controller_Preprensa();
                Preprensa d = c.cargaDireccionesaEdit(IDDireccion, 2);
                return new[] { d.IDDireccion, d.Direccion, d.Pais, d.Region, d.Comuna, d.Ciudad, d.Tipo, d.NroTipo, d.Piso, d.Contacto, d.CodTelefono, d.AreaTelefono, d.Telefono, d.AreaCelular, d.Celular, d.Correo, d.Observacion };
            }
            catch
            {
                return new[] { "Error" };
            }


        }
        //ModificaDireccion
        //[WebMethod]
        //public static string[] CargaDireccionModi(string IDDireccion)
        //{
        //    try
        //    {
        //        Controller_Preprensa c = new Controller_Preprensa();
        //        Preprensa d = c.cargaDireccionesaEdit(IDDireccion, 2);
        //        return new[] { d.IDDireccion, d.Direccion, d.Pais, d.Region, d.Comuna, d.Ciudad, d.Tipo, d.NroTipo, d.Piso, d.Contacto, d.CodTelefono, d.AreaTelefono, d.Telefono, d.AreaCelular, d.Celular, d.Correo, d.Observacion };
        //    }
        //    catch
        //    {
        //        return new[] { "Error" };
        //    }
        //}
    }
}