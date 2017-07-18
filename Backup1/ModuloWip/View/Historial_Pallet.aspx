<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historial_Pallet.aspx.cs" Inherits="Intranet.ModuloWip.View.Historial_Pallet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../images/faviconqg.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="300px"
        Width="100%">
        <asp:TabPanel runat="server" HeaderText="Historial" ID="TabPanel0">
            <headertemplate>Historial</headertemplate>
            <contenttemplate>
                <div>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
            </contenttemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Detalle" ID="TabPanel1">
            <headertemplate>Detalle Pallet</headertemplate>
            <contenttemplate>
                <div>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </div>
            </contenttemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <div align="center">
        <button type="button" onclick="javascript:window.close()">
            Cerrar</button></div>
    </form>
</body>
</html>
