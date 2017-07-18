<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcesarDocumento.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.ProcesarDocumento" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function contar() {
            var elem = document.getElementsByName("cuentacorriente");
            var elementos = document.getElementsByName("centro_costo");
            texto = "";
            for (y = 0; y < elem.length; y++) {
                texto = texto + elem[y].value + "-";
            }
            for (x = 0; x < elementos.length;x++)
                texto = texto + elementos[x].value + ",";
            
            //return texto;
//            alert(texto);
            PageMethods.ActualizarDatos(texto);
            //location.href = '@Url.Action("MensajeLeido", "Home")?usuario=' + '@Session["myVar2"]' + '&info=' + texto
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <td align="center" colspan="2">
                    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server" EnablePageMethods="true">
                    </telerik:RadScriptManager>
                    Procesar Documento</td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                    <legend>Datos Documento</legend>
                    N° Docto.:
                    <asp:Label ID="lblNumDoct" runat="server" Text=""></asp:Label>
                &nbsp;
                    Razón Social:
                    <asp:Label ID="lblRazonSocial" runat="server" Text=""></asp:Label>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td  colspan="2">
                    <fieldset>
                    <legend>Datos del Cliente</legend>
                    Dirección:
                    <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                &nbsp;
                    País:
                    <asp:Label ID="lblPais" runat="server" Text=""></asp:Label>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <fieldset>
                    <legend>Datos Producto</legend>
                    <div align="left">N° OT: 
                    <asp:Label ID="lblOT" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    Producto:&nbsp;
                    <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label></div>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    
                    
                   
                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" Width="500px">
                        <mastertableview autogeneratecolumns="False" datakeynames="IDDocMercantil">
                            <norecordstemplate>
                                <div style="text-align:center;">
                                    <br />¡ No se han encontrado OTs Nuevas !<br /></div>
                            </norecordstemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="NombreConceCon" HeaderText="Concepto Contable" 
                                    ItemStyle-Width="30px" ReadOnly="True" SortExpression="NombreConceCon" 
                                    UniqueName="NombreConceCon">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="valorNeto" HeaderText="Valor" ItemStyle-Width="150px" 
                                    SortExpression="valorNeto" UniqueName="valorNeto" DataFormatString="{0:c}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreCuenta" HeaderText="Cuenta Contable" ItemStyle-Width="150px" 
                                    SortExpression="NombreCuenta" UniqueName="NombreCuenta">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreCosto" HeaderText="Centro Costo" ItemStyle-Width="150px" 
                                    SortExpression="NombreCosto" UniqueName="NombreCosto">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </mastertableview>
                        <clientsettings enablerowhoverstyle="true">
                        </clientsettings>
                        <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default" 
                            enableimagesprites="True">
                        </headercontextmenu>
                    </telerik:RadGrid>
                    <div align="center">
                        <input id="Button1" type="button" value="Cancelar" onclick="self.close();return false;"/>
                       <%-- <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="self.close();return false;"/>--%>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnActualizar" type="button" value="Procesar" onclick="self.close();return false;"/>
                        <%--<asp:Button ID="btnActualizar" runat="server" Text="Procesar" 
                             /><%--onclick="btnActualizar_Click"--%>
                    </div>
                    </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
