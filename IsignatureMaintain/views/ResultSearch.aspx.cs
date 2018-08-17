using IsignatureMaintain.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.Views
{
    public partial class ResultSearch : System.Web.UI.Page
    {
        //定义条件变量
        public string ConditionStr = "";
        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            /* * 选择条件组合*/
            ConditionStr = "";
            if (!TextBox_DOC_NAME.Text.Trim().Equals(""))
            {
                //获取$符号后面字符串
                string Doc_Name = TextBox_DOC_NAME.Text.Trim().Substring(TextBox_DOC_NAME.Text.Trim().LastIndexOf("$") + 1);
                ConditionStr = " and DOC_NAME like '%" + Doc_Name + "%'";
            }
            if (!TextBox_DOC_TYPE.Text.Trim().Equals(""))
                ConditionStr += " and DOC_TYPE like '%" + TextBox_DOC_TYPE.Text.Trim() + "%'";
            if (!TextBox_ErrorMsg.Text.Trim().Equals(""))
                ConditionStr += " and ErrorMsg like '%" + TextBox_ErrorMsg.Text.Trim() + "%'";
            if (!TextBox_USRNAME.Text.Trim().Equals(""))
                ConditionStr += " and USRNAME like '%" + TextBox_USRNAME.Text.Trim() + "%'";
            if (!DropDownList_DOC_STATUS.Text.Trim().Equals(""))
            {
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("代签"))
                    ConditionStr += " and DOC_STATUS = '1'";
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("成功"))
                    ConditionStr += " and DOC_STATUS = '2'";
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("失败"))
                    ConditionStr += " and DOC_STATUS = '3'";
                if (DropDownList_DOC_STATUS.Text.Trim().Equals("正在盖章"))
                    ConditionStr += " and DOC_STATUS = '6'";
            }

            if (!IsPostBack)   //页面第一次加载
            {
                Init_SIGN_DOCNUMET_INSIG_INFO_Bak();
                /*******************************************
                 * 数据绑定
                 *******************************************/

                //this.GridView_IsigResult.DataSource = GetUnionDt(ConditionStr);
                this.GridView_IsigResult.DataSource = GetDataInfo(ConditionStr);
                this.GridView_IsigResult.DataBind();
            }

            //Init_SIGN_DOCNUMET_INSIG_INFO_Bak();
        }





        //数据初始化，先清空删除，再插入数据
        public void Init_SIGN_DOCNUMET_INSIG_INFO_Bak()
        {
            //更新表格SIGN_DOCNUMET_INSIG_INFO_Bak数据
            string updatesql = "update p set p.DOC_UNIQUE = u.DOC_UNIQUE,p.DOC_NAME = u.DOC_NAME,p.DOC_STATUS = u.DOC_STATUS, p.CREATE_TIME = u.CREATE_TIME,p.ErrorMsg = u.ErrorMsg,p.STATUS = u.STATUS from [SIGN_DOCNUMET_INSIG_INFO_Bak] p, view_signinfo u where p.[DOC_REAL_NAME] = u.[DOC_REAL_NAME]";

            noQuery(updatesql, SQLCON_Isignature);


            //插入新数据，不带设计人信息
            string insert_noname = "INSERT INTO [dbo].[SIGN_DOCNUMET_INSIG_INFO_Bak]([DOC_UNIQUE],[DOC_NAME],[DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],[STATUS],[Remark])(SELECT [DOC_UNIQUE],[DOC_DOCUMENTID] as [DOC_NAME],SUBSTRING(DOC_DOCUMENTID,10,40) as [DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],CASE WHEN SIGN_DOCNUMET.DOC_STATUS = '2' THEN '成功' WHEN SIGN_DOCNUMET.DOC_STATUS = '3' THEN '失败' WHEN SIGN_DOCNUMET.DOC_STATUS = '1' THEN '代签' WHEN SIGN_DOCNUMET.DOC_STATUS = '6' THEN '正在盖章' END AS [DOC_STATUS],'请选择' as Remark FROM dbo.SIGN_DOCNUMET WHERE DOC_UNIQUE IN(SELECT MAX(DOC_UNIQUE) FROM dbo.SIGN_DOCNUMET WHERE DOC_DOCUMENTID LIKE '%@%' AND CREATE_TIME>='2018.05.01' GROUP BY SUBSTRING(DOC_DOCUMENTID,10,40)) AND SUBSTRING(DOC_DOCUMENTID,10,40)  NOT IN (SELECT [DOC_REAL_NAME] FROM SIGN_DOCNUMET_INSIG_INFO_Bak where CREATE_TIME>='2016.05.01'))";
            noQuery(insert_noname, SQLCON_Isignature);
        }



        //执行sql语句
        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        //获取SQL语句返回的datatable
        public DataTable GetDataInfo(string ConditionStr)
        {

            string sql = "SELECT TOP 200 [DOC_UNIQUE],[DOC_NAME],[DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],[STATUS],[USRNAME],[USRCODE],[Remark] FROM [MyDataBase].[dbo].[view_signinfoDetl] where 1=1  " + ConditionStr + " order by DOC_UNIQUE desc";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_Isignature);
            conn.Open();
            StringBuilder sql_huizhi = new StringBuilder();
            sql_huizhi.AppendFormat(sql);
            SqlDataAdapter ad = new SqlDataAdapter(sql_huizhi.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        //获取linq组合的datatble,用于绑定Gridvbiew作为数据源
        public DataTable GetUnionDt(string ConditionStr)
        {
            //DataTable dt = new DataTable();
            //SqlConnection conn = new SqlConnection(SQLCON_Isignature);
            //conn.Open();
            //StringBuilder sql_isign = new StringBuilder();
            //sql_isign.AppendFormat("SELECT [DOC_UNIQUE],[DOC_NAME],[DOC_REAL_NAME],[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],[STATUS],[USRNAME],[USRCODE],[Remark] FROM [MyDataBase].[dbo].[SIGN_DOCNUMET_INSIG_INFO_Bak] WHERE  DOC_UNIQUE!='' " + ConditionStr + " order by DOC_UNIQUE desc");
            //SqlDataAdapter ad = new SqlDataAdapter(sql_isign.ToString(), conn);
            //ad.Fill(dt);
            //conn.Close();

            //1. 新建DataTable并初始化连接表表结构  
            DataTable DtUnion = new DataTable();
            DtUnion.Columns.Add("DOC_UNIQUE");
            DtUnion.Columns.Add("DOC_NAME");
            DtUnion.Columns.Add("DOC_REAL_NAME");
            DtUnion.Columns.Add("FileNo");
            DtUnion.Columns.Add("DOC_TYPE");
            DtUnion.Columns.Add("DOC_STATUS");
            DtUnion.Columns.Add("CREATE_TIME");
            DtUnion.Columns.Add("ErrorMsg");
            DtUnion.Columns.Add("STATUS");
            DtUnion.Columns.Add("Remark");
            DtUnion.Columns.Add("DocumentName");
            DtUnion.Columns.Add("role");
            DtUnion.Columns.Add("person");
            DtUnion.Columns.Add("Discipline");
            DtUnion.Columns.Add("ApproveDate");

            //获取签章数据库文件信息
            string sqlstr1 = "SELECT [DOC_UNIQUE],[DOC_NAME],[DOC_REAL_NAME],left([DOC_REAL_NAME],charindex('.',[DOC_REAL_NAME])-2) as FileNo,[DOC_TYPE],[DOC_STATUS],[CREATE_TIME],[ErrorMsg],[STATUS],[Remark] FROM [MyDataBase].[dbo].[SIGN_DOCNUMET_INSIG_INFO_Bak] WHERE  DOC_UNIQUE!='' " + ConditionStr + " order by DOC_UNIQUE desc";
            string connstr1 = SQLCON_Isignature;
            DataTable dt1 = GetData(sqlstr1, connstr1);

            //获取中间库SPF文件签名信息
            string sqlstr2 = "SELECT [DocumentName],[role] ,[person] ,[Discipline],[ApproveDate] FROM [DWH].[dbo].[SPF_QZ_File_Signatureinfo] where role = '设计'";
            string connstr2 = SQLCON_DWH;
            DataTable dt2 = GetData(sqlstr2, connstr2);

            //2. 数据筛选并写入连接表   left join on
            var query = from rowLeft in dt1.AsEnumerable()
                        join rowRight in dt2.AsEnumerable() on rowLeft["FileNo"] equals rowRight["DocumentName"] into temp
                        from subRight in temp.DefaultIfEmpty()
                        select rowLeft.ItemArray.Concat((subRight == null) ? (dt2.NewRow().ItemArray) : subRight.ItemArray).ToArray();
            //3. 遍历，插入databale
            foreach (object[] values in query)
                DtUnion.Rows.Add(values);


            //4. 对datatable 多条件查询
            DataTable newdt = new DataTable();
            newdt = DtUnion.Clone();     //先建立新表    克隆DtUnion 的结构，包括所有 DtUnion 架构和约束,并无数据； 

            DataRow[] dr = DtUnion.Select("person like '%" + TextBox_USRNAME.Text.Trim() + "%'", "DOC_UNIQUE desc");     // 从DtUnion 中查询符合条件的记录； 

            for (int i = 0; i < dr.Length; i++)     // 将查询的结果添加到DtUnion中； 
            {
                newdt.ImportRow((DataRow)dr[i]);
            }

            return newdt;

        }

        //返回sql查询数据存入datatable
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

        protected void Button_Seach_Click(object sender, EventArgs e)
        {
            Init_SIGN_DOCNUMET_INSIG_INFO_Bak();
            //this.GridView_IsigResult.DataSource = GetUnionDt(ConditionStr);

            this.GridView_IsigResult.DataSource = GetDataInfo(ConditionStr);
            
            this.GridView_IsigResult.DataBind();
        }


        /********
         * GridView翻页
         ********/
        protected void GridView_IsigResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_IsigResult.PageIndex = e.NewPageIndex;
            //this.GridView_IsigResult.DataSource = GetUnionDt(ConditionStr);   //翻页获取的是DtUnion，不需要重复运算加载
            this.GridView_IsigResult.DataSource = GetDataInfo(ConditionStr);
            GridView_IsigResult.DataBind();
        }



        protected void GridView_IsigResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName.Trim();

            try
            {
                //获取选中行索引值
                GridViewRow gvr = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));

                //根据索引值获取某列的值
                string DOC_NAME = ((HyperLink)(GridView_IsigResult.Rows[gvr.RowIndex].Cells[1].Controls[0])).Text;   //列属性为HyperLink，获取值要麻烦些

                //string cc = GridView_IsigResult.Rows[gvr.RowIndex].Cells[3].Text;     //普通列获值
                string DOC_REAL_NAME = DOC_NAME.Substring(9);
                string FailReason = ((DropDownList)(GridView_IsigResult.Rows[gvr.RowIndex].FindControl("DropDownList_FailReason"))).SelectedValue;  //获取dropdownlist的值
                //如果点击重签执行以下操作
                if (cmd == "Resign")
                {
                    //加入文件名中含有@，代表是集成化过来图纸
                    if (DOC_NAME.Contains("@"))
                    {
                        if (FailReason.Equals("请选择"))
                        {
                            this.Response.Write("<script>alert('请选择重签原因,再进行重签操作！');</script>");
                            return;
                        }
                        //更新SPF中间表state值，进行重签操作
                        string updatesql = "UPDATE [DWH].[dbo].[SPF_QZ_File_Info] SET state=0 WHERE filename = '" + DOC_REAL_NAME + "'";
                        //this.Response.Write("<script>alert('" + DOC_REAL_NAME + "');</script>");
                        noQuery(updatesql, SQLCON_DWH);
                    }
                    else
                    {
                        string updatesql = "UPDATE [MyDataBase].[dbo].[SIGN_DOCNUMET] SET DOC_STATUS=1,ErrorMsg=null,WRITELOG='N' WHERE DOC_DOCUMENTID = '" + DOC_NAME + "'";
                        //this.Response.Write("<script>alert('" + DOC_REAL_NAME + "');</script>");
                        noQuery(updatesql, SQLCON_Isignature);
                    }
                }

            }
            catch (Exception ex)
            {
                //输出错误信息
                //this.Response.Write("<script>alert('重签失败');</script>");
                //return;
            }

            Init_SIGN_DOCNUMET_INSIG_INFO_Bak();    //页面数据绑定重新刷新

        }

        protected void GridView_IsigResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //列值不为"成功"的标记颜色
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (!drv.Row["Remark"].ToString().Trim().Equals("请选择"))
                {
                    e.Row.BackColor = System.Drawing.Color.Linen;
                }
                if (!drv.Row["STATUS"].ToString().Trim().Equals("成功"))
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }

        protected void DropDownList_FailReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)ddl.Parent.Parent;       //获取当前行
            string DOC_REAL_NAME = ((HyperLink)(GridView_IsigResult.Rows[gvr.RowIndex].Cells[2].Controls[0])).Text;   //列属性为HyperLink，获取该行的空间值，获取值要麻烦些
            string FailReason = ((DropDownList)(GridView_IsigResult.Rows[gvr.RowIndex].FindControl("DropDownList_FailReason"))).SelectedValue;  //获取dropdownlist的值
            //更新数据表的值（失败原因）
            string updatesql = "UPDATE [MyDataBase].[dbo].[SIGN_DOCNUMET_INSIG_INFO_Bak] SET Remark ='" + FailReason + "' WHERE [DOC_REAL_NAME] = '" + DOC_REAL_NAME + "'";
            //this.Response.Write("<script>alert('" + DOC_REAL_NAME + "');</script>");
            noQuery(updatesql, SQLCON_Isignature);
        }

    }
}