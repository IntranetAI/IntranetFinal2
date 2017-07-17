<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformePorOT.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformePorOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
     <style type="text/css">
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
            background-color: #EEE;
        }
        .Grilla
        {
          
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
        }
         .style1
         {
             height: 34px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- 
 <div align="center">
    
   <h3 style="color: rgb(23, 130, 239); width: 935px;">Informe Por OT</h3>

 </div>--%>


        <%--inicio filtro--%>
        <%--<asp:Panel ID="Panel2" runat="server"  style="padding-left:0px;">--%>
    <table class="filtering" align="center" width="885px" style="border-radius:10px 10px 10px 10px;margin-left:20px;margin-top:6px;">
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
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: " Visible="False"></asp:Label>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px" Visible="False"></asp:TextBox>
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
            <td class="style1">
                </td>
            <td class="style1">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style1">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style1">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style1">
                </td>
            <td class="style1">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
                &nbsp;&nbsp;&nbsp;
                
           
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                    Visible="False" />
                
           
                &nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Excel" 
                    Visible="False" />
                &nbsp;
            <%-- <a href="javascript:history.go(-1)">Atrás</a>--%>
                
           
            </td>
        </tr>
    </table>
 <%--       </asp:Panel>--%>
        <%--fin filtro--%>

&nbsp;<div runat="server" id="divbotones" 
        style="text-align:right;margin-bottom:1px;width:931px; margin-top:-20px;" >
                                            <a title="Imprimir Mensajes" id="imprimirmensaje" runat="server" visible="false">
                                       &nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/print-message.jpg" 
                                                Width="25px" />
                 Imprimir
                                    </a>&nbsp;&nbsp;
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
        onclick="ibExcel_Click" Visible="False" 
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

<%--                                   ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true"--%>

          <asp:Panel ID="pnlResultados" runat="server" 
        Width="880px">
         <div style="height:500px;width:930px; overflow:auto;border:1px inset blue;" >
                    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" Height="300px" 

                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="TipoMovimiento" HeaderText="Tipo Movimiento" SortExpression="TipoMovimiento" 
                                UniqueName="TipoMovimiento" ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn DataField="Folio" HeaderText="Nº Guia" ItemStyle-HorizontalAlign="Center" 
                                ReadOnly="True" SortExpression="Folio" UniqueName="Folio" ItemStyle-Width="70px">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="180px">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Sucursal" 
                            UniqueName="Cliente" ItemStyle-Width="200px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Despacho" 
                                SortExpression="FechaImpresion" UniqueName="FechaImpresion" ItemStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy HH:mm}"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje Total" 
                            UniqueName="TirajeTotal" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Des." 
                            UniqueName="Despachado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>

                                 <telerik:radgrid ID="RadGrid2" Visible="false" runat="server" BorderWidth="0px"  Skin="Outlook" Height="300px" 
                    OnItemCommand="contactsGrid_ItemCommand"
                                   ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true"
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>

                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente" ItemStyle-Width="250px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaMinima" HeaderText="Fecha Inicio" 
                                SortExpression="FechaMinima" UniqueName="FechaMinima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"></telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn DataField="FechaMaxima" HeaderText="Fecha Termino" 
                                SortExpression="FechaMaxima" UniqueName="FechaMaxima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje Total" 
                            UniqueName="TirajeTotal" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Despachado" 
                            UniqueName="Despachado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
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
