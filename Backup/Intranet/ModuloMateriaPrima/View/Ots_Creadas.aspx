<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Ots_Creadas.aspx.cs" Inherits="Intranet.ModuloMateriaPrima.View.Ots_Creadas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function Solicitud() {
        window.open('SolicitudBobinaMaquina.aspx', 'Detalle Informe Producción', 'left=45,top=50,width=1210 ,height=810,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
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
<div id="divFiltro" style="display:none">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 865px;" 
        align="center">

        <tr>
               <td>
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td>
               
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td>
                &nbsp;</td>
            <td>
                <div style="margin-top:-5px;margin-left:40px;text-align:right;">  
                    <a onclick="javascript:Filtro('No');">
                        <asp:Image ID="Image2" runat="server" Height="16px"  Width="16px" ImageUrl="~/images/cerrar.PNG"/>
                    </a>
                </div>
            </td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Descripción Papel:"></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtPapel" runat="server"></asp:TextBox>
               
               </td>
            <td>
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Código Papel:"></asp:Label>
               
               </td>
            <td>
               
                <asp:TextBox ID="txtCodigoPapel" runat="server"></asp:TextBox>
               
               </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Estado:"></asp:Label>
                </td>
            <td>
               
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
               <td>
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Apertura Desde: "></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Apertura Hasta: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
                </td>
            <td>

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        </div>
        <div align="right" style="margin-bottom:-20px;margin-right:10px;">
            <a onclick="javascript:Filtro('Si');">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/buscar.png" Height="20px"  Width="20px"/>
            </a>
        </div>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="500px" Width="1095px" >
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OPs Creadas</HeaderTemplate>
            <ContentTemplate>
                        <div style="height:490px;width:1085px; overflow:auto;" >
                        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="160px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Codigo Papel" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="190px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Prensa" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="KG OT" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="50px" SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="SolicitadoKG" HeaderText="KG Bodega" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" SortExpression="SolicitadoKG" UniqueName="SolicitadoKG">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="80px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Ver Más" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
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
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Fechas Asignadas">
            <HeaderTemplate>Gestion OTs</HeaderTemplate>
            <ContentTemplate>
            <div style="height:490px;width:1085px; overflow:auto;" >
            <div align="center">
                <asp:Label ID="Label13" runat="server" Text="Ingrese Nro Pallet:  "></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                <telerik:radgrid ID="RadGrid2" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacionOT" HeaderText="FechaCreacionOT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaCreacionOT" UniqueName="FechaCreacionOT">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="160px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="190px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="SolicitadoFL" ItemStyle-Width="50px" SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="SolicitadoKG" HeaderText="SolicitadoKG" ItemStyle-Width="50px" SortExpression="SolicitadoKG" UniqueName="SolicitadoKG">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="50px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
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
            </ContentTemplate>
    </asp:TabPanel>

    </asp:TabContainer>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>
