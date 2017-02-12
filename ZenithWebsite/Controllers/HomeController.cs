using System.Linq;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data.Entity;
using System.Globalization;
using System;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var mon = DayOfWeek.Monday;
            var sun = DayOfWeek.Sunday;
            var cur = DateTime.Now.DayOfWeek;
            int startDif = mon - cur;
            int endDif = mon - sun;

                var events = db.Event
                            .Include(a => a.Activity)
                            .OrderBy(a => a.DateFrom);
            return View(events.ToList());
        }
    }
}