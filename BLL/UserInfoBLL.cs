using DAL;
using Models;
using System.Collections.Generic;


namespace BLL
{
    public class UserInfoBLL
    {
        #region 列表

        public List<UserInfo> GetList()
        {
            return new UserInfoDAL().GetList();
        }

        #endregion

        #region 编辑 
        public int Edit(UserInfo obj)
        {
            return new UserInfoDAL().Edit(obj);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            return new UserInfoDAL().Del(id);
        }
        #endregion

        #region 添加
        public int Add(UserInfo obj)
        {
            return new UserInfoDAL().Add(obj);
        }
        #endregion

       
        #region 用户名存在判断
        public UserInfo UserIn(UserInfo obj)
        {
           return new UserInfoDAL().UserIn(obj);
        }
        #endregion

        #region 管理员登录判断
        public UserInfo AdminLogin(UserInfo obj)
        {
            return new UserInfoDAL().AdminLogin(obj);
        }
        #endregion

        #region 用户登录判断
        public UserInfo Login(UserInfo obj)
        {
            return new UserInfoDAL().Login(obj);
        }
        #endregion

        #region 忘记密码 
        public int EditPwd(UserInfo obj)
        {
            return new UserInfoDAL().EditPwd(obj);
        }
        #endregion


    }
}
