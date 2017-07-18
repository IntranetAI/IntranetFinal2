<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="CrearPalletsMaquina.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.CrearPalletsMaquina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
    .style2
    {
        width: 223px;
    }
    .style3
    {
        width: 448px;
    }
    .style4
    {
        width: 439px;
    }
    .style6
    {
        width: 642px;
    }
    .style9
    {
        width: 95px;
    }
    .style10
    {
        width: 534px;
    }
    .style11
    {
    }
    .style12
    {
        width: 196px;
    }
    .style13
    {
        width: 132px;
    }
    .style14
    {
        width: 327px;
    }
    .style15
    {
        width: 210px;
    }
    #btnGuardar
    {
        width: 111px;
    }
</style>

<script type="text/javascript">
    function BuscarOT() {
        var OT = document.getElementById("<%= txtOT.ClientID%>").value;
        $.ajax({
            url: "CrearPalletsMaquina.aspx/BuscarOT",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "'}",
            success: function (msg) {
                if (msg.d[0] == '') {
                    alert('¡Ha Ocurrido un Error!');
                } else {
                    document.getElementById("ContentPlaceHolder1_lblOT").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[4];
                    document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML = msg.d[7];

                    document.getElementById("ContentPlaceHolder1_txtPliegos").focus();

                    document.getElementById("Registros").style.display = 'none';
                    document.getElementById("Registros2").style.display = 'none';
                }
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
        }

        function CrearPallet() {
            var OT = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var NombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
            var comp = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;
            var Papel = document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML;
            var ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
            var largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
            var gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
            var asignadoPliegos = document.getElementById("<%= txtPliegos.ClientID %>");
            var asignadoPeso = document.getElementById("<%= txtPeso.ClientID %>");
            $.ajax({
                url: "CrearPalletsMaquina.aspx/CrearPallet",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "','NombreOT':'" + NombreOT + "','Comp':'" + comp + "','Papel':'" + Papel +
                "','Ancho':'" + ancho + "','Largo':'" + largo + "','Gramaje':'" + gramaje + "','Cantidad':'" + asignadoPliegos +
                "','Peso':'" + asignadoPeso + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'OK') {
                        alert('¡Pallet Generado Correctamente!');
                    } else {
                        alert('¡Ha Ocurrido un Error!');

                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }


        $(document).ready(function () {
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
            $("#ContentPlaceHolder1_txtOT").keypress(function (e) {
                if (e.which == 13) {
                    BuscarOT();
                }
            });

            $("#ContentPlaceHolder1_txtOT").change(function () {
                BuscarOT();
            });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
  <table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 700px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                                  
            </td>
            <td class="style2">
               
                &nbsp;</td>
            <td class="style4">
                   <asp:Label ID="Label10" runat="server" Text="Codigo Solicitud:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        </table>
        <br />
    <div class="divTitulo">Datos de la Solicitud</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style13">
                    <asp:Label ID="Label11" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label12" runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style13">
                    <asp:Label ID="Label13" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblComponente" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style13">
                    <asp:Label ID="Label15" runat="server" Text="Papel Solicitado:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style11" colspan="3">
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style13">
                    <asp:Label ID="Label16" runat="server" Text="Gramaje:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblGramaje" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label20" runat="server" Text="Ancho:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblAncho" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label19" runat="server" Text="Largo: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblLargo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style13">
                    <asp:Label ID="Label21" runat="server" Text="Total Asignado:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="   Pliegos."></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
            <div class="divTitulo" id="Registros">Crear Pallets</div>
    <div class="divSeccion" id="Registros2">
    asdada</div>
        <div class="divTitulo">Crear Pallets</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label24" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label26" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <div align="center"><input id="btnGuardar" type="button" value="Crear Pallet" onclick="javascript:CrearPallet();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:Button ID="btnFiltro" runat="server" Text="Nueva Solicitud"  Width="144px" 
                    onclick="btnFiltro_Click1" />

               </div>
        </div>
</asp:Content>
