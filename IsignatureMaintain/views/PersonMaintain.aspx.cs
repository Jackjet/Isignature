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
    public partial class PersonMaintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //下拉框绑定部门
            if (!IsPostBack)
            {
                this.DropDownList_Dep.DataSource = GetDep();
                this.DropDownList_Dep.DataValueField = "orgname";
                this.DropDownList_Dep.DataBind();
                Gridview_Blind();
            }
           
        }

        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();

        //数据库操作方法
        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        //获取部门数据
        public DataTable GetDep()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_Huizhi);
            conn.Open();
            StringBuilder sql_huizhi = new StringBuilder();

            sql_huizhi.AppendFormat("select orgname from orgnization where mainid >=5 and mainid!=7593");
            SqlDataAdapter ad = new SqlDataAdapter(sql_huizhi.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }


        //返回sql查询数据存入方法
        public DataTable GetPersonInfo()
        {
            string username = this.name_text.Value.ToString().Trim();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_Huizhi);
            conn.Open();
            StringBuilder sql_huizhi = new StringBuilder();
            //输入值未空显示所有数据，不为空则显示筛选数据
            if (username.Equals(""))
                sql_huizhi.AppendFormat("SELECT P.[mainid],P.[account],P.[username],O.[orgname],P.[departmentid],P.[userstate],P.[systemtime],P.[erpuid] FROM [nbsh].[dbo].[puser] P,[nbsh].[dbo].[orgnization] O WHERE P.[departmentid]=O.[mainid] order by P.[mainid] desc");
            else
                sql_huizhi.AppendFormat("SELECT P.[mainid],P.[account],P.[username],O.[orgname],P.[departmentid],P.[userstate],P.[systemtime],P.[erpuid] FROM [nbsh].[dbo].[puser] P,[nbsh].[dbo].[orgnization] O WHERE P.[departmentid]=O.[mainid] and (P.[username] like '%" + username + "%' or P.[account] like '%" + username + "%') order by P.[mainid] desc");
            SqlDataAdapter ad = new SqlDataAdapter(sql_huizhi.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        //Gridview数据绑定
        public void Gridview_Blind()
        {
            this.GridView_Person.DataSource = GetPersonInfo();
            this.GridView_Person.DataBind();
        }
        //数据查询
        protected void Button_Search_Click(object sender, EventArgs e)
        {
            Gridview_Blind();
        }

        //翻页代码
        protected void GridView_Person_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Person.PageIndex = e.NewPageIndex;
            this.GridView_Person.DataSource = GetPersonInfo();
            GridView_Person.DataBind();
        }

        //返回sql查询数据存入方法
        public DataTable GetData(string selectstr)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_Huizhi);
            conn.Open();
            StringBuilder sql_huizhi = new StringBuilder();

            sql_huizhi.AppendFormat(selectstr);
            SqlDataAdapter ad = new SqlDataAdapter(sql_huizhi.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }
        protected void Button_Add_Click(object sender, EventArgs e)
        {
            //获取最大mainid和erpuid
            string selectstr1 = "select max(mainid)+1 as mainid,max(erpuid)+1 as erpuid from puser";

            //获取部门编号
            string DepName = this.DropDownList_Dep.SelectedValue.ToString().Trim();
            string selectstr2 = "select mainid,orgname from orgnization where orgname = '" + DepName + "'";

            //初始化mainid，account，username，gender，password..... 
            int mainid = Convert.ToInt32(GetData(selectstr1).Rows[0][0].ToString());
            string account = this.AccountAdd_Text.Value.ToString().Trim();
            string username = this.NameAdd_Text.Value.ToString().Trim();
            int gender = 0;
            string password = "D8EB87629476878CB0EC2349AE109CDE";
            int disabled = 0;
            string departmentid = GetData(selectstr2).Rows[0][0].ToString();
            string userstate = "在职";
            DateTime systemtime = DateTime.Now;
            int erpuid = Convert.ToInt32(GetData(selectstr1).Rows[0][1].ToString());

            //获取慧智系统数据库连接字段
            string SQLCON = SQLCON_Huizhi;

            //假如account，username为空，不执行数据插入操作
            if (account.Equals("") || username.Equals(""))
            {
                this.Response.Write("<script>alert('账户或姓名不能为空！');</script>");
            }
            else
            {
                string InsertSql = "insert into puser ([mainid],[account],[username],[gender],[password],[disabled],[departmentid],[userstate],[systemtime],[erpuid]) values (" + mainid + ",'" + account + "','" + username + "',0,'D8EB87629476878CB0EC2349AE109CDE',0,'" + departmentid + "','在职','" + systemtime + "'," + erpuid + ")";
                try
                {
                    noQuery(InsertSql, SQLCON);
                    this.Response.Write("<script>alert('用户添加成功！');</script>");
                }
                catch { }
            }

            Gridview_Blind();
        }

        //删除
        protected void GridView_Person_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int mainid = Convert.ToInt32(GridView_Person.DataKeys[e.RowIndex].Value.ToString());
            string deleteSql = "DELETE FROM dbo.puser WHERE mainid =" + mainid + "";
            noQuery(deleteSql, SQLCON_Huizhi);
            this.Response.Write("<script>alert('用户删除成功！');</script>");
            Gridview_Blind();
        }

        //编辑
        protected void GridView_Person_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView_Person.EditIndex = e.NewEditIndex;
            Gridview_Blind();
        }

        //取消编辑
        protected void GridView_Person_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Person.EditIndex = -1;
            Gridview_Blind();
        }

        //更新
        protected void GridView_Person_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取账户，姓名，更新时间，mainid
            string account = ((TextBox)(GridView_Person.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();//第一列注意这种写法很重要
            string username = ((TextBox)(GridView_Person.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            DateTime systemtime = DateTime.Now;
            int mainid = Convert.ToInt32(GridView_Person.DataKeys[e.RowIndex].Value.ToString());
            string updateStr = "update dbo.puser set account='" + account + "',username='" + username + "',systemtime='" + systemtime + "' where mainid=" + mainid + "";

            noQuery(updateStr, SQLCON_Huizhi);
            this.Response.Write("<script>alert('用户更新成功！');</script>");
            GridView_Person.EditIndex = -1;
            Gridview_Blind();
        }


    }
}