using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebBanHang.Models;

namespace WebBanHang.App_Start
{
    public class AdminAuthorize: AuthorizeAttribute
    {
        public int idChucNang { set; get; }
        BanHangEntities db = new BanHangEntities();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //Check session: Đã đăng nhập => cho thực hiện Filter không thì trở lại trang đăng nhập
            NhanVien nv = (NhanVien)HttpContext.Current.Session["user"];
            if(nv != null)
            {
                //Check quyền: Có quyền => cho thực hiện Filter không thì ra trang báo lỗi
                var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID && m.IDChucNang == idChucNang);
                if (count != 0)
                {
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(
                        new
                        {
                            controller = "Error",
                            action = "AccessDeny",
                            area = "Admin",
                            returnUrl = returnUrl.ToString()
                        })); ;
                }
                return;
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new
                    {
                        controller = "HomeAdmin",
                        action = "Login",
                        area = "Admin",
                        returnUrl = returnUrl.ToString()
                    })); ;
            }
            
        }
    }
}