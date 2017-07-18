<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedactarRespuesta.aspx.cs" Inherits="Intranet.ModuloUsuario.View.RedactarRespuesta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
<div><%--  id="modal" >   <%--idmodal--%>--%>
    <form id="form1" runat="server">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
  </asp:ToolkitScriptManager>
    <div>
            <table style="width:100%;">
            <tr>
                <td class="style1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="../../images/quadlogo.PNG"/>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                <div style="text-align:center;">    <asp:Label ID="Label1" runat="server" 
                        Font-Bold="True" Font-Size="Medium" 
                        Text="Respuesta a Mensaje: "></asp:Label>
                    <asp:Label ID="lblRespuesta" runat="server" Font-Bold="True" ForeColor="Gray"></asp:Label>
                </div>
                </td>
            </tr>
            </table>
    
    </div>
      <table style="width:100%;">
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label3" runat="server" Text="OT: " Font-Bold="True" 
                      ForeColor="Gray"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lblOT" runat="server" Font-Bold="True"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label4" runat="server" Text="Nombre OT: " Font-Bold="True" 
                      ForeColor="Gray"></asp:Label>
              </td>
              <td>
               <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label5" runat="server" Text="Asunto: " Font-Bold="True" 
                      ForeColor="Gray"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lblAsunto" runat="server" Font-Bold="True"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label7" runat="server" Text="Respuesta: " Font-Bold="True" 
                      ForeColor="Gray"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:TextBox ID="txtRespuesta" runat="server" Height="77px" MaxLength="200" 
                      TextMode="MultiLine" Width="318px"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>
          <table style="width:100%;">
        <tr>
            <td colspan="3">
            <div style="text-align:center;">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Adjuntar Archivos"></asp:Label>
            </div>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label6" runat="server" Text="Seleccione: " Font-Bold="True" 
                    ForeColor="Gray"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;<asp:Button ID="btnAdjuntar" runat="server" Text="Adjuntar" 
                    onclick="btnAdjuntar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
                  <div style="height:150px; width:588px; overflow:auto;text-align:center;">
                                 <asp:GridView ID="griddocument_attachment" runat="server" 
                                     AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID_Archivo" 
                                     ForeColor="#333333" GridLines="None" HeaderStyle-HorizontalAlign="Left" 
                                     HeaderStyle-VerticalAlign="Top"  RowStyle-VerticalAlign="Top"  
                                    >
                                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                     <Columns>
                                         <asp:TemplateField HeaderStyle-Width="3%">
                                             <ItemTemplate>
                                                 <asp:Image ID="Image1" runat="server" Height="20px" 
                                                     ImageUrl="~/Images/iconoDescarga.png" Width="20px" />
                                             </ItemTemplate>
                                             <HeaderStyle Width="100px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Archivo">
                                             <ItemTemplate>
                                                 <%# Eval("NombreArchivo")%>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText=" ">
                                             <ItemTemplate>
                                                 <a title="Descargar">Eliminar </a>
                                             </ItemTemplate>
                                             <HeaderStyle Width="5%" />
                                         </asp:TemplateField>
                                     </Columns>
                                     <EditRowStyle BackColor="#999999" />
                                     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                         HorizontalAlign="Left" VerticalAlign="Top" />
                                     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Top" />
                                     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                     <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                     <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                     <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                     <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                 </asp:GridView>
                            </div>
               
               
               </td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
            <div style="text-align:center;">
                  <asp:Button ID="btnResponder" runat="server" Text="Responder" 
              onclick="btnResponder_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="76px" 
                      onclick="btnSalir_Click" />
            </div>
            </td>
        </tr>
    </table>
      <p>
                  &nbsp;</p>
      <p>
                  &nbsp;</p>
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
