<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="LiquidarOT.aspx.cs" Inherits="Intranet.ModuloDespacho.View.LiquidarOT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 227px;
        }
        .style4
        {
            width: 135px;
        }
        .style5
        {
        }
        .style6
        {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<fieldset style="width: 786px;margin-left:112px;" >
    <legend align="center">Liquidar OT</legend>
        <div>
          
          <table style="width: 102%;">
        <tr>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style4">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" ontextchanged="txtOT_TextChanged"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style4">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombreOT" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Cliente:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCliente" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTiraje" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Estado Actual:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEstadoActual" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="lblFechaLiq" runat="server" Font-Bold="True" 
                    Text="Fecha Liquidacion:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFechaLiquidacion" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="4">
               <%-- aqui va la taasdsasd--%>
 <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:800px;margin-left:3px;">
  <tbody><tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">Total Despachado</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">Fecha 1er Despacho</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">Fecha Ultimo Despacho</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">Devolución</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">Faltante</td>
  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
        <asp:Label ID="lblDespachado" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
        <asp:Label ID="lblPrimerDesp" runat="server"></asp:Label></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
        <asp:Label ID="lblUltDesp" runat="server"></asp:Label></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
        <asp:Label ID="lblDevolucion" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp; </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
        <asp:Label ID="lblFaltante" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
  </tr>
</tbody></table>
                <%--fin--%>
                </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Nuevo Estado:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" Width="163px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>En Proceso</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Observación:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtObservacion" runat="server" Height="93px" 
                    TextMode="MultiLine" Width="388px"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Font-Size="Small" ForeColor="Red" 
                    Text="(* Campo obligatorio al cambiar a estado EN PROCESO.)"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        </div>

        <div align="center" id="DivMensaje" runat="server" visible="false">
            <asp:Image ID="imgMensaje" runat="server" />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>

        <div align="center" style="width: 810px">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                    onclick="btnGuardar_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNuevo" runat="server" Text="Nueva Liquidacion" 
                    onclick="btnNuevo_Click" />
                <br />
                <br />
                <br />
            </div>
                        <br />
            <br />
</fieldset>
            <br />
            <br />
            <br />
            <br />

                 <%--  <table id="id_tabla_itinerario" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:800px;">
  
  <tbody><tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Total Despachado</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Fecha 1er Despacho</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Fecha Ultimo Despacho</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Devolución</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Faltante</td>
  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Miercoles 29 enero 2014&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Santiago de Chile (SCL)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Antofagasta (ANF)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Operado por LanExpress   </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Económica-L</td>
  </tr>
  
  <tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Vuelta <a title="Detalle de itinerario" href="javascript:showLightbox_escalas('layer_escalas_2');">[+] info</a></td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Salida</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Llegada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Vuelo</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;">Cabina</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px;">Equipaje</td>
  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Martes 18 marzo 2014&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>22:10</strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Antofagasta (ANF)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;"><strong>00:05</strong> <strong>(Miércoles)</strong></td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Santiago de Chile (SCL)</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">LA123<br>
      </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;">Económica-S
    </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px;">

Máximo 2 piezas que pesen 23 kg <strong>en total</strong>.
 </td>
  </tr>
  
</tbody></table>--%>

            <br />
            <br />
            <br />
</asp:Content>
