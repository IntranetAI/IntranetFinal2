<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SuperAdmin.ModuloProduccion.View.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html class=" js no-touch webkit chrome win js">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Chartjs | Supr Admin Template</title>
    <!-- Mobile specific metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <!-- Force IE9 to render in normal mode -->
    <!--[if IE]><meta http-equiv="x-ua-compatible" content="IE=9" /><![endif]-->
    <meta name="author" content="">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="application-name" content="">
    <!-- Import google fonts - Heading first/ text second -->
    <link href="../../Estructura/Css/fonts.googleapis.comOpensans.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/fonts.googleapis.comDroidSans.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/icons.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/bootstrap_modificado.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Estructura/Css/custom.css" rel="stylesheet" type="text/css" />
    <!-- Fav and touch icons -->
    <style type="text/css">
        .jqstooltip
        {
            position: absolute;
            left: 0px;
            top: 0px;
            visibility: hidden;
            background: rgb(0, 0, 0) transparent;
            background-color: rgba(0,0,0,0.6);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000);
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000)";
            color: white;
            font: 10px arial, san serif;
            text-align: left;
            white-space: nowrap;
            padding: 5px;
            border: 1px solid white;
            z-index: 10000;
        }
        .jqsfield
        {
            color: white;
            font: 10px arial, san serif;
            text-align: left;
        }
    </style>
