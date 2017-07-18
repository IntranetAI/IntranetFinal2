<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="csr.aspx.cs" Inherits="Intranet.ModuloProduccion.View.csr" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <asp:Panel ID="pnlFiltro"  runat="server" Visible="False">  <%--style="padding-left:10px;"--%>
    &nbsp;
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-4px;" align="center" width="890px">
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style13">
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
               <div style="text-align:right;margin-top:-10px;">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style21">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" >
                </asp:CalendarExtender>
               
            </td>
            <td class="style21">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style10">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    Enabled="True"  TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style23">
                &nbsp;</td>
            <td class="style19">
                <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" 
                    Visible="False" />
           
            </td>
        </tr>
    </table>
 </asp:Panel>
 <%--fin panel filtro--%>




 <%--inicio container--%>
         <table class="Grilla" align="center" width="880px" style="margin-left:-15px;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
            <div style="text-align:right;margin-bottom:-20px; margin-top:10px" >
   <a title="Actualizar Registros">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"    />
                   </a>&nbsp;<a title="Buscar OTs por Filtro"><asp:ImageButton 
                    ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                     />
</a> 
              <%--  &nbsp;&nbsp;&nbsp;&nbsp;<a title="Suscribir OTs Seleccionadas"><asp:ImageButton ID="ibMultiCheck" 
                    runat="server" Height="30px" 
                   ImageUrl="~/images/check.png" Width="30px" Visible="False" 
                    onclick="ibMultiCheck_Click"  />
                   </a>&nbsp;&nbsp;&nbsp;
<a title="Elimina OTs Seleccionadas Suscritas">
              <asp:ImageButton ID="ibEliminarSuscrita" runat="server" Height="30px" 
                   ImageUrl="~/images/deleteS.png" Width="30px" Visible="False" 
                    onclick="ibEliminarSuscrita_Click" />
                   </a>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
       </div>


                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
       Height="610px" Width="890px">
        <asp:TabPanel runat="server" HeaderText="OTs con Fechas Asignadas por OV" ID="TabPanel1">
            <ContentTemplate>
               <div style="height:600px;width:875px; overflow:auto;" >
                <telerik:radgrid ID="RadGrid1" runat="server"  
                GridLines="None" Skin="Outlook"  OnItemCommand="contactsGrid_ItemCommand">
                
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT">
                     <NoRecordsTemplate>
                    <div style="text-align:center;"> <br />¡ No se han encontrado registros !<br /></div>                 
                                     </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn ItemStyle-Width="15px" DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" UniqueName="NumeroOT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="280px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Tiraje" UniqueName="Ejemplares" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="csr_observacion" HeaderText="Observacion" UniqueName="crs_observacion" ItemStyle-Width="250px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaSolicitada" HeaderText="FechaSolicitada" ItemStyle-Width="30px" SortExpression="FechaSolicitada" ItemStyle-HorizontalAlign="Right" UniqueName="FechaSolicitada"  >
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="FechaProduccion" HeaderText="Fecha Produccion" DataFormatString="{0:dd/MM/yyyy}"
                                SortExpression="FechaProduccion" UniqueName="FechaProduccion" ItemStyle-Width="50px"></telerik:GridBoundColumn>--%>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                            <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Asignar/Revisar</asp:LinkButton></ItemTemplate></telerik:GridTemplateColumn>
                            </Columns></MasterTableView>
                              <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                            </telerik:radgrid>
                            </div>
            </ContentTemplate>
        </asp:TabPanel>
                
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="OTs con Fechas Asignadas por CSR">
            <ContentTemplate>
              <div style="height:600px;width:875px; overflow:auto;" >
                <telerik:radgrid ID="RadGrid2" runat="server" GridLines="None"   
                Skin="Outlook"  OnItemCommand="contactsGrid_ItemCommand2">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT">
                     <NoRecordsTemplate>
                    <div style="text-align:center;"> <br />¡ No se han encontrado registros !<br /></div>                 
                                     </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn ItemStyle-Width="15px" DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" UniqueName="NumeroOT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="200px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Tiraje" ItemStyle-HorizontalAlign="Right" UniqueName="Ejemplares" ItemStyle-Width="25px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="observacion" HeaderText="Comentario CSR" UniqueName="observacion" ItemStyle-Width="200px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaCSR" HeaderText="Fecha Solicitada" 
                                SortExpression="FechaCSR" UniqueName="FechaCSR" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px"  >
                            </telerik:GridBoundColumn>
                          
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                            <ItemStyle CssClass="editCell" Width="25px"></ItemStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Modificar">Revisar/Modificar</asp:LinkButton>
                            </ItemTemplate></telerik:GridTemplateColumn></Columns>
                            </MasterTableView>
                            
                              <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                            </telerik:radgrid>
                            </div>
    </ContentTemplate>
    </asp:TabPanel>
        
    </asp:TabContainer>
    

                
                
                <div style="color:Green"></div>
                
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <%--fin container--%>
    <script type="text/javascript">
        $('#accordion ul:eq(1)').show();
 </script>
</asp:Content>
