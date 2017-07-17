    <%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="SolicitudPresupuesto.aspx.cs" Inherits="Intranet.ModuloComercial.View.SolicitudPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 110px;
        }
        .style2
        {
            width: 119px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            width: 134px;
        }
        .style5
        {
            height: 23px;
            width: 134px;
        }
        .style6
        {
            width: 289px;
        }
        .style7
        {
            height: 23px;
            width: 289px;
        }
        .style8
        {
            width: 155px;
        }
        .style9
        {
            width: 285px;
        }
        .style10
        {
            width: 285px;
            height: 23px;
        }
        .style11
        {
            width: 136px;
        }
        .style12
        {
            width: 136px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-top:10px;">
<fieldset>
<legend>Solicitud Presupuesto</legend>
    <table style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="lblCliente" runat="server" Text="Cliente: "></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblRUT" runat="server" Text="Rut: "></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Comuna: "></asp:Label>
                <asp:TextBox ID="txtComuna" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" Text="Pais: "></asp:Label>
                <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblContacto" runat="server" Text="Contacto: "></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</fieldset>
<br />
<fieldset>
<legend>Producto</legend>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                <asp:Label ID="lblCantEjemplares" runat="server" Text="Cant. Ejemplares:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCantEjemplares" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblTipoProducto" runat="server" Text="Tipo de Producto: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" 
                    Text="productos"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </fieldset>
    <br />
<fieldset>
<legend>Prepensa</legend>
<table style="width: 100%;">
    <tr>
        <td>
            &nbsp;
            <asp:Label ID="lblTipoArchivo" runat="server" Text="Tipo de Archivo"></asp:Label>
        </td>
        <td>
            &nbsp;<asp:Label ID="lblInside" runat="server" Text="Inside:"></asp:Label>
            <asp:RadioButton ID="rdSi" runat="server" GroupName="inside" Text="Si" />
            <asp:RadioButton ID="rdNo" runat="server" Checked="True" GroupName="inside" 
                Text="No" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
</fieldset>
<br />
<fieldset>
<legend>Detalle Interior</legend>
<table style="width:100%;">
        <tr>
            <td class="style4">
                <asp:Label ID="lblCantPaginas" runat="server" Text="Cant. de Paginas: "></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCantPaginas" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblFormatoCerrado" runat="server" Text="Formato Cerrado: "></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="lblAncho" runat="server" Text="Ancho: "></asp:Label>
                <asp:TextBox ID="txtAncho" runat="server" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAlto" runat="server" Text="Alto: "></asp:Label>
                <asp:TextBox ID="txtAlto" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblFormatoExtendido" runat="server" Text="Formato Extendido: "></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="Label6" runat="server" Text="Ancho: "></asp:Label>
                <asp:TextBox ID="txtAnchoFE" runat="server" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Alto: "></asp:Label>
                <asp:TextBox ID="txtAltoFE" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblColores" runat="server" Text="Colores: "></asp:Label>
            </td>
            <td class="style6">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="Tiro: "></asp:Label>
                <asp:TextBox ID="txtTiroInterior" runat="server" Width="80px"></asp:TextBox>
&nbsp;
                <asp:Label ID="Label9" runat="server" Text="Retiro: "></asp:Label>
                <asp:TextBox ID="txtRetiroInterior" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblPapel" runat="server" Text="Papel: "></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Lista de Presu</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="Tipo: "></asp:Label>
                <asp:TextBox ID="txtTipoPapelInt" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Gramaje: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                <asp:Label ID="Label12" runat="server" Text="Brillo: "></asp:Label>
                <asp:RadioButton ID="rdBrilloInts" runat="server" GroupName="brillo" 
                    Text="Si" />
                <asp:RadioButton ID="rdBrilloIntN" runat="server" Checked="True" 
                    GroupName="brillo" Text="No" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblRecubrimiento" runat="server" Text="Recubrimiento: "></asp:Label>
            </td>
            <td class="style7">
                </td>
            <td class="style3">
                </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblCertificacion" runat="server" Text="Certificacion: "></asp:Label>
            </td>
            <td class="style6">
                <asp:RadioButton ID="rdCertIntS" runat="server" GroupName="certificacion" 
                    Text="Si" />
                <asp:RadioButton ID="rdCertificacionNo" runat="server" Checked="True" 
                    GroupName="certificacion" Text="No" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label15" runat="server" Text="Tipo: "></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </fieldset>
    <br />
    <fieldset>
    <legend>Detalle Tapa</legend>
    
        <table style="width: 100%;">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label16" runat="server" Text="Papel: "></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Gramaje: "></asp:Label>
                    <asp:TextBox ID="txtGramae" runat="server" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label26" runat="server" Text="Brillo: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label24" runat="server" Text="Caracteristicas Tapa: "></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label18" runat="server" Text="Formato Cerrado: "></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label27" runat="server" Text="Ancho: "></asp:Label>
                    <asp:TextBox ID="txtAnchoFCDT" runat="server" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label28" runat="server" Text="Alto: "></asp:Label>
                    <asp:TextBox ID="txtAltoFCDT" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label19" runat="server" Text="Formato Extendido: "></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label29" runat="server" Text="Ancho: "></asp:Label>
                    <asp:TextBox ID="txtAnchoFEDT" runat="server" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label30" runat="server" Text="Alto: "></asp:Label>
                    <asp:TextBox ID="txtAltoFEDT" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="Label20" runat="server" Text="Colores: "></asp:Label>
                </td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label31" runat="server" Text="Tiro: "></asp:Label>
                    <asp:TextBox ID="txtTiroDT" runat="server" Width="80px"></asp:TextBox>
&nbsp;<asp:Label ID="Label32" runat="server" Text="Retiro: "></asp:Label>
                    <asp:TextBox ID="txtRetiroDT" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label21" runat="server" Text="Papel: "></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Gramaje: "></asp:Label>
                    <asp:TextBox ID="txtGramajeDT" runat="server" Width="80px"></asp:TextBox>
                    <asp:Label ID="Label34" runat="server" Text="Brillo: "></asp:Label>
                    <asp:RadioButton ID="rdBrilloDTS" runat="server" GroupName="brilloDT" 
                        Text="Si" />
                    <asp:RadioButton ID="rdBrilloDTN" runat="server" Checked="True" 
                        GroupName="brilloDT" Text="No" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label22" runat="server" Text="Recubrimiento: "></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label23" runat="server" Text="Certificacion: "></asp:Label>
                </td>
                <td class="style9">
                    <asp:RadioButton ID="rdCertDTS" runat="server" GroupName="certDT" Text="Si" />
                    <asp:RadioButton ID="rdCertDTN" runat="server" Checked="True" 
                        GroupName="certDT" Text="No" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label35" runat="server" Text="Tipo: "></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </fieldset>
    <br />
    <fieldset>
    <legend>Encuadernación</legend>
        <asp:Label ID="Label36" runat="server" Text="Tipo:"></asp:Label>
    </fieldset>
    <br />
<table style="width: 100%;">
    <tr>
        <td class="style11">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style11">
            <asp:Label ID="Label37" runat="server" Text="Otros: "></asp:Label>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style11">
            <asp:Label ID="Label38" runat="server" Text="Comisión Agencia: "></asp:Label>
            &nbsp;
        </td>
        <td>
            <asp:RadioButton ID="rdComisionN" runat="server" Checked="True" 
                GroupName="comision" Text="No" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; %Comisión.</td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style11">
            <asp:Label ID="Label39" runat="server" Text="Muestras: "></asp:Label>
        </td>
        <td>
            <asp:RadioButton ID="rdMuestraS" runat="server" GroupName="muestras" 
                Text="Si" />
            <asp:RadioButton ID="rdMuestraN" runat="server" Checked="True" 
                GroupName="muestra" Text="No" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style12">
        </td>
        <td class="style3">
        </td>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td class="style11">
            <asp:Label ID="Label40" runat="server" Text="Observaciones:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtObservaciones" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
    </div>
</asp:Content>


