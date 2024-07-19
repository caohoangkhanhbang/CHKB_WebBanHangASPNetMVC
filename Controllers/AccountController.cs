using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
        public ActionResult DangKyTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKyTaiKhoan(TaiKhoan tk)
        {
            if(ModelState.IsValid)
            {
                kn.TaiKhoans.Add(tk);
                kn.SaveChanges();
                return RedirectToAction("DangNhapTaiKhoan");
            }    
            return View(tk);
        }

        public ActionResult DangNhapTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapTaiKhoan(string tenTaiKhoan, string matKhau, TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                TaiKhoan taiKhoana = kn.TaiKhoans.Where(t => string.Compare(tenTaiKhoan, t.TenTaiKhoan, true) == 0 && string.Compare(matKhau, t.MatKhau, true) == 0).FirstOrDefault();
                if(taiKhoana != null)
                {
                    if (string.Compare(taiKhoana.TenTaiKhoan, "Admin", true) == 0 && string.Compare(taiKhoana.MatKhau, "Admin123", true) == 0)
                    {
                        return Redirect("/admin/home/index");
                    }
                    else
                    {
                        return RedirectToAction("index", "Home");
                    }
                }
                ViewBag.KhongCoTaiKhoan = "Tài khoản này chưa được đăng ký";
            }
            return View(tk);
        }
    }
}