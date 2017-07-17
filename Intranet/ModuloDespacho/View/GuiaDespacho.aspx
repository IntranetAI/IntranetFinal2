<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="GuiaDespacho.aspx.cs" Inherits="Intranet.ModuloDespacho.View.GuiaDespacho" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script language="javascript" src="https://maps.googleapis.com/maps/api/js?v=3"></script>
    <script type="text/javascript">
        function initMap() {
            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer;
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 6,
                center: { lat: 41.85, lng: -87.65 }
            });
            directionsDisplay.setMap(map);

            document.getElementById('submit').addEventListener('click', function () {
                calculateAndDisplayRoute(directionsService, directionsDisplay);
            });
        }

        function calculateAndDisplayRoute(directionsService, directionsDisplay) {
            var waypts = [];
            var checkboxArray = document.getElementById('waypoints');
            for (var i = 0; i < checkboxArray.length; i++) {
                if (checkboxArray.options[i].selected) {
                    waypts.push({
                        location: checkboxArray[i].value,
                        stopover: true
                    });
                }
            }

            directionsService.route({
                origin: document.getElementById('start').value,
                destination: document.getElementById('end').value,
                waypoints: waypts,
                optimizeWaypoints: true,
                travelMode: google.maps.TravelMode.DRIVING
            }, function (response, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    var route = response.routes[0];
                    var summaryPanel = document.getElementById('directions-panel');
                    summaryPanel.innerHTML = '';
                    // For each route, display summary information.
                    for (var i = 0; i < route.legs.length; i++) {
                        var routeSegment = i + 1;
                        summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
            '</b><br>';
                        summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                        summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                        summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                    }
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
    </script>
    <script type="text/javascript" language="javascript">
        function initialize() {
            var myLatlng = new google.maps.LatLng(-33.466964, -70.728726);
            var myOptions = {
                zoom: 25,
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map($("#map_canvas").get(0), myOptions);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: "Hola Mundo"
            });
        }

        function SelectAllCheckboxes(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                Tipo Guia
            </td>
            <td>
                <asp:DropDownList ID="ddlTipoGuia" runat="server">
                    <asp:ListItem>Selecionar...</asp:ListItem>
                    <asp:ListItem>Cliente</asp:ListItem>
                    <asp:ListItem>Proveedor</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                OT :
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Cliente
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Button" OnClick="btnFiltro_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <%--  <tr>
            <td colspan="3">
                <div style="border:1px solid blue;min-height:100px; max-height:150px;overflow-y:auto;" >
                
                </div>
            </td>
        </tr>--%>
    </table>
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="550px"
        Width="1050px">
        <asp:TabPanel runat="server" HeaderText="Distribucción" ID="TabPanel1" Enabled="false">
            <HeaderTemplate>
                Distribucción
            </HeaderTemplate>
            <ContentTemplate>
                <div style="height: 538px; width: 1035px; overflow: auto;">
                    <telerik:RadGrid ID="RadGridDist" BorderWidth="0px" runat="server" Skin="Outlook"
                        GridLines="None">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Rut">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="Rut" HeaderText="Rut" UniqueName="Rut">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="oT" Visible="False" UniqueName="OT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Sucursal" UniqueName="Sucursal">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" UniqueName="Comuna">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Embalaje" HeaderText="Embalaje" UniqueName="Embalaje">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cant_porbult" HeaderText="Cant_porbult" UniqueName="Cant_porbult">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <div align="center">
                        <asp:Button ID="btnCrearDistribuccion" runat="server" Text="Agregar Distribuccion"
                            OnClick="btnCrearDistribuccion_Click" /></div>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle Despacho">
            <HeaderTemplate>
                Detalle Despacho
            </HeaderTemplate>
            <ContentTemplate>
                <div style="height: 548px; overflow: auto;">
                    <telerik:RadGrid ID="RadGridDetalleD" BorderWidth="0px" runat="server" Skin="Outlook"
                        Width="100%">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_ProductosTerminados">
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
                                <telerik:GridBoundColumn DataField="cod_Pallet" HeaderText="Pallet" ReadOnly="True"
                                    SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                    UniqueName="OT">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                                    UniqueName="NombreOT">
                                    <ItemStyle Width="200px" />
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
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Direccion">
            <HeaderTemplate>
                Guias Con Patente</HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Direccion
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Comuna
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ciudad
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Region
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pais
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnDireccion" runat="server" Text="Siguinte" OnClick="btnDireccion_Click" />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Transporte">
            <HeaderTemplate>
                Guias Con Patente</HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Tipo Vehiculo
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Camion</asp:ListItem>
                                <asp:ListItem>Auto</asp:ListItem>
                                <asp:ListItem>ETC</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Patente
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button3" runat="server" Text="Guardar" />
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <%--<div id="map_canvas" style="width: 640px; height: 400px;">
    </div>--%>
    <div id="map">
    </div>
    <div id="right-panel">
        <div>
            <b>Start:</b>
            <select id="start">
                <option value="Halifax, NS">Halifax, NS</option>
                <option value="Boston, MA">Boston, MA</option>
                <option value="New York, NY">New York, NY</option>
                <option value="Miami, FL">Miami, FL</option>
            </select>
            <br>
            <b>Waypoints:</b>
            <br>
            <i>(Ctrl-Click for multiple selection)</i>
            <br>
            <select multiple id="waypoints">
                <option value="montreal, quebec">Montreal, QBC</option>
                <option value="toronto, ont">Toronto, ONT</option>
                <option value="chicago, il">Chicago</option>
                <option value="winnipeg, mb">Winnipeg</option>
                <option value="fargo, nd">Fargo</option>
                <option value="calgary, ab">Calgary</option>
                <option value="spokane, wa">Spokane</option>
            </select>
            <br>
            <b>End:</b>
            <select id="end">
                <option value="Vancouver, BC">Vancouver, BC</option>
                <option value="Seattle, WA">Seattle, WA</option>
                <option value="San Francisco, CA">San Francisco, CA</option>
                <option value="Los Angeles, CA">Los Angeles, CA</option>
            </select>
            <br>
            <input type="submit" id="submit">
        </div>
        <div id="directions-panel">
        </div>
    </div>
</asp:Content>
