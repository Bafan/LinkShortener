using AspNetCoreWebService.Filters;
using LinkShortener.Engine.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        #region Private Members
        private ILinkShortenerService _linkShortenerService;
        #endregion

        #region Constructor
        public LinksController(ILinkShortenerService linkShortenerService)
        {
            _linkShortenerService = linkShortenerService;
        }
        #endregion

        #region Actions
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
        #endregion
    }
}
