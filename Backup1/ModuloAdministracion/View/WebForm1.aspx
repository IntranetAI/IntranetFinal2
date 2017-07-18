<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.WebForm1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;visibility:hidden;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <%--<td>
                <asp:Label ID="Label4" runat="server" Text="Pliegos: "></asp:Label>
            </td>
            <td>
                
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Bodegas: "></asp:Label>
            </td>
            <td>
                
            </td>--%>

        <%--</tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td></td>--%>
            <td>
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" />
           </div>
            </td>
        </tr>
    </table>
<div style="border:1px solid blue; max-height:450px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridRF" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="CodItem">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Lote" HeaderText="Lote" 
                                ReadOnly="True" SortExpression="Lote" UniqueName="Lote">
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="CodItem" HeaderText="Cod Item" 
                                SortExpression="CodItem" UniqueName="CodItem">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Nombre Papel" 
                                UniqueName="NombrePapel">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gr." 
                                SortExpression="Gramage" UniqueName="Gramage" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" 
                                SortExpression="Ancho" UniqueName="Ancho" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" 
                                SortExpression="Largo" UniqueName="Largo" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Cons_Pliego" HeaderText="Cons. Pliego" 
                                ReadOnly="True" SortExpression="Cons_Pliego" UniqueName="Cons_Pliego"  ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Cons_Bobina"   HeaderText="Cons. Bobina" UniqueName="Cons_Bobina"  ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Certif" HeaderText="Certificación" 
                                SortExpression="Certif" UniqueName="Certif">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CostUni" HeaderText="Costo Unitario"
                                SortExpression="CostUni" UniqueName="CostUni" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Costtot" HeaderText="Costo Total"
                                SortExpression="Costtot" UniqueName="Costtot" ItemStyle-HorizontalAlign="Right">
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
                <div align="center">
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" 
                        onclick="btnExportar_Click" /> </div>
</asp:Content>
