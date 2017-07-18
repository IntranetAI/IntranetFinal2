<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Inventario_Wip.aspx.cs" Inherits="Intranet.ModuloWip.View.Inventario_Wip" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="450px">
        <tr>
            <td style="width:100px;">Fecha Termino</td>
            <td style="width:100px;">
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="80px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td></td>
            <td>
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
           </div>
            </td>
        </tr>
    </table>
    <div align="right" style="width:98%;">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/Excel-icon.png" Width="23px" onclick="ImageButton1_Click"  />
    </div>
    <div style="border:1px solid blue; max-height:400px;overflow-y:scroll;width:98%;" >
                <telerik:RadGrid ID="RadGridInforme" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="ID_Control" HeaderText="Cod. Pallet" ItemStyle-Width="100px" >
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="OT" HeaderText="N° OT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" >
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Cant. Pliegos" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Posicion" HeaderText="Posicion">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion">
                            </telerik:GridBoundColumn>
                                                        
                            
                            
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
</asp:Content>
