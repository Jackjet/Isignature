using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace IsignatureMaintain.TestPage
{
    public partial class fff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] xValue = { "60分以下", "60~69", "70~80", "80~90", "90~100" };
            double[] yValue = { 10,20,30,40,50};
            Series series = Chart1.Series.Add("Series2");
            Chart1.Series["Series2"].Points.DataBindXY(xValue, yValue);
            Chart1.ChartAreas[0].AxisX.Interval = 0.5;
            Chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            Chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            Chart1.ChartAreas["ChartArea1"].BorderWidth = 2;

            ///---在长方形上显示当前所在份额  
            for (int i = 0; i < 5; i++)
            {
                Chart1.Series["Series2"].Points[i].Label = yValue[i].ToString();
            }
            this.Response.Write("<script>alert('SPF_QZ_File_Info表信息更新成功！');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }


        

    }
}
