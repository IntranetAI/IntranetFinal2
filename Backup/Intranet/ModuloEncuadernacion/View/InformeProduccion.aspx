<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformeProduccion.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InformeProduccion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 115px;
        }
        .style3
        {
            width: 5px;
        }
        .style4
        {
            width: 32px;
        }
        .style5
        {
            width: 13px;
        }
        .style6
        {
            width: 12px;
        }
        .style7
        {
            width: 212px;
        }
        .style8
        {
            width: 118px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<table class="filtering" align="center" width="885px" style="border-radius:10px 10px 10px 10px;margin-left:20px;margin-top:6px;">
        <tr>
            <td class="style5">
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

                </td>
            <td class="style20">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Fecha Inicio: "></asp:Label>

                </td>
            <td class="style11">
                                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>

            </td>
            <td class="style6">
                &nbsp;&nbsp;&nbsp;
           
            </td>
            <td class="style8" style="margin-left: 40px">
                <asp:Label ID="Label6" runat="server" Text="Fecha Termino:"></asp:Label>
                </td>
            <td class="style7">
               <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
               
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
            </td>
        </tr>
        </table>
        <br />
        <br />
        <div align="right" style="width: 922px"> 
            <asp:ImageButton ID="ibExcel" runat="server" ImageUrl="~/Images/Excel-icon.png" 
                onclick="ibExcel_Click" Width="25px" /></div>
                 <div style="height:500px;width:930px; overflow:auto;border:1px inset blue;" >
                    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" Height="300px" 

                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="220px">
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-HorizontalAlign="Center" 
                                ReadOnly="True" SortExpression="Pliego" UniqueName="Pliego" ItemStyle-Width="40px">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Forma" HeaderText="Forma" SortExpression="Forma" 
                                UniqueName="Forma" ItemStyle-Width="20px">
                                </telerik:GridBoundColumn>
                               
                            


                            <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                            UniqueName="Maquina" ItemStyle-Width="100px">
                            </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" 
                            UniqueName="Buenos" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" 
                            UniqueName="FechaInicio" ItemStyle-Width="115px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
                           <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" 
                            UniqueName="FechaTermino" ItemStyle-Width="115px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>       
                            
                              <telerik:GridBoundColumn DataField="Operacion" HeaderText="Operacion" 
                            UniqueName="Operacion" ItemStyle-Width="190px">
                            </telerik:GridBoundColumn>
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              </div>
</asp:Content>
