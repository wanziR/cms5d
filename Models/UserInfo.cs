using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
   public class UserInfo
    {
        //User_Info=> userId, userName, UserPwd, userNickname, userImg, userPhone, userAge, userSex, userEdu, userEmail, userAddtime
        public int userId { set; get; }
        public int userAge { set; get; }
        public string userName { set; get; }
        public string userPwd { set; get; }
        public string userNickname { set; get; }
        public string userImg { set; get; }
        public string userPhone { set; get; }
        public string userEdu { set; get; }
        public string userSex { set; get; }
        public string userEmail { set; get; }
        public DateTime userAddtime { set; get; }

        //Sms_Code=>Id, Code, TelPhone, Sendtime, Validtime
        public int Id { set; get; }
        public int Code { set; get; }
        public string TelPhone { set; get; }
        public DateTime Sendtime { set; get; }
        public DateTime Validtime { set; get; }

        //Roles=>roleId,roleName
        public int roleId { set; get; }
        public string roleName { set; get; }


    }
}
