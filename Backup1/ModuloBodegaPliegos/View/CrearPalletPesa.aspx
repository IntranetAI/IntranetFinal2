<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearPalletPesa.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.CrearPalletPesa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
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
        .style16
        {
            height: 22px;
        }
    </style>
<script type="text/javascript">
    function BuscarOT() {
         var loc = document.location.href;
        $.ajax({
            url: "CrearPalletsMaquina.aspx/BuscarOT",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'loc':'" + loc + "'}",
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
        var OT = document.getElementById("lblOT").innerHTML;
        var NombreOT = document.getElementById("lblNombreOT").innerHTML;
        var comp = document.getElementById("lblComponente").innerHTML;
        var Papel = document.getElementById("lblPapel").innerHTML;
        var Codigo = document.getElementById("lblCodigo").innerHTML;
        var ancho = document.getElementById("lblAncho").innerHTML;
        var largo = document.getElementById("lblLargo").innerHTML;
        var gramaje = document.getElementById("lblGramaje").innerHTML;
        var asignadoPliegos = document.getElementById("<%= txtPliegos.ClientID %>").value;
        var asignadoPeso = document.getElementById("<%= txtPeso.ClientID %>").value;
        var Faltante = document.getElementById("lblTotalFaltante").innerHTML;
        var loc = document.location.href;
        $.ajax({
            url: "CrearPalletPesa.aspx/CrearPallet",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "','NombreOT':'" + NombreOT + "','Comp':'" + comp + "','Codigo':'" + Codigo + "','Papel':'" + Papel +
                "','Ancho':'" + eval(ancho) + "','Largo':'" + eval(largo) + "','Gramaje':'" + eval(gramaje) + "','Cantidad':'" + eval(asignadoPliegos) +
                "','Peso':'" + eval(asignadoPeso) + "','Faltante':'" + eval(Faltante) + "','loc':'" + loc + "'}",
            success: function (msg) {
                if (msg.d[0] == 'OK') {
                    location.reload();
                    alert('¡Pallet Generado Correctamente!');
                } else if (msg.d[0] == 'Error2') {
                    alert('¡La cantidad asignada no puede ser mayor a lo solicitado!');

                } else if (msg.d[0] == 'Error3') {
                    alert('¡Debe ingresar Cantidad Pliegos y Peso!');

                } else {
                    alert('¡Ha Ocurrido un Error!');
                }
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }


    function VerPallet() {
            document.getElementById("Registros").style.display = 'block';
            document.getElementById("Registros2").style.display = 'block';
           
    }
    function CerrarPallet() {
        document.getElementById("Registros").style.display = 'none';
        document.getElementById("Registros2").style.display = 'none';

    }
    $(document).ready(function () {

        document.getElementById("Registros").style.display = 'none';
        document.getElementById("Registros2").style.display = 'none';
    });
//    });
//        $("#ContentPlaceHolder1_txtOT").keypress(function (e) {
//            if (e.which == 13) {
//                BuscarOT();
//            }
//        });

//        $("#ContentPlaceHolder1_txtOT").change(function () {
//            BuscarOT();
        //});
  
</script>
<style type="text/css">
       .tablestyle 
        {   
            border: solid 1px #7f7f7f;
            width: 1080px;
            vertical-align:top;   
            font-family:Arial; 
            font-size:12px;
        }
        .altrowstyle 
        {
            background-color: #edf5ff;
    
        }
        .headerstyle th 
        {
            background: url(img/sprite.png) repeat-x 0px 0px;
            border-color: #989898 #cbcbcb #989898 #989898;
            border-style: solid solid solid none;
            border-width: 1px 1px 1px medium;
             
            padding: 4px 5px 4px 10px;
            text-align:left;
            vertical-align:  top ;
            background-color:#CDE5FF;
            position:relative ;

        }  

        .headerstyle th a
        {
            font-weight: bold;
            text-decoration: none;
            text-align: center;
            color: #063E77;
            display: block;
            padding-right: 10px;
        }  
        .rowstyle .sortaltrow, .altrowstyle .sortaltrow 
        {
            background-color: #edf5ff;
    
        }

        .rowstyle .sortrow, .altrowstyle .sortrow 
        {
            background-color: #dbeaff;
        }

        .rowstyle td, .altrowstyle td 
        {
            padding: 4px 10px 4px 10px;
            border-right: solid 1px #cbcbcb;
        }

        .headerstyle .sortascheader 
        {
            background: url(App_Themes/img/sprite.png) repeat-x 0px -100px;
           font-weight:bold;
        }

        .headerstyle .sortascheader a 
        {
            background: url(App_Themes/img/dt-arrow-up.png) no-repeat right 50%;
           font-weight:bold;
        } 

        .headerstyle .sortdescheader 
        {
            background: url(App_Themes/img/sprite.png) repeat-x 0px -100px;
           font-weight:bold;
        }   

        .headerstyle .sortdescheader a 
        {
            background: url(App_Themes/img/dt-arrow-dn.png) no-repeat right 50%;
           font-weight:bold;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
<br />
<div id="divDatosSolicitud">
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
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Codigo:"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Marca:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
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
            <div class="divTitulo" id="Registros" >
                <table style="width:100%;">
                    <tr>
                        <td>
                            Ver Pallets Creados</td>
                        <td>
                            <div align="right"><a style="color:Blue;text-decoration: underline;font-size:15px;"  onclick="javascript:CerrarPallet();">Cerrar</a></div></td>
                    </tr>
                </table>
    </div>
    <div class="divSeccion" id="Registros2">
    <div style="height:200px;">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" CssClass="tablestyle">
        <AlternatingRowStyle CssClass="altrowstyle" />
        <HeaderStyle CssClass="headerstyle" />
        <RowStyle CssClass="rowstyle" Wrap="false" />  
        <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
        <EmptyDataTemplate >
            No Records Found
        </EmptyDataTemplate> 
        <Columns>
            <asp:BoundField DataField="OT" HeaderText="OT" />
            <asp:BoundField DataField="NombreOT" HeaderText="Nombre OT" />
            <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" />
            <asp:BoundField DataField="Posicion" HeaderText="Posicion" />
            <asp:BoundField DataField="ID_Control" HeaderText="ID_Control" />
            <asp:BoundField DataField="Pliego" HeaderText="Pliego" />
            <asp:BoundField DataField="Pliegos_Impresos" HeaderText="Pliegos_Impresos" />
<%--            <asp:BoundField DataField="Peso_pallet" HeaderText="Peso_pallet" />
            <asp:BoundField DataField="Maquina_Proceso" HeaderText="Maquina_Proceso" />
            <asp:BoundField DataField="Estado_Pallet2" HeaderText="Estado_Pallet2" />
            <asp:BoundField DataField="Fecha_Modificacion" HeaderText="Fecha_Modificacion" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />--%>
           <%-- <asp:BoundField DataField="VerMas" HeaderText="VerMas" />--%>
        </Columns>
    </asp:GridView>
    </div>
    </div>
        <div class="divTitulo">
            <table style="width:100%;">
                <tr>
                    <td>
                        Crear Pallets</td>
                    <td>
                      <div align="right"> 
                          <a style="color:Blue;text-decoration: underline;font-size:15px;" onclick="javascript:VerPallet();">Ver Creados</a></div></td>
                </tr>
            </table>
    </div>
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
                    <asp:TextBox ID="txtPliegos" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" runat="server" BackColor="Yellow"></asp:TextBox>
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
        <br />
        <div align="right" style="margin-left:500px;">
                         <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Cantidad Solicitada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDespachado" runat="server">Total Solicitado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblTotalSolicitado" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label30" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server">Total Creado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblTotalCreado" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label31" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label32" runat="server" Text="Cantidad Faltante:"></asp:Label>
        </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblTotalFaltante" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label33" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
</tbody></table>
</div>
</div>
    </form>
</body>
</html>
