<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="DistribucionNatura.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.DistribucionNatura" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function Agregar() {
        var u = '<%= Session["Usuario"] %>';
        onload(window.open('ProductoElaborado.aspx?u=' + u, 'Producto Elaborado', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Gerencia"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtGerencia" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Marca"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMarca" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>REV. </asp:ListItem>
                    <asp:ListItem>ENSOBRADOS</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>Ciclo</td>
            <td><asp:TextBox ID="txtCicloNatura" runat="server"></asp:TextBox> </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>Pendiente</asp:ListItem>
                    <asp:ListItem>Proceso</asp:ListItem>
                    <asp:ListItem>Finalizada</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" /></td>

        </tr>
    </table>

<div align="right"> <a title="Exportar a Excel">
                <a id="ida" runat="server" onclick="javascript:Agregar()" style="color: #000000;
                                text-decoration: blink;">
                                <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar
                            </a>
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>&nbsp;&nbsp;</div>

    <div style="border:1px solid blue;min-height:300px;width:1095px; max-height:466px;overflow-y:auto;" >
               <telerik:RadGrid ID="RadGridCodigos" BorderWidth="0px" runat="server"  Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="CodigoBarra">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Gerencia" HeaderText="Gerencia" ReadOnly="True" ItemStyle-Width="150px">
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="Sector" HeaderText="Sector"  UniqueName="Sector" ItemStyle-Width="120px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Destinatario" HeaderText="Destinatario"  UniqueName="Destinatario" ItemStyle-Width="270px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Domicilio" HeaderText="Domicilio" UniqueName="Domicilio" Visible="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Localidad" HeaderText="Localidad" UniqueName="Localidad" ItemStyle-Width="100px">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Retiro" HeaderText="Retiro" UniqueName="Retiro" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="80px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Caja_Revista" HeaderText="Cant. Soli" UniqueName="Caja_Revista" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="caja_ensobrado" HeaderText="Cant. Faltante" UniqueName="caja_ensobrado" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CodigoBarra" HeaderText="Codigo Barra" UniqueName="CodigoBarra" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" UniqueName="Marca" ItemStyle-Width="120px">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado" ItemStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Nombre_Cajas" HeaderText="Nombre_Cajas" UniqueName="Nombre_Cajas" Visible="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
</asp:Content>

