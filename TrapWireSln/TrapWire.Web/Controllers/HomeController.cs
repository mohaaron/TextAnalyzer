using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrapWire.TextAnalysis;
using TrapWire.Web.Models;

namespace TrapWire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITextAnalyzer textAnalyzer;

        public HomeController(ILogger<HomeController> logger, ITextAnalyzer textAnalyzer)
        {
            _logger = logger;
            this.textAnalyzer = textAnalyzer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTextAnalysis(string text)
        {
            HashSet<CharacterResult> results = textAnalyzer.Analyze(text);
            return PartialView(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}