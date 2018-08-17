<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PersonMaintain.aspx.cs" Inherits="IsignatureMaintain.views.PersonMaintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-form layui-form-pane1">
        <blockquote class="layui-elem-quote">用户查询▼</blockquote>
        <div class="layui-row row text-right vertical-middle-sm">
            <div class="layui-col-xs1">
                <h5>姓名：</h5>
            </div>
            <div class="layui-col-xs5">
                <input id="name_text" type="text" runat="server" class="layui-input" />
            </div>
            <div class="layui-col-xs1"></div>
            <div class="layui-col-xs5">
                <asp:Button ID="Button_Search" runat="server" Text="搜索" CssClass="layui-btn" OnClick="Button_Search_Click" />
            </div>
        </div>
        <br />
        <div class="layui-form layui-form-pane1">
            <blockquote class="layui-elem-quote">用户添加▼</blockquote>
            <div class="layui-row row text-right vertical-middle-sm">
                <div class="layui-col-xs1">
                    <h5>账户：</h5>
                </div>
                <div class="layui-col-xs5">
                    <input id="AccountAdd_Text" type="text" runat="server" placeholder="zhangsan" class="layui-input" />
                </div>
                <div class="layui-col-xs1">
                    <h5>姓名：</h5>
                </div>
                <div class="layui-col-xs5">
                    <input id="NameAdd_Text" type="text" runat="server" placeholder="张三" class="layui-input" />
                </div>
            </div>
            <br />

            <div class="layui-row row text-right vertical-middle-sm">
                <div class="layui-col-xs1">
                    <h5>部门：</h5>
                </div>
                <div class="layui-col-xs5 text-left">
                    <asp:DropDownList ID="DropDownList_Dep" runat="server" CssClass="layui-input-inline">
                    </asp:DropDownList>
                </div>
                <div class="layui-col-xs1"></div>
                <div class="layui-col-xs5">
                    <asp:Button ID="Button_Add" runat="server" Text="添加" CssClass="layui-btn" OnClick="Button_Add_Click" />
                </div>
            </div>
        </div>
    </div>

    <br />

        <asp:GridView ID="GridView_Person" runat="server" CssClass="layui-table" lay-size="sm" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView_Person_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="mainid" OnRowCancelingEdit="GridView_Person_RowCancelingEdit" OnRowDeleting="GridView_Person_RowDeleting" OnRowEditing="GridView_Person_RowEditing" OnRowUpdating="GridView_Person_RowUpdating">
            <Columns>
                <asp:BoundField DataField="mainid" HeaderText="序号" ReadOnly="True" />
                <asp:BoundField DataField="account" HeaderText="账户" />
                <asp:BoundField DataField="username" HeaderText="姓名" />
                <asp:BoundField DataField="orgname" HeaderText="部门" ReadOnly="True" />
                <asp:BoundField DataField="departmentid" HeaderText="部门序号" ReadOnly="True" />
                <asp:BoundField DataField="userstate" HeaderText="工作情况" ReadOnly="True" />
                <asp:BoundField DataField="systemtime" HeaderText="更新时间" ReadOnly="True" />
                <asp:BoundField DataField="erpuid" HeaderText="员工编号" ReadOnly="True" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" >
                <ControlStyle CssClass="layui-btn layui-btn-xs" />
                </asp:CommandField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                <ControlStyle CssClass="layui-btn layui-btn-danger layui-btn-xs" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>



