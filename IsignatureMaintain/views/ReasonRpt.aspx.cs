using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.views
{
    public partial class ReasonRpt : System.Web.UI.Page
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

        //初始化chart
        public void InitChart()
        {
            Chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧 
            Chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chart1.Series[0].ToolTip = "文件数：#VALY；百分率：#PERCENT";   //饼状图中tooltip的值
            //Chart1.Series[0].ToolTip = "文件数：#PERCENT";

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            string selectsql = "select Remark as Reason,count(*) as Num  from [MyDataBase].[dbo].[SIGN_DOCNUMET_INSIG_INFO_Bak]  where Remark!='请选择'  group by Remark";
            DataTable dt = GetData(selectsql, SQLCON_Isignature);
            List<string> xData = new List<string>();
            List<string> yData = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xData.Add((dt.Rows[i][0].ToString() + "：共" + dt.Rows[i][1].ToString() + "个文件").Substring(3));
                yData.Add(dt.Rows[i][1].ToString());
            }

            Chart1.Series[0].Points.DataBindXY(xData, yData);
            InitChart();
        }
    }
}