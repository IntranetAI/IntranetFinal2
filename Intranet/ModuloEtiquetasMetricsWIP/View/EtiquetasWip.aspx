<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="EtiquetasWip.aspx.cs" Inherits="Intranet.ModuloEtiquetasMetricsWIP.View.EtiquetasWip" %>
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
<script type="text/javascript">
    $(document).ready(function () {
        });
         function CrearEtiqueta() {
             var objId = document.getElementById("ContentPlaceHolder1_lblObjId").innerHTML;
             var cantidad = eval(document.getElementById("<%= txtCantidad.ClientID%>").value);

            var Usuario = '<%= Session["Usuario"] %>';
             $.ajax({
                 url: "EtiquetasWip.aspx/CrearOrden",
                 type: "post",
                 dataType: "json",
                 contentType: "application/json;charset=utf-8",
                 data: "{'ObjId':'" + objId + "','Cantidad':'" + cantidad + "','Usuario':'" + Usuario + "'}",
                 success: function (msg) {
                     if (eval(msg.d[0]) > 0) {

                         window.open('_Etiqueta.aspx?id=' + msg.d[0], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                         document.getElementById("<%= txtCantidad.ClientID%>").value = '';
                         document.getElementById("<%= txtCantidad.ClientID%>").focus();
                     }
                     else {
                         alert("¡Ha ocurrido un Error, vuelva a intentarlo!");
                     }
                 },
                 error: function () {
                     alert('¡Ha Ocurrido un Error!');
                 }
             });
            }
            function Mostrar(objId,ot,nombreot,pliego) {
                document.getElementById("ContentPlaceHolder1_lblObjId").innerHTML = objId;
                document.getElementById("ContentPlaceHolder1_lblOT").innerHTML = ot;
                document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = nombreot;
                document.getElementById("ContentPlaceHolder1_lblPliego").innerHTML = pliego;
                
                document.getElementById("ContentPlaceHolder1_txtCantidad").disabled = false;
                document.getElementById("ContentPlaceHolder1_btnFiltro").disabled = false;
            }
            function solonumeros(e) {
                var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
                return ((tecla > 47 && tecla < 58) || tecla == 08);
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <table style="background-color:#EEE;border:1px solid #999;padding:9px;margin-left:-10px;margin-bottom:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
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
                    onclick="btnFiltrar_Click1" style="height: 26px" />
            </td>
        </tr>
        </table>
    <br /><br />
                        <telerik:radgrid ID="RadGrid1" runat="server" Width="935px"  Skin="Outlook" >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ObjId">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="ObjId" HeaderText="ObjId" 
                                ReadOnly="True" SortExpression="ObjId" UniqueName="ObjId" ItemStyle-Width="30px" Visible="false">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                                UniqueName="OT" ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-HorizontalAlign="Left" 
                                ReadOnly="True" SortExpression="NombreOT" UniqueName="NombreOT" ItemStyle-Width="220px">
                                </telerik:GridBoundColumn>                                   
                                
                            <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-HorizontalAlign="Left" 
                                ReadOnly="True" SortExpression="Pliego" UniqueName="Pliego" ItemStyle-Width="260px">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" SortExpression="Tiraje" 
                                UniqueName="Tiraje" ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" 
                            UniqueName="Buenos" ItemStyle-Width="30px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                                SortExpression="Maquina" UniqueName="Maquina" ItemStyle-Width="80px" ></telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="Fecha Inicio" 
                                SortExpression="FechaInicio" UniqueName="FechaInicio" ItemStyle-Width="120px" ></telerik:GridBoundColumn>
                           
                           <telerik:GridBoundColumn DataField="CantidadPallets" HeaderText="Cantidad Pallets" 
                            UniqueName="CantidadPallets" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" 
                            UniqueName="Accion" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    <br /> <br />
    <div class="divTitulo"> Crear Etiqueta </div>
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
