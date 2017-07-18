<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Etiqueta.aspx.cs" Inherits="Intranet.ModuloWip.View.Mantenedor_Etiqueta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .divTitulo
        {
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding: 5px;
            border: 1px solid #959595;
            text-align: left;
        }
        .divSeccion
        {
            padding: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            setTimeout(function () { ventimp.print(); }, 2000);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:700px;">
    <div class="divTitulo">Mantenedor Etiqueta</div>
    <div class="divSeccion">
        Bodega :&nbsp;&nbsp;
        <asp:DropDownList ID="ddlBodega" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="btnFiltro" runat="server" Text="Generar Etiqueta" onclick="btnFiltro_Click" />
    </div>
    </div>
    <div id="muestra" style="visibility:hidden;max-height:200px;overflow-y:scroll;">
        <asp:Label ID="lblImprimir" runat="server"></asp:Label>
    </div>
    <br /><br /><br /><br />
</asp:Content>
