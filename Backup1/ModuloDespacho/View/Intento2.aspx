<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Intento2.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Intento2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Draggable directions</title>
    <style>
        html, body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        #map
        {
            height: 100%;
            float: left;
            width: 63%;
            height: 100%;
        }
        #right-panel
        {
            float: right;
            width: 34%;
            height: 100%;
        }
        #right-panel
        {
            font-family: 'Roboto' , 'sans-serif';
            line-height: 30px;
            padding-left: 10px;
        }
        
        #right-panel select, #right-panel input
        {
            font-size: 15px;
        }
        
        #right-panel select
        {
            width: 100%;
        }
        
        #right-panel i
        {
            font-size: 12px;
        }
        
        .panel
        {
            height: 100%;
            overflow: auto;
        }
        .adp-directions
        {
            display:none;
        }
    </style>
</head>
<body>
    <div id="map">
    </div>
    <div id="right-panel">
        <p>
            Distancia Total : <span id="total"></span>
        </p>
    </div>
    <input type="button" value="Imprimir Tabla" onclick="javascript:imprSelec('right-panel');function imprSelec(muestra)
{var ficha=document.getElementById(muestra);var ventimp=window.open(' ','popimpr');ventimp.document.write(ficha.innerHTML);ventimp.document.close();ventimp.print();ventimp.close();};" />
    <script>
        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: { lat: 41.85, lng: -87.65 }
            });

            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer({
                draggable: true,
                map: map,
                panel: document.getElementById('right-panel')
            });

            directionsDisplay.addListener('directions_changed', function () {
                computeTotalDistance(directionsDisplay.getDirections());
            });

            displayRoute('Gladys Marín Millie 6920,Santiago, CL', 'Gladys Marín Millie 6920,Santiago, CL', directionsService,
      directionsDisplay);
        }

        function displayRoute(origin, destination, service, display) {
            

            service.route({
                origin: origin,
                destination: destination,
                waypoints: [{ location: 'ROSARIO NORTE 555, Santiago, CL' },{ location: 'AV. KENNEDY 9001, Santiago, CL'} ],
                travelMode: google.maps.TravelMode.DRIVING,
                avoidTolls: true
            }, function (response, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    display.setDirections(response);
                } else {
                    alert('Could not display directions due to: ' + status);
                }
            });
        }

        function computeTotalDistance(result) {
            var total = 0;
            var distancia = "";
            var myroute = result.routes[0];
            for (var i = 0; i < myroute.legs.length; i++) {
                total += myroute.legs[i].distance.value;
                distancia += myroute.legs[i].distance.value + ",";
            }
            total = total / 1000;
            document.getElementById('total').innerHTML = total + ' km' + distancia;
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyASjijPgIjASnXU7DagTSfyn2Qt1YGtIm0&amp;signed_in=true&amp;callback=initMap" async="" defer=""></script>
</body>
</html>
