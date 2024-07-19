using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangCuaKhanhBang.Models
{
    public class GioHangClass
    {
        DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
        public int gMaTaiKhoan { get; set; }
        public int gMaSanPham { get; set; }
        public string gTenSanPham { get; set; }
        public int gSoLuong { get; set; }
        public DateTime gNgayLap { get; set; }
        public double gDonGia { get; set; }
        public string gAnhSanPham { get; set; }
        public double gTthanhTien
        {
            get { return gSoLuong * gDonGia; }
        }

        //Khởi tạo giỏ hàng
        public GioHangClass(int id)//, int idTaiKhoan và ngày lập được thêm sau
        {
            gMaSanPham = id;
            //gMaTaiKhoan = idTaiKhoan;
            SanPham sp = kn.SanPhams.Single(s => s.MaSanPham == id);
            gTenSanPham = sp.TenSanPham;
            gAnhSanPham = sp.AnhSanPham;
            gDonGia = double.Parse(sp.GiaBan.ToString());
            gSoLuong = 1;
        }
    }
}