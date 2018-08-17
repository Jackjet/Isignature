﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ResultSearch.aspx.cs" Inherits="IsignatureMaintain.Views.ResultSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">

        <label class="layui-col-xs1">签名文件：</label>
        <div class="layui-col-xs3">
            <asp:TextBox ID="TextBox_DOC_NAME" runat="server" CssClass="layui-input"></asp:TextBox>
        </div>
        <label class="layui-col-xs1">文件类型：</label>
        <div class="layui-col-xs3">
            <asp:TextBox ID="TextBox_DOC_TYPE" runat="server" CssClass="layui-input"></asp:TextBox>
        </div>
        <label class="layui-col-xs1">设计人：</label>
        <div class="layui-col-xs3">
            <asp:TextBox ID="TextBox_USRNAME" runat="server" CssClass="layui-input"></asp:TextBox>
        </div>

        <br />
        <br />

        <label class="layui-col-xs1">签名信息：</label>
        <div class="layui-col-xs3">
            <asp:TextBox ID="TextBox_ErrorMsg" runat="server" CssClass="layui-input"></asp:TextBox>
        </div>
        <label class="layui-col-xs1">签名状态：</label>
        <div class="layui-col-xs3 text-left">
            <asp:DropDownList ID="DropDownList_DOC_STATUS" runat="server" CssClass="layui-input-inline">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>成功</asp:ListItem>
                <asp:ListItem>失败</asp:ListItem>
                <asp:ListItem>代签</asp:ListItem>
                <asp:ListItem>正在盖章</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="layui-col-xs2">
        </div>
        <div class="layui-col-xs2">
            <asp:Button ID="Button_Seach" runat="server" Text="确定" OnClick="Button_Seach_Click" CssClass="layui-btn" />
        </div>

        <br />
        <br />

        <asp:GridView ID="GridView_IsigResult" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" CssClass="layui-table" lay-size="sm" OnPageIndexChanging="GridView_IsigResult_PageIndexChanging" OnRowCommand="GridView_IsigResult_RowCommand" OnRowDataBound="GridView_IsigResult_RowDataBound">
            <Columns>
                <asp:BoundField DataField="DOC_UNIQUE" HeaderText="文件序号" />
                <asp:HyperLinkField DataNavigateUrlFields="DOC_NAME" DataNavigateUrlFormatString="~/Views/MidDBInfo.aspx?DOC_NAME={0}" DataTextField="DOC_NAME" HeaderText="签名文件" Target="_blank" />
                <asp:HyperLinkField DataTextField="DOC_REAL_NAME" HeaderText="源文件" DataNavigateUrlFields="DOC_REAL_NAME" DataNavigateUrlFormatString="~/Views/HistoryVersion.aspx?DOC_REAL_NAME={0}" Target="_blank" />
                <asp:BoundField DataField="DOC_TYPE" HeaderText="文件类型" />
                <asp:BoundField DataField="STATUS" HeaderText="签名状态" />
                <asp:BoundField DataField="CREATE_TIME" HeaderText="创建时间" />
                <asp:BoundField DataField="ErrorMsg" HeaderText="签名信息" />
                <asp:BoundField HeaderText="设计人" DataField="USRNAME" />
                <asp:TemplateField HeaderText="重签原因">
                    <ItemTemplate>
                        <%--<div class="layui-form layui-form-pane1">--%>
                        <asp:DropDownList ID="DropDownList_FailReason" runat="server" AutoPostBack="true" CssClass="layui-input-inline" Text='<%# Eval("Remark")%>' OnSelectedIndexChanged="DropDownList_FailReason_SelectedIndexChanged">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>01.文件版本不合规</asp:ListItem>
                            <asp:ListItem>02.文件标识缺失/多余</asp:ListItem>
                            <asp:ListItem>03.文件内容损坏</asp:ListItem>
                            <asp:ListItem>04.文件只盖章不签名</asp:ListItem>
                            <asp:ListItem>05.文件非标准模板</asp:ListItem>
                            <asp:ListItem>06.CAD文件字体缺失</asp:ListItem>
                            <asp:ListItem>07.未提供标准模板</asp:ListItem>
                            <asp:ListItem>08.签名缺失/异常/加盖不上</asp:ListItem>
                            <asp:ListItem>09.签名结果偏移/漏签/失效</asp:ListItem>
                            <asp:ListItem>10.项目专业缺失</asp:ListItem>
                            <asp:ListItem>11.DWG转TIF打印失败</asp:ListItem>
                            <asp:ListItem>12.PDF文件手动处理</asp:ListItem>
                            <asp:ListItem>13.签章加载项被禁用</asp:ListItem>
                            <asp:ListItem>14.中间库项目不一致</asp:ListItem>
                            <asp:ListItem>15.SPF参数内容有误</asp:ListItem>
                            <asp:ListItem>16.文件名含特殊字符</asp:ListItem>
                            <asp:ListItem>17.FTP服务器文件不存在</asp:ListItem>
                            <asp:ListItem>18.CAD致命错误</asp:ListItem>
                            <asp:ListItem>19.档案馆检查文件有误</asp:ListItem>
                            <asp:ListItem>20.其他</asp:ListItem>
                        </asp:DropDownList>
                        <%--</div>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="重签" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Resign" Text="重签" OnClientClick="return confirm('确定要重签吗？')" CssClass="layui-btn layui-btn-danger layui-btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>



