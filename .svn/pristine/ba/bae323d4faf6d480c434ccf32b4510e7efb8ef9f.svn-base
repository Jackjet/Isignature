<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HistoryVersion.aspx.cs" Inherits="IsignatureMaintain.Views.HistoryVersion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" class="layui-form layui-form-pane1" runat="server">
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>签名文件：</h5>
            </div>
            <div class="layui-col-xs5">
                <asp:TextBox ID="TextBox_DOC_NAME" runat="server" Width="80%" CssClass="layui-input"></asp:TextBox>

            </div>
            <div class="layui-col-xs3"></div>
            <div class="layui-col-xs3">
                <asp:Button ID="Button_Search" runat="server" Text="搜索" OnClick="Button_Search_Click" Font-Size="Small" CssClass="layui-btn" />
            </div>
        </div>
    </div>

    <br />


    <asp:GridView ID="GridView_Version" runat="server" PageSize="15" AutoGenerateColumns="False" CssClass="layui-table" lay-size="sm" OnRowDataBound="GridView_Version_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView_Version_PageIndexChanging">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="DOC_UNIQUE,DOC_TYPE,DOC_NAME" DataNavigateUrlFormatString="~/Views/FileSignature.aspx?DOC_UNIQUE={0}&amp;DOC_TYPE={1}&amp;DOC_NAME={2}" DataTextField="DOC_UNIQUE" HeaderText="ID" />
            <asp:BoundField DataField="DOC_NAME" HeaderText="签名文件" />
            <asp:BoundField DataField="DOC_TYPE" HeaderText="文件类型" />
            <asp:BoundField DataField="STATUS" HeaderText="签名状态" />
            <asp:BoundField DataField="CREATE_TIME" HeaderText="创建时间" />
            <asp:BoundField DataField="ErrorMsg" HeaderText="签章结果" />
            <asp:TemplateField HeaderText="未签名源文件">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink_DOC_PATH" runat="server" data-toggle="tooltip" data-placement="right" title="账户：sneceddm 密码：sneceddm">HyperLink</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="签名成功文件">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink_DOC_SUCCEEPATH" runat="server" data-toggle="tooltip" data-placement="top" title="账户：sneceddm 密码：sneceddm">HyperLink</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="签名失败文件">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink_DOC_FAILPATH" runat="server" data-toggle="tooltip" data-placement="top" title="账户：sneceddm 密码：sneceddm">HyperLink</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>


