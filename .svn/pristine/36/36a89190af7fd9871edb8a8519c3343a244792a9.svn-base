using IsignatureMaintain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.TestPage
{
    public partial class FTPTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string bb = "/huizhi/1348/电气/1348-D-00670-EE-DW017-0002A$4376553.tif";
            string ftpServerIP = "10.151.131.53";
            string ftpRemotePath = "";
            string ftpUserID = "CPMSPowerOn";
            string ftpURI = "Cpms20150610";
            FtpWeb Fw = new FtpWeb(ftpServerIP, ftpRemotePath, ftpUserID, ftpURI);

            string filePath = "D:\\";
            string fileName = bb.Substring(bb.LastIndexOf(@"/") + 1, bb.Length - bb.LastIndexOf(@"/") - 1);
            string ftpaddress = Fw.ftpURI + bb.Substring(0, bb.LastIndexOf(@"/"));
            //Fw.Download(filePath, fileName, ftpaddress);
            //dd();
        }

        //http下载
        public void dd()
        {
            string fileName = "aaa.txt";//客户端保存的文件名
            string filePath = Server.MapPath("\\");//路径
            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string bb = "/huizhi/0531/容器及换热器/0531-D-2200-EQ-LS020-2001A$4376885.xls";
            string ftpServerIP = "10.151.131.53";
            string ftpRemotePath = "";
            string ftpUserID = "CPMSPowerOn";
            string ftpURI = "Cpms20150610";
            FtpWeb Fw = new FtpWeb(ftpServerIP, ftpRemotePath, ftpUserID, ftpURI);

            string filePath = "D:";
            string fileName = bb.Substring(bb.LastIndexOf(@"/") + 1, bb.Length - bb.LastIndexOf(@"/") - 1);
            string ftpaddress = Fw.ftpURI + bb;
            Fw.Download(filePath, fileName, ftpaddress);
        }

    }
}



