<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeDespachosDiarios.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformeDespachosDiarios" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </script>
     <style type="text/css">
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
            background-color: #EEE;
        }
        .Grilla
        {
          
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
        }
         .style1
         {
             height: 34px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="filtering" align="center" width="885px" style="border-radius:10px 10px 10px 10px;margin-left:20px;margin-top:6px;">
        <tr>
            <td class="style5">
                </td>
            <td class="style20">
               
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style6">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
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
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <div style="text-align:right;margin-top:-40px;">
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style1">
               
                <asp:Label ID="Label3" runat="server" Text="Ordenar Por:"></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:DropDownList ID="ddlOrdernar" runat="server" Width="153px">
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem Value="Guias">N° Guias</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Estado:"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="ddlEstado" runat="server" Width="153px">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem Value="2">Vigente</asp:ListItem>
                    <asp:ListItem Value="3">Anulado</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style1" colspan="2">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
                &nbsp;&nbsp;&nbsp;
                
           
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                    Visible="False" />
                
           
                &nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Excel" 
                    Visible="False" />
                &nbsp;
            <%-- <a href="javascript:history.go(-1)">Atrás</a>--%>
                
           
                </td>
        </tr>
    </table>
    <br />
    <div runat="server" id="divbotones" 
        style="text-align:right;margin-bottom:1px;width:931px; margin-top:-20px;" >
   <a title="Actualizar OTs Nuevas">
   <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
        onclick="ibExcel_Click" Visible="False" 
                   />
                   </a>
               &nbsp;<asp:Label ID="lblExcel" runat="server" Text="Exportar a Excel." 
            Visible="False"></asp:Label>
        &nbsp;&nbsp;  


       </div>



             <div style="height:500px;width:930px; overflow:auto;border:1px inset blue;" >
                    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" Height="300px" 
                   
                                   ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true"
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>
                               
                               
                               <telerik:GridBoundColumn DataField="Guias" HeaderText="N° Guia" SortExpression="Guias" 
                                UniqueName="Guias" ItemStyle-Width="40px">
                                </telerik:GridBoundColumn>



                            
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                            UniqueName="NombreOT" ItemStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            

                              <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" 
                                UniqueName="Cliente" ItemStyle-Width="220px">
                                </telerik:GridBoundColumn>


                           <telerik:GridBoundColumn DataField="FechaDespacho" HeaderText="Fecha Despacho" 
                            UniqueName="FechaDespacho" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                            UniqueName="Estado" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>

              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              </div>
</asp:Content>
