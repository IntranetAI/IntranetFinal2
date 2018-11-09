<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Intranet.View.Pruebas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
    hola<br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="borrar grid" />
&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="copiar" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
&nbsp;<telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Transportista" UniqueName="Cliente"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Direccion" HeaderText="Direccion" UniqueName="Direccion"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Carga" HeaderText="Carga" UniqueName="Carga"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Notas" HeaderText="Notas" UniqueName="Notas"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" UniqueName="Folio"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PersonaContacto" HeaderText="PersonaContacto" UniqueName="PersonaContacto"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" UniqueName="NombreOT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" UniqueName="Total"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Correo" HeaderText="Correo" UniqueName="Correo"></telerik:GridBoundColumn>

                            
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
    </div><br /><br /><br /><br /><br /><br />
        <select class="mdb-select md-form" multiple>
                  <optgroup label="team 1">
                    <option value="1">Option 1</option>
                    <option value="2">Option 2</option>
                  </optgroup>
                  <optgroup label="team 2">
                    <option value="3">Option 3</option>
                    <option value="4">Option 4</option>
                  </optgroup>
                </select>
<button class="btn-save btn btn-primary btn-sm">Save</button>
    </form>
</body>
</html>
