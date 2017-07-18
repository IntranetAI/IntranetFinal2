<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeEstadoGuias.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InformeEstadoGuias" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style2">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
            </td>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
               </td>
            <td class="style2">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
               <td class="style4">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style4">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style4">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style4">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

           </td>
        </tr>
    </table>
    <br />
         <div runat="server" id="divbotones" style="text-align:right; width: 1059px;" >

               <a title="Exportar a Excel"><asp:ImageButton ID="ibExcel" runat="server" Height="20px" 
                      ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    onclick="ibExcel_Click" />
                </a>

                </div>
     <div style="border:1px solid blue;height:500px;Width:1087px; overflow:scroll;" >

    <telerik:RadGrid ID="RadGrid1"  runat="server" BorderWidth="0px"  Skin="Outlook" >

        <MasterTableView AutoGenerateColumns="False" DataKeyNames="NroPallet">
            <NoRecordsTemplate>
                <div style="text-align:center;">
                    <br />¡ No se han encontrado registros !<br /></div>
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                            <telerik:GridBoundColumn DataField="NroPallet" HeaderText="NroPallet" ItemStyle-Width="40px" ReadOnly="True" SortExpression="NroPallet" UniqueName="NroPallet">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ReadOnly="True" SortExpression="OT" UniqueName="OT">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                </telerik:GridBoundColumn>      

                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  
                
             
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="TipoEmbalaje" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="TipoEmbalaje" UniqueName="TipoEmbalaje">
                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Cantidad" UniqueName="Cantidad">
                  <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>  


                <telerik:GridBoundColumn   DataField="Ejemplares" HeaderText="Ejemplares" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Ejemplares" UniqueName="Ejemplares">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px" 
                    SortExpression="Total" UniqueName="Total">
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>  



                <telerik:GridBoundColumn DataField="Modelo" HeaderText="Modelo" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170px" 
                    SortExpression="Modelo" UniqueName="Modelo">
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  
                 
                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" 
                    SortExpression="Observacion" UniqueName="Observacion">
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </telerik:GridBoundColumn> 
                                <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="110px" 
                    SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </telerik:GridBoundColumn> 

                                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px" 
                    SortExpression="Estado" UniqueName="Estado">
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
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
</asp:Content>
