using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;

namespace MvcApiCall.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allArticles = Article.GetArticles(EnvironmentVariable.ApiKey);
            return View(allArticles);
        }
    }
}
