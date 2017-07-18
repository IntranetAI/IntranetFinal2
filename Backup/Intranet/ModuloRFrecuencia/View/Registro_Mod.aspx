<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro_Mod.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Registro_Mod" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
        <div align="center">   <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                             Font-Size="X-Large"></asp:Label><asp:Label ID="Label1" runat="server" Font-Bold="True" 
                             Font-Size="Large"></asp:Label></div>
        <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
                        Height="320px" Width="330px">
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Editar Bob." Height="310px" Width="290px">
                <HeaderTemplate>
                    Editar Bob.
                </HeaderTemplate>
                <ContentTemplate>
                    <table style="width:100%;">
                        <tr><td></td><td></td><td></td></tr>
                         <tr>
                            <td></td>
                            <td style="width:120px;">Maquina</td>
                            <td><asp:DropDownList ID="ddlMaquina" runat="server" Width="150px">
                                    <asp:ListItem>Lithoman</asp:ListItem>
                                    <asp:ListItem>WEB 1</asp:ListItem>
                                    <asp:ListItem>WEB 2</asp:ListItem>
                                    <asp:ListItem>M600</asp:ListItem>
                                    <asp:ListItem>Dimensionadora</asp:ListItem>
                                </asp:DropDownList></td>
                         </tr>
                         <tr>
                            <td></td>
                            <td>OT : </td>
                            <td>
                                <asp:TextBox ID="txtOT" runat="server" Width="60px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" 
                                    ImageUrl="~/images/Refresh.png" OnClick="ImageButton1_Click" Width="25px" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Pliego : </td>
                            <td>
                                <asp:DropDownList ID="ddlPliego" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--<tr>
                            <td></td>
                            <td style="vertical-align:top;">Estado : </td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server" Width="150px">
                                    <asp:ListItem>Bobina Buena</asp:ListItem>
                                    <asp:ListItem>Bobina Mala</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlResponsable" runat="server" Width="150px">
                                    <asp:ListItem>Bobina Buena</asp:ListItem>
                                    <asp:ListItem>Bobina Mala</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                                    <asp:ListItem>Bobina Buena</asp:ListItem>
                                    <asp:ListItem>Bobina Mala</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                         <tr>
                            <td></td>
                            <td>Peso bruto : </td>
                            <td>
                                <asp:TextBox ID="txtPesoBruto" runat="server" 
                                    style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Peso Tapa : </td>
                            <td>
                                <asp:TextBox ID="txtPesoTapa" runat="server" style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Peso Emboltura : </td>
                            <td>
                                <asp:TextBox ID="txtPesoEmb" runat="server" style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Peso Escarpe : </td>
                            <td>
                                <asp:TextBox ID="txtPesoEsc" runat="server" style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Peso Cono : </td>
                            <td>
                                <asp:TextBox ID="txtPesoCono" runat="server" style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Saldo : </td>
                            <td>
                                <asp:TextBox ID="txtSaldo" runat="server" style="text-align:right;" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Usuario : </td>
                            <td><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></td>
                            
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button1" runat="server" Text="Guardar" onclick="Button1_Click" /></td>
                            <td><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" onclick="btnEliminar_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSalir" runat="server" Text="Salir" onclick="btnSalir_Click" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Tipo Papel" Height="230px" Width="290px">
                <HeaderTemplate>
                    Tipo Papel
                </HeaderTemplate>
                <ContentTemplate>
                    <table>
                        <tr><td></td><td></td><td></td></tr>
                        <tr>
                            <td></td>
                            <td>Codigo :</td>
                            <td>
                                <asp:Label ID="lblBobina" runat="server" Text=""></asp:Label></td>
                        </tr>
                         <tr>
                            <td></td>
                            <td>Tipo : </td>
                            <td>
                                <asp:TextBox ID="txtTipo" runat="server" ></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                    TargetControlID="txtTipo" UseContextKey="True" CompletionInterval="500"
                                        MinimumPrefixLength="1" ServiceMethod="GetCompletionList" 
                                    DelimiterCharacters="" Enabled="True" ServicePath="" ></asp:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Marca : </td>
                            <td>
                                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                    TargetControlID="txtMarca" UseContextKey="True" CompletionInterval="500"
                                        MinimumPrefixLength="1" ServiceMethod="GetCompletionList1" 
                                    DelimiterCharacters="" Enabled="True" ServicePath="" ></asp:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Proveedor:</td>
                            <td>
                                <asp:DropDownList ID="ddlProveedor" runat="server">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                    <asp:ListItem>GRAFICOS QUILICURA S.A</asp:ListItem>
                                    <asp:ListItem>Libesa</asp:ListItem>
                                    <asp:ListItem>Publiguias</asp:ListItem>
                                    <asp:ListItem>A Impresores S.A.</asp:ListItem>
                                    <asp:ListItem>Santillana</asp:ListItem>
                                    <asp:ListItem>Televisa</asp:ListItem>
                                    <asp:ListItem>VARIOUS</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Ubicacion:</td>
                            <td>
                                <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Lote : </td>
                            <td>
                                <asp:TextBox ID="txtLote" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                                /></td> <%--//     onclick="btnGuardar_Click"--%>
                        </tr>
                    </table>

                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </form>
</body>
</html>
