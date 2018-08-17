<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="IsignatureMaintain.TestPage.form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="layui-form layui-form-pane1">
        <div class="layui-inline">
            <label class="layui-form-label">行内表单</label>
            <div class="layui-input-block">
                <select name="quiz" lay-verify="required" lay-vertype="tips">
                    <option value="">请选择问题</option>
                    <option value="你工作的第一个城市">你工作的第一个城市</option>
                    <option value="你的工号" disabled>你的工号</option>
                    <option value="你最喜欢的老师">你最喜欢的老师</option>
                </select>
            </div>
        </div>
        <div class="layui-inline">
            <label class="layui-form-label">select分组</label>
            <div class="layui-input-block">
                <select name="quiz" lay-filter="quiz">
                    <option value="">请选择问题</option>
                    <optgroup label="城市记忆">
                        <option value="你工作的第一个城市">你工作的第一个城市</option>
                    </optgroup>
                    <optgroup label="学生时代">
                        <option value="你的工号" disabled>你的工号</option>
                        <option value="你最喜欢的老师">你最喜欢的老师</option>
                    </optgroup>
                </select>
            </div>
        </div>


        <div class="layui-form-item">
            <label class="layui-form-label">选择框</label>
            <div class="layui-input-block">
                <select name="interest" lay-filter="interest">
                    <option value=""></option>
                    <option value="0">写作</option>
                    <option value="1" selected>阅读</option>
                    <option value="2">游戏</option>
                    <option value="3">音乐</option>
                    <option value="4">旅行</option>
                </select>
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">搜索选择框</label>
            <div class="layui-input-inline">
                <select name="interest-search" lay-filter="interest-search" lay-search lay-write>
                    <option value=""></option>
                    <option value="0">写作</option>
                    <option value="1">阅读</option>
                    <option value="2">游戏</option>
                    <option value="3">音乐</option>
                    <option value="4">旅行</option>
                    <option value="5">读书</option>
                </select>
            </div>
        </div>

        <div class="layui-form-item" pane>
            <label class="layui-form-label">复选框</label>
            <div class="layui-input-block">
                <input type="checkbox" name="like[write]" title="写作">
                <input type="checkbox" name="like[read]" title="阅读">
                <input type="checkbox" name="like[game]" title="游戏" disabled>
            </div>
        </div>
        <div class="layui-form-item" pane>
            <label class="layui-form-label">原始复选框</label>
            <div class="layui-input-block">
                <input type="checkbox" name="like1[write]" lay-skin="primary" title="写作">
                <input type="checkbox" name="like1[read]" lay-skin="primary" title="阅读">
                <input type="checkbox" name="like1[game]" lay-skin="primary" title="游戏" disabled>
            </div>
        </div>

    </div>

    <br>
    <br>
    <br>


    <script>

        layui.use('form', function () {
            var form = layui.form;

            //自定义验证规则
            form.verify({
                title: function (value) {
                    if (value.length < 5) {
                        return '标题也太短了吧';
                    }
                }
              , pass: [/(.+){6,12}$/, '密码必须6到12位']
            });


            //事件监听
            form.on('select', function (data) {
                console.log('select: ', this, data);
            });

            form.on('select(quiz)', function (data) {
                console.log('select.quiz：', this, data);
            });

            form.on('select(interest)', function (data) {
                console.log('select.interest: ', this, data);
            });



            form.on('checkbox', function (data) {
                console.log(this.checked, data.elem.checked);
            });

            form.on('switch', function (data) {
                console.log(data);
            });

            form.on('radio', function (data) {
                console.log(data);
            });

            //监听提交
            form.on('submit(*)', function (data) {
                console.log(data)
                return false;
            });

        });

    </script>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
