using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
   public class UserInfoDAL
    {
        #region 列表

        public List<UserInfo> GetList()
        {//User_Info=> userId, userName, userPwd, userNickname, userImg, userPhone, userAge, userSex, userEdu, userEmail, userAddtime
            string sql = "select * from User_Info";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<UserInfo> list = new List<UserInfo>();
          
            while (dr.Read())
            {
                list.Add(new UserInfo
                {
                    userId = Convert.ToInt32(dr["userId"]),
                    //userAge = Convert.ToInt32(dr["userAge"]),
                    userName = dr["userName"].ToString(),
                    userPwd = dr["userPwd"].ToString(),
                    userNickname = dr["userNickname"].ToString(),
                    userImg = dr["userImg"].ToString(),
                    userPhone = dr["userPhone"].ToString(),
                    userSex = dr["userSex"].ToString(),
                    userEdu = dr["userEdu"].ToString(),
                    userEmail = dr["userEmail"].ToString(),
                    userAddtime = Convert.ToDateTime(dr["userAddtime"])
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 编辑 
        public int Edit(UserInfo obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update User_Info set userName='{0}',userNickname='{1}', userImg='{2}', userPhone='{3}', userAge='{4}', userSex='{5}', userEdu='{6}', userEmail='{7}', userAddtime='{8}',UserPwd='{9}' ");
            sb.Append(" where userId = '{10}'");
            string sql = string.Format(sb.ToString(), obj.userName, obj.userNickname, obj.userImg, obj.userPhone, obj.userAge, obj.userSex, obj.userEdu, obj.userEmail,DateTime.Now,obj.userPwd,obj.userId);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            string sql = "delete from User_Info where userId = " + id + "";
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加
        public int Add(UserInfo obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into User_Info(userName, userNickname, userImg, userPhone, userAge, userSex, userEdu, userEmail, userAddtime,userPwd) ");
            sb.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')");
            string sql = string.Format(sb.ToString(), obj.userName, obj.userNickname, obj.userImg, obj.userPhone, obj.userAge, obj.userSex, obj.userEdu, obj.userEmail, DateTime.Now,obj.userPwd);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion

        #region 用户名存在判断
        public UserInfo UserIn(UserInfo obj)
        {
            string sql = "select userName from User_Info where userName= '{0}'";
            sql = string.Format(sql, obj.userName);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userName = dr["userName"].ToString();
                    dr.Close();
                }
                else
                {
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("应用程序数据库连接出现问题" + ex.Message);
            }
            return obj;


        }
        #endregion

        #region 管理员登录判断
        public UserInfo AdminLogin(UserInfo obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select *, ");
            sb.Append("(select roleId from User_Role where userId=User_Info.userId) as roleId,");
            sb.Append("(select roleName from Roles where roleId = (select roleId from User_Role where userId=User_Info.userId)) as roleName ");
            sb.Append(" from User_Info ");
            sb.Append("where userName= '{0}' and userPwd = '{1}' ");
            sb.Append(" and (select roleId from User_Role where userId=User_Info.userId) = {2}");
            string sql = String.Format(sb.ToString(), obj.userName,obj.userPwd,obj.roleId);
            sql = string.Format(sql, obj.userName, obj.userPwd);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userName = dr["userName"].ToString();
                    dr.Close();
                }
                else
                {
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("应用程序数据库连接出现问题" + ex.Message);
            }
            return obj;


        }
        #endregion

        #region 用户登录判断
        public UserInfo Login(UserInfo obj)
        {
            string sql = "select userName from User_Info where userName= '{0}' and userPwd = '{1}'";
            sql = string.Format(sql, obj.userName, obj.userPwd);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userName = dr["userName"].ToString();
                    dr.Close();
                }
                else
                {
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("应用程序数据库连接出现问题" + ex.Message);
            }
            return obj;


        }
        #endregion

        #region 忘记密码 
        public int EditPwd(UserInfo obj)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update User_Info set userPwd='{0}' ");
            sb.Append(" where userName = '{1}'");
            string sql = string.Format(sb.ToString(), obj.userPwd, obj.userName);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion

    }
}
