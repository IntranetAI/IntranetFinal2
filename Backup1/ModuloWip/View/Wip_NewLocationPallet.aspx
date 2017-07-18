<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Wip_NewLocationPallet.aspx.cs" Inherits="Intranet.ModuloWip.View.Wip_NewLocationPallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function contar() {
        var elementos = document.getElementsByName("checkintento");
        var texto = "";
        var contador = 0;
        var elem = document.getElementsByName("Text1");
        for (x = 0; x < elementos.length; x++) {
            if (elementos[x].checked) {
                texto = elem[0].value + "." + elementos[x].value;
            }
            //texto = texto + elementos[x].checked + "-" + elementos[x].value + ".";
            //, '<%= Session["Usuario"]%>'); elementos[x].value
        }
        //        texto = texto+ elem[0].value;
        PageMethods.btnAsignar_Click(texto, '<%= Session["Usuario"]%>');
        alert('Pallet con Ubicacion asignada Correctamente');
        window.location.href = 'Wip_NewLocationPallet.aspx?id=8&Cat=5';

        //        alert(texto);
        //        alert('Pallet con Ubicacion asignada Correctamente');
        //        window.location.href = 'Asignar_Pallet_Ubicacion.aspx?id=8'
    }

</script>
   <%-- <style type="text/css">
        .style2
        {
            height: 30px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">  <asp:Label ID="Label3" runat="server" Text="Código Pallet:"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtCodigoPallet" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                    
                    </div>
    <div align="center" id="DivMensaje" runat="server">
    <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
              
    </div>
    <asp:Panel ID="pnlDatosOT" runat="server" Visible="false">
    <fieldset>
    <legend>Datos de OT</legend>
        <table align="center">
            <tr>
                <td style="width:80px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="OT :" ></asp:Label>
                </td>
                <td style="width:100px;">
                    <asp:Label ID="lblOT" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                </td>
                <td style="width:110px;">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Nombre OT :" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:80px;">
                    &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Tiraje :" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTiraje" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <div align="center">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="" ></asp:Label>
                    </div>
                    
                </td>
                <%--<td>
                    <asp:Label ID="lblPliego" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tarea :" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTarea" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Forma :" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblForma" runat="server" Text=""></asp:Label>
                </td>--%>
            </tr>
        </table>
    </fieldset>
    <fieldset>
    <legend>Datos Pallet</legend>
        <table>
            <tr>
                <td style="width:140px;">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Maquina Origen:" ></asp:Label>
                </td>
                <td style="width:140px;">
                    <asp:Label ID="lblMaquina" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
    <legend>Datos Ubicación</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" 
                        Text="Ubicación Actual :" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBodega1" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Rack Actual :" 
                        Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNumRack1" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:150px;">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Lugar de Ubicación :" ></asp:Label>
                    
                </td>
                <td>
                    <asp:DropDownList ID="ddlBodega" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBodega_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Rack :" ></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlNumeroRack" runat="server" 
                        onselectedindexchanged="ddlNumeroRack_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style2">
                    
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style2">
                    
                </td>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan= "3">
                    <asp:Label ID="RackUbicacion" runat="server" Text="" ></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                    </td>
               
            </tr>
        </table>
    </fieldset>
    </asp:Panel>
    <div id="divGuardar" runat="server" align="center" visible="false">
        <input id="btnAsignar" type="button" value="Guardar y Asignar" onclick="contar();" />
            
            </div>


</asp:Content>
