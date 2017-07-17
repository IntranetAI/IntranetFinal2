<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Perdida.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Perdida" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<h3 style="color: rgb(23, 130, 239);text-align:center;width:940px;margin-top:-10px;">Informe Gemba</h3>--%>

        <div runat="server" id="divbotones" style="text-align:right; width: 945px; margin-top:0px; margin-left:-10px;" >
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
       <asp:Panel ID="Panel2" runat="server" Visible="false">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;width:900px;margin-bottom:5px;" align="center">
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label></td>
            <td><asp:TextBox ID="txtNumeroOT" runat="server" Width="128px"></asp:TextBox></td>
            <td><asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label></td>
            <td><asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox></td>
            <td><asp:Label ID="Label1" runat="server" Text="Maquina:"></asp:Label></td>
            <td><asp:DropDownList ID="ddlMaquina" runat="server">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Lithoman</asp:ListItem>
                    <asp:ListItem>M600</asp:ListItem>
                    <asp:ListItem>Dimensionadora</asp:ListItem>
                    <asp:ListItem>Web 1</asp:ListItem>
                    <asp:ListItem>Web 2</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            <div style="margin-top:-15px;margin-left:40px;text-align:right;">  
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                    style="width: 16px"  /></div>
            </td>
        </tr>
        <tr>
            
            <td><asp:Label ID="Label2" runat="server" Text="Tipo Papel:"></asp:Label></td>
            <td><asp:TextBox ID="txtTipPapel" runat="server"></asp:TextBox></td>
            <td><asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label></td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td><asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label></td>
            <td><asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
            </td>
        </tr>
    </table>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat ="server" Height="470px" Width="940px" Direction="NotSet" ClientIDMode="Inherit">
        <div style="overflow-y:auto;max-height:465px;margin-left:-10px;">
        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" Width="933px"
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Trabajo !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Fecha_Consumo" HeaderText="Fecha" UniqueName="Fecha_Consumo" DataFormatString="{0:dd-MM-yyyy}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="OTs" UniqueName="NumeroOp">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="pliego" HeaderText="Descripción" UniqueName="pliego">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo de Papel" UniqueName="Tipo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Marca" HeaderText="Maquina" UniqueName="Marca">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Porc_Buenas" HeaderText="Cons. T" UniqueName="Porc_Buenas" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Porc_Malas" HeaderText="Escarpe" UniqueName="Porc_Malas" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Porc_Perdida" HeaderText="Conos" UniqueName="Porc_Perdida" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Proveedor" HeaderText="S/ Impr" UniqueName="Proveedor" ItemStyle-HorizontalAlign="Right">
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
