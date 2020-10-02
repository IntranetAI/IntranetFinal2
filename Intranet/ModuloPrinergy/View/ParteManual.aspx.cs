using Intranet.ModuloPrinergy.Controller;
using Intranet.ModuloPrinergy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Web.UI;

namespace Intranet.ModuloPrinergy.View
{
    public partial class ParteManual : System.Web.UI.Page
    {
        Controller_XML xml = new Controller_XML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                DivAlert.Visible = false;
                btnModificar.Visible = false;
                DivError.Visible = false;
                List<APA_Clientes> clientes = xml.ClientesMetrics();
                ddlCliente.DataSource = clientes;
                ddlCliente.DataTextField = "Cliente";
                ddlCliente.DataValueField = "Cliente";
                ddlCliente.DataBind();

                ddlCliente.Items.Insert(0, new ListItem("Seleccione...", "0"));

                if (Request.QueryString["admin"] == null)
                {

                    txtNombreOT.Visible = false;
                    ddlCliente.Visible = false;
                    txtOT.Visible = true;
                    txtOTNueva.Visible = false;
                    lblNombreOT.Visible = true;
                    btnBuscar.Visible = true;
                    btnBuscarNueva.Visible = false;
                    //OT nueva campos habilitados
                    lblDiferencia.Text = "";
                }
                else
                {

                    txtOT.Visible = false;
                    txtOTNueva.Visible = true;
                    txtNombreOT.Visible = true;
                    lblNombreOT.Visible = false;
                    btnBuscar.Visible = false;
                    btnBuscarNueva.Visible = true;
                    //OT nueva campos habilitados
                    lblDiferencia.Text = "*Encargados";
                    ddlCliente.Visible = true;

                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtOT.Text!="")
            {
                if (xml.ConsultaOTIngresada(txtOT.Text, 12) == true)
                {
                    RadGrid1.DataSource = xml.ListaGruposPaginas(txtOT.Text, 13);
                    RadGrid1.DataBind();
                   
                    DivAlert.Visible = true;
                }
                else
                {
                    DivAlert.Visible = false;
                }
                XMLFormato xf = xml.BuscaOT(txtOT.Text, 0);
                lblNombreOT.Text = xf.NombreOT;
                lblCliente.Text = xf.Cliente;
                lblCSR.Text = xf.CSR;
                if (xf.NombreOT==null && xf.Cliente==null)
                {
                    DivError.Visible = true;
                    btnAgregar.Enabled = false;
                    btnFinalizar.Enabled = false;
                    RadGrid1.DataSource = "";
                    RadGrid1.DataBind();
                }
                else
                {
                    DivError.Visible = false;
                    btnAgregar.Enabled = true;
                    btnFinalizar.Enabled = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<XMLFormato> listaFormato = new List<XMLFormato>();


            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                XMLFormato xm = new XMLFormato();
                xm.Id = Convert.ToInt32(RadGrid1.Items[i]["Id"].Text);
                xm.NombreGrupo = RadGrid1.Items[i]["NombreGrupo"].Text;
                xm.Paginas = Convert.ToInt32(RadGrid1.Items[i]["Paginas"].Text);
                xm.Inicio = Convert.ToInt32(RadGrid1.Items[i]["Inicio"].Text);
                xm.Formato = RadGrid1.Items[i]["Formato"].Text;
                xm.FormatoX = Convert.ToInt32(RadGrid1.Items[i]["FormatoX"].Text);
                xm.FormatoY = Convert.ToInt32(RadGrid1.Items[i]["FormatoY"].Text);
                xm.Papel = RadGrid1.Items[i]["Papel"].Text;
                listaFormato.Add(xm);
            }
            if (txtNombreGrupo.Text != "" && txtPaginas.Text != "" && txtInicio.Text != "" && txtFormatoX.Text != "" && txtFormatoY.Text != "")
            {
                XMLFormato xf = new XMLFormato();
                xf.Id = new Random().Next(0, 1000000);

                xf.OT = txtOT.Text;
                xf.NombreOT = lblNombreOT.Text;
                xf.Cliente = lblCliente.Text;
                xf.NombreGrupo = txtNombreGrupo.Text;
                xf.Paginas = Convert.ToInt32(txtPaginas.Text);
                xf.Inicio = Convert.ToInt32(txtInicio.Text);
                xf.Formato = txtFormatoX.Text + "x" + txtFormatoY.Text;
                xf.FormatoX = Convert.ToInt32(txtFormatoX.Text);
                xf.FormatoY = Convert.ToInt32(txtFormatoY.Text);
                xf.Papel = DropDownList1.SelectedValue.ToString();
                listaFormato.Add(xf);

                RadGrid1.DataSource = listaFormato;
                RadGrid1.DataBind();
            }else
            {
                string popupScript = "<script language='JavaScript'> alert('Debe completar todos los campos'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

            txtNombreGrupo.Text = "";
            txtPaginas.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string aa = ddlCliente.SelectedItem.Value;
            string b = ddlCliente.SelectedValue;


            bool validacion = false;
            if(Request.QueryString["admin"]!=null && lblTipo.Text == "Nueva" && txtNombreOT.Text!="" && ddlCliente.SelectedItem.Value!="0")
            {
                validacion = true;
            }else if (Request.QueryString["admin"] != null && lblTipo.Text == "Existe" && lblNombreOT.Text!="" && lblCliente.Text != "")
            {
                validacion = true;
            }else if(Request.QueryString["admin"] == null && lblNombreOT.Text!="" && lblCliente.Text != "")
            {
                validacion = true;
            }
            else
            {
                validacion = false;
            }

            if (validacion == true)
            {


                string OT = ""; string NombreOT = ""; string Cliente = "";
                if (Request.QueryString["admin"] != null && lblTipo.Text != "Existe")
                {
                    OT = txtOTNueva.Text;
                    NombreOT = Regex.Replace(txtNombreOT.Text.ToUpper(), @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "").Replace("ñ", "N").Replace("°", "").Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("#", "");
                    Cliente = ddlCliente.SelectedItem.ToString();
                }
                else
                {
                    OT = txtOT.Text;
                    NombreOT = Regex.Replace(lblNombreOT.Text.ToUpper(), @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "").Replace("ñ", "N").Replace("°", "").Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("#", "");
                    Cliente = lblCliente.Text;
                }

                //string OT = txtOT.Text;
                //string NombreOT = Regex.Replace(lblNombreOT.Text, @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("&", "").Replace("ñ", "N"); string Cliente = lblCliente.Text;


                string PrimerColorFlow = ""; string UltimoColorFlow = "";
                XMLFormato xf = new XMLFormato();
                Controller_XML xc = new Controller_XML();
                List<XMLFormato> ListaGrupos = new List<XMLFormato>();
                List<APA_Clientes> listadoAPAClientes = xc.ClientesAPA();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    XMLFormato xm = new XMLFormato();
                    xm.NombreGrupo = RadGrid1.Items[i]["NombreGrupo"].Text;
                    xm.Paginas = Convert.ToInt32(RadGrid1.Items[i]["Paginas"].Text);
                    xm.Inicio = Convert.ToInt32(RadGrid1.Items[i]["Inicio"].Text);
                    xm.Formato = RadGrid1.Items[i]["Formato"].Text;
                    xm.X = Math.Round((Convert.ToDouble(RadGrid1.Items[i]["FormatoX"].Text.ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(RadGrid1.Items[i]["FormatoX"].Text.ToString()) * 2.8346) + 2).ToString();
                    xm.Y = Math.Round((Convert.ToDouble(RadGrid1.Items[i]["FormatoY"].Text.ToString()) * 2.8346) - 2).ToString() + "-" + Math.Round((Convert.ToDouble(RadGrid1.Items[i]["FormatoY"].Text.ToString()) * 2.8346) + 2).ToString();
                    xm.Papel = RadGrid1.Items[i]["Papel"].Text;

                    if (xm.Papel == "Couche" || xm.Papel == "LWC" || xm.Papel == "Cartulina")
                    {
                        xm.ColorFlow = "Ink Opt Fogra_39_v2";
                    }
                    else if (xm.Papel == "Bond")
                    {
                        xm.ColorFlow = "Ink Opt Fogra 29 _v2";
                    }
                    else
                    {
                        xm.ColorFlow = "Ink Opt Papel diario";
                    }
                    xm.XNota = RadGrid1.Items[i]["FormatoX"].Text.ToString();
                    xm.YNota = RadGrid1.Items[i]["FormatoY"].Text.ToString();

                    ListaGrupos.Add(xm);
                }

                string miXML = ""; string miXMLenc = ""; string Notas = ""; string NotasAnidadas = "";

                //Recorrer numero de paginas
                string arregloPrefijo = "p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k,p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k,p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k"; string APA = "";
                foreach (var it in ListaGrupos)
                {
                    if (it.NombreGrupo.ToLower().Contains("pagina"))
                    {
                        PrimerColorFlow = it.ColorFlow;
                    }
                    if (UltimoColorFlow == "")
                    {
                        UltimoColorFlow = it.ColorFlow;
                    }
                    string Papel = ((Cliente.ToLower().Contains("copesa")) ? "" : it.Papel);
                    string Prefijo = (it.NombreGrupo.ToLower().Contains("paginas") ? "p" : it.NombreGrupo + "");
                    string Prefijoxml = arregloPrefijo.Substring(0, 2);
                    miXML += "<GrupoPaginas>" +
                                            "<NombreGrupoPaginas>" + it.NombreGrupo + "</NombreGrupoPaginas>" +
                                            "<CantidadPaginas>" + it.Paginas.ToString() + "</CantidadPaginas>" +
                                            "<InicioGrupo>" + it.Inicio + "</InicioGrupo>" +
                                            "<X>" + it.X + "</X>" +
                                            "<Y>" + it.Y + "</Y>" +
                                            "<Prefijo>" + Prefijoxml.Replace(",", "") + "</Prefijo>" +
                                            "<ColorPapel>" + Papel + "</ColorPapel>" +
                                            "<ColorFlow>" + it.ColorFlow + "</ColorFlow>" +
                                      "</GrupoPaginas>";

                    Notas += "Para " + it.NombreGrupo + ":<br/>" +
                               OT + Prefijo + "1.pdf<br/>" +
                               "Donde " + OT + " Corresponde al numero de OT, " + Prefijo + " indica que forma parte de las " + it.NombreGrupo + " y " + it.Inicio + " indica la posicion dentro de estas.<br/>" +
                               it.NombreGrupo + " mide " + it.XNota + " mm de ancho y " + it.YNota + " mm de alto, con una cantidad de " + it.Paginas + ".<br/><br/>";
                    NotasAnidadas += "Para " + it.NombreGrupo + ": El PDF anidado debe llamarse " + it.NombreGrupo + ".pdf<br/>";

                    if (it.NombreGrupo.ToLower().Contains("pagina") && listadoAPAClientes.Where(x => x.Cliente == Cliente).Count() > 0)
                    {
                        string miApa = listadoAPAClientes.Where(x => x.Cliente == Cliente && NombreOT.ToLower().Contains(x.Keyword.ToLower())).Select(p => p.APA).FirstOrDefault();
                        APA += "ASSIGN= &quot;" + miApa + "&quot; &quot;" + it.NombreGrupo + "&quot; [#PgPosition] 1<br/>";
                    }
                    APA += "ASSIGN= &quot;" + OT + Prefijo + "[#PgPosition].p1.pdf&quot; &quot;" + it.NombreGrupo + "&quot; [#PgPosition] 1<br/>";
                    APA += "ASSIGN= &quot;" + it.NombreGrupo + "[%].p[#PgPosition].p1.pdf&quot; &quot;" + it.NombreGrupo + "&quot; [#PgPosition] 1<br/>";
                    APA += "ASSIGN= &quot;" + it.NombreGrupo + "[%].p[#PgPosition].pdf&quot; &quot;" + it.NombreGrupo + "&quot; [#PgPosition] 1<br/>";

                    //APA Especial para NATURA
                    //if (Cliente.ToLower().Contains("natura") && NombreOT.ToLower().Contains("catal")&& it.NombreGrupo.ToLower().Contains("pagina"))
                    //{
                    //    APA += "ASSIGN= &quot;[%]_[$]_[#PgPosition].p1.pdf&quot; &quot;" + it.NombreGrupo + "&quot; [#PgPosition] 1<br/>";
                    //}
                    //  arregloPrefijo = arregloPrefijo.Replace(Prefijoxml, "");
                    arregloPrefijo = arregloPrefijo.Substring(2, arregloPrefijo.Length - 2);
                }
                try
                {
                    if (miXML != "")
                    {
                        string NotaCompleta = Notas + "SI CARGA PAGINAS ANIDADAS(1 solo PDF con todas las paginas)<br/>" + NotasAnidadas;
                        miXMLenc = "<ConfiguracionTrabajo NOTA='Estimado Cliente: <br/><br/><br/>La nomenclatura a utilizar en sus archivos es la siguiente:<br/><br/>" + NotaCompleta.Replace("<br/>", "&#xA;\n") + "<br/><br/>En caso de dudas contacese con su reprentante de servicio al cliente.' Cliente='" + Cliente.Trim() + "' ColorFlow='" + (PrimerColorFlow != "" ? PrimerColorFlow : UltimoColorFlow) + "' APA='!APA 1.0 <br/>" +
                                        //"ASSIGN= &quot;000001p[#PgPosition].p1.pdf&quot; &quot;Paginas&quot; [#PgPosition] 1<br/>" +
                                        //"ASSIGN= &quot;000001Tapa[#PgPosition].p1.pdf&quot; &quot;Tapa&quot; [#PgPosition] 1<br/>" +
                                        APA +
                                        "' Username='cjerias' NombreTrabajo='" + NombreOT.Trim() + "' CSR='" + lblCSR.Text + "' CorreoCSR='' ClienteNuevo='Si'>";
                        //"' Username='cjerias' NombreTrabajo='" + NombreOT + "' CSR='" + item.CSR + "' CorreoCSR='" + item.CorreoCSR + "' ClienteNuevo='" + item.EstadoCliente + "'>";

                        miXML += "</ConfiguracionTrabajo>";
                        XElement xml = XElement.Parse(miXMLenc.Replace("<br/>", "&#xA;\n") + miXML);

                        XDocument pruebaXml = new XDocument(xml);
                        string a = HttpContext.Current.Server.MapPath("~/Prueba/" + OT.Trim() + "_" + NombreOT.Trim() + "_ConfiguracionTrabajo.xml");
                        pruebaXml.Save(a);

                        string FormaCreacion = "";
                        if (Request.QueryString["admin"] == null)
                        {
                            FormaCreacion = "Parte Manual";

                        }
                        else
                        {
                            FormaCreacion = "Parte Manual Completo";

                        }

                        Controller_XML xmlx = new Controller_XML();
                        string ale = xmlx.InsertSincronizacion(OT, NombreOT, Cliente, "Creada", 1, FormaCreacion, 0);

                        miXML = "";
                        Notas = "";


                        //INSERT ESTRUCTURA
                        Controller_XML xxml = new Controller_XML();
                        int ultimavrsion = xxml.InsertUltimaVersion(OT, "", 0, 0, 0, 0, "", 2);
                        if (ultimavrsion >= 1)
                        {
                            for (int i = 0; i < RadGrid1.Items.Count; i++)
                            {
                                int ALGO = xxml.InsertEstructura(OT, RadGrid1.Items[i]["NombreGrupo"].Text, Convert.ToInt32(RadGrid1.Items[i]["Paginas"].Text), Convert.ToInt32(RadGrid1.Items[i]["Inicio"].Text), Convert.ToInt32(RadGrid1.Items[i]["FormatoX"].Text.ToString()), Convert.ToInt32(RadGrid1.Items[i]["FormatoY"].Text.ToString()), RadGrid1.Items[i]["Papel"].Text, ultimavrsion.ToString(), 1);
                            }
                        }

                        if (Request.QueryString["admin"] == null)
                        {
                            string popupScript = "<script language='JavaScript'> alert('Parte creado correctamente');location.href='ParteManual.aspx' </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
 
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('Parte creado correctamente');location.href='ParteManual.aspx?admin=preprensa' </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
 
                        }

                    }

                }
                catch (Exception ex)
                {
                    string errorrr = ex.Message.ToString();
                }
                miXML = "";
                Notas = "";
            }//poner else con alerta

            //return "";
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            List<XMLFormato> listaFormato = new List<XMLFormato>();
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                XMLFormato xm = new XMLFormato();
                xm.Id= Convert.ToInt32(RadGrid1.Items[i]["Id"].Text);
                xm.NombreGrupo = RadGrid1.Items[i]["NombreGrupo"].Text;
                xm.Paginas = Convert.ToInt32(RadGrid1.Items[i]["Paginas"].Text);
                xm.Inicio = Convert.ToInt32(RadGrid1.Items[i]["Inicio"].Text);
                xm.Formato = RadGrid1.Items[i]["Formato"].Text;
                xm.FormatoX = Convert.ToInt32(RadGrid1.Items[i]["FormatoX"].Text);
                xm.FormatoY = Convert.ToInt32(RadGrid1.Items[i]["FormatoY"].Text);
                xm.Papel = RadGrid1.Items[i]["Papel"].Text;
                listaFormato.Add(xm);
            }
            if (e.CommandName == "CustomDelete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int id = Convert.ToInt32(item["Id"].Text);
                var itemToRemove = listaFormato.Single(r => r.Id == id);
                 listaFormato.Remove(itemToRemove);

               // var obj = listaFormato.FirstOrDefault(x => x.Id == id);
                //if (obj != null) obj.NombreGrupo = "NOTENGOIDEA";

                RadGrid1.DataSource = listaFormato;
                RadGrid1.DataBind();
                btnAgregar.Visible = true;
                btnModificar.Visible = false;
            }
            else if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;
                //int id = Convert.ToInt32(item["Id"].Text);
                lblId.Text= item["Id"].Text;
                txtNombreGrupo.Text = item["NombreGrupo"].Text;
                txtPaginas.Text = item["Paginas"].Text;
                txtInicio.Text = item["Inicio"].Text;
                txtFormatoX.Text = item["FormatoX"].Text;
                txtFormatoY.Text= item["FormatoY"].Text;
                DropDownList1.SelectedItem.Text= item["Papel"].Text;
                btnAgregar.Visible = false;
                btnModificar.Visible = true;
            } 

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            List<XMLFormato> listaFormato = new List<XMLFormato>();
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                XMLFormato xm = new XMLFormato();
                xm.Id = Convert.ToInt32(RadGrid1.Items[i]["Id"].Text);
                xm.NombreGrupo = RadGrid1.Items[i]["NombreGrupo"].Text;
                xm.Paginas = Convert.ToInt32(RadGrid1.Items[i]["Paginas"].Text);
                xm.Inicio = Convert.ToInt32(RadGrid1.Items[i]["Inicio"].Text);
                xm.Formato = RadGrid1.Items[i]["Formato"].Text;
                xm.FormatoX = Convert.ToInt32(RadGrid1.Items[i]["FormatoX"].Text);
                xm.FormatoY = Convert.ToInt32(RadGrid1.Items[i]["FormatoY"].Text);
                xm.Papel = RadGrid1.Items[i]["Papel"].Text;
                listaFormato.Add(xm);
            }
            if (txtNombreGrupo.Text != "" && txtPaginas.Text != "" && txtInicio.Text != "" && txtFormatoX.Text != "" && txtFormatoY.Text != "")
            {
                var obj = listaFormato.FirstOrDefault(x => x.Id == Convert.ToInt32(lblId.Text));
                if (obj != null)
                {
                    obj.NombreGrupo = txtNombreGrupo.Text;
                    obj.Paginas = Convert.ToInt32(txtPaginas.Text);
                    obj.Inicio = Convert.ToInt32(txtInicio.Text);
                    obj.Formato = txtFormatoX.Text + "x" + txtFormatoY.Text;
                    obj.FormatoX = Convert.ToInt32(txtFormatoX.Text);
                    obj.FormatoY = Convert.ToInt32(txtFormatoY.Text);
                    obj.Papel = DropDownList1.SelectedItem.ToString();

                    txtNombreGrupo.Text = "";
                    txtPaginas.Text = "";
                }
            }

