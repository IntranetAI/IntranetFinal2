<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prod_Agregar_Fecha.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Prod_Agregar_Fecha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%;text-align:center;">
        <tr>
            <td>
                <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Larger"
                    Text="Asignación Fecha de Entrega"></asp:Label>
            </td>
        </tr>
    </table>

        <fieldset>
    <legend>Datos OT</legend>
 
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="OT"
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    :&nbsp;<asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    :&nbsp;<asp:Label ID="lblNomOT" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cliente"
                        Font-Bold="True"></asp:Label>
                </td>
                <td colspan="3">
                    :&nbsp;<asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Tiraje Original" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    :&nbsp;
                    <asp:Label ID="lblTiraje" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    
    </fieldset>
              <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
             </asp:ToolkitScriptManager>
 
    <fieldset>
    <legend>Detalle Fecha Asignada</legend>
            <table>
                <tr>
                    <td><asp:Label ID="Label28" runat="server" Text="Fecha Entrega: "></asp:Label></td>
                    <td><asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha" 
                    Enabled="True" Format="dd/MM/yyyy"></asp:CalendarExtender>
                    &nbsp;&nbsp;<asp:DropDownList ID="ddlHora" runat="server">
                    <asp:ListItem Value="0">00:00</asp:ListItem>
                    <asp:ListItem Value="1">01:00</asp:ListItem>
                    <asp:ListItem Value="2">02:00</asp:ListItem>
                    <asp:ListItem Value="3">03:00</asp:ListItem>
                    <asp:ListItem Value="4">04:00</asp:ListItem>
                    <asp:ListItem Value="5">05:00</asp:ListItem>
                    <asp:ListItem Value="6">06:00</asp:ListItem>
                    <asp:ListItem Value="7">07:00</asp:ListItem>
                    <asp:ListItem Value="8">08:00</asp:ListItem>
                    <asp:ListItem Value="9">09:00</asp:ListItem>
                    <asp:ListItem Value="10">10:00</asp:ListItem>
                    <asp:ListItem Value="11">11:00</asp:ListItem>
                    <asp:ListItem Value="12">12:00</asp:ListItem>
                    <asp:ListItem Value="13">13:00</asp:ListItem>
                    <asp:ListItem Value="14">14:00</asp:ListItem>
                    <asp:ListItem Value="15">15:00</asp:ListItem>
                    <asp:ListItem Value="16">16:00</asp:ListItem>
                    <asp:ListItem Value="17">17:00</asp:ListItem>
                    <asp:ListItem Value="18">18:00</asp:ListItem>
                    <asp:ListItem Value="19">19:00</asp:ListItem>
                    <asp:ListItem Value="20">20:00</asp:ListItem>
                    <asp:ListItem Value="21">21:00</asp:ListItem>
                    <asp:ListItem Value="22">22:00</asp:ListItem>
                    <asp:ListItem Value="23">23:00</asp:ListItem>
                    <asp:ListItem Value="24">23:59</asp:ListItem>
                </asp:DropDownList></td>
                    <td>Cant. Despachar</td>
                    <td><asp:TextBox ID="txtCantidad" runat="server" Width="100px" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><div style="margin-top:-35px;"><asp:Label ID="Label6" runat="server" Text="Observación : "></asp:Label></div></td>
                    <td colspan="3"><asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Height="60px" Width="600px"></asp:TextBox>
                </td>
                </tr>
                <tr><td colspan="4" align="right">
                <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click"/></td></tr>
            </table>
                <div style="min-height:100px; max-height:225px;overflow:auto;">
                <telerik:radgrid ID="RadGrid1" runat="server" 
                    Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand">
                    <PagerStyle Mode="NumericPages"></PagerStyle>
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDProduccion">
                    <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns>
                        <telerik:GridBoundColumn  DataField="IDProduccion" Visible="False" HeaderText="ID" 
                            SortExpression="IDProduccion" UniqueName="IDProduccion">
                            <ItemStyle Width="10px" />
                        </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="OT" SortExpression="NumeroOT" UniqueName="NumeroOT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" 
                            SortExpression="Tiraje" UniqueName="TirajeProd" >
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FechaProduccion" HeaderText="Fecha Produccion" 
                            SortExpression="FechaProduccion" UniqueName="FechaProduccion" 
                            DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-Width="100px" >
                        </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="observacion" HeaderText="Observacion" SortExpression="observacion" UniqueName="observacion">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit" Font-Underline="true">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="editCell" Width="50px"></ItemStyle>
                    </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
            </div>
                <div style="text-align:center;">
                <asp:Button ID="btnFinalizar" runat="server" onclick="btnFinalizar_Click" 
                    Text="Guardar y Finalizar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click" Text="Salir" 
                        Width="88px" />
                    </div>
                  
    </fieldset>
    </form>
</body>
</html>
