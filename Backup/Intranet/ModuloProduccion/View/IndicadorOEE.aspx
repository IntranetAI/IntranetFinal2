<%@ Page Title="" Language="C#" MasterPageFile="~/Estructura/View/MasterAplicaciones.Master"
    AutoEventWireup="true" CodeBehind="IndicadorOEE.aspx.cs" Inherits="Intranet.ModuloProduccion.View.IndicadorOEE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" 
                        Style="height: 26px" Visible="false"/>
    <div class="heading">
        <!--  .heading-->
        <h3>
            Chartjs</h3>
        <div class="resBtnSearch">
            <a href="#"><span class="s16 icomoon-icon-search-3"></span></a>
        </div>
        <div class="search">
            <!-- .search -->
            <form id="searchform" class="form-horizontal" action="search.html">
            <input class="top-search from-control" placeholder="Search here ..." type="text">
            <input class="search-btn" value="" type="submit">
            </form>
        </div>
        <!--  /search -->
        <ul class="breadcrumb">
            <li>You are here:</li><li><a href="index.html" class="tip" title="" data-original-title="back to dashboard">
                <i class="s16 icomoon-icon-screen-2"></i></a></li>
            <span class="divider"><i class="s16 icomoon-icon-arrow-right-3"></i></span>
            <li><a href="#">Charts</a></li><span class="divider"><i class="s16 icomoon-icon-arrow-right-3"></i></span><li>
                Chartjs</li></ul>
    </div>
    <div class="row">
                        <div class="col-lg-6">
                            <!-- col-lg-6 start here -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr0">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Line chart</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="line-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr1">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Line chart unfilled
                                        <small>and curved</small>
                                    </h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="line-unfilled-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr2">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Pie chart</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="pie-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr3">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Radar chart</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="radar-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                        </div>
                        <!-- col-lg-6 end here -->
                        <div class="col-lg-6">
                            <!-- col-lg-6 start here -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr4">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Line chart with dots</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body" style="display: block;">
                                    <div class="canvas-holder">
                                        <canvas id="line-dots-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr5">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Bar chart</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="bar-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr6">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Donut chart</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="donut-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                            <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr7">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Polar area</h4>
                                <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="brocco-icon-refresh s12"></i></a><a href="#" class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="#" class="panel-close"><i class="icomoon-icon-close"></i></a></div></div>
                                <div class="panel-body">
                                    <div class="canvas-holder">
                                        <canvas id="polar-chartjs" height="247" style="width: 743px; height: 247px;" width="743"></canvas>
                                    </div>
                                </div>
                            </div>
                            <!-- End .panel -->
                        </div>
                        <!-- col-lg-6 end here -->
                    </div>
</asp:Content>
