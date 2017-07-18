<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EstadisticaProduccionEncuadernacion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.EstadisticaProduccionEncuadernacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style2">
                &nbsp;&nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Máquina:"></asp:Label>
               
            </td>
            <td class="style2">
               
                <asp:DropDownList ID="ddlMaquina" runat="server" Width="173px">
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
             <div runat="server" id="divGrilla" style="width:1100px;height:500px;overflow:auto;">
    <telerik:radgrid ID="RadGrid1" runat="server" Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Mes"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="Mes" HeaderText="Mes" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Right" SortExpression="Mes" UniqueName="Mes">
                    </telerik:GridBoundColumn>             
             
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ItemStyle-Width="50px" SortExpression="Maquina" UniqueName="Maquina">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OTS" HeaderText="OTS" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="OTS" UniqueName="OTS">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Entradas" HeaderText="Entradas" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Entradas" UniqueName="Entradas">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacion" HeaderText="Horas Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacion" UniqueName="HorasPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasPreparacionPromedio" HeaderText="Promedio Preparacion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasPreparacionPromedio" UniqueName="HorasPreparacionPromedio">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasImproductivas" HeaderText="Horas Improductivas" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasImproductivas" UniqueName="HorasImproductivas">
                    </telerik:GridBoundColumn>

                    
                    <telerik:GridBoundColumn DataField="HorasSinTrabajo" HeaderText="Horas SinTrabajo" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinTrabajo" UniqueName="HorasSinTrabajo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasSinPersonal" HeaderText="Horas SinPersonal" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasSinPersonal" UniqueName="HorasSinPersonal">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasMantencion" HeaderText="Horas Mantencion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasMantencion" UniqueName="HorasMantencion">
                    </telerik:GridBoundColumn>
                                        
                    <telerik:GridBoundColumn DataField="EsperaMaterial" HeaderText="Espera Material" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="EsperaMaterial" UniqueName="EsperaMaterial">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TotalHoras" HeaderText="TotalHoras" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="TotalHoras" UniqueName="TotalHoras">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcProduciendo" HeaderText="% Prod" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcProduciendo" UniqueName="PorcProduciendo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcSinCarga" HeaderText="% sinCarga" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcSinCarga" UniqueName="PorcSinCarga">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="PorcSinProducir" HeaderText="% sinProd" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcSinProducir" UniqueName="PorcSinProducir">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="PorcEsperaMaterial" HeaderText="% Esp. Material" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcEsperaMaterial" UniqueName="PorcEsperaMaterial">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="HorasTiraje" HeaderText="HorasTiraje" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="HorasTiraje" UniqueName="HorasTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Buenos" UniqueName="Buenos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="BuenosPromedio" HeaderText="Buenos Promedio" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="BuenosPromedio" UniqueName="BuenosPromedio">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosPreparacion" HeaderText="Malos Preparacion" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosPreparacion" UniqueName="PliegosMalosPreparacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PliegosMalosTiraje" HeaderText="MalosTiraje" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="PliegosMalosTiraje" UniqueName="PliegosMalosTiraje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PorcBuenosMalos" HeaderText="% Malos/Buenos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="PorcBuenosMalos" UniqueName="PorcBuenosMalos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Velocidad" HeaderText="Velocidad" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Velocidad" UniqueName="Velocidad">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="RendPP" HeaderText="Rend(PP)" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="RendPP" UniqueName="RendPP">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="RendImp" HeaderText="Rend(Imp)" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="RendImp" UniqueName="RendImp">
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
