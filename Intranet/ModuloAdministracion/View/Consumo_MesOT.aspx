<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Consumo_MesOT.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Consumo_MesOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;" align="center" width="910px">
        <tr>
            <td>Mes :</td>
            <td>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
            </td>
            <td>Año :</td>
            <td><asp:DropDownList ID="ddlAño" runat="server">
            </asp:DropDownList></td>
            <td></td>
            <td>
            <div align="right" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" />
           </div>
            </td>
        </tr>
    </table>
    <div align="right" style="width: 940px;">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/Excel-icon.png" Width="23px" onclick="ImageButton1_Click"  />
    </div>
    <div style="border:1px solid blue; max-height:220px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridInforme" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id_Funcionalidad">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Id_Funcionalidad" HeaderText="OT" >
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="EmpId" HeaderText="Nombre OT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DivCodigo" HeaderText="FL Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LlgDocNumDoc" HeaderText="Kg Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="LlgDocGlosa" HeaderText="Precio Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="LlgDocFechaIng" HeaderText="Kg Bobina" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="LlgDocNumInterno" HeaderText="Precio Bobina" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="IntPeriodo" HeaderText="Kg Total" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="OpeCod"   HeaderText="Precio Total" ItemStyle-HorizontalAlign="Right">
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
    <table style="width: 940px;text-align:center;">
        <tr>
            <td style="border: 1px solid black;border-collapse: collapse;"></td>
            <td style="border: 1px solid black;border-collapse: collapse;">Fl Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Bobina</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Bobina</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Total</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Total</td>
        </tr>
        <tr>
            <td style="text-align:left;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblOperacion" runat="server" Text="Total Operacional"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblFlPliego" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblHoja" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioHoja" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblBobina" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioBob" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblKgTotal" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioTotal" runat="server" Text="0.00"></asp:Label></td>
        </tr>
    </table>
    <br />
    <div style="border:1px solid blue; max-height:120px;overflow-y:scroll;width:943px;margin-left:-8px;" >
                <telerik:RadGrid ID="RadGridOtros" BorderWidth="0px" runat="server" Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id_Funcionalidad">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Id_Funcionalidad" HeaderText="OT" >
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="EmpId" HeaderText="Nombre OT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DivCodigo" HeaderText="FL Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LlgDocNumDoc" HeaderText="Kg Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="LlgDocGlosa" HeaderText="Precio Hoja" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="LlgDocFechaIng" HeaderText="Kg Bobina" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="LlgDocNumInterno" HeaderText="Precio Bobina" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="IntPeriodo" HeaderText="Kg Total" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="OpeCod"   HeaderText="Precio Total" ItemStyle-HorizontalAlign="Right">
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
    <table style="text-align:center;width: 940px;">
        <tr>
            <td>&nbsp;</td>
            <td style="border: 1px solid black;border-collapse: collapse;"></td>
            <td style="border: 1px solid black;border-collapse: collapse;">Fl Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Hoja</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Bobina</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Bobina</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Kg Total</td>
            <td style="border: 1px solid black;border-collapse: collapse;">Precio Total</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align:left;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblOperacion2" runat="server" Text="Total Otros"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblFlPliego2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblHoja2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioHoja2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblBobina2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioBob2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblKgTotal2" runat="server" Text="0.00"></asp:Label></td>
            <td style="text-align:right;border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lblPrecioTotal2" runat="server" Text="0.00"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
