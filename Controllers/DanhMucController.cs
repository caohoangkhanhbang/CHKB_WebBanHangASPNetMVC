using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        public ActionResult DanhMucPartial()
        {
            List<DanhMuc> dsDanhMuc = KetNoi.coSoDuLieu().DanhMucs.ToList();
            return View(dsDanhMuc);
        }
    }
}