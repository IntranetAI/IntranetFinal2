<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Wip_EtiquetaMult.aspx.cs" Inherits="Intranet.ModuloWip.View.Wip_EtiquetaMult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center">
                       <tr>
                           <td>
                               <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Numero OT:"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
                               &nbsp;&nbsp;<asp:Button ID="btnFiltro" runat="server" 
                                   Text="Buscar" onclick="btnFiltro_Click" />
                           </td>
                       </tr>
                   </table>
              
             
               <asp:Panel ID="pnlError" runat="server" Visible="False">
                   <div align="center" id="DivError" runat="server">
                       <asp:Image ID="imgError" runat="server" />
                       <asp:Label ID="lblError" runat="server"></asp:Label>
                   </div>
               </asp:Panel>

    <asp:Panel ID="pnlDatosOT" runat="server" Visible="false">
    
    <fieldset style="margin-left:35px;margin-right:35px;">
    <legend>Datos OT</legend>
     <table align="center">
         <tr>
             <td class="style10">
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
             </td>
             <td colspan="5" class="style4">
                 <asp:Label ID="txtNombreOT" runat="server" Font-Bold="True"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="style27">
                 <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Cliente:"></asp:Label>
             </td>
             <td class="style12">
                 <asp:Label ID="lblCliente" runat="server"></asp:Label>
             </td>
         </tr>
          <tr>
             <td class="style27">
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
             </td>
             <td colspan="2">
                 <asp:Label ID="txtTotal" runat="server"></asp:Label>
             </td>
             
         </tr>
         
    </table>
    </fieldset>
</asp:Panel>

                <%--  <asp:Label ID="Label11" runat="server" Text="Detalle OT - Pallet"></asp:Label>
                   &nbsp;<asp:Label ID="lblCodigoGrid" runat="server" Font-Bold="True"></asp:Label>--%>
                   <asp:Panel ID="pnlDatosMaquina" runat="server" Visible="false">
                       <fieldset style="margin-left:35px;margin-right:35px;">
                           <legend>Origen/ Destino Pallet</legend>
                           <table align="center">
                               <tr>
                                   <td class="style26">
                                       <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Maquina:"></asp:Label>
                                   </td>
                                   <td colspan="2">
                                       <asp:DropDownList ID="ddlMaquina" runat="server" Width="155px" 
                                           AutoPostBack="True" onselectedindexchanged="ddlMaquina_SelectedIndexChanged">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
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
                                <table align="center">
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Nombre Pliego:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPliego" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlPliego_SelectedIndexChanged" Width="155px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblTarea" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblForma" runat="server" Text="" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Tiraje Pliego:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTirajeFinal" runat="server" AutoPostBack="True" 
                                                ontextchanged="txtTirajeFinal_TextChanged"></asp:TextBox>
                                            <asp:Label ID="lblCantidadEti" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblTirajeEti" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblTirajeEtiF" runat="server" Text="" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Cantidad por Paquete:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaquete" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Cantidad Base:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBase" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Cantidad Altura:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAltura" runat="server" AutoPostBack="True" 
                                                ontextchanged="txtAltura_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Peso Inicial:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPesoIni" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Peso Final:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPesoFin" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                </asp:Panel>
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

</asp:Content>

