using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestLinq2DB.LinqToDB;
using LinqToDB;

namespace TestLinq2DB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

		public IActionResult GetTests()
		{
			using (var db = new DBTest())
			{
				var query = from t in db.TestItems
							select t;
				var res = query.ToList();
				return new ObjectResult(res);
			}
		}
    }


}
