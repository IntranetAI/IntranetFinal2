<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EgresoEjemplares.aspx.cs" Inherits="Intranet.ModuloDespacho.View.EgresoEjemplares" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp"  %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/funciones.js" type="text/javascript"></script>
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
    width:92%;
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
    width:92%;
}
.divEtiqueta{
    display: inline-block;
    padding: 5px;
    font-weight: bold;
    text-align: left;
}
.divCampo{
    display: inline-block;
    text-align: left;
}
     .style2
     {
         width: 148px;
     }
     .style3
     {
         width: 342px;
     }
     .style5
     {
         width: 150px;
     }
     .style6
     {
         width: 123px;
     }
     .style7
     {
         width: 126px;
     }
    </style>

    <script  type="text/javascript" language="javascript">

        $(document).ready(function () {
            Deshabilitar();
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
            $("#ContentPlaceHolder1_txtCantidad").keypress(function (e) {
                if (e.which == 13) {

                }
            });
            $("#ContentPlaceHolder1_txtOT").keypress(function (e) {
                if (e.which == 13) {

                }
            });
            $("#ContentPlaceHolder1_txtOT").change(function () {
                var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                if (OT.length <= 4) {
                    alert('Debe ingresar una OT');
                } else {
                    BuscarOT();
                    BuscarExistencia();
                }
            });
            $("#ContentPlaceHolder1_ddlAreaEntrega").change(function () {
                var select3 = document.getElementById("<%= ddlAreaEntrega.ClientID %>");
                var Area = select3.options[select3.selectedIndex].text;

                if (Area != "Seleccione...") {
                    var ddlTerritory = document.getElementById("<%= ddlUsuario.ClientID %>");
                    var lengthddlTerritory = ddlTerritory.length - 1;
                    for (var i = lengthddlTerritory; i >= 0; i--) {
                        ddlTerritory.options[i] = null;
                    }
                    var ddlTerritory2 = document.getElementById("<%= ddlMotivo.ClientID %>");
                    var lengthddlTerritory2 = ddlTerritory2.length - 1;
                    for (var i = lengthddlTerritory2; i >= 0; i--) {
                        ddlTerritory2.options[i] = null;
                    }
                    CargarArea();
                    CargaMotivo();
                }
                else {
                }
            });

            function BuscarOT() {
                var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                $.ajax({
                    url: "EgresoEjemplares.aspx/BuscarOT",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'OT':'" + OT + "'}",
                    success: function (msg) {
                        document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[0];
                        document.getElementById("ContentPlaceHolder1_lblCliente").innerHTML = msg.d[1];

                        document.getElementById("<%= txtOT.ClientID%>").disabled = true;

                    },
                    error: function () {
                        alert('¡Error al cargar datos de la OT!');
                    }
                });
            }

            function CargarArea() {
                var select3 = document.getElementById("<%= ddlAreaEntrega.ClientID %>");
                var Area = select3.options[select3.selectedIndex].text;
                $.ajax({
                    url: "EgresoEjemplares.aspx/CargaArea",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'Area':'" + Area + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $('#<%=ddlUsuario.ClientID%>').append($("<option></option>").val(value.Cliente).html(value.Cliente));

                        });

                    },
                    error: function () {
                        alert('¡Ha Ocurrido un Error!');
                    }
                });
            }
            function CargaMotivo() {
                var select3 = document.getElementById("<%= ddlAreaEntrega.ClientID %>");
                var Area = select3.options[select3.selectedIndex].text;
                $.ajax({
                    url: "EgresoEjemplares.aspx/CargaMotivos",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'Area':'" + Area + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $('#<%=ddlMotivo.ClientID%>').append($("<option></option>").val(value.Cliente).html(value.Cliente));

                        });

                    },
                    error: function () {
                        alert('¡Ha Ocurrido un Error!');
                    }
                });
            }

        });
        function BuscarExistencia() {
                var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                $.ajax({
                    url: "EgresoEjemplares.aspx/BuscarExistencia",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'OT':'" + OT + "'}",
                    success: function (msg) {
                        document.getElementById("ContentPlaceHolder1_lblExistencia").innerHTML = msg.d[0];
                    },
                    error: function () {
                        alert('¡Error al cargar datos de la OT!');
                    }
                });
            }
        function CargaTipo(tipo, cantidad) {
            document.getElementById("ContentPlaceHolder1_lblTipo").innerHTML = tipo;
            document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML = cantidad;
            document.getElementById("<%= txtCantidad.ClientID%>").value = cantidad;

            habilitar();

        }
        function Deshabilitar() {
            document.getElementById("<%= txtCantidad.ClientID%>").disabled = true;
            document.getElementById("<%= txtObservacion.ClientID%>").disabled = true;
            document.getElementById("ContentPlaceHolder1_ddlMotivo").disabled = true;
            document.getElementById("ContentPlaceHolder1_ddlAreaEntrega").disabled = true;
            document.getElementById("ContentPlaceHolder1_ddlUsuario").disabled = true;
            document.getElementById("btnFinalizarSolicitud").disabled = true;
        }
        function habilitar() {
            document.getElementById("<%= txtCantidad.ClientID%>").disabled = false;
            document.getElementById("<%= txtObservacion.ClientID%>").disabled = false;
            document.getElementById("ContentPlaceHolder1_ddlAreaEntrega").disabled = false;
            document.getElementById("ContentPlaceHolder1_ddlUsuario").disabled = false;
            document.getElementById("btnFinalizarSolicitud").disabled = false;
            document.getElementById("ContentPlaceHolder1_ddlMotivo").disabled = false;
        }
       
        function NuevoEgreso() {
            location.href = 'egresoejemplares.aspx?id=8&Cat=6';
        }
         
        function ContinuarEgreso() {
            BuscarExistencia();
            Deshabilitar();
            document.getElementById("<%= ddlAreaEntrega.ClientID %>").selectedIndex=0;


            var ddlTerritory = document.getElementById("<%= ddlUsuario.ClientID %>");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            var ddlTerritory2 = document.getElementById("<%= ddlMotivo.ClientID %>");
            var lengthddlTerritory2 = ddlTerritory2.length - 1;
            for (var i = lengthddlTerritory2; i >= 0; i--) {
                ddlTerritory2.options[i] = null;
            }
            document.getElementById("<%= txtCantidad.ClientID%>").value = '0';
            document.getElementById("<%= txtObservacion.ClientID%>").value = '';

        }
         function CrearEgreso() {
                var select3 = document.getElementById("<%= ddlAreaEntrega.ClientID %>");
                var AreaEntrega = select3.options[select3.selectedIndex].text;

                var select1 = document.getElementById("<%= ddlUsuario.ClientID %>");
                var Usuario = select1.options[select1.selectedIndex].text;

                var select2 = document.getElementById("<%= ddlMotivo.ClientID %>");
                var Motivo = select2.options[select2.selectedIndex].text;

                var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                var NombreOT= document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
                var tipo = document.getElementById("ContentPlaceHolder1_lblTipo").innerHTML;
                var cantidad = document.getElementById("<%= txtCantidad.ClientID%>").value;
                var CantidadMaxima = document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML;
                var Observacion = document.getElementById("<%= txtObservacion.ClientID%>").value;

     
               $.ajax({
                    url: "EgresoEjemplares.aspx/CrearEgresoss",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'CantidadMaxima':'"+eval(CantidadMaxima)+"','OT':'" + OT + "','NombreOT':'"+NombreOT+"','Tipo':'"+tipo+"','Cantidad':'"+eval(cantidad)+"','AreaEntrega':'"+AreaEntrega+"','Usuario':'"+Usuario+"','Motivo':'"+Motivo+"','Observacion':'"+Observacion+"','CreadoPor':'<%=Session["Usuario"] %>'}",
                    success: function (msg) {
                    if(msg.d[0]=='OK'){
                        alert('¡Egreso de ejemplares creado correctamente!');
                       ContinuarEgreso();
                    }else if(msg.d[0]=='ERROR2'){
                        alert('¡Debe seleccionar todos los campos para hacer el ingreso!');
                         
                    }else if(msg.d[0]=='ERROR3'){
                        alert('¡La Cantidad no puede ser mayor a la seleccionada!');
                        }else{
                        alert('¡ha ocurrido un error, vuelva a intentarlo!');
                        }
                    },
                    error: function () {
                        alert('¡Error al cargar datos de la OT!');
                    }
                });



            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="divTitulo" >
                    Egreso Ejemplares</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="OT:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                       <fieldset>
                       <legend>Existencia</legend>
                      <div align="center">
                           <asp:Label ID="lblExistencia" runat="server"></asp:Label></div>
  </fieldset>
    </div>


                            <div class="divTitulo">
                    Salida Ejemplares</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Cantidad:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Descontar a: "></asp:Label>
                    <asp:Label ID="lblTipo" runat="server"></asp:Label>
                    <asp:Label ID="lblCantidad" runat="server" style="display:none;"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Area a Entregar:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="ddlAreaEntrega" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>CSR</asp:ListItem>
                        <asp:ListItem>Vendedores</asp:ListItem>
                        <asp:ListItem>Bodega de Rezago</asp:ListItem>
                        <asp:ListItem>Facturacion</asp:ListItem>
                        <asp:ListItem>Biblioteca</asp:ListItem>
                        <asp:ListItem>Despacho</asp:ListItem>
                        <asp:ListItem>Bodega Materias Primas</asp:ListItem>
                        <asp:ListItem>Encuadernacion</asp:ListItem>
                        <asp:ListItem>Control de Calidad</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Usuario:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="ddlUsuario" runat="server" Width="173px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Motivo:"></asp:Label>
                </td>
                <td>  &nbsp;
                    <asp:DropDownList ID="ddlMotivo" runat="server" Width="173px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Observación:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtObservacion" runat="server" Height="122px" TextMode="MultiLine" 
                        Width="448px" Wrap="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </div>
   <div align="center" style="width: 1179px">
   <br />
       <input id="btnFinalizarSolicitud" onclick="javascript:CrearEgreso();" type="button" 
                        value="Finalizar Egreso" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnNuevo" onclick="javascript:NuevoEgreso();" type="button" 
                        value="Nuevo Egreso" />
                        <br />
       </div>
</asp:Content>
