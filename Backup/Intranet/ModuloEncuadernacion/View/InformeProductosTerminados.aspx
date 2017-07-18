<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeProductosTerminados.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InformeProductosTerminados" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 230px;
        }
    </style>
        <script>
            function openPopUp(OT, nOT) {
                window.open('DetalleInformeProductosTerminados.aspx?ot=' + OT + '&nOT=' + nOT + '&p=0', 'Detalle Despachos', 'left=80,top=100,width=1120 ,height=600,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
            }

            </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="800px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                </td>
        </tr>
        <tr>
               <td class="style4">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style1">
               
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

    <div align="right" style="width: 923px"> 
        <asp:ImageButton ID="ibExcel" runat="server" 
            ImageUrl="~/Images/Excel-icon.png" Width="25px" onclick="ibExcel_Click1" /></div>
    <div style="height:548px;width:930px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="200px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Tiraje" UniqueName="Tiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Despachado" HeaderText="Despachado" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Despachado" UniqueName="Despachado">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Devolucion" HeaderText="Devolucion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Devolucion" UniqueName="Devolucion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Saldo" UniqueName="Saldo">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn  DataField="CantPallet" HeaderText="CantPallet" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="CantPallet" UniqueName="CantPallet">
                    </telerik:GridBoundColumn>--%>

                    <telerik:GridBoundColumn DataField="CantCajas" HeaderText="Cant. Cajas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="CantCajas" UniqueName="CantCajas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="VerDetalle" HeaderText="Ver Detalle" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="VerDetalle" UniqueName="VerDetalle">
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
