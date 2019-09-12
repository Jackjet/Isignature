using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace IsignatureMaintain.Models
{
    public class SqlHelper
    {
        #region  数据库操作方法
        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();
        string SQLCON_Hanna = ConfigurationManager.ConnectionStrings["SQLCON_Hanna"].ToString();
        string SQLCON_Hanna1 = ConfigurationManager.ConnectionStrings["SQLCON_Hanna1"].ToString();


        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /*SQL数据查询，返回datatable*/
        public DataTable GetData(string selctsql, string SQLCON)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON);
            conn.Open();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(selctsql);
            SqlDataAdapter ad = new SqlDataAdapter(sb.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }
        #endregion
    }
}