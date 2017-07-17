<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="OPSCreadas.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.OPSCreadas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function Solicitud(ot, componente, solFL, solKG, usuario) {
        window.open('AtenderSolicitudPapel2.aspx?ot=' + ot + '&comp=' + componente + '&solFL=' + solFL + '&solKG=' + solKG+'&usuario='+usuario, 'Detalle Informe Producción', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 865px;" 
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
               
                <asp:TextBox ID="txtPapel" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                   <asp:Label ID="Label3" runat="server" Text="Código Papel:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtCodigoPapel" runat="server" Enabled="False"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label12" runat="server" Text="Estado:"></asp:Label>
                </td>
            <td class="style6">
               
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>Sin Procesar</asp:ListItem>
                    <asp:ListItem>En Proceso</asp:ListItem>
                    <asp:ListItem>Procesada</asp:ListItem>
                    <asp:ListItem>Parcialmente Procesada</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
               <td class="style3">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Apertura Desde: "></asp:Label>
               
            </td>
            <td class="style3">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style3">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Apertura Hasta: "></asp:Label>
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
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="500px" Width="1095px" >
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OPs Creadas</HeaderTemplate>
            <ContentTemplate>
                        <div style="height:490px;width:1085px; overflow:auto;" >
                        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" OnItemDataBound="gridSearchResults_OnItemDataBound" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" 
                        SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                        UniqueName="OT">
                        <ItemStyle Width="30px" />
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" 
                        SortExpression="NombreOT" UniqueName="NombreOT">
                        <ItemStyle Width="160px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente"  
                        SortExpression="Componente" UniqueName="Componente">
                        <ItemStyle Width="40px" />
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" 
                        SortExpression="Papel" UniqueName="Papel">
                        <ItemStyle Width="190px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje"  
                        SortExpression="Gramaje" UniqueName="Gramaje">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" 
                        SortExpression="Ancho" UniqueName="Ancho">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" 
                        SortExpression="Largo" UniqueName="Largo">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="Sol. FL" 
                        SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="SolicitadoKG" HeaderText="Sol. KG" 
                        SortExpression="SolicitadoKG" UniqueName="SolicitadoKG">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Procesado" HeaderText="Procesado" 
                        SortExpression="Procesado" UniqueName="Procesado">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                        SortExpression="Estado" UniqueName="Estado">
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" 
                        SortExpression="Accion" UniqueName="Accion">
                        <ItemStyle Width="50px" />
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
            </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Fechas Asignadas">
            <HeaderTemplate>Pliegos desde Pesa</HeaderTemplate>
            <ContentTemplate>
            <div style="height:490px;width:1085px; overflow:auto;" >
            <div align="center">
                <asp:Label ID="Label13" runat="server" Text="Ingrese Nro Pallet:  "></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                <telerik:radgrid ID="RadGrid2" runat="server" Skin="Outlook" >
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
</asp:Content>
