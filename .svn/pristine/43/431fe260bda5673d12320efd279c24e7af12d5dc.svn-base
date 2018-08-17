using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IsignatureMaintain.Models
{
    public class FtpWeb
    {
        public String ftpServerIP { get; set; }
        public String ftpRemotePath { get; set; }
        public String ftpUserID { get; set; }
        public String ftpPassword { get; set; }
        public String ftpURI { get; set; }

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public FtpWeb(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = "ftp://" + ftpServerIP + ftpRemotePath + "/";
        }


        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public void Download(string filePath, string fileName, string ftpaddress)
        {
            FtpWebRequest reqFTP;
            //try
            //{
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);    //下载目录
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpaddress));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.ContentType = "application/octet-stream";
                response.Close();               
            //}
            //catch (Exception ex)
            //{
            //    wLog(ex.ToString());
            //}
        }


        private void wLog(string s)
        {
            //写入文件
            FileStream fsapp = new FileStream(@"C:\CodeLog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsapp);
            sw.WriteLine(s);
            sw.Close();
            fsapp.Close();
        }

    }
}