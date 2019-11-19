<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Intranet.Dashboard.View.Dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dashboard Produccion</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <style>

        /*.header_fijo {
  width: 750px;
  table-layout: fixed;
  border-collapse: collapse;
}
.header_fijo thead {
  background-color: #333;
  color: #FDFDFD;
}
.header_fijo thead tr {
  display: block;
  position: relative;
}
.header_fijo tbody {
  display: block;
  overflow: auto;
  width: 100%;
  height: 300px;
}*/
    </style>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
            <table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="850px">
        <tr>
               <td>
                <asp:Label ID="lblMaquina" runat="server" Text="Maquina: "></asp:Label>
               
            </td>
            <td>
               
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha: "  ></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </td>
        </tr>
    </table>
<br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
