using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
   public class SysAdmin
    {
        //Sys_Admin=>adminId, adminName, adminPwd, adminRole, adminAddtime
        public int adminId { set; get; }
        public string adminName { set; get; }
        public string adminPwd { set; get; }
        public DateTime adminAddtime { set; get; }

    }
}
