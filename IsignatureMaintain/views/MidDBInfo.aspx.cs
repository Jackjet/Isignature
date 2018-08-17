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
    public partial class MidDBInfo : System.Web.UI.Page
    {
        #region  参数定义
        //定义图号
        public string DocumentName = "";

        //定义文件名
        public string filename = "";

        /*数据库连接字符创*/
        string SQLCON_Isignature = ConfigurationManager.ConnectionStrings["SQLCON_Isignature"].ToString();
        string SQLCON_DWH = ConfigurationManager.ConnectionStrings["SQLCON_DWH"].ToString();
        string SQLCON_COPT6 = ConfigurationManager.ConnectionStrings["SQLCON_COPT6"].ToString();
        string SQLCON_Huizhi = ConfigurationManager.ConnectionStrings["SQLCON_Huizhi"].ToString();
        #endregion

        #region  数据库操作方法
        public void noQuery(string sql, string SQLCON)
        {
            SqlConnection conn = new SqlConnection(SQLCON);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /*SQL数据查询，返回datatable*/
        public DataTable GetData(string selctsql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLCON_DWH);
            conn.Open();
            StringBuilder sql_dwh = new StringBuilder();
            sql_dwh.AppendFormat(selctsql);
            SqlDataAdapter ad = new SqlDataAdapter(sql_dwh.ToString(), conn);
            ad.Fill(dt);
            conn.Close();
            return dt;
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            string FullName = "";
            try {
                FullName = Request.QueryString["FileName"].ToString();    //获取传递的参数值
                this.FileName_TextBox.Text = FullName;                    //将参数值写入textbox
                this.FileName_TextBox.Enabled = false;                    //textbox不可写
            }
            catch { }
            //获取文件名
            try
            {
                //FullName = this.FileName_TextBox.Text.Trim().ToString().Trim();
                //int Head_Pos = FullName.IndexOf("$");      //获取第一个$的坐标
                //int End_Pos = FullName.IndexOf(".") - 2;     //获取"."的坐标
                //int length = End_Pos - Head_Pos;           //获取截取字符串的长度
                //DocumentName = FullName.Substring(Head_Pos + 1, length).ToString();  //图号
                //filename = FullName.Substring(Head_Pos + 1);     //图号+文件格式
                FullName = this.FileName_TextBox.Text; 
                DocumentName = FullName.Substring(0, FullName.IndexOf("."));
                filename = FullName;
            }
            catch (Exception ex)
            {
                //this.Response.Write("<script>alert('文件名格式有误');</script>");
                return;
            }
            if (this.IsPostBack)
                return;
            DataBound_CPMS_SPF(DocumentName, filename);   //显示各中间库信息

        }

        protected void Seach_Click(object sender, EventArgs e)
        {

            DataBound_CPMS_SPF(DocumentName, filename);
        }

        //依据图号、文件名获取该文件在DWH中间库中信息
        public void DataBound_CPMS_SPF(string DocumentName, string filename)
        {
            if (DocumentName.Equals("") || filename.Equals(""))  //如果DocumentName,filename为空，则不查询显示数据库信息
                return;
            //根据文件名获取该文件在SPF_QZ_File_Signatureinfo中信息
            //string Selectsql_SPF_QZ_File_Signatureinfo = "SELECT [DocumentName],[role],[person],[Discipline],[ApproveDate] FROM [DWH].[dbo].[SPF_QZ_File_Signatureinfo] WHERE DocumentName like '%" + DocumentName + "%'";
            //this.GridView_SPF_QZ_File_Signatureinfo.DataSource = GetData(Selectsql_SPF_QZ_File_Signatureinfo);
            //this.GridView_SPF_QZ_File_Signatureinfo.DataBind();

            ////根据文件名获取该文件在SPF_QZ_File_Info中信息
            ////string Selectsql_SPF_QZ_File_Info = "SELECT common_id,filename,fileroute,PrintstyleName,state,PageCount,ZA1count,fileroute,result FROM [DWH].[dbo].[SPF_QZ_File_Info] WHERE filename like '%" + filename + "%'";
            //string Selectsql_SPF_QZ_File_Info = "SELECT a.common_id,a.filename,b.[picName],b.[PrjName],a.fileroute,a.PrintstyleName,a.state,a.PageCount,a.ZA1count,a.fileroute,a.result FROM [DWH].[dbo].[SPF_QZ_File_Info] a, [DWH].[dbo].[SPF_QZ_Document_Info] b where a.DocumentName = b.DocumentName and a.filename like '%" + filename + "%'";
            //this.GridView_SPF_QZ_File_Info.DataSource = GetData(Selectsql_SPF_QZ_File_Info);
            //this.GridView_SPF_QZ_File_Info.DataBind();

            //根据文件名获取该文件在CPMS_sync_drawinginfo中信息
            string Selectsql_CPMS_sync_drawinginfo = "SELECT common_id,[filesrc],picnumber,picname,designer,account,uploadtime,annex,picturename,special,specnumber,piccount,a1,projectname,pltannex,printstylename,printfilename,diye,gongye,miji,case when SelectStatus = '0' and state = '0' then '可重签' else '重签无效' end as states FROM [DWH].[dbo].[CPMS_sync_drawinginfo] WHERE [picnumber] like '%" + DocumentName + "%'";
            this.GridView_CPMS_sync_drawinginfo.DataSource = GetData(Selectsql_CPMS_sync_drawinginfo);
            this.GridView_CPMS_sync_drawinginfo.DataBind();

            //根据文件名获取该文件在CPMS_sync_fileinfo中信息
            string Selectsql_CPMS_sync_fileinfo = @"SELECT [common_id],[filesrc],[fileuid],[filename],'file://10.151.131.53/FTPhztocpms'+[ftpaddress] AS [ftpaddress],[fileext] FROM [DWH].[dbo].[CPMS_sync_fileinfo] WHERE ftpaddress like '%" + DocumentName + "%' order by fileuid desc";
            this.GridView_CPMS_sync_fileinfo.DataSource = GetData(Selectsql_CPMS_sync_fileinfo);
            this.GridView_CPMS_sync_fileinfo.DataBind();
        }

          
        //#region   GridView_SPF_QZ_File_Info进行更新操作
        //protected void GridView_SPF_QZ_File_Info_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView_SPF_QZ_File_Info.EditIndex = e.NewEditIndex; ;
        //    DataBound_CPMS_SPF(DocumentName, filename);
        //}

        //protected void GridView_SPF_QZ_File_Info_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView_SPF_QZ_File_Info.EditIndex = -1;
        //    DataBound_CPMS_SPF(DocumentName, filename);
        //}

        //protected void GridView_SPF_QZ_File_Info_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    //获取账户，姓名，common_id
        //    string State = ((TextBox)(GridView_SPF_QZ_File_Info.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        //    string PageCount = ((TextBox)(GridView_SPF_QZ_File_Info.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();    //第一列注意这种写法很重要
        //    string ZA1count = ((TextBox)(GridView_SPF_QZ_File_Info.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
        //    string Result = ((TextBox)(GridView_SPF_QZ_File_Info.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();

        //    string common_id = GridView_SPF_QZ_File_Info.DataKeys[e.RowIndex].Value.ToString();
        //    string updateStr = "update [DWH].[dbo].[SPF_QZ_File_Info] set State='" + State + "',PageCount='" + PageCount + "',ZA1count='" + ZA1count + "',Result='" + Result + "' where common_id='" + common_id + "'";

        //    noQuery(updateStr, SQLCON_DWH);
        //    this.Response.Write("<script>alert('SPF_QZ_File_Info表信息更新成功！');</script>");
        //    GridView_SPF_QZ_File_Info.EditIndex = -1;
        //    DataBound_CPMS_SPF(DocumentName, filename);
        //}
        //#endregion   //对GridView_SPF_QZ_File_Info进行更新操作



        #region  GridView_CPMS_sync_drawinginfo进行更新操作
        protected void GridView_CPMS_sync_drawinginfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_CPMS_sync_drawinginfo.EditIndex = -1;
            DataBound_CPMS_SPF(DocumentName, filename);
        }

        protected void GridView_CPMS_sync_drawinginfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_CPMS_sync_drawinginfo.EditIndex = e.NewEditIndex; ;
            DataBound_CPMS_SPF(DocumentName, filename);
        }

        protected void GridView_CPMS_sync_drawinginfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取账户，姓名，common_id
            string Picname = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string Annex = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();    //第一列注意这种写法很重要
            Double Piccount = Convert.ToDouble(((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim());
            Double A1 = Convert.ToDouble(((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim());
            string Pltannex = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
            string Diye = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[12].Controls[0])).Text.ToString().Trim();
            string Gongye = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[13].Controls[0])).Text.ToString().Trim();
            string Miji = ((TextBox)(GridView_CPMS_sync_drawinginfo.Rows[e.RowIndex].Cells[14].Controls[0])).Text.ToString().Trim();
            int common_id = Convert.ToInt32(GridView_CPMS_sync_drawinginfo.DataKeys[e.RowIndex].Value.ToString());
            string updateStr = "update [DWH].[dbo].[CPMS_sync_drawinginfo] set Picname='" + Picname + "',Annex='" + Annex + "',Piccount='" + Piccount + "',A1='" + A1 + "',Pltannex='" + Pltannex + "',Diye='" + Diye + "',Gongye='" + Gongye + "',Miji='" + Miji + "' where common_id='" + common_id + "'";

            noQuery(updateStr, SQLCON_DWH);
            this.Response.Write("<script>alert('CPMS_sync_drawinginfo表信息更新成功！');</script>");
            GridView_CPMS_sync_drawinginfo.EditIndex = -1;
            DataBound_CPMS_SPF(DocumentName, filename);
        }
        #endregion

        protected void GridView_CPMS_sync_fileinfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = -1; i < GridView_CPMS_sync_fileinfo.Rows.Count; i++)
                //用FindControl方法找到模板中的HyperLink控件，对其赋值，并初始化超链接地址
                {
                    HyperLink HyperLink_address = (HyperLink)e.Row.FindControl("HyperLink_address");
                    HyperLink_address.NavigateUrl = HyperLink_address.Text.ToString().Trim();

                }
            }
        }


   




    }
}