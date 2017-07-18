<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Anular_Pallet.aspx.cs" Inherits="Intranet.ModuloWip.View.Anular_Pallet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script  type="text/javascript" language="javascript">
        function openGame(OT, NombreOT) {
            window.open('Historial_Bobina.aspx?ot=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
         function SelectAllCheckboxes(spanChk) {

             // Added as ASPX uses SPAN for checkbox
             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }
         }
        </script>
     <style type="text/css">
         .style2
         {
             width: 344px;
         }
         .style3
         {
             width: 671px;
         }
         .style4
         {
             width: 332px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Anular Guias/Pallets</h3>
</div>--%>

<div align="center">  <asp:Label ID="Label3" runat="server" Text="Código Pallet / Numero OT:"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtCodigoPallet" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                    
                    </div>
    <div align="center" id="DivMensaje" runat="server">
    <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
              
    </div>
    <br />

        <div style="border:1px solid blue;min-height:100px; max-height:466px;overflow-y:auto;" >
                <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Control">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" >
                                <HeaderTemplate>Todas 
                                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect"  runat="server" />
                                    </ItemTemplate>
                              </telerik:GridTemplateColumn >
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicaciones" 
                                UniqueName="Ubicacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Posicion" HeaderText="Posiciones" 
                                ReadOnly="True" SortExpression="ToPosiciontal" UniqueName="Posicion" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="100px"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ID_Control" HeaderText="Pallet" 
                                ReadOnly="True" SortExpression="ID_Control" UniqueName="ID_Control" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Pliego"   HeaderText="Pliego" UniqueName="Pliegos" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Cant. Pliegos" 
                                ReadOnly="True" SortExpression="Pliegos_Impresos" UniqueName="Pliegos_Impresos" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Peso_pallet" HeaderText="Peso Pallet" 
                                ReadOnly="True" SortExpression="Peso_pallet" UniqueName="Peso_pallet" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Maquina_Proceso" HeaderText="Pallets" 
                                ReadOnly="True" SortExpression="Maquina_Proceso" UniqueName="Maquina_Proceso" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado_Pallet2" HeaderText="Estado" 
                                ReadOnly="True" SortExpression="Estado_Pallet2" UniqueName="Estado_Pallet2">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="VerMas" HeaderText="Detalle" 
                                ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                                <ItemStyle Width="50px" />
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
    <div align="center" style="width: 1093px">
        <br />
    <asp:Label ID="Label4" runat="server" Text="Causa Anulación:" Font-Bold="True" style="vertical-align:top;"
            Font-Size="Large"></asp:Label>
    <asp:TextBox ID="txtDevolucion" runat="server" Height="98px" TextMode="MultiLine" 
            Width="764px" Wrap="False"></asp:TextBox>

</div>    <br />
    <br />
    <div align="center" style="margin-bottom:5px;">
        <asp:Button ID="btnAnular" runat="server" Text="Anular Pallet" 
            onclick="btnAnular_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" onclick="btnNuevo_Click" 
            Width="83px" />
    </div>
</asp:Content>
