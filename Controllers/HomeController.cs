using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhoIsTheUgliest.Models;

namespace WhoIsTheUgliest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ImageAndVote ImageAndVote;

        public HomeController(ILogger<HomeController> logger, ImageAndVote imageAndVote)
        {
            _logger = logger;
            this.ImageAndVote = imageAndVote;
        }

        public IActionResult Index()
        {
            return View(ImageAndVote);
        }
        public IActionResult UpdateCount(string imagename)
        {
            if ( ImageAndVote.Votes.ContainsKey(imagename))
            {
                ImageAndVote.Votes[imagename] = ImageAndVote.Votes[imagename] +1;
                return Json(new { isOkay = true });
            }
            return Json(new { isOkay = false });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Result()
        {
            return View(ImageAndVote);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
