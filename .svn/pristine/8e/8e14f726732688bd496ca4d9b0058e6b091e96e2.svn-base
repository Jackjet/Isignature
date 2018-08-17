<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FileReSign.aspx.cs" Inherits="IsignatureMaintain.views.FileReSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <blockquote class="layui-elem-quote">异常文件（签章系统不能正常签名签章）请按以下步骤进行处理▼</blockquote>

        <ul class="layui-timeline">
            <li class="layui-timeline-item">
                <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
                <div class="layui-timeline-content layui-text">
                    <h4 class="layui-timeline-title">1.将处理的签名文件（手动盖章完毕的签名文件）上传至共享路径：\\10.151.126.1\signfile\successs</h4>
                </div>
            </li>
            <li class="layui-timeline-item">
                <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
                <div class="layui-timeline-content layui-text">
                    <h4 class="layui-timeline-title">2.输入文件名全称（例如：@4331935$0531-D-1200-EQ-DW060-0203A.dwg），进行重签操作</h4>
                </div>
            </li>
            <li class="layui-timeline-item">
                <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
                <div class="layui-timeline-content layui-text">
                    <h4 class="layui-timeline-title">3.检查慧智系统中签名文件是否为上传的文件，SPF/CPMS中间库数据是否对应</h4>
                </div>
            </li>
        </ul>
        <div class="layui-row  vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>文件名：</h5>
            </div>
            <div class="layui-col-xs5">
                <asp:TextBox ID="FileName_TextBox" runat="server" Width="60%" placeholder="@4331935$0531-D-1200-EQ-DW060-0203A.dwg" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs1">
                <asp:Button ID="Seach_Button" runat="server" Text="查询" OnClick="Seach_Button_Click" CssClass="layui-btn" />
            </div>
            <div class="layui-col-xs1">
                <%--<asp:Button ID="Resign_Button" runat="server" Text="重签" OnClick="Resign_Button_Click" OnClientClick="return confirm('确定要重签吗？')" Font-Names="微软雅黑" />--%>
                <asp:Button ID="Resign_Button" runat="server" Text="重签" OnClick="Resign_Button_Click" OnClientClick="ShowProgress()" CssClass="layui-btn" />
            </div>
        </div>
    </div>

    <div class="loading">
        Loading. Please wait.<br />
        <br />
        <img src="../img/loading.gif" alt="" />
    </div>

    <div class="container-fluid">
        <asp:Label ID="Label6" runat="server" Text="SPF中间库信息" Font-Names="微软雅黑" Font-Bold="True" Font-Size="Small"></asp:Label>
        <asp:GridView ID="GridView_SPFInfo" runat="server" CssClass="layui-table" lay-size="sm"></asp:GridView>
    </div>

    <br />
    <div class="container-fluid">
        <asp:Label ID="Label7" runat="server" Text="CPMS中间库信息" Font-Names="微软雅黑" Font-Bold="True" Font-Size="Small"></asp:Label>
        <asp:GridView ID="GridView_CPMS_drawinginfo" runat="server" CssClass="layui-table" lay-size="sm"></asp:GridView>
    </div>

    <br />
    <div class="container-fluid">
        <asp:GridView ID="GridView_CPMS_fileinfo" runat="server" CssClass="layui-table" lay-size="sm"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>


