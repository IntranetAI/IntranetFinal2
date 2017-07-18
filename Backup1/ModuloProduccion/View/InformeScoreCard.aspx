<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeScoreCard.aspx.cs" Inherits="Intranet.ModuloProduccion.View.InformeScoreCard" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />

<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Area:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True"  
                    Width="173px" onselectedindexchanged="ddlArea_SelectedIndexChanged">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem Value="IMP ROT">Rotativas</asp:ListItem>
                    <asp:ListItem Value="IMP PLANA">Planas</asp:ListItem>
                </asp:DropDownList>
               
               </td>
            <td class="style4">
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Maquina:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="173px">
                </asp:DropDownList>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                <asp:CheckBox ID="chkInforme" runat="server" Text="Infome Detallado" 
                    Visible="False" />
                </td>
        </tr>
        <tr>
               <td class="style3">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style3">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style3">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style3">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style3">
                </td>
            <td class="style8">
<%--            
<asp:UpdatePanel ID="PleaseWaitPanel" runat="server" RenderMode="Inline">
    <ContentTemplate>--%>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />
<%-- </ContentTemplate>
</asp:UpdatePanel>--%>
                </td>
        </tr>
        </table>
        <br />
                         <div runat="server" id="divbotones" style="text-align:right; width: 1059px;" >

               <a title="Exportar a Excel">
                     <asp:ImageButton ID="ibExcel" runat="server" Height="20px" 
                      ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    onclick="ibExcel_Click" Visible="False" />
                </a>

                </div>
         <div runat="server" id="divGrilla" >

            <telerik:radgrid ID="RadGrid1" runat="server" Width="1600px" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>             
                    
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>  
                   
                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Pliego" UniqueName="Pliego">
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Colores" HeaderText="Colores" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Colores" UniqueName="Colores">
                    </telerik:GridBoundColumn>
                   
                    <telerik:GridBoundColumn DataField="Planchas" HeaderText="Planchas" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Planchas" UniqueName="Planchas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="260px" ItemStyle-HorizontalAlign="Left" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>  
                    
                    <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" SortExpression="Cliente" UniqueName="Cliente">
                    </telerik:GridBoundColumn>  
             
<%--                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Ent." ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>--%>

                    <telerik:GridBoundColumn DataField="Planificado" HeaderText="Plan" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Planificado" UniqueName="Planificado">
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Giros" HeaderText="Giros" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Giros" UniqueName="Giros">
                    </telerik:GridBoundColumn>               
                    
                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="H.Prep." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right"  SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="H.Tir." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="H.Imp." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>
                    
<%--                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="H.sinTrab." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>--%>

<%--                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="S.Pers" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="H.Mant." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>
--%>
                    <telerik:GridBoundColumn DataField="MermaArranque" HeaderText="M.Arran." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="MermaArranque" UniqueName="MermaArranque">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="MermaTiraje" HeaderText="M.Tir." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="MermaTiraje" UniqueName="MermaTiraje">
                    </telerik:GridBoundColumn>


                    
<%--                    <telerik:GridBoundColumn DataField="Planchas" HeaderText="Plan." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Planchas" UniqueName="Planchas">
                    </telerik:GridBoundColumn>--%>
                    
<%--                    <telerik:GridBoundColumn DataField="Preparaciones" HeaderText="Prep." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Preparaciones" UniqueName="Preparaciones">
                    </telerik:GridBoundColumn>--%>
                    
<%--                    <telerik:GridBoundColumn DataField="HorasDisponibles" HeaderText="H.Disp." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasDisponibles" UniqueName="HorasDisponibles">
                    </telerik:GridBoundColumn>--%>

                    <telerik:GridBoundColumn DataField="VPromedio" HeaderText="V.Promedio" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="VPromedio" UniqueName="VPromedio">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Uptime" HeaderText="Uptime" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Uptime" UniqueName="Uptime">
                    </telerik:GridBoundColumn>
<%--
                    <telerik:GridBoundColumn DataField="Colores" HeaderText="Colores" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Colores" UniqueName="Colores">
                    </telerik:GridBoundColumn>
                   
                    <telerik:GridBoundColumn DataField="Planchas" HeaderText="Planchas" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Planchas" UniqueName="Planchas">
                    </telerik:GridBoundColumn>--%>


                    <telerik:GridBoundColumn DataField="HorasDirectas" HeaderText="H.Direc." ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasDirectas" UniqueName="HorasDirectas">
                    </telerik:GridBoundColumn>
                    
<%--                    <telerik:GridBoundColumn DataField="Escarpe" HeaderText="Escarpe" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Escarpe" UniqueName="Escarpe">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Cono" HeaderText="Cono" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Cono" UniqueName="Cono">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="ConsumoPapel" HeaderText="Consumo" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="ConsumoPapel" UniqueName="ConsumoPapel">
                    </telerik:GridBoundColumn>--%>                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>

                </div>
                <div id="divErrores" runat="server" style="height:150px;overflow:auto;">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="ERRORES"></asp:Label>
&nbsp;<asp:Label ID="lblErrores" runat="server"></asp:Label>
                </div>
</asp:Content>
