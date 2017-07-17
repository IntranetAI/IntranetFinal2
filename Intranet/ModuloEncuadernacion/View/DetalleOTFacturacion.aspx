<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOTFacturacion.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.DetalleOTFacturacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    </head>
<body>
    <form id="form1" runat="server">
    <div align="center"><asp:Label ID="lblOT" runat="server" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="lblTirajeyDespachado" runat="server" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="lblPliegos" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <br />
<asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
        Height="600px" Width="1005px"> 
 <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Fecha de Entrega">
                            <HeaderTemplate>
                              Valorizacion Enc.
                            </HeaderTemplate>
                            <ContentTemplate>
                   
                                <div style="height:590px;width:990px; overflow:auto;">
                                   <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False"   CellPadding="4" ForeColor="#333333">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

                    <Columns>
                      <asp:BoundField DataField="OT" HeaderText="OT" SortExpression="OT"  />
                       <asp:BoundField DataField="Proceso" HeaderText="Proceso" SortExpression="Proceso"  />
                        <asp:BoundField DataField="Maquina" HeaderText="Maquina" SortExpression="Maquina"   ReadOnly="True" />
                         <asp:BoundField DataField="Cantidad" HeaderText="Producido" SortExpression="Cantidad"   ItemStyle-HorizontalAlign="Right" />
                         


                      <asp:TemplateField HeaderText="Cant. Despachada" SortExpression="CantidadDesp" >

                             <ItemTemplate>
                                <asp:Label ID="lblCantidad" runat="server" Visible="false" Text='<%# Bind("CantidadDespOriginal") %>'></asp:Label>
                                <asp:TextBox ID="txtCantidad" Width="100px" runat="server"  Text='<%# Bind("CantidadDesp") %>'></asp:TextBox>
                            </ItemTemplate>

                             

                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Ejemplar" SortExpression="Ejemplar">

                             <ItemTemplate>
                                <asp:Label ID="lblEjemplar" runat="server" Visible="false"  Text='<%# Bind("Ejemplar") %>'></asp:Label>
                                <asp:TextBox ID="txtEjemplar" Width="50px" runat="server"  Text='<%# Bind("Ejemplar") %>'></asp:TextBox>
                            </ItemTemplate>

                             <ItemStyle VerticalAlign="Middle" />

                        </asp:TemplateField>


                     <asp:BoundField DataField="ValorUnitario" HeaderText="PrecioUnitario" SortExpression="ValorUnitario"   ItemStyle-HorizontalAlign="Right" />

                      <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"  ItemStyle-HorizontalAlign="Right"/>

                    </Columns>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White"/>

                </asp:GridView>
                                    <div align="right">
                                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Datos" 
                                            onclick="btnActualizar_Click" />
                                    <table style="width:30%;">
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="Label1" runat="server" Text="Total:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    </div>

                                </div>
                                <br />
                                <asp:Button ID="btnPrefactura" runat="server" Text="Generar PreFactura" 
                                    onclick="btnPrefactura_Click" />
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Fecha de Entrega">
                            <HeaderTemplate>
                              Despachos Encuadernacion
                            </HeaderTemplate>
                            <ContentTemplate>
                   
                                <div style="height:590px; overflow:auto;">
                                    <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="cod_pallet">
                                            <NoRecordsTemplate>
                                                <div style="text-align:center;">
                                                    <br />
                                                    ¡ No se han encontrado registros !<br /></div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" ItemStyle-Width="30px" SortExpression="OT"  UniqueName="OT">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="cod_pallet" HeaderText="Cod Pallet" ItemStyle-Width="30px" SortExpression="cod_pallet"  UniqueName="cod_pallet">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" ItemStyle-Width="30px" SortExpression="Terminacion"  UniqueName="Terminacion">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" ItemStyle-Width="30px" SortExpression="TipoEmbalaje"  UniqueName="TipoEmbalaje">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Bultos" ItemStyle-Width="30px" SortExpression="Cantidad"  UniqueName="Cantidad">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Ejemplares x Bultos" ItemStyle-Width="30px" SortExpression="Ejemplares"  UniqueName="Ejemplares">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>
                                                                          
                                                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" ItemStyle-Width="30px" SortExpression="Total"  UniqueName="Total">
                                                    <ItemStyle Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="60px" SortExpression="Modelo"  UniqueName="Modelo">
                                                    <ItemStyle Width="60px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="200px" SortExpression="Observacion"  UniqueName="Observacion">
                                                    <ItemStyle Width="200px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Creacion" ItemStyle-Width="90px" SortExpression="FechaCreacion"  UniqueName="FechaCreacion">
                                                    <ItemStyle Width="90px" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                            EnableImageSprites="True">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
  
  <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Fecha de Entrega">
                            <HeaderTemplate>
                             PreFacturas Realizadas
                            </HeaderTemplate>
                            <ContentTemplate>
                   
                                <div style="height:590px; overflow:auto;">
                                    <telerik:RadGrid ID="RadGrid3" runat="server" Skin="Outlook">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="NroPreFactura">
                                            <NoRecordsTemplate>
                                                <div style="text-align:center;">
                                                    <br />
                                                    ¡ No se han encontrado registros !<br /></div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="NroPreFactura" HeaderText="Nº PreFactura" ItemStyle-Width="30px" SortExpression="NroPreFactura"  UniqueName="NroPreFactura">
                                                    <ItemStyle Width="20px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="30px" SortExpression="Proceso"  UniqueName="Proceso">
                                                    <ItemStyle Width="180px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="30px" SortExpression="Maquina"  UniqueName="Maquina">
                                                    <ItemStyle Width="70px" />
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Producido" ItemStyle-Width="30px" SortExpression="Cantidad"  UniqueName="Cantidad">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DespachadoEnc" HeaderText="DespachadoEnc" ItemStyle-Width="30px" SortExpression="DespachadoEnc"  UniqueName="DespachadoEnc">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Facturado" HeaderText="Cant.Facturada" ItemStyle-Width="30px" SortExpression="Facturado"  UniqueName="Facturado">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                                          
                                                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" ItemStyle-Width="30px" SortExpression="Total"  UniqueName="Total">
                                                    <ItemStyle Width="30px" HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Creacion" ItemStyle-Width="90px" SortExpression="FechaCreacion"  UniqueName="FechaCreacion">
                                                    <ItemStyle Width="90px" HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                            EnableImageSprites="True">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                                             



                    </asp:TabContainer>
    </form>
</body>
</html>
