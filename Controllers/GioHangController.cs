using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult themGioHang(int ms)
        {
            //Lấy giỏ hàng
            //List<GioHangClass> DSgioHang = layGioHang();

            //Kiểm tra danh sách này có tồn tại trong session giỏ hàng chưa
            GioHang sanPhamkt = kn.GioHangs.FirstOrDefault(sp => sp.MaSanPham == ms);
            GioHangClass sanPham = new GioHangClass(ms);

            if (sanPhamkt == null)
            {
                //sanPham = new GioHangClass(ms);
                //sanPham.gNgayLap = DateTime.Now;
                //DSgioHang.Add(sanPham);

                GioHang gioHangLuuDB = new GioHang();
                gioHangLuuDB.MaTaiKhoan = 1;
                gioHangLuuDB.MaSanPham = sanPham.gMaSanPham;
                gioHangLuuDB.TenSanPham = sanPham.gTenSanPham;
                gioHangLuuDB.SoLuong = sanPham.gSoLuong;
                gioHangLuuDB.DonGia = sanPham.gDonGia;
                gioHangLuuDB.NgayLap = DateTime.Now;
                gioHangLuuDB.ThanhTien = sanPham.gTthanhTien;
                gioHangLuuDB.TongThanhToan = sanPham.gTthanhTien;
                gioHangLuuDB.AnhSanPham = sanPham.gAnhSanPham;
                kn.GioHangs.Add(gioHangLuuDB);
                kn.SaveChanges();
                return RedirectToAction("Giohang");
            }
            else //sản phẩm đã có trong giỏ
            {
                GioHang gioHangCapNhat = kn.GioHangs.FirstOrDefault(t => t.MaSanPham == ms);
                gioHangCapNhat.SoLuong++;
                gioHangCapNhat.ThanhTien = tongThanhTien();
                gioHangCapNhat.SoLuong = tongSoLuong();
                kn.SaveChanges();
                //sanPham.gSoLuong++;
                return RedirectToAction("giohang");
            }
        }

        private int tongSoLuong()
        {
            int tongSoLuong = 0;
            //List<GioHangClass> DSgioHang = Session["GioHang"] as List<GioHangClass>;
            List<GioHang> gioHangDB = kn.GioHangs.ToList();
            if (gioHangDB != null)
            {
                tongSoLuong = gioHangDB.Sum(sp => sp.SoLuong.Value);
            }
            return tongSoLuong;
        }

        private double tongThanhTien()
        {
            double thanhTien = 0;
            //List<GioHangClass> DSgioHang = Session["GioHang"] as List<GioHangClass>;
            List<GioHang> gioHangDB = kn.GioHangs.ToList();
            if (gioHangDB != null)
            {
                //thanhTien += DSgioHang.Sum(sp => sp.gTthanhTien);
                thanhTien += gioHangDB.Sum(sp => sp.ThanhTien.Value);
            }
            return thanhTien;
        }

        public List<GioHangClass> layGioHang()
        {
            List<GioHangClass> DSgioHang = Session["GioHang"] as List<GioHangClass>;
            if (DSgioHang == null)
            {
                DSgioHang = new List<GioHangClass>();
                Session["GioHang"] = DSgioHang;
            }
            return DSgioHang;
        }

        public ActionResult GioHang()
        {

            List<GioHang> gioHangDB = kn.GioHangs.ToList();
            if (gioHangDB.Count > 0)
            {
                ViewBag.tongSoLuong = tongSoLuong();
                ViewBag.tongThanhTien = tongThanhTien();
                return View(gioHangDB);
            }
            else
            {
                //if (Session["GioHang"] == null)
                //{
                //    if (gioHangDB.Count > 0)
                //    {
                //        return View(gioHangDB);
                //    }
                //    else
                //    {
                //        return RedirectToAction("index", "home");
                //    }
                //}
                //if(gioHangDB.Count>0)
                //{
                //    return View(gioHangDB);
                //}
                //else
                //{
                //    List<GioHangClass> DSgioHang = layGioHang();
                   
                //    return View(DSgioHang);
                //}
                return RedirectToAction("index", "home");
            }
        }

        public ActionResult GioHangCon()
        {
            //if (Session["GioHang"] == null)
            //{
            //    ViewBag.rong = 0;
            //}
            //List<GioHangClass> DSgioHang = layGioHang();
            //return View(DSgioHang);
            List<GioHang> gioHangDB = kn.GioHangs.ToList();
            return View(gioHangDB);
        }

        public ActionResult gioHangPartial()
        {
            ViewBag.soSanPhamDat = tongSoLuong();
            return View();
        }

        public ActionResult xoaGioHang(int id)
        {
            //List<GioHangClass> DSgioHang = layGioHang();
            //GioHangClass sp = DSgioHang.Single(dk => dk.gMaSanPham == id);
            //có sản phẩm
            //if (sp != null)
            //{
                GioHang gioHangCapNhat = kn.GioHangs.FirstOrDefault(t => t.MaSanPham == id);
                if(gioHangCapNhat!=null)
                {
                    kn.GioHangs.Remove(gioHangCapNhat);
                    kn.SaveChanges();
                    //return RedirectToAction("giohang", "giohang");
                }    
                //DSgioHang.RemoveAll(dk => dk.gMaSanPham == id);
            //}

            if (gioHangCapNhat == null) //không có
            {
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("giohang", "giohang");
        }

        public ActionResult xoaTatCaGioHang()
        {
            //List<GioHangClass> DSgioHang = layGioHang();
            List<GioHang> gioHangCapNhat = kn.GioHangs.ToList();
            gioHangCapNhat.Clear();
            return RedirectToAction("index", "home");
        }

        //public ActionResult capNhatSoLuong(int id)
        //{
        //    List<GioHang> DSgioHang = layGioHang();
        //    GioHang sp = DSgioHang.Single(theo => theo.iMaSach == id);
        //    //cập nhật
        //    sp.iSoLuong = 2;
        //    return RedirectToAction("giohang", "giohang");
        //}

        [HttpPost]
        public ActionResult capNhatSoLuong(int id, int soLuong)
        {
            //List<GioHangClass> DSgioHang = layGioHang();
            //GioHangClass sp = DSgioHang.Single(theo => theo.gMaSanPham == id);
            GioHang gioHangDB = kn.GioHangs.FirstOrDefault(kb => kb.MaSanPham == id);
            //cập nhật
            //sp.gSoLuong = soLuong;
            gioHangDB.SoLuong = soLuong;
            kn.SaveChanges();
            return RedirectToAction("giohang", "giohang");
        }

    }
}