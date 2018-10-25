using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AspNetCoreWebService.Controllers
{
    [Route("/")]
    public class InfoController : Controller
    {
        #region private constants
        public const string MESSAGE_FORMAT = "<html><head>    <title>LinkShortener</title></head><body>    <h3>The link shortener web-api is ready to use</h3>    <hr />    <h4>Sample requests:</h4>    <p>        To generate shorten url:<br />        Method: Post<br />        Content-Type: application/json<br />        Url: http://ec2-13-229-149-50.ap-southeast-1.compute.amazonaws.com/api/links/createshortener<br />        body: \"http://www.mydomain.com/query\"    </p>    <br />    <p>        To retrieve original url:<br />        Method: Post<br />        Content-Type: application/json<br />        Url: http://ec2-13-229-149-50.ap-southeast-1.compute.amazonaws.com/api/links/retrieveorigin<br />        body: \"http://www.mydomain.com/a\"    </p></body></html>";
        #endregion

        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            return new ContentResult()
            {
                Content = MESSAGE_FORMAT,
                ContentType = "text/html",
            };
        } 
        #endregion
    }
}
