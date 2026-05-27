using System;
using HttpServer.Core;
using Xunit;

namespace HttpServer.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parse_ValidGetRequest_ExtractsMethodAndPath()
        {
            // Arrange
            string raw = "GET /dashboard HTTP/1.1\r\nHost: localhost\r\n\r\n";

            // Act
            var request = HttpParser.Parse(raw);

            // Assert
            Assert.Equal("GET", request.Method);
            Assert.Equal("/dashboard", request.Path);
            Assert.Equal("localhost", request.Headers["Host"]);
        }
    }
}
