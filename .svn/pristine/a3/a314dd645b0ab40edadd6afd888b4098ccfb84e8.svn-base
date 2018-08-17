using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.views
{
    public partial class RsFileRpt : System.Web.UI.Page
    {
        #region  参数定义
        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();
        #endregion

        #region  数据库操作方法
        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /*SQL数据查询，返回datatable*/
        public DataTable GetData(string selctsql, string sqlcon)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(selctsql);
            SqlDataAdapter ad = new SqlDataAdapter(sb.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            InitChart();
        }

        public void InitChart()
        {
            Chart1.ChartAreas[0].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            //坐标轴说明
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "月份";
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "文件数";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//仅不显示x轴方向的网格线
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;//仅显示y轴方向的网格线
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("微软雅黑", 18f, FontStyle.Bold);
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("微软雅黑", 18f, FontStyle.Bold);

            //显示坐标值
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            Chart1.Series["Series2"].IsValueShownAsLabel = true;
            Chart1.Series["Series3"].IsValueShownAsLabel = true;
            Chart1.Series["Series4"].IsValueShownAsLabel = true;

            //图例文字
            Chart1.Series["Series1"].LegendText = "签名一次";
            Chart1.Series["Series2"].LegendText = "签名两次";
            Chart1.Series["Series3"].LegendText = "签名三次及以上";
            Chart1.Series["Series4"].LegendText = "签名文件总数";

            //Give two columns of data to Y-axle
            Chart1.Series[0].YValueMembers = "Volume1";
            Chart1.Series[1].YValueMembers = "Volume2";
            Chart1.Series[2].YValueMembers = "Volume3";
            Chart1.Series[3].YValueMembers = "Volume4";
            //Set the X-axle as date value
            Chart1.Series[0].XValueMember = "Month";
        }

        //获取SQL语句返回的datatable
        public DataSet GetDataSet(string year)
        {
            DataSet ds = new DataSet();

            //获取每个月份签名数据，并将其存入ds内存数据库
            for (int i = 1; i <= 12; i++)
            {
                string StartTime, EndTime;
                if (i != 12)
                {
                    int startMonth = i;
                    StartTime = year + "." + startMonth + ".01";
                    int endMonth = i + 1;
                    EndTime = year + "." + endMonth + ".01";
                }
                else
                {
                    int startMonth = i;
                    StartTime = year + "." + startMonth + ".01";
                    int endMonth = 1;
                    EndTime = (Convert.ToInt32(year)+1) + "." + endMonth + ".01";
                }
                string sqlstr = "SELECT SUBSTRING(DOC_DOCUMENTID,10,40) as Filename,count(*) as Num FROM dbo.SIGN_DOCNUMET WHERE DOC_DOCUMENTID LIKE '%@%' AND CREATE_TIME>='" + StartTime + "' AND CREATE_TIME<'" + EndTime + "'  AND CREATE_TIME>='2016.09.01' GROUP BY SUBSTRING(DOC_DOCUMENTID,10,40) order by Num desc";
                DataTable dt = GetData(sqlstr, SQLCON_Isignature);
                ds.Tables.Add(dt.Copy());
            }
            return ds;
        }


        //初始化表格，将每个月前面签章次数及文件数存入表格
        private DataTable CreateDataTable(string year)
        {
            DataSet ds = GetDataSet(year);  //定义内存数据库
            //Create a DataTable as the data source of the Chart control
            DataTable dt = new DataTable();

            //Add three columns to the DataTable
            dt.Columns.Add("Month");
            dt.Columns.Add("Volume1");
            dt.Columns.Add("Volume2");
            dt.Columns.Add("Volume3");
            dt.Columns.Add("Volume4");

            DataRow dr;
            //获取每个月份，签名次数为1,2,3次及以上的文件个数
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                int count1 = 0; int count2 = 0; int count3 = 0;
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    if (ds.Tables[i].Rows[j][1].ToString().Equals("1"))
                    {
                        count1++;
                    }
                    if (ds.Tables[i].Rows[j][1].ToString().Equals("2"))
                    {
                        count2++;
                    }
                    if (!ds.Tables[i].Rows[j][1].ToString().Equals("2") && !ds.Tables[i].Rows[j][1].ToString().Equals("1"))
                    {
                        count3++;
                    }
                }

                //Add rows to the table which contains some random data for demonstration
                dr = dt.NewRow();
                dr["Month"] = year + "年" + Convert.ToString(i + 1) + "月";
                dr["Volume1"] = count1;
                dr["Volume2"] = count2;
                dr["Volume3"] = count3;
                dr["Volume4"] = ds.Tables[i].Rows.Count;
                dt.Rows.Add(dr);
            }
            return dt;

        }

        protected void Calcul_Click(object sender, EventArgs e)
        {
            string year = DropDownList1.Text.ToString();   //获取年份
            if (year.Equals("请选择"))    //如果未选择年份，则弹出提示框并结束程序
            {
                this.Response.Write("<script>alert('请选择年份！');</script>");
                return;
            }
            //初始化表格
            DataTable dt = CreateDataTable(year);
            //Set the DataSource property of the Chart control to the DataTabel
            Chart1.DataSource = dt;
            //Bind the Chart control with the setting above
            Chart1.DataBind();
        }


    }
}