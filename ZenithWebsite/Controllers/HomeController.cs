using System.Linq;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data.Entity;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var events = db.Event.Include(a => a.Activity);
            return View(events.ToList());
        }
    }
}