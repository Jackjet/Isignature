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
    public partial class DataDictMaintain : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConditionStr = GetConstr();
                GridView_DataDict_Blind(ConditionStr);
            }
                     
        }


        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();
        
        //全局变量
        public string ConditionStr = "";

        //数据库操作方法
        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //获取条件字符串
        public string GetConstr()
        {
            /*
            * 选择条件组合
           */
            ConditionStr = "";
            //键、值、是否适用于协同管理
            string key = this.TextBox_key.Text.ToString().Trim();
            string value = this.TextBox_value.Text.ToString().Trim();
            string remark = this.TextBox_remark.Text.ToString().Trim();

            if (!this.TextBox_key.Text.ToString().Trim().Equals(""))
                ConditionStr += " and [key] like '%" + key + "%'";
            if (!this.TextBox_value.Text.ToString().Trim().Equals(""))
                ConditionStr += " and [value] like '%" + value + "%'";
            if (!this.TextBox_remark.Text.ToString().Trim().Equals(""))
                ConditionStr += " and [remark] like '%" + remark + "%'";

            //下拉框值为是，赋值为"1"，其他为0
            if (!DropDownList_manage.Text.Trim().Equals(""))
            {
                if (DropDownList_manage.Text.Trim().Equals("是"))
                    ConditionStr += " and [iscaduse] = '1'";
                if (DropDownList_manage.Text.Trim().Equals("否"))
                    ConditionStr += " and [iscaduse] = '0'";
            }
            return ConditionStr;
        }

        //获取SQL语句返回的datatable
        public DataTable GetDataDictInfo(string ConditionStr)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_Huizhi);
            conn.Open();
            StringBuilder sql_huizhi = new StringBuilder();
            sql_huizhi.AppendFormat("SELECT [key],[value],[remark],[unuse],[common_id],[iscaduse] FROM [nbsh].[dbo].[prj_dictionary] WHERE [key] is not null " + ConditionStr + " order by [key] desc");
            SqlDataAdapter ad = new SqlDataAdapter(sql_huizhi.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        //Gridview数据绑定函数
        public void GridView_DataDict_Blind(string ConditionStr)
        {
            this.GridView_DataDict.DataSource = GetDataDictInfo(ConditionStr);
            this.GridView_DataDict.DataBind();
        }


       

        //搜索按钮功能
        protected void Button_Seach_Click(object sender, EventArgs e)
        {
            string ConditionStr = GetConstr();
            GridView_DataDict_Blind(ConditionStr);
        }

        //Gridview翻页
        protected void GridView_DataDict_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_DataDict.PageIndex = e.NewPageIndex;
            string ConditionStr = GetConstr();
            GridView_DataDict_Blind(ConditionStr);
        }

        //Gridveiw编辑状态
        protected void GridView_DataDict_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView_DataDict.EditIndex = e.NewEditIndex;
            string ConditionStr = GetConstr();
            GridView_DataDict_Blind(ConditionStr);
        }

        //Gridveiw更新UPDATE操作
        protected void GridView_DataDict_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取键、值、备注
            string key = ((TextBox)(GridView_DataDict.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();//第一列注意这种写法很重要
            string value = ((TextBox)(GridView_DataDict.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string remark = ((TextBox)(GridView_DataDict.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
            //Gridview属性里边需要加上 DataKeysNames="common_id"
            int common_id = Convert.ToInt32(GridView_DataDict.DataKeys[e.RowIndex].Value.ToString());
            string updateStr = "update [nbsh].[dbo].[prj_dictionary] set [key]='" + key + "',[value]='" + value + "',[remark]='" + remark + "' where [common_id] =" + common_id + "";
            noQuery(updateStr, SQLCON_Huizhi);
            this.Response.Write("<script>alert('用户更新成功！');</script>");
            GridView_DataDict.EditIndex = -1;
            string ConditionStr = GetConstr();
            GridView_DataDict_Blind(ConditionStr);
        }

        //Gridveiw取消编辑状态
        protected void GridView_DataDict_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_DataDict.EditIndex = -1;
            string ConditionStr = GetConstr();
            GridView_DataDict_Blind(ConditionStr);
        }
      
    }
}