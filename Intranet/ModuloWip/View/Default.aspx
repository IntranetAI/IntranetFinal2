<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Intranet.ModuloWip.View.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script type="text/javascript">
        function openGame(OT, NombreOT) {
            window.open('Historial_Bobina.aspx?ot=' + OT + '&not=' + NombreOT, 'Detalle OT', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
        
        $(function () {
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var customers = xml.find("Table");
            var row = $("[id*=gvCustomers] tr:last-child").clone(true);
            $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
            $.each(customers, function () {
                var customer = $(this);
                $("td", row).eq(0).html($(this).find("OT").text());
                $("td", row).eq(1).html($(this).find("NombreOT").text());
                $("td", row).eq(2).html($(this).find("Ubicacion").text());
                $("td", row).eq(3).html($(this).find("Posicion").text());
                $("td", row).eq(4).html($(this).find("ID_Control").text());
                $("td", row).eq(5).html($(this).find("Pliego").text());
                $("td", row).eq(6).html($(this).find("Pliegos_Impresos").text());
                $("td", row).eq(7).html($(this).find("Peso_pallet").text());
                $("td", row).eq(8).html($(this).find("Maquina_Proceso").text());
                $("td", row).eq(9).html($(this).find("Estado_Pallet2").text());
                $("td", row).eq(10).html($(this).find("Fecha_Modificacion").text());
                $("td", row).eq(11).html($(this).find("Usuario").text());
                $("td", row).eq(12).html($(this).find("VerMas").text());
                $("[id*=gvCustomers]").append(row);
                row = $("[id*=gvCustomers] tr:last-child").clone(true);
            });
        }
    </script>
    <style type="text/css">
       .tablestyle 
        {   
            border: solid 1px #7f7f7f;
            width: 1180px;
            vertical-align:top;   
            font-family:Arial; 
            font-size:12px;
        }
        .altrowstyle 
        {
            background-color: #edf5ff;
    
        }
        .headerstyle th 
        {
            background: url(img/sprite.png) repeat-x 0px 0px;
            border-color: #989898 #cbcbcb #989898 #989898;
            border-style: solid solid solid none;
            border-width: 1px 1px 1px medium;
             
            padding: 4px 5px 4px 10px;
            text-align:left;
            vertical-align:  top ;
            background-color:#CDE5FF;
            position:relative ;

        }  

        .headerstyle th a
        {
            font-weight: bold;
            text-decoration: none;
            text-align: center;
            color: #063E77;
            display: block;
            padding-right: 10px;
        }  
        .rowstyle .sortaltrow, .altrowstyle .sortaltrow 
        {
            background-color: #edf5ff;
    
        }

        .rowstyle .sortrow, .altrowstyle .sortrow 
        {
            background-color: #dbeaff;
        }

        .rowstyle td, .altrowstyle td 
        {
            padding: 4px 10px 4px 10px;
            border-right: solid 1px #cbcbcb;
        }

        .headerstyle .sortascheader 
        {
            background: url(App_Themes/img/sprite.png) repeat-x 0px -100px;
           font-weight:bold;
        }

        .headerstyle .sortascheader a 
        {
            background: url(App_Themes/img/dt-arrow-up.png) no-repeat right 50%;
           font-weight:bold;
        } 

        .headerstyle .sortdescheader 
        {
            background: url(App_Themes/img/sprite.png) repeat-x 0px -100px;
           font-weight:bold;
        }   

        .headerstyle .sortdescheader a 
        {
            background: url(App_Themes/img/dt-arrow-dn.png) no-repeat right 50%;
           font-weight:bold;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" CssClass="tablestyle">
        <AlternatingRowStyle CssClass="altrowstyle" />
        <HeaderStyle CssClass="headerstyle" />
        <RowStyle CssClass="rowstyle" Wrap="false" />  
        <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
        <EmptyDataTemplate >
            No Records Found
        </EmptyDataTemplate> 
        <Columns>
            <asp:BoundField DataField="OT" HeaderText="OT" />
            <asp:BoundField DataField="NombreOT" HeaderText="Nombre OT" />
            <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" />
            <asp:BoundField DataField="Posicion" HeaderText="Posicion" />
            <asp:BoundField DataField="ID_Control" HeaderText="ID_Control" />
            <asp:BoundField DataField="Pliego" HeaderText="Pliego" />
            <asp:BoundField DataField="Pliegos_Impresos" HeaderText="Pliegos_Impresos" />
            <asp:BoundField DataField="Peso_pallet" HeaderText="Peso_pallet" />
            <asp:BoundField DataField="Maquina_Proceso" HeaderText="Maquina_Proceso" />
            <asp:BoundField DataField="Estado_Pallet2" HeaderText="Estado_Pallet2" />
            <asp:BoundField DataField="Fecha_Modificacion" HeaderText="Fecha_Modificacion" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="VerMas" HeaderText="VerMas" />
        </Columns>
    </asp:GridView>

    </form>
</body>
</html>
