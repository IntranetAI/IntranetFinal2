<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EstadisticaProduccion2.aspx.cs" Inherits="Intranet.ModuloProduccion.View.EstadisticaProduccion2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
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

<table style="background-color:#EEE;border:1px solid #999;margin-left:70px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Sección:"></asp:Label>
               
            </td>
            <td class="style2">
               
                <asp:DropDownList ID="ddlSeccion" runat="server" Width="173px" 
                    onselectedindexchanged="ddlSeccion_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="IMP ROT">Rotativa</asp:ListItem>
                    <asp:ListItem Value="IMP PLANA">Planas</asp:ListItem>
                    <asp:ListItem Value="ENCADERN">Encuadernación</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Maquina:"></asp:Label>
               </td>
            <td class="style2">
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="173px">
                </asp:DropDownList>
               </td>
            <td class="style2">
                </td>
        </tr>
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
    <div align="right">
        <table style="width:100%;">
            <tr>
                <td align="left">
    <asp:Label ID="lblGrid1" runat="server"></asp:Label>
                </td>
                <td align="right">
                     <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" onclick="ibExcel_Click" /></a> </td>
            </tr>
        </table>
    </div>
         <div id="Div1" runat="server" style="height:600px;overflow:auto;">
             <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                 <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana">
                     <NoRecordsTemplate>
                         <div style="text-align:center;">
                             <br />
                             ¡ No se han encontrado registros !<br /></div>
                     </NoRecordsTemplate>
                     <CommandItemSettings ExportToPdfText="Export to Pdf" />
                     <Columns>
                         <telerik:GridBoundColumn DataField="Semana" HeaderText="Sem" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Giros" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Giros" UniqueName="Giros">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="Horas Tiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="Horas Imp." ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Pre." ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasPruebaImpresion" HeaderText="Horas PruebaImp." ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPruebaImpresion" UniqueName="HorasPruebaImpresion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="GirosMalosPreparacion" HeaderText="GirosMalos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosMalosPreparacion" UniqueName="GirosMalosPreparacion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Prep." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="GirosMalosTiraje" HeaderText="GirosMalos Tiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosMalosTiraje" UniqueName="GirosMalosTiraje">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="Malos Tiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                         </telerik:GridBoundColumn>
                     </Columns>
                 </MasterTableView>
                 <ClientSettings EnableRowHoverStyle="true">
                 </ClientSettings>
                 <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                 </HeaderContextMenu>
             </telerik:radgrid>

             <telerik:radgrid ID="RadGrid2" runat="server" Skin="Outlook" >
                 <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana">
                     <NoRecordsTemplate>
                         <div style="text-align:center;">
                             <br />
                             ¡ No se han encontrado registros !<br /></div>
                     </NoRecordsTemplate>
                     <CommandItemSettings ExportToPdfText="Export to Pdf" />
                     <Columns>
                         <telerik:GridBoundColumn DataField="Semana" HeaderText="Sem" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="Horas Tiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="Horas Improductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="HorasPruebaImpresion" HeaderText="Horas PruebaImp." ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPruebaImpresion" UniqueName="HorasPruebaImpresion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="Malos Tiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                         </telerik:GridBoundColumn>

                     </Columns>
                 </MasterTableView>
                 <ClientSettings EnableRowHoverStyle="true">
                 </ClientSettings>
                 <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                 </HeaderContextMenu>
             </telerik:radgrid>
             <br />
                </div>
</asp:Content>
