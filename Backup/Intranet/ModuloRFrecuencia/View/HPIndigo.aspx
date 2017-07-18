<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="HPIndigo.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.HPIndigo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
function Agregar() {
    onload(window.open('Ingreso_Indigo.aspx', 'Ingreso Indigo', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" ></asp:TextBox>
            </td>
            <td>Nombre OT:
            </td>
            <td>
                <asp:TextBox ID="txtproveedor" runat="server" ></asp:TextBox></td>
            <td>Tipo de Papel</td>
            <td><asp:TextBox ID="txtnroFactura" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td colspan="2">
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
           </div>
            </td>
        </tr>
    </table>
<div align="right" style="width: 1095px;">
                            <a id="ida" runat="server" onclick="javascript:Agregar()" style="color: #000000;
                                text-decoration: blink;">
                                <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />
                            </a>
                        </div>
<%--<br />--%>

    <div style="border:1px solid blue; width:1095px; min-height:300px; max-height:466px;overflow-y:auto;" >
                <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook"  GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" UniqueName="Maquina">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" UniqueName="Pliego">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" UniqueName="Papel">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje" UniqueName="Tiraje" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Color"   HeaderText="Color" UniqueName="Color" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" UniqueName="Buenos" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Malos" HeaderText="Malos" UniqueName="Malos" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                          <%--  <telerik:GridBoundColumn DataField="VerMas" HeaderText="Detalle" 
                                ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                                <ItemStyle Width="50px" />
                            </telerik:GridBoundColumn>
--%>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
    <br />
</asp:Content>
