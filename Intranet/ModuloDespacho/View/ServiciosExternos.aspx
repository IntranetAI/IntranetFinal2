<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="ServiciosExternos.aspx.cs" Inherits="Intranet.ModuloDespacho.View.ServiciosExternos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 113px;
        }
        .style3
        {
            width: 394px;
        }
        .style4
        {
        }
        .style5
        {
            width: 70px;
        }
        .style6
        {
        }
        .style7
        {
            width: 166px;
        }
        .style8
        {
            width: 672px;
        }
        .style9
        {
            width: 206px;
        }
    </style>
    <script>
        function openGame(ID) {
            var usuario = '<%=Session["Usuario"] %>';
            window.open('Ingre_DetFact.aspx?id=' + ID+ '&u='+usuario, 'Detalle Factura', 'left=160,top=100,width=586 ,height=540,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <fieldset>
        <legend>Detalle Proveedor</legend>
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Rut:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                &nbsp;
                    <asp:TextBox ID="txtRut" runat="server" AutoPostBack="True" 
                        ontextchanged="txtRut_TextChanged"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:Label ID="Label4" runat="server" Text="Nombre:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProveedor" runat="server" Width="220px"></asp:TextBox>
                    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                        onclick="btnFiltro_Click" />
                &nbsp;
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Visible="False" 
                        onclick="btnNuevo_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Direccion:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style4" colspan="2">
                    &nbsp;
                    <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Comuna:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;
                    <asp:Label ID="lblComuna" runat="server"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Ciudad:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                &nbsp;
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Fecha Factura:"></asp:Label>
                </td>
                <td class="style9">
                 &nbsp;
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                   <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFecha" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                 &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="N° de Factura:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style6" colspan="3">
                 &nbsp;
                    <asp:TextBox ID="txtNroFactura" runat="server" AutoPostBack="True" 
                        ontextchanged="txtNroFactura_TextChanged" MaxLength="10"></asp:TextBox>
                &nbsp;<asp:Label ID="lblValidacionFactura" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style6" colspan="3" align="right">
                    <asp:Button ID="btnDet" runat="server" onclick="btnDetalle_Click" 
                        Text="Ingresar Detalle Factura" Visible="False" Width="193px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
    <legend>Detalle Factura</legend>
    
    <telerik:RadGrid ID="RadGrid4" runat="server" Height="300px" Skin="Outlook" >
                                <ClientSettings EnableRowHoverStyle="True" EnablePostBackOnRowClick="True">
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_Factura">
                                    <NoRecordsTemplate>
                                        <div style="text-align: center;">
                                            <br />
                                            ¡ No se han encontrado registros !<br />
                                        </div>
                                    </NoRecordsTemplate>
                                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                            SortExpression="OT" UniqueName="OT">
                                            <ItemStyle Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cant" HeaderText="Cant" SortExpression="Cant"
                                            UniqueName="Cant">
                                            <ItemStyle Width="20px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" 
                                            SortExpression="Proceso" UniqueName="Proceso">
                                            <ItemStyle Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Formato" HeaderText="Formato" SortExpression="Formato"
                                            UniqueName="Formato">
                                            <ItemStyle Width="30px" />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Unidad" HeaderText="Unidad" SortExpression="Unidad"
                                            UniqueName="Unidad">
                                            <ItemStyle Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Barniz" HeaderText="Caras" UniqueName="Barniz">
                                            <ItemStyle  Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" UniqueName="Tipo">
                                            <ItemStyle  Width="30px" />
                                        </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Total" HeaderText="Total" UniqueName="Total">
                                            <ItemStyle  Width="40px" />
                                        </telerik:GridBoundColumn>

                                    </Columns>
                                </MasterTableView>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
    </fieldset>
   
    <fieldset>
    <legend>Detalle Factura</legend>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style8" align="right">
                    <asp:Label ID="Label9" runat="server" Text="Valor Neto:" Font-Bold="True"></asp:Label>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                    <asp:Label ID="lblValorNeto" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;
                    </td>
                <td class="style8" align="right">
                   
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="19% I.V.A:"></asp:Label>
                     &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                    <asp:Label ID="lblIVA" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;
                    </td>
                <td class="style8" align="right">
                    <asp:Label ID="Label10" runat="server" Text="Costo Total:" Font-Bold="True"></asp:Label>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                    <asp:Label ID="lblCostoTotal" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
