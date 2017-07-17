<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Mensajeria.aspx.cs" Inherits="Intranet.ModuloUsuario.View.Mensajeria" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ MasterType VirtualPath="~/View/index.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
   
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <link  href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui-1.10.3.js" type="text/javascript"></script>
    <script src="../../js/ConfiguracionPantalla.js" type="text/javascript"></script>

     <script type="text/javascript">
         $(function () {
             $("#acco").accordion();
             $("#accordion").show();
         });
         function newRespuesta(id) {
             location.href = 'RedactarRespuesta.aspx?id='+id;
         };
</script>
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

<style>
.mailRevisido {
	font-family: "Trebuchet MS", "Helvetica", "Arial",  "Verdana", "sans-serif";
	font-size: 78%;
}
</style>
        <style type="text/css">
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
            background-color: #EEE;
        }
        .Grilla
        {
          
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <%--inicio filtro--%>
        <asp:Panel ID="Panel2" runat="server" Visible="True" style="padding-left:-10px; margin-top:15px;margin-bottom:-25px;margin-left:-5px;">
    <asp:Panel ID="Panel1" runat="server" Visible="False" style="padding-left:-10px; margin-top:15px;margin-bottom:-25px;margin-left:-5px;">
    <table align="center" width="895px" style="background-color:#EEE;border:1px solid #999">
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style13">
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <div style="text-align:right;margin-top:-30px;">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style21">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style21">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style10">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style23">
                &nbsp;</td>
            <td class="style19">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
            </td>
        </tr>
    </table>
    <br />
        </asp:Panel>
        <%--fin filtro--%>



        <%--inicio container--%>
                <table class="Grilla"  align="center" width="900px" style="margin-left:-22px;">
        <tr>
            <td>
                </td>
            
            <td>
            
           <div runat="server" id="divbotones" style="text-align:right;margin-top:-40px;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/Images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
               
       </div>

            <div style="height:540px;width:895px; overflow:auto; margin-top:0px;margin-left:5px;" >
               
             <telerik:radgrid ID="RadGrid1" runat="server" ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true"
                Skin="Outlook" OnItemCommand="RadGrid1_ItemCommand">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                <telerik:GridBoundColumn DataField="CantidadMensaje" HeaderText="<a title='Total de Mensajes'><img src='../../Images/mensajeria.png' height='20' width='20' /></a>" ItemStyle-Width="30px" SortExpression="CantidadMensaje" UniqueName="CantidadMensaje">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaSoli" HeaderText="<a title='Nuevos Mensajes'><img src='../../Images/mensajeria-intento.png' height='20' width='20' /></a>" ItemStyle-Width="30px" SortExpression="FechaSoli" UniqueName="FechaSoli">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NivelCumpli" HeaderText="" ItemStyle-Width="25px" SortExpression="NivelCumpli" UniqueName="NivelCumpli">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" 
                ReadOnly="True" SortExpression="NumeroOT" UniqueName="NumeroOT" ItemStyle-Width="50px">
                </telerik:GridBoundColumn>
                                
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT" 
                UniqueName="NombreOT" ItemStyle-Width="300px">
                </telerik:GridBoundColumn>
                                
                <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Tiraje" 
                UniqueName="Ejemplares" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right" >
                </telerik:GridBoundColumn>
                            
                <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Cliente" 
                UniqueName="NombreCliente" ItemStyle-Width="300px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaPro" HeaderText="Fecha Entrega" ItemStyle-Width="130px" SortExpression="FechaPro" UniqueName="FechaPro"  DataFormatString="{0:dd/MM/yyyy HH:mm}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ejemplares" Visible="false" HeaderText="Tiraje" ItemStyle-Width="100px" SortExpression="Ejemplares" UniqueName="Ejemplares">
                </telerik:GridBoundColumn>                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
              
              </div>
           
               
                
                
                </td>
            <td>
               </td>
        </tr>
    </table>
     </asp:Panel>
     <asp:Panel ID="Panel3" runat="server" Visible="false" style="padding-left:-10px; margin-top:5px;margin-bottom:-25px;margin-left:-5px;">
         <div style="text-align:center;"><asp:Label ID="lblOTClick" runat="server"></asp:Label></div>
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
         <br /><h3 style='width:800px;'></h3>
     </asp:Panel>
    <br />
        <%--fin container--%>
        <script type="text/javascript">
            $('#accordion ul:eq(7)').show();
 </script>
        
</asp:Content>
