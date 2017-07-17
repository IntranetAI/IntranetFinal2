<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="SolicitudCortePapel.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.SolicitudCortePapel" %>
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
}
    .style2
    {
        width: 1263px;
    }
    .style3
    {
        width: 1241px;
    }
    .style4
    {
        width: 1188px;
    }
    .style5
    {
        width: 387px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divTitulo">
        Solicitud Corte de Papel</div>
    <div class="divSeccion">
        <table style="width: 352%;">
            <tr>
                <td class="style4">
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Numero OP:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Nombre OP:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Componente:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Cant. Solicitada"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Formato Impresion:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Fecha Creacion OP:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label9" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
        <div class="divTitulo">
            Datos de Papel Solicitado a Corte</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style5">
                    &nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Codigo Producto:"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                    <asp:Label ID="Label16" runat="server" Text="Descripcion:"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label15" runat="server" Text="Gramaje:"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="Ancho:"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    <asp:Label ID="Label13" runat="server" Text="Largo:"></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                    <asp:Label ID="Label17" runat="server" Text="Certificacion:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label12" runat="server" Text="Tipo Certificacion:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
        <div class="divTitulo">
        Papel Asignado a Corte </div>
    <div class="divSeccion">
    <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="NumeroTicket" HeaderText="CodigoPallet" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="NumeroTicket" UniqueName="NumeroTicket">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Ubicacion" ItemStyle-Width="30px" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NumeroOP" HeaderText="CodigoProducto" ItemStyle-Width="160px" SortExpression="NumeroOP" UniqueName="NumeroOP">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Marca" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="190px" SortExpression="Descripcion" UniqueName="Descripcion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="CantSolicitadaFL" HeaderText="Certificacion" ItemStyle-Width="50px" SortExpression="CantSolicitadaFL" UniqueName="CantSolicitadaFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="CantPliegos" ItemStyle-Width="50px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Estado" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
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
