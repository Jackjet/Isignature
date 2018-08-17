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
    public partial class HanaFileCKPLTRcd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FileName = Request.QueryString["FileName"].ToString();    //获取传递的参数值
            FileName = FileName.Remove(FileName.LastIndexOf("."));
            if (FileName.Contains(" "))
                FileName = FileName.Substring(0, FileName.IndexOf(" "));
            string sql_ck = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client]  FROM [HNDServer].[dbo].[FileCheckPool] where FileName like '%" + FileName + "%' and ORGFilePath like '%FTP://10.151.131.53%' order by LastUpdateDate desc";
            DataTable dt_Check = GetData(sql_ck, SQLCON_Hanna);
            this.Grv_Check.DataSource = dt_Check;
            this.Grv_Check.DataBind();

            string sql_plt = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[CreateDate] as [UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client] FROM [HNDServer].[dbo].[FilePlotPool] where FileName like '%" + FileName + "%' and ORGFilePath like '%FTP://10.151.131.53%' order by LastUpdateDate desc";
            DataTable dt_plt = GetData(sql_plt, SQLCON_Hanna);
            this.Grv_Plot.DataSource = dt_plt;
            this.Grv_Plot.DataBind();
        }

        #region  数据库操作方法
        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();
        string SQLCON_Hanna = ConfigurationManager.ConnectionStrings["SQLCON_Hanna"].ToString();



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