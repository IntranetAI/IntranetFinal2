<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="EnvioFactura.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.EnvioFactura" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function openGame(folio, emisor,rut) {
            window.open('DetalleFacturaEnvio.aspx?folio=' + folio + '&emi=' + emisor + '&rut=' + rut, 'Detalle Factura', 'left=80,top=100,width=1120 ,height=600,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table align="center" width="800px" style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:8%;border-radius:10px 10px 10px 10px;">
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label11" runat="server" Text="Rut Remitente:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtRutEmisor" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label8" runat="server" Text="Nombre Remitente:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNombreEmisor" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label10" runat="server" Text="Nombre Item:"></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtNombreItem" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label9" runat="server" Text="Folio Doc.:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtFolioDocInicio" runat="server" Font-Names="Arial"></asp:TextBox>

            </td>
            <td class="style20" colspan="2">
                <asp:Label ID="Label14" runat="server" Text="Hasta"></asp:Label>
&nbsp;&nbsp;
                <asp:TextBox ID="txtFolioDocTermino" runat="server"></asp:TextBox>
                </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Remitente:"></asp:Label>
               
            </td>
            <td class="style6">
               
                &nbsp;<asp:TextBox ID="txtFechaInicioEmision" runat="server" 
                    style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicioEmision" Format="dd/MM/yyyy" >
                </asp:CalendarExtender>
               
            </td>
            <td class="style20" colspan="2">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Hasta"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtFechaTerminoEmision" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTerminoEmision_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" 
                    TargetControlID="txtFechaTerminoEmision">
                </asp:CalendarExtender>

                </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
                </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
<asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
    
            </td>
        </tr>
        </table>
        <div align="right" style="width: 921px">
        <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Images/Excel-icon.png" onclick="ImageButton1_Click" Width="25px" />
        </div>
           <div runat="server" id="divGrillaGuias" visible="true" 
                       style="height:530px;width:930px; overflow:auto;" >
                       <%--grilla guias de QGCHILE--%>
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Folio">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" UniqueName="Folio" ItemStyle-Width="40px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="RutEmisor" HeaderText="Rut Remitente"  UniqueName="RutEmisor" ItemStyle-Width="30px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="NombreEmisor" HeaderText="Nombre Remitente" UniqueName="NombreEmisor" ItemStyle-Width="250px"  >
                </telerik:GridBoundColumn>



                <telerik:GridBoundColumn DataField="FechaEmision" HeaderText="Fecha Remitente" UniqueName="FechaEmision" ItemStyle-Width="50px"  >
                <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>

                
                 <telerik:GridBoundColumn DataField="FechaVencimiento" HeaderText="Vencimiento" UniqueName="FechaVencimiento" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>   

                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado" ItemStyle-Width="130px"  >
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn DataField="VerMas" HeaderText="" UniqueName="VerMas" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>           
                              
                    
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
              </div>
</asp:Content>
