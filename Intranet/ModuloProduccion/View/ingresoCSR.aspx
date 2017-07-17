<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ingresoCSR.aspx.cs" Inherits="Intranet.ModuloProduccion.View.ingresoCSR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../js/funciones.js" type="text/javascript"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/ConfiguracionPantalla.js" type="text/javascript"></script>

        <script language="javascript" type="text/javascript">
            var controlador = "../../View/MantenedordeSesion.ashx";
            function MantenSesion() {
                var head = document.getElementsByTagName('head').item(0);
                script = document.createElement('script');
                script.src = controlador;
                script.setAttribute('type', 'text/javascript');
                script.defer = true;
                head.appendChild(script);

            }
            setInterval("MantenSesion()", 1080000); //1080000
    
    </script>
</head>
<body>
 <div id="modal">
    <form id="form1" runat="server">
   
    <table style="width: 100%;">
        <tr>
            <td class="style11">
                &nbsp;
            <asp:Image ID="Logo" runat="server" ImageUrl="../../images/quadlogo.PNG"/>
            </td>
            <td class="style11">
                &nbsp;
            </td>
            <td class="style11">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style10" style="text-align:center;" colspan="3">
                &nbsp; &nbsp;
                <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                    Text="Asignar Fecha CSR OT"></asp:Label>
                    </td>
        </tr>
        </table>
        <fieldset>
    <legend>Datos OT</legend>
 
        <table style="width: 99%;">
            <tr>
                <td class="style1">
                    
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style4">

                </td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="OT" Font-Size="Small" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style7">
                    :&nbsp;
                    <asp:Label ID="lblOT" runat="server" Font-Size="Small"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT" Font-Size="Small" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    :&nbsp;
                    <asp:Label ID="lblNomOT" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Cliente" Font-Size="Small" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style5" colspan="4">
                    :&nbsp;
                    <asp:Label ID="lblCliente" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                    &nbsp;<asp:Label ID="Label3" runat="server" Text="Tiraje Original" 
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                </td>
                <td class="style7">
                    :&nbsp;
                    <asp:Label ID="lblTiraje" runat="server" Font-Size="Small"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
    
    </fieldset>        <%-- segundo ingreso fechas --%>
              <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
             </asp:ToolkitScriptManager>
 
    <fieldset style="width:578px;height:250px;">

   
        <div style="margin-top:5px;">
       <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="200px" Width="580px" >
           
           <asp:TabPanel runat="server" HeaderText="Asignar Fecha CSR" ID="TabPanel1">

               <HeaderTemplate>
                   Asignar Fecha CSR<br />
               </HeaderTemplate>

            <ContentTemplate>
                <br />
                <asp:Label ID="Label28" runat="server" Text="Fecha Entrega: "></asp:Label>
      <asp:TextBox ID="txtFecha" runat="server" Width="89px" Height="20px"></asp:TextBox>

                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFecha" Format="dd/MM/yyyy" Enabled="True">
                </asp:CalendarExtender>
                <br />
                <asp:Label ID="Label29" runat="server" Text="Observación"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtObservacion" runat="server" Height="80px" 
                    TextMode="MultiLine" Width="369px"></asp:TextBox>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bntAgregar" runat="server" onclick="Button2_Click" 
                    Text="Asignar Fecha" />&nbsp;&nbsp;<asp:Button ID="btnModificar" runat="server" 
                    onclick="btnModificar_Click" Text="Modificar" Visible="False" />
&nbsp; 
                <asp:Button ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" 
                    Text="Volver" />
                <br /><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;&nbsp;
                <div style="text-align:center;">
                  <br />
                    </div>
                  
                </div>
</ContentTemplate>
      
</asp:TabPanel>

</asp:TabContainer> 


    </div>
    </fieldset>     
    </form>
    </div>

</body>
<script src="../../js/jquery.min.js" type="text/javascript"></script>
<script src="../../js/jquery.reveal.js" type="text/javascript"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        //	        $('#button').click(function (e) { // Button which will activate our modal
	        $('#modal').reveal({ // The item which will be opened with reveal
	            animation: 'fade',                   // fade, fadeAndPop, none
	            animationspeed: 600,                       // how fast animtions are
	            closeonbackgroundclick: false,              // if you click background will modal close?
	            dismissmodalclass: 'close'    // the class of a button or element that will close an open modal
	        });
	        return false;
	    });
	    //	    });
	</script>  
</html>
