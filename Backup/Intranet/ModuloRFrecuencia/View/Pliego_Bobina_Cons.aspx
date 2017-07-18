<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Pliego_Bobina_Cons.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Pliego_Bobina_Cons" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function Agregar() {
            var ot = document.getElementById("<%= txtOT.ClientID %>").value;
            var pliego = document.getElementById("<%=lblNombrePliego.ClientID %>").innerText;
            if (pliego == "") {
                pliego = "&nbsp;"
            }
            var tiraje = document.getElementById("<%= lblTirajePliego.ClientID%>").innerText;
            onload(window.open('Consumo_Bobina.aspx?ot=' + ot + '&Pliego=' + pliego, 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
        function openGame(ot,id) {
            var pliego = document.getElementById("<%=lblNombrePliego.ClientID %>").innerText;
            var tiraje = document.getElementById("<%= lblTirajePliego.ClientID%>").innerText;
            onload(window.open('Consumo_Bobina.aspx?ot=' + ot + '&Pliego=' + pliego + '&cod='+id, 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
        function Falla(id) {
            var Usuario = '<%= Session["Usuario"]%>';
            onload(window.open('Falla_Corte.aspx?id=' + id + '&User=' + Usuario, 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
        
    </script>
    <style type="text/css">
        .style2
        {
            width: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 1066px">
        <legend>Información Orden Trabajo</legend>
        <table>
            <tr>
                <td>
                    OT
                </td>
                <td>
                    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Nombre OT
                </td>
                <td colspan="2">
                    <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divDatos" runat="server" visible="false">
            <table>
                <tr>
                    <td class="style2">
                        Pliego
                    </td>
                    <td>
                        <asp:Label ID="lblNombrePliego" runat="server"></asp:Label>
                    </td>
                    <td>
                        Tiraje Pliego
                    </td>
                    <td>
                        <asp:Label ID="lblTirajePliego" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/Images/Atras-icon.png"
                            OnClick="ImageButton1_Click" Width="25px" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <div runat="server" id="divOT" visible="true">
        <fieldset style="width: 1066px">
            <legend>Información Pliegos</legend>
            <div style="width: 1070px; min-height: 300px; max-height: 320px; overflow: auto;">
                <telerik:RadGrid ID="RadGrid2" runat="server" Skin="Outlook" ClientSettings-EnablePostBackOnRowClick="true"
                    OnItemCommand="RadGrid1_ItemCommand">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OrdenP">
                        <NoRecordsTemplate>
                            <div style="text-align: center;">
                                <br />
                                ¡ No se han encontrado Pliegos !<br />
                            </div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Tarea" ReadOnly="True" SortExpression="Cliente"
                                UniqueName="Cliente">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OrdenP" HeaderText="OrdenP" UniqueName="OrdenP"
                                SortExpression="OrdenP" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Papel_Solicitud" HeaderText="Nombre Pliego" ReadOnly="True"
                                SortExpression="Papel_Solicitud" UniqueName="Papel_Solicitud">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TirajePliego" HeaderText="Tiraje" SortExpression="TirajePliego"
                                UniqueName="TirajePliego" DataType="System.Int32" DataFormatString="{0:N0}">
                                <ItemStyle Width="300px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" HeaderText="Forma" UniqueName="Status">
                                <ItemStyle Width="350px" />
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="Nombre_OT" HeaderText="Estado Pliego" ItemStyle-Width="100px">
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </fieldset>
    </div>
    <div runat="server" id="divPliego" visible="false">
        <fieldset style="width: 1066px;">
            <legend>Información Bobina</legend>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="290px"
                Width="1070px">
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Asignación Bobina">
                    <ContentTemplate>
                        <div align="right" style="width: 1050px;">
                            <a id="ida" runat="server" onclick="javascript:Agregar()" style="color: #000000;
                                text-decoration: blink;">
                                <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar Bobina
                            </a>
                        </div>
                        <div style="height: 280px; width: 1050px; overflow: auto;">
                            <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook" OnItemCommand="RadGrid4_ItemCommand">
                                <ClientSettings EnableRowHoverStyle="True" EnablePostBackOnRowClick="True">
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp">
                                    <NoRecordsTemplate>
                                        <div style="text-align: center;">
                                            <br />
                                            ¡ No se han encontrado registros !<br />
                                        </div>
                                    </NoRecordsTemplate>
                                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ID_Bobina" HeaderText="Nº OT" ReadOnly="True"
                                            SortExpression="ID_Bobina" UniqueName="ID_Bobina" Visible="False">
                                            <ItemStyle Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="Nº OT" ReadOnly="True"
                                            SortExpression="NumeroOp" UniqueName="NumeroOp">
                                            <ItemStyle Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo Bobina" SortExpression="Codigo"
                                            UniqueName="Codigo">
                                            <ItemStyle Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca de Bobina" SortExpression="Marca"
                                            UniqueName="Marca">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Tipo de Papel" SortExpression="Proveedor"
                                            UniqueName="Proveedor">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gramage" UniqueName="Gramage">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Fecha_Consumo" HeaderText="Fecha" SortExpression="FechaDes"
                                            UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Bobina" UniqueName="Peso_Original">
                                            <ItemStyle Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cono" HeaderText="Corte Banda" UniqueName="Cono">
                                            <ItemStyle Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tipo" HeaderText="Estado Bobina" UniqueName="Despachado">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Bobinas Consumidas">
                    <ContentTemplate>
                        <div style="height: 280px; width: 1050px; overflow: auto;">
                            <telerik:RadGrid ID="RadGrid5" runat="server" Skin="Outlook">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp">
                                    <NoRecordsTemplate>
                                        <div style="text-align: center;">
                                            <br />
                                            ¡ No se han encontrado registros !<br />
                                        </div>
                                    </NoRecordsTemplate>
                                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo Bobina" SortExpression="NombreOT"
                                            UniqueName="NombreOT">
                                            <ItemStyle Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Tipo de Papel" SortExpression="NombreOT"
                                            UniqueName="NombreOT">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gramage" UniqueName="Cant">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Fecha_Consumo" HeaderText="Fecha" SortExpression="FechaDes"
                                            UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Bobina" UniqueName="Peso_Original"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="Peso Tapa" UniqueName="Peso_Tapa"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="Peso Envoltorio"
                                            UniqueName="Peso_emboltorio" ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="Peso Escarpe" UniqueName="PesoEscarpe"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="Peso Cono" UniqueName="Peso_Cono"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" UniqueName="Saldo"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <%-- <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca de Bobina" 
                                                    SortExpression="NombreOT" UniqueName="NombreOT">
                                                    
                                                    <ItemStyle Width="150px" />
                                                    
                                                </telerik:GridBoundColumn>--%></Columns>
                                </MasterTableView><ClientSettings EnableRowHoverStyle="True">
                                </ClientSettings>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid></div>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </fieldset>
    </div>
</asp:Content>
