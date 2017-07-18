<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleInformeProduccion.aspx.cs"
    Inherits="Intranet.ModuloProduccion.View.DetalleInformeProduccion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle Informe Producción</title>
    <style type="text/css">
        @media print
        {
            #Button1, #Button2,#Button3
            {
                display:none;
            }
            #divdetallepl
            {
                display: block;
                width: 100%;
                height: 100%;
                overflow: visible;
            }
            #divdetalleot
            {
                display: block !important;
                width: 100% !important;
                height: 100% !important;
                overflow: visible !important;
                max-height:100% !important;
            }
            #divdetalleotEnc
            {
                display: block !important;
                width: 100% !important;
                height: 100% !important;
                overflow: visible !important;
                max-height:100% !important;
            }
            .ajax__tab_body
            {
                height: 100% !important;
            }
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="True" EnableScriptLocalization="False">
    </asp:ToolkitScriptManager>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False"
            Font-Size="X-Large"></asp:Label>
        <br />
        <br />
    </div>
    <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" Height="600px"
        Width="1140px">
        &nbsp;&nbsp;<%-- Height="600px" Width="985px"--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TabPanel ID="TabPanel6" runat="server">
            <HeaderTemplate>
                Detalle Pliego</HeaderTemplate>
            <ContentTemplate>
                <div id="divdetallepl" style="max-height: 590px; width: 1130px; overflow: auto;">
                    <asp:Label ID="lblPliego" runat="server"></asp:Label>
                </div>
                <input id="Button1" type="button" value="Imprimir" onclick="javascript:print();"/>
            </ContentTemplate>
        </asp:TabPanel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Detalle OT Impresión">
            <ContentTemplate>
                <div id="divdetalleot"  style="max-height: 580px; width: 1130px; overflow: auto;">

                    <asp:Label ID="lbDetalle" runat="server" Text="Label"></asp:Label>
                    
                </div>
                <input id="Button2" type="button" value="Imprimir" onclick="javascript:print();"/>
            </ContentTemplate>
        </asp:TabPanel> 

                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle OT Encuadernación">
            <ContentTemplate>
                <div id="divdetalleotEnc"  style="max-height: 580px; width: 1130px; overflow: auto;">
   
                    <asp:Label ID="lblDetalleENC" runat="server" Text="Label"></asp:Label>
                    
                </div>
                <input id="Button3" type="button" value="Imprimir" onclick="javascript:print();"/>
            </ContentTemplate>
        </asp:TabPanel> 
    </asp:TabContainer>
    </form>
</body>
</html>
