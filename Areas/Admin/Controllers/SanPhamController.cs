using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        //DB_QuanLySanPhamDataContext kn = new DB_QuanLySanPhamDataContext(KetNoi.chuoiKetNoi);

        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();

        // GET: Admin/SanPham
        public ActionResult SanPhamView(string SearchText = "")
        {
            ViewBag.searchText = SearchText;
            List<SanPham> DSsanPham = kn.SanPhams.OrderByDescending(theo => theo.MaSanPham).ToList();
            if (!string.IsNullOrEmpty(SearchText))
            {
                DSsanPham = kn.SanPhams.Where(tim => tim.TenSanPham.Contains(SearchText) || tim.MoTa.Contains(SearchText)).ToList();
            }
            return View(DSsanPham);
        }

        public ActionResult ThemSanPham()
        {
            ViewBag.DanhMuc = new SelectList(kn.DanhMucs.ToList(),"MaDanhMuc","TenDanhMuc");
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(SanPham sp, HttpPostedFileBase AnhSanPham, int? MaDanhMuc)
        {
            ViewBag.DanhMuc = new SelectList(kn.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");

            if (ModelState.IsValid)
            {
                kn.SanPhams.Add(sp);
                kn.SaveChanges();
                if (AnhSanPham != null && AnhSanPham.ContentLength > 0)
                {
                    int id = sp.MaSanPham;
                    int vitri = AnhSanPham.FileName.IndexOf('.');

                    var newFileName = AnhSanPham.FileName.Substring(0, vitri);
                    var _extension = Path.GetExtension(AnhSanPham.FileName);
                    string newName = newFileName + _extension;
                    string _fileName = Path.GetFileName(newName);
                    string _path = Path.Combine(Server.MapPath("~/assets/img/san_pham"), _fileName);
                    AnhSanPham.SaveAs(_path);

                    SanPham spn = kn.SanPhams.FirstOrDefault(tim => tim.MaSanPham == id);
                    spn.AnhSanPham = newName;
                    kn.SaveChanges();
                }
                else
                {
                    return View(sp);
                }
                return RedirectToAction("sanphamview");
            }
            return View(sp);
        }

        [HttpPost]
        public ActionResult xoaTatCaSanPham(string maSanPham)
        {
            if (!string.IsNullOrEmpty(maSanPham))
            {
                string[] cacMaSanPham = maSanPham.Split(',');
                if (cacMaSanPham != null && cacMaSanPham.Any())
                {
                    foreach (var ma in cacMaSanPham)
                    {
                        var motSanPham = kn.SanPhams.Find(int.Parse(ma));
                        kn.SanPhams.Remove(motSanPham);
                        kn.SaveChanges();

                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        public ActionResult capNhatSanPham(int MaSanPham)
        {
            SanPham capNhat = KetNoi.coSoDuLieu().SanPhams.Where(tim => tim.MaSanPham == MaSanPham).FirstOrDefault();
            return View(capNhat);
        }

        [HttpPost]
        public ActionResult capNhatSanPham(SanPham sp, HttpPostedFileBase AnhSanPham)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            if (ModelState.IsValid)
            {
                SanPham sanPham = kn.SanPhams.Where(tim => tim.MaSanPham == sp.MaSanPham).FirstOrDefault();
                sanPham.TenSanPham = sanPham.TenSanPham;
                ViewBag.ngaySX = sanPham.NgaySanXuat;
                ViewBag.ngayHH = sanPham.NgayHetHan;
                if (AnhSanPham != null && AnhSanPham.ContentLength > 0)
                {
                    var tenMoi = Guid.NewGuid();
                    string phamMoRong = Path.GetExtension(AnhSanPham.FileName);
                    string tenTam = tenMoi + phamMoRong;
                    string tenLuu = Path.Combine(Server.MapPath("~/assets/img/icon_gioThieu"), tenTam);
                    AnhSanPham.SaveAs(tenLuu);
                    sanPham.AnhSanPham = tenTam;
                }
                kn.SaveChanges();
                return RedirectToAction("SanPhamView");
            }
            return View(sp);
        }

        //public ActionResult xoaSanPham(int MaSanPham)
        //{
        //    DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
        //    SanPham capNhat = KetNoi.coSoDuLieu().SanPhams.Where(tim => tim.MaSanPham == MaSanPham).FirstOrDefault();
        //    return View(capNhat);
        //}
        //[HttpPost]
        public ActionResult xoaSanPham(int MaSanPham)
        {

            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            SanPham spa = kn.SanPhams.Where(tim => tim.MaSanPham == MaSanPham).FirstOrDefault();
            kn.SanPhams.Remove(spa);
            kn.SaveChanges();
            return RedirectToAction("SanPhamView");
        }



    }
}