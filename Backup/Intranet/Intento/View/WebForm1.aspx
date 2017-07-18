<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Intranet.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var chart = new CanvasJS.Chart("chartContainer",
	{
	    title: {
	        text: "Top Categories of New Year's Resolution"
	    },
	    exportFileName: "Pie Chart",
	    exportEnabled: false,
	    animationEnabled: true,
	    legend: {
	        verticalAlign: "center",
	        horizontalAlign: "left",
	        fontSize: 12,
	        fontFamily: "Helvetica"
	    },
	    data: [
		{
		    type: "pie",
		    showInLegend: true,
		    toolTipContent: "{name}: <strong>{y}%</strong>",
		    indexLabel: "{name} {y}%",
		    dataPoints: [
				{ y: 35, name: "Health", exploded: true },
				{ y: 20, name: "Finance" },
				{ y: 18, name: "Career" },
				{ y: 15, name: "Education" },
				{ y: 5, name: "Family" },
				{ y: 7, name: "Real Estate" }
			]
		}
	]
	});
            chart.render();
        }
</script>
<script type="text/javascript" src="../../Estructura/Javascript/canvasjs.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
        $(function () {

            $('#container').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: true
                },

                title: {
                    text: 'Velocidad'
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#00FF00',
                        borderWidth: 0,
                        outerRadius: '115%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 200,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: 'Pliegos/h'
                    },
                    plotBands: [{
                        from: 0,
                        to: 120,
                        color: '#55BF3B' // green
                    }, {
                        from: 120,
                        to: 160,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: 160,
                        to: 200,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [80],
                    tooltip: {
                        valueSuffix: ' km/h'
                    }
                }]

            }
            
//            ,
//            // Add some life
//       function (chart) {
////            if (!chart.renderer.forExport) {
////                setInterval(function () {
////                    var point = chart.series[0].points[0],
////                        newVal,
////                        inc = Math.round((Math.random() - 0.5) * 20);

////                    newVal = point.y + inc;
////                    if (newVal < 0 || newVal > 200) {
////                        newVal = point.y - inc;
////                    }

////                    point.update(120);

////                }, 3000);
////            }
            //       });
            // )}); en el caso de llevar una funcion
        )});
		</script>

<script type="text/javascript">
    $(function () {

        $('#container0').highcharts({

            chart: {
                type: 'gauge',
                plotBackgroundColor: null,
                plotBackgroundImage: null,
                plotBorderWidth: 0,
                plotShadow: false
            },

            title: {
                text: 'Speedometer'
            },

            pane: {
                startAngle: -150,
                endAngle: 150,
                background: [{
                    backgroundColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                        stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                    },
                    borderWidth: 0,
                    outerRadius: '109%'
                }, {
                    backgroundColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                        stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                    },
                    borderWidth: 1,
                    outerRadius: '107%'
                }, {
                    // default background
                }, {
                    backgroundColor: '#00FF00',
                    borderWidth: 0,
                    outerRadius: '115%',
                    innerRadius: '103%'
                }]
            },

            // the value axis
            yAxis: {
                min: 0,
                max: 200,

                minorTickInterval: 'auto',
                minorTickWidth: 1,
                minorTickLength: 10,
                minorTickPosition: 'inside',
                minorTickColor: '#666',

                tickPixelInterval: 30,
                tickWidth: 2,
                tickPosition: 'inside',
                tickLength: 10,
                tickColor: '#666',
                labels: {
                    step: 2,
                    rotation: 'auto'
                },
                title: {
                    text: 'km/h'
                },
                plotBands: [{
                    from: 0,
                    to: 120,
                    color: '#55BF3B' // green
                }, {
                    from: 120,
                    to: 160,
                    color: '#DDDF0D' // yellow
                }, {
                    from: 160,
                    to: 200,
                    color: '#DF5353' // red
                }]
            },

            series: [{
                name: 'Speed',
                data: [80],
                tooltip: {
                    valueSuffix: ' km/h'
                }
            }]

        },
        // Add some life
        function (chart) {
            if (!chart.renderer.forExport) {
                setInterval(function () {
                    var point = chart.series[0].points[0],
                        newVal,
                        inc = Math.round((Math.random() - 0.5) * 20);

                    newVal = point.y + inc;
                    if (newVal < 0 || newVal > 200) {
                        newVal = point.y - inc;
                    }

                    point.update(newVal);

                }, 3000);
            }
        });
    });
		</script>


