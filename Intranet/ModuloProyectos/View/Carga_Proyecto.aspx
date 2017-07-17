<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Carga_Proyecto.aspx.cs" Inherits="Intranet.ModuloProyectos.View.Carga_Proyecto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
<%-- <script src="//code.jquery.com/jquery-1.9.1.js"></script>--%>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
<%--  <link rel="stylesheet" href="/resources/demos/style.css">--%>
 <script>
     function openGame(OT, NombreOT) {
         window.open('DetalleOT.aspx?ot='+OT+'&not='+NombreOT, 'Detalle OT', 'left=150,top=100,width=958 ,height=790,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
     }
    </script>
    
  <script>
      $(function () {
          $("#dialog").dialog();
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">
    <asp:Label ID="lblProyecto" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" />
    </div>
    <div align="right" style="padding-bottom:10px; width: 1089px;">                <a title="Exportar a Excel" > 
               <asp:ImageButton ID="ibExportExcel" runat="server"  Height="20px" 
                    ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    onclick="ibExportExcel_Click"  />
                   &nbsp;<asp:Label ID="Label3" runat="server" Text="Exportar a Excel"></asp:Label>
                   </a></div>
       <div runat="server" id="divGrillaGuias" visible="true" 
                       style="height:550px;width:1090px; overflow:auto;" >
                       <%--grilla guias de QGCHILE--%>
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT" ItemStyle-Width="25px"  >
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT" ItemStyle-Width="140px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" UniqueName="Cliente" ItemStyle-Width="170px"  >
                </telerik:GridBoundColumn>


<%--
                <telerik:GridBoundColumn DataField="FechaMinima" HeaderText="Fecha Primer y ultimo Despacho" UniqueName="FechaMinima" ItemStyle-Width="200px"  >
                </telerik:GridBoundColumn>--%>

                                 <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje OT" UniqueName="TirajeTotal"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="EnviadoEnc" HeaderText="Enviado Enc." ItemStyle-Width="30px" UniqueName="EnviadoEnc"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="TotalRecepcionado" HeaderText="Fecha Ult. Desp" ItemStyle-Width="80px" UniqueName="TotalRecepcionado"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="TotalDespachado" HeaderText="Total Desp." ItemStyle-Width="30px" UniqueName="TotalDespachado"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Devolucion" HeaderText="Devol." SortExpression="Devolucion" UniqueName="Devolucion" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" UniqueName="Saldo"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn DataField="Avance" HeaderText="Avance(%)" SortExpression="Avance" UniqueName="Avance"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px">
                </telerik:GridBoundColumn>



                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado" ItemStyle-Width="50px">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="VerMas" HeaderText="" SortExpression="VerMas" UniqueName="VerMas"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                </telerik:GridBoundColumn>


<%--                
              <telerik:GridTemplateColumn UniqueName="TemplateColumn" ItemStyle-Width="10px">
                <HeaderTemplate>Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >
--%>


              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
            </div>
  <%--              <div id="dialog" title="Basic dialog">
  <p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
</div>--%>
</asp:Content>
