<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_EstadoOT.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Informe_EstadoOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;margin-bottom:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Cliente: "></asp:Label>
            </td>
            
            <td>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
               <div style="text-align:right;margin-top:-10px;">
                <%--<asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />--%>
                    </div>
            </td>
        </tr>
        <tr>
               <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
                <asp:Label ID="lblTransportista" runat="server" Text="Estado: "></asp:Label>
                
            </td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" Height="18px" Width="161px">
                    <asp:ListItem Value="A">En Proceso</asp:ListItem>
                    <asp:ListItem Value="E">Liquidada</asp:ListItem>
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </td>
        </tr>
    </table>
    <br />
 <div style="text-align: right; width: 940px;  "><a title="Exportar a Excel"> <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png" Width="20px" Visible="True" OnClick="ibExcel_Click" /></a></div>
     <div runat="server" id="divGrilla" style="height:650px;width:940px; overflow:auto;border:1px inset blue; "><%--margin-left:-25px;--%>
         
            <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate>
                    <Columns>
                     <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  ReadOnly="True" UniqueName="OT" ItemStyle-Width="30px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT"  ReadOnly="True" UniqueName="NombreOT" ItemStyle-Width="250px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente"  ReadOnly="True" UniqueName="Cliente" ItemStyle-Width="250px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" ItemStyle-HorizontalAlign="Right"  ReadOnly="True" UniqueName="Tiraje" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="FechaEmision" HeaderText="Emitida"  ReadOnly="True" UniqueName="FechaEmision" ItemStyle-Width="90px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="FechaEntrega" HeaderText="FechaEntrega"  ReadOnly="True" UniqueName="FechaEntrega" ItemStyle-Width="100px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado"  ReadOnly="True" UniqueName="Estado" ItemStyle-Width="90px">
                      </telerik:GridBoundColumn>   
                                                     
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True"></HeaderContextMenu>
                </telerik:radgrid>
     </div>
</asp:Content>
