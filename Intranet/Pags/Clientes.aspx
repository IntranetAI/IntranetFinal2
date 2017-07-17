<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/PagsMaster.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Intranet.Pags.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div style="width:800px;padding-left:250px;">
        <h3 style="color:#0078AD;">
            <asp:Label ID="Label9" runat="server" Font-Size="X-Large" Text="Clientes"></asp:Label>
            </h3>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Gray" 
                Text="A Impresores S.A.  "></asp:Label>
        <asp:Label ID="Label2" runat="server" ForeColor="#4C4C4C" 
                Text="atiende a un variado número de Clientes en el Mercado Local y Latinoamericano. Los cuales se agrupan en los siguientes segmentos:"></asp:Label>
        <br />
        <table>
            <tr>
                <td><div><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Gray" Text="Retail"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Gray" Text="Revistas"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image3" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Gray" Text="Textos de Estudios"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Gray" Text="Libros"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image5" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Gray" Text="Memorias"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image6" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Gray" Text="Diarios"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image7" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Gray" Text="Directorios Telefónicos"></asp:Label></td>
            </tr>
            <tr>
                <td><div><asp:Image ID="Image8" runat="server" ImageUrl="~/Images/tickAzul.PNG" /></div></td>
                <td><asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Gray" Text="Especiales"></asp:Label></td>
            </tr>
        </table>
 </div>
</asp:Content>
