<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RsFileRpt.aspx.cs" Inherits="IsignatureMaintain.views.RsFileRpt" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-1">
                <h5>选择年份：</h5>
            </div>
            <div class="col-lg-3">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="selectpicker show-tick">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-4">
                <asp:Button ID="Calcul" runat="server" Text="报表统计" CssClass="btn btn-primary btn-sm" OnClick="Calcul_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Chart ID="Chart1" runat="server" BackColor="Linen" BackImageTransparentColor="LightCyan" BackSecondaryColor="White" Height="805px" Width="1468px">
                    <Series>
                        <asp:Series Name="Series1" YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                        <asp:Series Name="Series2" YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                        <asp:Series Name="Series3" YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                        <asp:Series Name="Series4" YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                    </Series>
                    <BorderSkin SkinStyle="Emboss" BackImageAlignment="Center" PageColor="Transparent"></BorderSkin>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend BorderDashStyle="Dash" Docking="Bottom" Font="微软雅黑, 8.25pt" IsTextAutoFit="False" Name="Legend1">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>

            </div>
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
