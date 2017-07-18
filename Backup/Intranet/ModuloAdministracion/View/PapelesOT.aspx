<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="PapelesOT.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.PapelesOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="filtering" align="center" width="885px" style="border-radius:10px 10px 10px 10px;margin-left:20px;margin-top:6px;">
        <tr>
            <td class="style5">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               </td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style1">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style1">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style1">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style1">
                </td>
            <td class="style1">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
                &nbsp;&nbsp;&nbsp;
                
           
                &nbsp;
                &nbsp;
  
                
           
            </td>
        </tr>
    </table>
    <div align="right" style="width: 909px">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Excel-icon.png" 
            Visible="False" Width="23px" />
        <asp:LinkButton ID="lkExportar" runat="server" onclick="lkExportar_Click" 
            Visible="False">Exportar a Excel.</asp:LinkButton>
    </div>
    <div style="height:550px;width:940px; overflow-y:auto;" >
    <asp:Label ID="Label4" runat="server"></asp:Label>
    </div>
</asp:Content>
