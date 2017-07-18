<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Control_Consumo.aspx.cs" Inherits="Intranet.ModuloMateriaPrima.View.Control_Consumo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 50px;
            height: 22px;
        }
        .style4
        {
        }
        .style5
        {
            width: 115px;
            height: 22px;
        }
        .style7
        {
            width: 115px;
        }
        .style8
        {
            width: 52px;
        }
        .style9
        {
        }
        .style12
        {
            width: 124px;
            height: 22px;
        }
        .style14
        {
            height: 22px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 765px;" 
        align="center">

        <tr>
               <td class="style7">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style9" colspan="4">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdDesperdicio" runat="server" GroupName="rdDespericio" 
                    Text="Ver Consumo Metrics &lt; Desperdicio" />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdDiferenciasDesperdicio" runat="server" 
                    GroupName="rdDespericio" Text="Ver Consumo Metrics &gt; Desperdicio" />
                <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdDiferenciasTeorico" runat="server" 
                    GroupName="rdDespericio" Text="Ver Consumo Metrics &lt; Teorico" />
               </td>
        </tr>

        <tr>
               <td class="style5">
                &nbsp;&nbsp;
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
               
            </td>
            <td class="style3">
               
                <asp:TextBox ID="txtFechaInicio" runat="server" style="margin-left: 0px"></asp:TextBox>
                
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
            </td>
            <td class="style12">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
            <td class="style3">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>

                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>

            </td>
            <td class="style14">
                </td>
            <td class="style8">

                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        <br />
        <div style="height:600px;width:960px; overflow:auto;margin-left:-17px;" >
        <asp:Label ID="Label11" runat="server"></asp:Label>
        </div>
<%--  <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;">
  <tbody>
  <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Codigo </td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">OT</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Nombre OT</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Papel</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Gramaje</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Ancho</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Largo</td>
        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Consumo KGs.</td>
  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
&nbsp;</td>
  </tr>
</tbody></table>



<table id="Table1" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px;margin-left:540px; width:400px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:116px;" 
          class="style16">Consumo Teorico</td>
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style15">Consumo Real</td>
              <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:118px;" 
          class="style16">Consumo Desp.</td>
              <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;" 
          class="style16">&nbsp;</td>
  </tr>
  
  <tr style="background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal;  border-right: 1px solid #ccc;text-align:center;">
     </td>
    <td style="font-weight: normal;  border-right: 1px solid #ccc;text-align:center;" 
          >
      </td>
    <td style="font-weight: normal; border-right: 1px solid #ccc;text-align:center;" 
          >
      </td>
    <td style="font-weight: normal; border-right: 1px solid #ccc;text-align:center;" 
         >
        ver mas</td>
   
  </tr>
</tbody></table>--%>


</asp:Content>
