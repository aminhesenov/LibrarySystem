using System.Diagnostics;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(string bookName, string author, string isbn, string shelfNo)
        {
            AddBooks add=new AddBooks();
            ViewBag.Message=add.Add(bookName, author, isbn, shelfNo);
            return View();
        }
        [HttpGet]
        public IActionResult SearchBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchBook(string bookName)
        {
            SearchBooks search=new SearchBooks();
            ViewBag.Result=search.Search(bookName);
            return View();
        }

        public IActionResult Index()
        {
            return View("AddBook");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
