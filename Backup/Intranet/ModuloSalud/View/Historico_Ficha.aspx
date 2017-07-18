<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Historico_Ficha.aspx.cs" Inherits="Intranet.ModuloSalud.View.Historico_Ficha" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function AgregarFicha(Rut) {
            var w = 1010;
            var h = 850;
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;

            onload(window.open('Ficha_Clinica.aspx?rut=' + Rut, 'Ficha Medica', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=' + w + ',height=' + h + ',left=' + left + ',top=' + top));
        }

        function AgregarConsulta(Rut) {
            var w = 1010;
            var h = 850;
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;

            onload(window.open('Consulta_Medica.aspx?rut=' + Rut, 'Ficha Medica', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=' + w + ',height=' + h + ',left=' + left + ',top=' + top));
        }
        function FiltroActivo() {
            document.getElementById("tablaFiltro").style.display = "block";

        }

        function openPopup(Rut, Procedimiento){
            var w = 1010;
            var h = 850;
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;

            onload(window.open('Ficha_Clinica.aspx?rut=' + Rut+'&pro='+Procedimiento, 'Ficha Medica', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=' + w + ',height=' + h + ',left=' + left + ',top=' + top));
        }
        function openConsulta(Rut, nroConsulta) {
            var w = 1010;
            var h = 850;
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;

            onload(window.open('Consulta_Medica.aspx?rut=' + Rut + '&nro=' + nroConsulta, 'Ficha Medica', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=' + w + ',height=' + h + ',left=' + left + ',top=' + top));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 950px; margin-top: -5px;
        margin-left: -10px;">
        <a title="Buscar OTs por Filtro" onclick="javascript:FiltroActivo();">
            <img alt="" src="../../Images/buscar.png" width="20" height="20px" />
        </a>&nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" />
        </a>
    </div>
    <table id="tablaFiltro" style="background-color: #EEE; border: 1px solid #999; padding: 5px;
        border-radius: 10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>
                C.I.
            </td>
            <td>
                <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
            </td>
            <td>
                Apellido
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" Style="height: 26px"
                    OnClick="btnFiltro_Click" />
            </td>
        </tr>
    </table>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="550px"
        Width="1100px">
        <asp:TabPanel runat="server" HeaderText="Distribucción" ID="TabPanel1">
            <HeaderTemplate>
                Ficha Medica</HeaderTemplate>
            <ContentTemplate>
                <div runat="server" id="div1" style="text-align: right; width: 100%; margin-top: -5px;
                    margin-left: -10px;">
                    <a id="A2" runat="server" onclick="javascript:AgregarFicha(document.getElementById('ContentPlaceHolder1_txtCI').value)"
                        style="color: #000000; text-decoration: blink;">
                        <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" /></a></div>
                <div style="border: 1px solid blue; margin-left: -10px; min-height: 300px; max-height: 466px;
                    overflow-y: auto;">
                    <telerik:RadGrid ID="RadGridFichaMedica" BorderWidth="0px" runat="server" Skin="Outlook"
                        Width="100%" GridLines="None">
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDFichaMedica" HeaderText="N° Ficha" ReadOnly="True"
                                    SortExpression="IDFichaMedica" UniqueName="IDFichaMedica">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"
                                    UniqueName="Nombre">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Edad" HeaderText="Edad" UniqueName="Edad">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Sexo" HeaderText="Sexo" UniqueName="Sexo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fuma" HeaderText="Fuma" ReadOnly="True" SortExpression="Fuma"
                                    UniqueName="Fuma">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Bebe" HeaderText="Bebé" ReadOnly="True" SortExpression="Bebe"
                                    UniqueName="Bebe">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Drogas" HeaderText="Drogas" SortExpression="Drogas"
                                    UniqueName="Drogas">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" SortExpression="Comuna"
                                    UniqueName="Comuna">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Transporte" HeaderText="Transporte" SortExpression="Transporte"
                                    UniqueName="Transporte">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Accion" HeaderText="Acción" SortExpression="Accion"
                                    UniqueName="Accion">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView><HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"
                            EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid></div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Controles" ID="TabPanel2">
            <HeaderTemplate>
                Controles</HeaderTemplate>
            <ContentTemplate>
                <div style="border: 1px solid blue; margin-left: -10px; min-height: 300px; max-height: 466px;
                    overflow-y: auto;">
                    <telerik:RadGrid ID="RadGridControles" BorderWidth="0px" runat="server" Skin="Outlook"
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
                                <telerik:GridBoundColumn DataField="IDFichaMedica" HeaderText="N° Ficha" ReadOnly="True" SortExpression="IDFichaMedica"
                                    UniqueName="IDFichaMedica">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"
                                    UniqueName="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fuma" HeaderText="Fecha Control" SortExpression="Fuma"
                                    UniqueName="Fuma">
                                    <ItemStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Diagnostico Comun" UniqueName="Comuna">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Transporte" HeaderText="Diagnostico Tratamiento" UniqueName="Transporte">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView><ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid></div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Consulta" ID="TabPanel3">
            <HeaderTemplate>
                Consulta</HeaderTemplate>
            <ContentTemplate>
                <div runat="server" id="div3" style="text-align: right; width: 100%; margin-top: -5px;
                    margin-left: -10px;">
                    <a id="A1" runat="server" onclick="javascript:AgregarConsulta(document.getElementById('ContentPlaceHolder1_txtCI').value)"
                        style="color: #000000; text-decoration: blink;">
                        <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" /></a></div>
                <div style="border: 1px solid blue; margin-left: -10px; min-height: 300px; max-height: 466px;
                    overflow-y: auto;">
                    <telerik:RadGrid ID="RadGridConsultas" BorderWidth="0px" runat="server" Skin="Outlook" Width="100%"
                        GridLines="None">
                        <MasterTableView AutoGenerateColumns="False">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDFichaMedica" HeaderText="N° Ficha" ReadOnly="True"
                                    SortExpression="IDFichaMedica" UniqueName="IDFichaMedica">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Talla" HeaderText="Nombre" SortExpression="Talla"
                                    UniqueName="Talla">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Diagnostico_Comun" HeaderText="Diagnostico_Comun" UniqueName="Diagnostico_Comun">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Diagnostico_Tratamiento" HeaderText="Diagnostico_Tratamiento" UniqueName="Diagnostico_Tratamiento">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Peso" HeaderText="Peso" ReadOnly="True" SortExpression="Peso"
                                    UniqueName="Peso">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Pulso" HeaderText="Pulso" ReadOnly="True" SortExpression="Pulso"
                                    UniqueName="Pulso">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PresionArterial" HeaderText="Presion Arterial" SortExpression="PresionArterial"
                                    UniqueName="Drogas">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UsuarioCreador" HeaderText="Atendido por" SortExpression="UsuarioCreador"
                                    UniqueName="UsuarioCreador">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaConsulta" HeaderText="Fecha Consulta" SortExpression="FechaConsulta"
                                    UniqueName="FechaConsulta">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Examen_CabezaCuello" HeaderText="Acción" SortExpression="Examen_CabezaCuello"
                                    UniqueName="Examen_CabezaCuello">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView><ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid></div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <br />
    <script type="text/javascript">
        $('#accordion ul:eq(0)').show();
    </script>
</asp:Content>
