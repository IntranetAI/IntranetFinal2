<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Control_Wip.aspx.cs" Inherits="Intranet.Wip.View.Control_Wip" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 10px;
        }
        .style4
        {
        }
        .style5
        {
            width: 217px;
        }
        .style10
        {
            width: 126px;
        }
        .style12
        {
            width: 219px;
        }
        .style17
        {
            width: 254px;
        }
        .style19
        {
            width: 212px;
        }
        .style20
        {
            width: 217px;
        }
        .style21
        {
            width: 215px;
        }
        .style25
        {
            width: 128px;
        }
        .style26
        {
            width: 125px;
        }
        .style27
        {
            width: 126px;
        }
        .style28
        {
            width: 215px;
        }
        .style29
        {
            width: 125px;
        }
        .style30
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<asp:Panel ID="pnlResultado" runat="server" Width="1095px">
            
                   <table style="width:82%;">
                       <tr>
                           <td class="style17">
                               &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                           <td>
                               <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Numero OT:"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
                               &nbsp;&nbsp;<asp:Button ID="btnFiltro" runat="server" 
                                   Text="Buscar" onclick="btnFiltro_Click" />
                               &nbsp;&nbsp;
                               <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                           </td>
                       </tr>
                   </table>
              
             
               <asp:Panel ID="pnlError" runat="server" Visible="False">
                   <div align="center" id="DivError" runat="server">
                       <asp:Image ID="imgError" runat="server" />
                       <asp:Label ID="lblError" runat="server"></asp:Label>
                   </div>
               </asp:Panel>

    <asp:Panel ID="pnlDatosOT" runat="server" Visible="False">
    
    <fieldset style="margin-left:35px;margin-right:35px;">
    <legend>Datos OT</legend>
     <table style="width:100%;">
         <tr>
             <td class="style5">
                 </td>
             <td class="style10">
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
             </td>
             <td colspan="5" class="style4">
                 <asp:Label ID="txtNombreOT" runat="server" Font-Bold="True"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="style20">
                 &nbsp;</td>
             <td class="style27">
                 <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Cliente:"></asp:Label>
             </td>
             <td class="style12">
                 <asp:Label ID="lblCliente" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
          <tr>
             <td class="style20">
                 &nbsp;</td>
             <td class="style27">
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
             </td>
             <td colspan="2">
                 <asp:Label ID="txtTotal" runat="server"></asp:Label>
             </td>
             <td colspan="3">
                 &nbsp;</td>
         </tr>
         
    </table>
    </fieldset>
</asp:Panel>

                <%--  <asp:Label ID="Label11" runat="server" Text="Detalle OT - Pallet"></asp:Label>
                   &nbsp;<asp:Label ID="lblCodigoGrid" runat="server" Font-Bold="True"></asp:Label>--%>
                   <asp:Panel ID="pnlDatosMaquina" runat="server" Visible="False">
                       <fieldset style="margin-left:35px;margin-right:35px;">
                           <legend>Origen/ Destino Pallet</legend>
                           <table style="width:99%;">
                               <tr>
                                   <td class="style28">
                                       </td>
                                   <td class="style29">
                                       <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Pliego Multiples:"></asp:Label>
                                   </td>
                                   <td colspan="2" class="style30">
                                       <asp:CheckBox ID="cbxPliegoMult" runat="server" Text="Si" AutoPostBack="True" 
                                           oncheckedchanged="cbxPliegoMult_CheckedChanged" />
                                   </td>
                                   <td class="style30">
                                       </td>
                               </tr>
                               <tr>
                                   <td class="style21">
                                   </td>
                                   <td class="style26">
                                       <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Rotativa:"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:RadioButton ID="rbSi" runat="server" AutoPostBack="True" 
                                           GroupName="Rotativa" oncheckedchanged="Si_CheckedChanged" Text="SI" />
                                       &nbsp;<asp:RadioButton ID="rbNO" runat="server" AutoPostBack="True" 
                                           GroupName="Rotativa" oncheckedchanged="rbNO_CheckedChanged" Text="NO" />
                                       <%-- &nbsp;<asp:RadioButton ID="rbServicio" runat="server" AutoPostBack="True" 
                     GroupName="Rotativa" Text="Servicio Externo" />--%>
                                   </td>
                                   <td>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="style21">
                                       &nbsp;</td>
                                   <td class="style26">
                                       <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Maquina:"></asp:Label>
                                   </td>
                                   <td colspan="2">
                                       <asp:DropDownList ID="ddlMaquina" runat="server" Width="155px" 
                                           AutoPostBack="True" onselectedindexchanged="ddlMaquina_SelectedIndexChanged">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       &nbsp;</td>
                               </tr>
                               <tr>
                                    <td class="style28">
                                        &nbsp;</td>
                                    <td class="style29">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Destino:"></asp:Label>
                                    </td>
                                    <td style="margin-left: 80px">
                                        <asp:DropDownList ID="ddlDestino" runat="server">
                                            <asp:ListItem Value="1">Almacenamiento Wip</asp:ListItem>
                                            <asp:ListItem Value="2">Servicio Externo</asp:ListItem>
                                            <asp:ListItem Value="3">Directo a Encuadernacion</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                           </table>
                       </fieldset>
                   </asp:Panel>
    <asp:Panel ID="pnlDatosPallet" runat="server" Visible="False">
