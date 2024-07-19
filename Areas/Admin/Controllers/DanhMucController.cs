using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();

        public ActionResult DanhMucView(string SearchText = "")
        {
            ViewBag.searchText = SearchText;
            List<DanhMuc> DSdanhMuc = kn.DanhMucs.OrderByDescending(theo => theo.MaDanhMuc).ToList();
            if (!string.IsNullOrEmpty(SearchText))
            {
                DSdanhMuc = kn.DanhMucs.Where(tim => tim.TenDanhMuc.Contains(SearchText)).ToList();
            }
            return View(DSdanhMuc);
        }


        public ActionResult ThemDanhMuc()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDanhMuc(DanhMuc dm, HttpPostedFileBase AnhDanhMuc)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            if (ModelState.IsValid)
            {
                kn.DanhMucs.Add(dm);
                kn.SaveChanges();
                if(AnhDanhMuc!=null&&AnhDanhMuc.ContentLength>0)
                {
                    var tenMoi = Guid.NewGuid();
                    string phanMoRong = Path.GetExtension(AnhDanhMuc.FileName);
                    string tenTam = tenMoi + phanMoRong;
                    string tenLuu = Path.GetFileName(tenTam);
                    string noiLuu = Path.Combine(Server.MapPath("~/assets/img/icon_gioiThieu"), tenLuu);
                    AnhDanhMuc.SaveAs(noiLuu);

                    //cập nhật tên
                    var danhMuc = kn.DanhMucs.FirstOrDefault(t => t.MaDanhMuc == dm.MaDanhMuc);
                    danhMuc.AnhDanhMuc = tenLuu;
                    kn.SaveChanges();
                }    
                return RedirectToAction("Danhmucview");
            }
            return View(dm);
        }

        public ActionResult CapNhatDanhMuc(int maDanhMuc)
        {
            DanhMuc capNhat = KetNoi.coSoDuLieu().DanhMucs.Where(tim => tim.MaDanhMuc == maDanhMuc).FirstOrDefault();
            return View(capNhat);
        }

        [HttpPost]
        public ActionResult CapNhatDanhMuc(DanhMuc dm, HttpPostedFileBase AnhDanhMuc)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            if (ModelState.IsValid)
            {
                DanhMuc danhMuc = kn.DanhMucs.Where(tim => tim.MaDanhMuc == dm.MaDanhMuc).FirstOrDefault();
                danhMuc.TenDanhMuc = dm.TenDanhMuc;
                if(AnhDanhMuc!=null&&AnhDanhMuc.ContentLength>0)
                {
                    var tenMoi = Guid.NewGuid();
                    string phamMoRong = Path.GetExtension(AnhDanhMuc.FileName);
                    string tenTam = tenMoi + phamMoRong;
                    string tenLuu = Path.Combine(Server.MapPath("~/assets/img/icon_gioThieu"), tenTam);
                    if(danhMuc.AnhDanhMuc != tenLuu)
                    {
                        AnhDanhMuc.SaveAs(tenLuu);
                        danhMuc.AnhDanhMuc = tenTam;// có lỗi ở đây
                    }    
                }    
                kn.SaveChanges();
                return RedirectToAction("Danhmucview");
            }
            return View(dm);
        }


        //public ActionResult xoaDanhMuc(int maDanhMuc)
        //{
        //    DB_WebBanHangOnlineEntities1 kn = new DB_WebBanHangOnlineEntities1();
        //    DanhMuc danhMuc = kn.DanhMuc.Find(maDanhMuc);
        //    return View(danhMuc);
        //}
        //[HttpPost]
        //public ActionResult xoaDanhMuc(DanhMuc dm)
        //{
        //    DB_WebBanHangOnlineEntities1 kn = new DB_WebBanHangOnlineEntities1();
        //    DanhMuc danhMuc = kn.DanhMuc.Where(theo=>theo.MaDanhMuc==dm.MaDanhMuc).FirstOrDefault();
        //    kn.DanhMuc.Remove(danhMuc);
        //    kn.SaveChanges();
        //    return RedirectToAction("danhmucview");
        //}

        ////cách dùng json
        [HttpPost]
        public ActionResult xoaDanhMuc(int id)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            DanhMuc danhMuc = kn.DanhMucs.Where(t => t.MaDanhMuc == id).FirstOrDefault();
            if (danhMuc != null)
            {
                kn.DanhMucs.Remove(danhMuc);
                kn.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }



    }
}