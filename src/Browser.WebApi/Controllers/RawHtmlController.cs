﻿using Browser.Core;
using Microsoft.AspNetCore.Mvc;

namespace Browser.WebApi.Controllers
{
    [Route("/RawHtml")]
    public class RawHtmlController : Controller
    {
        private readonly IBrowserService _browserService;
        public RawHtmlController(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        [HttpPost]
        public FileResult Post(string url, string script = "", int width = 1200, int height = 900)
        {
            var content = _browserService.GetRawHtml(url, script, height, width);
            return PhysicalFile(content.RawHtmlPath, "text/html", content.RawHtmlPath);
        }
    }
}