<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Serv_Exter.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Informe_Serv_Exter" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function openGame(OT, NombreOT) {
        window.open('Historial_Bobina.aspx?ot=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
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
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre OT: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreOT" runat="server" ></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>

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
            <td></td>
            <td>
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
           </div>
            </td>
        </tr>
    </table>

<div align="right" style="width:950px;"> <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>&nbsp;&nbsp;</div>
<%--<br />--%>

    <div style="border:1px solid blue;margin-left:-10px; width:950px; min-height:300px; max-height:466px;overflow-y:auto;" >
                <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook"  GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" UniqueName="OT">
                                <ItemStyle Width="47px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" UniqueName="NombreOT">
                              <ItemStyle Width="260px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PliegoImp" HeaderText="Impresos" UniqueName="PliegoImp"  ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Cant_Envio" HeaderText="Cant. Envia" UniqueName="Cant_Envio" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px"/>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ProcExtern" HeaderText="Proc. Ext" UniqueName="ProcExtern">
                                <ItemStyle Width="120px"/>
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="FechImp"   HeaderText="Fecha Imp." UniqueName="FechImp">
                                <ItemStyle Width="143px"/>
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Cant_Recep" HeaderText="Cant. Recep" UniqueName="Cant_Recep" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="fechDev" HeaderText="Fecha Dev." UniqueName="fechDev">
                                <ItemStyle Width="143px"/>
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