</head>
<body class=" fixed-header fixed-left-sidebar fixed-right-sidebar shrink-header pace-done">
    <div class="pace  pace-inactive">
        <div class="pace-progress" data-progress-text="100%" data-progress="99" style="transform: translate3d(100%, 0px, 0px);">
            <div class="pace-progress-inner">
            </div>
        </div>
        <div class="pace-activity">
        </div>
    </div>
    <!--[if lt IE 9]>
      <p class="browsehappy">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
    <![endif]-->
    <!-- .#header -->
    <div id="header" class="header-fixed shrink">
        <nav class="navbar navbar-default" role="navigation">
                <div class="navbar-header">
                    <a class="navbar-brand" href="http://themes.suggelab.com/supr/index.html">
                Supr.<span class="slogan">admin</span>
            </a>
                </div>
                <div id="navbar-no-collapse" class="navbar-no-collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <!--Sidebar collapse button-->
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="collapseBtn leftbar"><i class="s16 minia-icon-list-3"></i></a>
                        </li>
                        <li>
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="tipB reset-layout" title="" data-original-title="Reset panel postions"><i class="s16 icomoon-icon-history"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="s16 icomoon-icon-cog-2"></i><span class="txt"> Settings</span>
                                <b class="caret"></b>
                            </a>
                            <ul class="dropdown-menu left dropdown-form template-settings">
                                <li class="menu">
                                    <ul role="menu">
                                        <li><strong>Template settings</strong>
                                        </li>
                                        <li>
                                            <div class="toggle-custom">
                                                <label class="toggle" data-on="ON" data-off="OFF">
                                                    <input type="checkbox" id="fixed-header-toggle" name="fixed-header-toggle" checked="">
                                                    <span class="button-checkbox"></span>
                                                </label>
                                                <label for="fixed-header-toggle">Fixed header</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="toggle-custom">
                                                <label class="toggle" data-on="ON" data-off="OFF">
                                                    <input type="checkbox" id="fixed-left-sidebar" name="fixed-left-sidebar" checked="">
                                                    <span class="button-checkbox"></span>
                                                </label>
                                                <label for="fixed-left-sidebar">Fixed Left Sidebar</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="toggle-custom">
                                                <label class="toggle" data-on="ON" data-off="OFF">
                                                    <input type="checkbox" id="fixed-right-sidebar" name="fixed-right-sidebar" checked="">
                                                    <span class="button-checkbox"></span>
                                                </label>
                                                <label for="fixed-right-sidebar">Fixed Right Sidebar</label>
                                            </div>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                <i class="s16 minia-icon-envelope"></i><span class="txt">Messages</span><span class="notification">8</span>
                            </a>
                            <ul class="dropdown-menu left animated fadeIn">
                                <li class="menu">
                                    <ul class="messages">
                                        <li class="header"><strong>Messages</strong> (10) emails and (2) PM</li>
                                        <li>
                                            <span class="icon"><i class="s16 icomoon-icon-user-plus"></i></span>
                                            <span class="name"><a data-toggle="modal" href="http://themes.suggelab.com/supr/charts-chartjs.html#myModal1"><strong>Sammy Morerira</strong></a><span class="time">35 min ago</span></span>
                                            <span class="msg">I have question about new function ...</span>
                                        </li>
                                        <li>
                                            <span class="icon avatar"><img src="../../Estructura/Image/avatar.jpg" alt=""></span>
                                            <span class="name"><a data-toggle="modal" href="http://themes.suggelab.com/supr/charts-chartjs.html#myModal1"><strong>George Michael</strong></a><span class="time">1 hour ago</span></span>
                                            <span class="msg">I need to meet you urgent please call me ...</span>
                                        </li>
                                        <li>
                                            <span class="icon"><i class="s16 icomoon-icon-envelop"></i></span>
                                            <span class="name"><a data-toggle="modal" href="http://themes.suggelab.com/supr/charts-chartjs.html#myModal1"><strong>Ivanovich</strong></a><span class="time">1 day ago</span></span>
                                            <span class="msg">I send you my suggestion, please look and ...</span>
                                        </li>
                                        <li class="view-all"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#">View all messages <i class="s16 fa fa-angle-double-right"></i></a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="nav navbar-right usernav">
                        <li class="dropdown">
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="s16 icomoon-icon-earth"></i><span class="notification">3</span>
                            </a>
                            <ul class="dropdown-menu right" style="margin-left: -81px;">
                                <li class="menu">
                                    <ul class="notif">
                                        <li class="header"><strong>Notifications</strong> (3) items</li>
                                        <li>
                                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">
                                                <span class="icon"><i class="s16 icomoon-icon-user-plus"></i></span>
                                                <span class="event">1 User is registred</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">
                                                <span class="icon"><i class="s16 icomoon-icon-bubble-3"></i></span>
                                                <span class="event">Jony add 1 comment</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">
                                                <span class="icon"><i class="s16 icomoon-icon-new"></i></span>
                                                <span class="event">admin Julia added post with a long description</span>
                                            </a>
                                        </li>
                                        <li class="view-all"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#">View all notifications <i class="s16 fa fa-angle-double-right"></i></a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="dropdown-toggle avatar" data-toggle="dropdown">
                                <img src="../../Estructura/Image/avatar.jpg" alt="" class="image">
                                <span class="txt">admin@supr.com</span>
                                <b class="caret"></b>
                            </a>
                            <ul class="dropdown-menu right" style="margin-left: 3.5px;">
                                <li class="menu">
                                    <ul>
                                        <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"><i class="s16 icomoon-icon-user-plus"></i>Edit profile</a>
                                        </li>
                                        <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"><i class="s16 icomoon-icon-bubble-2"></i>Comments</a>
                                        </li>
                                        <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"><i class="s16 icomoon-icon-plus"></i>Add user</a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li><a href="http://themes.suggelab.com/supr/login.html"><i class="s16 icomoon-icon-exit"></i><span class="txt"> Logout</span></a>
                        </li>
                        <li><a id="toggle-right-sidebar" href="http://themes.suggelab.com/supr/charts-chartjs.html#"><i class="icomoon-icon-indent-increase s16"></i></a>
                        </li>
                    </ul>
                </div>
                <!-- /.nav-collapse -->
            </nav>
        <!-- /navbar -->
    </div>
    <!-- / #header -->
    <div id="wrapper">
        <!-- #wrapper -->
        <!--Sidebar background-->
        <div id="sidebarbg" class="">
        </div>
        <!--Sidebar content-->
        <div id="sidebar" class="page-sidebar sidebar-fixed">
            <div class="shortcuts">
                <ul>
                    <li><a href="http://themes.suggelab.com/supr/support.html" title="" class="tip" data-original-title="Support section">
                        <i class="s24 icomoon-icon-support"></i></a></li>
                    <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#" title="" class="tip"
                        data-original-title="Database backup"><i class="s24 icomoon-icon-database"></i></a>
                    </li>
                    <li><a href="http://themes.suggelab.com/supr/charts.html" title="" class="tip" data-original-title="Sales statistics">
                        <i class="s24 icomoon-icon-pie-2"></i></a></li>
                    <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#" title="" class="tip"
                        data-original-title="Write post"><i class="s24 icomoon-icon-pencil"></i></a>
                    </li>
                </ul>
            </div>
            <!-- End search -->
            <!-- Start .sidebar-inner -->
            <div class="sidebar-inner">
                <!-- Start .sidebar-scrollarea -->
                <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto;
                    height: 100%;">
                    <div class="sidebar-scrollarea" style="overflow: hidden; width: auto; height: 100%;">
                        <div class="sidenav">
                            <div class="sidebar-widget mb0">
                                <h6 class="title mb0">
                                    Navigation</h6>
                            </div>
                            <!-- End .sidenav-widget -->
                            <div class="mainnav show-arrows">
                                <ul>
                                    <li><a href="http://themes.suggelab.com/supr/index.html"><i class="s16 icomoon-icon-screen-2">
                                    </i><span class="txt">Dashboard</span> </a></li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="active-state notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop">
                                        </i><i class="s16 icomoon-icon-stats-up"></i><span class="txt">Charts</span> </a>
                                        <ul class="sub" style="display: none;">
                                            <li><a href="http://themes.suggelab.com/supr/charts-flot.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Flot charts</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/charts-rickshaw.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Rickshaw charts</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/charts-morris.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Morris charts</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html" class="active"><i
                                                class="s16 icomoon-icon-arrow-right-3"></i><span class="txt">Chartjs</span><span
                                                    class="indicator"></span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/charts-other.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Other charts</span></a> </li>
                                        </ul>
                                    </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-list">
                                        </i><span class="txt">Forms</span><span class="notification red">6</span></a>
                                        <ul class="sub" style="display: none;">
                                            <li><a href="http://themes.suggelab.com/supr/forms-basic.html"><i class="s16 icomoon-icon-file">
                                            </i><span class="txt">Basic forms</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/forms-advanced.html"><i class="s16 icomoon-icon-file">
                                            </i><span class="txt">Advanced forms</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/forms-layouts.html"><i class="s16 icomoon-icon-file">
                                            </i><span class="txt">Form layouts</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/forms-wizard.html"><i class="s16 fa fa-magic">
                                            </i><span class="txt">Form wizard</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/forms-validation.html"><i class="s16 fa fa-check">
                                            </i><span class="txt">From validation</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/code-editor.html"><i class="s16 icomoon-icon-code">
                                            </i><span class="txt">Code editor</span></a> </li>
                                        </ul>
                                    </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-table-2">
                                        </i><span class="txt">Tables</span></a>
                                        <ul class="sub">
                                            <li><a href="http://themes.suggelab.com/supr/tables-basic.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Basic tables</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/tables-data.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Data tables</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/tables-ajax.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Ajax tables</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/tables-pricing.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Pricing tables</span></a> </li>
                                        </ul>
                                    </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-equalizer-2">
                                        </i><span class="txt">UI Elements</span></a>
                                        <ul class="sub">
                                            <li><a href="http://themes.suggelab.com/supr/icons.html"><i class="s16 icomoon-icon-rocket">
                                            </i><span class="txt">Icons</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/buttons.html"><i class="s16 icomoon-icon-point-up">
                                            </i><span class="txt">Buttons</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/tabs.html"><i class="s16 icomoon-icon-tab">
                                            </i><span class="txt">Tabs</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/accordions.html"><i class="s16 iconic-icon-new-window">
                                            </i><span class="txt">Accordions</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/modals.html"><i class="s16 cut-icon-popout">
                                            </i><span class="txt">Modals</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/sliders.html"><i class="s16 fa fa-sliders">
                                            </i><span class="txt">Sliders</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/progressbars.html"><i class="s16 icomoon-icon-steps">
                                            </i><span class="txt">Progressbars</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/notifications.html"><i class="s16  icomoon-icon-bubble-notification">
                                            </i><span class="txt">Notifications</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/typo.html"><i class="s16 icomoon-icon-font">
                                            </i><span class="txt">Typography</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/lists.html"><i class="s16 icomoon-icon-numbered-list">
                                            </i><span class="txt">Lists</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/grids.html"><i class="s16 icomoon-icon-grid">
                                            </i><span class="txt">Grids</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/ui-other.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Other</span></a> </li>
                                        </ul>
                                    </li>
                                    <li><a href="http://themes.suggelab.com/supr/portlets.html"><i class="s16 minia-icon-window-4">
                                    </i><span class="txt">Portlets</span></a> </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-envelop">
                                        </i><span class="txt">Email</span><span class="notification green">12</span></a>
                                        <ul class="sub">
                                            <li><a href="http://themes.suggelab.com/supr/email-inbox.html"><i class="s16 fa fa-inbox">
                                            </i><span class="txt">Inbox</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/email-read.html"><i class="s16 fa fa-mail-forward">
                                            </i><span class="txt">Read email</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/email-write.html"><i class="s16 fa fa-mail-reply">
                                            </i><span class="txt">Write email</span></a> </li>
                                        </ul>
                                    </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-map">
                                        </i><span class="txt">Maps</span></a>
                                        <ul class="sub">
                                            <li><a href="http://themes.suggelab.com/supr/maps-google.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Google maps</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/maps-vector.html"><i class="s16 icomoon-icon-arrow-right-3">
                                            </i><span class="txt">Vector maps</span></a> </li>
                                        </ul>
                                    </li>
                                    <li><a href="http://themes.suggelab.com/supr/file.html"><i class="s16 icomoon-icon-upload">
                                    </i><span class="txt">File Manager</span></a> </li>
                                    <li><a href="http://themes.suggelab.com/supr/widgets.html"><i class="s16 icomoon-icon-cube">
                                    </i><span class="txt">Widgets</span><span class="notification red">9</span></a>
                                    </li>
                                    <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                        class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-folder">
                                        </i><span class="txt">Pages</span><span class="notification blue">11</span></a>
                                        <ul class="sub">
                                            <li><a href="http://themes.suggelab.com/supr/blank.html"><i class="s16 icomoon-icon-file-2">
                                            </i><span class="txt">Blank page</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/calendar.html"><i class="s16 icomoon-icon-calendar">
                                            </i><span class="txt">Calendar</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/gallery.html"><i class="s16 icomoon-icon-image-2">
                                            </i><span class="txt">Gallery</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/timeline.html"><i class="s16 entypo-icon-clock">
                                            </i><span class="txt">Timeline</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/login.html"><i class="s16 icomoon-icon-unlocked">
                                            </i><span class="txt">Login</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/lock-screen.html"><i class="s16 icomoon-icon-lock">
                                            </i><span class="txt">Lock screen</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/register.html"><i class="s16 icomoon-icon-user-plus-2">
                                            </i><span class="txt">Register</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/lost-password.html"><i class="s16 icomoon-icon-file">
                                            </i><span class="txt">Lost password</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/profile.html"><i class="s16 icomoon-icon-profile">
                                            </i><span class="txt">User profile</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/invoice.html"><i class="s16 icomoon-icon-file">
                                            </i><span class="txt">Invoice</span></a> </li>
                                            <li><a href="http://themes.suggelab.com/supr/faq.html"><i class="s16 icomoon-icon-attachment">
                                            </i><span class="txt">FAQ</span></a> </li>
                                            <li class="hasSub"><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="notExpand"><i class="icomoon-icon-arrow-down-2 s16 hasDrop"></i><i class="s16 icomoon-icon-file">
                                                </i><span class="txt">Error pages</span><span class="notification">6</span></a>
                                                <ul class="sub">
                                                    <li><a href="http://themes.suggelab.com/supr/403.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Error 403</span></a> </li>
                                                    <li><a href="http://themes.suggelab.com/supr/404.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Error 404</span></a> </li>
                                                    <li><a href="http://themes.suggelab.com/supr/405.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Error 405</span></a> </li>
                                                    <li><a href="http://themes.suggelab.com/supr/500.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Error 500</span></a> </li>
                                                    <li><a href="http://themes.suggelab.com/supr/503.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Error 503</span></a> </li>
                                                    <li><a href="http://themes.suggelab.com/supr/offline.html"><i class="s16 icomoon-icon-file">
                                                    </i><span class="txt">Offline page</span></a> </li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <!-- End sidenav -->
                        <div class="sidebar-widget">
                            <h6 class="title">
                                Monthly Bandwidth Transfer</h6>
                            <div class="content clearfix">
                                <i class="s16 icomoon-icon-loop pull-left mr10"></i>
                                <div class="progress progress-bar-xs pull-left mt5 tip" title="" data-original-title="87%">
                                    <div class="progress-bar progress-bar-danger" style="width: 87%;">
                                    </div>
                                </div>
                                <span class="percent pull-right">87%</span>
                                <div class="stat">
                                    19419.94 / 12000 MB</div>
                            </div>
                        </div>
                        <!-- End .sidenav-widget -->
                        <div class="sidebar-widget">
                            <h6 class="title">
                                Disk Space Usage</h6>
                            <div class="content clearfix">
                                <i class="s16  icomoon-icon-storage-2 pull-left mr10"></i>
                                <div class="progress progress-bar-xs pull-left mt5 tip" title="" data-original-title="16%">
                                    <div class="progress-bar progress-bar-success" style="width: 16%;">
                                    </div>
                                </div>
                                <span class="percent pull-right">16%</span>
                                <div class="stat">
                                    304.44 / 8000 MB</div>
                            </div>
                        </div>
                        <!-- End .sidenav-widget -->
                        <div class="sidebar-widget">
                            <h6 class="title">
                                Ad sense stats</h6>
                            <div class="content">
                                <div class="stats">
                                    <div class="item">
                                        <div class="head clearfix">
                                            <div class="txt">
                                                Advert View</div>
                                        </div>
                                        <i class="s16 icomoon-icon-eye pull-left"></i>
                                        <div class="number">
                                            21,501</div>
                                        <div class="change">
                                            <i class="s24 icomoon-icon-arrow-up-2 color-green"></i>5%
                                        </div>
                                        <span id="stat1" class="spark">
                                            <canvas width="34" height="15" style="display: inline-block; width: 34px; height: 15px;
                                                vertical-align: top;"></canvas>
                                        </span>
                                    </div>
                                    <div class="item">
                                        <div class="head clearfix">
                                            <div class="txt">
                                                Clicks</div>
                                        </div>
                                        <i class="s16 icomoon-icon-thumbs-up pull-left"></i>
                                        <div class="number">
                                            308</div>
                                        <div class="change">
                                            <i class="s24 icomoon-icon-arrow-down-2 color-red"></i>8%
                                        </div>
                                        <span id="stat2" class="spark">
                                            <canvas width="34" height="15" style="display: inline-block; width: 34px; height: 15px;
                                                vertical-align: top;"></canvas>
                                        </span>
                                    </div>
                                    <div class="item">
                                        <div class="head clearfix">
                                            <div class="txt">
                                                Page CTR</div>
                                        </div>
                                        <i class="s16 icomoon-icon-heart pull-left"></i>
                                        <div class="number">
                                            4%</div>
                                        <div class="change">
                                            <i class="s24 icomoon-icon-arrow-down-2 color-red"></i>1%
                                        </div>
                                        <span id="stat3" class="spark">
                                            <canvas width="34" height="15" style="display: inline-block; width: 34px; height: 15px;
                                                vertical-align: top;"></canvas>
                                        </span>
                                    </div>
                                    <div class="item">
                                        <div class="head clearfix">
                                            <div class="txt">
                                                Earn money</div>
                                        </div>
                                        <i class="s16 icomoon-icon-coin pull-left"></i>
                                        <div class="number">
                                            $376</div>
                                        <div class="change">
                                            <i class="s24 icomoon-icon-arrow-up-2 color-green"></i>26%
                                        </div>
                                        <span id="stat4" class="spark">
                                            <canvas width="34" height="15" style="display: inline-block; width: 34px; height: 15px;
                                                vertical-align: top;"></canvas>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End .sidenav-widget -->
                        <div class="sidebar-widget">
                            <h6 class="title">
                                Right now</h6>
                            <div class="content">
                                <div class="rightnow">
                                    <ul class="list-unstyled">
                                        <li><span class="number">34</span><i class="s16 icomoon-icon-new"></i>Posts</li>
                                        <li><span class="number">7</span><i class="s16 icomoon-icon-file"></i>Pages</li>
                                        <li><span class="number">14</span><i class="s16 icomoon-icon-list-2"></i>Categories</li>
                                        <li><span class="number">201</span><i class="s16 icomoon-icon-tag"></i>Tags</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End .sidenav-widget -->
                    </div>
                    <div class="slimScrollBar" style="background: rgb(196, 196, 196); width: 5px; position: absolute;
                        top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 0px;
                        height: 380.312px;">
                    </div>
                    <div class="slimScrollRail" style="width: 5px; height: 100%; position: absolute;
                        top: 0px; display: none; border-radius: 7px; background: rgb(51, 51, 51); opacity: 1;
                        z-index: 90; right: 0px;">
                    </div>
                </div>
                <!-- End .sidebar-scrollarea -->
            </div>
            <!-- End .sidebar-inner -->
        </div>
        <!-- End #sidebar -->
        <!--Sidebar background-->
        <div id="right-sidebarbg" class="hide-sidebar">
        </div>
        <!-- Start #right-sidebar -->
        <aside id="right-sidebar" class="right-sidebar sidebar-fixed hide-sidebar">
                <!-- Start .sidebar-inner -->
                <div class="sidebar-inner">
                    <!-- Start .sidebar-scrollarea -->
                    <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 100%;"><div class="sidebar-scrollarea" style="overflow: hidden; width: auto; height: 100%;">
                        <div class="pl10 pt10 pr5">
                            <ul class="timeline timeline-icons">
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Jonh Doe</a> attached new <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">file</a>
                                        <span class="timeline-icon"><i class="fa fa-file-text-o"></i></span>
                                        <span class="timeline-date">Dec 10, 22:00</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Admin</a> approved <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">3 new comments</a>
                                        <span class="timeline-icon"><i class="fa fa-comment"></i></span>
                                        <span class="timeline-date">Dec 8, 13:35</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Jonh Smith</a> deposit 300$
                                        <span class="timeline-icon"><i class="fa fa-money color-green"></i></span>
                                        <span class="timeline-date">Dec 6, 10:17</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Serena Williams</a> purchase <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">3 items</a>
                                        <span class="timeline-icon"><i class="fa fa-shopping-cart color-red"></i></span>
                                        <span class="timeline-date">Dec 5, 04:36</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">1 support </a> request is received from <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Klaudia Chambers</a>
                                        <span class="timeline-icon"><i class="fa fa-life-ring color-gray-light"></i></span>
                                        <span class="timeline-date">Dec 4, 18:40</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        You received 136 new likes for <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">your page</a>
                                        <span class="timeline-icon"><i class="glyphicon glyphicon-thumbs-up"></i></span>
                                        <span class="timeline-date">Dec 4, 12:00</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">12 settings </a> are changed from <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Master Admin</a>
                                        <span class="timeline-icon"><i class="glyphicon glyphicon-cog"></i></span>
                                        <span class="timeline-date">Dec 3, 23:17</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Klaudia Chambers</a> change your photo
                                        <span class="timeline-icon"><i class="icomoon-icon-image-2"></i></span>
                                        <span class="timeline-date">Dec 2, 05:17</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Master server </a> is down for 10 min.
                                        <span class="timeline-icon"><i class="icomoon-icon-database"></i></span>
                                        <span class="timeline-date">Dec 2, 04:56</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">12 links </a> are broken
                                        <span class="timeline-icon"><i class="fa fa-unlink"></i></span>
                                        <span class="timeline-date">Dec 1, 22:13</span>
                                    </p>
                                </li>
                                <li>
                                    <p>
                                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Last backup </a> is restored by <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Master admin</a>
                                        <span class="timeline-icon"><i class="fa fa-undo color-red"></i></span>
                                        <span class="timeline-date">Dec 1, 17:42</span>
                                    </p>
                                </li>
                            </ul>
                            <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="btn btn-default timeline-load-more-btn"><i class="fa fa-refresh"></i> Load more </a>
                        </div>
                    </div><div class="slimScrollBar" style="background: rgb(149, 165, 166); width: 5px; position: absolute; top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 0px; height: 453.456px;"></div><div class="slimScrollRail" style="width: 5px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; background: rgb(51, 51, 51); opacity: 1; z-index: 90; right: 0px;"></div></div>
                    <!-- End .sidebar-scrollarea -->
                </div>
                <!-- End .sidebar-inner -->
            </aside>
        <!-- End #right-sidebar -->
        <!--Body content-->
        <div id="content" class="page-content clearfix sidebar-page">
            <div class="contentwrapper">
                <!--Content wrapper-->
                <div class="heading">
                    <!--  .heading-->
                    <h3>
                        Chartjs</h3>
                    <div class="resBtnSearch">
                        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#"><span class="s16 icomoon-icon-search-3">
                        </span></a>
                    </div>
                    <div class="search">
                        <!-- .search -->
                        <form id="searchform" class="form-horizontal" action="http://themes.suggelab.com/supr/search.html">
                        <input type="text" class="top-search from-control" placeholder="Search here ...">
                        <input type="submit" class="search-btn" value="">
                        </form>
                    </div>
                    <!--  /search -->
                    <ul class="breadcrumb">
                        <li>You are here:</li><li><a href="http://themes.suggelab.com/supr/index.html" class="tip"
                            title="" data-original-title="back to dashboard"><i class="s16 icomoon-icon-screen-2">
                            </i></a></li>
                        <span class="divider"><i class="s16 icomoon-icon-arrow-right-3"></i></span>
                        <li><a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Charts</a></li><span
                            class="divider"><i class="s16 icomoon-icon-arrow-right-3"></i></span><li>Chartjs</li></ul>
                </div>
                <!-- End  / heading-->
                <!-- Start .row -->
                <div class="row">
                    <div class="col-lg-6">
                        <!-- col-lg-6 start here -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr0">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Line chart</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="line-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr1">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Line chart unfilled <small>and curved</small>
                                </h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="line-unfilled-chartjs" height="151" width="454" style="width: 454px;
                                        height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr2">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Pie chart</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="pie-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr3">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Radar chart</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="radar-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
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
                                <h4 class="panel-title">
                                    Line chart with dots</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="line-dots-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr5">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Bar chart</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="bar-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr6">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Donut chart</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="donut-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                        <div class="panel panel-default toggle panelMove panelClose panelRefresh" id="supr7">
                            <!-- Start .panel -->
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    Polar area</h4>
                                <div class="panel-controls panel-controls-right">
                                    <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="panel-refresh">
                                        <i class="brocco-icon-refresh s12"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                            class="toggle panel-minimize"><i class="icomoon-icon-plus"></i></a><a href="http://themes.suggelab.com/supr/charts-chartjs.html#"
                                                class="panel-close"><i class="icomoon-icon-close"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="canvas-holder">
                                    <canvas id="polar-chartjs" height="151" width="454" style="width: 454px; height: 151px;"></canvas>
                                </div>
                            </div>
                        </div>
                        <!-- End .panel -->
                    </div>
                    <!-- col-lg-6 end here -->
                </div>
                <!-- End .row -->
            </div>
            <!-- End contentwrapper -->
        </div>
        <!-- End #content -->
        <div id="footer" class="clearfix sidebar-page" style="position: static;">
            <!-- Start #footer  -->
            <p class="pull-left">
                Copyrights © 2014 <a href="http://suggeelson.com/" class="color-blue strong" target="_blank">
                    SuggeElson</a>. All rights reserved.
            </p>
            <p class="pull-right">
                <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="mr5">Terms of
                    use</a> | <a href="http://themes.suggelab.com/supr/charts-chartjs.html#" class="ml5 mr25">
                        Privacy police</a>
            </p>
        </div>
        <!-- End #footer  -->
    </div>
    <!-- / #wrapper -->
    <!-- Back to top -->
    <div id="back-to-top" class="">
        <a href="http://themes.suggelab.com/supr/charts-chartjs.html#">Back to Top</a>
    </div>
    <!-- Javascripts -->
    <!-- Load pace first -->
    <script src="../../Estructura/Js/pace.min.js" type="text/javascript"></script>
    <!-- Important javascript libs(put in all pages) -->
    <script src="../../Estructura/Js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script>
        window.jQuery || document.write('<script src="js/libs/jquery-2.1.1.min.js">\x3C/script>')
        </script>
    <script src="../../Estructura/Js/jquery-ui%201.10.4.js" type="text/javascript"></script>
    <script>
        window.jQuery || document.write('<script src="js/libs/jquery-ui-1.10.4.min.js">\x3C/script>')
        </script>
    <script src="../../Estructura/Js/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script>
        window.jQuery || document.write('<script src="js/libs/jquery-migrate-1.2.1.min.js">\x3C/script>')
        </script>
    <!--[if lt IE 9]>
  <script type="text/javascript" src="js/libs/excanvas.min.js"></script>
  <script type="text/javascript" src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
  <script type="text/javascript" src="js/libs/respond.min.js"></script>
