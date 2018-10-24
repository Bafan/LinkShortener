using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Controllers
{
    [Route("/")]
    public class InfoController : Controller
    {
        private const string MESSAGE_FORMAT = "Linkshortener service is up";

        [HttpGet]
        public JsonResult Get()
        {
            return Json(new Response
            {
                output = MESSAGE_FORMAT
            });
        }
    }
}
