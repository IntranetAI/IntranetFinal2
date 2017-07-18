<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso_Indigo.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Ingreso_Indigo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function addPoints(input) {
            var str = new String(input.value);
            var amount = str.split('.').join('');
            amount = amount.split("").reverse();

            var output = "";
            for (var i = 0; i <= amount.length - 1; i++) {
                output = amount[i] + output;
                if ((i + 1) % 3 == 0 && (amount.length - 1) !== i) output = '.' + output;
            }
            input.value = output;
        }
        function pulsarTiraje(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla == 13 || tecla > 31 && (tecla < 48 || tecla > 57)) return false;
        }
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
        <table>
            <tr>
                <td>OT</td>
                <td>
                    <asp:TextBox ID="txtOT" runat="server" AutoPostBack="True" Width="60px"
                        ontextchanged="txtOT_TextChanged"></asp:TextBox>
                </td>
                <td>Nombre OT:</td>
                <td>
                    <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Tiraje</td>
                <td><asp:TextBox ID="txtTiraje" runat="server"  Width="60px" onkeyup="addPoints(this)"></asp:TextBox></td>
                <td>Maquina</td>
                <td>
                    <asp:DropDownList ID="ddlMaquina" runat="server">
                        <asp:ListItem>Selecionar</asp:ListItem>
                        <asp:ListItem>Indigo</asp:ListItem>
                        <asp:ListItem>Esko</asp:ListItem>
                        <asp:ListItem>Escodix</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Contador Inicio</td>
                <td>
                    <asp:TextBox ID="txtInicio" runat="server" onkeyup="addPoints(this)" Width="70px"></asp:TextBox>
                </td>
                <td>Contador Termino</td>
                <td>
                    <asp:TextBox ID="txtTermino" runat="server" onkeyup="addPoints(this)"  Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Nombre Pliego</td>
                <td colspan="3">
                    <asp:TextBox ID="txtPliego" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tipo de Papel</td>
                <td colspan="3">
                    <asp:TextBox ID="txtPapel" runat="server" Width="300px"></asp:TextBox>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        TargetControlID="txtPapel" UseContextKey="True" CompletionInterval="100"
                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList">
                    </asp:AutoCompleteExtender>
                </td>
            </tr>
            <tr>
                <td>Pliegos Impresos</td>
                <td>
                    <asp:TextBox ID="txtPliego_Impresos" runat="server"  onkeyup="addPoints(this)"  Width="70px"></asp:TextBox>
                </td>
                <td>Pliegos Malos</td>
                <td>
                    <asp:TextBox ID="txtPliego_Malos" runat="server" onkeyup="addPoints(this)"  Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Color</td>
                <td>
                    <asp:DropDownList ID="ddlColor1" runat="server">
                        <asp:ListItem>X</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                    /
                    <asp:DropDownList ID="ddlColor2" runat="server">
                        <asp:ListItem>X</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Formato del Pliego</td>
                <td>
                    <asp:TextBox ID="txtAncho" runat="server" Width="23px" MaxLength="3"></asp:TextBox>x<asp:TextBox ID="txtLargo" runat="server" Width="23px" MaxLength="3"></asp:TextBox>
                </td>
            </tr>
  
            <tr>
                <td>Observación</td>
                <td colspan="3">
                    <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="300px" Height="82px"></asp:TextBox>
                </td>
            </tr>
        </table>
    <br />
    <div align="center">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
            onclick="btnGuardar_Click" />&nbsp;
        <asp:Button ID="btnSalir" runat="server" Text="Salir" 
            onclick="btnSalir_Click" />
    </div>
    </form>
</body>
</html>
