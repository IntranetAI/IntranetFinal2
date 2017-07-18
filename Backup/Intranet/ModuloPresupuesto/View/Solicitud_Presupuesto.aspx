<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Solicitud_Presupuesto.aspx.cs" Inherits="Intranet.ModuloPresupuesto.View.Solicitud_Presupuesto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function Agregar() {
        var w = 1010;
        var h = 937;
        var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
        var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

        width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
        height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

        var left = ((width / 2) - (w / 2)) + dualScreenLeft;
        var top = ((height / 2) - (h / 2)) + dualScreenTop;

        onload(window.open('Sol_PPTO.aspx?Bodega=1', 'Solicitud PPTO', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=' + w + ',height=' + h + ',left=' + left + ',top=' + top));
    }
    function FiltroActivo() {
        document.getElementById("tablaFiltro").style.display = "block";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 950px; margin-top: -15px;
        margin-left: -10px;">
        <a id="A1" runat="server" onclick="javascript:Agregar()"  style="color: #000000; text-decoration: blink;">
            <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />
        </a>&nbsp;&nbsp; <a title="Buscar OTs por Filtro" onclick="javascript:FiltroActivo();">
            <img alt="" src="../../Images/buscar.png" width="20" height="20px" />
        </a>&nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" />
        </a>
    </div>
    <table id="tablaFiltro" style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;display:none;" align="center" width="910px">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Pliegos: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPliegos" runat="server">
                </asp:DropDownList>

            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Bodegas: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlBodegas" runat="server">
                </asp:DropDownList>
                &nbsp;</td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="80px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server" Width="80px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Estado Pallet: "></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
            </td>
        </tr>
    </table>



    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" style="margin-left:-5px;"
        Height="550px" Width="945px">
    </asp:TabContainer>
                
    <br />

        <script type="text/javascript">
            $('#accordion ul:eq(0)').show();
 </script>
</asp:Content>
