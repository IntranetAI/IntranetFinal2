<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeImproductivo.aspx.cs" Inherits="Intranet.ModuloProduccion.View.InformeImproductivo" %>
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
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
               
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>
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
                    <asp:ListItem Value="ENCADERN">Encuadernacion</asp:ListItem>
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
                <asp:Label ID="Label4" runat="server" Text="Operador:"></asp:Label>
                </td>
            <td class="style6">
               
                <asp:DropDownList ID="ddlOperador" runat="server" Width="173px">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
               <td class="style5">
                &nbsp;&nbsp;
                   <asp:Label ID="Label8" runat="server" Text="Clasificación:"></asp:Label>
               
            </td>
            <td class="style5">
               
                <asp:DropDownList ID="ddlClasificacion" runat="server"  Width="173px" 
                    onselectedindexchanged="ddlClasificacion_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
               
            </td>
            <td class="style5">
                   &nbsp;
                   <asp:Label ID="Label9" runat="server" Text="Tipo:"></asp:Label>
               
               </td>
            <td class="style5">
               
                <asp:DropDownList ID="ddlTipo" runat="server" Width="173px">
                </asp:DropDownList>
               
               </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
               
                <asp:CheckBox ID="chkInforme" runat="server" Text="Infome Agrupado" />
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
         <div runat="server" id="divGrilla" 
        style="width:1100px;height:500px;overflow:auto;">

            <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="160px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="40px"  SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Clasificacion" HeaderText="Clasificacion" ItemStyle-Width="60px" SortExpression="Clasificacion" UniqueName="Clasificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="210px"  SortExpression="Proceso" UniqueName="Proceso">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="210px" SortExpression="Observacion" UniqueName="Observacion">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Operador" HeaderText="Operador" ItemStyle-Width="80px" SortExpression="Operador" UniqueName="Operador">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" ItemStyle-Width="130px" SortExpression="FechaInicio" UniqueName="FechaInicio">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" ItemStyle-Width="130px" SortExpression="FechaTermino" UniqueName="FechaTermino">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Horas" HeaderText="Horas" ItemStyle-Width="20px" SortExpression="Horas" UniqueName="Horas">
                    </telerik:GridBoundColumn>

                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
                <telerik:radgrid ID="RadGrid2" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="90px"  SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Clasificacion" HeaderText="Clasificacion" ItemStyle-Width="130px" SortExpression="Clasificacion" UniqueName="Clasificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="250px"  SortExpression="Proceso" UniqueName="Proceso">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="250px" SortExpression="Observacion" UniqueName="Observacion">
                    </telerik:GridBoundColumn>
                    

<%--                    <telerik:GridBoundColumn DataField="DAcerto" HeaderText="DAcerto" ItemStyle-Width="20px" SortExpression="DAcerto" UniqueName="DAcerto">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="DVirando" HeaderText="DVirando" ItemStyle-Width="20px" SortExpression="DVirando" UniqueName="DVirando">                  
                      </telerik:GridBoundColumn>--%>
                    

                    <telerik:GridBoundColumn DataField="Operador" HeaderText="Operador" ItemStyle-Width="60px" SortExpression="Operador" UniqueName="Operador">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" ItemStyle-Width="120px" SortExpression="FechaInicio" UniqueName="FechaInicio">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" ItemStyle-Width="120px" SortExpression="FechaTermino" UniqueName="FechaTermino">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Horas" HeaderText="Horas" ItemStyle-Width="80px" SortExpression="Horas" UniqueName="Horas">
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
