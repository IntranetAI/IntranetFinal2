<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Suscripcion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Suscripcion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../js/jquery.min.js" type="text/javascript"></script>



     <script  type="text/javascript" language="javascript">
         function SelectAllCheckboxes(spanChk) {

             // Added as ASPX uses SPAN for checkbox
             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }
         }
        </script>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div runat="server" id="divbotones" style="text-align:right;width:940px;margin-top:-10px;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="20px" Width="20px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp; <a title="Buscar OTs por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="20px" 
                    ImageUrl="~/images/buscar.png" Width="20px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
   &nbsp;&nbsp;&nbsp;<a title="Suscribir OTs Seleccionadas"><asp:ImageButton ID="ibMultiCheck" 
                   runat="server" Height="20px" 
                   ImageUrl="~/images/check.png" Width="20px" onclick="ibMultiCheck_Click" 
                   />
                   </a>
               &nbsp;&nbsp;&nbsp;<a title="Elimina OTs Seleccionadas Suscritas"><asp:ImageButton 
                   ID="ibEliminarSuscrita" runat="server" Height="20px" 
                   ImageUrl="~/images/deleteS.png" Width="20px" onclick="ibEliminarSuscrita_Click" 
                   />
                   </a>
       </div>
          <%--inicio filtro--%>
        <asp:Panel ID="Panel2" runat="server" Visible="False"> <%--style="margin-top:20px;">--%>
            <table style="background-color:#EEE;border:1px solid #999;padding:5px;border-radius:10px 10px 10px 10px;margin-left:-10px;margin-bottom:10px;" align="center" width="950px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumeroOT" runat="server" ></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre OT: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreOT" runat="server" ></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Cliente: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCliente" runat="server" ></asp:TextBox>
                <div align="right" style="margin-top:-22px;">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/cerrar.PNG" 
                        Width="15px" onclick="ImageButton2_Click1"/>
                </div>
            </td>

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
            <div align="center" style="width:184px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"
                     onclick="btnFiltro_Click1" />
           </div>
            </td>
        </tr>
    </table>
        </asp:Panel>
        <%--fin filtro--%>



        <%--inicio container--%>
                <table align="center" width="940px" style="margin-left:-15px;margin-top:-10px;">
        <tr><td>
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="550px" Width="945px" >
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OTs Nuevas</HeaderTemplate>
            <ContentTemplate>
            <div style="height:548px;width:930px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" 
                    onsortcommand="RadGrid1_SortCommand" >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" 
                    UniqueName="NumeroOT">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" 
                    HeaderText="Nombre" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                                    <ItemStyle Width="300px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="ejem" HeaderText="Tiraje" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Cliente" 
                            UniqueName="NombreCliente">
                                <ItemStyle Width="300px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaOT" HeaderText="Fecha de Creación" 
                                SortExpression="FechaOT" UniqueName="FechaOT" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                <ItemStyle Width="150px" />
                </telerik:GridBoundColumn>
                                
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas<asp:CheckBox id="chkAll1" runat="server" onclick="javascript:SelectAllCheckboxes(this);" /><%--<input id="chkAll1" onclick="javascript:SelectAllCheckboxes(this);" 
               type="checkbox" />--%>
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server"  Checked="false"/>
              </ItemTemplate>
              </telerik:GridTemplateColumn >
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              
              </div></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Fechas Asignadas">
            <HeaderTemplate>OTs Suscritas</HeaderTemplate>
            <ContentTemplate><div style="height:548px;width:930px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid2" runat="server" AllowSorting="True"
                Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand2" 
                    OnSortCommand="RadGrid2_SortCommand" >
                
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                 <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" UniqueName="NumeroOT">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                                    <ItemStyle Width="300px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="ejem" HeaderText="Tiraje" 
                            UniqueName="Ejemplares" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Cliente" 
                            UniqueName="NombreCliente">
                                <ItemStyle Width="300px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaOT" HeaderText="Fecha de Creación" 
                                SortExpression="FechaOT" UniqueName="FechaOT" 
                        DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                <ItemStyle Width="150px" />
                    </telerik:GridBoundColumn>
                                

           <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas <asp:CheckBox id="chkAll2" runat="server" onclick="javascript:SelectAllCheckboxes(this);" /><%--<input id="chkAll2" onclick="javascript:SelectAllCheckboxes(this);" 
               type="checkbox" />--%>
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server"  Checked="false"/></ItemTemplate>
           </telerik:GridTemplateColumn >
                                
                                </Columns></MasterTableView>
                                <ClientSettings EnableRowHoverStyle="True"></ClientSettings>
                                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                                </telerik:radgrid></div></ContentTemplate>
    </asp:TabPanel>
                <asp:TabPanel ID="TabPanel3" runat="server" >
            <HeaderTemplate>OTs sin Suscribir</HeaderTemplate>
            <ContentTemplate><div style="height:548px;width:930px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid3" runat="server"  Skin="Outlook" AllowSorting="True" 
                    OnSortCommand="RadGrid3_SortCommand" >
             <PagerStyle Mode="NumericPages"></PagerStyle>
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs sin Suscribir !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns>
                <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="NumeroOT" 
                    UniqueName="NumeroOT">
                    <ItemStyle Width="30px" />
                </telerik:GridBoundColumn><telerik:GridBoundColumn DataField="NombreOT" 
                    HeaderText="Nombre" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                    <ItemStyle Width="300px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ejem" HeaderText="Tiraje" 
                            UniqueName="Ejemplares" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Cliente" 
                            UniqueName="NombreCliente">
                            <ItemStyle Width="300px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaOT" 
                    HeaderText="Fecha de Creación"  DataFormatString="{0:dd/MM/yyyy HH:mm}"
                                SortExpression="FechaOT" UniqueName="FechaOT">
                                <ItemStyle Width="150px" />
                                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas <asp:CheckBox id="chkAll3" runat="server" onclick="javascript:SelectAllCheckboxes(this);" /><%--<input id="chkAll3" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />--%></HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" Checked="false"/></ItemTemplate></telerik:GridTemplateColumn ></Columns></MasterTableView>
                <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid></div></ContentTemplate>
    </asp:TabPanel>

    </asp:TabContainer>
    

                
                
                
                
                </td>
        </tr>
    </table>

        <%--fin container--%>
        <script type="text/javascript">
            $('#accordion ul:eq(0)').show();
 </script>


</asp:Content>
