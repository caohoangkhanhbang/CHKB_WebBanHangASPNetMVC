using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebBanHangCuaKhanhBang.Models
{
    public class TaiKhoanClass
    {
        public int tMaTaiKhoan { get; set; }
        [Required(ErrorMessage = "Không được để trống trường này")]
        public string tTenTaiKhoan { get; set; }
        [Required(ErrorMessage = "Không được để trống trường này")]
        [MinLength(3)]
        public string tMatKhau { get; set; }
        //[Compare(tMatKhau,ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string tXacNhanMatKhau { get; set; }
        [Required(ErrorMessage = "Không được để trống trường này")]

        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
    }
}