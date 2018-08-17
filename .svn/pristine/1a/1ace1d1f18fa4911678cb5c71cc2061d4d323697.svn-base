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
    public partial class SuccssOrFail : System.Web.UI.Page
    {

        /*数据库连接字符创*/
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        public DataTable Dtb = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dtb.Clear();
                Dtb = GetUnitData();
                this.GridView1.DataSource = Dtb;
                this.GridView1.DataBind();
            }
        }


        protected DataTable GetUnitData()
        {
            DataSet ds = new DataSet();
            string SQL_JGQZ = "SELECT DOC_UNIQUE,SUBSTRING([DOC_DOCUMENTID],10,40) AS [DOC_DOCUMENTID],[CREATE_TIME],[ErrorMsg],CASE WHEN SIGN_DOCNUMET.DOC_STATUS = '2' THEN '成功' WHEN SIGN_DOCNUMET.DOC_STATUS = '3' THEN '失败' WHEN SIGN_DOCNUMET.DOC_STATUS = '1' THEN '代签' WHEN SIGN_DOCNUMET.DOC_STATUS = '6' THEN '正在盖章' END AS [DOC_STATUS]  FROM [SIGN_DOCNUMET] WHERE DOC_UNIQUE IN (SELECT MAX(DOC_UNIQUE)FROM [dbo].[SIGN_DOCNUMET] where DOC_DOCUMENTID LIKE '%@%' AND CREATE_TIME>'2016.09.01' group BY SUBSTRING(DOC_DOCUMENTID,10,40) ) order by DOC_UNIQUE DESC";
            string SQL_CPMS_ZJK = "SELECT [picnumber],[picname],[designer] ,[uploadtime],[special],[projectnumber],[projectname],SUBSTRING([printfilename],10,40) AS [printfilename] FROM [DWH].[dbo].[CPMS_sync_drawinginfo] WHERE printfilename LIKE '%@%' ORDER BY common_id desc";
            
            DataTable CPMS_ZJK = GetData(SQL_CPMS_ZJK, SQLCON_DWH);
            DataTable JGQZ = GetData(SQL_JGQZ, SQLCON_Isignature);
            ds.Tables.Add(CPMS_ZJK);
            ds.Tables.Add(JGQZ);


            //1. 新建DataTable并初始化连接表表结构  
            DataTable DtUnion = new DataTable();
            DtUnion.Columns.Add("DOC_UNIQUE");          
            DtUnion.Columns.Add("DOC_DOCUMENTID"); 
            DtUnion.Columns.Add("CREATE_TIME");
            DtUnion.Columns.Add("ErrorMsg");
            DtUnion.Columns.Add("DOC_STATUS");           
            DtUnion.Columns.Add("picnumber");
            DtUnion.Columns.Add("picname");
            DtUnion.Columns.Add("designer");
            DtUnion.Columns.Add("uploadtime");
            DtUnion.Columns.Add("special");
            DtUnion.Columns.Add("projectnumber");
            DtUnion.Columns.Add("projectname");
            DtUnion.Columns.Add("printfilename");                     

            //2. 数据筛选并写入连接表   left join on
            var query = from rowLeft in JGQZ.AsEnumerable()
                        join rowRight in CPMS_ZJK.AsEnumerable() on rowLeft["DOC_DOCUMENTID"] equals rowRight["printfilename"] into temp
                        from subRight in temp.DefaultIfEmpty()
                        select rowLeft.ItemArray.Concat((subRight == null) ? (CPMS_ZJK.NewRow().ItemArray) : subRight.ItemArray).ToArray();
            //3. 遍历，插入databale
            foreach (object[] values in query)
                DtUnion.Rows.Add(values);


            //4. 对datatable 多条件查询
            DataTable newdt = new DataTable();
            newdt = DtUnion.Clone();     //先建立新表    克隆DtUnion 的结构，包括所有 DtUnion 架构和约束,并无数据； 

            string ConditionStr = "";
            if(!TextBox_PrjNum.Text.Trim().Equals(""))
            {
                ConditionStr += " and DOC_DOCUMENTID like '%" + TextBox_PrjNum.Text.Trim() + "%'";
            }
            if (!TextBox_DocName.Text.Trim().Equals(""))
            {
                ConditionStr += " and DOC_DOCUMENTID like '%" + TextBox_DocName.Text.Trim() + "%'";
            }
            if (!TextBox_Designer.Text.Trim().Equals(""))
            {
                ConditionStr += " and designer like '%" + TextBox_Designer.Text.Trim() + "%'";
            }
            if (!DropDownList_DOC_STATUS.Text.Trim().Equals(""))
            {
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("成功"))
                    ConditionStr += " and picnumber is not null";
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("失败"))
                    ConditionStr += " and picnumber is null";
            }
            DataRow[] dr = DtUnion.Select("DOC_UNIQUE is not null" + ConditionStr, "DOC_UNIQUE desc");     // 从DtUnion 中查询符合条件的记录； 

            for (int i = 0; i < dr.Length; i++)     // 将查询的结果添加到DtUnion中； 
            {
                newdt.ImportRow((DataRow)dr[i]);
            }

            return newdt;
        }

        /*SQL数据执行*/
        protected void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        /*SQL数据查询，返回datatable*/
        protected DataTable GetData(string selctsql, string connstr)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(selctsql);
            SqlDataAdapter ad = new SqlDataAdapter(sb.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }


        //翻页功能
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Dtb.Clear();
            Dtb = GetUnitData();
            this.GridView1.DataSource = Dtb;
            this.GridView1.DataBind();
        }

        protected void Button_Seach_Click(object sender, EventArgs e)
        {
            Dtb.Clear();
            Dtb = GetUnitData();
            this.GridView1.DataSource = Dtb;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //列值不为"成功"的标记颜色
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (drv.Row["picnumber"].ToString().Trim().Equals(""))
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                //if (drv.Row["ErrorMsg"].ToString().Trim().Equals("手动处理"))
                //{
                //    e.Row.BackColor = System.Drawing.Color.LightYellow;
                //}
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName.Trim();
            try
            {
                //获取选中行索引值
                GridViewRow gvr = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));

                //根据索引值获取某列的值
                string DOC_NAME = ((HyperLink)(GridView1.Rows[gvr.RowIndex].Cells[5].Controls[0])).Text;   //列属性为HyperLink，获取值要麻烦些

                //string cc = GridView_IsigResult.Rows[gvr.RowIndex].Cells[3].Text;     //普通列获值
                //string FailReason = ((DropDownList)(GridView1.Rows[gvr.RowIndex].FindControl("DropDownList_FailReason"))).SelectedValue;  //获取dropdownlist的值
                //如果点击重签执行以下操作
                if (cmd == "Resign")
                {

                        //更新SPF中间表state值，进行重签操作
                    string updatesql = "UPDATE [DWH].[dbo].[SPF_QZ_File_Info] SET state=0 WHERE filename = '" + DOC_NAME + "'";
                        //this.Response.Write("<script>alert('" + DOC_REAL_NAME + "');</script>");
                        noQuery(updatesql, SQLCON_DWH);

                }

            }
            catch (Exception ex)
            {
                //输出错误信息
                //this.Response.Write("<script>alert('重签失败');</script>");
                //return;
            }

            Dtb.Clear();
            Dtb = GetUnitData();
            this.GridView1.DataSource = Dtb;
            this.GridView1.DataBind();    //页面数据绑定重新刷新
        }


    }
}