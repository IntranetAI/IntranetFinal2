<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisProyectos.aspx.cs" Inherits="Intranet.ModuloProyectos.View.MisProyectos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 76px">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="True">
            </asp:ToolkitScriptManager>
    <div align="center"> 
        <asp:Label ID="Label1" runat="server" Text="MIS PROYECTOS" Font-Bold="True"></asp:Label></div>
    <div ALIGN="center">
        <asp:Label ID="lblMisProyectos" runat="server"></asp:Label>

        <br />

    </div>
    <div align="center" id="divProyecto" runat="server" visible="false">
        <asp:Label ID="lblProyecto" runat="server"></asp:Label>
        <div style="height:420px; width:690px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" 
                    GridLines="None"   >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" 
                    HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                                    <ItemStyle Width="350px" />
                                </telerik:GridBoundColumn>
                                
                                
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente">
                                <ItemStyle Width="350px" />
                            </telerik:GridBoundColumn>
                                                        
                            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT"
                            UniqueName="Tiraje">
                                <ItemStyle Width="50px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                            UniqueName="Estado">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn> 



   <%--                             <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas<input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
              --%>
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
        </div>
    </div>
    </form>
</body>
</html>
