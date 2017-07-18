<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Sincronizar_OT.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Sincronizar_OT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><br />
        <div style="vertical-align:middle;" align="center"><asp:ImageButton ID="btnFiltro" runat="server" Text="Filtrar"  OnClick="btnFiltro_Click1"
                        ImageUrl="~/Images/sync.png" Height="150px"/><br />
        Sincronizar OT</div>
    
        <div id="DivMensaje" runat="server" align="center">
            <asp:Image ID="Image4" runat="server" />
&nbsp;<asp:Label ID="lblOTSusc" runat="server" Text=""></asp:Label></div>
        <br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br />
</asp:Content>
