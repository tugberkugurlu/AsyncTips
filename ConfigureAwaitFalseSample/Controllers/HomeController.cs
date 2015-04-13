using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConfigureAwaitFalseSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DoWorkAsync().Wait();
            return View();
        }

        private async Task DoWorkAsync()
        {
            await Task.Delay(500);
        }
    }
}