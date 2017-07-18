<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudRequerimientosOP.aspx.cs" Inherits="Intranet.ModuloProduccion.View.SolicitudRequerimientosOP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript" src="http://localhost:11431/js/jquery-1.9.1.js"></script>
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
        .style1
        {
            width: 144px;
        }
        .style3
        {
        }
        .style4
        {
            width: 150px;
        }
        .style5
        {
            width: 53px;
        }
        .style6
        {
            width: 108px;
        }
        .style8
        {
            width: 44px;
        }
        .style9
        {
            width: 346px;
        }
        .style10
        {
            width: 43px;
        }
        .style12
        {
            width: 146px;
        }
        .style14
        {
            width: 42px;
        }
        .style16
        {
            width: 310px;
        }
        .style17
        {
            width: 145px;
        }
    </style>
        <script  type="text/javascript" language="javascript">
            $(document).ready(function () {

            });
            function habilitaSI() {
                document.getElementById("DivSi").style.display = "block";
                document.getElementById("DivNo").style.display = "none";
            }

            function habilitaNO() {
                document.getElementById("DivSi").style.display = "none";
                document.getElementById("DivNo").style.display = "block";
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
                   <div align="center"> <asp:Label ID="Label24" runat="server" 
                           Text="Solicitud de Requerimientos" Font-Bold="True" Font-Size="X-Large" 
                           ForeColor="#003E7E"></asp:Label></div>
                    <div class="divTitulo">
                   Datos OT </div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style12">
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;<asp:Label ID="Label2"
                        runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                &nbsp;
                </td>
                <td>
                <asp:Label ID="lblNombreOT" runat="server"></asp:Label> 
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" Text="Fecha Creación:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style12">
                    <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Tiraje: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTiraje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label6" runat="server" Text="Formato Impresión:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style12">
                    <asp:Label ID="lblFormatoImpresion" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;
                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Páginas:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPaginas" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label9" runat="server" Text="Cliente:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style3" colspan="2">
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
                        <div class="divTitulo">
                   Requerimientos </div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style8">
                    &nbsp;
                </td>
                <td class="style4">
                    <asp:Label ID="Label14" runat="server" Text="Fecha V°B°:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtFechaVB" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaVB" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Hora: "></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" Width="25px"></asp:TextBox>
&nbsp;:
                    <asp:TextBox ID="TextBox9" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;
                </td>
                <td class="style4">
                    <asp:Label ID="Label16" runat="server" Text="N° Páginas Color:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label20" runat="server" Text="N° Páginas Improof:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr> 
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label21" runat="server" Text="N° Páginas Armado:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label22" runat="server" Text="Revisa CSR:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    <asp:RadioButton ID="rdRevisaCSRSi" runat="server" Text="Si" 
                        GroupName="RevisaCSR" />
&nbsp;<asp:RadioButton ID="rdRevisaCSRNo" runat="server" Checked="True" Text="No" 
                        GroupName="RevisaCSR" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label23" runat="server" Text="Observacion:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style9">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="35px" 
                        Width="331px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
                            <div class="divTitulo">
                                Dirección V°B° </div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style14">
                    &nbsp;
                </td>
                <td class="style12">
                    <asp:Label ID="Label30" runat="server" Font-Bold="True" 
                        Text="¿Otra Dirección? :"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:RadioButton ID="rdDireccionSi" runat="server" Text="Si" 
                        GroupName="OtraDireccion" onclick="javascript:habilitaSI();"/>
&nbsp;<asp:RadioButton ID="rdDireccionNo" runat="server" Text="No" 
                        GroupName="OtraDireccion" Checked="True" onclick="javascript:habilitaNO();" />
                </td>
            </tr>
            </table>
            <div id="DivSi">
                <table style="width: 100%;">
                    <tr>
                        <td class="style10">
                            &nbsp;
                        </td>
                        <td class="style17">
                    <asp:Label ID="Label36" runat="server" Font-Bold="True" 
                        Text="Comuna:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="217px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            &nbsp;
                        </td>
                        <td class="style17">
                    <asp:Label ID="Label37" runat="server" Font-Bold="True" 
                        Text="Ciudad:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="217px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            &nbsp;
                        </td>
                        <td class="style17">
                            &nbsp;<asp:Label ID="Label38" runat="server" Font-Bold="True" 
                        Text="Dirección Cliente:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox14" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="DivNo">
                <table style="width: 100%;">
                    <tr>
                        <td class="style10">
                            &nbsp;
                        </td>
                        <td class="style17">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                        Text="Dirección Cliente:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDireccion" runat="server" Width="217px">
                    </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
            </div>
        <table style="width: 100%;">
            <tr>
                <td class="style10">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Detalle Envío:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="V°B° Color" />
&nbsp;
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="V°B° Improof" />
&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Contacto:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Text="Telefono:"></asp:Label>
                &nbsp;
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="E-Mail:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Observación:"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Height="35px" TextMode="MultiLine" 
                        Width="331px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Agregar Dirección" 
                        Width="131px" />
                </td>
            </tr>
        </table>
 <div style="height:150px;overflow:auto;" >
 <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:800px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Dirección</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16">Comuna</td>
                  <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16">Ciudad</td>
                  <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16">V°B° Color</td>
                  <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16">V°B° Improof</td>
                                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblTotalSolicitado" runat="server"></asp:Label>
&nbsp;</td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
&nbsp;</td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
&nbsp;</td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="Label11" runat="server"></asp:Label>
&nbsp;</td>
 <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
&nbsp;</td>

  </tr>


</tbody></table>
</div>
    </div>
    </div>
    <asp:Button ID="btnFiltro" runat="server" Text="Button" />
    </form>
</body>
</html>
