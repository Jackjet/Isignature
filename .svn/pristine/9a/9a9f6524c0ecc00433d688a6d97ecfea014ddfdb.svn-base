using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.views
{
    public partial class SignMaintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Gridview绑定
                string ConditionStr = GetConstr();
                GridView_sign_Blind(ConditionStr);
            }
        }

        protected void Seach_Click(object sender, EventArgs e)
        {
            string ConditionStr = GetConstr();
            GridView_sign_Blind(ConditionStr);
        }

        /*数据库连接字符创*/
        string MYSQLCON_IsigSys = ConfigurationManager.ConnectionStrings["MYSQLCON_IsigSys"].ToString();

        //全局变量
        public string ConditionStr = "";

        //数据库操作方法
        public void noQuery(string mysql)
        {
            MySqlConnection conn = new MySqlConnection(MYSQLCON_IsigSys);
            MySqlCommand cmd = new MySqlCommand(mysql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //查询条件字符串
        public string GetConstr()
        {
            /*
            * 选择条件组合
           */
            ConditionStr = "";
            //键、值、签名是否正在使用
            string keysn = TextBox_keysn.Text.ToString().Trim();
            string userName = TextBox_userName.Text.ToString().Trim();

            //下拉框值为"请选择","启用","注销","禁用"，keyStatus的值
            if (!DropDownList_signStatus.Text.Trim().Equals("请选择"))
            {
                if (DropDownList_signStatus.Text.Trim().Equals("使用中"))
                    ConditionStr += " and t_signinfo.signStatus = '01'";
                if (DropDownList_signStatus.Text.Trim().Equals("已失效"))
                    ConditionStr += " and t_signinfo.signStatus != '01'";
            }

            if (!keysn.Equals(""))
                ConditionStr += " and t_keyinfo.keysn like '%" + keysn + "%'";
            if (!userName.Equals(""))
                ConditionStr += " and t_keyinfo.userName like '%" + userName + "%'";

            return ConditionStr;
        }
        public DataTable GetDataSignInfo(string ConditionStr)
        {

            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(MYSQLCON_IsigSys);
            conn.Open();
            StringBuilder mysql_isig = new StringBuilder();
            mysql_isig.AppendFormat("select t_signinfo.tid,t_keyinfo.keysn,t_keyinfo.userName,case when t_signinfo.signStatus='01' then '使用中' else '已失效' end as signStatus,t_orginfo.orgName,t_signinfo.signName,t_signinfo.signWidth,t_signinfo.signHeight,t_signinfo.signDate FROM t_signinfo,t_orginfo,t_keyinfo where t_signinfo.keyUniqueMarker = t_keyinfo.keyUniqueMarker and t_orginfo.uniqueMarker = t_keyinfo.orgUniqueMarker " + ConditionStr + " ORDER BY t_signinfo.tid DESC");
            MySqlDataAdapter ad = new MySqlDataAdapter(mysql_isig.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        //Gridview数据绑定函数
        public void GridView_sign_Blind(string ConditionStr)
        {
            this.GridView_sign.DataSource = GetDataSignInfo(ConditionStr);
            this.GridView_sign.DataBind();
        }

        protected void GridView_sign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_sign.PageIndex = e.NewPageIndex;
            string ConditionStr = GetConstr();
            GridView_sign_Blind(ConditionStr);
        }

        protected void GridView_sign_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tid = Convert.ToInt32(GridView_sign.DataKeys[e.RowIndex].Value.ToString());
            string deleteMySql = "DELETE FROM t_signinfo WHERE tid =" + tid + "";
            noQuery(deleteMySql);
            this.Response.Write("<script>alert('用户删除成功！');</script>");
            string ConditionStr = GetConstr();
            GridView_sign_Blind(ConditionStr);
        }

    }
}