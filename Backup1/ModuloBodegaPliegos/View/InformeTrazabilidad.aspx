<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeTrazabilidad.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.InformeTrazabilidad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="background-color:#EEE;border:1px solid #999;margin-left:5%;border-radius:10px 10px 10px 10px; width: 800px;" 
        align="center">

        <tr>
               <td class="style9">
                   &nbsp;</td>
               <td class="style9">
                   &nbsp;</td>
               <td class="style9">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style5">
               
                <asp:TextBox ID="txtOT" runat="server" AutoPostBack="True" 
                    ontextchanged="txtOT_TextChanged"></asp:TextBox>
               
               </td>
            <td class="style4">
            &nbsp;
                <asp:Label ID="Label12" runat="server" Text="Componente"></asp:Label>
                </td>
            <td class="style4">
               
                <asp:DropDownList ID="ddlComponente" runat="server" Width="173px">
                </asp:DropDownList>
               </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style9">
                   &nbsp;</td>
               <td class="style9">
                   &nbsp;</td>
               <td class="style9">
                   <asp:Label ID="Label11" runat="server" Text="Codigo Pallet:"></asp:Label>
               
            </td>
            <td class="style5">
               
                <asp:TextBox ID="txtFolioPallet" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
               
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        </table>

        <br />
        <div style="height:500px;width:1095px; overflow:auto;" >
        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="Proceso" UniqueName="Proceso">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="NroPallet" HeaderText="Folio" ItemStyle-Width="70px" SortExpression="NroPallet" UniqueName="NroPallet">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>
                      
                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>       
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="SKU" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="340px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>
<%--
                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    --%>

                    <telerik:GridBoundColumn DataField="Pliegos" HeaderText="Pliegos" ItemStyle-Width="50px" SortExpression="Pliegos" UniqueName="Pliegos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Kilos" HeaderText="Peso" ItemStyle-Width="50px" SortExpression="Kilos" UniqueName="Kilos">        
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CostoMedio" HeaderText="Costo Medio" ItemStyle-Width="50px" SortExpression="CostoMedio" UniqueName="CostoMedio">
                    </telerik:GridBoundColumn>   
                    
                    <telerik:GridBoundColumn DataField="Usuario" HeaderText="Usuario" ItemStyle-Width="50px" SortExpression="Usuario" UniqueName="Usuario">
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Consumo" ItemStyle-Width="50px" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
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
</asp:Content>
