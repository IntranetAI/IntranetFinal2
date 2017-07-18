<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloJefatura/View/masterJefatura.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="Intranet.ModuloJefatura.View.AdminUsuarios" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
         <script type="text/javascript" language="javascript">
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
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
            background-color: #EEE;
        }
        .Grilla
        {
          
            margin-bottom: 5px;
            margin:center;
            padding: 10px;
        }
        .style2
        {
            width: 52px;
        }
        .style3
        {
            width: 152px;
        }
        .style8
        {
            width: 93px;
        }
        .style9
        {
            width: 84px;
        }
        .style10
        {
            width: 10px;
        }
        .style11
        {
            width: 9px;
        }
        .style12
        {
            width: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="pnlFiltro" align="center" runat="server" Visible="False">
        <table class="filtering" align="center" width="885px">
            <tr>
                <td class="style12">
                </td>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="lbl2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="style24">
                    :
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td class="style11">
                </td>
                <td class="style9">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                </td>
                <td class="style13">
                    :
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <div style="text-align:right;margin-top:-10px;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" 
                        ImageUrl="~/images/cerrar.PNG" onclick="ImageButton2_Click" 
                            style="width: 16px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                </td>
                <td class="style25">
                    :
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;<asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
                </td>
                <td class="style19">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />

    <%--inicio carga y contenido--%>
                <table class="Grilla" align="center" width="950px" style="margin-left:-20px;">
        <tr>
            <td>
                &nbsp;</td>
            <td> 
                       <div style="text-align:right;margin-bottom:-10px;" >
   <a title="Actualizar OTs Nuevas">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png" 
                   Height="23px" Width="23px" onclick="ImageButton1_Click"  />
                   </a>
               &nbsp;&nbsp; <a title="Buscar Usuarios por Filtro"> 
               <asp:ImageButton ID="ibMostrarFiltro" runat="server"  Height="23px" 
                    ImageUrl="~/images/buscar.png" Width="23px" onclick="ibMostrarFiltro_Click" 
                 />
</a> 
   &nbsp;&nbsp;&nbsp;<a title="Activas Cuentas Seleccionadas"><asp:ImageButton ID="ibMultiCheck" 
                   runat="server" Height="23px" 
                   ImageUrl="~/images/check.png" Width="23px" onclick="ibMultiCheck_Click" 
                   />
                   </a>
               &nbsp;&nbsp;&nbsp;<a title="Deshabilitar Cuentas Seleccionadas Suscritas"><asp:ImageButton 
                   ID="ibEliminarSuscrita" runat="server" Height="23px" 
                   ImageUrl="~/images/deleteS.png" Width="23px" onclick="ibEliminarSuscrita_Click" 
                   />
                   </a>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       </div>


                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="250px" Width="885px">
                      
        <asp:TabPanel runat="server" HeaderText="Usuarios" ID="TabPanel1">

            <HeaderTemplate>Cuentas Inactivas</HeaderTemplate>

            <ContentTemplate><telerik:radgrid ID="RadGrid1" runat="server"  
                GridLines="None"  OnItemCommand="contactsGrid_ItemCommand"
                PageSize="8" 
                AllowPaging="True" Skin="Outlook"><PagerStyle Mode="NumericPages" /><MasterTableView AutoGenerateColumns="False" DataKeyNames="idUsuario" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Cuentas de usuario Inactivas !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns><telerik:GridBoundColumn DataField="idUsuario" DataType="System.Int32" 
            HeaderText="ID"  SortExpression="idUsuario" 
            UniqueName="idUsuario">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn Visible="False" DataField="Passw" HeaderText="Passw" 
            SortExpression="Passw" UniqueName="Passw"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre"  ItemStyle-Width="250px"
            SortExpression="Nombre" UniqueName="Nombre"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Username" ItemStyle-Width="200px"
            SortExpression="Usuario" UniqueName="Usuario"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Correo" HeaderText="Correo" ItemStyle-Width="200px"
            SortExpression="Correo" UniqueName="Correo"></telerik:GridBoundColumn>
            
             <telerik:GridTemplateColumn ><HeaderTemplate>Seleccionar Todas <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
            
            
            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            </telerik:radgrid>
            </ContentTemplate>

        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Cuentas Deshabilitadas" ID="TabPanel2">
       <ContentTemplate>
       <telerik:radgrid ID="RadGrid2" runat="server"  
                GridLines="None"   Skin="Outlook">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="idUsuario" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Usuarios Deshabilitados !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns><telerik:GridBoundColumn DataField="idUsuario" DataType="System.Int32" 
            HeaderText="ID"  SortExpression="idUsuario" 
            UniqueName="idUsuario">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn Visible="False" DataField="Passw" HeaderText="Passw" 
            SortExpression="Passw" UniqueName="Passw"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre"  ItemStyle-Width="250px"
            SortExpression="Nombre" UniqueName="Nombre"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Username" ItemStyle-Width="200px"
            SortExpression="Usuario" UniqueName="Usuario"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Correo" HeaderText="Correo" ItemStyle-Width="200px"
            SortExpression="Correo" UniqueName="Correo"></telerik:GridBoundColumn>
            
             <telerik:GridTemplateColumn ><HeaderTemplate>Seleccionar Todas <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
            
            
            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
    </ContentTemplate>     
       
       
        </asp:TabPanel>

                <asp:TabPanel runat="server" HeaderText="Deshabilitar Usuarios" ID="TabPanel3">
       <ContentTemplate>
       <telerik:radgrid ID="RadGrid3" runat="server"  
                GridLines="None"   Skin="Outlook">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="idUsuario" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Usuarios !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns>
                    <telerik:GridBoundColumn DataField="idUsuario" DataType="System.Int32" 
            HeaderText="ID"  SortExpression="idUsuario" 
            UniqueName="idUsuario" ItemStyle-Width="15px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn Visible="False" DataField="Passw" HeaderText="Passw" 
            SortExpression="Passw" UniqueName="Passw"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre"  ItemStyle-Width="350px"
            SortExpression="Nombre" UniqueName="Nombre"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Username" ItemStyle-Width="200px"
            SortExpression="Usuario" UniqueName="Usuario"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Correo" HeaderText="Correo" ItemStyle-Width="250px"
            SortExpression="Correo" UniqueName="Correo"></telerik:GridBoundColumn>
            
             <telerik:GridTemplateColumn ><HeaderTemplate>Seleccionar Todas <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
            
            
            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
    </ContentTemplate>     
       
       
        </asp:TabPanel>
    </asp:TabContainer>
    
               
                
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
