<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Regional.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Regional" Culture="Auto" UICulture="Auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="true" style="margin-top:5px;">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;border-radius:10px 10px 10px 10px;" align="center" width="945px">
               
        <tr>
            <td style="width:95;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td style="width:134;">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td style="width:95;">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
            </td>
            <td style="width:134;">
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="128px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="txtFechaTermino" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td style="width:300px;" colspan ="2">
            <div style="margin-left:17px;">
                <asp:ImageButton ID="btnFiltro" runat="server" Height="25px" 
                    ImageUrl="~/Images/Excel-icon.png" onclick="ibExcel_Click" Visible="True" 
                    Width="25px" />
                </a>
           </div>
            </td>
            
            <td>
            <div style="margin-top:-20px;margin-left:40px;text-align:right;">  
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                    style="width: 16px"  /></div>
            </td>
        </tr>
    </table>
    <br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
        </asp:Panel>
      
        <script type="text/javascript">
            $('#accordion ul:eq(8)').show();
 </script>
</asp:Content>
