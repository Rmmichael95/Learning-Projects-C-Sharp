using HttpServer.Core;
using Xunit;

namespace HttpServer.Tests
{
    public class RouterTests
    {
        [Fact]
        public void WebAppRouter_UnknownPath_Returns404()
        {
            // Arrange
            var router = new WebAppRouter();
            var mockRequest = new HttpRequest { Method = "GET", Path = "/this-does-not-exist" };

            // Act
            var response = router.Route(mockRequest);

            // Assert
            Assert.Equal(404, response.StatusCode);
        }
    }
}
