<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculoFlete.aspx.cs" Inherits="Intranet.ModuloCotizadorTransporte.View.CalculoFlete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
        <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"/>
    <style >
        fieldset legend{
    display: block;
    width: auto;
    padding: 3px 10px;
    margin-bottom: 0;
    font-size: 15px;
    line-height: inherit;
    color: #333;
    border: 1px solid #ddd;
    background-color: #ffffff;
}
        fieldset {
    padding: 10px 25px;
    margin: 15px 0px;
    border: 1px solid #dddddd;
    background-color: #fafafa;
}
    </style>
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            //listUsers();
            $("#lblJson").hide();
            $("#ddlDestino").change(function () {
                CalculaFlete();
            });
            $("#ddlVia").change(function () {
                CalculaFlete();
            });
            $("#txtPesoUN").change(function () {
                CalculaFlete();
            });
            $("#txtCantidad").change(function () {
                CalculaFlete();
            });
        });
        function CalculaFlete() {
            var IdDestino = $("#ddlDestino option:selected").val();
            var Destino = $("#ddlDestino option:selected").text();
            var Via = $("#ddlVia option:selected").val();
            var PesoUn = document.getElementById("txtPesoUN").value == '' ? '0' : document.getElementById("txtPesoUN").value;
            var Cantidad = document.getElementById("txtCantidad").value == '' ? '0' : document.getElementById("txtCantidad").value;
            $.ajax({
                url: "CalculoFlete.aspx/CalcularFlete",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IdDestino':'" + eval(IdDestino) + "','Destino':'"+Destino+"','Via':'" + Via + "','PesoUN':'" + eval(PesoUn) + "','Cantidad':'" + eval(Cantidad) + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        $("#lblMensaje").text(msg.d[1]);
                        $('#btnAgregar').attr("disabled", true);
                        //$('#divMensaje').removeClass("alert alert-success col-xs-12");
                        //$('#divMensaje').addClass("alert alert-danger col-xs-12");
                        //$('#divMensaje').show();
                        //$('#divMensaje').html('<b>Error!</b> ' + msg.d[1]);
                        //$('#divMensaje').delay(6000).hide(500);
                    } else {
                        $('#btnAgregar').attr("disabled", false);
                        $("#lblKGTotales").text(msg.d[1]);
                        $("#lblRamal").text(msg.d[2]);
                        $("#lblCostoTotal").text(msg.d[3]);
                        $("#lblSalida").text(msg.d[4]);

                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function addFlete() {
            var destino = $("#ddlDestino option:selected").text();
            var via = $("#ddlVia option:selected").text();
            var PesoUN = document.getElementById("txtPesoUN").value;
            var cantidad = document.getElementById("txtCantidad").value;
            var KilosTotales = document.getElementById('lblKGTotales').innerHTML;
            var Ramal =  document.getElementById('lblRamal').innerHTML;
            var costo =  document.getElementById('lblCostoTotal').innerHTML;
            var Salidas = document.getElementById('lblSalida').innerHTML;
            var lbJson = document.getElementById('lblJson').innerHTML;
            $.ajax({
                url: "CalculoFlete.aspx/addFletes",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Destino':'" + destino + "','Via':'" + via + "','PesoUN':'" + eval(PesoUN) + "','Cantidad':'" + eval(cantidad) + "','KilosTotales':"+eval(KilosTotales)+",'Ramal':'"+Ramal+"','Costo':'"+eval(costo)+"','Salidas':'"+Salidas+"','lblJson':'"+lbJson+"'}",
                success: function (msg) {
                    document.getElementById('lblJson').innerHTML = msg.d[0];
                    document.getElementById('lblTotalFletes').innerHTML = msg.d[1];
                    document.getElementById('lblTotal').innerHTML = msg.d[1];
                    $("#tbl-Fletes").dataTable({
                        destroy:true,
                        "searching": false,
                        "paging": false,
                        "info": false,
                        "aaData": JSON.parse(msg.d[0]),
                        "aoColumns": [
                                    { "mData": "Destino" },
                                    { "mData": "Via" },
                                    { "mData": "PesoUN" },
                                    { "mData": "Cantidad" },
                                    { "mData": "KilosTotales" },
                                    { "mData": "Ramal" },
                                    { "mData": "Costo" },
                                    { "mData": "Salidas" }
                        ]
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('An error occurred... Look at the console (F12 or Ctrl+Shift+I, Console tab) for more information!');

                    $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
                    console.log('jqXHR:');
                    console.log(jqXHR);
                    console.log('textStatus:');
                    console.log(textStatus);
                    console.log('errorThrown:');
                    console.log(errorThrown);
                }
            });



        }
        function Guardar() {
            $("#myModal1").modal("show");
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">

<%--<nav class="navbar navbar-expand-sm  ">
  <!-- Brand -->
  <a class="navbar-brand" href="#">Logo</a>

  <!-- Links -->
  <ul class="navbar-nav">
    <li class="nav-item">
      <a class="nav-link" href="#">Link 1</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="#">Link 2</a>
    </li>

    <!-- Dropdown -->
    <li class="nav-item dropdown">
      <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
        Dropdown link
      </a>
      <div class="dropdown-menu">
        <a class="dropdown-item" href="#">Link 1</a>
        <a class="dropdown-item" href="#">Link 2</a>
        <a class="dropdown-item" href="#">Link 3</a>
      </div>
    </li>
  </ul>
</nav>--%>



        <div style="padding:50px;">
            <div class="form-horizontal">
               <fieldset>
                    <legend>Calculo Peso Ejemplar</legend>
                    <div class="form-group">
                       <table id="tbl-PesoEjemplar" class="table table-bordered">
                           <tbody>
                               <tr>
                                   <th>Concepto</th>
                                   <th>N° Paginas</th>
                                   <th>Ancho</th>
                                   <th>Largo</th>
                                   <th>Peso Papel</th>
                                   <th>Unitario</th>
                                   <th>Total</th>
                                   <th></th>
                               </tr>
                           </tbody>
                           <tbody>
                               <tr>
                                   <td><select id="ddlConcepto" class="form-control">
                                            <option value="1">Interior</option>
                                            <option value="2">Tapa</option>
                                            <option value="3">Guardas</option>
                                            <option value="4">Sobrecubierta</option>
                                            <option value="5">Desplegable</option>
                                            <option value="6">Inserto</option>
                                        </select></td>
                                   <td><input id="txtPaginas" class="form-control"  type="number" /></td>
                                   <td><input id="txtAncho" class="form-control"  type="number" /></td>
                                   <td><input id="txtAlto" class="form-control"  type="number" /></td>
                                   <td><input id="txtPesoPapel" class="form-control"  type="number" /></td>
                                   <td>UN</td>
                                   <td>Total</td>
                                   <td>Agregar</td>
                               </tr>
                           </tbody>
                        </table>
                    </div>

                </fieldset>
            </div>

            <%-- INICIO FLETE --%>
            <div class="form-horizontal">
               <fieldset>
                    <legend>Calculo Flete</legend>
                    <div class="form-group">
                       <table id="tbl-FletesInsert" class="table table-bordered">
                           <thead>
                               <tr>
                                   <th>Destino</th>
                                   <th>Via</th>
                                   <th>Peso UN</th>
                                   <th>Cantidad</th>
                                   <th>Kilos Totales</th>
                                   <th>Ramal</th>
                                   <th>Costo</th>
                                   <th>Salidas</th>
                                   <th></th>
                               </tr>
                           </thead>
                           <tbody>
                               <tr>
                                   <td>
                                       <asp:DropDownList ID="ddlDestino" CssClass="form-control" runat="server"></asp:DropDownList>
                                   </td>
                                   <td><select id="ddlVia" class="form-control">
                                            <option value="Aereo">Aereo</option>
                                            <option value="Terrestre">Terrestre</option>
                                        </select>
                                   </td>
                                   <td><input id="txtPesoUN" class="form-control"  type="number"  value="0"/></td>
                                   <td><input id="txtCantidad" class="form-control"  type="number" value="0" /></td>
                                   <td><asp:Label ID="lblKGTotales" runat="server" Text="0"></asp:Label></td>
                                   <td><asp:Label ID="lblRamal" runat="server" Text="0"></asp:Label></td>
                                   <td><asp:Label ID="lblCostoTotal" runat="server" Text="0"></asp:Label></td>
                                   <td><asp:Label ID="lblSalida" runat="server" Text="-"></asp:Label></td>
                                   <td><button id="btnAgregar" type="button" class="btn btn-success" data-dismiss="modal" onclick="addFlete();">Agregar</button></td>
                               </tr>
                           </tbody>
                       </table>

                    </div>
                   <div class="form-group">
                       <table id="tbl-Fletes" class="table table-bordered">
                           <thead>
                               <tr>
                                   <th>Destino</th>
                                   <th>Via</th>
                                   <th>Peso UN</th>
                                   <th>Cantidad</th>
                                   <th>Kilos Totales</th>
                                   <th>Ramal</th>
                                   <th>Costo</th>
                                   <th>Salidas</th>
                               </tr>
                           </thead>
                       </table>
                       <table id="tbl-Totales" class="table" style="width:50%">
                           <tbody>
                               <tr>
                                   <td>Total</td>
                                   <td><asp:Label ID="lblTotalFletes" runat="server" Text=""></asp:Label></td>
                                   <td><button id="btnGuardar" type="button" class="btn btn-success" data-dismiss="modal" onclick="Guardar();">Guardar</button></td>
                               </tr>
                           </tbody>
                       </table>
                   </div>

                </fieldset>
            </div>
            
            <asp:Label ID="lblJson" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>

        </div>

          <%--MODAL GUARDAR FLETES--%>
      <div class="modal fade" id="myModal1" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--header--%>
                <div class="modal-header">
                  <h4 class="modal-title">Guardar Flete</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                   <div class="form-horizontal">
                       <div class="row">
                         <div class="col-md-12">
                               <p>Ingrese el numero de Cotización</p>
                         </div>
                       </div>
                       <div class="row">
                         <div class="col-md-4">
                             <p><b>Costo Total: </b></p>
                         </div>
                         <div class="col-md-8">
                               <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                         </div>
                       </div>


                       <div class="row">
                         <div class="col-md-4">,
                             <p><b>N° Cotización: </b></p>
                         </div>
                         <div class="col-md-8">
                               <input id="txtCotizacion" class="form-control"  type="number" />
                         </div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="GuardarFlete();">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>
            </div>
        </div>
      </div>

 

    </form>
</body>
</html>
