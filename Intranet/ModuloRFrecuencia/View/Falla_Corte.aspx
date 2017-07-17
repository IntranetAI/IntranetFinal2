<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Falla_Corte.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Falla_Corte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(document).ready(function () {
            $("#DropDownList1").change(function () {
                var select = document.getElementById("<%= DropDownList1.ClientID %>");
                var answer = select.options[select.selectedIndex].value;
                CargarMotivo(answer);
            });
        });

        function CargarMotivo(TipoOrigen) {
            var ddlTerritory = document.getElementById("<%= DropDownList2.ClientID %>");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "Falla_Corte.aspx/Carga_Motivo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'TipoOrigen':'" + TipoOrigen + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $('#<%=DropDownList2.ClientID%>').append($("<option></option>").val(value.Lote).html(value.Lote));

                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function GuardarMotivoCorte() {
            var Usuario = document.getElementById("lblUsuario").innerHTML;
            var IDBobina = document.getElementById("lblIDBobina").innerHTML; 
            var select = document.getElementById("<%= DropDownList1.ClientID %>");
            var Origen = select.options[select.selectedIndex].value;
            var select1 = document.getElementById("<%= DropDownList2.ClientID %>");
            var Motivo = select1.options[select1.selectedIndex].value;
            $.ajax({
                url: "Falla_Corte.aspx/GuardarMotivo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Usuario':'" + Usuario + "','IDBobina':'" + IDBobina + "','Origen':'" + Origen + "','Motivo':'" + Motivo + "'}",
                success: function (data) {
                    if (data.d == "OK") {
                        document.getElementById("error").style.display = "none";
                        alert("Se a ingresado Correctamente.");
                        Cerrar();
                    }
                    else {
                        document.getElementById("error").style.display = "Block";
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function Cerrar() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Falla por Corte</h1>
    <table class="table">
            <tr>
                <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Origen del Corte</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" >
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Motivo</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" >
                        <asp:ListItem>Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
        </table>
        <div id="error" style="display:none;" class="alert alert-danger" role="alert"><strong>Error, </strong> Todos los Campos son Obligatorios</div>
        <div class="modal-footer">
            <button type="button" class="btn btn-primary" onclick="javascript:GuardarMotivoCorte();">
                Guardar Cambios</button>
            <button type="button" class="btn btn-default" onclick="javascript:Cerrar();">
                Cerrar</button>
        </div>
        <div style="display:none;" >
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblIDBobina" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
