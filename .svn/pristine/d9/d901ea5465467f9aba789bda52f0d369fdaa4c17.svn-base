<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HanaFileCKPLTRcd.aspx.cs" Inherits="IsignatureMaintain.views.HanaFileCKPLTRcd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="layui-timeline">
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis"></i>
            <div class="layui-timeline-content layui-text">
                <h2 class="layui-timeline-title">汉纳系统校验表</h2>
            </div>
        </li>
            <asp:GridView ID="Grv_Check" runat="server" AutoGenerateColumns="False" lay-size="sm" CssClass="layui-table">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                    <asp:BoundField DataField="ORGFilePath" HeaderText="ORGFilePath" />
                    <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" />
                    <asp:BoundField DataField="LastUpdateDate" HeaderText="LastUpdateDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Remark" HeaderText="Remark" />
                    <asp:BoundField DataField="Client" HeaderText="Client" />
                </Columns>
            </asp:GridView>
       <li></li>
       <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis"></i>
            <div class="layui-timeline-content layui-text">
                <h2 class="layui-timeline-title">汉纳系统打印表</h2>
            </div>
        </li>
        <asp:GridView ID="Grv_Plot" runat="server" AutoGenerateColumns="False" lay-size="sm" CssClass="layui-table">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="FileName" HeaderText="FileName" />
                <asp:BoundField DataField="ORGFilePath" HeaderText="ORGFilePath" />
                <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" />
                <asp:BoundField DataField="LastUpdateDate" HeaderText="LastUpdateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                <asp:BoundField DataField="Client" HeaderText="Client" />
            </Columns>
        </asp:GridView>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
