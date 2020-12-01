using Csp.Web.Extensions;
using FjRuiYiPack.Web.Models;
using FjRuiYiPack.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FjRuiYiPack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.Carousels = _articleService.GetCarousels().Result;
            base.OnActionExecuted(context);
        }

        public async Task<IActionResult> Index()
        {
            IndexModel model = new IndexModel
            {
                Articles = await _articleService.GetArticles(),
                Categories = await _articleService.GetCategoriesAsync()
            };
            return View(model);
        }


        [Route("/d/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var article = await _articleService.GetArticle(id, HttpContext.RemoteIp(), Request.BrowserNameByUserAgent(), Request.DeviceByUserAgent(), Request.OsByUserAgent());
            article.Content = article.Content.Replace("src", "data-original");
            return View(article);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
