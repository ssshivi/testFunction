using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using System.Threading.Tasks;
using AzureFunctionApp;

namespace AzureFunctionApp.Tests
{
    public class HttpTriggerTests
    {
       [Fact]
        public async Task HttpTrigger_Should_Return_HelloWorld()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var request = context.Request;
            var logger = NullLoggerFactory.Instance.CreateLogger("Test");

            // Act
            var result = await HttpTrigger.Run(request, logger) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Hello, World!", result.Value);
        }
    }
}
