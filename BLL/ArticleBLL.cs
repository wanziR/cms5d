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
   public class ArticleBLL
    {
        #region 列表

        public List<Article> GetList()
        {
          return new ArticleDAL().GetList();
        }

        #endregion

        #region 列表根据栏目ID

        public List<Article> GetListByAcid(string acId)
        {
            return new ArticleDAL().GetListByAcid(acId);
        }

        #endregion

        #region 列表根据栏目父ID

        public List<Article> GetListByAcPId(string acPid)
        { 
            return new ArticleDAL().GetListByAcPId(acPid);
        }

        #endregion

        #region 编辑 
        public int Edit(Article obj)
        {
          return new ArticleDAL().Edit(obj);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
           return new ArticleDAL().Del(id);
        }
        #endregion

        #region 添加
        public int Add(Article obj)
        {
         return new ArticleDAL().Add(obj);
        }
        #endregion

        #region  栏目列表根据父ID

        public List<Article> GetCListByPid(string pId)
        {
            return new ArticleDAL().GetCListByPid(pId);
        }

        #endregion

        #region 栏目列表根据父名称

        public List<Article> GetCListByPName(string pName)
        {
            return new ArticleDAL().GetCListByPName(pName);
        }

        #endregion

        #region 栏目编辑 
        public int CEdit(Article obj)
        {
            return new ArticleDAL().CEdit(obj);
        }
        #endregion

        #region 栏目删除
        public int CDel(string id)
        {
            return new ArticleDAL().CDel(id);
        }
        #endregion

        #region 栏目添加
        public int CAdd(Article obj)
        {
            return new ArticleDAL().CAdd(obj);
        }
        #endregion

        #region 栏目名根据栏目ID

        public string GetAcNameByAcId(string acId)
        {
           return new ArticleDAL().GetAcNameByAcId(acId);
        }

        #endregion

        #region 取父栏目名根据子栏目ID

        public string GetAcPNameByAcId(string acId)
        {
            return new ArticleDAL().GetAcPNameByAcId(acId);
        }

        #endregion
    }
}
