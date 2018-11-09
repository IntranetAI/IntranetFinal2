<%@ Page Title="" Language="C#" MasterPageFile="~/Estructura/View/MasterAplicaciones.Master" AutoEventWireup="true" CodeBehind="ProgramaProduccion_Ext.aspx.cs" Inherits="Intranet.ModuloProduccion.View.ProgramaProduccion_Ext" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
            <script type="text/javascript">
        $(function () {
            $('[id*=lstFruits]').multiselect({
                includeSelectAllOption: true
            });
            $("#Button1").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
            <table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;margin-left:450px;" align="center" width="950px">
                    <tr>
                           <td class="style4">
                            &nbsp;&nbsp;
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Sector: "></asp:Label>
               
                               <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                   <asp:ListItem>Todas</asp:ListItem>
                                   <asp:ListItem>Rotativas</asp:ListItem>
                                   <asp:ListItem>Planas</asp:ListItem>
                                   <asp:ListItem>Digital</asp:ListItem>
                                   <asp:ListItem>Dimensionado</asp:ListItem>
                                   <asp:ListItem>Guillotinas</asp:ListItem>
                                   <asp:ListItem>Dobladoras</asp:ListItem>
                                   <asp:ListItem>Costura Alambre</asp:ListItem>
                                   <asp:ListItem>Costura Hilo</asp:ListItem>
                                   <asp:ListItem>Entape</asp:ListItem>
                                   <asp:ListItem>Tapa Dura</asp:ListItem>
                                   <asp:ListItem>Espiral</asp:ListItem>
                                   <asp:ListItem>Embolsado</asp:ListItem>
                                   <asp:ListItem>Manualidades</asp:ListItem>
                                   <asp:ListItem>Externos</asp:ListItem>
                                   <asp:ListItem>Encuadernacion</asp:ListItem>
                               </asp:DropDownList>
               
                        </td>
                        <td class="style4">
               
                            <asp:Label ID="Label3" runat="server" Text="Maquina:"></asp:Label>
                           <asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple">
                           </asp:ListBox>

                           </td>
                        <td class="style4">
                            <asp:Label ID="lblFechaTermino" runat="server" Text="Meses: "></asp:Label>

                        <asp:DropDownList ID="ddlMeses" runat="server">
                            <asp:ListItem Value="0">ACTUAL</asp:ListItem>
                           <asp:ListItem Value="1">2 MES</asp:ListItem>
                           <asp:ListItem Value="2">3 MESES</asp:ListItem>
                           <asp:ListItem Value="3">4 MESES</asp:ListItem>
                           <asp:ListItem Value="4">5 MESES</asp:ListItem>
                           <asp:ListItem Value="5">6 MESES</asp:ListItem>
                        </asp:DropDownList>
                            </td>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style4">

                <asp:Button ID="btnFiltro" runat="server" Text="Button" OnClick="btnFiltro_Click" />

                       </td>
                    </tr>
                </table>

    <div style="height: 850px; width: 100%; overflow:auto;">
        <span style="float:right;"> <asp:LinkButton ID="lbImprimir" runat="server" OnClick="lbImprimir_Click" >IMPRIMIR PROGRAMA</asp:LinkButton> </span>
     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     </div>
</asp:Content>
