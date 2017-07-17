<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Det_facturacion_print.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Det_facturacion_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @media print
        {
            table {
                border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1000px;
            }
            thead {
                font:11px Arial, Helvetica, sans-serif;background:#f3f4f9; height: 22px;   color: #003e7e; text-align: left;
            }
            tbody  {
                height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top
            }
            td {
                font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
            }
            h1 
            {
                font:16px Arial, Helvetica, sans-serif;font-weight: bold;
            }
            div.saltopagina {
                display:block; page-break-before:always;
            }
        }
        @media screen
        {
            table {
                border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1000px;
            }
            thead {
                font:11px Arial, Helvetica, sans-serif;background:#f3f4f9; height: 22px;   color: #003e7e; text-align: left;
            }
            tbody  {
                height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top
            }
            td {
                font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
            }
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblImprimir" runat="server"></asp:Label>   
    </div>
    </form>
</body>
</html>
