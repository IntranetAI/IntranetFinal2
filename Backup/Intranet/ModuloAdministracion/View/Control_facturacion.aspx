<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Control_facturacion.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Control_facturacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function Solicitud(OT) {
        window.open('Historial_Notas.aspx?OT=' + OT + '&Mens=OK', 'Detalle Informe Producción', 'left=45,top=50,width=1014 ,height=620,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
    function agregarNota(OT) {
        window.open('Historial_Notas.aspx?OT=' + OT, 'Detalle Informe Producción', 'left=45,top=50,width=1014 ,height=620,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
    function Filtro(Estado) {
        if (Estado == "Si") {
            document.getElementById("divFiltro").style.display = "block";
        }
        else {
            document.getElementById("divFiltro").style.display = "none";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divFiltro" style="display:block">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 900px;" 
        align="center">

        <tr>
               <td>
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" Width="80px"></asp:TextBox>
               
               </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td>
               
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td>
                   <asp:Label ID="Label7" runat="server" Text="Cliente:"></asp:Label>
               
               </td>
            <td>
               <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
               <div style="margin-top:-20px;margin-left:200px;text-align:right;width:20px;">  
                    <a onclick="javascript:Filtro('No');">
                        <asp:Image ID="Image2" runat="server" Height="16px"  Width="16px" ImageUrl="~/images/cerrar.PNG"/>
                    </a>
                </div>
            </td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                                  
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"  Width="80px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
               
               </td>
            <td>
                &nbsp;
                   <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
               
               </td>
            <td>
               
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

               </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Ver  OTs Proceso" />
                </td>
            <td>
               
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        </div>
        <div align="right" style="margin-bottom:5px;margin-right:20px;">
            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
            <a onclick="javascript:Filtro('Si');">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/buscar.png" Height="20px"  Width="20px"/>
            </a>
            &nbsp;&nbsp;
        </div>
                <div style="height:490px;width:1085px; overflow:auto;" >
                <telerik:radgrid ID="RadGrid1" runat="server" 
        Skin="Outlook" >
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
        <Columns>
            <telerik:GridBoundColumn DataField="numeroFactura" HeaderText="*" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="numeroFactura" UniqueName="numeroFactura">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-HorizontalAlign="Center" SortExpression="OT" UniqueName="OT">
            </telerik:GridBoundColumn>
                        
            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Producto" ItemStyle-Width="280px"  SortExpression="NombreOT" UniqueName="NombreOT">
            </telerik:GridBoundColumn>         
             
            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ItemStyle-Width="280px" SortExpression="Cliente" UniqueName="Cliente">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT" ItemStyle-Width="80px"  SortExpression="Tiraje" UniqueName="Tiraje" ItemStyle-HorizontalAlign="Right" >
            </telerik:GridBoundColumn>               
                    
                    
            <telerik:GridBoundColumn DataField="TotalDesp" HeaderText="Total Des." ItemStyle-Width="80px" SortExpression="TotalDesp" UniqueName="TotalDesp" ItemStyle-HorizontalAlign="Right" >
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="FechaLiquidacion" HeaderText="Fecha Liqui."  ItemStyle-Width="90px"  SortExpression="FechaLiquidacion" UniqueName="FechaLiquidacion">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="FechaFactura" HeaderText="Fecha Fact." ItemStyle-Width="90px" SortExpression="FechaFactura" UniqueName="FechaFactura">
            </telerik:GridBoundColumn>
                    

            <telerik:GridBoundColumn DataField="ValorNeto" HeaderText="Valor Neto" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="80px" SortExpression="ValorNeto" UniqueName="ValorNeto">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="Accion" HeaderText="" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="VerMas" HeaderText="Ver Más" ItemStyle-Width="80px" SortExpression="VerMas" UniqueName="VerMas">
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