<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Pliegos_Impreso.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Pliegos_Impreso" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.panel1
{margin-left:-10px;    }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div runat="server" id="divbotones" style="text-align:right; width: 945px; margin-top:-12px; margin-left:-10px;" >
   <%--<a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>--%>
              <%-- &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> --%>
   <%--&nbsp;&nbsp;&nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="True" />
                   </a>--%>
              <%-- &nbsp;&nbsp;&nbsp;
               <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>--%>
                    <br />
       </div>
       <asp:Panel ID="Panel2" runat="server" Visible="true">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;margin-bottom:5px;border-radius:10px 10px 10px 10px;" align="center" width="948px">
               
        <tr>
            <td style="width:95;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="OT : "></asp:Label>
            </td>
            <td style="width:134;">
               
                <asp:TextBox ID="txtOT" runat="server" Width="128px"></asp:TextBox>
                      
            </td>
            <td style="width:500px;" colspan ="2">
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                    onclick="btnFiltro_Click" style="height: 26px" />
           </div>
            </td>
            
            <td>
         <%--   <div style="margin-top:-20px;margin-left:40px;text-align:right;">  
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                    style="width: 16px"  /></div>--%>
            </td>
         </tr>
    </table>
        </asp:Panel>
        <asp:Panel ID="Panel1" CssClass="panel1" runat ="server" Width="945px" Direction="NotSet" ClientIDMode="Inherit" ScrollBars="Auto" HorizontalAlign="Left">
        <%--<div style="overflow:auto;height:550px;margin-left:-10px;">--%>
        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" 
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OT !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                        <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT"  UniqueName="OT">
                                <ItemStyle Width="50px" />
                                </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IdAtiv" HeaderText="IdAtiv" 
                                ReadOnly="True" SortExpression="IdAtiv"  UniqueName="IdAtiv">
                                <ItemStyle Width="50px" />
                                </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" 
                                ReadOnly="True" SortExpression="Description"  UniqueName="Description">
                                <ItemStyle Width="190px" />
                                </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                                ReadOnly="True" SortExpression="Maquina"  UniqueName="Maquina">
                                <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Operacion" HeaderText="Operacion" SortExpression="Operacion" 
                                UniqueName="Operacion">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="valocMaquina" HeaderText="Velocidad Programada" 
                            UniqueName="valocMaquina" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle Width="50px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="velocTiraje" HeaderText="Velocidad Promedio" 
                            UniqueName="velocTiraje" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle Width="50px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Horas" HeaderText="Horas Tiraje" 
                            UniqueName="Horas">
                                <ItemStyle Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Desarrollo" HeaderText="P. Buenos" 
                            UniqueName="Desarrollo">
                                <ItemStyle Width="50px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>              
                            
                            <telerik:GridBoundColumn DataField="Malas" HeaderText="P. Malos" 
                            UniqueName="Malas">
                                <ItemStyle Width="50px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
             <%-- </div>--%>
        </asp:Panel>
        <br />
   <%--     <table id="id_tabla_itinerario" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:100%;">
  
  <tbody><tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-size: X-Large;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Ida <a title="Detalle de itinerario" href="javascript:showLightbox_escalas('layer_escalas_1');">[+] info</a></td>
    <td style="font-weight: normal; font-weight: bold; padding: 4px 0 0 5px;">Salida</td>
    <td style="font-size: X-Large; font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Llegada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Vuelo</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Cabina</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Equipaje</td>
  </tr>
  
  <tr style="border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Miercoles 29 enero 2014&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>21:20</strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Santiago de Chile (SCL)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>23:25</strong> <strong></strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Antofagasta (ANF)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">LA336<br>
      <br>Operado por LanExpress   </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Económica-L
    </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;">

Máximo 2 piezas que pesen 23 kg <strong>en total</strong>.
 </td>
  </tr>
  
  <tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Vuelta <a title="Detalle de itinerario" href="javascript:showLightbox_escalas('layer_escalas_2');">[+] info</a></td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Salida</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Llegada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Vuelo</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Cabina</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Equipaje</td>
  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Martes 18 marzo 2014&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>22:10</strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Antofagasta (ANF)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>00:05</strong> <strong>(Miércoles)</strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Santiago de Chile (SCL)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">LA123<br>
      </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Económica-S
    </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;">

Máximo 2 piezas que pesen 23 kg <strong>en total</strong>.
 </td>
  </tr>
  
</tbody></table>--%>
        <script type="text/javascript">
            $('#accordion ul:eq(8)').show();
 </script>
</asp:Content>
