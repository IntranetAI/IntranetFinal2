<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EstadisticaPartesManualesDiario.aspx.cs" Inherits="Intranet.ModuloProduccion.View.EstadisticaPartesManualesDiario" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
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
<%--            <asp:UpdatePanel ID="PleaseWaitPanel" runat="server" RenderMode="Inline">
    <ContentTemplate>--%>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />
<%--                     </ContentTemplate>
</asp:UpdatePanel>--%>
           </td>
        </tr>
    </table>
     <div id="Div1" runat="server" style="height:600px;overflow:auto;">
    <asp:Label ID="lblWeb2" runat="server">Web 2</asp:Label>
    <br />
    <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Semana" HeaderText="Semana" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="HorasTiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="HorasImproductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="MalosTiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>   --%>                             
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
                <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Goss"></asp:Label>
    <br />
    <telerik:radgrid ID="RadGrid2" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Semana" HeaderText="Semana" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="HorasTiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="HorasImproductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="MalosTiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>   --%>                             
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="CD"></asp:Label>
    <br />
    <telerik:radgrid ID="RadGrid3" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Semana" HeaderText="Semana" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="HorasTiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="HorasImproductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="MalosTiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>   --%>                             
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="4P"></asp:Label>
    <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana">
            <NoRecordsTemplate>
                <div style="text-align:center;">
                    <br />¡ No se han encontrado registros !<br /></div>
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Semana" HeaderText="Semana" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10px" 
                    SortExpression="Semana" UniqueName="Semana">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                    ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" 
                    SortExpression="Buenos" UniqueName="Buenos">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" 
                    SortExpression="Entradas" UniqueName="Entradas">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="HorasTiraje" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" 
                    SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasImproductivas" 
                    HeaderText="HorasImproductivas" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="100px" SortExpression="HorasImproductivas" 
                    UniqueName="HorasImproductivas">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasPreparacion" 
                    HeaderText="Horas Preparacion" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="100px" SortExpression="HorasPreparacion" 
                    UniqueName="HorasPreparacion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasSinTrabajo" 
                    HeaderText="Horas SinTrabajo" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="100px" SortExpression="HorasSinTrabajo" 
                    UniqueName="HorasSinTrabajo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasSinPersonal" 
                    HeaderText="Horas SinPersonal" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="100px" SortExpression="HorasSinPersonal" 
                    UniqueName="HorasSinPersonal">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HorasMantencion" 
                    HeaderText="Horas Mantencion" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="100px" SortExpression="HorasMantencion" 
                    UniqueName="HorasMantencion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" 
                    HeaderText="Malos Preparacion" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="50px" SortExpression="PliegosMalosPreparacion" 
                    UniqueName="PliegosMalosPreparacion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PliegosMalosTiraje" 
                    HeaderText="MalosTiraje" ItemStyle-HorizontalAlign="Right" 
                    ItemStyle-Width="50px" SortExpression="PliegosMalosTiraje" 
                    UniqueName="PliegosMalosTiraje">
                </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>   --%>                             
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
