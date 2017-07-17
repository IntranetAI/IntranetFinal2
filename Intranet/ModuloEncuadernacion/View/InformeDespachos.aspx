<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeDespachos.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InformeDespachos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center"> 
<h3 style="color: rgb(23, 130, 239);">Informe Despachos</h3>

</div>--%>
<div runat="server" id="divbotones" style="text-align:right;width:940px;margin-top:-15px;" >
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
              onclick="ibExcel_Click"  />
                   </a>

                      &nbsp; <a title="Atrás" href="javascript:history.go(-1)"> 
                   <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Images/Atras-icon.png" Height="20px" Width="20px" />
</a> 
</div>
<table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;border-radius:10px 10px 10px 10px;margin-bottom:5px;" align="center" width="945px">
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtOP" runat="server"></asp:TextBox>
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre OT: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreOP" runat="server"></asp:TextBox>

            </td>
            <td class="style14">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="MM-dd-yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style13">
                &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="MM-dd-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14">
            <div style="margin-left:17px;">
           </div>
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label5" runat="server" Text="Estado:"></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:DropDownList ID="ddlEstado" runat="server" Width="155px">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>Liquidadas</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style16">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />

                <asp:Label ID="lblOTDetalle" runat="server" Visible="False"></asp:Label>

            </td>
            <td class="style14">
                &nbsp;</td>
        </tr>
    </table>
    
      
      <div runat="server" id="DivAgrupado" style="border:1px solid blue;height:540px;width:945px; margin-left:-10px; overflow:scroll;" >
                <telerik:RadGrid ID="RadGrid1" BorderWidth="0px" runat="server"  Skin="Outlook" 
                     OnItemCommand="contactsGrid_ItemCommand"
                                   ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                                <ItemStyle Width="200px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Tiraje"   HeaderText="Tiraje" UniqueName="Tiraje">
                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="DespachoEnc"   HeaderText="Despacho Enc." UniqueName="DespachoEnc">
                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RecibidoQGChile" HeaderText="Recibido QGChile" 
                                UniqueName="RecibidoQGChile">
                                <ItemStyle Width="60px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" 
                                ReadOnly="True" SortExpression="Saldo" UniqueName="Saldo">
                                <ItemStyle Width="30px" HorizontalAlign="Right"
                                 />
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
<%--            segunda grilla carga el detalle--%>



      <div runat="server" id="DivDetalle" style="border:1px solid blue;height:500px;width:940px;margin-left:-10px; overflow:scroll;" >

                <telerik:RadGrid ID="RadGrid2" BorderWidth="0px" runat="server"  Skin="Outlook">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="cod_Pallet" HeaderText="Pallet" 
                                ReadOnly="True" SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                <ItemStyle Width="20px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="20px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                                <ItemStyle Width="200px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Embalaje"   HeaderText="Embalaje" UniqueName="Embalaje">
                                <ItemStyle HorizontalAlign="Left" Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Cantidad"   HeaderText="Cantidad Bultos" UniqueName="Cantidad">
                                <ItemStyle HorizontalAlign="Right" Width="15px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Ejem. por Bulto" 
                                UniqueName="Ejemplares">
                                <ItemStyle Width="40px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Total" HeaderText="Total Ejemplares" 
                                ReadOnly="True" SortExpression="Total" UniqueName="Total">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="RecepcionadoPor" HeaderText="Responsable" 
                                UniqueName="RecepcionadoPor">
                                <ItemStyle Width="80px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                           
                            <telerik:GridBoundColumn DataField="FechaRecepcion" HeaderText="Fecha/Hora" 
                                UniqueName="FechaRecepcion">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
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
