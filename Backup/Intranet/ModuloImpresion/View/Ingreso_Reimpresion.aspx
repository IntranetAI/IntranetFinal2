<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Ingreso_Reimpresion.aspx.cs" Inherits="Intranet.ModuloImpresion.View.Ingreso_Reimpresion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="left" cellpadding="5px" style="margin-left: 25px; width: 341px;">
        <tr>
            <td>
                <label id="label">
                N° de OT</label></td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtOT" runat="server" Width="160px"></asp:TextBox>
            </td>
            <td>
                <%--el autoCompletar--%>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                    CompletionInterval="500" MinimumPrefixLength="3" 
                    ServiceMethod="GetCompletionList" TargetControlID="txtOT" UseContextKey="true">
                </asp:AutoCompleteExtender>
                <asp:Button ID="btnBuscar" runat="server" Height="29px" 
                    onclick="btnBuscar_Click" Text="Buscar" Width="76px" />
            </td>
        </tr>
        <tr>
            <td>
                <label id="label1">
                Nombre OT</label></td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtProducto" runat="server" Enabled="False" Width="160px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <label id="label47">
                Tarea</label></td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="ddlTarea" runat="server" AutoPostBack="true" 
                    Height="20px" onselectedindexchanged="ddlTarea_SelectedIndexChanged" 
                    Width="165px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label id="label4">
                Forma</label><br />
            </td>
            <td>
                :</td>
            <td>
                <label id="label46">
                <asp:TextBox ID="txtForma" runat="server" Enabled="False" Width="160px"></asp:TextBox>
                </label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <label id="label3">
                Pliego</label></td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="160px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <label id="label7">
                Tiraje Original</label><br />
            </td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtCantidadOriginal" runat="server" Enabled="False" 
                    Width="160px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <label id="label9">
                Cantidad Faltante</label></td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtCantidadFalta" runat="server" Width="160px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
      <table align="left" style="margin-left: 30px;" cellpadding="5px">
        <tr><td colspan="3">
            <asp:Label ID="lblCentroCosto" runat="server" Text="Centro de Costo"></asp:Label>
            </tr>
        <tr>
            <td rowspan="2" class="style5"><asp:ListBox ID="LbxArea" runat="server" SelectionMode="Multiple" 
                    Width="140px" Height="70px" 
                    onselectedindexchanged="LbxArea_SelectedIndexChanged"></asp:ListBox><br /></td>
            <td class="style7"><asp:Button ID="btnAgregarList" runat="server" Text=">>" 
                    onclick="btnAgregarList_Click"  /></td>
            <td rowspan="2" class="style6"><asp:ListBox ID="LbxAreaSeleccionada" runat="server" Width="140px" Height="70px" SelectionMode="Multiple"></asp:ListBox></td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Button ID="btnQuitarList" runat="server" Text="<<" 
                    onclick="btnQuitarList_Click" /></td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblCausaReimpresion" runat="server" Text="Origen de Falla"></asp:Label>
            </td>
            <td class="style7">:</td>
            <td class="style6"><asp:DropDownList ID="ddlCausaReImpresion" runat="server" Height="20px" 
                    Width="180px" 
                    onselectedindexchanged="ddlCausaReImpresion_SelectedIndexChanged" 
                    AutoPostBack="True">
            </asp:DropDownList><br /></td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblDetalleReimpresion" runat="server" Text="Detalle"></asp:Label>
                <br /></td>
            <td class="style7">:</td>
            <td class="style6">
                <asp:DropDownList ID="ddlDetalle" runat="server" Width="180px" Height="20px" 
                    onselectedindexchanged="ddlDetalle_SelectedIndexChanged">
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtObservacion" runat="server" Height="97px" 
                             Width="175px"></asp:TextBox>--%><br />
            </td>
        </tr>
        <tr>
            <td class="style5">&nbsp;</td>
            <td class="style7">&nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" Text="Centro Productivo"></asp:Label>
            </td>
            <td class="style7">:</td>
            <td class="style6">
                <asp:DropDownList ID="ddlArea" runat="server" Height="20px" Width="180px" 
                    onselectedindexchanged="ddlArea_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label48" runat="server" Text="Tipo de Proceso"></asp:Label>
            </td>
            <td class="style7">:</td>
            <td class="style6">
                <asp:DropDownList ID="ddlSeccion" runat="server" Height="20px" Width="180px" 
                    AutoPostBack="True" onselectedindexchanged="ddlSeccion_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label49" runat="server" Text="Máquina"></asp:Label>
            </td>
            <td class="style7">:</td>
            <td class="style6">
                <asp:DropDownList ID="ddlNombreMq" runat="server" Height="20px" Width="180px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">Operador</td>
            <td class="style7">:</td>
            <td class="style6">
                <asp:TextBox ID="txtOperador" runat="server" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5"><asp:Button BackColor="AppWorkspace" CssClass="button" 
                    ID="btnAgregar" runat="server" Text="Agregar" 
                    onclick="btnAgregarReimpresion_Click" Height="39px" Width="104px"/></td>
            <td class="style7">&nbsp;</td>
            <td class="style6"><a href="Pagina_Servicio.aspx?ID=2"  Height="39px" Width="104px" class="button red close" 
                    style="text-align:center; width: 78px;">Cancelar</a></td>
        </tr>
        </table>
        <br /><br /><br /><br /><br /><br />
</asp:Content>
