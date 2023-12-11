using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Common;

namespace PlanetExplorationManagement.Api.UnitTests.Application.v1.PlanetExplorations.GetPlanetExplorations
{
    [TestClass]
    public class GetPlanetExplorationsTests
    {
        [TestMethod]
        public async Task Given_GetPlanetExplorationsRequest_When_HandlerIsCalled_Then_ReturnPlanetExplorations()
        {
            // Arrange
            var request = new GetPlanetExplorationsRequest();
            var database = new Database();
            var dataProvider = database.Context;
            var mockedAuth0Management = new Mock<IAuth0Management>();
            mockedAuth0Management.Setup(m => m.GetUsersByIdsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<UserDto>
            {
                new UserDto
                {
                    UserId = "google-oauth2|102590899082590583530",
                    FullName = "Iulian Cosmin Peiu"
                }
            });

            var handler = new GetPlanetExplorationsRequestHandler(dataProvider, mockedAuth0Management.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.PlanetExplorations.Should().NotBeNull();
            result.PlanetExplorations.Should().HaveCount(5);
            var firstPlanetExploration = result.PlanetExplorations.FirstOrDefault();
            firstPlanetExploration.Should().NotBeNull();
            firstPlanetExploration?.PlanetExplorationId.Should().BeGreaterThan(0);
            firstPlanetExploration?.PlanetId.Should().BeGreaterThan(0);
            firstPlanetExploration?.PlanetName.Should().NotBeNullOrEmpty();
            firstPlanetExploration?.PlanetImage.Should().NotBeNull();
            firstPlanetExploration?.Observations.Should().NotBeNullOrEmpty();
            firstPlanetExploration?.PlanetExplorationStatusId.Should().NotBe(0);
            firstPlanetExploration?.Captain.Should().NotBeNull();
            firstPlanetExploration?.Captain.UserId.Should().NotBeNullOrEmpty();
            firstPlanetExploration?.Captain.FullName.Should().NotBeNullOrEmpty();
            firstPlanetExploration?.Robots.Should().NotBeNull();
            firstPlanetExploration?.Robots.Should().HaveCountGreaterThan(0);
            firstPlanetExploration?.Robots.All(robot => !string.IsNullOrEmpty(robot.UserId)).Should().BeTrue();
            mockedAuth0Management.Verify(m => m.GetUsersByIdsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}