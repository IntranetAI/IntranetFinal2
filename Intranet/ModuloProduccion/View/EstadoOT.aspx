<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="EstadoOT.aspx.cs" Inherits="Intranet.ModuloProduccion.View.EstadoOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function openGame(OT, NombreOT) {
        window.open('DetalleOT.aspx?ot=' + OT , 'Detalle OT', 'left=160,top=100,width=1115 ,height=791,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
<script>
    function openMensajes(OT, fi, ft) {
        window.open('MensajesNoLeidos.aspx?id=' + OT + '&fi=' + fi + '&ft=' + ft, 'Mensajes No Leidos', 'left=160,top=100,width=1020 ,height=770,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div align="right" style="width: 927px" id="DivImprimir" runat="server" visible="false">
          <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Imprimir Mensajes</asp:LinkButton>
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
              ImageUrl="~/Images/print-message.jpg" Width="25px" 
              onclick="ImageButton1_Click" /></div>
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;margin-bottom:-10px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
               <div style="text-align:right;margin-top:-10px;">
                <%--<asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click"  />--%>
                    </div>
            </td>
        </tr>
        <tr>
               <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td>
                <asp:Label ID="lblTransportista" runat="server" Text="Estado: "></asp:Label>
                
            </td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" Height="18px" Width="161px">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                    <asp:ListItem Value="1">En Proceso</asp:ListItem>
                    <asp:ListItem Value="2">Liquidada</asp:ListItem>
                    <asp:ListItem Value="3">Todos los Mensajes </asp:ListItem>
                    <asp:ListItem Value="4">Mensajes No Leidos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </td>
        </tr>
    </table>
    <br />
               <div runat="server" id="divGrilla" style="height:650px;width:940px; overflow:auto;border:1px inset blue; "><%--margin-left:-25px;--%>

            <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                 <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" UniqueName="NumeroOT" ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn><%--<a title='Total de Mensajes'>--%>
                <telerik:GridBoundColumn DataField="mensajeNuevos" HeaderText="<img src='../../Images/mensajeria.png' height='20' width='20' />" ItemStyle-Width="10px" SortExpression="mensajeNuevos" UniqueName="mensajeNuevos">
                </telerik:GridBoundColumn>
                <%--<a title='Nuevos Mensajes'>--%>
                <telerik:GridBoundColumn DataField="mensajeLeido" HeaderText="<img src='../../Images/mensajeria-intento.png' height='20' width='20' />" ItemStyle-Width="10px" SortExpression="mensajeLeido" UniqueName="mensajeLeido">
                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="mensajeAdjunto" HeaderText="<a title='Documentos Adjuntos'><img src='../../Images/PaperClip3_Black.png' height='20' width='20' /></a>" ItemStyle-Width="10px" SortExpression="mensajeAdjunto" UniqueName="mensajeAdjunto">
                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="ejem" HeaderText="Tiraje" 
                            UniqueName="Ejemplares" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="StatusOV" HeaderText="Estado OTs" AllowSorting="false"
                            UniqueName="StatusOV" ItemStyle-Width="120px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CantidadMensaje" Visible="false" HeaderText="Mail" ItemStyle-Width="30px" SortExpression="CantidadMensaje" UniqueName="CantidadMensaje">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaPro" HeaderText="Fecha Entrega" ItemStyle-Width="130px" SortExpression="FechaPro" UniqueName="FechaOT"  DataFormatString="{0:dd/MM/yyyy HH:mm}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Despacho" HeaderText="Lib." ItemStyle-Width="30px" SortExpression="Despacho" UniqueName="Despacho">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NivelCumpli" HeaderText="F.E. Ok" ItemStyle-Width="25px" SortExpression="NivelCumpli" UniqueName="NivelCumpli">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="" ItemStyle-Width="50px" SortExpression="Usuario" UniqueName="Usuario">
                            </telerik:GridBoundColumn>
                          <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                            <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Seleccionar</asp:LinkButton></ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>

                </div>
       
</asp:Content>
