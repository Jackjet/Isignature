using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsignatureMaintain
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((object)(Request.Cookies["LoginUsr"]) == null)
            //    Response.Redirect("~/views/Login.aspx");
        }
    }
}