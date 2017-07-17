<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="ConsumoOT.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.ConsumoOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="N° OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
                
           </div>
            </td>
        </tr>
    </table>
    <table style="margin-top:5px;margin-bottom:5px;width:940px;">
        <tr>
            <td style="font-weight: bold;"><asp:Label ID="Label1" runat="server" Text="Nombre OT :" Visible="false"></asp:Label></td>
            <td style="width:620px;"><asp:Label ID="lblOT" runat="server" Visible="False"></asp:Label></td>
            <td style="font-weight: bold;"><asp:Label ID="Label2" runat="server" Text="Fecha Liquidación" Visible="false"></asp:Label></td>
            <td><asp:Label ID="lblFeliqui" runat="server" Text="" Visible="false"></asp:Label></td>
        </tr>
    </table>
    
    <div style="width:940px;" align="center">Consumos de Papel</div>
    <div align="right" style="width: 940px;margin-top:-20px;">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/Excel-icon.png" Width="23px" onclick="ImageButton1_Click"  />
    </div>
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
                <table style="margin-left:388px; width: 550px;text-align:center;"  border="1">
                    <tr>
                        <td></td>
                        <td>Cons. Pliego</td>
                        <td>Cons. Bobina</td>
                        <td>Costo Total</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;"><asp:Label ID="lblOperacion" runat="server" Text="Total"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblPliego" runat="server" Text="0.00"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblBobina" runat="server" Text="0.00"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <div id="RadGridPlanchaTit" runat="server" style="width:940px;" align="center">Consumos 
                    de Planchas</div>
                <div id="RadGridPlanchadiv" runat="server" style="border:1px solid blue; max-height:450px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridPlanchas" BorderWidth="0px" runat="server" Skin="Outlook" 
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

                            <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Descripción" 
                                UniqueName="NombrePapel">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Cons_Plancha" HeaderText="Cantidad" 
                                ReadOnly="True" SortExpression="Cons_Plancha" UniqueName="Cons_Plancha"  ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                           <%-- <telerik:GridBoundColumn DataField="Certif" HeaderText="Certificación" 
                                SortExpression="Certif" UniqueName="Certif">
                            </telerik:GridBoundColumn>--%>

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
                <table id="tablaPlancha" runat="server" style="margin-left:388px; width: 550px;text-align:center;"  border="1">
                    <tr>
                        <td></td>
                        <td>Cantidad de Planchas</td>
                        <td>Costo Total</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;"><asp:Label ID="Label4" runat="server" Text="Total"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblPlancha" runat="server" Text="0.00"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblTotalplc" runat="server" Text="0.00"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <div id="DivTitServExt" runat="server" style="width:940px;" align="center">Servicios Externos</div>
                <div id="DivSerExterno" runat="server" style="border:1px solid blue; max-height:450px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridSerExterno" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="CodItem">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Lote" HeaderText="Descripción Proceso" 
                                ReadOnly="True" SortExpression="Lote" UniqueName="Lote">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Cons_Plancha" HeaderText="Componente" 
                                ReadOnly="True" SortExpression="Cons_Plancha" UniqueName="Cons_Plancha">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CodItem" HeaderText="Aplicación" 
                                SortExpression="CodItem" UniqueName="CodItem">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Formato (A x L)" 
                                UniqueName="NombrePapel" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            
                            
                            <telerik:GridBoundColumn DataField="Certif" HeaderText="Cantidad" 
                                SortExpression="Certif" UniqueName="Certif" ItemStyle-HorizontalAlign="Right">
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
                <table id="TablaSerExter" runat="server" style="margin-left:388px; width: 550px;text-align:center;"  border="1">
                    <tr>
                        <td></td>
                        <td>Costo Total</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;"><asp:Label ID="Label5" runat="server" Text="Total"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblTotalSerExt" runat="server" Text="0.00"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <div id="RadGridOtrosTit" runat="server" style="width:940px;" align="center">Otros Consumos</div>
                <div id="RadGridOtrosdiv" runat="server" style="border:1px solid blue; max-height:450px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridOtros" BorderWidth="0px" runat="server" Skin="Outlook" 
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

                            <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Nombre Material" 
                                UniqueName="NombrePapel">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Cons_Otros" HeaderText="Cons. Otros" 
                                ReadOnly="True" SortExpression="Cons_Otros" UniqueName="Cons_Otros"  ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                          <%--  
                            <telerik:GridBoundColumn DataField="Certif" HeaderText="Certificación" 
                                SortExpression="Certif" UniqueName="Certif">
                            </telerik:GridBoundColumn>
--%>
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
                <table id="TableOtros" runat="server" style="margin-left:388px; width: 550px;text-align:center;"  border="1">
                    <tr>
                        <td></td>
                        <td>Cons. Otros</td>
                        <td>Costo Total</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;"><asp:Label ID="Label8" runat="server" Text="Total"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblOtros" runat="server" Text="0.00"></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblTotalOtros" runat="server" Text="0.00"></asp:Label></td>
                    </tr>
                </table>
                <div style="visibility:hidden;">Consumo Real</div>
                <div style="border:1px solid blue; max-height:450px;overflow-y:scroll;width:943px;margin-left:-8px; visibility:hidden;" >
                <telerik:RadGrid ID="RadGridReal" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None" Visible="false">
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
    <br />
</asp:Content>
