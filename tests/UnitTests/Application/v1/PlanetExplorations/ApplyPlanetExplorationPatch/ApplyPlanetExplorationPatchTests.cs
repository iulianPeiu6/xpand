using Application.Interfaces;
using Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;
using UnitTests.Common;

namespace UnitTests.Application.v1.PlanetExplorations.ApplyPlanetExplorationPatch
{
    [TestClass]
    public class ApplyPlanetExplorationPatchTests
    {
        private readonly IXPandDataProvider dataProvider;
        private readonly ApplyPlanetExplorationPatchRequestHandler handler;

        public ApplyPlanetExplorationPatchTests()
        {
            var database = new Database();
            dataProvider = database.Context;
            handler = new ApplyPlanetExplorationPatchRequestHandler(dataProvider);
        }

        [TestMethod]
        public async Task Given_ApplyPlanetExplorationPatchRequest_When_HandlerIsCalled_Then_ReturnPlanetExploration()
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = 1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", "/planetExplorationStatusId", null, Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk),
                        new Operation<PlanetExploration>("replace", "/observations", null, "Observations updated")
                    },
                    new DefaultContractResolver() // Add this line to provide the contractResolver
                )
            };



            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.PlanetExplorationId.Should().Be(1);
        }
    }
}
