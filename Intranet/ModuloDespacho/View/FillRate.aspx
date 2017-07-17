<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="FillRate.aspx.cs" Inherits="Intranet.ModuloDespacho.View.FillRate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="../../js/jquery.min.js" type="text/javascript"></script>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--   <div align="center" style="width: 937px">
    <h3 style="color: rgb(23, 130, 239);">Informe Fill Rate</h3>
   </div>--%>
        <%--inicio filtro--%>
      <%--  <asp:Panel ID="Panel1" runat="server" Visible="False" style="padding-left:-10px; margin-top:15px;margin-bottom:-25px;margin-left:-5px;">--%>
    <table align="center" width="895px" style="background-color: #EEE;border: 1px solid #999;margin-left:18px;border-radius:10px 10px 10px 10px;margin-top:6px;">
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style13">
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <div style="text-align:right;margin-top:-30px;">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                       Visible="False"  />
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style21">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style21">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style10">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style23"></td><td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </td>
           <td></td>
        </tr>
    </table>

         <br />

        <%--inicio container--%>
                <table class="Grilla"  align="center" 
            style="margin-left:-12px;margin-top:-10px; width: 951px;">
        <tr>
            <td>
                </td>
            
            <td>
           <div runat="server" id="divbotones" style="text-align:right;" >
                <a title="Actualizar OTs Nuevas">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                      Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                </a>
                &nbsp;&nbsp;<a title="Exportar a Excel"><asp:ImageButton ID="ibExcel" runat="server" Height="20px" 
                      ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    onclick="ibExcel_Click" />
                </a>
            &nbsp;<a title="Buscar OTs por Filtro"><asp:ImageButton ID="ibMostrarFiltro" 
                    runat="server"  Height="20px" 
                      ImageUrl="~/images/buscar.png" Width="20px" 
                    onclick="ibMostrarFiltro_Click" Visible="False"/>
                </a>
                &nbsp;&nbsp;&nbsp;
                <a title="Exportar a PDF"><asp:ImageButton ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" onclick="ibPDF_Click" 
                    Visible="False" />
                </a>
                &nbsp;&nbsp;&nbsp;
                </div>
            
                           
                </td>
            <td>
               </td>
        </tr>
    </table>
    <div style="height:540px;width:930px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="N° OT"  UniqueName="OT" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT" ItemStyle-Width="220px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" ItemStyle-Width="60px" UniqueName="Tiraje"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Solitada" HeaderText="Cant. Solicitada" ItemStyle-Width="80px" UniqueName="Solitada" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CantidadGenerada" HeaderText="Cant. Despachada" ItemStyle-Width="80px" UniqueName="CantidadGenerada" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaEntregar" Visible="false" HeaderText="Fecha Entregar" SortExpression="FechaProduccion" UniqueName="FechaProduccion" ItemStyle-Width="120px" DataFormatString="{0:dd-MM-yyyy HH:mm}" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaEntregada" HeaderText="Fecha de Entrega" SortExpression="FechaEntregada" UniqueName="FechaEntregada" ItemStyle-Width="120px" DataFormatString="{0:dd-MM-yyyy HH:mm}" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PuntoEntrega" HeaderText="Punt. Entregas" SortExpression="PuntoEntrega" UniqueName="PuntoEntrega" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DespachoTotal" HeaderText="% Sobre Tiraje" ItemStyle-Width="90px" UniqueName="DespachoTotal" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PorcSolicitado" HeaderText="% Sobre Solicitud" SortExpression="PorcSolicitado" UniqueName="PorcSolicitado" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                            
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              
              </div>
        <%--fin container--%>

        <script type="text/javascript">
            $('#accordion ul:eq(7)').show();
 </script>
</asp:Content>
