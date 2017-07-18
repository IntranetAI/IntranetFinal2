<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help_DeskFormulario.aspx.cs"
    Inherits="Intranet.ModuloAdmin.View.Help_DeskFormulario" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC;
        margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width: 450px;">
        <tbody>
            <tr style="height: 22px; background: #f3f4f9; font: 17px Arial, Helvetica, sans-serif;
                color: #003e7e; text-align: left;">
                <td colspan="2" style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    Ingreso de Registro
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Label ID="Label3" runat="server" Text="Tipo Incidencia: "></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:DropDownList ID="ddlTipo" runat="server" Width="300px" 
                        OnTextChanged="ddlTipo_TextChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Label ID="lblIncidencia" runat="server" Text="Incidencia: "></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:DropDownList ID="ddlIncidencia" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Label ID="lblFeIncidencia" runat="server" Text="Fecha Incidencia: "></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="300px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Label ID="lblArea" runat="server">Area: </asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:DropDownList ID="ddlAreas" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Label ID="Label1" runat="server">Depto: </asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:TextBox ID="txtDepto" runat="server" Width="300px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;vertical-align:top;">
                    <asp:Label ID="Label2" runat="server">Observación: </asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;">
                    <asp:TextBox ID="txtObs" runat="server" Height="65px" TextMode="MultiLine" MaxLength="350"
                        Width="300px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td colspan="2" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;" class="style20">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        onclick="btnGuardar_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
