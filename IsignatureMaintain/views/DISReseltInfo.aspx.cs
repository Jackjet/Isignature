using IsignatureMaintain.Models;
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
    public partial class DISReseltInfo : System.Web.UI.Page
    {

        SqlHelper sqlhp = new SqlHelper();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GrvBlind(SQLCON_DWH);
            }
        }
        public string GetSQLStr()
        {
            string ConditionStr = "SELECT [common_id],[DocNo],[DocDescription],[IsOnlyStamp],[UploadUser],[FTP],[PageCount],[ConvertA1],[OwnerNo],[Uploaded],[UploadTime]  FROM[DWH].[dbo].[Hanna_DIS_Reselt]  where UploadTime >= '2019-09-01'";

            if (!this.TextBox_DocNo.Text.Trim().Equals(""))
            {
                //获取$符号后面字符串
                ConditionStr += " and [DocNo] like '%" + TextBox_DocNo.Text.Trim() + "%'";
            }

            if (!this.TextBox_UploadUser.Text.Trim().Equals(""))
            {
                //获取$符号后面字符串
                ConditionStr += " and [UploadUser] like '%" + TextBox_UploadUser.Text.Trim() + "%'";
            }

            if (!this.DropDownList_IsOnlyStamp.Text.Trim().Equals(""))
            {
                ConditionStr = ConditionStr + " and [IsOnlyStamp]='" + DropDownList_IsOnlyStamp.Text.Trim() + "'";
            }

            if (!this.DropDownList_Uploaded.Text.Trim().Equals(""))
            {
                ConditionStr = ConditionStr + " and [Uploaded]='" + DropDownList_Uploaded.Text.Trim() + "'";
            }

            ConditionStr = ConditionStr + " order by common_id desc";
            return ConditionStr;
        }


        public void GrvBlind(string SQLCON_DWH)
        {
            string selectstr = GetSQLStr();
            DataTable dt = sqlhp.GetData(selectstr, SQLCON_DWH);
            this.GrvHanna.DataSource = dt;
            this.GrvHanna.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GrvBlind(SQLCON_DWH);
        }

        protected void GrvHanna_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvHanna.PageIndex = e.NewPageIndex;
            GrvBlind(SQLCON_DWH);
        }
    }
}