            RadGrid1.DataSource = listaFormato;
            RadGrid1.DataBind();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
        }

 

        protected void btnBuscarNueva_Click(object sender, EventArgs e)
        {
            if (txtOTNueva.Text != "")
            {
                try
                {
                    Controller_XML xml = new Controller_XML();
                    XMLFormato mf = xml.ConsultaOTManual(txtOTNueva.Text);

                    lblTipo.Text = ((mf.NombreOT != null) ? "Existe" : "Nueva");
                    if (mf.NombreOT != null)
                    {
                        txtNombreOT.Visible = false;
                        lblNombreOT.Visible = true;
                        lblNombreOT.Text = mf.NombreOT;
                        ddlCliente.Visible = false;
                        lblCliente.Visible = true;
                        lblCliente.Text = mf.Cliente;
                        txtOT.Text = txtOTNueva.Text;

                        RadGrid1.DataSource = xml.ListaGruposPaginas(txtOTNueva.Text, 13);
                        RadGrid1.DataBind();
                        btnAgregar.Visible = true;
                        btnFinalizar.Visible = true;
                    }
                    else
                    {
                        ddlCliente.Visible = true;
                        lblNombreOT.Visible = false;
                        txtNombreOT.Visible = true;
                        lblCliente.Visible = false;
                        RadGrid1.DataSource = "";
                        RadGrid1.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

                if (Request.QueryString["admin"] == null)
                {
                    //string popupScript = "<script language='JavaScript'> alert('Parte creado correctamente');location.href='ParteManual.aspx' </script>";
                    //Page.RegisterStartupScript("PopupScript", popupScript);
                    Response.Redirect("ParteManual.aspx");
                }
                else
                {
                   Response.Redirect("ParteManual.aspx?admin=preprensa");
                }
        
           

            
        }
    }
}