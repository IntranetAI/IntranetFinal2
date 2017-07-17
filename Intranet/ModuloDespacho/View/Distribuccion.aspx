<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Distribuccion.aspx.cs"
    Inherits="Intranet.ModuloDespacho.View.Distribuccion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <style>
.container {
    width: 100%;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <ul class="nav nav-tabs" style="width: 100%;">
            <li class="active"><a data-toggle="tab" href="#Formulario">Formulario</a></li>
            <li><a data-toggle="tab" href="#Archivo">Cargar Archivo</a></li>
        </ul>
        <div class="tab-content" style="width: 100%;">
            <div id="Formulario" class="tab-pane fade in active">
                <%-- <div class="panel-body">--%>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="txtOT">
                        OT:</label>
                    <div class="col-sm-2">
                        <input id="txtOT" class="form-control" type="text" disabled/>
                    </div>
                    <label class="control-label col-sm-2" for="txtNombreOT">
                        Nombre OT:</label>
                    <div class="col-sm-6">
                        <input id="txtNombreOT" class="form-control" type="text" disabled/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="txtRutCliente">
                        Rut Cliente:</label>
                    <div class="col-sm-2">
                        <input id="txtRutCliente" class="form-control" type="text" placeholder="Rut Cliente" />
                    </div>
                    <label class="control-label col-sm-2" for="txtRutCliente">
                        Dirección:</label>
                    <div class="col-sm-6">
                        <input id="Text1" class="form-control" type="text" placeholder="Sucursal o Dirección"/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlComuna">
                        Comuna:</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="control-label col-sm-2" for="txtCuidad">
                        Ciudad:</label>
                    <div class="col-sm-2">
                        <input id="txtCuidad" class="form-control" type="text" disabled/>
                    </div>
                    <label class="control-label col-sm-2" for="txtCuidad">
                        Pais:</label>
                    <div class="col-sm-2">
                        <input id="txtPais" class="form-control" type="text" disabled/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlEmbalaje">
                        Embalaje:</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlEmbalaje" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="control-label col-sm-2" for="txtAnchobanda">
                        Cant x Bulto:</label>
                    <div class="col-sm-2">
                        <input id="txtCantBulto" class="form-control" type="text" placeholder="Cant x Bulto" />
                    </div>
                    <label class="control-label col-sm-2" for="txtCantdeBultos">
                        Cant de  Bulto:</label>
                    <div class="col-sm-2">
                        <input id="txtCantdeBultos" class="form-control" type="text" placeholder="Cant de Bulto" />
                    </div>
                </div>
            </div>
            <div id="Archivo" class="tab-pane fade">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Cargar Archivo"  class="btn btn-primary" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
