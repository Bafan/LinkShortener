using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreWebService.Filters;
using LinkShortener.Engine.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        private ILinkShortenerService _linkShortenerService;
        public LinksController(ILinkShortenerService linkShortenerService)
        {
            _linkShortenerService = linkShortenerService;
        }

        [HttpGet("info")]
        public IActionResult info()
        {            
            return Ok("Hi");
        }

        [HttpPost("createshortener")]
        public IActionResult CreateShortener([FromBody]string value)
        {
            var result = _linkShortenerService.OriginToShortener(value);
            return Ok(result);
        }

        [HttpPost("retrieveorigin")]
        public IActionResult RetrieveOrigin([FromBody]string value)
        {
            var result = _linkShortenerService.ShortenerToOrigin(value);
            return Ok(result);
        }
    }
}
