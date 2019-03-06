<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TarifasTerrestre.aspx.cs" Inherits="Intranet.ModuloCotizadorTransporte.View.TarifasTerrestre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"/>
      
    
    
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            listUsers();
        });
        function listUsers() {
            var table = $("#table-users").DataTable({
                destroy: true,
                reponsive: false,
                ajax: {
                    method: "POST",
                    //url: "Inicio.aspx/getTerrestres",
                    url: "Inicio.aspx/getTerrestres",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: function (d) {
                        return JSON.stringify(d);
                    },
                    dataSrc: "d.data"
                },
                columns: [

                    { "data": "Ciudad" },
                    { "data": "De01a05" },
                    { "data": "De06a10" },
                    { "data": "De11a20" },
                    { "data": "De21a30" },
                    { "data": "De31a40" },
                    { "data": "De41a50" },
                    { "data": "De51a60" },
                    { "data": "De61a70" },
                    { "data": "De71a80" },
                    { "data": "De81a90" },
                    { "data": "De91a100" },
                    { "data": "De101a1000" },
                    { "data": "De1001a4000" },
                    { "data": "De4001a7000" },
                    { "data": "De7001aInfinito" },
                    { "data": "MT3" },
                    { "data": "Salidas" },
                    { "data": "Opciones" }
                ]
            });
        }
        function NuevoTerrestre() {
            $("#myModal1").modal("show");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:10px;"> 
                <div id="divMensaje"></div>
            <button type="button" class="btn btn-default" style="background-color:#009798;color:white;" onclick="NuevoTerrestre();">Nueva Tarifa Terrestre</button>
             <table id="table-users" class="display" style="width:100%;">
                 <thead>
                     <tr>
                         <th>Ciudad</th>
                         <th>01-05</th>
                         <th>06-10</th>
                         <th>12-20</th>
                         <th>21-30</th>
                         <th>31-40</th>
                         <th>41-50</th>
                         <th>51-60</th>
                         <th>61-70</th>
                         <th>71-80</th>
                         <th>81-90</th>
                         <th>91-100</th>
                         <th>101- 1000</th>
                         <th>1001- 4000</th>
                         <th>4001- 7000</th>
                         <th>7001+</th>
                         <th>Mt3</th>
                         <th>Salidas</th>
                         <th>Opciones</th>
                     </tr>
                 </thead>
            </table>
        </div>



<div class="modal fade" id="myModal1" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--header--%>
                <div class="modal-header">
                  <h4 class="modal-title">Nueva Tarifa Terrestre</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       <div class="row">
                           <div class="col-md-4"><b>Ciudad:</b></div>
                           <div class="col-md-8"><input id="txtCiudad" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>01-03 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe01a03" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>04-150 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe04a150" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>151-500 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe151a500" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito1" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito2" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito3" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito4" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito5" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito6" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito7" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito8" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito9" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito10" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito11" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito12" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito13" class="form-control"  type="number" /></div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="saveTarifa();">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>


            </div>
        </div>
      </div>
    </form>
</body>
</html>
