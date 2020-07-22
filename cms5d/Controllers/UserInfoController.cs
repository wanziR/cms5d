using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Models;
using X.PagedList;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;

namespace cms5d.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: SysAdmin
        public ActionResult Index()
        {
            return View();
        }

        #region 列表

        public ActionResult List(int page = 1)
        {
            List<UserInfo> list = new UserInfoBLL().GetList();
            var plist = list.ToPagedList(page, 1);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region 编辑
        [ValidateInput(false)]
        public ActionResult GetEdit(UserInfo obj)
        {
            obj = new UserInfo()
            {
                userId = obj.userId,
                userAge = obj.userAge,
                userName = obj.userName,
                userNickname = obj.userNickname,
                userImg = obj.userImg,
                userPhone = obj.userPhone,
                userSex = obj.userSex,
                userEdu = obj.userEdu,
                userEmail = obj.userEmail,
                userAddtime = DateTime.Now,
            };
            int result = new UserInfoBLL().Edit(obj);
            return RedirectToAction("UserList", "Admin");
        }
        #endregion

        #region 删除

        public ActionResult Del(string id)
        {
            int result = new UserInfoBLL().Del(id);

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
        public ActionResult GetAdd(UserInfo obj)
        {
            //var isIndex = obj.isIndex != null ? true : false;

                obj = new UserInfo
                {
                    userId = obj.userId,
                    userAge = obj.userAge,
                    userName = obj.userName,
                    userNickname = obj.userNickname,
                    userImg = obj.userImg,
                    userPhone = obj.userPhone,
                    userSex = obj.userSex,
                    userEdu = obj.userEdu,
                    userEmail = obj.userEmail,
                    userAddtime = DateTime.Now,
                };
                int result = new UserInfoBLL().Add(obj);
                return RedirectToAction("UserCenter", "UserInfo");

        }
        #endregion

        #region 用户存在判断
        public ActionResult UserNameIn(string userName)
        {
           UserInfo obj = new UserInfo
            {
                userName = userName
           };
            obj = new UserInfoBLL().UserIn(obj);
            if (obj != null)
            {//用户存在
                return Content("1");
            }
            else
            {
                return Content("0");

            }
        }

        #endregion

        #region 注册 

        public ActionResult GetReg(UserInfo obj)
        {
            obj = new UserInfo
            {
                userId = obj.userId,
                userName = obj.userName,
                userPwd = obj.userPwd,
                userPhone = obj.userPhone,
                userAddtime = DateTime.Now,
            };
            int result = new UserInfoBLL().Add(obj);
            return RedirectToAction("login", "UserInfo");
        }
      
        #endregion

        #region 登录

        public ActionResult login()
        {
            return View();
        }
        public ActionResult UserLogin(UserInfo obj)
        {
            obj = new UserInfo
            {
                userName = obj.userName,
                userPwd = obj.userPwd
            };
            obj = new UserInfoBLL().Login(obj);
            if (obj != null)
            {
                string userName = obj.userName;
                FormsAuthentication.SetAuthCookie(userName, true);
                //return RedirectToAction("UserCenter");
                return Content("1");
            }
            else
            {
                //ViewBag.info = "用户名或密码错误！";
                //return RedirectToAction("login", "UserInfo");
                return Content("0");

            }
        }
        //分部视图_登入登出
        public ActionResult _LoginInOut()
        {
            return PartialView("_LoginInOut");
        }

        #endregion

        #region 忘记密码
        public ActionResult GetEditPwd(UserInfo obj)
        {
            obj = new UserInfo()
            {
                userName = obj.userName,
                userPwd = obj.userPwd
            };
            try
            {
                int result = new UserInfoBLL().EditPwd(obj);
                return this.Content("1");
            }
            catch (Exception e)
            {
                return this.Content("0");
            }
          

        }
        #endregion

        #region 退出
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "UserInfo");
        }
        #endregion

        #region 用户中心

        public ActionResult UserCenter()
        {
            return View();
        }

        #endregion



    }
}