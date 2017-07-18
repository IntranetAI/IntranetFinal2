<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Reimpresion_Guias.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.Reimpresion_Guias" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .style7
        {
            height: 13px;
            width: 376px;
        }
        .style8
        {
            width: 406px;
            height: 13px;
        }
        .style9
        {
            height: 13px;
        }
        .style10
        {
            width: 376px;
        }
        #DivMensaje
        {
            width: 1092px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Reimpresión de Guias</h3>
</div>--%>
    <br />
    <table style="width:100%;">
          <tr>
            <td class="style7">
                </td>
            <td class="style8">
                <asp:Label ID="Label3" runat="server" Text="Código Pallet: "></asp:Label>
&nbsp;<asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
&nbsp;
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
            </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style10">
                </td>
            <td class="style2">
                </td>
            <td>
                </td>
        </tr>
    </table>
    <div align="center" id="DivMensaje" runat="server">
             <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
               
            </div>
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="pnlResultado" runat="server" Visible="False">
    <div id="divResultado" runat="server" align="center" style="height:50px;">
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" 
            onclick="btnNuevo_Click" />
    </div>
    </asp:Panel>
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />
    <br />
    <br />
    <br />
    <br />
    <br />   
</asp:Content>
