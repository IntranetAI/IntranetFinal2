<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imprimir_ScoreCard_Semanal.aspx.cs" Inherits="Intranet.View.Imprimir_ScoreCard_Semanal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informe ScoreCard Diario</title>
    <script src="../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../js/jquery.PrintArea.js" type="text/javascript"></script>
   <script type="text/javascript" language="javascript">

	function imprSelec() {
	    $("#seleccion").printArea();  
	}
	
   </script>

    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>

</head>
<body onload="imprSelec();">           
    <form id="form1" runat="server">
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
     </asp:ToolkitScriptManager>
    <table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 870px;" 
        align="center">

        <tr>
               <td class="style1">
                &nbsp;&nbsp;
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
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
       <div align="right" style="width:1250px;"><input type="button" value="Imprimir" onclick="imprSelec();"/></div>
    <div id="seleccion">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
