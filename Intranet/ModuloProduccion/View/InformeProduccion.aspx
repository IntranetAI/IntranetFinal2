<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeProduccion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.InformeProduccion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function openDetalle(OT, pliego, nOT, pliego2) {
        window.open('DetalleInformeProduccion.aspx?pliego='+pliego2+'&ot=' + OT + '&pli=' + pliego + '&nOT=' + nOT, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=770,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
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
    <style type="text/css">
        .style3
        {
            height: 35px;
        }
        .style9
        {
            height: 7px;
        }
        .style10
        {
            height: 7px;
            width: 169px;
        }
        .style11
        {
            height: 15px;
        }
        .style12
        {
            height: 15px;
            width: 169px;
        }
        .style13
        {
            height: 9px;
        }
        .style14
        {
            height: 9px;
            width: 169px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 870px;" 
        align="center">

        <tr>
               <td class="style13">
               &nbsp;&nbsp;
                   <asp:Label ID="Label5" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style13">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               </td>
            <td class="style13">
                <asp:Label ID="Label6" runat="server" Text="NombreOT:"></asp:Label>
               </td>
            <td class="style13">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style13">
                </td>
            <td class="style14">
                </td>
        </tr>
        <tr>
               <td class="style9">
                &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Area:"></asp:Label>
               
            </td>
            <td class="style9">
               
                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="173px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="IMP ROT">Rotativas</asp:ListItem>
                    <asp:ListItem Value="IMP PLANA">Planas</asp:ListItem>
                    <asp:ListItem Value="ENCADERN">Encuadernacion</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style9">
                   <asp:Label ID="Label3" runat="server" Text="Maquina:"></asp:Label>
               
               </td>
            <td class="style9">
               
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="173px" 
                    AutoPostBack="True" onselectedindexchanged="ddlMaquina_SelectedIndexChanged">
                </asp:DropDownList>
               
               </td>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="Operador:"></asp:Label>
               </td>
            <td class="style10">
               
                <asp:DropDownList ID="ddlOperador" runat="server" Width="173px">
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
               <td class="style11">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style11">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style11">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style11">
                </td>
            <td class="style12">
<%--            
<asp:UpdatePanel ID="PleaseWaitPanel" runat="server" RenderMode="Inline">
    <ContentTemplate>--%>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />
<%-- </ContentTemplate>
</asp:UpdatePanel>--%>
                </td>
        </tr>
        </table>

<br />
 <div align="right" style="width: 1084px"> <a title="Exportar a Excel">
               <asp:ImageButton ID="ibExcel" runat="server" Height="20px"  
         ImageUrl="~/Images/Excel-icon.png" Width="20px" Visible="False" 
         onclick="ibExcel_Click" /></a>
               </div>
 <div runat="server" id="divGrilla" ><%--style="overflow:auto;"--%>

            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" Width="1100px">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maq." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="130px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pli." ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right" SortExpression="Pliego" UniqueName="Pliego">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Planificado" HeaderText="Plani." ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Planificado" UniqueName="Planificado">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Producido" HeaderText="Prod." ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right" SortExpression="Producido" UniqueName="Producido">
                    </telerik:GridBoundColumn>

                   
                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Prep." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="MermaPreparacion" HeaderText="Merma Prep." ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="MermaPreparacion" UniqueName="MermaPreparacion">
                    </telerik:GridBoundColumn>



                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="Horas Tiraje" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="MermaTiraje" HeaderText="Merma Tiraje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="MermaTiraje" UniqueName="MermaTiraje">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Velocidad" HeaderText="V.Promedio" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Velocidad" UniqueName="Velocidad">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Uptime" HeaderText="Uptime" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Uptime" UniqueName="Uptime">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" ItemStyle-Width="100px" SortExpression="FechaInicio" UniqueName="FechaInicio">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" ItemStyle-Width="100px" SortExpression="FechaTermino" UniqueName="FechaTermino">
                    </telerik:GridBoundColumn>



                    <telerik:GridBoundColumn DataField="Operador" HeaderText="Operador" ItemStyle-Width="50px" SortExpression="Operador" UniqueName="Operador">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="VerMas" HeaderText="VerMas" ItemStyle-Width="50px" SortExpression="VerMas" UniqueName="VerMas">
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
                <div id="divErrores" runat="server" style="height:150px;overflow:auto;">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="ERRORES"></asp:Label>
&nbsp;<asp:Label ID="lblErrores" runat="server"></asp:Label>
                </div>
<%--                        <asp:Panel ID="PleaseWaitMessagePanel" runat="server" CssClass="modalPopup" Height="125px" Width="180px">
            <div class="divTitulo">Cargando Registros</div><br />
            <img src="../../Images/cargando.gif" alt="Cargando Registros. Por favor Espere..." /><br /> Por favor Espere...<br /> 
        </asp:Panel>

 <asp:Button ID="HiddenButton" runat="server" CssClass="hidden" Text="Hidden Button"
 ToolTip="Necessary for Modal Popup Extender" />
 <asp:ModalPopupExtender ID="PleaseWaitPopup" BehaviorID="PleaseWaitPopup"
 runat="server" TargetControlID="HiddenButton" PopupControlID="PleaseWaitMessagePanel"
 BackgroundCssClass="modalBackground">
 </asp:ModalPopupExtender>--%>
</asp:Content>
