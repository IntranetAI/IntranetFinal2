<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeProgramacionProduccion.aspx.cs" Inherits="Intranet.ModuloProduccion.InformeProgramacionProduccion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 125px;
        }
    </style>
    <script>
        function openGame(OT, NombreOT) {
            window.open('DetallePapel.aspx?ot=' + OT, 'Detalle OT', 'left=80,top=100,width=1120 ,height=500,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
    <script>
        function openProgramaProd() {
            var select = document.getElementById("<%=ddlSeccion.ClientID %>");
            var Seccion = select.options[select.selectedIndex].text;
            var Maquinas = "";
            if (Seccion != "Todas") {
                var select2 = document.getElementById("<%=ddlMaquinas.ClientID%>");
                Maquinas = select2.options[select2.selectedIndex].text;
            }
            var FechaInicio = document.getElementById("ContentPlaceHolder1_txtFechaInicio").value;
            var FechaTermino = document.getElementById("ContentPlaceHolder1_txtFechaTermino").value;
            window.open('ImprimirPrograma.aspx?Sec=' + Seccion + "&Maquinas=" + Maquinas + "&Fci=" + FechaInicio + "&Fct=" + FechaTermino + "&strid=" + 1, 'Detalle OT', 'left=80,top=100,width=1120 ,height=700,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
        function openProgramaEnc() {
            var select = document.getElementById("<%=ddlSeccion.ClientID %>");
            var Seccion = select.options[select.selectedIndex].text;
            var Maquinas = "";
            if (Seccion != "Todas") {
                var select2 = document.getElementById("<%=ddlMaquinas.ClientID%>");
                Maquinas = select2.options[select2.selectedIndex].text;
            }
            var FechaInicio = document.getElementById("ContentPlaceHolder1_txtFechaInicio").value;
            var FechaTermino = document.getElementById("ContentPlaceHolder1_txtFechaTermino").value;
            window.open('ImprimirPrograma.aspx?Sec=' + Seccion + "&Maquinas=" + Maquinas + "&Fci=" + FechaInicio + "&Fct=" + FechaTermino + "&strid="+2, 'Detalle OT', 'left=80,top=100,width=1120 ,height=700,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
       }
</script>
<%--    <script>
        $(function () {
            $('#ContentPlaceHolder1_ddlSeccion').change(function () {
                var value = $(this).val();
                var ddlTerritory = document.getElementById("<%= ddlMaquinas.ClientID %>");
                var lengthddlTerritory = ddlTerritory.length - 1;
                for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                }
                $.ajax({
                    url: "InformeProgramacionProduccion.aspx/CargaMaquina",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'Valor':'" + value + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $('#<%=ddlMaquinas.ClientID%>').append($("<option></option>").val(value.ID).html(value.Name));
                        });
                    },
                    error: function () {
                        alert('no funca');
                    }
                });
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="right" style="width: 930px">

&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbImprimir" runat="server" 
        OnClientClick="javascript:openProgramaProd();">Programa Prod</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
        OnClientClick="javascript:openProgramaEnc();">Programa Enc</asp:LinkButton>
&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Visible="False" />
    <asp:LinkButton ID="lbImprimirReporte" runat="server" Visible="False">Imprimir Reporte</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkPDF" runat="server" onclick="LinkPDF_Click" 
        Visible="False">Exportar a PDF</asp:LinkButton>
&nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/pdf-icon.jpg" 
        Width="20px" Visible="False" />
        </div>
<table style="background-color:#EEE;border:1px solid #999;margin-left:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style1">
               &nbsp;&nbsp;
                   <asp:Label ID="Label5" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Tipo Informe:"></asp:Label>
               </td>
            <td>
                <asp:DropDownList ID="ddlTipoInforme" runat="server" Width="173px">
                    <asp:ListItem>General</asp:ListItem>
                    <asp:ListItem>Resumido</asp:ListItem>
                    <asp:ListItem>Detallado</asp:ListItem>
                </asp:DropDownList>
               </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
               <td class="style1">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Sección:"></asp:Label>
               
            </td>
            <td>
               
                <asp:DropDownList ID="ddlSeccion" runat="server" Width="173px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlSeccion_SelectedIndexChanged">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Rotativa</asp:ListItem>
                    <asp:ListItem>Planas</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Maquinas:"></asp:Label>
               </td>
            <td>
                <asp:DropDownList ID="ddlMaquinas" runat="server" Width="173px">
                </asp:DropDownList>
               </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
               <td class="style1">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />
           </td>
        </tr>
    </table>
    <br />
    <div align="right" style="width:930px;">
    <a href="javascript:imprSelec('ContentPlaceHolder1_lblInforme');" >
    <img src="../../Images/print-message.jpg" width="20px" height="20px"/></a></div>
             <div style="height:800px;width:930px; overflow:auto;" >
    <asp:Label ID="lblInforme" runat="server"></asp:Label>
    </div>
</asp:Content>
