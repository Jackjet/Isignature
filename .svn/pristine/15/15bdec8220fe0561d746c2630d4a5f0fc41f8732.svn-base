using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace IsignatureMaintain.views
{
    public partial class KeyMaintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DropDownList绑定
                this.DropDownList_orgName.DataSource = GetDep();
                this.DropDownList_orgName.DataValueField = "orgName";
                this.DropDownList_orgName.DataBind();
                this.DropDownList_orgName.Items.Insert(0, "请选择");

                //Gridview绑定
                string ConditionStr = GetConstr();
                GridView_Key_Blind(ConditionStr);
            }
        }


        protected void Seach_Click(object sender, EventArgs e)
        {
            string ConditionStr = GetConstr();
            GridView_Key_Blind(ConditionStr);
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

        //获取部门数据
        public DataTable GetDep()
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(MYSQLCON_IsigSys);
            conn.Open();
            StringBuilder mysql_isig = new StringBuilder();
            mysql_isig.AppendFormat("SELECT DISTINCT t_orginfo.orgName FROM t_keyinfo,t_orginfo WHERE t_keyinfo.orgUniqueMarker = t_orginfo.uniqueMarker");
            MySqlDataAdapter ad = new MySqlDataAdapter(mysql_isig.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }


        //获取SQL语句返回的datatable
        public DataTable GetDataKeyInfo(string ConditionStr)
        {

            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(MYSQLCON_IsigSys);
            conn.Open();
            StringBuilder mysql_isig = new StringBuilder();
            mysql_isig.AppendFormat("select t_keyinfo.tid,t_keyinfo.keysn,t_keyinfo.userCode,t_keyinfo.userName,case when t_keyinfo.keyStatus='01' then '启用' when t_keyinfo.keyStatus='02' then '注销' else '禁用' end as keyStatus,t_orginfo.orgName,t_keyinfo.applyDate,t_keyinfo.overDate from t_keyinfo,t_orginfo where t_keyinfo.orgUniqueMarker = t_orginfo.uniqueMarker " + ConditionStr + " order by t_keyinfo.applyDate DESC");
            MySqlDataAdapter ad = new MySqlDataAdapter(mysql_isig.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        //根据选中行的tid，获取该用户对应的签名数目
        public int GetsignNum(int tid)
        {
            int signNum=0;
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(MYSQLCON_IsigSys);
            conn.Open();
            StringBuilder mysql_isig = new StringBuilder();
            mysql_isig.AppendFormat("SELECT count(*) FROM t_signinfo where keyUniqueMarker in (SELECT keyUniqueMarker FROM t_keyinfo where tid='" + tid + "')");
            MySqlDataAdapter ad = new MySqlDataAdapter(mysql_isig.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            signNum = Convert.ToInt32(dt.Rows[0][0].ToString().Trim());
            return signNum;
        }


        //获取条件字符串
        public string GetConstr()
        {
            /*
            * 选择条件组合
           */
            ConditionStr = "";
            //键、值、是否适用于协同管理
            string keysn = this.TextBox_keysn.Text.ToString().Trim();
            string userCode = this.TextBox_userCode.Text.ToString().Trim();
            string userName = this.TextBox_userName.Text.ToString().Trim();

            //下拉框值为"请选择","启用","注销","禁用"，keyStatus的值
            if (!DropDownList_keyStatus.Text.Trim().Equals("请选择"))
            {
                if (DropDownList_keyStatus.Text.Trim().Equals("启用"))
                    ConditionStr += " and t_keyinfo.keyStatus= '01'";
                if (DropDownList_keyStatus.Text.Trim().Equals("注销"))
                    ConditionStr += " and t_keyinfo.keyStatus= '02'";
                if (DropDownList_keyStatus.Text.Trim().Equals("禁用"))
                    ConditionStr += " and t_keyinfo.keyStatus= '03'";
            }
            //string keyStatus = this.DropDownList_keyStatus.Text.ToString().Trim();
            string orgName = this.DropDownList_orgName.Text.ToString().Trim();

            if (!keysn.Equals(""))
                ConditionStr += " and t_keyinfo.keysn like '%" + keysn + "%'";
            if (!userCode.Equals(""))
                ConditionStr += " and t_keyinfo.userCode like '%" + userCode + "%'";
            if (!userName.Equals(""))
                ConditionStr += " and t_keyinfo.userName like '%" + userName + "%'";

            //下拉框值为是，赋值为"1"，其他为0
            if (!orgName.Equals("请选择"))
            {
                ConditionStr += " and t_orginfo.orgName = '" + orgName + "'";
            }
            return ConditionStr;
        }

        //Gridview数据绑定函数
        public void GridView_Key_Blind(string ConditionStr)
        {
            this.GridView_key.DataSource = GetDataKeyInfo(ConditionStr);
            this.GridView_key.DataBind();
        }

        protected void GridView_key_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_key.PageIndex = e.NewPageIndex;
            string ConditionStr = GetConstr();
            GridView_Key_Blind(ConditionStr);
        }

        //删除操作
        protected void GridView_key_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tid = Convert.ToInt32(GridView_key.DataKeys[e.RowIndex].Value.ToString());
            int signNum = GetsignNum(tid);    //获取盖用户的签名数目

            //假如签名数目为0，执行删除操作，否则不执行
            if(signNum==0)
            {

                string deleteMySql = "DELETE FROM t_keyinfo WHERE tid =" + tid + "";
                noQuery(deleteMySql);
                this.Response.Write("<script>alert('用户删除成功！');</script>");
            }
            else
            {
                this.Response.Write("<script>alert('该用户底下还有" + signNum + "条签章，请先删除对应签章再删除用户！');</script>");
            }

            //数据绑定
            string ConditionStr = GetConstr();
            GridView_Key_Blind(ConditionStr);
        }

    }
}