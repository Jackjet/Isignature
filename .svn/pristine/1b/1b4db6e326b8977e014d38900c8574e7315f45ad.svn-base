<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DataDictMaintain.aspx.cs" Inherits="IsignatureMaintain.views.DataDictMaintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>键：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_key" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs2">
                <h5>备注：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_remark" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
                      
        </div>
        <br />
        <div class="layui-row row text-right vertical-middle-sm">
             <div class="layui-col-xs1">
                <h5>值：</h5>
            </div>
            <div class="layui-col-xs4">
                <asp:TextBox ID="TextBox_value" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
            <div class="layui-col-xs2">
                <h5>是否适用于协同管理：</h5>
            </div>
            <div class="layui-col-xs3  text-left">
                <asp:DropDownList ID="DropDownList_manage" runat="server" CssClass="layui-input-inline">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="layui-col-xs1">
                <asp:Button ID="Button_Seach" runat="server" Text="搜索" CssClass="layui-btn" OnClick="Button_Seach_Click"/></div>
            </div>
    </div>
    <br />

        <asp:GridView ID="GridView_DataDict" runat="server"  AutoGenerateColumns="False" AllowPaging="True" PageSize="25" CssClass="layui-table" lay-size="sm" OnPageIndexChanging="GridView_DataDict_PageIndexChanging" DataKeyNames="common_id" OnRowCancelingEdit="GridView_DataDict_RowCancelingEdit" OnRowEditing="GridView_DataDict_RowEditing" OnRowUpdating="GridView_DataDict_RowUpdating">
            <Columns>
                <asp:BoundField DataField="common_id" HeaderText="序号" ReadOnly="True" />
                <asp:BoundField DataField="Key" HeaderText="键" />
                <asp:BoundField DataField="Value" HeaderText="值 " />
                <asp:BoundField DataField="Iscaduse" HeaderText="是否适用于协同管理" ReadOnly="True" />
                <asp:BoundField DataField="Remark" HeaderText="备注" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" >
                <ControlStyle CssClass="layui-btn layui-btn-xs" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
