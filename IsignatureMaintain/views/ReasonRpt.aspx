<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReasonRpt.aspx.cs" Inherits="IsignatureMaintain.views.ReasonRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Chart ID="Chart1" runat="server" Height="949px" Width="1330px">
        <Series>
            <asp:Series ChartType="Pie" Name="Series1" Legend="Legend1" IsXValueIndexed="True">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend BorderDashStyle="Dash" Docking="Top" Name="Legend1" Title="签名问题统计" Font="微软雅黑, 8.25pt" IsTextAutoFit="False" TitleFont="微软雅黑, 15.75pt, style=Bold" Enabled="False" >
            </asp:Legend>
        </Legends>
        <BorderSkin BackColor="LightGray" BackGradientStyle="DiagonalLeft" BorderColor="Gainsboro" SkinStyle="Raised" />
    </asp:Chart>
</asp:Content>
