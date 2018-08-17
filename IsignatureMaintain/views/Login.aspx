﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IsignatureMaintain.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>签章运维管理系统</title>
    <!-- CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/form-elements.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />

    <%--HTML5 Shim and Respond.js IE8 support of HTML5 elements and media querie
    WARNING: Respond.js doesn't work if you view the page via file://
    [if lt IE 9]--%>
    <script src="../js/html5shiv.min.js"></script>
    <script src="../js/respond.min.js"></script>

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="../img/ico/favicon.png" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../img/ico/apple-touch-icon-144-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../img/ico/apple-touch-icon-114-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../img/ico/apple-touch-icon-72-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" href="../img/ico/apple-touch-icon-57-precomposed.png" />

</head>
<body>
    <form id="form1" runat="server">
        <!-- Content -->
        <div class="top-content">

            <div class="inner-bg">
                <div class="container">

                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <a class="logo"></a>
                            <h1><strong>签章运维管理系统</strong> </h1>
                            <h1>登录认证</h1>
                            <div class="description">
                                <p>
                                    This is a free responsive modal login form made with Bootstrap.
                                <strong>customize and use it as you like!</strong>
                                </p>
                            </div>
                            <div class="top-big-link">
                                <a class="btn btn-link-1 launch-modal" href="#" data-modal-id="modal-login">认证</a>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 social-login">
                            <h3>...or login with:</h3>
                            <div class="social-login-buttons">
                                <a class="btn btn-link-2" href="#">
                                    <i class="fa fa-facebook"></i>Facebook
                                </a>
                                <a class="btn btn-link-2" href="#">
                                    <i class="fa fa-twitter"></i>Twitter
                                </a>
                                <a class="btn btn-link-2" href="#">
                                    <i class="fa fa-google-plus"></i>Google Plus
                                </a>
                            </div>

                            <div class="social-login-buttons">
                                <p>
                                    <strong>皆不能登录</strong>
                                </p>
                                <p>
                                    <strong>Developed By WuLiming</strong>
                                </p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>

        <!-- MODAL -->
        <div class="modal fade" id="modal-login" tabindex="-1" role="dialog" aria-labelledby="modal-login-label" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                        </button>
                        <h3 class="modal-title" id="modal-login-label">登录我们的网站</h3>
                        <p>请输入SNEC域账户以及密码用以登录</p>
                    </div>

                    <div class="modal-body">
                        <div class="form-group">
                            <label class="sr-only" for="form-username">Username</label>
                            <asp:TextBox ID="TextBox_username" runat="server" placeholder="Username..." class="form-username form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="form-password">Password</label>
                            <asp:TextBox ID="TextBox_password" runat="server" placeholder="Password..." class="form-password form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button_Login" runat="server" Text="登录" class="btn btn-primary btn-default form-control" OnClick="Button_Login_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <!-- Javascript -->
        <script src="../js/jquery-3.1.1.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/jquery.backstretch.min.js"></script>
        <script src="../js/scripts.js"></script>

        <!--[if lt IE 10]-->
        <script src="../js/placeholder.js"></script>

        <!--[endif]-->
    </form>
</body>
</html>
