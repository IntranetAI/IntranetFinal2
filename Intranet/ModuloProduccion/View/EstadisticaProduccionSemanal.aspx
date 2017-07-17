<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EstadisticaProduccionSemanal.aspx.cs" Inherits="Intranet.ModuloProduccion.View.EstadisticaProduccionSemanal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
   .divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    padding: 5px;
    text-align: center;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Área:"></asp:Label>
               
            </td>
            <td class="style2">

               
                <asp:DropDownList ID="ddlSeccion" runat="server" Width="173px" 
                    onselectedindexchanged="ddlSeccion_SelectedIndexChanged">
                    <asp:ListItem>Seleccione...</asp:ListItem>
<%--                    <asp:ListItem Value="IMP ROT">Rotativa</asp:ListItem>
                    <asp:ListItem Value="IMP PLANA">Planas</asp:ListItem>--%>
                    <asp:ListItem Value="ENCADERN">Encuadernación</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Máquina:" Visible="False"></asp:Label>
               </td>
            <td class="style2">
                <asp:DropDownList ID="ddlMaquina" runat="server" Visible="False" Width="173px">
                </asp:DropDownList>
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
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px"  onclick="btnFiltro_Click1" />

           </td>
        </tr>
    </table>
    <br />

         <div id="Div1" runat="server" style="height:200px;overflow:auto;">
    <asp:Label ID="lblMaquina" runat="server"></asp:Label>
    <br />
    <telerik:radgrid ID="RadGrid2" runat="server" Skin="Outlook" Width="1090px" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                    <telerik:GridBoundColumn DataField="Semana" HeaderText="Sem" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="100px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn DataField="GirosBuenosTiraje" HeaderText="Giros" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="GirosBuenosTiraje" UniqueName="GirosBuenosTiraje">
                    </telerik:GridBoundColumn>--%>


                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PromedioPreparacion" HeaderText="Prom. x Prep" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="PromedioPreparacion" UniqueName="PromedioPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="Horas Tiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="Horas Improductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="Productividad" HeaderText="% Prod." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Productividad" UniqueName="Productividad">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="Velocidad" HeaderText="Velocidad" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Velocidad" UniqueName="Velocidad">
                    </telerik:GridBoundColumn>  

<%--                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPruebaImpresion" HeaderText="Horas PruebaImp." ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPruebaImpresion" UniqueName="HorasPruebaImpresion">
                    </telerik:GridBoundColumn>--%>
<%--
                    <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="Malos Tiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
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
                         <div id="Div2" runat="server" style="height:200px;overflow:auto;">
    <asp:Label ID="Label1" runat="server" Text="Producción Por Turnos" 
        Font-Bold="True"></asp:Label>
    <br />
    <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" Width="1090px" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                    <telerik:GridBoundColumn DataField="Semana" HeaderText="Sem" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Semana" UniqueName="Semana">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="100px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Noche" HeaderText="Noche" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="Noche" UniqueName="Noche">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="PorcNoche" HeaderText="Noche %" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="PorcNoche" UniqueName="PorcNoche">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Mañana" HeaderText="Mañana" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="Mañana" UniqueName="Mañana">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcMañana" HeaderText="Mañana %" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="Mañana" UniqueName="Mañana">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Tarde" HeaderText="Tarde" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="Tarde" UniqueName="Tarde">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcTarde" HeaderText="Tarde %" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="PorcTarde" UniqueName="PorcTarde">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="Generales" HeaderText="Totales Generales" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="Generales" UniqueName="Generales">
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
                

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Producción Acumulada Mes" 
                    Font-Bold="True"></asp:Label>
               &nbsp;<asp:Label ID="lblMes" runat="server" Font-Bold="True"></asp:Label>
               <telerik:radgrid ID="RadGrid3" runat="server" Skin="Outlook" Width="450px" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
          
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="100px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TotalProducido" HeaderText="Produccion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="TotalProducido" UniqueName="TotalProducido">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="PorcTotalProducido" HeaderText="% Prod." ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="PorcTotalProducido" UniqueName="PorcTotalProducido">
                    </telerik:GridBoundColumn> 
                     
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Produccion Acumulada Año" 
                    Font-Bold="True"></asp:Label>
               &nbsp;<asp:Label ID="lblAño" runat="server" Font-Bold="True"></asp:Label>
               <telerik:radgrid ID="RadGrid4" runat="server" Skin="Outlook" Width="450px" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="semana"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
          
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="100px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TotalProducido" HeaderText="Produccion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="TotalProducido" UniqueName="TotalProducido">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="PorcTotalProducido" HeaderText="% Prod." ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="PorcTotalProducido" UniqueName="PorcTotalProducido">
                    </telerik:GridBoundColumn> 
                     
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
            </td>
        </tr>
        </table>

                </asp:Content>


