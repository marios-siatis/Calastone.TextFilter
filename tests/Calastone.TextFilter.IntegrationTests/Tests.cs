using System.Text;
using Calastone.TextFilter.Functions;
using Calastone.TextFilter.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;

namespace Calastone.TextFilter.IntegrationTests
{
    public class ProgramTests : IClassFixture<HostTestFixture>
    {
        private readonly HostTestFixture _fixture;

        public ProgramTests(HostTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TestHostConfiguration()
        {
            // Arrange
            var serviceProvider = _fixture.Host.Services;

            // Assert
            Assert.NotNull(serviceProvider.GetService<ITextFilterService>());
            Assert.NotNull(serviceProvider.GetService<IFileReaderService>());
        }


        [Fact]
        public async Task Function_ShouldRun()
        {
            // Arrange
            var args = new string[] { };
            var sut = _fixture.Host.Services.GetRequiredService<FilterTextHttpTrigger>();

            // Act
            var req = CreateMockRequest(new { Data = "Hello" });
            var response = await sut.Run(req.Object);

            // Assert
            var createdResult = (OkObjectResult)response;
            createdResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        private Mock<HttpRequest> CreateMockRequest(object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(json);

            var memoryStream = new MemoryStream(byteArray);
            memoryStream.Flush();
            memoryStream.Position = 0;

            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Body).Returns(memoryStream);

            return mockRequest;
        }
    }
}