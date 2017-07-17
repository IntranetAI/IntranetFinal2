<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Presupuestador.aspx.cs" Inherits="Intranet.ModuloComercial.View.Presupuestador" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    $(document).ready(function () {


        //        document.getElementById("ContentPlaceHolder1_lblCantPliegosInt").innerHTML = (parseInt(document.getElementById("ContentPlaceHolder1_txtTiraje").value) * 2);





        $("#ContentPlaceHolder1_txtTiraje").change(function () {
            document.getElementById("ContentPlaceHolder1_txtNombreCliente").value = $(this).val();


            var pagInt = document.getElementById("ContentPlaceHolder1_ddlPaginasInterior").value;
            var tiraje = document.getElementById("ContentPlaceHolder1_txtTiraje").value; // 
            var pagPli = document.getElementById("ContentPlaceHolder1_lblPagXPliego").innerHTML;
           
            //  document.getElementById("ContentPlaceHolder1_lblCantPliegosInt").innerHTML = (parseInt(document.getElementById("ContentPlaceHolder1_txtTiraje").value) * 2);
            document.getElementById("ContentPlaceHolder1_lblCantPliegosInt").innerHTML = ((parseInt(pagInt) * parseInt(tiraje)) / parseInt(pagPli)).toFixed();
        });
        $("#ContentPlaceHolder1_ddlFormatoCerrado").change(function () {
            $.ajax({
                url: "Presupuestador.aspx/MyMethod",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'firstName':'" + $(this).val() + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblFormatoPag").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblPagXPliego").innerHTML = msg.d[1];
                },
                error: function () {
                    alert('no funca');
                }
            });

        });
    });

</script>
<style type="text/css" >
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
    .style1
    {
        width: 55px;
    }
    .style2
    {
        width: 148px;
    }
    .style3
    {
        width: 91px;
        height: 23px;
    }
    .style4
    {
        width: 148px;
        height: 23px;
    }
    .style5
    {
        height: 23px;
    }
    .style6
    {
        width: 210px;
    }
    .style7
    {
        height: 23px;
        width: 210px;
    }
    .style8
    {
        width: 55px;
        height: 23px;
    }
    .style9
    {
        width: 50px;
    }
    .style10
    {
        width: 135px;
    }
    .style11
    {
        width: 50px;
        height: 9px;
    }
    .style12
    {
        width: 135px;
        height: 9px;
    }
    .style14
    {
        width: 50px;
        height: 23px;
    }
    .style15
    {
        width: 135px;
        height: 23px;
    }
    .style16
    {
        width: 62px;
    }
    .style17
    {
        width: 163px;
    }
    .style18
    {
        height: 9px;
        width: 163px;
    }
    .style19
    {
        height: 23px;
        width: 163px;
    }
    .style20
    {
        height: 22px;
    }
    .style21
    {
        width: 62px;
        height: 22px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divTitulo"> Detalle Cliente 
        <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
            Text="Button" />
    </div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Nombre Cliente:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Rut:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRut" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Atencion a:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Telefono/Fax."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                </td>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Contacto:"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:Label ID="Label9" runat="server" Text="Ciudad:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label8" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Ejecutivo a Cargo:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label11" runat="server" Text="Nombre Producto:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>

    <div class="divTitulo"> Detalle Producto</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="Label12" runat="server" Text="Tipo Producto:"></asp:Label>
                </td>
                <td class="style17">
                    <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
                <td rowspan="6">
                  
                  <div id="tblCalculoPliegos">
                      <table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;  width:350px;'>
                <tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>
                <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Resumen Operacion</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">Interior</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Tapa</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Total</td>  
                </tr>
                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label20" runat="server" Text="Cantidad Pliegos A3"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="lblCantPliegosInt" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
               </td>
          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label1" runat="server" Text="Cantidad de Clicks"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
               </td>
          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label26" runat="server" Text="Merma"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
               </td>
          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label30" runat="server" Text="Peso Pedido"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
               </td>
          </tr>
         </tbody></table>
                  
                  </div>
                  </td>
            </tr>
            <tr>
                <td class="style11">
                </td>
                <td class="style12">
                    <asp:Label ID="Label13" runat="server" Text="Tiraje:"></asp:Label>
                </td>
                <td class="style18">
                    <asp:TextBox ID="txtTiraje" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="Label14" runat="server" Text="Encuadernacion:"></asp:Label>
                </td>
                <td class="style17">
                    <asp:DropDownList ID="ddlEncuadernacion" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style14">
                </td>
                <td class="style15">
                    <asp:Label ID="Label15" runat="server" Text="Formato Cerrado:"></asp:Label>
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddlFormatoCerrado" runat="server" Width="153px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="Label16" runat="server" Text="Formato Abierto:"></asp:Label>
                </td>
                <td class="style17">
                    <asp:DropDownList ID="ddlFormatoAbierto" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="Label17" runat="server" Text="Paginas x Pliego A3:"></asp:Label>
                </td>
                <td class="style17">
                    <asp:Label ID="lblFormatoPag" runat="server"></asp:Label>
                &nbsp;-
                    <asp:Label ID="lblPagXPliego" runat="server" Text="label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div class="divTitulo"> Detalle Paginas</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td>
                                      <div id="DivPaginas">
                      <table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;  width:350px;'>
                <tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>
                <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>
                    &nbsp;</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">Interior</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>Tapa</td>
                </tr>
                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label34" runat="server" Text="Cantidad de Paginas"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:DropDownList ID="ddlPaginasInterior" runat="server" Width="50px">
                                    </asp:DropDownList>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label38" runat="server" Text="Cobertura"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label42" runat="server" Text="Colores"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>
               </td>
  
          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label46" runat="server" Text="Tipo Papel"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label47" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label48" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
           <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label37" runat="server" Text="Gramaje Papel"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label45" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
           <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label49" runat="server" Text="Laminado Tapa"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label50" runat="server" Text="-"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label51" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
           <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label52" runat="server" Text="% Cobertura Scodix"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label53" runat="server" Text="-"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label54" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
           <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label55" runat="server" Text="Despacho"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label56" runat="server"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                                    <asp:Label ID="Label57" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
         </tbody></table>
                  
                  </div></td>
                <td>
                    <table id='Table2' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;  width:250px;'>
                <tbody>
                    <tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>
                <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                            class="style20">
                        Precio de Venta x Pliego</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style21">&nbsp;</td>

                </tr>
                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label58" runat="server" Text="Solo Impresion y Papel"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label59" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label61" runat="server" Text="Pliego Encuadernado"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label62" runat="server" Text="Label"></asp:Label>
               </td>


          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label64" runat="server" Text="Pliego con Terminaciones"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label65" runat="server" Text="Label"></asp:Label>
               </td>

  
          </tr>
                          <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>
                 <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>
                     <asp:Label ID="Label67" runat="server" Text="Pliego Embalado y Despachado"></asp:Label>
               </td>
                                <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style16">
                                    <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>
               </td>

          </tr>
          
         </tbody></table>
         <br />
                             <table id='Table3' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;  width:250px;'>
                <tbody>
                    <tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>
                <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                            class="style20">
                        Aplicacion Scodix al
                        <asp:Label ID="Label69" runat="server" Text="Label"></asp:Label>
                        %</td>
                <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' 
                        class="style21">
                    <asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>
                        </td>

                </tr>
                </tbody></table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