<fieldset style="margin-left:35px;margin-right:35px;">
<legend>Datos Pallet</legend>
    <table style="width:100%;">
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Pliego Programado:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProgramado" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlPliego_SelectedIndexChanged" Width="155px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Nombre Pliego:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPliego" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlPliego_SelectedIndexChanged" Width="155px">
                </asp:DropDownList>
                &nbsp;
                <asp:Label ID="Label24" runat="server"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="cbxNPliegNew" runat="server" AutoPostBack="True" 
                    oncheckedchanged="cbxNPliegNew_CheckedChanged" Text="Cambiar Nombre Pliego" />
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" 
                    Text="Tipos de Pliegos:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTipoPallet" runat="server" Visible="False">
                    <asp:ListItem Value="1">Pliego Normal</asp:ListItem>
                    <asp:ListItem Value="2">Pliego Especial</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:Label ID="lblNew_Pliego" runat="server" Text="Nuevo Nombre Pliego :" 
                    Visible="False"></asp:Label>
                <asp:TextBox ID="txtPliego_new" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" 
                    Text="Tiraje del Pliego:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTirajePliego" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Forma:" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtForma" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Tarea:" 
                    Visible="False"></asp:Label>
                <asp:Label ID="txtTarea" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="lblEjemplares" runat="server" Font-Bold="True" 
                    Text="Pliegos Impresos: " Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEjemplares" runat="server" Visible="False"></asp:TextBox>
                &nbsp;<asp:Label ID="lblRes" runat="server" ForeColor="Red" 
                    Text="* Pliegos Restantes: " Visible="False"></asp:Label>
                <asp:Label ID="lblRestantes" runat="server" Visible="False"></asp:Label>
                .</td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="lblCantidad" runat="server" Font-Bold="True" Text="Peso:" 
                    Visible="False"></asp:Label>
            </td>
            <td style="margin-left: 80px">
                <asp:TextBox ID="txtCantidad" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        
    </table>
</fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlDatosPallet2" runat="server" Visible="False">
<fieldset style="margin-left:35px;margin-right:35px;">
<legend>Datos Pallet</legend>
    <table style="width:100%;">
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Pliego Programado:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPlProg" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlPliego_SelectedIndexChanged" Width="155px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Nombre Pliego:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPliego2" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlPliego_SelectedIndexChanged" Width="155px">
                </asp:DropDownList>
                &nbsp;
                <asp:Label ID="Label25" runat="server"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="cbxNPliegNew1" runat="server" AutoPostBack="True" 
                    oncheckedchanged="cbxNPliegNew1_CheckedChanged" Text="Cambiar Nombre Pliego" />
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                    Text="Tipos de Pliegos:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTipoPallet2" runat="server" Visible="False">
                    <asp:ListItem Value="1">Pliego Normal</asp:ListItem>
                    <asp:ListItem Value="2">Pliego Especial</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:Label ID="lblNew_Pliego1" runat="server" Text="Nuevo Nombre Pliego :" 
                    Visible="False"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtPliego_new1" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" 
                    Text="Tiraje del Pliego:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTirajePliego2" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Forma:" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtForma2" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Tarea:" 
                    Visible="False"></asp:Label>
                <asp:Label ID="txtTarea2" runat="server" Font-Bold="False" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label20" runat="server" Font-Bold="True" 
                    Text="Pliegos Impresos: " Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEjemplares2" runat="server" Visible="False"></asp:TextBox>
                &nbsp;<asp:Label ID="Label21" runat="server" ForeColor="Red" 
                    Text="* Pliegos Restantes: " Visible="False"></asp:Label>
                <asp:Label ID="lblRestantes2" runat="server" Visible="False"></asp:Label>
                .</td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style25">
                <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Peso:" 
                    Visible="False"></asp:Label>
            </td>
            <td style="margin-left: 80px">
                <asp:TextBox ID="txtCantidad2" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="btnAgregar0" runat="server" Text="Agregar" 
                    onclick="btnAgregar0_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan ="3" >
                <div align="center">

                    <telerik:RadGrid ID="RadGridOT" runat="server" BorderWidth="0px" 
                        GridLines="None" Skin="Outlook">
                        <ClientSettings  EnableRowHoverStyle="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                            <NoRecordsTemplate>
                                <div style="text-align:center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br /></div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" 
                                    SortExpression="OT" UniqueName="OT">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliegos" 
                                    SortExpression="Pliego" UniqueName="Pliego">
                                    <ItemStyle Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Pliego Impresos" 
                                    UniqueName="Pliegos_Impresos">
                                    <ItemStyle Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Tarea" HeaderText="Tarea" 
                                    UniqueName="Tarea">
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Forma" HeaderText="Forma" ReadOnly="True" 
                                    SortExpression="Forma" UniqueName="Forma">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalTiraje" HeaderText="Tiraje" 
                                    ReadOnly="True" SortExpression="TotalTiraje" UniqueName="TotalTiraje">
                                    <ItemStyle Width="80px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                            EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>

                </div></td>
        </tr>
        
    </table>
</fieldset>
    </asp:Panel>

                   <div ID="DivMensaje" runat="server" align="center">
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="imgMensaje" runat="server" />
                       &nbsp;
                       <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                   </div>
     <br />
     
   

    <div align="center">
            <asp:Button ID="btnCerrarPallet" runat="server" Text="Crear Pallet" 
                onclick="btnCerrarPallet_Click" Visible="False" 
                />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnImprimir" runat="server"  
                Text="Imprimir" Visible="False" Width="89px" onclick="btnImprimir_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Nuevo Registro" 
                onclick="Button1_Click" Visible="False" />
   </div>      
    <br />
    </asp:Panel>
</asp:Content>

