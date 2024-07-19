using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangCuaKhanhBang.Models
{
    public class KetNoi
    {
        public static string chuoiKetNoi = "Data Source=BATCHANHDAO\\SQLEXPRESS;Initial Catalog=DB_WebBanHangOnline;Integrated Security=True";

        public static DB_WebBanHangOnlineEntities2 coSoDuLieu() 
        { 
            DB_WebBanHangOnlineEntities2 kn = new DB_WebBanHangOnlineEntities2();
            return kn;
        }

    }
}