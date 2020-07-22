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
   public class SysAdminDAL
    {
        #region 列表

        public List<SysAdmin> GetList(string adminRole)
        {//adminId, adminName, adminPwd, adminRole, adminAddtime
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Sys_Admin where adminRole = {0}");
            string sql = String.Format(sb.ToString(), adminRole);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<SysAdmin> list = new List<SysAdmin>();
            while (dr.Read())
            {
                list.Add(new SysAdmin
                {
                    adminId = Convert.ToInt32(dr["adminId"]),
                    adminName = dr["adminName"].ToString(),
                    adminPwd = dr["adminPwd"].ToString(),
                    adminAddtime = Convert.ToDateTime(dr["adminAddtime"])
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 登录判断
        public SysAdmin Login(SysAdmin obj)
        {
            string sql = "select adminName from Sys_Admin where adminName= '{0}' and adminPwd = '{1}'";
            sql = string.Format(sql, obj.adminName, obj.adminPwd);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.adminName = dr["adminName"].ToString();
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

        #region 编辑 
        public int Edit(SysAdmin obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Sys_Admin set adminName='{0}',adminPwd='{1}' ");
            sqlBuilder.Append(" where adminId = '{2}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.adminName, obj.adminPwd, obj.adminId);
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
            string sql = "delete from Sys_Admin where AdminId = " + id + "";
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
        public int Add(SysAdmin obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Sys_Admin(adminName,adminPwd,adminAddtime) ");
            sb.Append("values('{0}','{1}','{2}')");
            string sql = string.Format(sb.ToString(), obj.adminName, obj.adminPwd, DateTime.Now);
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
