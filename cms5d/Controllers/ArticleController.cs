using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using X.PagedList;

namespace cms5d.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        #region 列表

        public ActionResult List(int page = 1)
        {
            List<Article> list = new ArticleBLL().GetList();
            var plist = list.ToPagedList(page, 1);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region 编辑
        [ValidateInput(false)]
        public ActionResult GetEdit(Article obj,string acId)
        {
            obj = new Article()
            {
                acId = obj.acId,
                artId = obj.artId,
                artName = obj.artName,
                artPV = obj.artPV,
                artAuthor = obj.artAuthor,
                artAddtime = Convert.ToDateTime(DateTime.Now),
                artIsZhiDing = obj.artIsZhiDing,
                artContent = obj.artContent,
                artImg = obj.artImg
            };
            int result = new ArticleBLL().Edit(obj);
            return RedirectToAction("ArticleList", "Admin",new{acId=acId});
        }
        #endregion

        #region 删除

        public ActionResult Del(string id)
        {
            int result = new ArticleBLL().Del(id);

            if (result == 1)
            {
                return this.Content("删除成功！");
            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 添加
        public ActionResult GetAdd(Article obj)
        {
            //var isIndex = obj.isIndex != null ? true : false;

                obj = new Article
                {
                    acId = obj.acId,
                    artId = obj.artId,
                    artName = obj.artName,
                    artPV = obj.artPV,
                    artAuthor = obj.artAuthor,
                    artAddtime = Convert.ToDateTime(DateTime.Now),
                    artIsZhiDing = obj.artIsZhiDing,
                    artContent = obj.artContent,
                    artImg = obj.artImg
                };
                int result = new ArticleBLL().Add(obj);
                return RedirectToAction("ArticleList", "Admin");

        }
        #endregion

        #region 栏目列表

        public ActionResult CList(string pid,int page = 1)
        {
            List<Article> list = new ArticleBLL().GetCListByPid(pid);
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region 栏目编辑
        [ValidateInput(false)]
        public ActionResult GetCEdit(Article obj)
        {//--acId, acName, acImg, acPid, acOrder
            obj = new Article()
            {
                acId = obj.acId,
                acName = obj.acName,
                acImg = obj.acImg,
                acPid = obj.acPid,
                acOrder = obj.acOrder,
            };
            int result = new ArticleBLL().CEdit(obj);
            return RedirectToAction("ArticleCList", "Admin");
        }
        #endregion

        #region 栏目删除

        public ActionResult CDel(string id)
        {
            int result = new ArticleBLL().CDel(id);

            if (result == 1)
            {
                return this.Content("删除成功！");
            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 栏目添加
        public ActionResult GetCAdd(Article obj, string pid)
        {
            //var isIndex = obj.isIndex != null ? true : false;
            obj = new Article
            {
                acId = obj.acId,
                acName = obj.acName,
                acImg = obj.acImg,
                acPid = obj.acPid,
                acOrder = obj.acOrder,
            };
            int result = new ArticleBLL().CAdd(obj);
            return RedirectToAction("ArticleCList", "Admin", new { pid = pid });
            
        }
        #endregion

        #region 分部视图_栏目下拉列表

        public ActionResult _ArtCList(string acPName)
        {
            List<Article> list = new ArticleBLL().GetCListByPName(acPName);
            ViewBag.list = list;
            return PartialView("_ArtCList");
        }

        #endregion



    }
}