<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="RecepcionOTComercial.aspx.cs" Inherits="Intranet.ModuloDespacho.View.RecepcionOTComercial" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script  type="text/javascript" language="javascript">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Ingrese Folio: "></asp:Label>
    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
        onclick="btnFiltro_Click" />
    </div>
    <br />
    <div align="center" id="divMensaje" runat="server" visible="false">
        <asp:Image ID="imgMensaje" runat="server" />&nbsp;<asp:Label ID="lblMensaje" 
            runat="server"></asp:Label></div>
    <div align="right" style="width: 1054px">
            <a    title="Aprobar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibAprobar" runat="server" ImageUrl="~/Images/check.png" 
                    Width="20px" OnClick="ibAprobar_Click1"   />
                <asp:Label ID="Label1" runat="server" Text="Aprobar"></asp:Label>
                
            </a>

                &nbsp;&nbsp;

           <a    title="Rechazar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibRechazar" runat="server" ImageUrl="~/Images/cross.png" 
                    Width="20px" onclick="ibRechazar_Click"   />
                <asp:Label ID="Label2" runat="server" Text="Rechazar"></asp:Label>
                
            </a>
            </div>
        <div align="center" id="DivGrilla" runat="server"
        style="height:502px;width:1090px; overflow:auto;border:1px inset blue;" >
       <%-- ClientSettings-EnablePostBackOnRowClick="true"  --%>
    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" 
                Height="500px"  >  
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" 
                            UniqueName="Folio" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            
                                
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                                UniqueName="OT" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                            UniqueName="NombreOT" ItemStyle-Width="210px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>


                            
                            <telerik:GridBoundColumn DataField="TirajeOT" HeaderText="Tiraje OT" 
                            UniqueName="TirajeOT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            


                           
                           
                           <telerik:GridBoundColumn DataField="CantidadEnviada" HeaderText="Tiraje Pliego" 
                            UniqueName="CantidadEnviada" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Peso" HeaderText="Peso" 
                            UniqueName="Peso" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
                            <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripcion" 
                            UniqueName="Descripcion" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="EnviadaPor" HeaderText="Generada por" 
                            UniqueName="EnviadaPor" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaEnvio" HeaderText="Fecha Generacion" 
                            UniqueName="FechaEnvio" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                            UniqueName="Estado" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>


                                          <telerik:GridTemplateColumn UniqueName="TemplateColumn" ItemStyle-Width="30px" >
                <HeaderTemplate>Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox"  />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server"  />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >

              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    </div>
</asp:Content>
