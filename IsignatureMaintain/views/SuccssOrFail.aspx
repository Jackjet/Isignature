<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuccssOrFail.aspx.cs" Inherits="IsignatureMaintain.views.SuccssOrFail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>项目号：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_PrjNum" runat="server" CssClass="layui-input"></asp:TextBox>

            </div>
            <div class="layui-col-xs1">
                <h5>文件名：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_DocName" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>

        </div>
        <br />

        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>设计人：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_Designer" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs1">
                <h5>最终结果：</h5>
            </div>
            <div class="layui-col-xs4 text-left">
                <asp:DropDownList ID="DropDownList_DOC_STATUS" runat="server" CssClass="layui-input-inline">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>成功</asp:ListItem>
                    <asp:ListItem>失败</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="layui-col-xs1">
                <asp:Button ID="Button_Seach" runat="server" Text="搜索" CssClass="layui-btn" OnClick="Button_Seach_Click" />
            </div>
        </div>

        <br />


        <asp:GridView ID="GridView1" runat="server" CssClass="layui-table"  lay-size="sm" AllowPaging="True" PageSize="20"  Font-Size="X-Small" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="uploadtime" HeaderText="uploadtime" Visible="False" />
                <asp:BoundField DataField="DOC_DOCUMENTID" HeaderText="DOC_DOCUMENTID" Visible="False" />
                <asp:BoundField DataField="printfilename" HeaderText="printfilename" Visible="False" />
                <asp:BoundField DataField="DOC_UNIQUE" HeaderText="文件序号" />
                <asp:BoundField DataField="picnumber" HeaderText="图号" />
                <asp:HyperLinkField DataNavigateUrlFields="DOC_DOCUMENTID" DataNavigateUrlFormatString="~/Views/MidDBInfo.aspx?DOC_NAME={0}" DataTextField="DOC_DOCUMENTID" HeaderText="文件名" />
                <asp:BoundField DataField="picname" HeaderText="图名" />
                <asp:BoundField DataField="projectnumber" HeaderText="项目号" />
                <asp:BoundField DataField="projectname" HeaderText="项目名称" />
                <asp:BoundField DataField="special" HeaderText="专业" />
                <asp:BoundField DataField="CREATE_TIME" HeaderText="上传日期" />
                <asp:BoundField DataField="ErrorMsg" HeaderText="签名信息" />
                <asp:BoundField DataField="DOC_STATUS" HeaderText="签名状态" />
                <asp:BoundField DataField="designer" HeaderText="设计人" />
                <asp:TemplateField HeaderText="重签">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Resign" Text="重签" OnClientClick="return confirm('确定要重签吗？')" CssClass="layui-btn layui-btn-danger layui-btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle CssClass="layui-elem-field layui-field-title" />

            <RowStyle Height="35px"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
