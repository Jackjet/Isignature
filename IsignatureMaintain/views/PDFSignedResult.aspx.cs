﻿using HNDrawingServicesAPI;
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
    public partial class PDFSignedResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DtUnion = GetUnitb();
                Grid_Databinding(DtUnion);
            }
        }

        DataTable DtUnion = new DataTable();

        //获取组合的Datatable      汉纳打印表+CPMS中间库文件信息表
        public DataTable GetUnitb()
        {
            DataSet ds = new DataSet();
            //string sqlplt = "SELECT [Id],[FileName],left([FileName],charindex('.',[FileName])-1) as FileNo,[FileExt],[FilePath],[ORGFilePath],[FileHash],[CreateDate] as UploadDate,[Status],[LastUpdateDate],[UserId],[Remark],[PriorityLevel],[Client]  FROM [HNDServer].[dbo].[FilePlotPool] where  Id in(  select max([Id]) FROM [HNDServer].[dbo].[FilePlotPool] where [ORGFilePath] like '%FTP://10.151.131.53%'  group by FileName) and [CreateDate]>='2018.07.02' and [ORGFilePath] like '%FTP://10.151.131.53%' ";
            string sqlplt = "SELECT [Id],[FileName],left([FileName],charindex('.',[FileName])-1) as FileNo,[ORGFilePath],CONVERT(varchar(12) , [CreateDate], 111) as UploadDate,[Status],[LastUpdateDate],[Remark],[Client]  FROM [HNDServer].[dbo].[FilePlotPool] where  Id in(  select max([Id]) FROM [HNDServer].[dbo].[FilePlotPool] where [ORGFilePath] like '%FTP://10.151.131.53%'  group by FileName)  and [ORGFilePath] like '%FTP://10.151.131.53%' and [FileName] not like '%-F-%' ";
            DataTable HananPltDtb1 = GetData(sqlplt, SQLCON_Hanna);
            DataTable HananPltDtb2 = GetData(sqlplt, SQLCON_Hanna1);

            //两个表合并
            DataTable HananPltDtbCombine = HananPltDtb1.Copy();
            foreach (DataRow dr in HananPltDtb2.Rows)
            {
                HananPltDtbCombine.ImportRow(dr);
            }


            //string sqlmid = "SELECT  [common_id],[filesrc],[picnumber],[picname],[designer],[uploadtime],[special],[account],[projectnumber],[projectname],[pltannex] FROM [DWH].[dbo].[CPMS_sync_drawinginfo] where filesrc like '%DIS%' AND uploadtime>='2018.07.01'";
            string sqlmid = "SELECT  [picnumber],[picname],[designer],CONVERT(varchar(12) , [uploadtime], 111) as [uploadtime],[projectname],[pltannex] FROM [DWH].[dbo].[CPMS_sync_drawinginfo] where [filesrc]='DIS'";
            DataTable FileMidDtb = GetData(sqlmid, SQLCON_DWH);
            ds.Tables.Add(HananPltDtbCombine);
            ds.Tables.Add(FileMidDtb);

            //1. 新建DataTable并初始化连接表表结构  
            DtUnion.Clear();
            DtUnion.Columns.Add("Id");
            DtUnion.Columns.Add("FileName");
            DtUnion.Columns.Add("FileNo");
            DtUnion.Columns.Add("ORGFilePath");
            DtUnion.Columns.Add("UploadDate");
            DtUnion.Columns.Add("Status");
            DtUnion.Columns.Add("LastUpdateDate");
            DtUnion.Columns["LastUpdateDate"].DataType = typeof(DateTime);
            DtUnion.Columns.Add("Remark");
            DtUnion.Columns.Add("Client");
            DtUnion.Columns.Add("picnumber");
            DtUnion.Columns.Add("picname");
            DtUnion.Columns.Add("designer");
            DtUnion.Columns.Add("uploadtime");
            DtUnion.Columns.Add("projectname");
            DtUnion.Columns.Add("pltannex");

            //2. 数据筛选并写入连接表   left join on
            var query = from rowLeft in HananPltDtbCombine.AsEnumerable()
                        join rowRight in FileMidDtb.AsEnumerable() on rowLeft["FileNo"] equals rowRight["picnumber"] into temp
                        from subRight in temp.DefaultIfEmpty()
                        select rowLeft.ItemArray.Concat((subRight == null) ? (FileMidDtb.NewRow().ItemArray) : subRight.ItemArray).ToArray();
            //3. 遍历，插入databale
            foreach (object[] values in query)
                DtUnion.Rows.Add(values);

            //4.查询条件初始化 
            string ConditionStr = "";
            if (!TextBox_FileName.Text.Trim().Equals(""))
            {
                ConditionStr += " and FileName like '%" + TextBox_FileName.Text.Trim() + "%'";
            }
            //下拉框值为文件处理状态
            if (!DropDownList_IsWriten.Text.Trim().Equals("请选择"))
            {
                if (DropDownList_IsWriten.Text.Trim().Equals("已写入"))
                    ConditionStr += " and picnumber  is not null";
                if (DropDownList_IsWriten.Text.Trim().Equals("未写入"))
                    ConditionStr += " and picnumber is null";
                if (DropDownList_IsWriten.Text.Trim().Equals("日期不一致"))
                    ConditionStr += " and UploadDate>uploadtime and LastUpdateDate>='2019.08.24'";
            }
            //DataRow[] dr = DtUnion.Select("1=1" + ConditionStr, "Id desc");     // 从DtUnion 中查询符合条件的记录； 

            //5. 查询加排序 
            DataView dv = new DataView(DtUnion);
            dv.RowFilter = "1=1 " + ConditionStr;
            dv.Sort = "LastUpdateDate desc";

            DataTable dt = dv.ToTable();

            return dt;
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

        public void Grid_Databinding(DataTable dtb)
        {
            this.Grv1.DataSource = dtb;
            this.Grv1.DataBind();
        }

        #endregion



        //设置列的颜色
        protected void Grv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //列值不为"成功"的标记颜色
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (!drv.Row["STATUS"].ToString().Trim().Equals("03"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightSalmon;
                }
                if (drv.Row["uploadtime"].ToString().Trim().Equals(""))
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    DateTime pltdate = Convert.ToDateTime(drv.Row["UploadDate"].ToString().Trim());
                    //string end = drv.Row["uploadtime"].ToString().Trim();
                    DateTime enddate = Convert.ToDateTime(drv.Row["uploadtime"].ToString().Trim());
                    if (pltdate > enddate)
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }
                }

            }
        }

        //分页功能
        protected void Grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grv1.PageIndex = e.NewPageIndex;
            //DtUnion = GetUnitb();
            Grid_Databinding(DtUnion);
        }

        //搜索按钮功能
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            DtUnion = GetUnitb();
            Grid_Databinding(DtUnion);
        }

        protected void Grv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string cmd = e.CommandName.Trim();
                //获取选中行索引值
                GridViewRow gvr = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));

                //根据索引值获取某列的值
                string ID = Grv1.Rows[gvr.RowIndex].Cells[0].Text;    //列属性为HyperLink，获取值要麻烦些
                string Client = Grv1.Rows[gvr.RowIndex].Cells[7].Text;

                if (cmd == "ReBuild")
                {
                    string filepath = Grv1.Rows[gvr.RowIndex].Cells[3].Text.Trim();
                    string filename = ((HyperLink)(Grv1.Rows[gvr.RowIndex].Cells[1].Controls[0])).Text;  //列属性为HyperLink，取值方式不一样

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
            }
            catch { }
            DtUnion = GetUnitb();
            Grid_Databinding(DtUnion);
        }


    }
}