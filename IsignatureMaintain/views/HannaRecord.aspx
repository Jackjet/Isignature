<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HannaRecord.aspx.cs" Inherits="IsignatureMaintain.views.HannaRecord" %>

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
            <label class="layui-form-label">备注</label>
            <div class="layui-input-inline">
                <asp:TextBox ID="TextBox_Remark" runat="server" class="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">文件类型</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_FileExt" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PDF</asp:ListItem>
                    <asp:ListItem>WORD</asp:ListItem>
                    <asp:ListItem>EXCEL</asp:ListItem>
                    <asp:ListItem>DWG</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">文件状态</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_Status" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>01 待处理</asp:ListItem>
                    <asp:ListItem>02 失败</asp:ListItem>
                    <asp:ListItem>03 成功</asp:ListItem>
                    <asp:ListItem>04 文件异常或处理超时</asp:ListItem>
                    <asp:ListItem>06 正在处理</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">处理方式</label>
            <div class="layui-input-inline">
                <asp:DropDownList ID="DropDownList_Function" runat="server">
                    <asp:ListItem>校验</asp:ListItem>
                    <asp:ListItem>打印</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="layui-inline">
            <div class="layui-inline">
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" class="layui-btn" OnClick="SearchBtn_Click" />
            </div>
        </div>
        <br />
        <asp:GridView ID="Grv_File" runat="server" AutoGenerateColumns="False" lay-size="sm" AllowPaging="True" PageSize="15" CssClass="layui-table" OnPageIndexChanging="Grv_File_PageIndexChanging" OnRowDataBound="Grv_File_RowDataBound" OnRowCommand="Grv_File_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:TemplateField HeaderText="FileName">
                    <ItemTemplate>                       
                        <asp:LinkButton ID="linkbtn1" CommandName="lkbtnClick" runat="server"  CommandArgument='<%# Eval("FileName")+","+Eval("Client")%>' Text='<%#Eval("FileName") %>'>  </asp:LinkButton>                       
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:HyperLinkField DataNavigateUrlFields="FileName" DataNavigateUrlFormatString="~/Views/HanaFileCKPLTRcd.aspx?FileName={0}" DataTextField="FileName" HeaderText="FileName" />--%>
                <asp:BoundField DataField="ORGFilePath" HeaderText="ORGFilePath" />
                <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" />
                <asp:BoundField DataField="LastUpdateDate" HeaderText="LastUpdateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" />                
                <asp:BoundField DataField="Client" HeaderText="Client" />
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
