<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Intranet.ModuloCotizadorTransporte.View.Inicio" %>

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
            //dtUsers();
            listUsers();
        });
        function abrirPopUp(id) {
            $("#myModalBodyDiv1").load(url, function () {
                $("#myModal1").modal("show");

            });

        }
        function dtUsers(){
            $.ajax({
                method: "POST",
                url: "Inicio.aspx/getUsers",
                contentType: "application/json; charset=utf-8",
                dataType:"json"
            }).done(function (info) {
                console.log(info);
            });
        }
        function listUsers() {
            var table = $("#table-users").DataTable({
                destroy: true,
                reponsive: false,
                ajax: {
                    method: "POST",
                    url: "Inicio.aspx/getUsers",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: function (d){
                        return JSON.stringify(d);
                    },
                    dataSrc: "d.data"
                },
                columns: [
                    { "data": "Numero" },
                    { "data": "Nombre" },
                    { "data": "OtroNum" }
                ]
            });
        }
        function alerta(num) {
                $("#myModal1").modal("show");


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px;"> 
     <table id="table-users" class="display" style="width:100%;">
         <thead>
             <tr>
                 <th>Id</th>
                 <th>Usuario</th>
                 <th>Password</th>
             </tr>
         </thead>
     </table>
            </div>


      <div class="modal fade" id="myModal1" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a href="#" class="close" data-dismiss="modal">&times;</a>
                    <h3 class="modal-title">Eliminar Presupuesto</h3>
                </div>
                <div class="modal-body" id="myModalBodyDiv1" >
                     <div class="modal-body">
                        <h3>Esta seguro que desea eliminarlo?</h3>
                        <div class="form-horizontal">
                            <p>ASasaS</p>
                        </div>
                     </div>
                    
                </div>
            </div>
        </div>
      </div>

    </form>
</body>
</html>
