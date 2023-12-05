using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Common;

namespace PlanetExplorationManagement.Api.UnitTests.Application.v1.PlanetExplorations.GetPlanetExplorations
{
    [TestClass]
    public class GetPlanetExplorationsTests
    {
        private readonly IXPandDataProvider dataProvider;
        private readonly GetPlanetExplorationsRequestHandler handler;

        public GetPlanetExplorationsTests()
        {
            var database = new Database();
            dataProvider = database.Context;
            handler = new GetPlanetExplorationsRequestHandler(dataProvider);
        }

        [TestMethod]
        public async Task Given_GetPlanetExplorationsRequest_When_HandlerIsCalled_Then_ReturnPlanetExplorations()
        {
            // Arrange
            var request = new GetPlanetExplorationsRequest();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.PlanetExplorations.Should().NotBeNull();
            result.PlanetExplorations.Should().HaveCount(5);
            var firstPlanetExploration = result.PlanetExplorations.FirstOrDefault();
            firstPlanetExploration.Should().NotBeNull();
            firstPlanetExploration.PlanetExplorationId.Should().BeGreaterThan(0);
            firstPlanetExploration.PlanetId.Should().BeGreaterThan(0);
            firstPlanetExploration.PlanetName.Should().NotBeNullOrEmpty();
            firstPlanetExploration.PlanetImage.Should().NotBeNull();
            firstPlanetExploration.Observations.Should().NotBeNullOrEmpty();
            firstPlanetExploration.PlanetExplorationStatusId.Should().NotBe(0);
            firstPlanetExploration.Captain.Should().NotBeNull();
            firstPlanetExploration.Captain.UserId.Should().BeGreaterThan(0);
            firstPlanetExploration.Robots.Should().NotBeNull();
            firstPlanetExploration.Robots.Should().HaveCountGreaterThan(0);
            firstPlanetExploration.Robots.All(robot => robot.UserId > 0).Should().BeTrue();
        }
    }
}