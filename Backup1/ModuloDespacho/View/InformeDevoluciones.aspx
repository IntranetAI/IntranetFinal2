<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeDevoluciones.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformeDevoluciones" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script language="javascript">
     function openGame(OT, NombreOT) {
         window.open('DetalleDevolucionInterna.aspx?cod=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=150,top=100,width=958 ,height=790,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
     }
         </script>
          <script language="javascript">
     function openGames(OT, NombreOT) {
         window.open('DetalleDevolucion.aspx?cod=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=150,top=100,width=958 ,height=790,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;border-radius:10px 10px 10px 10px;" align="center" width="890px">
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label3" runat="server" Text="OP:"></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtOP" runat="server"></asp:TextBox>
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre OP: "></asp:Label>
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
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style13">
                &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14">
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
            </td>
        </tr>
    </table>
    <br />

    <%--inicio tabconteiner--%>
    <div runat="server" id="divbotones" 
        style="text-align:right;margin-bottom:1px;width:1090px; margin-top:-20px;" >
   <a title="Actualizar OTs Nuevas">
        </a>&nbsp;&nbsp;
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
            onclick="ibExcel_Click" />
                   </a>&nbsp;&nbsp; <a title="Atrás" href="javascript:history.go(-1)"> 
                   <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Images/Atras-icon.png" Height="20px" Width="20px" />
</a> 


       </div>

       <%--fin exportaciones--%>
              <div style="border:1px solid blue;height:478px;overflow:scroll;" >
                <telerik:RadGrid ID="RadGrid3" BorderWidth="0px" runat="server"  Skin="Outlook">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Folio">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" 
                                ReadOnly="True" SortExpression="Folio" UniqueName="Folio">
                                <ItemStyle Width="70px" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Producto" HeaderText="Nombre OT" 
                                SortExpression="Producto" UniqueName="Producto">
                                <ItemStyle Width="230px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn Visible="false" DataField="Cliente" HeaderText="Cliente" 
                                SortExpression="Cliente" UniqueName="Cliente">
                                <ItemStyle Width="190px" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="TirajeOT" HeaderText="TirajeOT" 
                                SortExpression="TirajeOT" UniqueName="TirajeOT">
                                <ItemStyle Width="40px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="CausaDevolucion"   HeaderText="CausaDevolucion" UniqueName="CausaDevolucion">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </telerik:GridBoundColumn>
            

                            <telerik:GridBoundColumn DataField="Total_Dev" HeaderText="Total_Dev" 
                                ReadOnly="True" SortExpression="Total_Dev" UniqueName="Total_Dev">
                                <ItemStyle Width="35px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="CreadaPor" HeaderText="CreadaPor" 
                                ReadOnly="True" SortExpression="CreadaPor" UniqueName="CreadaPor">
                                <ItemStyle Width="70px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" 
                                ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="id_TipoDev" HeaderText="Tipo Devolucion" 
                                ReadOnly="True" SortExpression="id_TipoDev" UniqueName="id_TipoDev">
                                <ItemStyle Width="110px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="guia" HeaderText="Estado" 
                                ReadOnly="True" SortExpression="guia" UniqueName="guia">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Observacion" HeaderText=" " 
                                ReadOnly="True" SortExpression="Observacion" UniqueName="Observacion">
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
    <br />
</asp:Content>
