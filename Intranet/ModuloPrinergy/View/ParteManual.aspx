<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParteManual.aspx.cs" Inherits="Intranet.ModuloPrinergy.View.ParteManual" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Parte Manual</title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form runat="server">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
            <div class="container">
              <h3>Ingreso Parte Manual</h3> 
                <div class="card">
                    <div class="card-body">
                        <h4>Información Trabajo</h4>    
                        <div class="row">
                                  <div class="col-md-4"><b>OT:</b></div>
                                  <div class="col-md-8">
                                      <asp:TextBox ID="txtOT" runat="server"></asp:TextBox><asp:TextBox ID="txtOTNueva" runat="server"></asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="Button1_Click" />
                                      &nbsp;&nbsp;<asp:Button ID="btnBuscarNueva" runat="server" OnClick="btnBuscarNueva_Click" Text="Buscar" />
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTipo" runat="server" Font-Bold="True" Visible="False"></asp:Label> 
                                      <asp:Label ID="lblDiferencia" runat="server" Font-Bold="True"></asp:Label>
                                  </div>
                               </div>  
                            <div class="row">
                                 <div class="col-md-6"><b>Nombre OT:</b>&nbsp;<asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label><asp:TextBox ID="txtNombreOT" Width="265px" runat="server"></asp:TextBox></div>
                                 <div class="col-md-6"><b>Cliente:</b>&nbsp;<asp:Label ID="lblCliente" runat="server" Text=""></asp:Label><asp:DropDownList ID="ddlCliente" runat="server" Width="250px"></asp:DropDownList><asp:Label ID="lblCSR" runat="server" Text="Label" Visible="false"></asp:Label></div>
                            </div>
                    </div>
                </div>
                <div class="alert alert-warning" runat="server" id="DivAlert">
  <strong>¡Advertencia!</strong> Este trabajo ya ha sido cargado previamente.
</div>

                                <div class="alert alert-danger" runat="server" id="DivError">
  <strong>¡ERROR!</strong> Este trabajo no esta cargado en <strong>Metrics</strong>.