<script type="text/javascript">
            $(function () {

                $('#container1').highcharts({

                    chart: {
                        type: 'gauge',
                        plotBackgroundColor: null,
                        plotBackgroundImage: null,
                        plotBorderWidth: 0,
                        plotShadow: false
                    },

                    title: {
                        text: 'Speedometer'
                    },

                    pane: {
                        startAngle: -150,
                        endAngle: 150,
                        background: [{
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                            },
                            borderWidth: 0,
                            outerRadius: '109%'
                        }, {
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                            },
                            borderWidth: 1,
                            outerRadius: '107%'
                        }, {
                            // default background
                        }, {
                            backgroundColor: '#00FF00',
                            borderWidth: 0,
                            outerRadius: '115%',
                            innerRadius: '103%'
                        }]
                    },

                    // the value axis
                    yAxis: {
                        min: 0,
                        max: 200,

                        minorTickInterval: 'auto',
                        minorTickWidth: 1,
                        minorTickLength: 10,
                        minorTickPosition: 'inside',
                        minorTickColor: '#666',

                        tickPixelInterval: 30,
                        tickWidth: 2,
                        tickPosition: 'inside',
                        tickLength: 10,
                        tickColor: '#666',
                        labels: {
                            step: 2,
                            rotation: 'auto'
                        },
                        title: {
                            text: 'km/h'
                        },
                        plotBands: [{
                            from: 0,
                            to: 120,
                            color: '#55BF3B' // green
                        }, {
                            from: 120,
                            to: 160,
                            color: '#DDDF0D' // yellow
                        }, {
                            from: 160,
                            to: 200,
                            color: '#DF5353' // red
                        }]
                    },

                    series: [{
                        name: 'Speed',
                        data: [80],
                        tooltip: {
                            valueSuffix: ' km/h'
                        }
                    }]

                },
                // Add some life
        function (chart) {
            if (!chart.renderer.forExport) {
                setInterval(function () {
                    var point = chart.series[0].points[0],
                        newVal,
                        inc = Math.round((Math.random() - 0.5) * 20);

                    newVal = point.y + inc;
                    if (newVal < 0 || newVal > 200) {
                        newVal = point.y - inc;
                    }

                    point.update(newVal);

                }, 3000);
            }
        });
            });
		</script>
       
        <script src="../../js/highcharts.js"></script>
<script src="../../js/highcharts-more.js"></script>
<script src="../../js/modules/exporting.js"></script>
<div>
OT:
NombreOT:
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button2"
        runat="server" Text="Button" onclick="Button2_Click" />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
<div id="container" 
        style="min-width: 310px; max-width: 400px; height: 225px; margin: 0 auto; width: 326px;"></div>
</div>
    </div>
    </form>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <div id="container0" 
                    style="min-width: 310px; max-width: 400px; height: 225px; margin: 0 auto; width: 326px;">
                </div>
            </td>
            <td>
                <div id="container1" 
                    style="min-width: 310px; max-width: 400px; height: 225px; margin: 0 auto; width: 326px;">
                </div>
            </td>
            <td>
                <div id="container2" 
                    style="min-width: 310px; max-width: 400px; height: 225px; margin: 0 auto; width: 326px;">
                </div>
            </td>
        </tr>
        <tr><td><div id="chartContainer" style="height: 300px; width: 100%;"></div></td></tr>
    </table>
</body>
</html>
