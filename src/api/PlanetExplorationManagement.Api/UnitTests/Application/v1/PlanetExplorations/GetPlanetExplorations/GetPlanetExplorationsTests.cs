using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PlanetExplorationManagement.Api.UnitTests.Application.v1.PlanetExplorations.GetPlanetExplorations
{
    [TestClass]
    public class GetPlanetExplorationsTests
    {
        [TestMethod]
        public async Task Given_GetPlanetExplorationsRequest_When_HandlerIsCalled_Then_ReturnPlanetExplorations()
        {
            // Arrange
            var dataProvider = new Mock<IXPandDataProvider>();
            var handler = new GetPlanetExplorationsRequestHandler(dataProvider.Object);
            var request = new GetPlanetExplorationsRequest();

            var planetExplorationsData = new List<PlanetExploration>
            {
                new PlanetExploration {  },
                new PlanetExploration {  }
            };

            dataProvider.Setup(dp => dp.Query<PlanetExploration>()).Returns(planetExplorationsData.AsQueryable());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.PlanetExplorations.Should().NotBeNull();
            result.PlanetExplorations.Should().HaveCount(planetExplorationsData.Count);
        }
    }
}