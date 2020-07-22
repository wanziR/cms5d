using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using System.Web;


namespace BLL
{
   public class SysAdminBLL
    {
        #region 列表

        public List<SysAdmin> GetList(string adminRole)
        {//adminId, adminName, adminPwd, adminRole, adminAddtime
          return new SysAdminDAL().GetList(adminRole);
        }

        #endregion

        #region 登录判断
        public SysAdmin Login(SysAdmin obj)
        {
            obj = new SysAdminDAL().Login(obj);
            if (obj != null)
            {
                //FormsAuthentication.SetAuthCookie(obj.adminName, true);
            }
            return obj;
        }
        #endregion

        #region 编辑 
        public int Edit(SysAdmin obj)
        {
          return new SysAdminDAL().Edit(obj);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
           return new SysAdminDAL().Del(id);
        }
        #endregion

        #region 添加
        public int Add(SysAdmin obj)
        {
         return new SysAdminDAL().Add(obj);
        }
        #endregion
    }
}
