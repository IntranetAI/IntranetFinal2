<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeDiarioEncuadernacion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.InformeDiarioEncuadernacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.modalBackground {
    background-color:Gray;
    filter:alpha(opacity=70);
    opacity:0.7;
}

.modalPopup {
    background-color:White;
    border-width:3px;
    border-style:solid;
    border-color:Gray;
    padding:3px;
    text-align:center;
}
.hidden {display:none}
   .divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    padding: 5px;
    text-align: center;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style4">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style4">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style4">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style4">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

           </td>
        </tr>
    </table>
    <br />
    <div id="Div1" runat="server" style="height:600px;overflow:auto;">
    <asp:Label ID="lblGrid1" runat="server" Font-Bold="True"></asp:Label>
    <br />


            <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" Width="1100px">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Dia" HeaderText="Dia" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center" SortExpression="Dia" UniqueName="Dia">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                
                    <telerik:GridBoundColumn DataField="Mañana" HeaderText="Mañana" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Mañana" UniqueName="Mañana">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcMañana" HeaderText="Mañana %" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcMañana" UniqueName="PorcMañana">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Tarde" HeaderText="Tarde" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Tarde" UniqueName="Tarde">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcTarde" HeaderText="Tarde %" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcTarde" UniqueName="PorcTarde">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Noche" HeaderText="Noche" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Noche" UniqueName="Noche">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcNoche" HeaderText="Noche %" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcNoche" UniqueName="PorcNoche">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TotalProducido" HeaderText="Total Producción" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="TotalProducido" UniqueName="TotalProducido">
                    </telerik:GridBoundColumn>

                    
                                      
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
               </div>
</asp:Content>
