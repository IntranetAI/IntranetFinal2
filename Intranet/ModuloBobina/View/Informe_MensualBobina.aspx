<%@ Page Title="" Language="C#" MasterPageFile="~/Estructura/View/MasterAplicaciones.Master"
    AutoEventWireup="true" CodeBehind="Informe_MensualBobina.aspx.cs" Inherits="Intranet.ModuloBobina.View.Informe_MensualBobina" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .filterable
        {
            margin-top: 15px;
        }
        .filterable .panel-heading .pull-right
        {
            margin-top: -20px;
        }
        .filterable .filters input[disabled]
        {
            background-color: transparent;
            border: none;
            cursor: auto;
            box-shadow: none;
            padding: 0;
            height: auto;
        }
        .filterable .filters input[disabled]::-webkit-input-placeholder
        {
            color: #333;
        }
        .filterable .filters input[disabled]::-moz-placeholder
        {
            color: #333;
        }
        .filterable .filters input[disabled]:-ms-input-placeholder
        {
            color: #333;
        }
        .container
        {
            width: 95%;
            height:800px;
        }
        .pre-scrollable {
            max-height: 746px;
            overflow-y: auto;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('.filterable .btn-filter').click(function () {
                var $panel = $(this).parents('.filterable'),
        $filters = $panel.find('.filters input'),
        $tbody = $panel.find('.table tbody');
                if ($filters.prop('disabled') == true) {
                    $filters.prop('disabled', false);
                    $filters.first().focus();
                } else {
                    $filters.val('').prop('disabled', true);
                    $tbody.find('.no-result').remove();
                    $tbody.find('tr').show();
                }
            });

            $('.filterable .filters input').keyup(function (e) {
                /* Ignore tab key */
                var code = e.keyCode || e.which;
                if (code == '9') return;
                /* Useful DOM data and selectors */
                var $input = $(this),
        inputContent = $input.val().toLowerCase(),
        $panel = $input.parents('.filterable'),
        column = $panel.find('.filters th').index($input.parents('th')),
        $table = $panel.find('.table'),
        $rows = $table.find('tbody tr');
                /* Dirtiest filter function ever ;) */
                var $filteredRows = $rows.filter(function () {
                    var value = $(this).find('td').eq(column).text().toLowerCase();
                    return value.indexOf(inputContent) === -1;
                });
                /* Clean previous no-result if exist */
                $table.find('tbody .no-result').remove();
                /* Show all rows, hide filtered ones (never do that outside of a demo ! xD) */
                $rows.show();
                $filteredRows.hide();
                /* Prepend no-result row if all rows are filtered */
                if ($filteredRows.length === $rows.length) {
                    $table.find('tbody').prepend($('<tr class="no-result text-center"><td colspan="' + $table.find('.filters th').length + '">No result found</td></tr>'));
                }
            });
        });
    </script>
    <script>
        function divPiePagina() {
        document.getElementById("lblFooter").style.position= "fixed";
        document.getElementById("lblFooter").style.marginTop = "710px";
        document.getElementById("lblFooter").style.marginleft = "30%";
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container">
        <div align="center">
            <table class="filterable" style="background-color: #EEE; border: 1px solid #999; padding: 5px; margin-bottom: 5px;
                border-radius: 10px 10px 10px 10px;" width="945px;">
                <tr>
                    <td style="width: 95px;">
                        <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha : "></asp:Label>
                    </td>
                    <td style="width: 134px;">
                        <asp:TextBox ID="txtFechaInicio" class="form-control" runat="server" Width="128px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        a
                    </td>
                    <td style="width: 134px;">
                        <asp:TextBox ID="txtFechaTermino" class="form-control" runat="server" Width="128px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaTermino"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td>    <asp:Label ID="Label1"  runat="server" Text="Turno:"></asp:Label></td>
                    <td>

    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
        <asp:ListItem Value="0">Todos</asp:ListItem>
        <asp:ListItem Value="1">1 - Dia</asp:ListItem>
        <asp:ListItem Value="2">2 - Tarde</asp:ListItem>
        <asp:ListItem Value="3">3 - Noche</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 200px;" colspan="2">
                        <div style="margin-left: 17px;">
                            <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                                Style="height: 26px" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divbotones" style="text-align: right; width: 100%; margin-bottom: -15px;
            margin-left: -10px;">
            <a title="Exportar a Excel">
                <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                    Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
        </div>
        <div class="row">
            <div class="panel panel-primary filterable pre-scrollable">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Informe Mensual Desperdicio Papel</h3>
                </div>
                <asp:Label ID="lblTabla" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <script type="text/javascript">
            $('#accordion ul:eq(8)').show();
        </script>
    </div>
</asp:Content>
