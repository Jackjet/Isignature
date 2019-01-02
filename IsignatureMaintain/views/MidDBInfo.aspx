﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="MidDBInfo.aspx.cs" Inherits="IsignatureMaintain.views.MidDBInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>文件名：</h5>
            </div>
            <div class="layui-col-xs5">
                <asp:TextBox ID="FileName_TextBox" runat="server" CssClass="layui-input" placeholder="0531-D-1200-EQ-DW060-0203A.dwg"></asp:TextBox>
            </div>
            <div class="layui-col-xs3"></div>
            <div class="layui-col-xs3">
                <asp:Button ID="Seach" runat="server" Text="搜索" CssClass="layui-btn" OnClick="Seach_Click" />
            </div>
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <ul class="layui-timeline">
       <%-- <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis"></i>
            <div class="layui-timeline-content layui-text">
                <h2 class="layui-timeline-title">SPF中间库</h2>
            </div>
        </li>
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
            <div class="layui-timeline-content layui-text">
                <h5 class="layui-timeline-title">SPF签章文件信息（表SPF_QZ_File_Info）</h5>
                <asp:GridView ID="GridView_SPF_QZ_File_Info" runat="server" CssClass="layui-table" lay-size="sm" AutoGenerateColumns="False" OnRowEditing="GridView_SPF_QZ_File_Info_RowEditing" OnRowUpdating="GridView_SPF_QZ_File_Info_RowUpdating" DataKeyNames="common_id" OnRowCancelingEdit="GridView_SPF_QZ_File_Info_RowCancelingEdit">
                    <Columns>
                        <asp:BoundField DataField="filename" HeaderText="filename" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="picName" HeaderText="picName" ReadOnly="True" />
                        <asp:BoundField DataField="PrjName" HeaderText="PrjName" ReadOnly="True" />
                        <asp:BoundField DataField="PrintstyleName" HeaderText="PrintstyleName" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="state" HeaderText="state" ControlStyle-Width="20%">
                            <ControlStyle Width="20%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PageCount" HeaderText="PageCount" ControlStyle-Width="20%">
                            <ControlStyle Width="20%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ZA1count" HeaderText="ZA1count" ControlStyle-Width="20%">
                            <ControlStyle Width="20%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="fileroute" HeaderText="fileroute" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="result" HeaderText="result" ControlStyle-Width="80%">
                            <ControlStyle Width="80%"></ControlStyle>
                        </asp:BoundField>
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True">
                            <ControlStyle CssClass="layui-btn layui-btn-xs" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </li>
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
            <div class="layui-timeline-content layui-text">
                <h5 class="layui-timeline-title">SPF文件签名信息（表SPF_QZ_File_Signatureinfo）</h5>
                <asp:GridView ID="GridView_SPF_QZ_File_Signatureinfo" runat="server" CssClass="layui-table" lay-size="sm" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName" />
                        <asp:BoundField DataField="role" HeaderText="role" />
                        <asp:BoundField DataField="person" HeaderText="person" />
                        <asp:BoundField DataField="Discipline" HeaderText="Discipline" />
                        <asp:BoundField DataField="ApproveDate" HeaderText="ApproveDate" />
                    </Columns>
                </asp:GridView>
            </div>
        </li>--%>
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis"></i>
            <div class="layui-timeline-content layui-text">
                <h2 class="layui-timeline-title">CPMS中间库</h2>
            </div>
        </li>
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
            <div class="layui-timeline-content layui-text">
                <h5 class="layui-timeline-title">CPMS签章文件信息（表CPMS_sync_drawinginfo）</h5>
                <asp:GridView ID="GridView_CPMS_sync_drawinginfo" runat="server" CssClass="layui-table" lay-size="sm" AutoGenerateColumns="False" DataKeyNames="Common_id" OnRowCancelingEdit="GridView_CPMS_sync_drawinginfo_RowCancelingEdit" OnRowEditing="GridView_CPMS_sync_drawinginfo_RowEditing" OnRowUpdating="GridView_CPMS_sync_drawinginfo_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="common_id" HeaderText="common_id" ReadOnly="True" ControlStyle-Width="80%">
                            <ControlStyle Width="80%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="filesrc" HeaderText="filesrc" ReadOnly="True" />
                        <asp:BoundField DataField="picnumber" HeaderText="picnumber" ReadOnly="True" />
                        <asp:BoundField DataField="picname" HeaderText="picname" ControlStyle-Width="100%">
                            <ControlStyle Width="100%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="annex" HeaderText="annex" ControlStyle-Width="100%">
                            <ControlStyle Width="100%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="special" HeaderText="special" ReadOnly="True" />
                        <asp:BoundField DataField="specnumber" HeaderText="specnumber" ReadOnly="True" />
                        <asp:BoundField DataField="piccount" HeaderText="piccount" ControlStyle-Width="80%">
                            <ControlStyle Width="80%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="a1" HeaderText="a1" ControlStyle-Width="80%">
                            <ControlStyle Width="80%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="projectname" HeaderText="projectname" ReadOnly="True" />
                        <asp:BoundField DataField="pltannex" HeaderText="pltannex" ControlStyle-Width="100%">
                            <ControlStyle Width="100%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="miji" HeaderText="miji" ControlStyle-Width="80%">
                            <ControlStyle Width="80%"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="states" HeaderText="states" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="designer" HeaderText="designer" />
                        <asp:BoundField DataField="account" HeaderText="account" />
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" ShowDeleteButton="True">
                            <ControlStyle CssClass="layui-btn layui-btn-xs" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </li>
        <li class="layui-timeline-item">
            <i class="layui-icon layui-timeline-axis">&#xe63f;</i>
            <div class="layui-timeline-content layui-text">
                <h5 class="layui-timeline-title">CPMS文件上传信息（表CPMS_sync_fileinfo）</h5>
                <asp:GridView ID="GridView_CPMS_sync_fileinfo" runat="server" CssClass="layui-table" lay-size="sm" AutoGenerateColumns="False" OnRowDataBound="GridView_CPMS_sync_fileinfo_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="common_id" HeaderText="common_id" />
                        <asp:BoundField DataField="filesrc" HeaderText="filesrc" />
                        <asp:BoundField DataField="fileuid" HeaderText="fileuid" />
                        <asp:BoundField DataField="filename" HeaderText="filename" />
                        <%--<asp:BoundField DataField="ftpaddress" HeaderText="ftpaddress" />--%>
                        <%--<asp:BoundField DataField="fileext" HeaderText="fileext" />--%>
                        <asp:TemplateField HeaderText="ftpaddress">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink_address" runat="server" Text='<%# Eval("ftpaddress")%>' data-toggle="tooltip" data-placement="top" title="复制打开链接可下载文件">HyperLink_address</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </li>
    </ul>
</asp:Content>
