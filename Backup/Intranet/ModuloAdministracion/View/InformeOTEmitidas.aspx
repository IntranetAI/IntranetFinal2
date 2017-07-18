<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeOTEmitidas.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.InformeOTEmitidas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<table style="background-color:#EEE;border:1px solid #999;margin-left:30px;border-radius:10px 10px 10px 10px;" align="center" width="850px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style2">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
            </td>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td class="style2">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
               <td >
                &nbsp;&nbsp;
                   <asp:Label ID="Label5" runat="server" Text="Cliente:"></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
               
            </td>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
               </td>
            <td class="style1">
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>En Proceso</asp:ListItem>
                    <asp:ListItem>Liquidada</asp:ListItem>
                    <asp:ListItem>Anulada</asp:ListItem>
                </asp:DropDownList>
               </td>
            <td class="style1">
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
     <div id="Div1" runat="server" style="height:600px;overflow:auto;width:940px;">
            <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="200px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" SortExpression="Cliente" UniqueName="Cliente">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Tiraje" UniqueName="Tiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="EstadoOT" HeaderText="Estado" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" SortExpression="EstadoOT" UniqueName="EstadoOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaEmision" HeaderText="Emision" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaEmision" UniqueName="FechaEmision">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="UltimaModificacion" HeaderText="Ult. Modificacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaEmision" UniqueName="FechaEmision">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" SortExpression="Observacion" UniqueName="Observacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ingreso" HeaderText="Ingreso" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" SortExpression="Ingreso" UniqueName="Ingreso">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaIngreso" HeaderText="FechaIngreso" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="FechaIngreso" UniqueName="FechaIngreso">
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
