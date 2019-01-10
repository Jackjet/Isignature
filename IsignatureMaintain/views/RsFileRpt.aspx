<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RsFileRpt.aspx.cs" Inherits="IsignatureMaintain.views.RsFileRpt" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
        <legend>设计成品一体化流程线上签名报表</legend>
    </fieldset>
    <div class="layui-col-md12">
        <div class="layui-card">
            <%--<div class="layui-card-header">投资/费用/维修项目支出金额</div>--%>
            <div class="layui-card-body">
                <div id="div_chart_FileCount">

                </div>
            </div>
        </div>
    </div>
    <br />

    <script type="text/javascript">
        $(function () {
            InitChartFileCount();
        });

        function InitChartFileCount() {
            //var year = $('#input_Year2').val();   //选中的值;   // 选中文本
            $.ajax({
                url: "RsFileRpt.aspx",
                type: "Post",
                async: false,
                dataType: "text",  //请求到服务器返回的数据类型
                data: { "action": "GetFileCount" },

                success: function (data) {
                    var obj = $.parseJSON(data); //这个数据Json化
                    //调用Echart生成方法
                    GetEchartFileCount(obj);
                }
            })
        }
        function GetEchartFileCount(obj) {

            //建立数组
            var uploadtime = new Array(); //标题数组
            var TotalCount = new Array(); //值数组
            var ResignCount = new Array(); //值数组

            //填入标题及各值的数据
            for (var i = 0; i < obj.length; i++) {
                uploadtime.push(obj[i]["uploadtime"]);
                TotalCount.push(obj[i]["TotalCount"]);
                ResignCount.push(obj[i]["ResignCount"]);
            };

            //用于使chart自适应高度和宽度,通过窗体高宽计算容器高宽
            var div_chart1 = document.getElementById('div_chart_FileCount');
            var resizechart1Container = function () {
                div_chart1.style.width = window.innerWidth - 200 + 'px';
                div_chart1.style.height = window.innerHeight - 350 + 'px';
            };
            resizechart1Container();

            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(div_chart1);
            var option = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                legend: {
                    data: ['一次性签名成功文件数', '重签文件数']
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: {
                    type: 'value',
                    name: '个',
                    boundaryGap: [0, 0.01]
                },
                yAxis: {
                    type: 'category',
                    //data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
                    data: uploadtime
                },
                series: [
                    {
                        name: '一次性签名成功文件数',
                        type: 'bar',
                        stack: '总量',
                        label: {
                            normal: {
                                show: true,
                                position: 'insideRight'
                            }
                        },
                        //data: [320, 302, 301, 334, 390, 330, 320]
                        data: TotalCount
                    },
                    {
                        name: '重签文件数',
                        type: 'bar',
                        stack: '总量',
                        label: {
                            normal: {
                                show: true,
                                position: 'insideRight'
                            }
                        },
                        //data: [120, 132, 101, 134, 90, 230, 210]
                        data: ResignCount
                    }
                ]
            };
            //使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);

            //用于使chart自适应高度和宽度
            window.onresize = function () {
                //重置容器高宽
                resizechart1Container();
                myChart.resize();
            };
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

