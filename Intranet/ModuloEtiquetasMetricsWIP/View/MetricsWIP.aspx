<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="MetricsWIP.aspx.cs" Inherits="Intranet.ModuloEtiquetasMetricsWIP.View.MetricsWIP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
         .divTitulo{
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding-top: 5px;
            padding-bottom: 5px;
            border: 1px solid #959595;
            text-align: left;
            color:#003e7e;
        }
        .divSeccion{
            padding-top: 10px;
            padding-bottom: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 126px;
        }
        .auto-style3 {
            height: 23px;
            width: 126px;
        }
        .auto-style4 {
            width: 112px;
        }
        .auto-style5 {
            height: 23px;
            width: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        
        <table style="background-color:#EEE;border:1px solid #999;margin-left:50px;padding:9px;margin-bottom:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
       
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Pliego:"></asp:Label>
                </td>
            <td>
                <asp:DropDownList ID="ddlPliego" runat="server" Width="168px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Maquina:"></asp:Label>
            </td>
                <td>
                    <asp:DropDownList ID="ddlMaquina" runat="server" Width="168px">
                        <asp:ListItem>KBA</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
               <div style="text-align:right;margin-top:-10px;">
                <%--<asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />--%>
                    </div>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                    onclick="btnFiltrar_Click1" />
            </td>
        </tr>
        </table> 
    <br />
    <div style="height:150px;overflow:auto;">
        <asp:Label ID="lblTabla" runat="server"></asp:Label>
    </div>
    <br /> <br />
    <div class="divTitulo"> Crear Etiqueta <div style="display:inline;float:right;">Historial Etiquetas</div></div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" Text="ObjID:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblObjId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label8" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOT" runat="server"></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label9" runat="server" Text="Pliego:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPliego" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style5">
                    <asp:Label ID="Label7" runat="server" Text="Cantidad:" Font-Bold="True"></asp:Label>
                </td>
                <td class="auto-style1">  <asp:TextBox ID="txtCantidad" runat="server" Enabled="False"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>

        <%--<asp:Button ID="btnFiltro" runat="server" Text="Crear" OnClick="btnFiltro_Click" Width="80px" Enabled="False" />--%>
                    <input id="btnCrear" type="button" value="Crear" onclick="javascript: CrearEtiqueta();" style="width:80px;" />
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        </div>
     <br /> <br /> <br /> <br /> <br /> <br />
</asp:Content>
