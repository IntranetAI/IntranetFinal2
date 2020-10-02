using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloFacturacion.Controller;
using Intranet.ModuloFacturacion.Model;
using System.Globalization;
using System.Text;
using Intranet.ModuloAdministracion.Controller;

namespace Intranet.ModuloFacturacion.View
{
    public partial class Vista_FacturaElectronica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNFactura.Text = Request.QueryString["Fac"].ToString();
                cargarDatos(Convert.ToInt32(Request.QueryString["Fac"].ToString()), Convert.ToInt32(Request.QueryString["TipoDoc"].ToString()));
            }
        }

        public void cargarDatos(int factura, int TipoDoc)
        {
            Controller_Facturacion controlFact = new Controller_Facturacion();
            Facturacion_ElectronicaSII CabFactura = controlFact.BuscarCabFacturaDetallada(factura, TipoDoc);
            lblRut.Text = ": " + CabFactura.RutCliente;
            lblNombreCliente.Text = ": " + CabFactura.Nombre_Cliente;
            lblgiro.Text = ": " + CabFactura.giro;
            lblSucursal.Text = ": " + CabFactura.Sucursal;
            lblDireccion.Text = ": " + CabFactura.Direccion;
            lblFecha.Text = ": " + CabFactura.Fecha_Creacion;
            lblComuna.Text = ": " + CabFactura.Comuna;
            lblCiudad.Text = ": " + CabFactura.Ciudad;
            lblPais.Text = ": " + CabFactura.Pais;
            lblVendedor.Text = ": " + CabFactura.Vendedor;
            lblCondicion.Text = ": " + CabFactura.CondicionVenta;
            lblGuias.Text = ": " + CabFactura.Guias;
            lblIVa.Text = CabFactura.Valor_Iva;
            lblValor_Neto.Text = CabFactura.Valor_Neto;
            lblTotal.Text = CabFactura.Valor_total;
            lblTotalTexto.Text = ToCustomCardinal(Convert.ToDouble(CabFactura.Valor_total.Replace(".", string.Empty))).ToUpper();

            List<Facturacion_ElectronicaSII> lista = controlFact.BuscarDetFacturaDetallada(factura, TipoDoc);
            string Tabla = "<table style='width: 100%;border-style:solid;border-width:1px;border-color:black;'>";
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
            foreach (Facturacion_ElectronicaSII detalle in lista)
            {
                string TablaPesos = "<table style='border-spacing:0px;width:100%'>";
                string[] a = detalle.Descripcion.Split('\r');
                foreach (string b in a)
                {
                    string abc = b.Replace('\n', ' ');
                    if (abc.Contains("OCN°") || abc.Contains("OCNº"))
                    {
                        int corteString = 0;
                        try
                        {
                            DIVOrdenCompra.Visible = true;
                            corteString = b.IndexOf("OCN° ");
                            if (corteString == -1)
                            {
                                corteString = 5;
                            }
                            string OrdenCompra = b.Substring(corteString, b.Length - corteString).Trim();
                            //int largoEspacio = OrdenCompra.IndexOf(' ');
                            txtNOrdenCompra.Text = OrdenCompra.Substring(0, OrdenCompra.Length - 10).Trim();
                            string OCfecha = OrdenCompra.Substring(OrdenCompra.Length - 10, 10).Replace(".", "").Trim();
                            txtFechaOC.Text = OCfecha;
                        }
                        catch
                        {
                            txtNOrdenCompra.Text = b.Substring(corteString, b.Length - corteString).Trim();
                            txtFechaOC.Text = "";
                        }
                    }
                    else
                    {
                        if (b.Contains("$"))
                        {
                            string[] pesos = b.Split('$');
                            TablaPesos += "<tr><td style='width:80%'>" + pesos[0] + "</td><td style='width:3%'>$</td><td align='right' style='width:17%'>" + pesos[1] + "</td></tr>";
                        }
                        else
                        {
                            if (b.Count() > 0)
                            {
                                TablaPesos += "<tr><td>" + b + "</td><td></td><td></td></tr>";
                            }
                            else
                            {
                                TablaPesos += "<tr><td>&nbsp;</td><td></td><td></td></tr>";
                            }
                        }
                    }
                }
                TablaPesos += "</table>";

                Tabla += "<tr><td align='right' style='vertical-align:top;width: 100px;'>" + detalle.Cantidad + "</td>" +
                             "<td style='border-left:1px solid black;'>" + TablaPesos + "</td>" +
                             "<td align='right' style='vertical-align:top;border-left:1px solid black;width: 130px;'>" + Convert.ToDouble(detalle.ValorUnit).ToString("N4").Replace(",", "*").Replace(".", ",").Replace("*", ".") + "</td>" +
                             "<td align='right' style='vertical-align:top;border-left:1px solid black;width: 150px;'>" + detalle.ValorItemTotal + "</td></tr>";
            }
            Tabla += "</table><br />";
            lblTablaDetalle.Text = Tabla;

            if (TipoDoc >= 4 && TipoDoc <= 9)
            {
                if (TipoDoc < 7)
                {
                    lblTipo.Text = "Nota Credito ";
                }
                else
                {
                    lblTipo.Text = "Nota Debito ";
                }
                DIVreferencia.Visible = true;
                lblReferencia.Text = controlFact.BuscarDetRefencia(TipoDoc, factura);
            }
            else if (TipoDoc == 3)
            {
                lblTipo.Text = "Factura Exenta IVA";
            }
            else
            {
                lblTipo.Text = "Factura Electronica ";
            }
        }


        #region ConversorNumeroATexto
        #region Miembros estáticos

        private const int UNI = 0, DIECI = 1, DECENA = 2, CENTENA = 3;
        private static string[,] _matriz = new string[CENTENA + 1, 10]
        {
            {null," uno", " dos", " tres", " cuatro", " cinco", " seis", " siete", " ocho", " nueve"},
            {" diez"," once"," doce"," trece"," catorce"," quince"," dieciséis"," diecisiete"," dieciocho"," diecinueve"},
            {null,null,null," treinta"," cuarenta"," cincuenta"," sesenta"," setenta"," ochenta"," noventa"},
            {null,null,null,null,null," quinientos",null," setecientos",null," novecientos"}
        };

        private const Char sub = (Char)26;
        //Cambiar acá si se quiere otro comportamiento en los métodos de clase
        public const String SeparadorDecimalSalidaDefault = "";
        public const String MascaraSalidaDecimalDefault = "00'/100.-'";
        public const Int32 DecimalesDefault = 2;
        public const Boolean LetraCapitalDefault = false;
        public const Boolean ConvertirDecimalesDefault = false;
        public const Boolean ApocoparUnoParteEnteraDefault = false;
        public const Boolean ApocoparUnoParteDecimalDefault = false;

        #endregion

        #region Propiedades

        private Int32 _decimales = DecimalesDefault;
        private CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
        private String _separadorDecimalSalida = SeparadorDecimalSalidaDefault;
        private Int32 _posiciones = DecimalesDefault;
        private String _mascaraSalidaDecimal, _mascaraSalidaDecimalInterna = MascaraSalidaDecimalDefault;
        private Boolean _esMascaraNumerica = true;
        private Boolean _letraCapital = LetraCapitalDefault;
        private Boolean _convertirDecimales = ConvertirDecimalesDefault;
        private Boolean _apocoparUnoParteEntera = false;
        private Boolean _apocoparUnoParteDecimal;

        /// <summary>
        /// Indica la cantidad de decimales que se pasarán a entero para la conversión
        /// </summary>
        /// <remarks>Esta propiedad cambia al cambiar MascaraDecimal por un valor que empieze con '0'</remarks>
        public Int32 Decimales
        {
            get { return _decimales; }
            set
            {
                if (value > 10) throw new ArgumentException(value.ToString() + " excede el número máximo de decimales admitidos, solo se admiten hasta 10.");
                _decimales = value;
            }
        }

        /// <summary>
        /// Objeto CultureInfo utilizado para convertir las cadenas de entrada en números
        /// </summary>
        public CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
            set { _cultureInfo = value; }
        }

        /// <summary>
        /// Indica la cadena a intercalar entre la parte entera y la decimal del número
        /// </summary>
        public String SeparadorDecimalSalida
        {
            get { return _separadorDecimalSalida; }
            set
            {
                _separadorDecimalSalida = value;
                //Si el separador decimal es compuesto, infiero que estoy cuantificando algo,
                //por lo que apocopo el "uno" convirtiéndolo en "un"
                if (value.Trim().IndexOf(" ") > 0)
                    _apocoparUnoParteEntera = true;
                else _apocoparUnoParteEntera = false;
            }
        }

        /// <summary>
        /// Indica el formato que se le dara a la parte decimal del número
        /// </summary>
        public String MascaraSalidaDecimal
        {
            get
            {
                if (!String.IsNullOrEmpty(_mascaraSalidaDecimal))
                    return _mascaraSalidaDecimal;
                else return "";
            }
            set
            {
                //determino la cantidad de cifras a redondear a partir de la cantidad de '0' o '#' 
                //que haya al principio de la cadena, y también si es una máscara numérica
                int i = 0;
                while (i < value.Length
                    && (value[i] == '0')
                        | value[i] == '#')
                    i++;
                _posiciones = i;
                if (i > 0)
                {
                    _decimales = i;
                    _esMascaraNumerica = true;
                }
                else _esMascaraNumerica = false;
                _mascaraSalidaDecimal = value;
                if (_esMascaraNumerica)
                    _mascaraSalidaDecimalInterna = value.Substring(0, _posiciones) + "'"
                        + value.Substring(_posiciones)
                        .Replace("''", sub.ToString())
                        .Replace("'", String.Empty)
                        .Replace(sub.ToString(), "'") + "'";
                else
                    _mascaraSalidaDecimalInterna = value
                        .Replace("''", sub.ToString())
                        .Replace("'", String.Empty)
                        .Replace(sub.ToString(), "'");
            }
        }

        /// <summary>
        /// Indica si la primera letra del resultado debe estár en mayúscula
        /// </summary>
        public Boolean LetraCapital
        {
            get { return _letraCapital; }
            set { _letraCapital = value; }
        }

        /// <summary>
        /// Indica si se deben convertir los decimales a su expresión nominal
        /// </summary>
        public Boolean ConvertirDecimales
        {
            get { return _convertirDecimales; }
            set
            {
                _convertirDecimales = value;
                _apocoparUnoParteDecimal = value;
                if (value)
                {// Si la máscara es la default, la borro
                    if (_mascaraSalidaDecimal == MascaraSalidaDecimalDefault)
                        MascaraSalidaDecimal = "";
                }
                else if (String.IsNullOrEmpty(_mascaraSalidaDecimal))
                    //Si no hay máscara dejo la default
                    MascaraSalidaDecimal = MascaraSalidaDecimalDefault;
            }
        }

        /// <summary>
        /// Indica si de debe cambiar "uno" por "un" en las unidades.
        /// </summary>
        public Boolean ApocoparUnoParteEntera
        {
            get { return _apocoparUnoParteEntera; }
            set { _apocoparUnoParteEntera = value; }
        }

        /// <summary>
        /// Determina si se debe apococopar el "uno" en la parte decimal
        /// </summary>
        /// <remarks>El valor de esta propiedad cambia al setear ConvertirDecimales</remarks>
        public Boolean ApocoparUnoParteDecimal
        {
            get { return _apocoparUnoParteDecimal; }
            set { _apocoparUnoParteDecimal = value; }
        }

        #endregion


        #region Conversores de instancia

        public String ToCustomCardinal(Double Numero)
        { return Convertir((Decimal)Numero, _decimales, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _convertirDecimales, _apocoparUnoParteEntera, _apocoparUnoParteDecimal); }

        #endregion

        private static String Convertir(Decimal Numero, Int32 Decimales, String SeparadorDecimalSalida, String MascaraSalidaDecimal, Boolean EsMascaraNumerica, Boolean LetraCapital, Boolean ConvertirDecimales, Boolean ApocoparUnoParteEntera, Boolean ApocoparUnoParteDecimal)
        {
            Int64 Num;
            Int32 terna, centenaTerna, decenaTerna, unidadTerna, iTerna;
            String cadTerna;
            StringBuilder Resultado = new StringBuilder();

            Num = (Int64)Math.Abs(Numero);

            if (Num >= 1000000000000 || Num < 0) throw new ArgumentException("El número '" + Numero.ToString() + "' excedió los límites del conversor: [0;1.000.000.000.000)");
            if (Num == 0)
                Resultado.Append(" cero");
            else
            {
                iTerna = 0;
                while (Num > 0)
                {
                    iTerna++;
                    cadTerna = String.Empty;
                    terna = (Int32)(Num % 1000);

                    centenaTerna = (Int32)(terna / 100);
                    decenaTerna = terna % 100;
                    unidadTerna = terna % 10;

                    if ((decenaTerna > 0) && (decenaTerna < 10))
                        cadTerna = _matriz[UNI, unidadTerna] + cadTerna;
                    else if ((decenaTerna >= 10) && (decenaTerna < 20))
                        cadTerna = cadTerna + _matriz[DIECI, unidadTerna];
                    else if (decenaTerna == 20)
                        cadTerna = cadTerna + " veinte";
                    else if ((decenaTerna > 20) && (decenaTerna < 30))
                        cadTerna = " veinti" + _matriz[UNI, unidadTerna].Substring(1);
                    else if ((decenaTerna >= 30) && (decenaTerna < 100))
                        if (unidadTerna != 0)
                            cadTerna = _matriz[DECENA, (Int32)(decenaTerna / 10)] + " y" + _matriz[UNI, unidadTerna] + cadTerna;
                        else
                            cadTerna += _matriz[DECENA, (Int32)(decenaTerna / 10)];

                    switch (centenaTerna)
                    {
                        case 1:
                            if (decenaTerna > 0) cadTerna = " ciento" + cadTerna;
                            else cadTerna = " cien" + cadTerna;
                            break;
                        case 5:
                        case 7:
                        case 9:
                            cadTerna = _matriz[CENTENA, (Int32)(terna / 100)] + cadTerna;
                            break;
                        default:
                            if ((Int32)(terna / 100) > 1) cadTerna = _matriz[UNI, (Int32)(terna / 100)] + "cientos" + cadTerna;
                            break;
                    }
                    //Reemplazo el 'uno' por 'un' si no es en las únidades o si se solicító apocopar
                    if ((iTerna > 1 | ApocoparUnoParteEntera) && decenaTerna == 21)
                        cadTerna = cadTerna.Replace("veintiuno", "veintiún");
                    else if ((iTerna > 1 | ApocoparUnoParteEntera) && unidadTerna == 1 && decenaTerna != 11)
                        cadTerna = cadTerna.Substring(0, cadTerna.Length - 1);
                    //Acentúo 'veintidós', 'veintitrés' y 'veintiséis'
                    else if (decenaTerna == 22) cadTerna = cadTerna.Replace("veintidos", "veintidós");
                    else if (decenaTerna == 23) cadTerna = cadTerna.Replace("veintitres", "veintitrés");
                    else if (decenaTerna == 26) cadTerna = cadTerna.Replace("veintiseis", "veintiséis");

                    //Completo miles y millones
                    switch (iTerna)
                    {
                        case 3:
                            if (Numero < 2000000) cadTerna += " millón";
                            else cadTerna += " millones";
                            break;
                        case 2:
                        case 4:
                            if (terna > 0) cadTerna += " mil";
                            break;
                    }
                    Resultado.Insert(0, cadTerna);
                    Num = (Int32)(Num / 1000);
                } //while
            }

            //Se agregan los decimales si corresponde
            if (Decimales > 0)
            {
                Resultado.Append(" " + SeparadorDecimalSalida + " ");
                Int32 EnteroDecimal = (Int32)Math.Round((Double)(Numero - (Int64)Numero) * Math.Pow(10, Decimales), 0);
                if (ConvertirDecimales)
                {
                    Boolean esMascaraDecimalDefault = MascaraSalidaDecimal == MascaraSalidaDecimalDefault;
                    Resultado.Append(Convertir((Decimal)EnteroDecimal, 0, null, null, EsMascaraNumerica, false, false, (ApocoparUnoParteDecimal && !EsMascaraNumerica/*&& !esMascaraDecimalDefault*/), false) + " "
                        + (EsMascaraNumerica ? "" : MascaraSalidaDecimal));
                }
                else
                    if (EsMascaraNumerica) Resultado.Append(EnteroDecimal.ToString(MascaraSalidaDecimal));
                    else Resultado.Append(EnteroDecimal.ToString() + " " + MascaraSalidaDecimal);
            }
            //Se pone la primer letra en mayúscula si corresponde y se retorna el resultado
            if (LetraCapital)
                return Resultado[1].ToString().ToUpper() + Resultado.ToString(2, Resultado.Length - 2);
            else
                return Resultado.ToString().Substring(1);
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {try
            {
                Controller_Facturacion controlFact = new Controller_Facturacion();
                string OC = txtNOrdenCompra.Text.ToString();
                string fechaOC = txtFechaOC.Text;
                string evento = "";
                int TipoDoc = Convert.ToInt32(Request.QueryString["TipoDoc"].ToString());
                if (TipoDoc >= 4 && TipoDoc <= 9)
                {
                    if (ddlRazon.SelectedValue.ToString() != "0")
                    {
                        evento = controlFact.SincronizadorFacturas(Convert.ToInt32(Request.QueryString["Fac"].ToString()), Convert.ToInt32(Request.QueryString["TipoDoc"].ToString()), ddlRazon.SelectedValue.ToString(), Session["Usuario"].ToString(), OC, fechaOC);
                    }
                    else
                    {
                        evento = "Debe seleccionar una razón. Intentelo nuevamente";
                    }
                }
                else
                {
                    evento = controlFact.SincronizadorFacturas(Convert.ToInt32(Request.QueryString["Fac"].ToString()), Convert.ToInt32(Request.QueryString["TipoDoc"].ToString()), ddlRazon.SelectedValue.ToString(), Session["Usuario"].ToString(), OC, fechaOC);
                }


                if (evento == "OK")
                {
                    Document_Controller dcc = new Document_Controller();
                    if (dcc.UpdateEstado7(Request.QueryString["Fac"].ToString()) == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Actualizacion de Factura Electronicas Realizada Correctamente');opener.location.reload();window.close();</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }else
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Ha ocurrido un error, vuelva a intentarlo');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('" + evento + "');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception exx)
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }


    }
}