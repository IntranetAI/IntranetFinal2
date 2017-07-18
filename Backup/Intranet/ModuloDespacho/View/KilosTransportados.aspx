<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="KilosTransportados.aspx.cs" Inherits="Intranet.ModuloDespacho.View.KilosTransportados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<%--    <div align="center">
    
     <h3 style="color: rgb(23, 130, 239); width: 935px;">Informe Kilos Transportados</h3>
    </div>--%>
        <%--inicio filtro--%>
       <%-- <asp:Panel ID="Panel1" runat="server" Visible="False" style="padding-left:-10px; margin-top:15px;margin-bottom:-25px;margin-left:-5px;">--%>
    <table align="center" width="895px" style="background-color: #EEE;border: 1px solid #999;border-radius:10px 10px 10px 10px;margin-left:12px;margin-top:5px;">
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
            <td class="style23">
                &nbsp;</td>
            <td class="style19">
                <asp:Label ID="lblTransportista" runat="server" Text="Transportista: "></asp:Label>
                
            </td>
            <td>
                <asp:TextBox ID="txtTransporta" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </td>
        </tr>
    </table>
       <%-- </asp:Panel>--%>
        <%--fin filtro--%>



        <%--inicio container--%>
                <table class="Grilla"  align="center" width="900px" style="margin-left:-22px;">
        <tr>
            <td>
                </td>
            
            <td>
           <div runat="server" id="divbotones" style="text-align:right;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ibFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibFiltro_Click" 
                   Visible="False" />
               &nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="True" />
                   </a>
               &nbsp;&nbsp;&nbsp;
               <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>
       </div>
                   <%-- <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="550px" Width="890px">
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OTs Nuevas</HeaderTemplate>
            <ContentTemplate>--%>
            <div style="height:520px;width:940px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Transportista" ReadOnly="True" SortExpression="Cliente" UniqueName="Cliente" ItemStyle-Width="200px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Destinatario" HeaderText="Patente" ItemStyle-Width="80px" UniqueName="Destinatario">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Folio" HeaderText="N° Guias" SortExpression="Folio" UniqueName="Folio" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Despacho" SortExpression="FechaImpresion" UniqueName="FechaImpresion" ItemStyle-Width="120px" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OT" HeaderText="N° OT"  UniqueName="OT" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOMBREOT" HeaderText="Nombre OT" UniqueName="NOMBREOT" ItemStyle-Width="200px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Peso Unitario" ItemStyle-Width="80px" UniqueName="TirajeTotal" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Cantidad Despachada" SortExpression="Despachado" UniqueName="Despachado" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                            
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              
              </div>
           
                
                
                
                </td>
            <td>
               </td>
        </tr>
    </table>

        <%--fin container--%>

        <script type="text/javascript">
            $('#accordion ul:eq(7)').show();
 </script>
</asp:Content>
