﻿using HNDrawingServicesAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.views
{
    public partial class HannaRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList_Function.Text.Trim().Equals("校验"))
                this.Grv_File.Columns[8].Visible = false;
            if (DropDownList_Function.Text.Trim().Equals("打印"))
                this.Grv_File.Columns[8].Visible = true;
            if (!IsPostBack)
            {
                //string sql = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client] FROM [HNDServer].[dbo].[FileCheckPool]   where Id in(  select max([Id]) FROM [HNDServer].[dbo].[FileCheckPool]  where [ORGFilePath] like '%FTP://10.151.131.53//DIS%' group by FileName) and [ORGFilePath] like '%FTP://10.151.131.53//DIS%'  order by LastUpdateDate desc";
                string sql = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client] FROM [HNDServer].[dbo].[FileCheckPool]   where Id in (  select max([Id]) FROM [HNDServer].[dbo].[FileCheckPool]  where [ORGFilePath] like '%FTP://10.151.131.53//DIS%' and charindex(' ',[FileName])>0 group by left([FileName],charindex(' ',[FileName])-1))and [ORGFilePath] like '%FTP://10.151.131.53//DIS%'  order by LastUpdateDate desc";
                Grid_Databinding(sql, SQLCON_Hanna);
            }
        }



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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string sql = GetConstr();
            Grid_Databinding(sql, SQLCON_Hanna);
        }


        //获取条件字符串
        public string GetConstr()
        {
            string ConditionStr = "";
            if (!DropDownList_Function.Text.Trim().Equals(""))
            {
                if (DropDownList_Function.Text.Trim().Equals("校验"))
                    //ConditionStr = "SELECT [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client]  FROM [HNDServer].[dbo].[FileCheckPool]   where Id in(  select max([Id]) FROM [HNDServer].[dbo].[FileCheckPool] where [ORGFilePath] like '%FTP://10.151.131.53%' group by FileName)  and [ORGFilePath] like '%FTP://10.151.131.53%' ";
                    ConditionStr = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client] FROM [HNDServer].[dbo].[FileCheckPool]   where Id in (select max([Id]) FROM [HNDServer].[dbo].[FileCheckPool]  where  charindex(' ',[FileName])>0 group by left([FileName],charindex(' ',[FileName])-1)) and  ORGFilePath!='' ";
                if (DropDownList_Function.Text.Trim().Equals("打印"))
                    ConditionStr = "SELECT [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[CreateDate] as UploadDate,[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client]  FROM [HNDServer].[dbo].[FilePlotPool] where  Id in(  select max([Id]) FROM [HNDServer].[dbo].[FilePlotPool]  group by FileName) and  ORGFilePath!=''  ";
            }
            //ConditionStr = "SELECT  [Id],[FileName],[FileExt],[FilePath],[ORGFilePath],[FileHash],[UploadDate],[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client]  FROM [HNDServer].[dbo].[FileCheckPool] where UploadDate>='2018.07.02' ";

            if (!TextBox_FileName.Text.Trim().Equals(""))
            {
                //获取$符号后面字符串
                ConditionStr += " and FileName like '%" + TextBox_FileName.Text.Trim() + "%'";
            }
            if (!TextBox_Remark.Text.Trim().Equals(""))
            {
                //获取$符号后面字符串
                ConditionStr += " and [Remark] like '%" + TextBox_Remark.Text.Trim() + "%'";
            }
            //下拉框值为文件类型选择
            if (!DropDownList_FileExt.Text.Trim().Equals("请选择"))
            {
                if (DropDownList_FileExt.Text.Trim().Equals("PDF"))
                    ConditionStr += " and [FileName] like '%PDF%'";
                if (DropDownList_FileExt.Text.Trim().Equals("WORD"))
                    ConditionStr += " and FileExt like '%DOC%'";
                if (DropDownList_FileExt.Text.Trim().Equals("EXCEL"))
                    ConditionStr += " and FileExt like '%XLS%'";
                if (DropDownList_FileExt.Text.Trim().Equals("DWG"))
                    ConditionStr += " and FileExt like '%DWG%'";
            }
            //下拉框值为文件处理状态
            if (!DropDownList_Status.Text.Trim().Equals("请选择"))
            {
                if (DropDownList_Status.Text.Trim().Equals("01 待处理"))
                    ConditionStr += " and [Status] like '%01%'";
                if (DropDownList_Status.Text.Trim().Equals("02 失败"))
                    ConditionStr += " and [Status] like '%02%'";
                if (DropDownList_Status.Text.Trim().Equals("03 成功"))
                    ConditionStr += " and [Status] like '%03%'";
                if (DropDownList_Status.Text.Trim().Equals("04 文件异常或处理超时"))
                    ConditionStr += " and [Status] like '%04%'";
                if (DropDownList_Status.Text.Trim().Equals("06 正在处理"))
                    ConditionStr += " and [Status] like '%06%'";
            }
            ConditionStr += " order by Id desc";
            return ConditionStr;
        }

        public void Grid_Databinding(string sql, string SQLCON)
        {
            DataTable Dtb = GetData(sql, SQLCON_Hanna);
            DataTable Dtb1 = GetData(sql, SQLCON_Hanna1);

            //两个表合并
            DataTable dtbCombine = Dtb.Copy();
            foreach (DataRow dr in Dtb1.Rows)
            {
                dtbCombine.ImportRow(dr);
            }

            //合并后的表排序
            DataView dv = dtbCombine.DefaultView;
            dv.Sort = "LastUpdateDate desc";
            DataTable dt2 = dv.ToTable();

            this.Grv_File.DataSource = dt2;
            this.Grv_File.DataBind();
        }

        protected void Grv_File_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grv_File.PageIndex = e.NewPageIndex;
            //this.GridView_IsigResult.DataSource = GetUnionDt(ConditionStr);   //翻页获取的是DtUnion，不需要重复运算加载
            string sql = GetConstr();
            Grid_Databinding(sql, SQLCON_Hanna);
        }

        protected void Grv_File_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //列值不为"成功"的标记颜色
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (!drv.Row["Status"].ToString().Trim().Equals("03"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightSalmon;
                }
            }
        }




        protected void Grv_File_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string cmd = e.CommandName.Trim();

                if (cmd == "ReBuild")
                {
                    //获取选中行索引值
                    GridViewRow gvr = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));

                    //根据索引值获取某列的值
                    string ID = Grv_File.Rows[gvr.RowIndex].Cells[0].Text;
                    string Client = Grv_File.Rows[gvr.RowIndex].Cells[6].Text;

                    string filepath = Grv_File.Rows[gvr.RowIndex].Cells[2].Text.Trim();
                    string filename = ((HyperLink)(Grv_File.Rows[gvr.RowIndex].Cells[1].Controls[0])).Text;  //列属性为HyperLink，取值方式不一样

                    string fileno = filename.Substring(0, filename.IndexOf("."));
                    string guid = Guid.NewGuid().ToString();

                    HNDrawingServicesAPI.HNDrawingSevices services = new HNDrawingSevices();

                    if (Client.Equals("HANNASERVER") || Client.Equals("HANNASERVER1") || Client.Equals("HANNASERVER2"))
                    {
                        services.SetServicesPath("http://10.151.129.88:8099/api/");
                        //PlotFileMessage plotfile = services.PlotFile(filepath, fileno, "", "", 1);
                        //string PlotString = Newtonsoft.Json.JsonConvert.SerializeObject(plotfile);
                        services.PlotFileAsync(filepath, fileno, "", "", 1, guid);
                    }
                    if (Client.Equals("HANNASERVER3") || Client.Equals("HANNASERVER4"))
                    {
                        services.SetServicesPath("http://10.151.129.91:8099/api/");
                        //PlotFileMessage plotfile = services.PlotFile(filepath, fileno, "", "", 1);
                        //string PlotString = Newtonsoft.Json.JsonConvert.SerializeObject(plotfile);
                        services.PlotFileAsync(filepath, fileno, "", "", 1, guid);
                    }
                    //更新SPF中间表state值，进行重签操作
                    //string updatesql = "UPDATE [dbo].[FilePlotPool] SET [Status]='01' WHERE ID = '" + ID + "'";
                    //noQuery(updatesql, SQLCON_Hanna);
                }
                if(cmd== "lkbtnClick")
                {
                    object[] arguments = e.CommandArgument.ToString().Split(',');
                    Response.Redirect("~/Views/HanaFileCKPLTRcd.aspx?FileName=" + arguments[0].ToString() + "&Client=" + arguments[1].ToString());
                }
            }
            catch { }
            string sql = GetConstr();
            Grid_Databinding(sql, SQLCON_Hanna);
        }

    }
}