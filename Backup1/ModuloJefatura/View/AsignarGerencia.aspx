<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloJefatura/View/masterJefatura.Master" AutoEventWireup="true" CodeBehind="AsignarGerencia.aspx.cs" Inherits="Intranet.ModuloJefatura.View.AsignarGerencia" %>
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
<style type="text/css">
    .style1
    {
        width: 128px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Asignar Centro de Costo"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Gray" 
                Text="Área a Cargo: "></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlArea" runat="server" Width="269px" AutoPostBack="True" 
                onselectedindexchanged="ddlArea_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Gray" 
                Text="Centro de Costos: "></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>

        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
        Height="400px" Width="600px">
                      
        <asp:TabPanel runat="server" HeaderText="Centros Costos sin Asignar" ID="TabPanel1">

            <ContentTemplate>
            <div style="height:390px;overflow:auto;"> 
       <telerik:radgrid ID="RadGrid1" runat="server"  
                GridLines="None"   Skin="Outlook"
                   OnItemCommand="contactsGrid_ItemCommand"
                 ClientSettings-EnableRowHoverStyle="true">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="cod_CentroCosto" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Nuevos Centros de Costo !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                    <telerik:GridBoundColumn DataField="cod_CentroCosto" DataType="System.Int32" 
            HeaderText="Codigo"  SortExpression="cod_CentroCosto"
            UniqueName="cod_CentroCosto">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn Visible="true" DataField="CentroCosto" HeaderText="Centro Costo"  
            SortExpression="CentroCosto" UniqueName="CentroCosto"></telerik:GridBoundColumn>

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
        <asp:TabPanel runat="server" HeaderText="Centros Costos Asignados" ID="TabPanel2">
       <ContentTemplate>
         <div style="height:390px;overflow:auto;"> 
       <telerik:radgrid ID="RadGrid2" runat="server"
                GridLines="None"   Skin="Outlook"
                   OnItemCommand="contactsGrid_ItemCommand2">
               
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="cod_CentroCosto" 
                    ><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Centros de Costo Asociados!<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                    <telerik:GridBoundColumn DataField="cod_CentroCosto" DataType="System.Int32" 
            HeaderText="Codigo"  SortExpression="cod_CentroCosto" ItemStyle-Width="150px"
            UniqueName="cod_CentroCosto">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn Visible="true" DataField="CentroCosto" HeaderText="Centro Costo" ItemStyle-Width="350px"
            SortExpression="CentroCosto" UniqueName="CentroCosto"></telerik:GridBoundColumn>

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
<%--
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            </asp:TabPanel>--%>

    </asp:TabContainer>







            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" Width="82px" 
                onclick="btnAsignar_Click" style="height: 26px" />
            
            <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            
            &nbsp;&nbsp;
            <asp:Button ID="btnDesasignar" runat="server" onclick="btnDesasignar_Click" 
                Text="Desasignar" />
            
            </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<br />
</asp:Content>
