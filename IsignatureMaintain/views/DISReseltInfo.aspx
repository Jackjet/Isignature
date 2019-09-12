<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DISReseltInfo.aspx.cs" Inherits="IsignatureMaintain.views.DISReseltInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <div class="layui-form-item">
            <label class="layui-form-label">图号：</label>
            <div class="layui-input-block">
                <asp:TextBox ID="TextBox_DocNo" runat="server" class="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">上传用户：</label>
            <div class="layui-input-inline">
                <asp:TextBox ID="TextBox_UploadUser" runat="server" class="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">只盖章成品：</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_IsOnlyStamp" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="layui-inline">
            <label class="layui-form-label">DIS已开始流程：</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_Uploaded" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="layui-inline">
            <div class="layui-inline">
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" class="layui-btn" OnClick="SearchBtn_Click" />
            </div>
        </div>

        <asp:GridView ID="GrvHanna" runat="server" AllowPaging="True" AllowSorting="True"  AutoGenerateColumns="False" lay-size="sm" PageSize="15" CssClass="layui-table" OnPageIndexChanging="GrvHanna_PageIndexChanging" >
            <Columns>
                <asp:BoundField DataField="common_id" HeaderText="common_id" />
                <asp:BoundField DataField="DocNo" HeaderText="DocNo" />
                <asp:BoundField DataField="DocDescription" HeaderText="DocDescription" />
                <asp:BoundField DataField="IsOnlyStamp" HeaderText="IsOnlyStamp" />
                <asp:BoundField DataField="UploadUser" HeaderText="UploadUser" />
                <asp:BoundField DataField="FTP" HeaderText="FTP" />
                <asp:BoundField DataField="PageCount" HeaderText="PageCount" />
                <asp:BoundField DataField="ConvertA1" HeaderText="ConvertA1" />
                <asp:BoundField DataField="OwnerNo" HeaderText="OwnerNo" />
                <asp:BoundField DataField="Uploaded" HeaderText="Uploaded" />
                <asp:BoundField DataField="UploadTime" HeaderText="UploadTime" />
            </Columns>

        </asp:GridView>

        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
