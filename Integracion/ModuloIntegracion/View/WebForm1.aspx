<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Integracion.ModuloIntegracion.View.WebForm1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script  type="text/javascript" lang="javascript" >
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
                $(document).ready(function () {
                    $('#RadGrid1 input[type=checkbox]').attr('disabled', false);
                });
</script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>


        <div>
        <h3 style="color: rgb(23, 130, 239); width: 935px;">Documentos No Procesados</h3> 

</div>

         <asp:Panel ID="Panel2" runat="server" Visible="true" style="margin-top:20px;">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:10px;border-radius:10px 10px 10px 10px;" align="center" width="890px">
        <tr>
            <td class="style9">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ddlTipDoc" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:Label ID="lblFechaInicio0" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td class="style13">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                    TargetControlID="txtFechaInicio">
                </asp:CalendarExtender>
            </td>
            <td class="style16">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
            </td>
            <td class="style14">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td>
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" /><%--onclick="btnFiltro_Click1"--%>
           </div>    
            </td>

        </tr>
    </table>
    <br />
        </asp:Panel>
    <div style="width:950px;height:500px;overflow:auto;margin-left:15px;margin-top:-10px;">
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" Width="940px" 
            onitemdatabound="RadGrid1_ItemDataBound"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="FolioFactura">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridTemplateColumn >
                    <HeaderTemplate>Todos 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                    </HeaderTemplate>
                <ItemTemplate>
                <asp:CheckBox ID="chkSelect"  runat="server" /></ItemTemplate>
                </telerik:GridTemplateColumn >
                <telerik:GridTemplateColumn ItemStyle-ForeColor="#0066FF">
                    <HeaderTemplate><label>Nº Documento</label> </HeaderTemplate>
                    <ItemTemplate>
                        <a href="#" onclick="window.open('ProcesarDocumento.aspx?IDDocMercantil='+'<%#  Eval("IDDocMercantil")%>'+'&IDTipoCam='+'<%#  Eval("IDTipoCambio")%>'+'&IDTipoDocMer='+'<%#  Eval("IDTipoDocMerca")%>','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=400,left=340,top=250','width=200,height=200')">
                            <asp:Label ID="lblFolio" runat="server" Text='<%# Bind("FolioFactura") %>' ForeColor="Blue" Font-Underline="True">"></asp:Label>
                        </a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="FolioFactura" UniqueName="FolioFactura" SortExpression="FolioFactura"  HeaderText="FolioFactura" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="IDDocMercantil" HeaderText="IDDocMercantil" 
                   ReadOnly="True" SortExpression="IDDocMercantil" UniqueName="IDDocMercantil" ItemStyle-Width="30px" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreTipoDocMer" HeaderText="Tipo Documento" SortExpression="NombreTipoDocMer" 
                   UniqueName="NombreTipoDocMer" ItemStyle-Width="150px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Creación" 
                   SortExpression="FechaCreacion" UniqueName="FechaCreacion" ItemStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="fechaEmision" HeaderText="Fecha Emisión" 
                   SortExpression="fechaEmision" UniqueName="fechaEmision" ItemStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Razón Social" UniqueName="NombreCliente" ItemStyle-Width="400px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="valorNeto" HeaderText="Valor Neto" UniqueName="valorNeto" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right"
                    DataFormatString="{0:c}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreCuenta" HeaderText="Estado" UniqueName="NombreCuenta" ItemStyle-Width="60px">
                </telerik:GridBoundColumn>            
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              </div>
        <div align="center">
            <asp:Button ID="btnEncabezado" runat="server" Text="Encabezado" 
                onclick="btnEncabezado_Click" Visible="False" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDetalle" runat="server" Text="Detalle" 
                onclick="btnDetalle_Click" Visible="False" />
           
            <asp:GridView ID="GridView1" runat="server" Visible="False">
                <Columns>
                    <asp:BoundField HeaderText="SisCidOri" DataField="SisCidOri" />
                    <asp:BoundField HeaderText="Id_Funcionalidad" DataField="Id_Funcionalidad" />
                    <asp:BoundField HeaderText="EmpId" DataField="EmpId" />
                    <asp:BoundField HeaderText="DivCodigo" DataField="DivCodigo" />
                    <asp:BoundField HeaderText="UniCodigo" DataField="UniCodigo" />
                    <asp:BoundField HeaderText="LlgDocFechaIng" DataField="LlgDocFechaIng" DataFormatString="{0:yyyy/MM/dd}"/>
                    <asp:BoundField HeaderText="IntPeriodo" DataField="IntPeriodo" />
                    <asp:BoundField HeaderText="OpeCod" DataField="OpeCod" />
                    <asp:BoundField HeaderText="LlgDocGlosa" DataField="LlgDocGlosa" />
                    <asp:BoundField HeaderText="LlgDocNumInterno" DataField="LlgDocNumInterno" />
                    <asp:BoundField HeaderText="LlgDocNumDoc" DataField="LlgDocNumDoc" />
                    <asp:BoundField HeaderText="LlgDocNumProvision" DataField="LlgDocNumProvision" />
                    <asp:BoundField HeaderText="EntRut" DataField="EntRut" />
                    <asp:BoundField HeaderText="EntSucNumero" DataField="EntSucNumero" />
                    <asp:BoundField HeaderText="EntRutSec" DataField="EntRutSec" />
                    <asp:BoundField HeaderText="EntSucNumeroSec" DataField="EntSucNumeroSec" />
                    <asp:BoundField HeaderText="EntRutTer" DataField="EntRutTer" />
                    <asp:BoundField HeaderText="EntSucNumeroTer" DataField="EntSucNumeroTer" />
                    <asp:BoundField HeaderText="LlgDocFecha" DataField="LlgDocFecha" />
                    <asp:BoundField HeaderText="LlgDocFechaVenc" DataField="LlgDocFechaVenc" />
                    <asp:BoundField HeaderText="pMonedaId" DataField="pMonedaId" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuAfecto" DataField="LlgDocMtoImpuAfecto" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuNeto" DataField="LlgDocMtoImpuNeto" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuExento" DataField="LlgDocMtoImpuExento" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuIva" DataField="LlgDocMtoImpuIva" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuOtrosImp" DataField="LlgDocMtoImpuOtrosImp" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuDerAdu" DataField="LlgDocMtoImpuDerAdu" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuRete" DataField="LlgDocMtoImpuRete" />
                    <asp:BoundField HeaderText="LlgDocMtoImpuTotal" DataField="LlgDocMtoImpuTotal" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalAfecto" DataField="LlgDocMtoLocalAfecto" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalNeto" DataField="LlgDocMtoLocalNeto" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalExento" DataField="LlgDocMtoLocalExento" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalIva" DataField="LlgDocMtoLocalIva" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalOtrosImp" DataField="LlgDocMtoLocalOtrosImp" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalDerAdu" DataField="LlgDocMtoLocalDerAdu" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalRete" DataField="LlgDocMtoLocalRete" />
                    <asp:BoundField HeaderText="LlgDocMtoLocalTotal" DataField="LlgDocMtoLocalTotal" />
                    <asp:BoundField HeaderText="DocCceDocRef" DataField="DocCceDocRef" />
                    <asp:BoundField HeaderText="LlgDocMtoIvaRec100" DataField="LlgDocMtoIvaRec100" />
                    <asp:BoundField HeaderText="LlgDocMtoIvaRecPro" DataField="LlgDocMtoIvaRecPro" />
                    <asp:BoundField HeaderText="LlgDocMtoIvaNoRec" DataField="LlgDocMtoIvaNoRec" />
                    <asp:BoundField HeaderText="ClaIvaId" DataField="ClaIvaId" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Visible="false">
                <Columns>
                    <asp:BoundField HeaderText="SisCodOri" DataField="SisCodOri"/>
                    <asp:BoundField HeaderText="Id_Funcionalidad" DataField="Id_Funcionalidad"/>
                    <asp:BoundField HeaderText="EmpId" DataField="EmpId"/>
                    <asp:BoundField HeaderText="DivCodigo" DataField="DivCodigo"/>
                    <asp:BoundField HeaderText="UniCodigo" DataField="UniCodigo"/>
                    <asp:BoundField HeaderText="CabOpeFecha" DataField="CabOpeFecha"/>
                    <asp:BoundField HeaderText="IntPeriodo" DataField="IntPeriodo"/>
                    <asp:BoundField HeaderText="OpeCod" DataField="OpeCod"/>
                    <asp:BoundField HeaderText="CabOpeGlosa" DataField="CabOpeGlosa"/>
                    <asp:BoundField HeaderText="CabOpeNumero" DataField="CabOpeNumero"/>
                    <asp:BoundField HeaderText="CabOpeLinea" DataField="CabOpeLinea"/>
                    <asp:BoundField HeaderText="CtaCodigo" DataField="CtaCodigo"/>
                    <asp:BoundField HeaderText="MovCceGlosa" DataField="MovCceGlosa"/>
                    <asp:BoundField HeaderText="pMonedaId" DataField="pMonedaId"/>
                    <asp:BoundField HeaderText="CreCodigo" DataField="CreCodigo"/>
                    <asp:BoundField HeaderText="CdiCodigo" DataField="CdiCodigo"/>
                    <asp:BoundField HeaderText="CfiCodigo" DataField="CfiCodigo"/>
                    <asp:BoundField HeaderText="pTprId" DataField="pTprId"/>
                    <asp:BoundField HeaderText="PryNumero" DataField="PryNumero"/>
                    <asp:BoundField HeaderText="LineaProdCodigo" DataField="LineaProdCodigo"/>
                    <asp:BoundField HeaderText="EntRut" DataField="EntRut"/>
                    <asp:BoundField HeaderText="EntSucNumero" DataField="EntSucNumero"/>
                    <asp:BoundField HeaderText="EntRutSec" DataField="EntRutSec"/>
                    <asp:BoundField HeaderText="EntSucNumeroSec" DataField="EntSucNumeroSec"/>
                    <asp:BoundField HeaderText="EntRutTer" DataField="EntRutTer"/>
                    <asp:BoundField HeaderText="EntSucNumeroTer" DataField="EntSucNumeroTer"/>
                    <asp:BoundField HeaderText="TdoId" DataField="TdoId"/>
                    <asp:BoundField HeaderText="DocCceNumero" DataField="DocCceNumero"/>
                    <asp:BoundField HeaderText="DocCceFecEmi" DataField="DocCceFecEmi"/>
                    <asp:BoundField HeaderText="MovCceNumCuota" DataField="MovCceNumCuota"/>
                    <asp:BoundField HeaderText="MovCceFecVenc" DataField="MovCceFecVenc"/>
                    <asp:BoundField HeaderText="DocCceFecProyectada" DataField="DocCceFecProyectada"/>
                    <asp:BoundField HeaderText="MovCceMontoImpuDebe" DataField="MovCceMontoImpuDebe"/>
                    <asp:BoundField HeaderText="MovCceMontoImpuHaber" DataField="MovCceMontoImpuHaber"/>
                    <asp:BoundField HeaderText="MovCceMontoLocalDebe" DataField="MovCceMontoLocalDebe"/>
                    <asp:BoundField HeaderText="MovCceMontoLocalHaber" DataField="MovCceMontoLocalHaber"/>
                    <asp:BoundField HeaderText="InstCod" DataField="InstCod"/>
                    <asp:BoundField HeaderText="PlaCod" DataField="PlaCod"/>
                    <asp:BoundField HeaderText="RutBeneficiario" DataField="RutBeneficiario"/>
                    <asp:BoundField HeaderText="pFormaPagoId" DataField="pFormaPagoId"/>
                    <asp:BoundField HeaderText="UniCodigoEmi" DataField="UniCodigoEmi"/>
                    <asp:BoundField HeaderText="MovCceFecPagoPropuesta" DataField="MovCceFecPagoPropuesta"/>
                    <asp:BoundField HeaderText="ClcId" DataField="ClcId"/>
                    <asp:BoundField HeaderText="pCabReferenciaId" DataField="pCabReferenciaId"/>
                    <asp:BoundField HeaderText="pDetReferenciaId" DataField="pDetReferenciaId"/>
                    <asp:BoundField HeaderText="MovCcePeriodo" DataField="MovCcePeriodo"/>
                    <asp:BoundField HeaderText="CodCtaCteBco" DataField="CodCtaCteBco"/>
                </Columns>
            </asp:GridView>
         </div>

    
        
    <br />


    </form>
</body>
</html>
