<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="HorasImproductivas.aspx.cs" Inherits="Intranet.ModuloProduccion.View.HorasImproductivas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function openGame(OT, NombreOT) {
        window.open('DetallePliegos.aspx?ot=' + OT + '&pl=' + NombreOT, 'Detalle OT', 'left=20,top=100,width=1200 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
    <style type="text/css">
        .style2
        {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<table align="center" width="885px" style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:95px;border-radius:10px 10px 10px 10px;">
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label9" runat="server" Text="Operación:"></asp:Label>

            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlOperacion" runat="server" Width="153px">
                </asp:DropDownList>

            </td>
            <td class="style20">
                <asp:Label ID="Label11" runat="server" Text="Seccion:"></asp:Label>
                </td>
            <td class="style11">
                <asp:DropDownList ID="ddlSeccion" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlSeccion_SelectedIndexChanged" style="height: 22px" 
                    Width="153px">
                </asp:DropDownList>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style13">
                <asp:Label ID="Label10" runat="server" Text="Maquina:"></asp:Label>
                </td>
            <td>
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="153px">
                </asp:DropDownList>
            </td>
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
            <td class="style2">
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
            &nbsp;<asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
              


  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <a title="Orden Descendiente">
                                    &nbsp;
                                    </a>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
        onclick="ibExcel_Click" Visible="False" 
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
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="true"   onsortcommand="RadGrid1_SortCommand" >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina"  UniqueName="Maquina" ItemStyle-Width="120px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="OT" HeaderText="Operacion"  UniqueName="OT" ItemStyle-Width="120px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Horas"  UniqueName="NombreOT" ItemStyle-Width="120px"  >
                </telerik:GridBoundColumn>               
                    
                <telerik:GridBoundColumn DataField="VerMas" HeaderText="VerMas"  AllowSorting="false" UniqueName="VerMas" ItemStyle-Width="60px"  >
                </telerik:GridBoundColumn>        
                
                
                
                              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
              &nbsp;</div>
</asp:Content>
