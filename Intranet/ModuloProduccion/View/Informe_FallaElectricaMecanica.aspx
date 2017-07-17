<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Informe_FallaElectricaMecanica.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Informe_FallaElectricaMecanica" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Maquina:"></asp:Label>
               
            </td>
            <td class="style2">
               
                <asp:DropDownList ID="ddlSeccion" runat="server" Width="173px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="mr408">Lithoman</asp:ListItem>
                    <asp:ListItem Value="m6001">M600</asp:ListItem>
                    <asp:ListItem Value="m1016">WEB 1</asp:ListItem>
                    <asp:ListItem Value="SH102">10P</asp:ListItem>
                    <asp:ListItem Value="SH802">8P</asp:ListItem>
                    <asp:ListItem Value="SH402">4P</asp:ListItem>
                    <asp:ListItem Value="SHXL2">XL</asp:ListItem>
                    <asp:ListItem Value="C150">GOSS</asp:ListItem>
                    <asp:ListItem Value="M2016">Web 2</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
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
    <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="VerMas"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="VerMas" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="VerMas" UniqueName="VerMas">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CodMaquina" HeaderText="Clasificacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" SortExpression="CodMaquina" UniqueName="CodMaquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Left" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OT" HeaderText="Titulo" ItemStyle-Width="400px" ItemStyle-HorizontalAlign="Left" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Fecha" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="Pliego" UniqueName="Pliego">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Horas" HeaderText="Horas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="Horas" UniqueName="Horas">
                    </telerik:GridBoundColumn>
                              
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
</asp:Content>
