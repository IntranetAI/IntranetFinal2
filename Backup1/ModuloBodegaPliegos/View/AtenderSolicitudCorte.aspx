<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="AtenderSolicitudCorte.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AtenderSolicitudCorte" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Atender(codigo) {
            location.href = 'ProcesarSolicitudCorte.aspx?id=3&Cat=10&cod=' + codigo;
          //  window.open('AsignarPliegosPopUp.aspx?id=' + id + '&ot=' + ot + '&comp=' + componente + '&solFL=' + solFL + '&solKG=' + solKG + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
    <style type="text/css">
        .style3
        {
            width: 191px;
        }
        .style4
        {
            width: 190px;
        }
        .style5
        {
            width: 235px;
        }
        .style6
        {
            width: 189px;
        }
        .style7
        {
            width: 131px;
        }
        .style8
        {
            width: 193px;
            height: 30px;
        }
        .style9
        {
            width: 221px;
        }
        .style10
        {
            width: 221px;
            height: 30px;
        }
        .style11
        {
            width: 235px;
            height: 30px;
        }
        .style12
        {
            width: 191px;
            height: 30px;
        }
        .style13
        {
            width: 131px;
            height: 30px;
        }
    </style>
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
<table style="background-color:#EEE;border:1px solid #999;margin-left:8%;border-radius:10px 10px 10px 10px; width: 950px;" 
        align="center">

        <tr>
               <td class="style9">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style5">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
            &nbsp;
                <asp:Label ID="Label11" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style9">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Descripción Papel:"></asp:Label>
               
            </td>
            <td class="style5">
               
                <asp:TextBox ID="txtPapel" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Código Papel:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
               
               </td>
            <td class="style7">
                <asp:Label ID="Label13" runat="server" Text="Folio:"></asp:Label>
                </td>
            <td class="style6">
               
                <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
               <td class="style10">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:"></asp:Label>
               
            </td>
            <td class="style11">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style12">
            &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="FechaTermino: "></asp:Label>
                </td>
            <td class="style12">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style13">
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
                                    <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" SortExpression="Folio" UniqueName="Folio">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Solicitud" ItemStyle-Width="50px" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>         
                                 <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>
                      
<%--                    <telerik:GridBoundColumn DataField="NombreOP" HeaderText="NombreOT" ItemStyle-Width="300px" SortExpression="NombreOP" UniqueName="NombreOP">
                    </telerik:GridBoundColumn>   --%>   

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>       
                    
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="340px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Pliegos" ItemStyle-Width="50px" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="80px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="40px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>--%>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate><asp:CheckBox id="chkAll3" runat="server" onclick="javascript:SelectAllCheckboxes(this);" /></HeaderTemplate>
                <ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" Checked="false"/></ItemTemplate>
              
              </telerik:GridTemplateColumn >
              
              
                                           
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
                </div>
                                <div align="center">
                    <asp:Button ID="btnRecepcionar" runat="server" Text="Procesar Seleccionados" 
                        onclick="btnRecepcionar_Click" /></div>
</asp:Content>
