<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Crear_Proyectos.aspx.cs" Inherits="Intranet.ModuloProyectos.View.Crear_Proyectos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <style type="text/css">
        .style1
        {
            width: 156px;
        }
        #DivOculto
        {
            height: 440px;
        }
        .style3
        {
            width: 10px;
        }
        .style4
        {
            width: 52px;
        }
        .style5
        {
            width: 142px;
        }
        .style6
        {
            width: 111px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<fieldset style="margin-left:-5px;width:912px;height:630px;">
<legend>Datos Proyecto</legend>

    <table style="width:100%;margin-top:-15px;">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                <br />
                <asp:Label ID="Label3" runat="server" Text="Nombre Proyecto:"></asp:Label>
            </td>
            <td >
                <br />
                <asp:TextBox ID="txtNombreProyecto" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtNombreProyecto" UseContextKey="true" CompletionInterval="500"
                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList">
                </asp:AutoCompleteExtender>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            &nbsp;
                <asp:Button ID="btnFiltro" runat="server" Text="Nuevo Proyecto" Width="122px" 
                    onclick="btnFiltro_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMisProyectos" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
            <div id="divMensaje" runat="server" align="center">
                <asp:Image ID="imgMensaje" runat="server" />
                <asp:Label ID="lblMensaje" 
            runat="server"></asp:Label></div>


    <div id="DivOculto" runat="server" visible="false"> 
    
         <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="508px" Width="912px" >
        <asp:TabPanel runat="server" HeaderText="OTs sin asignar" ID="TabPanel1">
            <HeaderTemplate>OTs sin Asignar</HeaderTemplate>
            <ContentTemplate>

           <table style="background-color:#EEE;border:1px solid #999;margin-left:5px;border-radius:10px 10px 10px 10px;" 
            align="center" width="890px" >
        <tr>
            <td class="style4" >
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label1" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre OT: "></asp:Label>
                </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>

            </td>
            <td class="style14">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style15">
               
                <asp:Label ID="Label5" runat="server" Text="Cliente: "></asp:Label>
               
            </td>
            <td class="style1">
               
                <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
               
            </td>
            <td class="style13">
                &nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
                </td>
            <td class="style16">
                <asp:DropDownList ID="ddlEstado" runat="server" Width="153px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>En Proceso</asp:ListItem>
                    <asp:ListItem>Liquidada</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td class="style14" >
            <div style="margin-left:17px;" >
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltrar_Click" />
           </div>
            </td>
        </tr>
        </table>
        <div id="divAsignacion" align="right" >
            <asp:ImageButton ID="btnAsignar" runat="server" Height="20px" 
                ImageUrl="~/Images/check.png" Width="20px" onclick="btnAsignar_Click" />
            <asp:Label ID="Label2" runat="server" Text="Asignar"></asp:Label> &nbsp;&nbsp;&nbsp; 
            </div>
            <div style="height:420px; width:895px; overflow:auto;"  >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" AllowSorting="True" 
                    GridLines="None"   >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" 
                    HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                                    <ItemStyle Width="350px" />
                                </telerik:GridBoundColumn>
                                
                                
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente">
                                <ItemStyle Width="350px" />
                            </telerik:GridBoundColumn>
                                                        
                            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT"
                            UniqueName="Tiraje">
                                <ItemStyle Width="200px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                            UniqueName="Estado">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn> 



                                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas<input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="True"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              
              </div></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Fechas Asignadas">
            <HeaderTemplate>OTs Asignadas</HeaderTemplate>
            <ContentTemplate><div style="height:548px;width:895px; overflow:auto;" >
            <div id="div1" align="right">
                &nbsp;&nbsp;&nbsp; 
            <asp:ImageButton ID="ibQuitarOTs" runat="server" Height="20px" 
                ImageUrl="~/Images/deleteS.png" Width="20px" onclick="ibQuitarOTs_Click" />
            <asp:Label ID="Label9"
                runat="server" Text="Quitar OT(s)"></asp:Label>
        </div>
           <div style="height:480px;width:895px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid2" runat="server" AllowSorting="True"
                Skin="Outlook" >
                
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                  <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                                <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" 
                    HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT">
                                    <ItemStyle Width="350px" />
                                </telerik:GridBoundColumn>
                                
                                
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente">
                                <ItemStyle Width="350px" />
                            </telerik:GridBoundColumn>
                                                        
                            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Tiraje OT"
                            UniqueName="Tiraje">
                                <ItemStyle Width="200px" HorizontalAlign="Right"  />
                            </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                            UniqueName="Estado">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn> 


           <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
           </telerik:GridTemplateColumn >
                                
                                </Columns></MasterTableView>
                                <ClientSettings EnableRowHoverStyle="True"></ClientSettings>
                                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                                </telerik:radgrid></div></ContentTemplate>
          
    </asp:TabPanel>


        <%--     <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
             </asp:TabPanel>
--%>

    </asp:TabContainer>
    
    </div>
    </fieldset>

    </asp:Content>