<![endif]-->
    <!-- Bootstrap plugins -->
    <script src="../../Estructura/Js/bootstrap.js" type="text/javascript"></script>
    <!-- Core plugins ( not remove ) -->
    <script src="../../Estructura/Js/modernizr.custom.js" type="text/javascript"></script>
    <!-- Handle responsive view functions -->
    <script src="../../Estructura/Js/jRespond.min.js" type="text/javascript"></script>
    <!-- Custom scroll for sidebars,tables and etc. -->
    <script src="../../Estructura/Js/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="../../Estructura/Js/jquery.slimscroll.horizontal.min.js" type="text/javascript"></script>
    <!-- Remove click delay in touch -->
    <script src="../../Estructura/Js/fastclick.js" type="text/javascript"></script>
    <!-- Increase jquery animation speed -->
    <script src="../../Estructura/Js/jquery.velocity.min.js" type="text/javascript"></script>
    >
    <!-- Quick search plugin (fast search for many widgets) -->
    <script src="../../Estructura/Js/jquery.quicksearch.js" type="text/javascript"></script>
    <!-- Bootbox fast bootstrap modals -->
    <script src="../../Estructura/Js/bootbox.js" type="text/javascript"></script>
    <!-- Other plugins ( load only nessesary plugins for every page) -->
    <script src="../../Estructura/Js/jquery.sparkline.js" type="text/javascript"></script>
    <script src="../../Estructura/Js/Chart.js" type="text/javascript"></script>
    <script src="../../Estructura/Js/jquery.supr.js" type="text/javascript"></script>
    <script src="../../Estructura/Js/main.js" type="text/javascript"></script>
    <script src="../../Estructura/Js/charts-chartjs.js" type="text/javascript"></script>
</body>
</html>
