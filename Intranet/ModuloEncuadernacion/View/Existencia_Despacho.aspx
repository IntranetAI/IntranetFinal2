<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Existencia_Despacho.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.Existencia_Despacho" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
    <h3 style="color: rgb(23, 130, 239);">Existencia Despacho</h3>
</div>--%>

<table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:18px;border-radius:10px 10px 10px 10px;" 
            align="center" width="890px" >
        <tr>
            <td class="style9" >
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label3" runat="server" Text="OP:"></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtOP" runat="server"></asp:TextBox>
               
            &nbsp;&nbsp;
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre OP: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreOP" runat="server"></asp:TextBox>

            </td>
            <td class="style14">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" 
                    Text="Cliente: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCliente" 
                    runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="MM-dd-yyyy">
                </asp:CalendarExtender>
               
            &nbsp;
               
            </td>
            <td class="style13">
                &nbsp;
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="MM-dd-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14" >
            <div style="margin-left:17px;" >
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
            </td>
        </tr>
        </table>
    <asp:Panel ID="pnlRegistros" runat="server">
    
        <br />
        <br />
            <div runat="server" id="div1" 
            style="text-align:right;margin-bottom:1px;width:928px; margin-top:-20px;" >
   <a title="Actualizar OTs Nuevas">
        <a title="Exportar a PDF">
                <asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
                   Visible="False" onclick="ibPDF_Click"  />
                   </a>
                      &nbsp;&nbsp;
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
            onclick="ibExcel_Click" />
                   </a>&nbsp;&nbsp; <a title="Atrás" href="javascript:history.go(-1)"> 
                   <asp:Image ID="Image2" runat="server" 
        ImageUrl="~/Images/Atras-icon.png" Height="20px" Width="20px" />
</a> 


       </div>
    <%--style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-4px;border-radius:10px 10px 10px 10px;"--%>
<div style="border:1px solid blue;Width:947px;overflow:scroll;margin-left:-10px;" > 
    <telerik:RadGrid ID="RadGrid2" runat="server" BorderWidth="0px"      Skin="Outlook"
                 Height="490px"  class="total" OnItemCommand="contactsGrid_ItemCommand"  
             ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true" >
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate>
                <div style="text-align:center;">
                    <br />¡ No se han encontrado registros !<br /></div>
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>

                <telerik:GridBoundColumn  DataField="OT" HeaderText="OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20px" 
                    SortExpression="OT" UniqueName="OT">
                </telerik:GridBoundColumn>      

                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                </telerik:GridBoundColumn>      


                
             
                <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="40px" 
                    SortExpression="Tiraje" UniqueName="Tiraje">
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn   DataField="RecibidoQGChile" HeaderText="Total Recepcionado" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="40px" 
                    SortExpression="RecibidoQGChile" UniqueName="RecibidoQGChile">
                </telerik:GridBoundColumn>  

                <telerik:GridBoundColumn   DataField="DespachoEnc" HeaderText="Total Despachado" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="40px" 
                    SortExpression="DespachoEnc" UniqueName="DespachoEnc">
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn   DataField="Muestras" HeaderText="Muestras" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20px" 
                    SortExpression="Muestras" UniqueName="Muestras">
                </telerik:GridBoundColumn>  

                <telerik:GridBoundColumn   DataField="Sobrante" HeaderText="Sobrante" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10px" 
                    SortExpression="Sobrante" UniqueName="Sobrante">
                </telerik:GridBoundColumn>  

                <telerik:GridBoundColumn  DataField="id_ProductosTerminados" HeaderText="Devolucion" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10px" 
                    SortExpression="id_ProductosTerminados" UniqueName="id_ProductosTerminados">
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn  DataField="Saldo" HeaderText="Existencia" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10px" 
                    SortExpression="Saldo" UniqueName="Saldo">
                </telerik:GridBoundColumn>  


                              <telerik:GridBoundColumn  DataField="Terminacion" HeaderText="Estado" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                </telerik:GridBoundColumn>  

             

            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>

</div>
    <br />
    </asp:Panel>
</asp:Content>
