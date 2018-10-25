using Xunit;
using AspNetCoreWebService.Controllers;
using Moq;
using LinkShortener.Engine.Services;

namespace AspNetCoreWebServiceTest.Controllers
{
    public class HelloControllerTest
    {
        [Fact]
        public void HealthyResponseTest()
        {
            InfoController controller = new InfoController();
            var response = controller.Get().Value as Response;
            Assert.Equal("Linkshortener service is up", response.output);
        }

        [Theory]
        [InlineData("http://www.fakedomain.com/query")]
        public void CreateShortenerTest(string inputUrl)
        {
            var mock = new Mock<ILinkShortenerService>();
            mock.Setup(p => p.OriginToShortener(inputUrl)).Returns(new System.Uri("http://www.mydomain.com/a"));
            LinksController controller = new LinksController(mock.Object);
            var result = (controller.CreateShortener(inputUrl) as Microsoft.AspNetCore.Mvc.OkObjectResult).Value;
            Assert.Equal(new System.Uri("http://www.mydomain.com/a"), result);
        }

        [Theory]
        [InlineData("http://www.mydomain.com/a")]
        public void RetrieveOriginTest(string inputUrl)
        {
            var mock = new Mock<ILinkShortenerService>();
            mock.Setup(p => p.ShortenerToOrigin(inputUrl)).Returns(new System.Uri("http://www.fakedomain.com/query"));
            LinksController controller = new LinksController(mock.Object);
            var result = (controller.RetrieveOrigin(inputUrl) as Microsoft.AspNetCore.Mvc.OkObjectResult).Value;
            Assert.Equal(new System.Uri("http://www.fakedomain.com/query"), result);
        }
    }
}
