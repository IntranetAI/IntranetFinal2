<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EstadosOT.aspx.cs" Inherits="Intranet.ModuloDespacho.View.EstadosOT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp"  %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script  type="text/javascript" language="javascript">
         function SelectAllCheckboxes(spanChk) {

             // Added as ASPX uses SPAN for checkbox
             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }
         }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<table align="center" width="960px" style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:95px;border-radius:10px 10px 10px 10px;">
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label>
           
            </td>
            <td class="style13">
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style6">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" >
                </asp:CalendarExtender>
               
            </td>
            <td class="style20">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server"  Animated="true"
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
                <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
           
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlEstado" runat="server" Width="163px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="A">En Proceso</asp:ListItem>
                    <asp:ListItem>Por Liquidar</asp:ListItem>
                    <asp:ListItem Value="E">Liquidada</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td>
<asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
    
            </td>
        </tr>
        </table>
        <div runat="server" id="divbotones"  style="text-align:right;margin-bottom:1px;width:1087px;" >
            &nbsp;

            <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <a title="Liquidar OT">
                <asp:ImageButton ID="btnLiquidar" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Liquidar.png" Width="20px" onclick="btnLiquidar_Click" 
                   />
                <asp:Label ID="Label1" runat="server" Text="Label">Liquidar</asp:Label>
            </a>
  


  &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
        onclick="ibExcel_Click" 
                   />
                   </a>
               &nbsp;&nbsp;&nbsp; <a title="Atrás" href="javascript:history.go(-1)"> 
                   <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Images/Atras-icon.png" Height="20px" Width="20px" />
</a> 


       </div>

   <div runat="server" id="divGrillaGuias" visible="true"  style="height:545px;width:1100px; overflow:auto;" >
          
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT" ItemStyle-Width="150px"  >
                </telerik:GridBoundColumn>

<%--                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" UniqueName="Cliente" ItemStyle-Width="180px"  >
                </telerik:GridBoundColumn>--%>

                <telerik:GridBoundColumn DataField="FechaMinima" HeaderText="Primer Despacho" ItemStyle-HorizontalAlign="Center"  UniqueName="FechaMinima" ItemStyle-Width="100px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="FechaMaxima" HeaderText="Ultimo Despacho" ItemStyle-HorizontalAlign="Center"  UniqueName="FechaMaxima" ItemStyle-Width="100px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT" UniqueName="Tiraje"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Recepcionado"  HeaderText="Total Recepcionado" ItemStyle-Width="30px" UniqueName="Recepcionado"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Despachado" ItemStyle-Width="30px" UniqueName="Despachado"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                



                <telerik:GridBoundColumn DataField="DevolucionCliente" HeaderText="Devolucion" SortExpression="DevolucionCliente" UniqueName="DevolucionCliente" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Especiales" HeaderText="Especiales" SortExpression="Especiales" UniqueName="Especiales" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

<%--                <telerik:GridBoundColumn Visible="false" DataField="Saldo"  HeaderText="Cliente" SortExpression="Cliente" UniqueName="Cliente"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                </telerik:GridBoundColumn>--%>


                <telerik:GridBoundColumn DataField="Saldo" HeaderText="SaldoEnc" SortExpression="Saldo" UniqueName="Saldo"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                </telerik:GridBoundColumn>
                                
                <telerik:GridBoundColumn DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" UniqueName="Existencia"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado" ItemStyle-Width="70px">
                </telerik:GridBoundColumn>


                
              <telerik:GridTemplateColumn UniqueName="TemplateColumn" ItemStyle-Width="10px">
                <HeaderTemplate>
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >



              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
              </div>
</asp:Content>
