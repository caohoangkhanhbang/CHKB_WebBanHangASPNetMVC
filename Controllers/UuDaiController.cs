using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangCuaKhanhBang.Models;

namespace WebBanHangCuaKhanhBang.Controllers
{
    public class UuDaiController : Controller
    {
        // GET: UuDai
        public ActionResult UuDaiPartial()
        {
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            List<UuDai> dsUuDai = kn.UuDais.ToList();
            return View(dsUuDai);
        }
    }
}