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

namespace IsignatureMaintain.Views
{
    public partial class HistoryVersion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Data_Blind();
        }

        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();

        public static DataSet fill(String sqlstr, string Connstr)
        {
            SqlConnection con = new SqlConnection(Connstr);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(sqlstr, con);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            con.Close();
            return ds;
        }

        /*****
         * 将数据绑定到datatable中
         *****/
        DataTable dt = new DataTable();
        public DataTable GetData(string DOC_REAL_NAME)
        {
            dt.Clear();   //先清空再赋值。
            SqlConnection conn = new SqlConnection(SQLCON_Isignature);
            StringBuilder sql = new StringBuilder();

            if (DOC_REAL_NAME.Equals(""))     //查看最近文件的所有签名信息
            {
                string Condstr = TextBox_DOC_NAME.Text.Trim();
                sql.AppendFormat(" SELECT [DOC_UNIQUE],[DOC_NAME],SUBSTRING(DOC_DOCUMENTID,10,40) AS [DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],CASE WHEN DOC_STATUS = '2' THEN '成功' WHEN DOC_STATUS = '3' THEN '失败' WHEN DOC_STATUS = '1' THEN '代签' WHEN DOC_STATUS = '6' THEN '正在盖章' END AS STATUS,DOC_PATH,DOC_SUCCEEPATH,DOC_FAILPATH  FROM [SIGN_DOCNUMET] WHERE DOC_NAME like '%@%' AND CREATE_TIME >='2016.09.01' and DOC_DOCUMENTID LIKE '%" + Condstr + "%' order by DOC_UNIQUE desc");
            }
            else    //跳转查看某文件的历史签名信息    文件text搜索框不能修改
            {
                TextBox_DOC_NAME.Text = DOC_REAL_NAME;
                TextBox_DOC_NAME.Enabled = false;

                sql.AppendFormat(" SELECT [DOC_UNIQUE],[DOC_NAME],SUBSTRING(DOC_DOCUMENTID,10,40) AS [DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],CASE WHEN DOC_STATUS = '2' THEN '成功' WHEN DOC_STATUS = '3' THEN '失败' WHEN DOC_STATUS = '1' THEN '代签' WHEN DOC_STATUS = '6' THEN '正在盖章' END AS STATUS,DOC_PATH,DOC_SUCCEEPATH,DOC_FAILPATH  FROM [SIGN_DOCNUMET] WHERE DOC_NAME like '%@%' AND CREATE_TIME >='2016.09.01' and DOC_DOCUMENTID LIKE '%" + DOC_REAL_NAME + "%' order by DOC_UNIQUE desc");
            }
            SqlDataAdapter ad = new SqlDataAdapter(sql.ToString(), conn);
            ad.Fill(dt);

            //初始化源文件，成功文件，失败文件的路径。
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sqlstr = "SELECT [fileuid],[filename],[ftpaddress] FROM [CPMS_sync_fileinfo] WHERE fileuid in (SELECT SUBSTRING([annex],0,8) FROM [CPMS_sync_drawinginfo] WHERE printfilename like '%" + DOC_REAL_NAME + "%') OR fileuid in (SELECT SUBSTRING([pltannex],0,8) FROM [CPMS_sync_drawinginfo] WHERE printfilename like '%" + DOC_REAL_NAME + "%') ORDER BY common_id DESC";
                DataTable dsadd = fill(sqlstr, SQLCON_DWH).Tables[0];

                if (dsadd.Rows.Count > 0 && i == 0)
                {
                    dt.Rows[i][8] = "file://10.151.131.53/FTPhztocpms" + dsadd.Rows[1][2].ToString().Trim();       //原始文件路径
                    dt.Rows[i][9] = "file://10.151.131.53/FTPhztocpms" + dsadd.Rows[0][2].ToString().Trim();       //签名签章成功文件路径
                    dt.Rows[i][10] = "";
                }
                else
                {
                    if (dt.Rows[i][4].ToString().Equals("2"))    //签名成功
                    {
                        dt.Rows[i][8] = "ftp://10.151.126.1" + dt.Rows[i][8].ToString().Trim();       //DOC_PATH路径
                        dt.Rows[i][9] = "ftp://10.151.126.1" + dt.Rows[i][9].ToString().Trim();       //DOC_SUCCEEPATH路径
                        dt.Rows[i][10] = "";       //DOC_FAILPATH路径
                    }
                    else    //签名失败
                    {
                        dt.Rows[i][8] = "ftp://10.151.126.1" + dt.Rows[i][8].ToString().Trim();       //DOC_PATH路径
                        dt.Rows[i][9] = "";       //DOC_SUCCEEPATH路径
                        dt.Rows[i][10] = "ftp://10.151.126.1" + dt.Rows[i][10].ToString().Trim();       //DOC_FAILPATH路径
                    }
                    
                }
                dsadd.Clear();
            }
            return dt;
        }

        public void Data_Blind()
        {
            string DOC_REAL_NAME = "";
            try
            {
                DOC_REAL_NAME = Request.QueryString["DOC_REAL_NAME"].ToString();
            }
            catch
            {
                //输出错误信息
                //this.Response.Write("<script>alert('文件名格式有误');</script>");
            }
            //string DOC_NAME = TextBox_DOC_NAME.Text.Trim();
            this.GridView_Version.DataSource = GetData(DOC_REAL_NAME);
            this.GridView_Version.DataBind();
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            Data_Blind();
        }

        protected void GridView_Version_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = -1; i < GridView_Version.Rows.Count; i++)
                //用FindControl方法找到模板中的HyperLink控件，对其赋值，并初始化超链接地址
                {
                    HyperLink HyperLink_DOC_PATH = (HyperLink)e.Row.FindControl("HyperLink_DOC_PATH");
                    HyperLink_DOC_PATH.Text = dt.Rows[i + 1][8].ToString();
                    HyperLink_DOC_PATH.NavigateUrl = dt.Rows[i + 1][8].ToString();

                    HyperLink DOC_SUCCEEPATH = (HyperLink)e.Row.FindControl("HyperLink_DOC_SUCCEEPATH");
                    DOC_SUCCEEPATH.Text = dt.Rows[i + 1][9].ToString();
                    DOC_SUCCEEPATH.NavigateUrl = dt.Rows[i + 1][9].ToString();

                    HyperLink DOC_FAILPATH = (HyperLink)e.Row.FindControl("HyperLink_DOC_FAILPATH");
                    DOC_FAILPATH.Text = dt.Rows[i + 1][10].ToString();
                    DOC_FAILPATH.NavigateUrl = dt.Rows[i + 1][10].ToString();

                }
            }
        }

        protected void GridView_Version_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Version.PageIndex = e.NewPageIndex;
            Data_Blind();
        }



    }
}