using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeaderDisplay.Models;

namespace HeaderDisplay.Controllers
{
public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PostViewModel formData)
        {
            ViewBag.Url = formData.Url;
            ViewBag.Exclude = formData.ExcludeHeaders;
            var headers = await Helpers.GetHeaders(formData);
            return View(headers);
        }
    }
}