<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantenedor_ValorTrimestral.aspx.cs"
    Inherits="Intranet.ModuloComercial.View.Mantenedor_ValorTrimestral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Valor Trimestral</title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script>
        function GuardarCambios() {
            document.getElementById("errorCampo").style.display = "none";
            document.getElementById("errorGeneral").style.display = "none";
            var Usuario = document.getElementById("lblUsuario").innerHTML;
            var NuevoQ = document.getElementById("ValorQ").value;

            var select1 = document.getElementById("<%= ddlMes.ClientID %>");
            var Mes = select1.options[select1.selectedIndex].text;

            if (NuevoQ != "") {
                $.ajax({
                    url: "Mantenedor_ValorTrimestral.aspx/GuardarCambios",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'Usuario':'" + Usuario + "','NuevoQ':'" + NuevoQ + "','Mes':'" + Mes + "'}",
                    success: function (data) {
                        if (data.d == "OK") {
                            Cerrar();
                        }
                        else {
                            document.getElementById("errorGeneral").style.display = "Block";
                        }
                    },
                    error: function () {
                        document.getElementById("errorGeneral").style.display = "Block";
                    }
                });
            }
            else {
                document.getElementById("errorCampo").style.display = "Block";
            }
        }

        function Cerrar() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 align="center">
            Valor Trimestral</h1>
        <div class="input-group">
            <span class="input-group-addon" id="basic-addon1">Nuevo Valor</span>
            <input id="ValorQ" type="text" class="form-control" placeholder="Valor Trimestral Q" aria-describedby="basic-addon1" />
        </div>
        <br />
        <div class="input-group">
            <span class="input-group-addon" id="Span1">Mes Termino</span>
            <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control" >
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>Enero</asp:ListItem>
                        <asp:ListItem>Febrero</asp:ListItem>
                        <asp:ListItem>Marzo</asp:ListItem>
                        <asp:ListItem>Abril</asp:ListItem>
                        <asp:ListItem>Mayo</asp:ListItem>
                        <asp:ListItem>Junio</asp:ListItem>
                        <asp:ListItem>Julio</asp:ListItem>
                        <asp:ListItem>Agosto</asp:ListItem>
                        <asp:ListItem>Septiembre</asp:ListItem>
                        <asp:ListItem>Octubre</asp:ListItem>
                        <asp:ListItem>Noviembre</asp:ListItem>
                        <asp:ListItem>Diciembre</asp:ListItem>
                    </asp:DropDownList>
        </div>
        <br />
        <div id="errorCampo" style="display: none;" class="alert alert-danger" role="alert">
            <strong>Error, </strong>Todos los Campos son Obligatorios</div>
        <div id="errorGeneral" style="display: none;" class="alert alert-danger" role="alert">
            <strong>Error, </strong>A ocurrido un error inesperado</div>
        <div class="modal-footer">
            <button type="button" class="btn btn-primary" onclick="javascript:GuardarCambios();">
                Guardar Cambios</button>
            <button type="button" class="btn btn-default" onclick="javascript:Cerrar();">
                Cerrar</button>
        </div>
        <div style="display: none;">
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
