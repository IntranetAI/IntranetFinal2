<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Mensajeria.aspx.cs" Inherits="Intranet.View.Mensajeria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
   
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%--inicio filtro--%>
        <asp:Panel ID="Panel2" runat="server" Visible="False" style="padding-left:-10px; margin-top:15px;margin-bottom:-25px;margin-left:-5px;">
    <table align="center" width="895px" style="background-color:#EEE;border:1px solid #999">
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
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />
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

                <asp:CalendarExtender ID="CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style23">
                &nbsp;</td>
            <td class="style19">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
            </td>
        </tr>
    </table>
    <br />
        </asp:Panel>
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
               &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/Images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
       </div>

                   <%-- <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="550px" Width="890px">
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OTs Nuevas</HeaderTemplate>
            <ContentTemplate>--%>
            <div style="height:540px;width:895px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Mensaje" HeaderText="<a><img src='../Images/mensajeria.png' /</a>>" ItemStyle-Width="100px" UniqueName="Comuna" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NumeroFolio" UniqueName="NumeroFolio" ItemStyle-Width="300px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" SortExpression="Destinatario" UniqueName="Destinatario" ItemStyle-Width="400px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaDes" HeaderText="Fecha Despacho" SortExpression="FechaImpresion" UniqueName="FechaImpresion" ItemStyle-Width="150px"  DataFormatString="{0:dd/MM/yyyy HH:mm}" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Cant" HeaderText="Tiraje" UniqueName="Sucursal" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" >
                </telerik:GridBoundColumn>
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              
              </div>
           
                
                
                
                </td>
            <td>
               </td>
        </tr>
    </table>
  <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <%--fin container--%>
        <script type="text/javascript">
            $('#accordion ul:eq(7)').show();
 </script>
        
</asp:Content>
