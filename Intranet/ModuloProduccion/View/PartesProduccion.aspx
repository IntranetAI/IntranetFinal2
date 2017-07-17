<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="PartesProduccion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.PartesProduccion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function openGame(OT, NombreOT) {
        window.open('DetallePliegos.aspx?ot=' + OT + '&pl=' + NombreOT, 'Detalle OT', 'left=20,top=100,width=1200 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<table align="center" width="885px" style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:95px;border-radius:10px 10px 10px 10px;">
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server" AutoPostBack="True" 
                    ontextchanged="txtNumeroOT_TextChanged"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label8" runat="server" Text="Pliegos:"></asp:Label>
                </td>
            <td class="style11">
                <asp:DropDownList ID="ddlPliegos" runat="server" Width="153px" 
                    onselectedindexchanged="ddlPliegos_SelectedIndexChanged">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="30">Rotativas</asp:ListItem>
                    <asp:ListItem Value="31">Planas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label9" runat="server" Text="Cliente:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtCliente" runat="server" Font-Names="Arial"></asp:TextBox>

            </td>
            <td class="style20">
                <asp:Label ID="Label10" runat="server" Text="Maquina:"></asp:Label>
                </td>
            <td class="style11">
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="153px">
                </asp:DropDownList>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
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

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
           
                </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
<asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
    
            </td>
        </tr>
        </table>
        <br />
        <div runat="server" id="divbotones" 
        
        style="text-align:right;margin-bottom:1px;width:1087px; margin-top:-20px;" >
            &nbsp;

            <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
              


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

   <div runat="server" id="divGrillaGuias" visible="true" 
                       style="height:550px;width:1090px; overflow:auto;" >
                       <%--grilla guias de QGCHILE--%>
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT" ItemStyle-Width="190px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Cliente" Visible="false" HeaderText="Cliente" UniqueName="Cliente" ItemStyle-Width="130px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="TirajeOT" HeaderText="Tiraje" UniqueName="TirajeOT" ItemStyle-Width="20px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Forma" Visible="false" HeaderText="Forma" UniqueName="Forma" ItemStyle-Width="20px"  >
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="Pliegos" HeaderText="Pliego" UniqueName="Pliegos" ItemStyle-Width="20px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" UniqueName="Maquina" ItemStyle-Width="100px"  >
                </telerik:GridBoundColumn>

                
                 <telerik:GridBoundColumn DataField="Malos_Arranque" HeaderText="Malos Arranque" UniqueName="Malos_Arranque" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>   

                <telerik:GridBoundColumn DataField="Giros_Buenos" HeaderText="Giros Buenos" UniqueName="Giros_Buenos" ItemStyle-Width="20px"  >
                 <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" UniqueName="Buenos" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>
                

                <telerik:GridBoundColumn DataField="Malos" HeaderText="Malos Tiraje" UniqueName="Malos" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>           
                
     

                <telerik:GridBoundColumn DataField="Fecha_Inicio" HeaderText="Fecha_Inicio" UniqueName="Fecha_Inicio" ItemStyle-Width="100px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>   

                <telerik:GridBoundColumn DataField="Fecha_Fin" HeaderText="Fecha_Fin" UniqueName="Fecha_Fin" ItemStyle-Width="100px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>     
                
                
                <telerik:GridBoundColumn DataField="VerMas" HeaderText="Detalle" UniqueName="VerMas" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>           
                              
                    
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
              </div>
</asp:Content>
