<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialPartesManuales.aspx.cs" Inherits="Intranet.ModuloProduccion.View.HistorialPartesManuales" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <title></title>
    <script language="javascript" type="text/javascript">
    $(document).ready(function () {
    });
    function CargaDiaParte(Maquina, fi, ft, fechaparte) {
        window.location = "HistorialPartesManuales.aspx?Maquina=" + Maquina + "&fi=" + fi + "&ft=" + ft + "&fechaparte=" + fechaparte;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
    <table style="background-color:#EEE;border:1px solid #999;margin-left:50px;border-radius:10px 10px 10px 10px;" align="center" width="950px">
        <tr>
               <td class="style4">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Maquina: "></asp:Label>
            </td>
            <td class="style4">
            <asp:DropDownList ID="ddlMaquina" runat="server" Width="210px" >
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="C150">Goss</asp:ListItem>
                    <asp:ListItem Value="M2016">Web 2</asp:ListItem>
                    <asp:ListItem Value="SHCD">CD</asp:ListItem>
                    <asp:ListItem Value="SH402">4P</asp:ListItem>
                    <asp:ListItem Value="MR408">Lithoman</asp:ListItem>
                    <asp:ListItem Value="KBA">KBA</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="style4">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Mes: "></asp:Label>
                </td>
            <td class="style4">
               <asp:DropDownList ID="ddlMes" runat="server" Width="210px" >
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="01">Enero</asp:ListItem>
                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                    <asp:ListItem Value="04">Abril</asp:ListItem>
                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                    <asp:ListItem Value="06">Junio</asp:ListItem>
                    <asp:ListItem Value="07">Julio</asp:ListItem>
                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList></td>
            <td class="style4">
                <asp:Label ID="Label1" runat="server" Text="Año:"></asp:Label>

            </td>
            <td class="style4">
               <asp:DropDownList ID="ddlAño" runat="server" Width="210px" >
<%--                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td class="style4">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

           </td>
        </tr>
    </table>
    <br />
        <div id="divGrilla" runat="server" style="height:500px;width:930px;overflow:auto;padding-left:60px;" align="center">
        
    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" SortExpression="Maquina" UniqueName="Maquina">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="OT" HeaderText="Dia" SortExpression="OT" UniqueName="OT">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="HorasDirectas" HeaderText="Horas Totales" SortExpression="HorasDirectas" UniqueName="HorasDirectas">
                        </telerik:GridBoundColumn>

<%--                        <telerik:GridBoundColumn DataField="Entradas" HeaderText="Errores" SortExpression="Entradas" UniqueName="Entradas">
                        </telerik:GridBoundColumn>--%>

                        <telerik:GridBoundColumn DataField="Buenos" HeaderText="Ver" SortExpression="Buenos" UniqueName="Buenos">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            
    </div>
    <div id="divModificar" runat="server" style="height:700px;width:1160px;overflow:auto;" align="center">
     <div id="divMod" runat="server" style="height:580px;width:1150px;overflow:auto;" align="center">
         <telerik:RadGrid ID="RadGrid2" runat="server" Skin="Outlook" 
             AllowSorting="True" onitemcommand="RadGrid1_ItemCommand">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDParte" ItemStyle-Width="20px" HeaderText="ID" SortExpression="IDParte" UniqueName="IDParte">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Maquina" ItemStyle-Width="30px" HeaderText="Maquina" SortExpression="Maquina" UniqueName="Maquina">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridTemplateColumn UniqueName="Codigo">
                                    <HeaderTemplate>
                                        Codigo
                                    </HeaderTemplate>
                                    <ItemStyle Width="30px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCodigo" runat="server" Width="30px" Text='<%#Eval("Codigo") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>


                        <telerik:GridTemplateColumn UniqueName="Pliego">
                                    <HeaderTemplate>
                                        Pliego
                                    </HeaderTemplate>
                                    <ItemStyle Width="30px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPliego" runat="server" Width="30px" Text='<%#Eval("Pliego") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn UniqueName="OT">
                                    <HeaderTemplate>
                                        OT
                                    </HeaderTemplate>
                                    <ItemStyle Width="50px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOT" runat="server" Width="50px" Text='<%#Eval("OT") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="NombreOT" ItemStyle-Width="150px" HeaderText="NombreOT" SortExpression="NombreOT" UniqueName="NombreOT">
                        </telerik:GridBoundColumn>

                        <telerik:GridTemplateColumn UniqueName="FechaInicio">
                                    <HeaderTemplate>
                                        Fecha Inicio
                                    </HeaderTemplate>
                                    <ItemStyle Width="130px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFI" runat="server" Width="130px" Text='<%#Eval("FechaInicio") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>
                                                 
                         <telerik:GridTemplateColumn UniqueName="FechaTermino">
                                    <HeaderTemplate>
                                        Fecha Termino
                                    </HeaderTemplate>
                                    <ItemStyle Width="130px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFT" runat="server" Width="130px" Text='<%#Eval("FechaTermino") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn UniqueName="Buenos">
                                    <HeaderTemplate>
                                      Buenos
                                    </HeaderTemplate>
                                    <ItemStyle Width="70px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBuenos" runat="server" Width="70px" Text='<%#Eval("Buenos") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>

                         
                        <telerik:GridTemplateColumn UniqueName="Maloss">
                                    <HeaderTemplate>
                                      Malos
                                    </HeaderTemplate>
                                    <ItemStyle Width="70px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMalos" runat="server" Width="70px" Text='<%#Eval("Maloss") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>


                         
                        <telerik:GridTemplateColumn UniqueName="Factor">
                                    <HeaderTemplate>
                                      Factor
                                    </HeaderTemplate>
                                    <ItemStyle Width="70px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFactor" runat="server" Width="70px" Text='<%#Eval("Factor") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>


                         
                        <telerik:GridTemplateColumn UniqueName="FechaParte">
                                    <HeaderTemplate>
                                      FechaParte
                                    </HeaderTemplate>
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFechaParte" runat="server" Width="100px" Text='<%#Eval("FechaParte") %>'></asp:TextBox>
                                    </ItemTemplate>
                         </telerik:GridTemplateColumn>

                         <telerik:GridButtonColumn CommandName="Modificar" Text="Modificar" UniqueName="Modificar" HeaderText="Modificar">
                       </telerik:GridButtonColumn>

                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            </div>
                        <div id="divErrores" runat="server" style="height:100px;width:1100px;overflow:auto;" align="center">
                <asp:Label ID="lblErrores" runat="server"></asp:Label>
            </div>
     </div>
        <div align="center"><asp:Button ID="btnCerrar" runat="server" Text="Cerrar" 
                onclick="btnCerrar_Click" /></div>

       </div>
    </form>
</body>
</html>
  