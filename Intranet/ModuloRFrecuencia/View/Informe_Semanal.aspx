<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Semanal.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Semanal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div runat="server" id="divbotones" style="text-align:right; width: 940px; margin-top:-20px; margin-left:-10px;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
   <%--&nbsp;&nbsp;&nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="True" />
                   </a>--%>
               &nbsp;&nbsp;&nbsp;
               <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>
       </div>
       <asp:Panel ID="Panel2" runat="server" Visible="true" >
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;margin-bottom:5px;border-radius:10px 10px 10px 10px;" align="center" width="945px;">
               
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio : " 
                    Width="110px"></asp:Label>
            </td>
            <td style="width:134;">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino : " Width="110px"></asp:Label>
            </td>
            <td style="width:134;">
               
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="128px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="txtFechaTermino" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td style="width:500px;" colspan ="2">
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
            </td>
            
            <td>
            <div style="margin-top:-20px;margin-left:40px;text-align:right;">  
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                    style="width: 16px"  /></div>
            </td>
        </tr>
    </table>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat ="server" Height="600px" Width="935px" Direction="NotSet" ClientIDMode="Inherit">
        <div style="overflow-y:scroll;height:550px;margin-left:-10px;">
        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" Width="928px"
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Trabajo !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                        <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                                ReadOnly="True" SortExpression="Maquina"  UniqueName="Maquina">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="OT" HeaderText="Codigo Bobina" 
                                ReadOnly="True" SortExpression="Codigo_Bobina"  UniqueName="Codigo_Bobina">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Tipo_Papel" SortExpression="Tipo_Papel" 
                                UniqueName="Tipo_Papel">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="Total_B" HeaderText="Gramaje" 
                            UniqueName="Gramaje">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BBuenas" HeaderText="Peso Bobina" 
                            UniqueName="PesoBobina">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BMalas_QG" HeaderText="Estado Bobina" 
                            UniqueName="Estado Bobina">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Pesos_Tapas" HeaderText="Kilos Escarpe" 
                            UniqueName="KilosEscarpe">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                           <%--     <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Original" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="P. Tapa" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="P. Cono" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="P. Escarpe" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="P. Envoltura" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            --%>
                            <telerik:GridBoundColumn DataField="Pesos_Conos" HeaderText="% Perdida" 
                            UniqueName="Porc_Perdida">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              </div>
        </asp:Panel>
        <script type="text/javascript">
            $('#accordion ul:eq(8)').show();
 </script>
</asp:Content>
