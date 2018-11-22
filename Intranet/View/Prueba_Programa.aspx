<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba_Programa.aspx.cs" Inherits="Intranet.View.Prueba_Programa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programa de Producción</title>
     <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<style>
table {
    border-collapse: collapse;
    font-family: "Arial", serif; 
    font-size: 8px;
   /* font-size-adjust: 0.5; */
    
}

 td, th {
    border: 1px solid black;
}
 .newclass{
     color:blue;
 }
 @media (max-width: 1899px) {
    .tableFec{
        display: none !important; 
    }
}
@media (min-width: 1900px)
{
    .tableOferta {
        /* padding-left: 15px;*/
        /*position:inherit;*/
        display: table-cell !important;
        /*width:60%;*/

    }
    .tableTotalHoras{
        display: table-cell !important;
       /* padding-left: 8px;*/
        /*width:10%;*/  
    }
    .tableFec{
        display: table-cell !important;
        /*padding-right: 13px;*/
        /*width:30%;*/  
    }
}
</style>
<script>
    $(window).resize(function () {
        //alert($(window).width());
        document.getElementById('Label2').innerHTML = $(window).width();
        if ($(window).width() < 1250) {
            //     alert('menor a 1900');
            $(".ocultar").each(function () {
                $(this).addClass('hidden');
            });
            $(".textoOT").each(function () {
                $(this).removeClass('col-xs-12 col-sm-7');
                $(this).addClass('col-xs-12 col-sm-10');
            });
        } else {
            //   alert('mayor a 1900');
            $(".ocultar").each(function () {
                $(this).removeClass('hidden');
            });
            $(".textoOT").each(function () {
                $(this).removeClass('col-xs-12 col-sm-10');
                $(this).addClass('col-xs-12 col-sm-7');
            });
        }
        //agregar clase a los div
        //document.getElementById("tddd").style.color = "blue";
        //$('#divErrorBlock').attr('class','alert alert-warning');
        //$('#registros').find('td').each(function () {
        //    var innerDivId = $(this).attr('id');
        //    alert(innerDivId);
        //});
        // $("td-1").addClass("newclass");


       /* if (document.getElementById("td-1").className == "col-xs-12 col-sm-6") {
            alert(document.getElementById("td-1").className);
        } else {
            alert('otra clase');


        }
        */
        //$("#registros td").each(function () {
        //    alert($(this).attr('id'));
        //});
/*FUNCIONA
        $("#registros tbody tr").each(function (index) {
            $(this).children("td").each(function (index2) {
                console.log(index2);
            });
        });
        */



    });

</script>

</head>
   <body ><%--onload="window.print();"--%>
        <form id="form1" runat="server">
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <table id="registros" style="width:100%; border-collapse: collapse;">
   <tbody>
      <tr>
         <td style="width:15%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Lunes </b></td>
         <td style="width:14%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Martes </b></td>
         <td style="width:14%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Miércoles </b></td>
         <td style="width:14%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Jueves </b></td>
         <td style="width:14%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Viernes </b></td>
         <td style="width:14%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Sábado </b></td>
         <td style="width:15%;height:19px;font-size: 12px;border: 1px solid black;" align="center"><b> Domingo </b></td>
      </tr>
      <tr>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> - </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> - </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> - </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> 1 noviembre </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> 2 noviembre </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> 3 noviembre </b></td>
         <td bgcolor="#DCDCDC" style="width:14%;height:17px;font-size: 10px;border: 1px solid black;" align="center"><b> 4 noviembre </b></td>
      </tr>
      <tr>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
          <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
   <div style="font-size: 8px;"><span style="float:right">9:50</span><span style="float:right">10:50&nbsp;-&nbsp;11:50 &nbsp;&nbsp;</span><b>114942</b> lib.2°b matemat(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">5:25</span><b>113022</b> rev.paula #1278(1 Pls)</div>
   <div style="font-size: 8px;"><span style="float:right">9:55</span><b>114965</b> lib.1°b c.natur(1 Pls)</div>
</td>
        <%-- <td style="width:14%;overflow: hidden;max-height: 175px;vertical-align:top;border: 1px solid black;">
              <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> rev.paula #1278(1 Pls)</div>
                  <div class="ocultar col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;vertical-align:top;border: 1px solid black;">
             <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="ocultar col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;vertical-align:top;border: 1px solid black;">
              <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
              <div class="row">
                    <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
            <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;">
              <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>
         <td style="width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;"  >
              <div class="row">
                  <div class="textoOT col-xs-12 col-sm-7"><b>116154</b> catal.(4P)</div>
                  <div class="col-xs-12 col-sm-3">14:00-16:00</div>
                  <div class="col-xs-12 col-sm-2">06:00</div>
              </div>
         </td>--%>
      </tr>

   </tbody>
</table>
<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>



        </form>
    </body>
</html>
