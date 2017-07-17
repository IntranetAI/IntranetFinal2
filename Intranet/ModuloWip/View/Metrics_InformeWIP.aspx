<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Metrics_InformeWIP.aspx.cs" Inherits="Intranet.ModuloWip.View.Metrics_InformeWIP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/jscript" >
    function OpenPopUP(OT) {
        window.open('Metrics_HistorialPallet.aspx?idP=' + OT, 'Detalle OT', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;margin-left:80px;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" Width="128px" AutoPostBack="True" 
                    ontextchanged="txtOT_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Pliegos: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPliegos" runat="server" Wi67dth="128px" Width="128px">
                </asp:DropDownList>

            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Bodegas: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlBodegas" runat="server" Width="128px">
                </asp:DropDownList>
                &nbsp;</td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="128px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Estado Pallet: "></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" Width="128px">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                    <asp:ListItem Value="1">Disponible</asp:ListItem>
                    <asp:ListItem Value="2">En Uso</asp:ListItem>
                    <asp:ListItem Value="3">Finalizado</asp:ListItem>
                    <asp:ListItem Value="4">Necesita Recuento</asp:ListItem>
                    <asp:ListItem Value="5">No Utilizado</asp:ListItem>
                    <asp:ListItem Value="6">Cancelado</asp:ListItem>
                    <asp:ListItem Value="7">Dividido</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
            </td>
        </tr>
    </table>
    <br />
    <div style="border:1px solid blue;min-height:300px; max-height:466px;overflow-y:auto;" >
               <telerik:RadGrid ID="RadGridOT"  BorderWidth="0px" Width="1085px" runat="server"  Skin="Outlook" 
                      GridLines="None">
<%--                      <ClientSettings>
                      <Scrolling AllowScroll="True" UseStaticHeaders="true"/>
                      </ClientSettings>--%>
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Pallet">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT"      ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="60px" />
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT"      SortExpression="NombreOT" UniqueName="NombreOT">
                                 <ItemStyle Width="250px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Pliego"   HeaderText="Pliego" UniqueName="Pliegos" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicaciones"    UniqueName="Ubicacion">
                                <ItemStyle Width="170px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Posicion" HeaderText="Posiciones"        ReadOnly="True" SortExpression="Posicion" UniqueName="Posicion" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="60px"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Pallet" HeaderText="Pallet"      ReadOnly="True" SortExpression="Pallet" UniqueName="Pallet" ItemStyle-HorizontalAlign="Center">
                                  <ItemStyle Width="50px"/>
                            </telerik:GridBoundColumn>
                                                                                    

                            
                            <telerik:GridBoundColumn DataField="CantidadPliegos" HeaderText="Cant. Pliegos"         ReadOnly="True" SortExpression="CantidadPliegos" UniqueName="CantidadPliegos" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CantidadKG" HeaderText="Cant. KG"   ReadOnly="True" SortExpression="CantidadKG" UniqueName="CantidadKG" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Pallets" HeaderText="Pallets" ReadOnly="True" SortExpression="Pallets" UniqueName="Pallets" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ReadOnly="True" SortExpression="Estado" UniqueName="Estado">
                                <ItemStyle Width="70px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha" ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion" >
                                <ItemStyle Width="120px" />
                            </telerik:GridBoundColumn>
                            <%--
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Usuario" 
                                ReadOnly="True" SortExpression="Usuario" UniqueName="Usuario">
                            </telerik:GridBoundColumn>--%>
                           <telerik:GridBoundColumn DataField="Detalle" HeaderText="Detalle" 
                                ReadOnly="True" SortExpression="Detalle" UniqueName="Detalle">
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

                </div>
</asp:Content>
