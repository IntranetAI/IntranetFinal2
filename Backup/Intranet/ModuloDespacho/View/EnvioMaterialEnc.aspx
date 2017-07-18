<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EnvioMaterialEnc.aspx.cs" Inherits="Intranet.ModuloDespacho.View.EnvioMaterialEnc" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style2
        {
            width: 183px;
        }
        .style3
        {
            width: 301px;
        }
        .style4
        {
            width: 133px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div id="contenido"></div>
<div >
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Ingrese OT:" Font-Bold="True"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
        Text="Buscar" />
    </div>
    <br />
   <fieldset style="margin-left:90px;margin-right:90px;">
   <legend>Datos OT</legend>
   
       <table style="width:100%;">
           <tr>
               <td class="style2">
                   &nbsp;</td>
               <td class="style4">
                   <asp:Label ID="Label4" runat="server" Text="Nombre OT: " Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style2">
                   &nbsp;</td>
               <td class="style4">
                   <asp:Label ID="Label6" runat="server" Text="Tiraje OT:" Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style2">
                   &nbsp;</td>
               <td class="style4">
                   <asp:Label ID="Label8" runat="server" Text="Cantidad a Enviar:" 
                       Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtCantidadAEnviar" runat="server"></asp:TextBox>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style2">
                   &nbsp;</td>
               <td class="style4">
                   <asp:Label ID="Label9" runat="server" Text="Peso: " Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style2">
                   &nbsp;</td>
               <td class="style4">
                   <asp:Label ID="Label10" runat="server" Text="Descripcion: " Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtDescripcion" runat="server" style="margin-bottom: 0px" 
                       Height="146px" TextMode="MultiLine" Width="446px"></asp:TextBox>
               </td>
               <td>
                   &nbsp;</td>  
           </tr>
       </table>
       <div id="divMensaje" align="center" runat="server" visible="false">
           <asp:Image ID="imgMensaje"  runat="server" />
&nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label>
       </div>
       <div align="center">
           <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
               onclick="btnGuardar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" />
       &nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
       </div>
   <br />
   <br />

   </fieldset>
      <br />
   <br />
      <br />
   <br />
      <br />
   <br />
      <br />
   <br />
  
</asp:Content>
