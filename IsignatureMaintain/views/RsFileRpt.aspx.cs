using Newtonsoft.Json;
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
            string action = Request.Form["action"];  //项目类型
            if (!string.IsNullOrEmpty(action)) // 如果不是通过ajax 请求提交数据 就不会进入花括号来调用GetUserData(string year) 方法
            {
                if (action.Equals("GetFileCount"))
                {
                    GetJson();
                }
            }
        }


        public void GetJson()
        {
            string selectsql = "select a.TotalCount ,b.ResignCount,a.uploadtime  from (SELECT COUNT(*)as TotalCount ,convert(varchar(7),uploadtime) as uploadtime  FROM[DWH].[dbo].[CPMS_sync_drawinginfo] where resign IS  NULL group by convert(varchar(7), uploadtime)  ) a left join  (SELECT COUNT(*) as ResignCount, convert(varchar(7), uploadtime) as uploadtime  FROM[DWH].[dbo].[CPMS_sync_drawinginfo]  where Resign = 'Y'  group by convert(varchar(7), uploadtime)  ) b  on a.uploadtime = b.uploadtime  where a.uploadtime > '2018-07'  order by uploadtime desc";
            string sqlcon = SQLCON_DWH;

            DataTable dt = GetData(selectsql, sqlcon);

            string Jsondata = JsonConvert.SerializeObject(dt);
            Response.Write(Jsondata);
            Response.End();
        }


    }
}