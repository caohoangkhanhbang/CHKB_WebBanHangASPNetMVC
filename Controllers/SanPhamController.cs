using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class SanPhamController : Controller
    {
        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
        // GET: SanPham
        public ActionResult chiTietSanPhamView(int id)
        {
            ViewBag.DanhMuc = kn.SanPhams.Where(t=>t.MaSanPham== id).FirstOrDefault().DanhMucs.FirstOrDefault().TenDanhMuc;
           // ViewBag.DanhMuc = kn.SanPhams.FirstOrDefault(t => t.MaSanPham == id).DanhMucs.FirstOrDefault();
            SanPham sanPham = kn.SanPhams.Where(tim => tim.MaSanPham == id).FirstOrDefault();
            return View(sanPham);
        }
    }
}