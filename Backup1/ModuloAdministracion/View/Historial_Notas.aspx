<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historial_Notas.aspx.cs"
    Inherits="Intranet.ModuloAdministracion.View.Historial_Notas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Atender Solicitud</title>
    <script src="../../js/jquery-ui-1.10.3.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Asignar(id, ot, componente, solFL, solKG, preid, usuario) {
            window.open('AsignarPliegosPopUp.aspx?id=' + id + '&ot=' + ot + '&comp=' + componente + '&solFL=' + solFL + '&solKG=' + solKG + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

        function openGame(OT) {
            var respuesta = PageMethods.Delete(OT);
            location.reload();
        }

        function Consultar(ot, componente, papel, gramaje, ancho, preid, usuario) {
            window.open('InventarioMetricsBobina.aspx?ot=' + ot + '&componente=' + componente + '&papel=' + papel + '&gramaje=' + gramaje + '&ancho=' + ancho + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=800,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

        function Configurar() {
            var algo = document.getElementById("TabContainer1_TabPanel0_lblVendedor").innerHTML;
            document.getElementById("TabContainer1_TabPanel0_lblVendedor").style.display = "none";
            document.getElementById("TabContainer1_TabPanel0_TextBox2").style.display = "block";
            document.getElementById("TabContainer1_TabPanel0_txtObservacion").style.height = "68px";
            document.getElementById("TabContainer1_TabPanel0_TextBox2").value = document.getElementById("TabContainer1_TabPanel0_lblVendedor").innerHTML;
        }

        $(document).ready(function () {
            $("#TabContainer1_TabPanel0_ddlTipoNota").change(function () {
                var select = document.getElementById("TabContainer1_TabPanel0_ddlTipoNota");
                var TipoNota = select.options[select.selectedIndex].text;
                if (TipoNota == "Problema") {
                    document.getElementById("TabContainer1_TabPanel0_lblTitulo").innerHTML = "Ingreso Detalle Problema";
                    document.getElementById("TabContainer1_TabPanel0_lblAsunto").innerHTML = "Problema:";
                    document.getElementById("TabContainer1_TabPanel0_ddlProblema").disabled = false;
                }
                else if (TipoNota == "Solucion") {
                    document.getElementById("TabContainer1_TabPanel0_lblTitulo").innerHTML = "Ingreso Detalle Solución";
                    document.getElementById("TabContainer1_TabPanel0_lblAsunto").innerHTML = "Solucción:";
                    document.getElementById("TabContainer1_TabPanel0_ddlProblema").disabled = false;
                }
                else {
                    document.getElementById("TabContainer1_TabPanel0_lblTitulo").innerHTML = "Ingreso Detalle";
                    document.getElementById("TabContainer1_TabPanel0_lblAsunto").innerHTML = "";
                    document.getElementById("TabContainer1_TabPanel0_ddlProblema").disabled = true;

                }
            });

            $("#TabContainer1_TabPanel0_ddlProblema").change(function () {
                var OT = document.getElementById("TabContainer1_TabPanel0_lblOT").innerHTML;
                var select = document.getElementById("TabContainer1_TabPanel0_ddlProblema");
                var Problema = select.options[select.selectedIndex].text;
                if (Problema != "Seleccionar") {
                    $.ajax({
                        url: "Historial_Notas.aspx/CorreosResponsable",
                        type: "post",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        data: "{'Problema':'" + Problema + "','OT':'" + OT + "'}",
                        success: function (msg) {
                            document.getElementById("TabContainer1_TabPanel0_lblVendedor").innerHTML = msg.d;
                        },
                        error: function () {
                            alert('¡Ha Ocurrido un Error!');
                        }
                    });
                }
            });
            //TabContainer1_TabPanel0_ddlTipoNota
        });
    </script>
    <style type="text/css">
        .divTitulo
        {
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding: 5px;
            border: 1px solid #959595;
            text-align: left;
        }
        .divSeccion
        {
            padding: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
        .divEtiqueta
        {
            display: inline-block;
            padding: 5px;
            font-weight: bold;
            text-align: left;
        }
        .divCampo
        {
            display: inline-block;
            text-align: left;
        }
    </style>
    <script src="../../js/funciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="True" EnableScriptLocalization="False">
    </asp:ToolkitScriptManager>
    <div align="center">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="520px"
        Width="100%">
        <asp:TabPanel runat="server" HeaderText="Codigo Bobina" ID="TabPanel0">
            <HeaderTemplate>
                Agregar Nota</HeaderTemplate>
            <ContentTemplate>
                <div>
                    <div class="divTitulo">
                        Detalle OP</div>
                    <div class="divSeccion">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="width:140px;">
                                    <asp:Label ID="Label3" runat="server" Text="Numero OT:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                                </td>
                                <td style="width:100px;">
                                    <asp:Label ID="Label8" runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Fecha Liquidación:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaLiqui" runat="server"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Cliente:" Font-Bold="True"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="divTitulo">Tipo Requerimiento</div>
                    <div class="divSeccion">
                    <table><tr><td>&nbsp;</td><td>
                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Tipo Nota: "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoNota" runat="server">
                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                        <asp:ListItem>Problema</asp:ListItem>
                                        <asp:ListItem>Solucion</asp:ListItem>
                                    </asp:DropDownList>
                                </td></tr> </table>
                    </div>
                        <div class="divTitulo"><asp:Label ID="lblTitulo" runat="server" Text="Ingreso Detalle Problema"></asp:Label></div>
                        <div class="divSeccion">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style="width:120px;">
                                        <asp:Label ID="lblAsunto" runat="server" Text="Problema:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProblema" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="vertical-align:top;">
                                        <asp:Label ID="Label19" runat="server" Text="Responsable: " Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan = "2" style="width:300px;">
                                        <asp:Label ID="lblVendedor" runat="server"></asp:Label>
                                        <asp:TextBox ID="TextBox2" runat="server" style="width:100%; display:none;" 
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                         &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        &nbsp;<button id="btnConfigurar" type="button" onclick="javascript:Configurar();">Configuración</button>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    <div class="divTitulo">
                        Observación
                    </div>
                    <div class="divSeccion">
                            <asp:TextBox ID="txtObservacion" runat="server" Height="110px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <div align="center">
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Style="height: 26px" OnClick="btnGrabar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFiltro" runat="server" Text="Cancelar" 
                        onclick="btnFiltro_Click" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Codigo Bobina" ID="TabPanel1">
            <HeaderTemplate>
                Historial Notas
            </HeaderTemplate>
            <ContentTemplate>
                <div style="height: 525px; width: 100%; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid3" runat="server" Skin="Outlook">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="FechaFactura" HeaderText="Fecha Reg." SortExpression="FechaFactura" UniqueName="FechaFactura" ItemStyle-Width="70px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="Numero OP" SortExpression="OT" UniqueName="OT" ItemStyle-Width="70px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VerMas" HeaderText="Correos Resp." SortExpression="VerMas" UniqueName="VerMas" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tipo" SortExpression="Tiraje" UniqueName="Tiraje" ItemStyle-Width="80px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Accion" HeaderText="Asunto" SortExpression="Accion" UniqueName="Accion" ItemStyle-Width="150px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="numeroFactura" HeaderText="Observación" SortExpression="Tiraje" UniqueName="Tiraje" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" HeaderText="Historial Liquidación" runat="server">
            <HeaderTemplate>
                Historial Liquidación
            </HeaderTemplate>
            <ContentTemplate>
                <div style="height: 525px; width: 100%; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="FechaLiquidacion" HeaderText="Fecha Liqui." SortExpression="FechaLiquidacion"
                                    UniqueName="FechaLiquidacion" ItemStyle-Width="80px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OP" SortExpression="OT"
                                    UniqueName="OT" ItemStyle-Width="60px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OP" SortExpression="NombreOT"
                                    UniqueName="NombreOT" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EstadoOT" HeaderText="Estado OT" SortExpression="EstadoOT" ItemStyle-Width="100px"
                                    UniqueName="EstadoOT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Usuario" SortExpression="Cliente"  ItemStyle-Width="100px"
                                    UniqueName="Cliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="numeroFactura" HeaderText="Observacion" SortExpression="numeroFactura" UniqueName="numeroFactura" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" HeaderText="Detalle Facturación" runat="server">
            <HeaderTemplate>
                Detalle Facturación
            </HeaderTemplate>
            <ContentTemplate>
                <div style="height: 525px; width: 100%; overflow: auto;">
                    <telerik:RadGrid ID="RadGridfacturacion" runat="server" Skin="Outlook">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="FechaLiquidacion" HeaderText="Fecha Liqui." SortExpression="FechaLiquidacion"
                                    UniqueName="FechaLiquidacion" ItemStyle-Width="80px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="numeroFactura" HeaderText="N°fact." SortExpression="numeroFactura" UniqueName="numeroFactura">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="Detalle" SortExpression="OT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Cantidad" SortExpression="Tiraje" UniqueName="Tiraje">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValorNeto" HeaderText="ValorNeto" SortExpression="ValorNeto" UniqueName="ValorNeto">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VerMas" HeaderText="" SortExpression="VerMas" UniqueName="VerMas">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" HeaderText="Detalle Despacho" runat="server">
            <HeaderTemplate>Detalle Despacho</HeaderTemplate>
            <ContentTemplate>
                <div style="max-height: 480px; width: 100%; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid2" runat="server" Skin="Outlook">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Despacho" SortExpression="FechaImpresion"  UniqueName="FechaImpresion" ItemStyle-Width="120px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoMovimiento" HeaderText="TipoMovimiento" SortExpression="TipoMovimiento" UniqueName="TipoMovimiento" ItemStyle-Width="80px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Folio" HeaderText="Nro Guia" SortExpression="Folio" UniqueName="Folio" ItemStyle-Width="60px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal"  UniqueName="Sucursal">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Despachado" SortExpression="Despachado"  ItemStyle-HorizontalAlign="Right"   UniqueName="Despachado" ItemStyle-Width="60px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
                <asp:Label ID="lblTabla" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </form>
</body>
</html>
