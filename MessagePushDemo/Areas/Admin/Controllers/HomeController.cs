using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessagePushDemo.Hubs;
using Microsoft.AspNet.SignalR;

namespace MessagePushDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Push(string msg)
        {
            IHubContext chat = GlobalHost.ConnectionManager.GetHubContext<PushHub>();
            chat.Clients.All.notice("系统通知",msg);
            return Json(new { status = 1,msg="发送成功！"});
        }
    }
}