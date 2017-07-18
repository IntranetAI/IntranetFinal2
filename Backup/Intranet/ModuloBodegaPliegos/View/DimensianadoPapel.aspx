<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="DimensianadoPapel.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.DimensianadoPapel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .divTitulo{
    font-weight: bold;
    padding: 5px;
    border: 1px solid #959595;
    text-align: left;
        width: 253px;
    }
.divSeccion{
    padding: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
.divEtiqueta{
    display: inline-block;
    padding: 5px;
    font-weight: bold;
    text-align: left;
}
.divCampo{
    display: inline-block;
    text-align: left;
}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Descripción Papel:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Código Papel:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label12" runat="server" Text="Estado:"></asp:Label>
                </td>
            <td class="style6">
               
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>Sin Atender</asp:ListItem>
                    <asp:ListItem>En Proceso</asp:ListItem>
                    <asp:ListItem>Atendida</asp:ListItem>
                    <asp:ListItem>Parcialmente Atendida</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
               <td class="style3">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Apertura Desde: "></asp:Label>
               
            </td>
            <td class="style3">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style3">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Apertura Hasta: "></asp:Label>
                </td>
            <td class="style3">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style3">
                </td>
            <td class="style8">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        <br />
        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacionOT" HeaderText="NroFolio" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaCreacionOT" UniqueName="FechaCreacionOT">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="FechaSolicitud" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Entrada a Maquina" ItemStyle-Width="160px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="NroOP" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>               
                    <telerik:GridBoundColumn DataField="Componente" HeaderText="NombreOP" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>                 
                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>                   
                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Descripcion" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="190px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="SolicitadoKG" ItemStyle-Width="50px" SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="50px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Accion" HeaderText="Ver" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
</asp:Content>
