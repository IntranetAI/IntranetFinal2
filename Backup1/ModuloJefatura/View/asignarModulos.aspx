<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloJefatura/View/masterJefatura.Master" AutoEventWireup="true" CodeBehind="asignarModulos.aspx.cs" Inherits="Intranet.ModuloJefatura.View.asignarModulos" %>
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
<br />
    <div>
        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblidUs" runat="server" Visible="False"></asp:Label>
    </div>
    <div align="center">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Gray" 
        Text="Asignacion de Modulos"></asp:Label>
      
        <br />
  <asp:Label ID="Label2" runat="server" 
            Text="Seleccione un usuario para la asignar modulos" Font-Size="Small"></asp:Label>
    </div>
    <br />

               <div runat="server" id="divbotones" style="text-align:right;margin-bottom:-25px;" >

  <a title="Asignar Modulos Seleccionados"><asp:ImageButton ID="ibMultiCheck" 
                   runat="server" Height="30px" 
                   ImageUrl="~/images/check.png" Width="30px" onclick="ibMultiCheck_Click" 
                   />
                   </a>
<a title="Desasignar Modulos Seleccionados">
                   <asp:ImageButton 
                   ID="ibDesasignar" runat="server" Height="30px" 
                   ImageUrl="~/images/deleteS.png" Width="30px" onclick="ibEliminarSuscrita_Click" 
                   />
                   </a>
       </div>
                
<%--div contenedor grillas--%>
<div>
<asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="500px" Width="800px">
                      
        <asp:TabPanel runat="server" HeaderText="Usuarios" ID="TabPanel1">

            <ContentTemplate>
            <div style="height:500px;overflow:auto;"> 
       <telerik:radgrid ID="RadGrid1" runat="server"  
                GridLines="None"   Skin="Outlook"
                   OnItemCommand="contactsGrid_ItemCommand"
                 ClientSettings-EnableRowHoverStyle="true" 
                   ClientSettings-Selecting-EnableDragToSelectRows="false" 
                   ClientSettings-Scrolling-SaveScrollPosition="true" 
                   ClientSettings-Scrolling-UseStaticHeaders="false" 
                   ClientSettings-Selecting-AllowRowSelect="true"
                   ClientSettings-EnablePostBackOnRowClick="true">
               
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

            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            
            </telerik:radgrid>
            </div>
   
   </ContentTemplate>

        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Modulos" ID="TabPanel2">
       <ContentTemplate>
         <div style="height:500px;overflow:auto;"> 
       <telerik:radgrid ID="RadGrid2" runat="server"
                GridLines="None"   Skin="Outlook"
                   OnItemCommand="contactsGrid_ItemCommand2">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDModulo" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Modulos !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns>
                    <telerik:GridBoundColumn DataField="IDModulo" DataType="System.Int32" 
            HeaderText="ID"  SortExpression="IDModulo" 
            UniqueName="IDModulo" ItemStyle-Width="15px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn  DataField="Nombre_Modulo" HeaderText="Nombre Modulo" ItemStyle-Width="300px" 
            SortExpression="Nombre_Modulo" UniqueName="Nombre_Modulo"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Desc_Modulo" HeaderText="Descripcion"  ItemStyle-Width="350px"
            SortExpression="Desc_Modulo" UniqueName="Desc_Modulo"></telerik:GridBoundColumn>       
            

              <telerik:GridTemplateColumn >
              <HeaderTemplate>Seleccionar Todas<input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate>
              <ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" />
              </ItemTemplate>
              </telerik:GridTemplateColumn >
              


            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            
            </telerik:radgrid>
            </div>
        </ContentTemplate>
        </asp:TabPanel>
               <asp:TabPanel runat="server" HeaderText="Modulos Asignados" ID="TabPanel3">
       <ContentTemplate>
       <div style="height:500px;overflow:auto;"> 
       <telerik:radgrid ID="RadGrid3" runat="server"
                GridLines="None"   Skin="Outlook"
                   OnItemCommand="contactsGrid_ItemCommand3">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDModulo" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Modulos !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" /><Columns>
                    <telerik:GridBoundColumn DataField="IDModulo" DataType="System.Int32" 
            HeaderText="ID"  SortExpression="IDModulo" 
            UniqueName="IDModulo" ItemStyle-Width="15px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn  DataField="Nombre_Modulo" HeaderText="Nombre Modulo" ItemStyle-Width="300px" 
            SortExpression="Nombre_Modulo" UniqueName="Nombre_Modulo"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Desc_Modulo" HeaderText="Descripcion"  ItemStyle-Width="350px"
            SortExpression="Desc_Modulo" UniqueName="Desc_Modulo"></telerik:GridBoundColumn>       
            

                                            <telerik:GridTemplateColumn ><HeaderTemplate>Seleccionar Todas <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
              </telerik:GridTemplateColumn >
              


            </Columns>
            
            </MasterTableView><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            
            </telerik:radgrid>
            </div>
        </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>








    </div>
    <br />
</asp:Content>
