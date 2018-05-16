<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="MetricsWIP.aspx.cs" Inherits="Intranet.ModuloEtiquetasMetricsWIP.View.MetricsWIP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
         .divTitulo{
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding-top: 5px;
            padding-bottom: 5px;
            border: 1px solid #959595;
            text-align: left;
            color:#003e7e;
        }
        .divSeccion{
            padding-top: 10px;
            padding-bottom: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 126px;
        }
        .auto-style3 {
            height: 23px;
            width: 126px;
        }
        .auto-style4 {
            width: 149px;
        }
        .auto-style5 {
            height: 23px;
            width: 149px;
        }
    </style>
       <script  type="text/javascript" language="javascript">
           function CargaPliegosOT() {
               var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                var ddlTerritory = document.getElementById("<%= ddlPliego.ClientID %>");
                var lengthddlTerritory = ddlTerritory.length - 1;
                for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                }
             $.ajax({
                 url: "MetricsWIP.aspx/CargarPliegosOT",//CargarSKUStock
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'OT':'" + OT + "'}",
                     success: function (data) {
                         var jsdata = JSON.parse(data.d);
                         $.each(jsdata, function (key, value) {
                             $('#<%=ddlPliego.ClientID%>').append($("<option></option>").val(value.Pliego).html(value.Pliego));

                         });
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes!');
                     }
                 });
           }
           function BuscarFiltro() {
               var OT = document.getElementById("<%= txtOT.ClientID%>").value;
               var Pliego = document.getElementById("<%= ddlPliego.ClientID%>").value;
             $.ajax({
                 url: "MetricsWIP.aspx/CargarTabla", 
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'OT':'" + OT + "','Pliego':'" + Pliego + "'}",
                     success: function (data) {
                         document.getElementById("<%= lblTabla.ClientID%>").innerHTML = data.d[0];
<%--                         document.getElementById("<%= txtCantidad.ClientID%>").disabled = true;
                         document.getElementById("<%= lblObjId.ClientID%>").innerHTML = '';
                         document.getElementById("<%= lblOT.ClientID%>").innerHTML = '';
                         document.getElementById("<%= lblNombreOT.ClientID%>").innerHTML = '';
                         document.getElementById("<%= lblPliego.ClientID%>").innerHTML = '';--%>
                           //alert(data.d[0]);
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes!');
                     }
                 });
           }
           function Mostrar(objid, ot, nombreot, pliego,cantCreada,tiraje) {
               document.getElementById("<%= lblObjId.ClientID%>").innerHTML = objid;
               document.getElementById("<%= lblTiraje.ClientID%>").innerHTML = tiraje;
               document.getElementById("<%= lblOT.ClientID%>").innerHTML = ot;
               document.getElementById("<%= lblNombreOT.ClientID%>").innerHTML = nombreot;
               document.getElementById("<%= lblPliego.ClientID%>").innerHTML = pliego;
               document.getElementById("<%= txtCantidad.ClientID%>").disabled = false;
               document.getElementById("<%= lblCantGenerada.ClientID%>").innerHTML = cantCreada;
               document.getElementById("<%= txtPorGenerar.ClientID%>").value = tiraje - cantCreada;
               

     
               //alert(objid);
           }
           function CrearEtiqueta() {
             var objId = document.getElementById("ContentPlaceHolder1_lblObjId").innerHTML;
             var cantidad = eval(document.getElementById("<%= txtCantidad.ClientID%>").value);

            var Usuario = '<%= Session["Usuario"] %>';
             $.ajax({
                 url: "MetricsWip.aspx/CrearOrden",
                 type: "post",
                 dataType: "json",
                 contentType: "application/json;charset=utf-8",
                 data: "{'ObjId':'" + objId + "','Cantidad':'" + cantidad + "','Usuario':'" + Usuario + "'}",
                 success: function (msg) {
                     if (eval(msg.d[0]) > 0) {

                         window.open('_Etiqueta.aspx?id=' + msg.d[0], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                         document.getElementById("<%= txtCantidad.ClientID%>").value = '';
                         document.getElementById("<%= txtCantidad.ClientID%>").focus();
                         BuscarFiltro();
                         var tir = document.getElementById("<%= lblTiraje.ClientID%>").innerHTML;
                         var cantAntigua = document.getElementById("<%= lblCantGenerada.ClientID%>").innerHTML;
                         var cantidadGen = eval(cantAntigua) + eval(cantidad);
                         document.getElementById("<%= lblCantGenerada.ClientID%>").innerHTML = cantidadGen;
                         document.getElementById("<%= txtPorGenerar.ClientID%>").value = tir - cantidadGen;
                     }
                     else {
                         alert("¡Ha ocurrido un Error, vuelva a intentarlo!");
                     }
                 },
                 error: function () {
                     alert('¡Ha Ocurrido un Error!');
                 }
             });
            }
           function HistorialEtiquetas() {
               var OT = document.getElementById("<%= lblOT.ClientID%>").innerHTML;
               var Pliego = document.getElementById("<%= lblPliego.ClientID%>").innerHTML;
               var nOT=document.getElementById("<%= lblNombreOT.ClientID%>").innerHTML;
               if (document.getElementById("<%= lblPliego.ClientID%>").innerHTML != '') {
                   window.open('_HistorialEtiquetas.aspx?ot=' + OT + '&pl=' + Pliego + '&nOT=' + nOT, 'Historial Etiquetas', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
               } else {
                   alert('seleccione un pliego');
               }

              
           }

           
           $(document).ready(function () {
               $("#ContentPlaceHolder1_txtOT").change(function () {
                   CargaPliegosOT();
               });
               $('#btnBuscar').click(function (e) {
                   e.preventDefault();
                   BuscarFiltro();
               });
           });
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        
        <table style="background-color:#EEE;border:1px solid #999;margin-left:50px;padding:9px;margin-bottom:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
       
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Pliego:"></asp:Label>
                </td>
            <td>
                <asp:DropDownList ID="ddlPliego" runat="server" Width="168px">
                    <asp:ListItem>Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Maquina:"></asp:Label>
            </td>
                <td>
                    <asp:DropDownList ID="ddlMaquina" runat="server" Width="168px">
                        <asp:ListItem>KBA</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
               <div style="text-align:right;margin-top:-10px;">
                <%--<asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />--%>
                    </div>
                <button id="btnBuscar" >Buscar</button>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                    onclick="btnFiltrar_Click1" Visible="false" />
            </td>
        </tr>
        </table> 
    <br />
    <div style="width:1090px;height:150px;overflow:auto;">
        <asp:Label ID="lblTabla" runat="server"></asp:Label>
    </div>
    <br /> <br />
    <div class="divTitulo"> Crear Etiqueta <div style="display:inline;float:right;"><a href="javascript:HistorialEtiquetas();">Historial Etiquetas</a></div></div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr style="visibility:hidden;">
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" Text="ObjID:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblObjId" runat="server"></asp:Label>
                    <asp:Label ID="lblTiraje" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label8" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOT" runat="server"></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label9" runat="server" Text="Pliego:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPliego" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Cant. Generada:"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:Label ID="lblCantGenerada" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Cant. Por Generar: "></asp:Label>
                    <asp:TextBox ID="txtPorGenerar" runat="server" style="background-color: #ffff00;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style5">
                    <asp:Label ID="Label7" runat="server" Text="Cantidad:" Font-Bold="True"></asp:Label>
                </td>
                <td class="auto-style1">  <asp:TextBox ID="txtCantidad" runat="server" Enabled="False"></asp:TextBox>

                &nbsp;&nbsp;

                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>

        <%--<asp:Button ID="btnFiltro" runat="server" Text="Crear" OnClick="btnFiltro_Click" Width="80px" Enabled="False" />--%>
                    <input id="btnCrear" type="button" value="Crear" onclick="javascript: CrearEtiqueta();" style="width:80px;" />
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        </div>
     <br /> <br /> <br /> <br /> <br /> <br />
</asp:Content>
