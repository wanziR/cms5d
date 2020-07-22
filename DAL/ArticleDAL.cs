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
   public class ArticleDAL
    {
        #region 列表

        public List<Article> GetList()
        {//--artId, artName, artImg, artContent, acId, artAuthor, artPV, artAddtime, artIsTuiJian, artIsReMen, artIsZhiDing, artType, artLink
            StringBuilder sb = new StringBuilder();
            sb.Append("select *,");
            sb.Append("(select acName from Article_Column where acId = Article.acId) as acName,");
            sb.Append("(select acPid from Article_Column where acId = Article.acId) as acPid,");
            sb.Append("(select acName from Article_Column where acId=(select acPid from Article_Column where acId =Article.acId)) as acPName ");
            sb.Append("from Article ");
            sb.Append("order by artAddtime desc");
            string sql = String.Format(sb.ToString());
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    artId = Convert.ToInt32(dr["artId"]),
                    acId = Convert.ToInt32(dr["acId"]),
                    artIsTuiJian = Convert.ToInt32(dr["artIsTuiJian"]),
                    artIsReMen = Convert.ToInt32(dr["artIsReMen"]),
                    artIsZhiDing = Convert.ToInt32(dr["artIsZhiDing"]),
                    artName = dr["artName"].ToString(),
                    artContent = dr["artContent"].ToString(),
                    artImg = dr["artImg"].ToString(),
                    artAuthor = dr["artAuthor"].ToString(),
                    artPV = dr["artPV"].ToString(),
                    artLink = dr["artLink"].ToString(),
                    artType = dr["artType"].ToString(),
                    artAddtime = Convert.ToDateTime(dr["artAddtime"]),
                    acPid = Convert.ToInt32(dr["artId"]),
                    acName = dr["acName"].ToString(),
                    acPName = dr["acPName"].ToString()
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 列表根据栏目ID

        public List<Article> GetListByAcid(string acId)
        {//--artId, artName, artImg, artContent, acId, artAuthor, artPV, artAddtime, artIsTuiJian, artIsReMen, artIsZhiDing, artType, artLink
            StringBuilder sb = new StringBuilder();
            sb.Append("select *,");
            sb.Append("(select acName from Article_Column where acId = Article.acId) as acName,");
            sb.Append("(select acPid from Article_Column where acId = Article.acId) as acPid,");
            sb.Append("(select acName from Article_Column where acId=(select acPid from Article_Column where acId =Article.acId)) as acPName ");
            sb.Append("from Article ");
            sb.Append("where acId ={0} ");
            sb.Append("order by artAddtime desc");
            string sql = String.Format(sb.ToString(),acId);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    artId = Convert.ToInt32(dr["artId"]),
                    acId = Convert.ToInt32(dr["acId"]),
                    artIsTuiJian = Convert.ToInt32(dr["artIsTuiJian"]),
                    artIsReMen = Convert.ToInt32(dr["artIsReMen"]),
                    artIsZhiDing = Convert.ToInt32(dr["artIsZhiDing"]),
                    artName = dr["artName"].ToString(),
                    artContent = dr["artContent"].ToString(),
                    artImg = dr["artImg"].ToString(),
                    artAuthor = dr["artAuthor"].ToString(),
                    artPV = dr["artPV"].ToString(),
                    artLink = dr["artLink"].ToString(),
                    artType = dr["artType"].ToString(),
                    artAddtime = Convert.ToDateTime(dr["artAddtime"]),
                    acPid = Convert.ToInt32(dr["artId"]),
                    acName = dr["acName"].ToString(),
                    acPName = dr["acPName"].ToString()
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 列表根据栏目父ID

        public List<Article> GetListByAcPId(string acPid)
        {//--artId, artName, artImg, artContent, acId, artAuthor, artPV, artAddtime, artIsTuiJian, artIsReMen, artIsZhiDing, artType, artLink
            StringBuilder sb = new StringBuilder();
            sb.Append("select *,");
            sb.Append("(select acName from Article_Column where acId = Article.acId) as acName,");
            sb.Append("(select acPid from Article_Column where acId = Article.acId) as acPid,");
            sb.Append("(select acName from Article_Column where acId=(select acPid from Article_Column where acId =Article.acId)) as acPName ");
            sb.Append("from Article ");
            sb.Append("where (select acPid from Article_Column where acName = (select acName from Article_Column where acId = Article.acId)) ={0} ");
            sb.Append("order by artAddtime desc");
            string sql = String.Format(sb.ToString(), acPid);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    artId = Convert.ToInt32(dr["artId"]),
                    acId = Convert.ToInt32(dr["acId"]),
                    artIsTuiJian = Convert.ToInt32(dr["artIsTuiJian"]),
                    artIsReMen = Convert.ToInt32(dr["artIsReMen"]),
                    artIsZhiDing = Convert.ToInt32(dr["artIsZhiDing"]),
                    artName = dr["artName"].ToString(),
                    artContent = dr["artContent"].ToString(),
                    artImg = dr["artImg"].ToString(),
                    artAuthor = dr["artAuthor"].ToString(),
                    artPV = dr["artPV"].ToString(),
                    artLink = dr["artLink"].ToString(),
                    artType = dr["artType"].ToString(),
                    artAddtime = Convert.ToDateTime(dr["artAddtime"]),
                    acPid = Convert.ToInt32(dr["artId"]),
                    acName = dr["acName"].ToString(),
                    acPName = dr["acPName"].ToString()
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 编辑 
        public int Edit(Article obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Article set artName='{0}', artImg='{1}', artContent='{2}', acId={3}, artAuthor='{4}', artAddtime='{5}', artIsTuiJian={6}, artIsReMen={7}, artIsZhiDing={8}, artType='{9}', artLink='{10}'");
            sqlBuilder.Append(" where artId = '{11}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.artName, obj.artImg, obj.artContent, obj.acId, obj.artAuthor, DateTime.Now, obj.artIsTuiJian, obj.artIsReMen, obj.artIsZhiDing, obj.artType, obj.artLink,obj.artId);
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
            string sql = "delete from Article where artId = " + id + "";
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
        public int Add(Article obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Article(artName,artImg, artContent, acId, artAuthor,artAddtime,artIsZhiDing) ");
            sb.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')");
            string sql = string.Format(sb.ToString(), obj.artName, obj.artImg, obj.artContent, obj.acId, obj.artAuthor, DateTime.Now, obj.artIsZhiDing);
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

        #region 栏目列表根据父ID

        public List<Article> GetCListByPid(string pId)
        {//--acId, acName, acImg, acPid, acOrder
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Article_Column where acPid = "+pId+"");
            string sql = String.Format(sb.ToString());
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    acId = Convert.ToInt32(dr["acId"]),
                    acPid = Convert.ToInt32(dr["acPid"]),
                    acOrder = Convert.ToInt32(dr["acOrder"]),
                    acName = dr["acName"].ToString(),
                    acImg = dr["acImg"].ToString(),
                    
                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 栏目列表根据父名称

        public List<Article> GetCListByPName(string pName)
        {//--acId, acName, acImg, acPid, acOrder
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Article_Column where acPid =(select acId from Article_Column where acName ='{0}')");
            string sql = String.Format(sb.ToString(), pName);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    acId = Convert.ToInt32(dr["acId"]),
                    acPid = Convert.ToInt32(dr["acPid"]),
                    acOrder = Convert.ToInt32(dr["acOrder"]),
                    acName = dr["acName"].ToString(),
                    acImg = dr["acImg"].ToString(),

                });
            }
            dr.Close();
            return list;
        }

        #endregion

        #region 栏目编辑 
        public int CEdit(Article obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Article_Column set acName='{0}', acImg='{1}', acPid={2}, acOrder={3}");
            sqlBuilder.Append(" where acId = '{4}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.acName, obj.acImg, obj.acPid, obj.acOrder, obj.acId);
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

        #region 栏目删除
        public int CDel(string id)
        {
            string sql = "delete from Article_Column where acId = " + id + "";
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

        #region 栏目添加
        public int CAdd(Article obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Article_Column(acName, acImg, acPid, acOrder) ");
            sb.Append("values('{0}','{1}','{2}','{3}')");
            string sql = string.Format(sb.ToString(), obj.acName, obj.acImg, obj.acPid, obj.acOrder);
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

        #region 栏目名根据栏目Id

        public string GetAcNameByAcId(string acId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select acName from Article_Column where acId={0}");
            string sql = String.Format(sb.ToString(), acId);
            string acPName = SQLHelper.SingleResult(sql).ToString();
            return acPName;
        }

        #endregion

        #region 取父栏目名根据子栏目ID

        public string GetAcPNameByAcId(string acId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select acName from Article_Column where acId=(select acPid from Article_Column where acId ={0})");
            string sql = String.Format(sb.ToString(),acId);
            string acPName = SQLHelper.SingleResult(sql).ToString();
            return acPName;
        }

        #endregion
    }
}
