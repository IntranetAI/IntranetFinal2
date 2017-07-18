<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Devoluciones.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.Devoluciones" %>
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
    .style2
    {
        width: 51px;
    }
    .style3
    {
        width: 243px;
    }
    .style4
    {
        width: 125px;
    }
    .style5
    {
        width: 179px;
    }
    .style6
    {
        width: 105px;
    }
    .style8
    {
        width: 208px;
    }
    .style10
    {
    }
    .style12
    {
        width: 185px;
    }
    .style14
    {
        width: 362px;
    }
    .style15
    {
        width: 349px;
    }
    .style16
    {
        width: 300px;
    }
    .style17
    {
        width: 162px;
    }
    .style18
    {
        width: 231px;
    }
    .style19
    {
        width: 51px;
        height: 23px;
    }
    .style20
    {
        width: 125px;
        height: 23px;
    }
    .style21
    {
        width: 179px;
        height: 23px;
    }
    .style23
    {
        height: 23px;
    }
    .style25
    {
        width: 139px;
    }
    .style26
    {
        width: 139px;
        height: 23px;
    }
    .style27
    {
        width: 215px;
    }
</style>
  <script  type="text/javascript" language="javascript">
        $(document).ready(function () {
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
        });
        function Procesar(Folio,sku,papel,gramaje,ancho,largo) {
            $.ajax({
                url: "Devoluciones.aspx/ProcesarDevolucion",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Folio':'" + Folio + "','SKU':'" + sku + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblOT").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblSKUAsignado").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblPapelAsignado").innerHTML = msg.d[4];


                    document.getElementById("ContentPlaceHolder1_lblSKUSolicitado").innerHTML = sku;
                    document.getElementById("ContentPlaceHolder1_lblPapelSolicitado").innerHTML = papel;


                    document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML = msg.d[8];
                    document.getElementById("ContentPlaceHolder1_lblProcedencia").innerHTML = msg.d[9];



                    if (Folio.indexOf("SC") == -1) {
                        document.getElementById("ContentPlaceHolder1_lblS KUEntrada").innerHTML = sku;

                    } else {
                        document.getElementById("ContentPlaceHolder1_lblSKUEntrada").innerHTML = msg.d[3];

                    }

                    document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML = Folio;
                    document.getElementById("DivFiltroDev").style.display = "none";
                    document.getElementById("DivProcesar").style.display = "block";

                    CargaFaltantes(Folio);

                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function CargaFaltantes(id) {
            $.ajax({
                url: "Devoluciones.aspx/CargaFaltantes",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDConsumo':'" + id + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblMaximoDevolver").innerHTML = msg.d[0];


                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function IngresaDevolucion() {
            var folio = document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
            var sku = document.getElementById("ContentPlaceHolder1_lblSKUEntrada").innerHTML;
            var papel = '';
            var gramaje = '';
            var ancho = '';
            var largo = '';
            if (folio.indexOf("SC") == -1) {
                sku = document.getElementById("ContentPlaceHolder1_lblSKUEntrada").innerHTML;
                papel = document.getElementById("ContentPlaceHolder1_lblPapelAsignado").innerHTML;
                gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
                ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
                largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
      
            } else {
                sku = document.getElementById("ContentPlaceHolder1_lblSKUSolicitado").innerHTML;
                papel = document.getElementById("ContentPlaceHolder1_lblPapelSolicitado").innerHTML;
                gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
                ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
                largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
            }
            var ot = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var not = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
            var comp = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;
            
            var pliegos = document.getElementById("<%= txtPliegos.ClientID %>").value;
            var peso = document.getElementById("<%= txtPeso.ClientID %>").value;
            var maxDevolver = document.getElementById("ContentPlaceHolder1_lblMaximoDevolver").innerHTML;
            var moDevolucion = document.getElementById("<%= txtMotivoDevolucion.ClientID %>").value;
            var procedencia = document.getElementById("ContentPlaceHolder1_lblProcedencia").innerHTML;
            var usuario = '<%= Session["Usuario"] %>';
            $.ajax({
                url: "Devoluciones.aspx/CrearDevolucion",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Folio':'" + folio + "','OT':'" + ot + "','NombreOT':'" + not + "','Componente':'" + comp +
                "','SKU':'" + sku + "','Papel':'" + papel + "','Gramaje':'" + eval(gramaje) + "','Ancho':'" + eval(ancho) +
                "','Largo':'" + eval(largo) + "','Pliegos':'" + eval(pliegos) + "','Peso':'" + eval(peso) + 
                "','MotivoDevolucion':'"+moDevolucion+"','Procedencia':'"+procedencia+"','Usuario':'" + usuario + "','MaxDevolver':'" + eval(maxDevolver) + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'OK') {
                        window.open('EtiquetaBP.aspx?Pro=0&Folio=' + msg.d[1], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                        alert('¡Devolucion Generada Correctamente!');
                        CargaFaltantes(idconsumo);
                    } else {
                        alert(msg.d[0]);
                    }

                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="DivFiltroDev">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 850px;" 
        align="center">

        <tr>
               <td class="style18">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style14">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style15">
            &nbsp;
                   <asp:Label ID="Label11" runat="server" Text="Nro Pallet:"></asp:Label>
               
                </td>
            <td class="style4">
               
                <asp:TextBox ID="txtNroPallet" runat="server"></asp:TextBox>
               
               </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style18">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:"></asp:Label>
               
            </td>
            <td class="style14">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style15">
            &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style12">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style17">
                </td>
            <td class="style8">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        <br />
        <div style="height:500px;width:1095px; overflow:auto;" >
        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                                    <telerik:GridBoundColumn DataField="NroPallet" HeaderText="NroPallet" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" SortExpression="NroPallet" UniqueName="NroPallet">
                    </telerik:GridBoundColumn>
                        
   
      
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>
                      
                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>       
                                               <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="340px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="Cantidad Asignada" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Consumo" ItemStyle-Width="50px" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>      

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>    
            
              
                                           
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
                </div>
</div>
<div id="DivProcesar" >  <%--style="display:none;"--%>
    <div class="divTitulo">Datos de la Devolucion</div>
 <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td class="style25">
                    <asp:Label ID="Label12" runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label13" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblComponente" runat="server"></asp:Label>
                </td>
                <td class="style25">
                    <asp:Label ID="lblFolio"  runat="server"></asp:Label>
                </td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="SKU Asignado:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblSKUAsignado" runat="server"></asp:Label>
                </td>
                <td class="style25">
                    <asp:Label ID="Label15" runat="server" Text="Papel Asignado:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style10" colspan="2">
                    <asp:Label ID="lblPapelAsignado" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    </td>
                <td class="style20">
                    <asp:Label ID="Label60" runat="server" Font-Bold="True" Text="SKU Corte:"></asp:Label>
                </td>
                <td class="style21">
                    <asp:Label ID="lblSKUSolicitado" runat="server"></asp:Label>
                </td>
                <td class="style26">
                    <asp:Label ID="Label62" runat="server" Font-Bold="True" 
                        Text="Papel Corte:"></asp:Label>
                </td>
                <td class="style23" colspan="2">
                    <asp:Label ID="lblPapelSolicitado" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style20">
                    <asp:Label ID="Label63" runat="server" Font-Bold="True" Text="Procedencia:"></asp:Label>
                </td>
                <td class="style21">
                    <asp:Label ID="lblProcedencia" runat="server"></asp:Label>
                </td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style23" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label16" runat="server" Text="Gramaje:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblGramaje" runat="server"></asp:Label>
                </td>
                <td class="style25">
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
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label21" runat="server" Text="Total Asignado:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="   Pliegos."></asp:Label>
                </td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>

            <div class="divTitulo">
                        Crear Pallets Devolucion</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SKU Entrada:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSKUEntrada" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label24" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegos" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" runat="server" BackColor="Yellow"></asp:TextBox>
&nbsp;<asp:Label ID="Label26" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label64" runat="server" Font-Bold="True" 
                        Text="Motivo Devolucion:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMotivoDevolucion" runat="server" Height="94px" 
                        TextMode="MultiLine" Width="359px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div align="center">
        <input id="btnGuardar" type="button" value="Crear Devolucion" 
                onclick="javascript:IngresaDevolucion();" style="width:182px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--        <input id="Button5" type="button" value="Crear y Finalizar sol." onclick="javascript:CrearPallet('Cerrar');" />--%>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
         <input id="Button1" type="button" value="Nueva Solicitud" onclick="javascript:NuevaSolicitud();" style="width:182px;" />

               </div>
        </div>
        <br />
        <div align="right" style="margin-left:500px;">
    <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Cantidad Solicitud</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label32" runat="server" Text="Maximo a Devolver:"></asp:Label>
        </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblMaximoDevolver" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label33" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
</tbody></table>
</div>

</div>
</asp:Content>
