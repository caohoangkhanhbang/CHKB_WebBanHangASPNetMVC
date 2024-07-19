using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class HomeController : Controller
    {
        DB_WebBanHangOnlineEntities2 csdl = new DB_WebBanHangOnlineEntities2();

        // GET: Home

        //Trang chủ
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Trang sản phẩm
        public ActionResult sanPham(string SearchText = "")
        {
            ViewBag.searchText = SearchText;
            List<SanPham> DSsanPham = KetNoi.coSoDuLieu().SanPhams.OrderByDescending(theo => theo.MaSanPham).ToList();
            if (!string.IsNullOrEmpty(SearchText))
            {
                DSsanPham = KetNoi.coSoDuLieu().SanPhams.Where(tim => tim.TenSanPham.Contains(SearchText) || tim.MoTa.Contains(SearchText)).ToList();
            }
            //List<SanPham> dsSanPham = KetNoi.coSoDuLieu().SanPhams.ToList();
            return View(DSsanPham);
        }

        public ActionResult DanhMucTheoMaSanPham(int id)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            int maDM = int.Parse(kn.SanPhams.Where(t => t.MaSanPham == id).FirstOrDefault().DanhMucs.FirstOrDefault().MaDanhMuc.ToString());
            List<SanPham> dssp = kn.DanhMucs.Where(dma => dma.MaDanhMuc == maDM).FirstOrDefault().SanPhams.ToList();
            return View(dssp);
        }    

        public ActionResult SanPhamTheoDanhMuc(int id)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            List<SanPham> ds = kn.DanhMucs.Where(dma => dma.MaDanhMuc == id).FirstOrDefault().SanPhams.ToList();
            return View(ds);
        }

        public ActionResult MyPhamPartial()
        {
            List<SanPham> DSmyPham = csdl.DanhMucs.Where(ma => ma.MaDanhMuc == 24).FirstOrDefault().SanPhams.ToList();
            return View(DSmyPham);
        }

        public ActionResult SachPartial()
        {
            List<SanPham> DSmyPham = csdl.DanhMucs.Where(ma => ma.MaDanhMuc == 20).FirstOrDefault().SanPhams.ToList();
            return View(DSmyPham);
        }

        public ActionResult ThoiTrangNamPartial()
        {
            List<SanPham> DSthoiTrangNam = csdl.DanhMucs.Where(theo => theo.MaDanhMuc == 1).FirstOrDefault().SanPhams.ToList();
            return View(DSthoiTrangNam);
        }

        //Thử nghiệm
        public ActionResult SanPhamTheoChiTietDanhMuc(int MaChiTietDanhMuc)
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            List<SanPham> DSsanPhamDM = kn.ChiTietDanhMucs.Where(tim => tim.MaChiTietDanhMuc == MaChiTietDanhMuc).FirstOrDefault().DanhMucs.FirstOrDefault().SanPhams.ToList();
            return View(DSsanPhamDM);
        }

        //public ActionResult SanPhamTheoDanhMuc(int id)
        //{

        //}    

        //Trang giỏ hàng
        public ActionResult gioHang()
        {
            return View();
        }














    }
}