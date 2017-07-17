<%@ Page Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Reimpresion_Etiquetas.aspx.cs" Inherits="Intranet.ModuloWip.View.Reimpresion_Etiquetas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 294px;
            height: 30px;
        }
        .style4
        {
            height: 30px;
            width: 440px;
        }
        .style5
        {
            width: 147px;
        }
        .style6
        {
            height: 30px;
            width: 147px;
        }
        .style8
        {
            width: 488px;
        }
        .style9
        {
            width: 488px;
            height: 30px;
        }
        .style10
        {
            width: 440px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 80%;">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="Reimprimir Etiqueta Por:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdOT" runat="server" Text="OT" GroupName="rdBuscar" 
                    AutoPostBack="True" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdFolio" runat="server" Text="Etiqueta" Checked="true" 
                    GroupName="rdBuscar" AutoPostBack="True" />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="style4">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblFolio" runat="server" Text="Etiqueta:" Font-Bold="True"></asp:Label>
            &nbsp;
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                <asp:Label ID="lblOT" runat="server" Font-Bold="True" Text="OT:" 
                    Visible="False"></asp:Label>
                <asp:TextBox ID="txtOT" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
            <td class="style6">
                </td>
        </tr>
    </table>
    <div align="center" id="divResultado" visible="false" runat="server">
                <asp:Image ID="imgResultado" runat="server" Height="20px" Width="20px" />            
                &nbsp;<asp:Label ID="lblResultado" runat="server"></asp:Label>            
            </div>


    <div align="center" id="DivGrilla" runat="server"
        style="min-height:200px;max-height:502px;width:1090px; overflow:auto;border:1px inset blue;" >
    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook"  ClientSettings-EnablePostBackOnRowClick="true"  OnItemCommand="contactsGrid_ItemCommand">  
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Control">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Registro !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="ID_Control" HeaderText="ID_Control" 
                                ReadOnly="True" SortExpression="ID_Control" UniqueName="ID_Control" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>

                                
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                                UniqueName="OT" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                            UniqueName="NombreOT" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" 
                            UniqueName="Pliego" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Pliegos Impresos" 
                            SortExpression="Pliegos_Impresos" UniqueName="Pliegos_Impresos" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Peso_pallet" HeaderText="Peso Pallet" 
                            UniqueName="Peso_pallet" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" 
                            UniqueName="Maquina" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
              
              
                            <telerik:GridBoundColumn DataField="Estado_Pallet2" HeaderText="Estado Pallet" 
                            UniqueName="Estado_Pallet2" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Creada por" 
                            UniqueName="Usuario" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Fecha_Creacion" HeaderText="Fecha Creacion" 
                            UniqueName="Fecha_Creacion" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy HH:MM:ss}">
                            </telerik:GridBoundColumn>

              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    </div>

    <div align="center" id="divBotones" visible="false" runat="server">
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
            Text="Nuevo" />
    </div>
    

</asp:Content>