</div>
                <div class="card">
                    <div class="card-body">
                        <h4>Grupo de Páginas</h4>
                            <div class="row" style="margin:1px;">
                                 <div class="col-md-4">Nombre Grupo:</div>
                                 <div class="col-md-8">
                                     <asp:TextBox ID="txtNombreGrupo" runat="server" Class="form-control"></asp:TextBox><asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label></div>
                            </div>
                            <div class="row" style="margin:1px;">
                                 <div class="col-md-4">Cantidad de Páginas:</div>
                                 <div class="col-md-8"><asp:TextBox ID="txtPaginas" runat="server" Class="form-control" type="number"></asp:TextBox></div>
                            </div>
                            <div class="row" style="margin:1px;">
                                 <div class="col-md-4">Página de Inicio:</div>
                                 <div class="col-md-8"><asp:TextBox ID="txtInicio" runat="server" Class="form-control" type="number"></asp:TextBox></div>
                            </div>
                            <div class="row" style="margin:1px;">

                                 <div class="col-md-4">Formato (mm x mm):</div>
                                 <div class="col-md-8">
                                      <div  class="input-group">
                                        <asp:TextBox ID="txtFormatoX" runat="server" Class="form-control" style="width:50%" type="number"></asp:TextBox>&nbsp;&nbsp; X &nbsp;&nbsp;<asp:TextBox ID="txtFormatoY" runat="server" Class="form-control" style="width:50% " type="number"></asp:TextBox>
                                      </div>

                                 </div>
                            </div>
                            <div class="row" style="margin:1px;">
                                 <div class="col-md-4">Colores:</div>
                                 <div class="col-md-4">
                                     <div class="input-group">
                                     <asp:DropDownList ID="ddlTiro" runat="server" class="form-control">
                                         <asp:ListItem>0</asp:ListItem>
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                         <asp:ListItem>6</asp:ListItem>
                                         <asp:ListItem>7</asp:ListItem>
                                         <asp:ListItem>8</asp:ListItem>
                                     </asp:DropDownList>&nbsp;&nbsp;&nbsp;X&nbsp;&nbsp;<asp:DropDownList ID="ddlRetiro" runat="server"  class="form-control">
                                         <asp:ListItem>0</asp:ListItem>
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                         <asp:ListItem>6</asp:ListItem>
                                         <asp:ListItem>7</asp:ListItem>
                                         <asp:ListItem>8</asp:ListItem>
                                     </asp:DropDownList>
                                         </div>
                                 </div>
                                 <div class="col-md-4">
                                     <div class="input-group">
                                     Colores especiales:&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlColorEspecial" runat="server" class="form-control">
                                         <asp:ListItem>0</asp:ListItem>
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                         <asp:ListItem>6</asp:ListItem>
                                         <asp:ListItem>7</asp:ListItem>
                                         <asp:ListItem>8</asp:ListItem>
                                     </asp:DropDownList>
                                         </div>
                                 </div>
                            </div>
                            <div class="row" style="margin:1px;">
                                 <div class="col-md-4">Papel:</div>
                                 <div class="col-md-8"> <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control">
                                     <asp:ListItem>Couche</asp:ListItem>
                                     <asp:ListItem>Bond</asp:ListItem>
                                     <asp:ListItem>LWC</asp:ListItem>
                                     <asp:ListItem>Cartulina</asp:ListItem>
                                     <asp:ListItem>Diario</asp:ListItem>
                                     </asp:DropDownList></div>
                            </div>
                        <div class="row">
                            <div class="col-md-4"></div><div class="col-md-4"></div> 
                            <div class="col-md-4">
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Class="btn-success form-control" OnClick="Button2_Click"/>

                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Class="btn-success form-control" OnClick="btnModificar_Click"/>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <%--     GRIDVIEW CON DATOS--%>
                            <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"   Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NombreGrupo"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate>
                    <Columns>
                         <telerik:GridBoundColumn DataField="Id" HeaderText="Id"  ReadOnly="True" UniqueName="Id" ItemStyle-Width="30px" Visible="false">
                      </telerik:GridBoundColumn>

                     <telerik:GridBoundColumn DataField="NombreGrupo" HeaderText="NombreGrupo"  ReadOnly="True" UniqueName="NombreGrupo" ItemStyle-Width="30px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Paginas" HeaderText="Paginas"  ReadOnly="True" UniqueName="Paginas" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Inicio" HeaderText="Inicio"  ReadOnly="True" UniqueName="Inicio" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                                         
                      <telerik:GridBoundColumn DataField="Formato" HeaderText="Formato" ItemStyle-HorizontalAlign="Right"  ReadOnly="True" UniqueName="Formato" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                                         
                          <telerik:GridBoundColumn DataField="FormatoX" HeaderText="FormatoX" ItemStyle-HorizontalAlign="Right"  ReadOnly="True" UniqueName="FormatoX" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="FormatoY" HeaderText="FormatoY" ItemStyle-HorizontalAlign="Right"  ReadOnly="True" UniqueName="FormatoY" ItemStyle-Width="50px">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel"  ReadOnly="True" UniqueName="Papel" ItemStyle-Width="90px">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="Colores" HeaderText="Colores"  ReadOnly="True" UniqueName="Colores" ItemStyle-Width="90px">
                      </telerik:GridBoundColumn>

                      <telerik:GridBoundColumn DataField="ColorEspecial" HeaderText="ColorEspecial"  ReadOnly="True" UniqueName="ColorEspecial" ItemStyle-Width="90px">
                      </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ColorTiro" HeaderText="ColorTiro"  ReadOnly="True" UniqueName="ColorTiro" ItemStyle-Width="30px" Visible="false">
                      </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ColorRetiro" HeaderText="ColorRetiro"  ReadOnly="True" UniqueName="ColorRetiro" ItemStyle-Width="30px" Visible="false">
                      </telerik:GridBoundColumn>

                      <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                  
                            <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate>   
                                <asp:ImageButton  ID="ImageButton1" ImageUrl="~/Images/editar-icono-9796-128.png"  Width="17px" CommandName="CustomEdit" runat="server" /> &nbsp;&nbsp;|&nbsp;&nbsp;             
                                <asp:ImageButton  ID="imgEliminar" ImageUrl="~/Images/delete_icon.png"  Width="17px" CommandName="CustomDelete" runat="server" />
                            </ItemTemplate>

                      </telerik:GridTemplateColumn>
                                                   
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True"></HeaderContextMenu>
                </telerik:radgrid>

                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Parte" Class="btn-success form-control" OnClick="Button3_Click" />
            </div>
    </form>
</body>
</html>
