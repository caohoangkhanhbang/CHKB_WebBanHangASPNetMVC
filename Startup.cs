//using Microsoft.Owin;
//using Owin;
//using System;
//using System.Threading.Tasks;
//using WebBanHangCuaKhanhBang.Models;


////Sử dụng các thư viện 
//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.AspNet.Identity.EntityFramework;

//using WebBanHangCuaKhanhBang.Identity;

//[assembly: OwinStartup(typeof(WebBanHangCuaKhanhBang.Startup))]

//namespace WebBanHangCuaKhanhBang
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            app.UseCookieAuthentication(new CookieAuthenticationOptions()
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                LoginPath = new PathString("/Acount/login")
//            });
//            //this.CreateRolesAndUsers();
//        }

//        //public void CreateRolesAndUsers()
//        //{
//        //    var roleManneger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
//        //    var appDBContext = new AppDbContext();
//        //    var appUserStore = new AppUserStore(appDBContext);
//        //    var userManager = new AppUserManager(appUserStore);

//        //    if (!roleManneger.RoleExists("Admin"))
//        //    {
//        //        var role = new IdentityRole();
//        //        role.Name = "Admin";
//        //        roleManneger.Create(role);
//        //    }

//        //    if (userManager.FindByName("admin") == null)
//        //    {
//        //        var user = new AppUser();
//        //        user.UserName = "admin";
//        //        user.Email = "admin@gmail.com";
//        //        string userPwd = "nammoPhat";

//        //        var chkUser = userManager.Create(user, userPwd);
//        //        if (chkUser.Succeeded)
//        //        {
//        //            userManager.AddToRole(user.Id, "Admin");
//        //        }
//        //    }

//        //    if (!roleManneger.RoleExists("Manager"))
//        //    {
//        //        var role = new IdentityRole();
//        //        role.Name = "Manager";
//        //        roleManneger.Create(role);
//        //    }

//        //    if (userManager.FindByName("manager") == null)
//        //    {
//        //        var user = new AppUser();
//        //        user.UserName = "manager";
//        //        user.Email = "manager@gmail.com";
//        //        string userPwd = "nammoPhap";

//        //        var chkUser = userManager.Create(user, userPwd);
//        //        if (chkUser.Succeeded)
//        //        {
//        //            userManager.AddToRole(user.Id, "Manager");
//        //        }
//        //    }

//        //    if (!roleManneger.RoleExists("Customer"))
//        //    {
//        //        var role = new IdentityRole();
//        //        role.Name = "Customer";
//        //        roleManneger.Create(role);
//        //    }



//        }
//    }
//}
