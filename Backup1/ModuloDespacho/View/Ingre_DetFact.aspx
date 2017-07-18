<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingre_DetFact.aspx.cs"
    Inherits="Intranet.ModuloDespacho.View.Ingre_DetFact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
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
        function Editar(Fac, ID) {
            var Usuario = document.getElementById("lblUsuario").innerHTML;
            location.href = 'Ingre_DetFact.aspx?id=' + ID + '&modi=' + Fac + '&u=' + Usuario;
        }
        function Delete(Fac, ID) {
            $.ajax({
                url: "Ingre_DetFact.aspx/DeleteItem",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'ID_DetFactura':'" + Fac + "'}",
                success: function (data) {
                    if (data.d == "OK") {
                        location.href = 'Ingre_DetFact.aspx?id=' + ID + '&u=' + Usuario;
                    }
                    else {
                        alert("Error al eliminar registro. Intentelo mas tarde.");
                    }

                },
                error: function () {
                    alert('no funca');
                }
            });
        }
        function Validador(Tipo) {
            if (Tipo == "Fijo") {
                var OTFijo = document.getElementById("TabContainer1_TabPanel0_txtOTFijo").value;
                if (OTFijo == "") {
                    document.getElementById("TabContainer1_TabPanel0_txtOTFijo").style.borderColor = "rgb(255, 0, 0)";
                }
            }
        }
        function Validador(Tipo) {
            if (Tipo == "Fijo") {
                var OTFijo = document.getElementById("TabContainer1_TabPanel0_txtOTFijo").value;
                if (OTFijo == "") {
                    document.getElementById("TabContainer1_TabPanel0_txtOTFijo").style.borderColor = "rgb(255, 0, 0)";
                }

                var ddlProceso = document.getElementById("TabContainer1_TabPanel0_ddlProceso");
                var Proceso = ddlProceso.options[ddlProceso.selectedIndex].text;
                if (Proceso == "Seleccionar") {
                    document.getElementById("TabContainer1_TabPanel0_ddlProceso").style.borderColor = "rgb(255, 0, 0)";
                }

                var CantidadFijo = document.getElementById("TabContainer1_TabPanel0_txtCantidadFijo").value;
                if (CantidadFijo == "") {
                    document.getElementById("TabContainer1_TabPanel0_txtCantidadFijo").style.borderColor = "rgb(255, 0, 0)";
                }

                var PrecioUniFijo = document.getElementById("TabContainer1_TabPanel0_txtPrecioUniFijo").value;
                if (PrecioUniFijo == "") {
                    document.getElementById("TabContainer1_TabPanel0_txtPrecioUniFijo").style.borderColor = "rgb(255, 0, 0)";
                }
            }
            else if (Tipo == "Variable") {
                var OTVari = document.getElementById("TabContainer1_TabPanel1_txtOTVari").value;
                if (OTVari == "") {
                    document.getElementById("TabContainer1_TabPanel1_txtOTVari").style.borderColor = "rgb(255, 0, 0)";
                }

                var ddlExterno = document.getElementById("TabContainer1_TabPanel1_ddlExterno");
                var Externo = ddlExterno.options[ddlExterno.selectedIndex].text;
                if (Externo == "Seleccionar") {
                    document.getElementById("TabContainer1_TabPanel1_ddlExterno").style.borderColor = "rgb(255, 0, 0)";
                }

                var ddlBarniz = document.getElementById("TabContainer1_TabPanel1_ddlBarniz");
                var Barniz = ddlBarniz.options[ddlBarniz.selectedIndex].text;
                if (Barniz == "Seleccionar") {
                    document.getElementById("TabContainer1_TabPanel1_ddlBarniz").style.borderColor = "rgb(255, 0, 0)";
                }

                var ddlTipo = document.getElementById("TabContainer1_TabPanel1_ddlTipo");
                var Tipo = ddlTipo.options[ddlTipo.selectedIndex].text;
                if (Tipo == "Seleccionar") {
                    document.getElementById("TabContainer1_TabPanel1_ddlTipo").style.borderColor = "rgb(255, 0, 0)";
                }

                var CantidadVari = document.getElementById("TabContainer1_TabPanel1_txtCantidadVari").value;
                if (CantidadVari == "") {
                    document.getElementById("TabContainer1_TabPanel1_txtCantidadVari").style.borderColor = "rgb(255, 0, 0)";
                }

                var PreUnitVari = document.getElementById("TabContainer1_TabPanel1_txtPreUnitVari").value;
                if (PreUnitVari == "") {
                    document.getElementById("TabContainer1_TabPanel1_txtPreUnitVari").style.borderColor = "rgb(255, 0, 0)";
                }

                var PreUnitVari = document.getElementById("TabContainer1_TabPanel1_txtPreUnitVari").value;
                if (PreUnitVari == "") {
                    document.getElementById("TabContainer1_TabPanel1_txtPreUnitVari").style.borderColor = "rgb(255, 0, 0)";
                }

                var Ancho = document.getElementById("TabContainer1_TabPanel1_txtAncho").value;
                var Largo = document.getElementById("TabContainer1_TabPanel1_txtLargo").value;
                if (Ancho == "" || Largo == "") {
                    document.getElementById("TabContainer1_TabPanel1_txtAncho").style.borderColor = "rgb(255, 0, 0)";
                    document.getElementById("TabContainer1_TabPanel1_txtLargo").style.borderColor = "rgb(255, 0, 0)";
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ToolkitScriptManager>
    N° de Factura<asp:Label ID="lblNFactura" runat="server" Text=""></asp:Label>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="300px"
        Width="570px">
        <asp:TabPanel runat="server" HeaderText="Costo Fijo" ID="TabPanel0">
            <HeaderTemplate>
                Costo Fijo</HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            OT
                        </td>
                        <td style="width: 70px;">
                            <asp:TextBox ID="txtOTFijo" runat="server" MaxLength="7" Width="60px" AutoPostBack="True"
                                OnTextChanged="txtOTFijo_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 110px;">
                            Nombre OT
                        </td>
                        <td>
                            <asp:Label ID="lblNombreOtFijo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proceso
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlProceso" runat="server" Width="252px">
                                <asp:ListItem>Seleccionar</asp:ListItem>
                                <asp:ListItem>Salida de Pelicula</asp:ListItem>
                                <asp:ListItem>Entrada en Maquina</asp:ListItem>
                                <asp:ListItem>Molde Troquel</asp:ListItem>
                                <asp:ListItem>Molde Medio Corte</asp:ListItem>
                                <asp:ListItem>Molde Plisado</asp:ListItem>
                                <asp:ListItem>Molde Prepicado</asp:ListItem>
                                <asp:ListItem>Chillas</asp:ListItem>
                                <asp:ListItem>Grabado de Bastidor</asp:ListItem>
                                <asp:ListItem>Grabado de Mantilla</asp:ListItem>
                                <asp:ListItem>Diferencia Costo Minimo</asp:ListItem>
                                <asp:ListItem>Costo Minimo</asp:ListItem>
                                <asp:ListItem>Prueba</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cantidad
                        </td>
                        <td style="width: 70px;">
                            <asp:TextBox ID="txtCantidadFijo" runat="server" Width="60px" onkeyup="addPoints(this)"></asp:TextBox>
                        </td>
                        <td>
                            Precio Unitario
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrecioUniFijo" runat="server" Width="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Tot. Costo:</td>
                        <td><asp:TextBox ID="txtTotalFijo" runat="server" Width="60px" onkeyup="addPoints(this)"></asp:TextBox></td>
                        <td></td>
                        <td></td>

                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            Observación
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtObservacionFijo" runat="server" Height="94px" TextMode="MultiLine"
                                Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarFijo" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnModifiFijo" runat="server" Text="Modificar" Visible="False" OnClick="btnModifiFijo_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Costo Variable" ID="TabPanel1">
            <HeaderTemplate>
                Costo Variable</HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            OT
                        </td>
                        <td style="width: 70px;">
                            <asp:TextBox ID="txtOTVari" runat="server" MaxLength="7" AutoPostBack="True" OnTextChanged="txtOTVari_TextChanged"
                                Width="60px"></asp:TextBox>
                        </td>
                        <td style="width: 100px;">
                            Nombre OT
                        </td>
                        <td>
                            <asp:Label ID="lblNombreOTVari" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proceso Externo
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlExterno" runat="server" Width="400px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Caras
                        </td>
                        <td style="width: 70px;">
                            <asp:DropDownList ID="ddlBarniz" runat="server">
                                <asp:ListItem>Seleccionar</asp:ListItem>
                                <asp:ListItem>Tiro</asp:ListItem>
                                <asp:ListItem>Retiro</asp:ListItem>
                                <asp:ListItem>Tiro/Retiro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Tipo
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipo" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cantidad PL.
                        </td>
                        <td style="width: 70px;">
                            <asp:TextBox ID="txtCantidadVari" runat="server" Width="60px" onkeyup="addPoints(this)"></asp:TextBox>
                        </td>
                        <td>
                            Valor PL.
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreUnitVari" runat="server" Width="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Cantidad M2</td>
                        <td><asp:TextBox ID="txtCantidadM2" runat="server" Width="60px" onkeyup="addPoints(this)"></asp:TextBox></td>
                        <td>
                            Valor M2
                        </td>
                        <td>
                            <asp:TextBox ID="txtM2" runat="server" Width="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Formato (A x L)
                        </td>
                        <td style="width: 70px;">
                            <asp:TextBox ID="txtAncho" runat="server" Width="33px" MaxLength="5"></asp:TextBox>x<asp:TextBox
                                ID="txtLargo" runat="server" Width="33px" MaxLength="5"></asp:TextBox>
                        </td>
                        <td>Tot. Costo</td>
                        <td>
                            <asp:TextBox ID="txtTotalVari" runat="server" Width="60px" onkeyup="addPoints(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            Observación
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtObservVari" runat="server" Height="94px" TextMode="MultiLine"
                                Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 70px;">
                            <asp:Button ID="btnagregarvari" runat="server" Text="Agregar" OnClick="btnagregarvari_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnModificarvari" runat="server" Text="Modificar" Visible="False"
                                OnClick="btnModificarvari_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <div style="max-height: 130px; overflow-y: scroll;">
        <telerik:RadGrid ID="RgTemporal" runat="server" Skin="Outlook">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NFactura">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado OTs Nuevas !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT" ItemStyle-Width="50px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" UniqueName="Cantidad"
                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="150px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PrecioUnit" HeaderText="Precio Unitario" ItemStyle-Width="80px"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total" Visible="false" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Action" HeaderText="Editar/Eliminar">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />&nbsp;
        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    </div>
    <asp:Label ID="lblUsuario" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
