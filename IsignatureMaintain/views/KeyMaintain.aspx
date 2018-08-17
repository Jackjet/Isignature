<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="KeyMaintain.aspx.cs" Inherits="IsignatureMaintain.views.KeyMaintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>密钥盘序号：</h5>
            </div>
            <div class="layui-col-xs2">
                <asp:TextBox ID="TextBox_keysn" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs1">
                <h5>当前状态：</h5>
            </div>
            <div class="layui-col-xs2   text-left">
                <asp:DropDownList ID="DropDownList_keyStatus" runat="server"  CssClass="layui-input-inline">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>启用</asp:ListItem>
                    <asp:ListItem>注销</asp:ListItem>
                    <asp:ListItem>禁用</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="layui-col-xs1">
                <h5>所在部门：</h5>
            </div>
            <div class="layui-col-xs2  text-left">
                <asp:DropDownList ID="DropDownList_orgName" runat="server"  CssClass="layui-input-inline"></asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>用户编码：</h5>
            </div>
            <div class="layui-col-xs2">
                <asp:TextBox ID="TextBox_userCode" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs1">
                <h5>用户姓名：</h5>
            </div>
            <div class="layui-col-xs2">
                <asp:TextBox ID="TextBox_userName" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>

            <div class="layui-col-xs3">
                <asp:Button ID="Seach" runat="server" Text="搜索"  CssClass="layui-btn" OnClick="Seach_Click" />
            </div>
        </div>
    </div>
    <br />

    <div class="container-fluid">
        <asp:GridView ID="GridView_key" runat="server" CssClass="layui-table"  lay-size="sm" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" OnPageIndexChanging="GridView_key_PageIndexChanging" DataKeyNames="tid" OnRowDeleting="GridView_key_RowDeleting" >
            <Columns>
                <asp:BoundField DataField="tid" Visible="False" />
                <asp:BoundField DataField="keysn" HeaderText="密钥盘序号" />
                <asp:BoundField DataField="userCode" HeaderText="用户编码" />
                <asp:BoundField DataField="userName" HeaderText="用户姓名" />
                <asp:BoundField DataField="keyStatus" HeaderText="当前状态" />
                <asp:BoundField DataField="orgName" HeaderText="所在部门" />
                <asp:BoundField DataField="applyDate" HeaderText="启用日期" />
                <asp:BoundField DataField="overDate" HeaderText="过期日期" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                <ControlStyle CssClass="layui-btn layui-btn-danger layui-btn-xs" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
