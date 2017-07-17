<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Wip_BuscarPallet_OT.aspx.cs" Inherits="Intranet.ModuloWip.View.Wip_BuscarPallet_OT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script >
    function openGame(OT, NombreOT) {
        window.open('Historial_Pallet.aspx?ot=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" AutoPostBack="true" OnTextChanged="txtOT_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Pliegos: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPliegos" runat="server">
                </asp:DropDownList>

            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Bodegas: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlBodegas" runat="server">
                </asp:DropDownList>
                &nbsp;</td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="80px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="80px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Estado Pallet: "></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
            </td>
        </tr>
    </table>

<div align="right"> <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>&nbsp;&nbsp;</div>
<%--<br />--%>

    <div style="border:1px solid blue;min-height:300px; max-height:466px;overflow-y:auto;" >
               <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Control">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicaciones" 
                                UniqueName="Ubicacion">
                                <ItemStyle Width="80px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Posicion" HeaderText="Posiciones" 
                                ReadOnly="True" SortExpression="ToPosiciontal" UniqueName="Posicion" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ID_Control" HeaderText="Pallet" 
                                ReadOnly="True" SortExpression="ID_Control" UniqueName="ID_Control" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Pliego"   HeaderText="Pliego" UniqueName="Pliegos" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Cant. Pliegos" 
                                ReadOnly="True" SortExpression="Pliegos_Impresos" UniqueName="Pliegos_Impresos" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Peso_pallet" HeaderText="Peso Pallet" 
                                ReadOnly="True" SortExpression="Peso_pallet" UniqueName="Peso_pallet" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Maquina_Proceso" HeaderText="Pallets" 
                                ReadOnly="True" SortExpression="Maquina_Proceso" UniqueName="Maquina_Proceso" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado_Pallet2" HeaderText="Estado" 
                                ReadOnly="True" SortExpression="Estado_Pallet2" UniqueName="Estado_Pallet2">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Fecha_Modificacion" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy HH:mm}"
                                ReadOnly="True" SortExpression="Fecha_Modificacion" UniqueName="Fecha_Modificacion" ItemStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <%--
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Usuario" 
                                ReadOnly="True" SortExpression="Usuario" UniqueName="Usuario">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="VerMas" HeaderText="Detalle" 
                                ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                                <ItemStyle Width="50px" />
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
        <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
            <HeaderStyle BackColor="#DC5807" Font-Bold="true" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="OT" HeaderText="OT" />
                <asp:BoundField DataField="NombreOT" HeaderText="Nombre OT" />
                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" />
                <asp:BoundField DataField="Posicion" HeaderText="Posicion" />
                <asp:BoundField DataField="ID_Control" HeaderText="ID_Control" />
                <asp:BoundField DataField="Pliego" HeaderText="Pliego" />
                <asp:BoundField DataField="Pliegos_Impresos" HeaderText="Pliegos_Impresos" />
                <asp:BoundField DataField="Peso_pallet" HeaderText="Peso_pallet" />
                <asp:BoundField DataField="Maquina_Proceso" HeaderText="Maquina_Proceso" />
                <asp:BoundField DataField="Estado_Pallet2" HeaderText="Estado_Pallet2" />
                <asp:BoundField DataField="Fecha_Modificacion" 
                    HeaderText="Fecha_Modificacion" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="VerMas" HeaderText="VerMas" />
            </Columns>
        </asp:GridView>--%>
                </div>
                <asp:Label ID="lblTotal" runat="server" Text="" ></asp:Label>
    <br />
</asp:Content>
