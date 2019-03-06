<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Intranet.Inventario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnlEncabezado" runat="server" Width="233px">
        <div align="center">
            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Inventario
            </h2>
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        </div>
        </asp:Panel>
        <asp:Panel ID="pnlInicio" runat="server" Width="233px">
                <asp:Button ID="btnExistente" runat="server" Text="Existente" OnClick="btnExistente_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />

    </asp:Panel>
     <asp:Panel ID="pnlNuevo" runat="server" Width="233px">

           <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text="Inventario: "></asp:Label>
           <asp:TextBox ID="txtNombre" runat="server" Width="105px"></asp:TextBox>
           <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="Crear" />
           <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
           <br />
           &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text="Codigo:"></asp:Label>
           <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" OnTextChanged="txtCodigo_TextChanged" Width="100px"></asp:TextBox>
    </asp:Panel>
            <asp:Panel ID="pnlExistente" runat="server" Width="233px">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" Text="N° Inventario:"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server" Width="81px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="45px" OnClick="btnBuscar_Click" />

                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text="Inventario: "></asp:Label>
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                <br />
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" Text="Codigo:"></asp:Label>
                <asp:TextBox ID="txtCodigo0" runat="server" AutoPostBack="True"  Width="100px" OnTextChanged="txtCodigo0_TextChanged"></asp:TextBox>

    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server" Width="234px" Visible="False">
        Detalle
        <br />

         <asp:Label ID="lblTabla" runat="server"></asp:Label>
    </asp:Panel>


       


    </form>
</body>
</html>
