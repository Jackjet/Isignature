using System;
using System.Web;

namespace IsignatureMaintain.Class
{
    class IsignatureRecord
    {
        public String DOC_UNIQUE { get; set; }
        public String DOC_NAME { get; set; }
        public String DOC_REAL_NAME { get; set; }
        public String DOC_TYPE { get; set; }
        public String DOC_STATUS { get; set; }
        public String CREATE_TIME { get; set; }
        public String ErrorMsg { get; set; }
        public String USR_CODE { get; set; }
        public String USR_NAME { get; set; }
    }
}
