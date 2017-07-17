<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeDiario.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformeDiario" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--   <div align="center">
   <h3 style="color: rgb(23, 130, 239); width: 935px;">Informe Diario</h3>

   </div>--%>
        <%--inicio filtro--%>
      <%--  <asp:Panel ID="Panel2" runat="server" >--%>
    <table class="filtering" align="center" width="885px" style="margin-left:22px;border-radius:10px 10px 10px 10px;margin-top:6px;">
        <tr>
            <td class="style7">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style20">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                    TargetControlID="txtFechaInicio">
                </asp:CalendarExtender>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            </td>
            <td>
                &nbsp;</td>
            <td class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
            </td>
            <td class="style2">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style13">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <div style="text-align:right;margin-top:-40px;">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                       Visible="False"  />
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style21">
               
                &nbsp;</td>
            <td>
               
                <asp:CheckBox ID="chkDetalle" runat="server" Text="Informe Detallado" />
               
            </td>
            <td>
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style19">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click1" 
                    style="height: 26px" Text="Filtrar" Width="73px" />
                &nbsp; &nbsp;
            <%-- <a href="javascript:history.go(-1)">Atrás</a>--%>
                
           
            </td>
        </tr>
    </table>
    <br />
        <%--</asp:Panel>--%>
        <%--fin filtro--%>

<div runat="server" id="divbotones" 
        style="text-align:right;margin-bottom:1px;width:930px; margin-top:-20px;" >
   <a title="Actualizar OTs Nuevas">
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" onclick="ibExcel_Click" 
                   />
                   </a>
               &nbsp;&nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="False" 
                   />
                   </a>
                      &nbsp; <a title="Atrás" href="javascript:history.go(-1)"> 
                   <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Images/Atras-icon.png" Height="20px" Width="20px" />
</a> 


       </div>



          <asp:Panel ID="pnlResultados" runat="server" 
        Width="938px" Height="530px">
         <div style="height:505px;width:934px; overflow:auto;border:1px inset blue;" >
<telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" Height="300px" 

                     >             <%--       OnItemCommand="contactsGrid_ItemCommand"
                                   ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true"--%>
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>

                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            
<%--                            <telerik:GridBoundColumn DataField="FechaMinima" HeaderText="Primer Despacho" 
                                SortExpression="FechaMinima" UniqueName="FechaMinima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"></telerik:GridBoundColumn>
--%>
                                  <telerik:GridBoundColumn DataField="FechaMaxima" HeaderText="Fecha Despacho" 
                                SortExpression="FechaMaxima" UniqueName="FechaMaxima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje Total" 
                            UniqueName="TirajeTotal" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Despachado" 
                            UniqueName="Despachado" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>

              </div>
              <br />
         </asp:Panel>
<script type="text/javascript">
    $('#accordion ul:eq(7)').show();
 </script>
</asp:Content>
