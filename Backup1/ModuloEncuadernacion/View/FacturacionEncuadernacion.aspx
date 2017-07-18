<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="FacturacionEncuadernacion.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.FacturacionEncuadernacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function openGame(OT) {
        window.open('DetalleOTFacturacion.aspx?ot=' + OT, 'Detalle OT', 'left=160,top=100,width=1020 ,height=770,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }


</script>
        <script type="text/javascript">
            function openGame2(OT) {
                $.ajax({
                    url: "FacturacionEncuadernacion.aspx/GetContactName",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'OT':'" + OT + "'}",
                    success: function (msg) {
                        if (msg.d != 'SI') {
                            alert('El sistema no ha encontrado el archivo solicitado, la razón podría ser una de las siguientes:\n\n - No esta conectada la unidad de red Z:Antartica\n\n - El Archivo PDF para la OT solicitada no existe.');
                        }
                    },
                    error: function () {
                        alert('¡Ha Ocurrido un Error!');
                    }
                });
            }
        </script>
    <style type="text/css">
.modalBackground {
    background-color:Gray;
    filter:alpha(opacity=70);
    opacity:0.7;
}

.modalPopup {
    background-color:White;
    border-width:3px;
    border-style:solid;
    border-color:Gray;
    padding:3px;
    text-align:center;
}
.hidden {display:none}
   .divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    padding: 5px;
    text-align: center;
}
    </style>
    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) {
            var sm = Sys.WebForms.PageRequestManager.getInstance();
            if (!sm.get_isInAsyncPostBack()) {
                sm.add_beginRequest(onBeginRequest);
                sm.add_endRequest(onRequestDone);
            }
        }

        function onBeginRequest(sender, args) {
            var send = args.get_postBackElement().value;
            if (displayWait(send) == "yes") {
                $find('PleaseWaitPopup').show();
            }
        }

        function onRequestDone() {
            $find('PleaseWaitPopup').hide();
            __doPostBack();
        }

        function displayWait(send) {
            switch (send) {
                case "Filtrar":
                    return ("yes");
                    break;
                case "Filtrar":
                    return ("yes");
                    break;
                default:
                    return ("no");
                    break;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;border-radius:10px 10px 10px 10px;" align="center" width="890px">
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtOP" runat="server"></asp:TextBox>
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre OT: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreOP" runat="server"></asp:TextBox>

            </td>
            <td class="style14">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style13">
                &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14">
            <div style="margin-left:17px;">

<asp:UpdatePanel ID="PleaseWaitPanel" runat="server" RenderMode="Inline">
    <ContentTemplate>
      <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />

   </ContentTemplate>
</asp:UpdatePanel>




               

           </div>
            </td>
        </tr>
    </table>

    <br />
          <div runat="server" id="DivCont"  style="border:1px solid blue;height:540px; overflow:scroll; width: 940px;" >
                <telerik:RadGrid ID="RadGrid1" BorderWidth="0px" runat="server"  Skin="Outlook" >
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                                <ItemStyle Width="200px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Tiraje"   HeaderText="Tiraje" UniqueName="Tiraje">
                                <ItemStyle HorizontalAlign="Right" Width="30px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="DespachadoEnc"   HeaderText="Despacho Enc." UniqueName="DespachadoEnc">
                                <ItemStyle HorizontalAlign="Right" Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RecepcionadoDespacho" HeaderText="Recibido QGChile" 
                                UniqueName="RecepcionadoDespacho">
                                <ItemStyle Width="30px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Devolucion" HeaderText="Devolucion" 
                                ReadOnly="True" SortExpression="Devolucion" UniqueName="Devolucion">
                                <ItemStyle Width="30px" HorizontalAlign="Right"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" 
                                ReadOnly="True" SortExpression="Saldo" UniqueName="Saldo">
                                <ItemStyle Width="30px" HorizontalAlign="Right"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaEntrega" HeaderText="FechaEntrega" 
                                ReadOnly="True" SortExpression="FechaEntrega" UniqueName="FechaEntrega">
                                <ItemStyle Width="90px" HorizontalAlign="Center"/>
                            </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="VerMas" HeaderText="" 
                                ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                                <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>

        <asp:Panel ID="PleaseWaitMessagePanel" runat="server" CssClass="modalPopup" Height="125px" Width="180px">
            <div class="divTitulo">Cargando Registros</div><br />
            <img src="../../Images/cargando.gif" alt="Cargando Registros. Por favor Espere..." /><br /> Por favor Espere...<br /> 
        </asp:Panel>

 <asp:Button ID="HiddenButton" runat="server" CssClass="hidden" Text="Hidden Button"
 ToolTip="Necessary for Modal Popup Extender" />
 <asp:ModalPopupExtender ID="PleaseWaitPopup" BehaviorID="PleaseWaitPopup"
 runat="server" TargetControlID="HiddenButton" PopupControlID="PleaseWaitMessagePanel"
 BackgroundCssClass="modalBackground">
 </asp:ModalPopupExtender>
</asp:Content>
