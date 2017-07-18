<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ruta.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Ruta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    
        <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
        <meta charset="utf-8">
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
                width: 70%;
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
            
            #right-panel
            {
                margin: 20px;
                border-width: 2px;
                width: 20%;
                float: left;
                text-align: left;
                padding-top: 20px;
            }
            #directions-panel
            {
                margin-top: 20px;
                background-color: #FFEE77;
                padding: 10px;
            }
        </style>
    </head>
    <body>
        <div id="map">
        </div>
        <div id="right-panel">
            <div>
                
                <b>Direcciones:</b>
                <br>
                <i>(Ctrl-Click for multiple selection)</i>
                <br>
                <select multiple id="waypoints">
                    <option value="Ricardo Cumming, santiago, CL">Ricardo Cumming</option>
                    <option value="ROSARIO NORTE 555, Santiago, CL">ROSARIO NORTE 555</option>
                    <option value="AV. KENNEDY 9001, Santiago, CL">AV. KENNEDY 9001</option>
                </select>
                <br>
                <input type="submit" id="submit">
            </div>
            <div id="directions-panel">
            </div>
        </div>
        <script>
            function initMap() {
                var directionsService = new google.maps.DirectionsService;
                var directionsDisplay = new google.maps.DirectionsRenderer;
                var map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 6,
                    center: { lat: 41.85, lng: -87.65 }
                });
                directionsDisplay.setMap(map);

                document.getElementById('submit').addEventListener('click', function () {
                    calculateAndDisplayRoute(directionsService, directionsDisplay);
                });
            }

            function calculateAndDisplayRoute(directionsService, directionsDisplay) {
                var waypts = [];
                var checkboxArray = document.getElementById('waypoints');
                for (var i = 0; i < checkboxArray.length; i++) {
                    if (checkboxArray.options[i].selected) {
                        waypts.push({
                            location: checkboxArray[i].value,
                            stopover: true
                        });
                    }
                }

                directionsService.route({
                    origin: 'Gladys Marín Millie 6920,Santiago, CL',
                    destination: 'Gladys Marín Millie 6920,Santiago, CL',
                    waypoints: waypts,
                    optimizeWaypoints: true,
                    travelMode: google.maps.TravelMode.DRIVING
                }, function (response, status) {
                    if (status === google.maps.DirectionsStatus.OK) {
                        directionsDisplay.setDirections(response);
                        var route = response.routes[0];
                        var summaryPanel = document.getElementById('directions-panel');
                        summaryPanel.innerHTML = '';
                        // For each route, display summary information.
                        for (var i = 0; i < route.legs.length; i++) {
                            var routeSegment = i + 1;
                            summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
            '</b><br>';
                            summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                            summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                            summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                        }
                    } else {
                        window.alert('Directions request failed due to ' + status);
                    }
                });
            }

        </script>
        
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyASjijPgIjASnXU7DagTSfyn2Qt1YGtIm0&amp;signed_in=true&amp;callback=initMap" async="" defer=""></script>
    </body>
</html>
