<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Bobina.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Bobina" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div runat="server" id="divbotones" style="text-align:right; width: 940px; margin-top:-20px;margin-left:-10px;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
   <%--&nbsp;&nbsp;&nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="True" />
                   </a>--%>
               &nbsp;&nbsp;&nbsp;
               <a title="Exportar a Excel">
               <asp:ImageButton 
                   ID="ibExcel" runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
                    Visible="True" onclick="ibExcel_Click" /></a>
       </div>
       <asp:Panel ID="Panel2" runat="server" Visible="true">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;border-radius:10px 10px 10px 10px;" align="center" width="945px">
        <tr>
            <td style="width:85;">
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

            </td>
            <td style="width:134;">
                <asp:TextBox ID="txtNumeroOT" runat="server" Width="128px"></asp:TextBox>

            </td>
            <td style="width:81;">
                <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
            <td style="width:134;">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
            </td>
            <td style="width:81;">
                <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label>
            </td>
            <td style="width:134;">
                <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
            </td>
            <td>
            <div style="margin-top:-20px;margin-left:40px;text-align:right;">  
                <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                    ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                    style="width: 16px"  /></div>
            </td>

        </tr>
        <tr>
            <td style="width:85;">
                <asp:Label ID="Label1" runat="server" Text="Maquina:" Visible="False"></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlMaquina" runat="server" Visible="False">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Lithoman</asp:ListItem>
                    <asp:ListItem>M600</asp:ListItem>
                    <asp:ListItem>Dimensionadora</asp:ListItem>
                    <asp:ListItem>Web 1</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td style="width:81;">
                <asp:Label ID="Label2" runat="server" Text="Tipo Papel:" Visible="False"></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtTipPapel" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td style="width:81;">
                <asp:Label ID="Label6" runat="server" Text="Operador: " Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlOperador" runat="server">
                </asp:DropDownList>
                             
            </td>
        </tr>
        <tr>
            <td style="width:85;">
                <asp:Label ID="Label7" runat="server" Text="Bobina:" Visible="False"></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" 
                    OnTextChanged="ddlEstado_TextChanged" Visible="False">
                    <asp:ListItem Value="1">En Buen Estado</asp:ListItem>
                    <asp:ListItem Value="2">En Mal Estado</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td style="width:81;">
                <asp:Label ID="Label8" runat="server" Text="Responsable:" Visible="False"></asp:Label>
                </td>
            <td class="style16">
                <asp:DropDownList ID="ddlResponsable" runat="server" AutoPostBack="True" 
                    OnTextChanged="ddlResponsable_TextChanged" Visible="False">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                    <asp:ListItem Value="2">Rollero</asp:ListItem>
                    <asp:ListItem Value="3">Almacén</asp:ListItem>
                    <asp:ListItem Value="4">Otros Daños</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width:81;">
                <asp:Label ID="Label9" runat="server" Text="Causa Daño: " Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCausa" runat="server" Visible="False">
                </asp:DropDownList>
                             
            </td>

        </tr>
        <tr>
            <td style="width:95;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td class="style22">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
               
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style13">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14">
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           </div>
            </td>
            
            <td colspan = "2">
                <asp:CheckBox ID="cbxOption" runat="server" AutoPostBack="True" 
                    oncheckedchanged="cbxOption_CheckedChanged" Text="Opciones Avanzadas" />
            </td>
        </tr>
    </table>
    <br />
        </asp:Panel>
        <div style="margin-left:-10px;Width:940px;Height:500px;overflow-y:auto;">
       <%-- <asp:Panel runat ="server" Height="500px" ScrollBars="Auto" Width="940px">--%>
        
        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" Width="935px">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Trabajo !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOp"  UniqueName="NumeroOp">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="Proveedor">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ID_Bobina" HeaderText="Total Bob." 
                            UniqueName="Ancho">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ancho" HeaderText="B. Buenas" 
                            UniqueName="Ancho">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Gramage" HeaderText="B. Malas QG" 
                            UniqueName="Gramage">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Inicial" HeaderText="B. Malas" 
                            UniqueName="Inicial">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Original" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="P. Tapa" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="P. Cono" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="P. Escarpe" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="P. Envoltura" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Porc_Perdida" HeaderText="% Perdida" 
                            UniqueName="Porc_Perdida">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
        <telerik:radgrid ID="RadGrid2" runat="server"  Skin="Outlook" 
                AllowSorting="True" Width="922px" Visible="False"
                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="pliego">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Trabajo !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="pliego" HeaderText="Maquina" 
                                ReadOnly="True" SortExpression="Maquina"  UniqueName="Maquina">
                                <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOp"  UniqueName="NumeroOp">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="Proveedor">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ID_Bobina" HeaderText="Total Bob." 
                            UniqueName="Ancho">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ancho" HeaderText="B. Buenas" 
                            UniqueName="Ancho">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Gramage" HeaderText="B. Malas QG" 
                            UniqueName="Gramage">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Inicial" HeaderText="B. Malas" 
                            UniqueName="Inicial">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Original" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="P. Tapa" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="P. Cono" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="P. Escarpe" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="P. Envoltura" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Porc_Perdida" HeaderText="% Perdida" 
                            UniqueName="Porc_Perdida">
                                <ItemStyle Width="20px" />
                            </telerik:GridBoundColumn>              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
       
     <%--   </asp:Panel>--%>
        </div>
        <script type="text/javascript">
            $('#accordion ul:eq(8)').show();
 </script>
</asp:Content>
