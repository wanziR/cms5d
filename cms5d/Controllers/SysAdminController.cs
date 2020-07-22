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
    public class SysAdminController : Controller
    {
        // GET: SysAdmin
        public ActionResult Index()
        {
            return View();
        }

        #region 列表

        public ActionResult List(string role,int page = 1)
        {
            List<SysAdmin> list = new SysAdminBLL().GetList(role);
            var plist = list.ToPagedList(page, 1);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region 编辑
        [ValidateInput(false)]
        public ActionResult GetEdit(SysAdmin obj)
        {
            obj = new SysAdmin()
            {
                adminId = obj.adminId,
                adminName = obj.adminName,
                adminPwd = obj.adminPwd
            };
            int result = new SysAdminBLL().Edit(obj);
            return RedirectToAction("SysAdminList", "Admin");
        }
        #endregion

        #region 删除

        public ActionResult Del(string id)
        {
            int result = new SysAdminBLL().Del(id);

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
        public ActionResult GetAdd(SysAdmin obj)
        {
            //var isIndex = obj.isIndex != null ? true : false;

                obj = new SysAdmin
                {
                    adminName = obj.adminName,
                    adminPwd = obj.adminPwd
                };
                int result = new SysAdminBLL().Add(obj);
                return RedirectToAction("SysAdminList", "Admin");

        }
        #endregion



    }
}