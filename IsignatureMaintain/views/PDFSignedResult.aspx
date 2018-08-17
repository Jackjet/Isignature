﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PDFSignedResult.aspx.cs" Inherits="IsignatureMaintain.views.PDFSignedResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">

        <div class="layui-form-item">
            <label class="layui-form-label">文件名</label>
            <div class="layui-input-block">
                <asp:TextBox ID="TextBox_FileName" runat="server" class="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">写入中间库</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_IsWriten" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>已写入</asp:ListItem>
                    <asp:ListItem>未写入</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="layui-inline">
            <div class="layui-inline">
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" class="layui-btn" OnClick="SearchBtn_Click" />
            </div>
        </div>
        <asp:GridView ID="Grv1" runat="server" lay-size="sm" CssClass="layui-table" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnRowDataBound="Grv1_RowDataBound" OnPageIndexChanging="Grv1_PageIndexChanging" OnRowCommand="Grv1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:HyperLinkField DataNavigateUrlFields="FileName" DataNavigateUrlFormatString="~/Views/MidDBInfo.aspx?FileName={0}" DataTextField="FileName" HeaderText="FileName" />
                <asp:BoundField DataField="FileNo" HeaderText="FileNo" Visible="False" />
                <asp:BoundField DataField="ORGFilePath" HeaderText="ORGFilePath" />
                <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="LastUpdateDate" HeaderText="LastUpdateDate" />
                <asp:BoundField DataField="Client" HeaderText="Client" />
                <asp:BoundField DataField="picnumber" HeaderText="picnumber" />
                <asp:BoundField DataField="picname" HeaderText="picname" />
                <asp:BoundField DataField="designer" HeaderText="designer" />
                <asp:BoundField DataField="uploadtime" HeaderText="uploadtime" />
                <asp:BoundField DataField="projectname" HeaderText="projectname" />
                <asp:BoundField DataField="pltannex" HeaderText="pltannex" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:Button ID="RePlot" runat="server"  CommandName="ReBuild" class="layui-btn layui-btn-sm" OnClientClick="return confirm('确定要重新生成吗？')" Text="重新生成PDF/JSON" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
