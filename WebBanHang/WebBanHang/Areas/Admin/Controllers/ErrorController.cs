﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult AccessDeny()
        {
            return View();
        }
    }
}