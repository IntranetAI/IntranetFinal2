<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudBobinaMaquina.aspx.cs" Inherits="Intranet.ModuloMateriaPrima.View.SolicitudBobinaMaquina" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Atender Solicitud</title>
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

        function Buscar() {
        
        }
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
        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
        Height="750px" Width="1200px">
        <asp:TabPanel runat="server" HeaderText="Codigo Bobina" ID="TabPanel0">
            <HeaderTemplate>
                Solicitud Papel</HeaderTemplate>
            <ContentTemplate>
                <div>
                    <div class="divTitulo">
                        Detalle OP</div>
                    <div class="divSeccion">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style14">
                                    &nbsp;
                                </td>
                                <td class="style15">
                                    <asp:Label ID="Label3" runat="server" Text="Numero OT:" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style19">
                                    &nbsp;
                                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                                </td>
                                <td class="style11">
                                    &nbsp;
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
                                <td class="style14">
                                    &nbsp;
                                </td>
                                <td class="style15">
                                    <asp:Label ID="Label5" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style19">
                                    &nbsp;
                                    <asp:Label ID="lblComponente" runat="server"></asp:Label>
                                </td>
                                <td class="style11">
                                    &nbsp;
                                    <asp:Label ID="Label7" runat="server" Text="Fecha Creacion OT:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;
                                </td>
                                <td class="style15">
                                    <asp:Label ID="Label4" runat="server" Text="Formato Cerrado:" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style19">
                                    &nbsp;
                                    <asp:Label ID="lblFormatoCerrado" runat="server"></asp:Label>
                                </td>
                                <td class="style11">
                                    &nbsp;
                                    <asp:Label ID="Label26" runat="server" Text="Fecha Produccion OT:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaProduccion" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;
                                </td>
                                <td class="style15">
                                    <asp:Label ID="Label9" runat="server" Text="Cliente:" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style4" colspan="3">
                                    &nbsp;
                                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="divTitulo">
                        Calculo de Papel</div>
                    <div class="divSeccion">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Cantidad:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Paginas:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaginas" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="N° Pág. Pliego " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPagPliego" runat="server">
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                </td>
                                <td class="style6">
                                    <asp:Label ID="Label19" runat="server" Text="Gramaje:  " Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="txtGramaje" runat="server"></asp:TextBox>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="Label27" runat="server" Text="Maquina: " Font-Bold="True"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:DropDownList ID="ddlMaquina" runat="server">
                                        <asp:ListItem>Rotativa</asp:ListItem>
                                        <asp:ListItem>Plana</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style9">
                                    <asp:Label ID="Label10" runat="server" Text="% Merma:  " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;<asp:Label ID="lblMerma" runat="server"></asp:Label>
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
                                    <asp:Label ID="Label21" runat="server" Text="Ancho Bobina:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAncho" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="Label25" runat="server" Text="Entrada Maquina: " Font-Bold="True"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblEntrada" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="Kilos: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblKilos" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="divTitulo">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    Inventario Papel Bodega
                                </td>
                                <td align="right">
                                    <a onclick="javascript:Buscar();">
                                        <img alt="" src="../../Images/buscar.png" width="20px" height="20px" />Buscar
                                    </a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="divSeccion">
                        <div style="height: 130px; width: 1120px; overflow: auto;">
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
                                        <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" SortExpression="CodigoProducto"
                                            UniqueName="CodigoProducto">
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" SortExpression="Papel"
                                            UniqueName="Papel">
                                            <ItemStyle Width="290px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" SortExpression="Gramaje"
                                            UniqueName="Gramaje">
                                            <ItemStyle HorizontalAlign="Right" Width="40px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" SortExpression="Ancho"
                                            UniqueName="Ancho">
                                            <ItemStyle HorizontalAlign="Right" Width="40px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" SortExpression="Largo"
                                            UniqueName="Largo">
                                            <ItemStyle HorizontalAlign="Right" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" SortExpression="Certificacion"
                                            UniqueName="Certificacion">
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StockFL" HeaderText="KG. Disp." SortExpression="StockFL"
                                            UniqueName="StockFL">
                                            <ItemStyle HorizontalAlign="Right" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="KG. Res." SortExpression="Antiguedad"
                                            UniqueName="Antiguedad">
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Inventario" HeaderText="KG: Tot." SortExpression="Inventario"
                                            UniqueName="Inventario">
                                            <ItemStyle Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Asignar" HeaderText="Asignar" SortExpression="Asignar"
                                            UniqueName="Asignar">
                                            <ItemStyle Width="50px" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="True">
                                </ClientSettings>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div class="divTitulo">
                        Papel Asignado</div>
                    <div class="divSeccion">
                        <div style="height: 130px; width: 1120px; overflow: auto;">
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
                                        <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" SortExpression="CodigoProducto"
                                            UniqueName="CodigoProducto">
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" SortExpression="Papel"
                                            UniqueName="Papel">
                                            <ItemStyle Width="290px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" SortExpression="Gramaje"
                                            UniqueName="Gramaje">
                                            <ItemStyle HorizontalAlign="Right" Width="40px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" SortExpression="Ancho"
                                            UniqueName="Ancho">
                                            <ItemStyle HorizontalAlign="Right" Width="40px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" SortExpression="Largo"
                                            UniqueName="Largo">
                                            <ItemStyle HorizontalAlign="Right" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" SortExpression="Certificacion"
                                            UniqueName="Certificacion">
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StockFL" HeaderText="KG. Asignados" SortExpression="StockFL"
                                            UniqueName="StockFL">
                                            <ItemStyle HorizontalAlign="Right" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" SortExpression="Asignar"
                                            UniqueName="Asignar">
                                            <ItemStyle Width="50px" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="True">
                                </ClientSettings>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div align="right">
                        <table id="Table1" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC;
                            margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width: 450px;">
                            <tr runat="server" style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif;
                                color: #003e7e; text-align: left;">
                                <td runat="server" class="style21" style="font-weight: bold; padding: 4px 0 0 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    &nbsp;
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    Pliegos
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    Kilos
                                </td>
                            </tr>
                            <tr runat="server" style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                color: #333; vertical-align: text-top;">
                                <td runat="server" class="style21" style="font-weight: normal; padding: 4px 0 5px 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    <asp:Label ID="Label6" runat="server">Papel Solicitado:</asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    <asp:Label ID="lblSolicitadoFL" runat="server"></asp:Label>
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    <asp:Label ID="lblSolicitadoKG" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                color: #333; vertical-align: text-top;">
                                <td runat="server" class="style21" style="font-weight: normal; padding: 4px 0 5px 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    <asp:Label ID="Label11" runat="server">Papel Asignado:</asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    <asp:Label ID="lblAsignadoFL" runat="server"></asp:Label>
                                </td>
                                <td runat="server" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                    text-align: center;">
                                    <asp:Label ID="lblAsignadoKG" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" style="background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                color: #333; vertical-align: text-top;">
                                <td runat="server" class="style22" style="font-weight: normal; padding: 4px 0 5px 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    <asp:Label ID="Label12" runat="server">Saldo Por Asignar:</asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                <td runat="server" class="style23" style="font-weight: normal; padding: 4px 0 5px 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    <asp:Label ID="lblSaldoFL" runat="server"></asp:Label>
                                </td>
                                <td runat="server" class="style23" style="font-weight: normal; padding: 4px 0 5px 5px;
                                    border-right: 1px solid #ccc; text-align: center;">
                                    <asp:Label ID="lblSaldoKG" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div align="center">
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Style="height: 26px" 
                        onclick="btnGrabar_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFiltro" runat="server" Text="Cancelar" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Codigo Bobina" ID="TabPanel1">
            <HeaderTemplate>
                Inventario Metrics
            </HeaderTemplate>
            <ContentTemplate>
                <table style="background-color: #EEE; border: 1px solid #999; margin-left: 12%; border-radius: 10px 10px 10px 10px;
                    width: 825px;" align="center">
                    <tr>
                        <td class="style4">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Marca:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label15" runat="server" Text="Descripción:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
                        </td>
                        <td class="style4">
                            &nbsp;
                        </td>
                        <td class="style6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label16" runat="server" Text="Gramaje:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td class="style4">
                            &nbsp;
                            <asp:Label ID="Label17" runat="server" Text="Ancho:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>
                        <td class="style4">
                            &nbsp;
                        </td>
                        <td class="style6">
                            <asp:Button ID="Button1" runat="server" Text="Filtrar" Width="73px"/>
                        </td>
                    </tr>
                </table>
                <br />
                            <div class="divTitulo">
    Inventario Papel</div>
    <div class="divSeccion">
     <div style="height:250px;width:1115px; overflow:auto;" >
        <telerik:radgrid ID="RadGrid3" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="CodigoProducto" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="100px" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="250px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="StockFL" ItemStyle-Width="30px" SortExpression="StockFL" ItemStyle-HorizontalAlign="Right" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="60px" SortExpression="Antiguedad" UniqueName="Antiguedad">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Seleccionar" HeaderText="Seleccionar" ItemStyle-Width="50px" SortExpression="Seleccionar" UniqueName="Seleccionar">
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
     </div>
    </div>
                <br />
                    <div class="divTitulo">
    Papel a Solicitar</div>
    <div class="divSeccion">

    <telerik:radgrid ID="RadGrid4" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>                 

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="CodigoProducto" ItemStyle-Width="40px"  SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="190px" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="190px" SortExpression="Descripcion" UniqueName="Descripcion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="190px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="30px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CantRequerida" HeaderText="CantRequerida" ItemStyle-Width="30px" SortExpression="CantRequerida" UniqueName="CantRequerida">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CantSolicitada" HeaderText="CantSolicitada" ItemStyle-Width="30px" SortExpression="CantSolicitada" UniqueName="CantSolicitada">
                    </telerik:GridBoundColumn>

                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
    </div>
   
    <div align="right">
        <table style="width: 500px;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div align="center">Pliegos</div></td>
                <td>
                    <div align="center">Pliegos</div>
                </td>
            </tr>
            <tr>
                <td>
                   <div align="center">Papel Solicitado</div>
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
                   <div align="center">Papel Asignado</div>
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
                    <div align="center">Saldo por Asignar</div></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div align="center">
        <asp:Button ID="Button2" runat="server" Text="Grabar"  />&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
        <asp:Button ID="Button3" runat="server" Text="Volver" /></div>
    
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </form>
</body>
</html>
