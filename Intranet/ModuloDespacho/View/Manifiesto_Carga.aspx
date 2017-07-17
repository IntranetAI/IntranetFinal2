<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Manifiesto_Carga.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Manifiesto_Carga" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        html, body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        #map
        {
            height: 100%;
            float: left;
            width: 63%;
            height: 100%;
        }
        #right-panel
        {
            float: right;
            width: 34%;
            height: 100%;
        }
        #right-panel
        {
            font-family: 'Roboto' , 'sans-serif';
            line-height: 30px;
            padding-left: 10px;
        }
        
        #right-panel select, #right-panel input
        {
            font-size: 15px;
        }
        
        #right-panel select
        {
            width: 100%;
        }
        
        #right-panel i
        {
            font-size: 12px;
        }
        
        .panel
        {
            height: 100%;
            overflow: auto;
        }
        .adp-directions
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function openPopup(OT) {
            window.open('Manifiesto_CargaDetalle.aspx?ot=' + OT, 'Detalle OT', 'left=160,top=100,width=1115 ,height=791,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: { lat: 41.85, lng: -87.65 }
            });

            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer({
                draggable: true,
                map: map,
                panel: document.getElementById('right-panel')
            });

            directionsDisplay.addListener('directions_changed', function () {
                computeTotalDistance(directionsDisplay.getDirections());
            });

            displayRoute('Gladys Marín Millie 6920,Santiago, CL', 'Gladys Marín Millie 6920,Santiago, CL', directionsService, directionsDisplay);
        }

        function displayRoute(origin, destination, service, display) {
            var waypts = [];
            var Sucursales = document.getElementById("ContentPlaceHolder1_Label1").innerHTML.split('-');
            for (var i = 0; i < Sucursales.length - 1; i++) {
                waypts.push({
                    location: Sucursales[i],
                    stopover: true
                });
            }


            service.route({
                origin: origin,
                destination: destination,
                waypoints: waypts, //[{ location: 'ROSARIO NORTE 555, Santiago, CL' }, { location: 'AV. KENNEDY 9001, Santiago, CL'}],
                travelMode: google.maps.TravelMode.DRIVING,
                avoidTolls: true
            }, function (response, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    display.setDirections(response);
                } else {
                    alert('Could not display directions due to: ' + status);
                }
            });
        }

        function computeTotalDistance(result) {
            var total = 0;
            var distancia = "";
            var myroute = result.routes[0];
            for (var i = 0; i < myroute.legs.length; i++) {
                total += myroute.legs[i].distance.value;
                distancia += myroute.legs[i].distance.value + ",";
            }
            total = total / 1000;
            document.getElementById('total').innerHTML = total + ' km' + distancia;
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyASjijPgIjASnXU7DagTSfyn2Qt1YGtIm0&amp;signed_in=true&amp;callback=initMap"
        async="" defer=""></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="btnFiltro" runat="server" Text="Asignar" Width="73px" Style="height: 26px" visible="false"
                                  />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="550px"
        Width="1050px">
        <asp:TabPanel runat="server" HeaderText="Distribucción" ID="TabPanel1">
            <HeaderTemplate>
                OT - Sucursal
            </HeaderTemplate>
            <ContentTemplate>
                <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
                    align="center" width="910px">
                    <tr>
                        <td>
                            OT
                        </td>
                        <td>
                            <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Region(Opcional)
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegion" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div align="right" style="width: 184px;">
                                <asp:Button ID="Button1" runat="server" Text="Filtrar" Width="73px" Style="height: 26px"
                                    OnClick="Button1_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="border: 1px solid blue; margin-left: -10px; min-height: 300px; max-height: 466px;
                    overflow-y: auto;">
                    <telerik:RadGrid ID="RadGridSucursales" BorderWidth="0px" runat="server" Skin="Outlook"
                        Width="100%" GridLines="None">
                        <MasterTableView AutoGenerateColumns="False">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                    <HeaderTemplate>
                                        Todas<asp:CheckBox ID="chkAll1" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" Checked="false" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                    UniqueName="OT">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                                    UniqueName="NombreOT">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" UniqueName="Cliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Direccion" UniqueName="Sucursal">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" ReadOnly="True" SortExpression="Comuna"
                                    UniqueName="Comuna">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Region" HeaderText="Region" ReadOnly="True" SortExpression="Region"
                                    UniqueName="Region">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaEntrega" HeaderText="Fecha Entrega" SortExpression="FechaEntrega"
                                    UniqueName="FechaEntrega">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
                <div align="center">
                    <asp:Button ID="btnSucursales" runat="server" Text="Guardar y Continuar" OnClick="btnSucursales_Click" /></div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Producto Terminado" ID="TabPanel2">
            <HeaderTemplate>
                Producto Terminado
            </HeaderTemplate>
            <ContentTemplate>
                <div style="border: 1px solid blue; margin-left: -10px; min-height: 300px; max-height: 466px;
                    overflow-y: auto;">
                    <telerik:RadGrid ID="RadGridProducto_Terminado" BorderWidth="0px" runat="server"
                        Skin="Outlook" Width="100%" GridLines="None">
                        <MasterTableView AutoGenerateColumns="False">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                    <HeaderTemplate>
                                        Orden
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSelect" runat="server" Width="30px"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                    UniqueName="OT">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                                    UniqueName="NombreOT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" UniqueName="Cliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaEntrega" HeaderText="Fecha Entrega" ReadOnly="True"
                                    SortExpression="FechaEntrega" UniqueName="FechaEntrega">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Destino" UniqueName="Sucursal">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" ReadOnly="True" SortExpression="Comuna"
                                    UniqueName="Comuna">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ReadOnly="True" SortExpression="Estado"
                                    UniqueName="Estado">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ReadOnly="True" SortExpression="Accion"
                                    UniqueName="Accion">
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
                <div align="center">
                    <asp:Button ID="btnCargaPallet" runat="server" Text="Guardar y Continuar" OnClick="btnCargaPallet_Click" /></div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Distribucción 1" ID="TabPanel3">
            <HeaderTemplate>
                Orden de Carga
            </HeaderTemplate>
            <ContentTemplate>
                <telerik:RadGrid ID="RadGridOrdenCarga" BorderWidth="0px" runat="server" Skin="Outlook"
                    Width="100%">
                    <MasterTableView AutoGenerateColumns="False">
                        <NoRecordsTemplate>
                            <div style="text-align: center;">
                                <br />
                                ¡ No se han encontrado registros !<br />
                            </div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Orden" HeaderText="Orden" ReadOnly="True" SortExpression="Orden"
                                UniqueName="Orden">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaValidacion" HeaderText="Fechaentrega" ReadOnly="True"
                                SortExpression="FechaValidacion" UniqueName="FechaValidacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="cod_Pallet" HeaderText="Cliente" ReadOnly="True"
                                SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="cod_Pallet" HeaderText="CantidadGuias" ReadOnly="True"
                                SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Sucursaldestino" HeaderText="Direccion Destino"
                                ReadOnly="True" SortExpression="Sucursaldestino" UniqueName="Sucursaldestino">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminacion" UniqueName="Terminacion">
                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" UniqueName="TipoEmbalaje">
                                <ItemStyle Width="60px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total"
                                UniqueName="Total">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn Visible="false" DataField="FechaCreacion" HeaderText="FechaCreacion"
                                ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ReadOnly="True"
                                SortExpression="Observacion" UniqueName="Observacion">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Validado" HeaderText="Validado" ReadOnly="True"
                                SortExpression="Validado" UniqueName="Validado">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaValidacion" HeaderText="FechaValidacion"
                                ReadOnly="True" SortExpression="FechaValidacion" UniqueName="FechaValidacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
                    align="center" width="910px">
                    <tr>
                        <td>
                            Vehiculo
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVehiculo" runat="server">
                                <asp:ListItem>Seleccionar...</asp:ListItem>
                                <asp:ListItem>Camión</asp:ListItem>
                                <asp:ListItem>Camión 3/4</asp:ListItem>
                                <asp:ListItem>Furgón</asp:ListItem>
                                <asp:ListItem>Rampla</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <div align="right" style="width: 184px;">
                                <asp:Button ID="Button2" runat="server" Text="Button" />
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <div id="map" style="display: none;">
    </div>
    <div id="right-panel">
        <%--style="display: none;">--%>
        <p>
            Distancia Total : <span id="total"></span>
        </p>
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
