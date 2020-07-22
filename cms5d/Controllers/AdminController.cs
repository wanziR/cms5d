using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using BLL;
using X.PagedList;
using X.PagedList.Mvc;

namespace cms5d.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        #region 返回页面

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Form()
        {
            return View();
        }
        public ActionResult _List()
        {
            return View();
        }

        #endregion

        #region 登录

        public ActionResult login()
        {
            return View();
        }
        #region 注释

        //public ActionResult AdminLogin(SysAdmin obj)
        //{
        //    obj = new SysAdmin
        //    {
        //        adminName = obj.adminName,
        //        adminPwd = obj.adminPwd
        //    };
        //    obj = new SysAdminBLL().Login(obj);
        //    if (obj != null)
        //    {
        //        string adminName = obj.adminName;
        //        FormsAuthentication.SetAuthCookie(adminName, true);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.info = "用户名或密码错误！";
        //        return View("login");

        //    }
        //}

        #endregion
        //管理员登录
        public ActionResult AdminLogin(UserInfo obj)
        {
            obj = new UserInfo
            {
                userName = obj.userName,
                userPwd = obj.userPwd
            };
            obj = new UserInfoBLL().AdminLogin(obj);
            if (obj != null)
            {
                string userName = obj.userName;
                FormsAuthentication.SetAuthCookie(userName, true);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.info = "用户名或密码错误！";
                return View("login");

            }
        }

        #endregion
        
        #region 退出
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        #endregion

        #region 管理员
        //列表
        public ActionResult SysAdminList(string role,int page = 1)
        {
            List<SysAdmin> list = new SysAdminBLL().GetList(role);
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }

        #endregion

        #region 用户
        //列表
        public ActionResult UserList(int page=1)
        {
            List<UserInfo> list = new UserInfoBLL().GetList();
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region 文章
        //列表
        public ActionResult ArticleList(string acid,int page = 1)
        {
            // acid = "3";
            ViewBag.acId = acid;
           //取父栏目名根据子栏目ID
           ViewBag.acPName = new ArticleBLL().GetAcPNameByAcId(acid);
            //取栏目名根据栏目ID
            ViewBag.acName = new ArticleBLL().GetAcNameByAcId(acid);
            //列表
            List<Article> list = new ArticleBLL().GetListByAcid(acid);
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }
        //栏目
        public ActionResult ArticleCList(string pid, int page = 1)
        {
            ViewBag.pid = pid;
            ViewBag.acPName = new ArticleBLL().GetAcNameByAcId(pid);
            List<Article> list = new ArticleBLL().GetCListByPid(pid);
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

    }
}