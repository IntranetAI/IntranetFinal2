<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Ingreso_Partes.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Ingreso_Partes" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/funciones.js" type="text/javascript"></script>
    <script src="http://localhost:11487/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtCodigo").change(function () {
                BuscaCodigo();
            });
            $("#ContentPlaceHolder1_txtOT").change(function () {
                BuscaOT();
            });
            $("#ContentPlaceHolder1_txtHora").change(function () {
                if (eval(document.getElementById("<%= txtHora.ClientID%>").value) > 23) {
                    document.getElementById("<%= txtHora.ClientID%>").value = '';
                    document.getElementById("<%= txtHora.ClientID%>").focus();
                }
            });
            $("#ContentPlaceHolder1_txtMinuto").change(function () {
                if (eval(document.getElementById("<%= txtMinuto.ClientID%>").value) > 59) {
                    document.getElementById("<%= txtMinuto.ClientID%>").value = '';
                    document.getElementById("<%= txtMinuto.ClientID%>").focus();
                }
            });
            $("#ContentPlaceHolder1_txtFechaParte").change(function () {
                var dateFields = document.getElementById("<%= txtFechaParte.ClientID%>").value.split('/');
                var fecha = new Date(dateFields[1] + '/' + dateFields[0] + '/' + dateFields[2]);
                var dia = fecha.getDay();
                if (fecha.getDay() == '1') {
                    if (document.getElementById("ContentPlaceHolder1_rdTurno").checked == true) {
                        document.getElementById("<%= txtHora.ClientID%>").value = '09';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    } else if (document.getElementById("ContentPlaceHolder1_rdTurno2").checked == true) {
                        document.getElementById("<%= txtHora.ClientID%>").value = '14';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    } else {
                        document.getElementById("<%= txtHora.ClientID%>").value = '19';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    }
                } else {
                    if (document.getElementById("ContentPlaceHolder1_rdTurno").checked == true) {
                        document.getElementById("<%= txtHora.ClientID%>").value = '00';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    } else if (document.getElementById("ContentPlaceHolder1_rdTurno2").checked == true) {
                        document.getElementById("<%= txtHora.ClientID%>").value = '08';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    } else {
                        document.getElementById("<%= txtHora.ClientID%>").value = '16';
                        document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                    }
                }
            });

            $("#ContentPlaceHolder1_ddlMaquina").change(function () {
                var select = document.getElementById("ContentPlaceHolder1_ddlMaquina");
                var Maquina = select.options[select.selectedIndex].text;

                if (Maquina == 'Goss' || Maquina == 'Lithoman') {
                    document.getElementById("ContentPlaceHolder1_lblFactor").style.display = 'inline';
                    document.getElementById("ContentPlaceHolder1_txtFactor").style.display = 'inline';
                } else {
                    document.getElementById("ContentPlaceHolder1_lblFactor").style.display = 'none';
                    document.getElementById("ContentPlaceHolder1_txtFactor").style.display = 'none';
                }
            });
            $("#ContentPlaceHolder1_rdTurno").change(function () {
                if (document.getElementById("ContentPlaceHolder1_rdTurno").checked == true) {
                    if (document.getElementById("<%= txtFechaParte.ClientID%>").value == '') {
                        alert('Seleccione la Fecha del Parte');
                    } else {
                        var dateFields = document.getElementById("<%= txtFechaParte.ClientID%>").value.split('/');
                        var fecha = new Date(dateFields[1] + '/' + dateFields[0] + '/' + dateFields[2]);
                        var dia = fecha.getDay();
                        if (fecha.getDay() == '1') {
                            document.getElementById("<%= txtHora.ClientID%>").value = '09';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        } else {
                            document.getElementById("<%= txtHora.ClientID%>").value = '00';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        }
                    }
                }
            });
            $("#ContentPlaceHolder1_rdTurno2").change(function () {
                if (document.getElementById("ContentPlaceHolder1_rdTurno2").checked == true) {
                    if (document.getElementById("<%= txtFechaParte.ClientID%>").value == '') {
                        alert('Seleccione la Fecha del Parte');
                    } else {
                        var dateFields = document.getElementById("<%= txtFechaParte.ClientID%>").value.split('/');
                        var fecha = new Date(dateFields[1] + '/' + dateFields[0] + '/' + dateFields[2]);
                        var dia = fecha.getDay();
                        if (fecha.getDay() == '1') {
                            document.getElementById("<%= txtHora.ClientID%>").value = '14';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        } else {
                            document.getElementById("<%= txtHora.ClientID%>").value = '08';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        }
                    }
                }
            });
            $("#ContentPlaceHolder1_rdTurno3").change(function () {
                if (document.getElementById("ContentPlaceHolder1_rdTurno3").checked == true) {
                    if (document.getElementById("<%= txtFechaParte.ClientID%>").value == '') {
                        alert('Seleccione la Fecha del Parte');
                    } else {
                        var dateFields = document.getElementById("<%= txtFechaParte.ClientID%>").value.split('/');
                        var fecha = new Date(dateFields[1] + '/' + dateFields[0] + '/' + dateFields[2]);
                        var dia = fecha.getDay();
                        if (fecha.getDay() == '1') {
                            document.getElementById("<%= txtHora.ClientID%>").value = '19';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        } else {
                            document.getElementById("<%= txtHora.ClientID%>").value = '16';
                            document.getElementById("<%= txtMinuto.ClientID%>").value = '00';
                        }
                    }
                }
            });

        });
        function BuscaCodigo() {
            var codi = document.getElementById("<%= txtCodigo.ClientID%>").value;
            $.ajax({
                url: "Ingreso_Partes.aspx/BuscaCodigo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Codigo':'" + codi + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Codigo Incorrecto') {
                        document.getElementById("<%= txtCodigo.ClientID%>").value = '';
                        document.getElementById("<%= txtCodigo.ClientID%>").focus();
                        document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[0];
                    } else {
                        document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[0];
                        document.getElementById("ContentPlaceHolder1_lblIngresaCantidad").innerHTML = msg.d[1];
                        if (msg.d[1] == 'NO') {
                            document.getElementById("ContentPlaceHolder1_lblBuenos").style.display = 'none';
                            document.getElementById("ContentPlaceHolder1_txtBuenos").style.display = 'none';
                            document.getElementById("ContentPlaceHolder1_lblMalos").style.display = 'none'; 
                            document.getElementById("ContentPlaceHolder1_txtMalos").style.display = 'none';
                        } else {
                            document.getElementById("ContentPlaceHolder1_lblBuenos").style.display = 'inline';
                            document.getElementById("ContentPlaceHolder1_txtBuenos").style.display = 'inline';
                            document.getElementById("ContentPlaceHolder1_lblMalos").style.display = 'inline';
                            document.getElementById("ContentPlaceHolder1_txtMalos").style.display = 'inline';
                        }
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }
        function IngresarParte() {
            var select2 = document.getElementById("ContentPlaceHolder1_ddlMaquina");
            var Maquina = select2.options[select2.selectedIndex].value;
            var FechaParte = document.getElementById("<%= txtFechaParte.ClientID%>").value;
            var Turno = '';
            if (document.getElementById("ContentPlaceHolder1_rdTurno").checked == true) {
                Turno = '1';
            } else if (document.getElementById("ContentPlaceHolder1_rdTurno2").checked == true) {
                Turno = '2';
        } else {
                Turno = '3';
            }
            var Codigo = document.getElementById("<%= txtCodigo.ClientID%>").value;
            var OT = document.getElementById("<%= txtOT.ClientID%>").value;
            var NomOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
            var select3 = document.getElementById("ContentPlaceHolder1_ddlPliego");
            var Pliego = select3.options[select3.selectedIndex].value;
            var Hora = document.getElementById("<%= txtHora.ClientID%>").value;
            var Min = document.getElementById("<%= txtMinuto.ClientID%>").value;
            var Buenos = document.getElementById("<%= txtBuenos.ClientID%>").value;
            var Malos = document.getElementById("<%= txtMalos.ClientID%>").value;
            var Factor = document.getElementById("<%= txtFactor.ClientID%>").value;
            var IngCantidad = document.getElementById("ContentPlaceHolder1_lblIngresaCantidad").innerHTML;
            var Usuario = document.getElementById("ContentPlaceHolder1_lblUsuario").innerHTML;
            $.ajax({
                url: "Ingreso_Partes.aspx/IngresarParte",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Maquina':'" + Maquina + "','FechaParte':'" + FechaParte + "','Turno':'" + Turno + "','Codigo':'" + Codigo + "','OT':'" + OT + "','NombreOT':'" + NomOT + "','Pliego':'" + Pliego + "','Hora':'" + Hora + "','Minutos':'" + Min + "','Buenos':'" + Buenos + "','Malos':'" + Malos + "','IngresaCantidad':'" + IngCantidad + "','Factor':'"+Factor+"','Usuario':'" + Usuario + "'}",
                success: function (msg) {
                    alert(msg.d[0]);
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }
        function BuscaPliegos(ot) {
            var ddlTerritory = document.getElementById("<%= ddlPliego.ClientID%>");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "Ingreso_Partes.aspx/CargaPliego",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + ot + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ContentPlaceHolder1_ddlPliego").append($("<option></option>").val(value.Pliego).html(value.Pliego));
                    });
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });

        }
        function BuscaOT() {
            var oti = document.getElementById("<%= txtOT.ClientID%>").value;
            $.ajax({
                url: "Ingreso_Partes.aspx/BuscaOT",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + oti + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'OT Incorrecta') {
                        document.getElementById("<%= txtOT.ClientID%>").value = '';
                        document.getElementById("<%= txtOT.ClientID%>").focus();
                        document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[0];
                    } else {
                        document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[0];
                        BuscaPliegos(oti);
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }

        function Modificar(id) {
            window.location = "IngresoPartes.aspx?id=1&idP=" + id + "&r=modificar";
        }
        function Eliminar(id) {
            window.location = "IngresoPartes.aspx?id=1&idP=" + id + "&r=eliminar";
        }
        function VerHistorial() {
            window.open('HistorialPartesManuales.aspx', 'Historial Ingresos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
    <style type="text/css">
        .style1
        {
            width: 87px;
        }
        .style2
        {
            width: 99px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="right">
                    <input id="Button3" type="button" value="Nueva Solicitud" onclick="javascript:VerHistorial();" style="width:182px;" /><br />
    </div>
    <table style="width:100%;table-layout:fixed;width: 100%;">
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Maquina:"></asp:Label>
                            </td>
                            <td>
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="150px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="C150">Goss</asp:ListItem>
                    <asp:ListItem Value="M2016">Web 2</asp:ListItem>
                    <asp:ListItem>Lithoman</asp:ListItem>
                    <asp:ListItem>KBA</asp:ListItem>
                </asp:DropDownList>
                                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                </td>
                            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="FechaParte:"></asp:Label>
                            </td>
                            <td class="style8">
                <asp:TextBox ID="txtFechaParte" runat="server" Width="150px"></asp:TextBox>
   <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaParte"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Turno:"></asp:Label>
                            </td>
                            <td>
                <asp:RadioButton ID="rdTurno" runat="server" Checked="True" Text="1" 
                    GroupName="turnos" />
                                <asp:RadioButton ID="rdTurno2" runat="server" Text="2" 
                    GroupName="turnos" />
                                <asp:RadioButton ID="rdTurno3" runat="server" Text="3" GroupName="turnos" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                <asp:Label ID="Label10" runat="server" Text="Codigo:"></asp:Label>
                            </td>
                            <td>
                <asp:TextBox ID="txtCodigo" runat="server" Width="140px" MaxLength="4"></asp:TextBox>
                &nbsp;<asp:Label ID="lblCodigo" runat="server" Font-Bold="False"></asp:Label>
                            &nbsp;<asp:Label ID="lblIngresaCantidad" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                <asp:Label ID="Label11" runat="server" Text="OT:"></asp:Label>
                            </td>
                            <td>
                <asp:TextBox ID="txtOT" runat="server" Width="140px"></asp:TextBox>
                            &nbsp;<asp:Label ID="lblNombreOT" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                <asp:Label ID="Label12" runat="server" Text="Pliego:"></asp:Label>
                            </td>
                            <td>
                <asp:DropDownList ID="ddlPliego" runat="server" Width="143px"></asp:DropDownList>
                            &nbsp;<asp:Label ID="lblFactor" runat="server" Text="Factor:"  ></asp:Label>
                <asp:TextBox ID="txtFactor" runat="server" MaxLength="2" Width="55px"  ></asp:TextBox>                 
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Hora Inicio:"></asp:Label>
                            </td>
                            <td>
                <asp:TextBox ID="txtHora" runat="server" Width="25px" MaxLength="2"></asp:TextBox>
                                &nbsp;<asp:Label ID="Label13" runat="server" Text=":"></asp:Label>
                &nbsp;<asp:TextBox ID="txtMinuto" runat="server" Width="25px" MaxLength="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                <asp:Label ID="lblBuenos" runat="server" Text="Buenos:"></asp:Label>
                            </td>
                            <td>
                <asp:TextBox ID="txtBuenos" runat="server" MaxLength="7" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                <asp:Label ID="lblMalos" runat="server" Text="Malos:"></asp:Label>
                            </td>
                            <td>
                <asp:TextBox ID="txtMalos" runat="server" MaxLength="7" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                 <button type="button"  onclick="javascript:IngresarParte();" value="Guardar" id="Button1">Guardar</button>&nbsp;</td>
                            <td class="style2">
                                &nbsp;</td>
                            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Guardar" 
                    onclick="btnFiltro_Click" />
                <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                    Text="Modificar" Visible="False" />
                            </td>
                        </tr>
                    </table>
     <div id="divGrilla" 
        style="height:300px;width:930px;overflow:auto;">
    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" SortExpression="Maquina" UniqueName="Maquina">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaParte" HeaderText="FechaParte" SortExpression="FechaParte" UniqueName="FechaParte">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Turno" HeaderText="Turno" SortExpression="Turno" UniqueName="Turno">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" UniqueName="Codigo">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" UniqueName="OT">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" SortExpression="NombreOT" UniqueName="NombreOT">
                        </telerik:GridBoundColumn>
                                                
                        <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" SortExpression="Pliego" UniqueName="Pliego">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" SortExpression="Buenos" UniqueName="Buenos">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Malos" HeaderText="Malos" SortExpression="Malos" UniqueName="Malos">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" SortExpression="FechaInicio" UniqueName="FechaInicio">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" SortExpression="FechaTermino" UniqueName="FechaTermino">
                        </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="VerMas" HeaderText=" " SortExpression="VerMas" UniqueName="VerMas">
                        </telerik:GridBoundColumn>


                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Parte" 
            onclick="btnFinalizar_Click" />
    
    </div>
</asp:Content>
